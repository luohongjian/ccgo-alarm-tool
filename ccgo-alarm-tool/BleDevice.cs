using System;
using System.Collections.Generic;
using System.Text;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.Devices.Bluetooth;
using Windows.Foundation;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.ComponentModel;

namespace ccgo_bluetooth_tool {

    class BleDeviceClient {
        private static string SERVICE_UUID = "6e400001-b5a3-f393-e0a9-e50e24dcca9e";
        private static string WRITE_UUID = "6e400002-b5a3-f393-e0a9-e50e24dcca9e";
        private static string NOTIFY_UUID = "6e400003-b5a3-f393-e0a9-e50e24dcca9e";


        private BluetoothLEDevice device;
        public GattDeviceService CurrentService;
        private string CurrentDeviceMAC = null;
        private string CurrentDeviceName = null;
        private BluetoothScanner scanner = null;
        private volatile bool Shutdown = false;
        private volatile bool stop = false;
        /// <summary>
        /// 写特征对象
        /// </summary>
        public GattCharacteristic CurrentWriteCharacteristic { get; set; }

        /// <summary>
        /// 通知特征对象
        /// </summary>
        public GattCharacteristic CurrentNotifyCharacteristic { get; set; }

        /// <summary>
        /// 特性通知类型通知启用
        /// </summary>
        private const GattClientCharacteristicConfigurationDescriptorValue CHARACTERISTIC_NOTIFICATION_TYPE = GattClientCharacteristicConfigurationDescriptorValue.Notify;

        /// <summary>
        /// 提示信息委托
        /// </summary>
        public delegate void MessageChangedEvent(int type, string message, byte[] data = null);

        /// <summary>
        /// 提示信息事件
        /// </summary>
        public event MessageChangedEvent MessageChanged;

        public BleDeviceClient(BluetoothLEDevice device, BluetoothScanner scanner)
        {
            this.device = device;
            this.CurrentDeviceName = device.Name;
            this.scanner = scanner;
        }

        public async Task Connect()
        {
            if (device == null) {
                return;
            }
            try {
                for (int i = 0; i < 3; i++) {
                    GattDeviceServicesResult result = await this.device.GetGattServicesForUuidAsync(Guid.Parse(SERVICE_UUID));
                    IReadOnlyList<GattDeviceService> list = result.Services;
                    if (list.Count < 1) {
                        MessageChanged(5, this.CurrentDeviceName + "设备连接失败--第" + (i + 1) + "次获取服务为空");
                        Thread.Sleep(2000);
                    } else {
                        this.CurrentService = list[0];
                        break;
                    }
                }
                if (this.CurrentService == null) {
                    MessageChanged(4, null);
                    return;
                }

                GattCharacteristicsResult CharactResult = await this.CurrentService.GetCharacteristicsAsync();
                if (CharactResult.Characteristics.Count < 2) {
                    MessageChanged(4, null);
                    return;
                }
                foreach (var c in CharactResult.Characteristics) {
                    string uuid = c.Uuid.ToString();
                    if (uuid.StartsWith("6e400002")) {
                        this.CurrentWriteCharacteristic = c;
                    } else if (uuid.StartsWith("6e400003")) {
                        this.CurrentNotifyCharacteristic = c;
                        this.CurrentNotifyCharacteristic.ProtectionLevel = GattProtectionLevel.Plain;
                        this.CurrentNotifyCharacteristic.ValueChanged += Characteristic_ValueChanged;
                        this.EnableNotifications(CurrentNotifyCharacteristic, 0);
                    }
                }
                byte[] _Bytes1 = BitConverter.GetBytes(this.device.BluetoothAddress);
                Array.Reverse(_Bytes1);
                this.CurrentDeviceMAC = BitConverter.ToString(_Bytes1, 2, 6).Replace('-', ':').ToLower();
                MessageChanged(6, this.CurrentDeviceMAC);
                this.device.ConnectionStatusChanged += this.CurrentDevice_ConnectionStatusChanged;
            } catch (Exception e) {
                MessageChanged(5, this.CurrentDeviceName + "连接异常" + e.ToString());
                this.device?.Dispose();
                this.CurrentService?.Dispose();
                MessageChanged(4, null);
            }
        }

        private void CurrentDevice_ConnectionStatusChanged(BluetoothLEDevice sender, object args)
        {
            MessageChanged(5, this.CurrentDeviceName + "设备连接状态" + sender.ConnectionStatus);
            if (sender.ConnectionStatus == BluetoothConnectionStatus.Disconnected) {
                sender.ConnectionStatusChanged -= CurrentDevice_ConnectionStatusChanged;
                this.CurrentService = null;
                if (!Shutdown) {
                    ReConnect(sender,1);
                }
            } else {
                // this.Write(Encoding.Default.GetBytes("8^1"));

            }
        }

