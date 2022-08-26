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

namespace ccgo_bluetooth_tool
{

    class BluetoothScanner
    {
        private string START_LINE = "==================== 开始扫描设备 ====================";
        /// <summary>
        /// 搜索蓝牙设备对象
        /// </summary>
        private BluetoothLEAdvertisementWatcher deviceWatcher;
        private Dictionary<string, BluetoothLEDevice> DeviceDic = new Dictionary<string, BluetoothLEDevice>();
        private Regex Device_Imei = new Regex("[0-9]{15}");

        /// <summary>
        /// 提示信息委托
        /// </summary>
        public delegate void MessageChangedEvent(int type, string message, byte[] data = null);

        /// <summary>
        /// 提示信息事件
        /// </summary>
        public event MessageChangedEvent MessageChanged;

        public void Scanning()
        {
            this.DeviceDic.Clear();
            this.deviceWatcher = new BluetoothLEAdvertisementWatcher();
            this.deviceWatcher.ScanningMode = BluetoothLEScanningMode.Active;
            this.deviceWatcher.SignalStrengthFilter.InRangeThresholdInDBm = -80;
            this.deviceWatcher.SignalStrengthFilter.OutOfRangeThresholdInDBm = -90;
            this.deviceWatcher.SignalStrengthFilter.OutOfRangeTimeout = TimeSpan.FromMilliseconds(5000);
            this.deviceWatcher.SignalStrengthFilter.SamplingInterval = TimeSpan.FromMilliseconds(2000);
            this.deviceWatcher.Received += DeviceWatcher_Received;
            this.deviceWatcher.Start();
        }

        private void DeviceWatcher_Received(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {
            BluetoothLEDevice.FromBluetoothAddressAsync(args.BluetoothAddress).Completed = async (asyncInfo, asyncStatus) => {
                if (asyncStatus == AsyncStatus.Completed)
                {
                    if (asyncInfo.GetResults() != null)
                    {
                        BluetoothLEDevice currentDevice = asyncInfo.GetResults();
                        if (!Device_Imei.IsMatch(currentDevice.Name))
                        {
                            return;
                        }
                        if (!this.DeviceDic.ContainsKey(currentDevice.Name))
                        {
                            this.DeviceDic.Add(currentDevice.Name, currentDevice);
                            MessageChanged(1, currentDevice.Name);
                        }
                    }
                }
            };

        }

        public BleDeviceClient Testing_Start(string deviceName)
        {
            BluetoothLEDevice device = this.DeviceDic[deviceName];
            if (device == null)
            {
                return null;
            }
            return new BleDeviceClient(device,this);
        }

        /// <summary>
        /// 停止搜索蓝牙
        /// </summary>
        public void StopBleDeviceWatcher()
        {
            this.deviceWatcher.Stop();
        }

    }
}