        public async Task ReConnect(BluetoothLEDevice sender,int level)
        {
            MessageChanged(5,  "level:"+level);
            if (level > 5 || this.stop) {
                MessageChanged(5, this.CurrentDeviceName + "当前重连重试次数达到上限，退出测试");
                MessageChanged(4, null);
                this.device?.Dispose();
                this.CurrentService?.Dispose();
                return;
            }
            MessageChanged(5, this.CurrentDeviceName + "开始重新连接");
            this.device = sender;
            try {
                for (int i = 0; i < 3; i++) {
                    GattDeviceServicesResult result = await sender.GetGattServicesForUuidAsync(Guid.Parse(SERVICE_UUID));
                    IReadOnlyList<GattDeviceService> list = result.Services;
                    if (list.Count < 1) {
                        MessageChanged(5, this.CurrentDeviceName + "设备重新连接失败--第" + (i + 1) + "次获取服务为空");
                        Thread.Sleep(2000);
                    } else {
                        this.CurrentService = list[0];
                        break;
                    }
                }
                if (this.CurrentService == null || this.stop) {
                    this.device?.Dispose();
                    this.CurrentService?.Dispose();
                    MessageChanged(4, null);
                    return;
                }
                GattCharacteristicsResult CharactResult = await this.CurrentService.GetCharacteristicsAsync();
                if (CharactResult.Characteristics.Count < 2 || this.stop) {
                    this.device?.Dispose();
                    this.CurrentService?.Dispose();
                    MessageChanged(4, null);
                    return;
                }
                foreach (var c in CharactResult.Characteristics) {
                    string uuid = c.Uuid.ToString();
                    if (uuid.StartsWith("6e400002")) {
                        this.CurrentWriteCharacteristic = c;
                    } else if (uuid.StartsWith("6e400003")) {
                        this.CurrentNotifyCharacteristic = c;
                        this.CurrentNotifyCharacteristic.ProtectionLevel = GattProtectionLevel.Plain;
                        this.CurrentNotifyCharacteristic.ValueChanged += Characteristic_ValueChanged;
                        this.EnableNotifications(CurrentNotifyCharacteristic, 0);
                    }
                }
                this.device.ConnectionStatusChanged += this.CurrentDevice_ConnectionStatusChanged;
            } catch (Exception e) {
                MessageChanged(5, this.CurrentDeviceName + "重新连接异常" + e.ToString());
                Thread.Sleep(2000);
                if (!this.stop) {
                    ReConnect(sender, level++);
                }
                
            }
        }


        /// <summary>
        /// 设置特征对象为接收通知对象
        /// </summary>
        /// <param name="characteristic"></param>
        /// <returns></returns>
        public void EnableNotifications(GattCharacteristic characteristic, int level)
        {
            characteristic.WriteClientCharacteristicConfigurationDescriptorAsync(CHARACTERISTIC_NOTIFICATION_TYPE).Completed = async (asyncInfo, asyncStatus) => {
                if (asyncStatus == AsyncStatus.Completed) {
                    GattCommunicationStatus status = asyncInfo.GetResults();
                    if (status == GattCommunicationStatus.Unreachable) {
                        MessageChanged(5, this.CurrentDeviceName + "设备不可用");
                        if (CurrentNotifyCharacteristic != null) {
                            if (level > 5) {
                                return;
                            }
                            this.EnableNotifications(CurrentNotifyCharacteristic, level++);
                        }
                    } else if (status == GattCommunicationStatus.Success) {
                        MessageChanged(5, "下发指令8002");
                        //this.Write(Encoding.Default.GetBytes("8^1"));
                        this.Writes("8002");
                    }
                    MessageChanged(5, this.CurrentDeviceName + "设备连接状态" + status);
                }
            };
        }

        /// <summary>
        /// 接受到蓝牙数据
        /// </summary>
        private void Characteristic_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            byte[] data;
            CryptographicBuffer.CopyToByteArray(args.CharacteristicValue, out data);
            string msg = Encoding.Default.GetString(data);
            if (msg != null) {
                msg = msg.Replace("\r", "").Replace("\n", "");
            }
            if (this.stop) {
                this.Shutdown = true;
                return;
            }
            MessageChanged(2, msg);
            if ("2^1^1".Equals(msg)) {
                this.Shutdown = true;
            }
        }

        /// <summary>
        /// 发送数据接口
        /// </summary>
        public void Write(byte[] data)
        {
            if (CurrentWriteCharacteristic != null)
            {
                CurrentWriteCharacteristic.WriteValueAsync(CryptographicBuffer.CreateFromByteArray(data), GattWriteOption.WriteWithResponse);
            }

        }
        /// <summary>
        /// 发送数据接口
        /// </summary>
        public void Writes(String hexData)
        {
            if (CurrentWriteCharacteristic != null)
            {
                //CurrentWriteCharacteristic.WriteValueAsync(CryptographicBuffer.CreateFromByteArray(new byte[] { 128, 01 }), GattWriteOption.WriteWithResponse);
                CurrentWriteCharacteristic.WriteValueAsync(CryptographicBuffer.DecodeFromHexString(hexData), GattWriteOption.WriteWithResponse);
            }

        }

        public async void Dispose()
        {
            try {
                this.stop = true;
                this.Shutdown = true;
                if (this.device != null) {
                    this.device.Dispose();
                    this.device.ConnectionStatusChanged -= this.CurrentDevice_ConnectionStatusChanged;
                }
                this.CurrentService?.Dispose();
                this.device = null;
                this.CurrentDeviceMAC = null;
                this.CurrentDeviceName = null;
            } catch (Exception) {

            }
        }
    }
}
