using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

namespace ccgo_bluetooth_tool
{
    public partial class Ccgo_tool_form : Form
    {

        private SetDataManage setManage = new SetDataManage();
        private BluetoothScanner scanner = new BluetoothScanner();
        private Dictionary<string, string> companies = new Dictionary<string, string>();
        private volatile  bool running = false;
        private bool setPlatform = false;
        private bool closeNB = false;
        private bool changing = false;
        Label[] resultLabels = null;
        Label[] btnLabels = null;
        Button[] resultBtns = null;
        Button[] optBtns = null;
        private int excuteNum = 0;
        private int[] excVals = new int[19];
        private string keyStatus = "";
        private string current_mac = "";
        private string[] gps = null;
        private BleDeviceClient bleClient;
        private static readonly Object LockObj = new object();
        private string START_LINE = "==================== 开始执行本轮测试 ====================";
        private string SINGLE_LINE = "----------------------------------------------------------";
        private string EXC_OVER = "====================== 本轮测试结束 ======================";
        private string SCAN_LINE = "====================== 开始扫描设备 ======================";
        private string SCAN_END = "======================= 停止扫描设备 ======================";

        public Ccgo_tool_form()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Form_load(object sender, EventArgs e)
        {

            Init_setting();
            Init_Coms();
            Reset_coms_status();
            scanner.MessageChanged += BleCore_MessageChanged;
            Process_log(SCAN_LINE);
            scanner.Scanning();
        }


        private void Init_setting()
        {
            String val = setManage.readSetStr();
            if (null == val || "".Equals(val))
            {
                val = "10,3,40,-80,0,0";
            }
            String[] nums = val.Split(',');
            csq_shold.Text = nums[0];
            gps_num.Text = nums[1];
            gps_shold.Text = nums[2];
            wifi_shold.Text = nums[3];
        }

        private void Init_Coms()
        {
            resultLabels = new Label[12] { lbl_imei, lbl_imsi, lbl_ccid, lbl_csq, lbl_wifi, lbl_soft_version, lbl_mod_version, lbl_net, lbl_gps_status, lbl_gps_loca, lbl_shock, lbl_acc_status };
            btnLabels = new Label[5] { lbl_vbat, lbl_beep,  lbl_shutdown, lbl_led, lbl_oile };
            resultBtns = new Button[5] { btn_vbat,  btn_beep, btn_sd_result, btn_led, btn_oile };
            optBtns = new Button[3] { btn_shutdown, btn_close_bluetoothKey, btn_open_bluetoothKey };
        }

        private void Reset_coms_status()
        {
            String lblResultText = running ? "执行中" : "未执行";
            
            for (int i = 0; i < resultLabels.Length; i++)
            {
                Label lbl = resultLabels[i];
                lbl.Text = lblResultText;
                lbl.ForeColor = Color.Black;
            }
            
            for (int i = 0; i < resultBtns.Length; i++)
            {
                resultBtns[i].Visible = running;
                resultBtns[i].Enabled = running;
                btnLabels[i].Visible = !running;
                btnLabels[i].Text = lblResultText;
                btnLabels[i].ForeColor = Color.Black;
            }

            for (int i = 0; i < optBtns.Length; i++)
            {
                //optBtns[i].Visible = running;
                optBtns[i].Enabled = running;
            }
            btn_restart.Enabled = running;
            btn_submit.Enabled = false;
            changing = true;
            t_imei.Text = "";
            t_imsi.Text = "";
            t_ccid.Text = "";
            t_csq.Text = "";
            t_wifi.Text = "";
            t_soft_version.Text = "";
            t_mod_version.Text = "";
            lbl_net_result.Text = "-";
            lbl_gpsStatus_result.Text = "-";
            lbl_gpsloca_result.Text = "-";
            lbl_shock_result.Text = "-";
            lbl_accStatus_result.Text = "-";
            lbl_vbat_result.Text = "-";
            changing = false;

            excuteNum = 0;
            excVals = new int[19];
            keyStatus = "";
            current_mac = "";
            gps = null;
            setPlatform = false;
            closeNB = false;
        }

        /// <summary>
        /// 提示消息
        /// </summary>
        private void BleCore_MessageChanged(int type, string msg, byte[] data)
        {

            RunAsync(() => {
                if (type == 1)
                {
                    this.Add_Device(msg);
                }
                else if (type == 2)
                {
                    this.On_BleTestMsg(msg);
                }
                else if (type == 3)
                {
                    this.Log_Send_Msg(msg);
                }
                else if (type == 4)
                {

                    this.Restart_Test();
                }
                else if (type == 5)
                {
                    this.Process_log("####" + msg);
                }
                else if (type == 6)
                {
                    this.current_mac = msg.ToUpper();
                    this.Log_Send_Msg("获取到MAC地址为：" + msg.ToUpper());
                    btn_submit.Enabled = true;
                }

            });
        }

        private void Add_Device(string deviceName)
        {
            this.list_device_box.Items.Add(deviceName);
        }

        private void On_BleTestMsg(string msg)
        {
            if (!running) return;
            if (msg == null || msg.Length < 1)
            {
                return;
            }
            comresultWrite(true, msg);
            if (new Regex("imsi:.+").IsMatch(msg))
            {
                excuteNum++;
                if (excuteNum == 100) { //manageOver();
                }
                if (excVals[1] == 1) return;
                t_imsi.Text = msg.Split(':')[1];
                lblResultShow(lbl_imsi, !"error".Equals(t_imsi.Text), 1);
            }
            else if (new Regex("imei:.+").IsMatch(msg))
            {
                if (excVals[2] == 1) return;
                t_imei.Text = msg.Split(':')[1];
                lblResultShow(lbl_imei, !"error".Equals(t_imei.Text), 2);
            }
            else if (new Regex("ccid:.+").IsMatch(msg))
            {
                if (excVals[3] == 1) return;
                t_ccid.Text = msg.Split(':')[1];
                lblResultShow(lbl_ccid, !"error".Equals(t_ccid.Text), 3);
            }
            else if (new Regex("csq.+").IsMatch(msg))
            {    
                if (msg.Contains("err")) return;
                msg = msg.Replace(" ", "");
                string valStr = msg.Split(':')[1];
                int csq = int.Parse(valStr);
                int csq_shold_value = int.Parse(csq_shold.Text);
                if (excVals[4] == 1) return; 
                t_csq.Text = valStr;
                lblResultShow(lbl_csq, !(99 == csq || csq < csq_shold_value), 4);
            }
            else if (new Regex("wifi:.+").IsMatch(msg))
            {
                if (excVals[5] == 1) return;
                string[] cwStrs = msg.Split('|');
                if (cwStrs.Length > 0)
                {
                    for (int i = 0; i < cwStrs.Length; i++)
                    {
                        string mac = cwStrs[i];
                        if (mac == null || "".Equals(mac))
                        {
                            continue;
                        }
                        string[] wifi = mac.Split(',');
                        t_wifi.Text = wifi[1];
                        int wifi_gps = int.Parse(wifi[1]);
                        bool flag = wifi_gps > int.Parse(wifi_shold.Text);
                        lblResultShow(lbl_wifi, flag, 5);
                        if (flag) break;

                    }
                }
            }
            else if (new Regex("^soft version:.+").IsMatch(msg))
            {
                if (excVals[6] == 1) return;
                t_soft_version.Text = msg.Split(':')[1];
                lblResultShow(lbl_soft_version, true, 6);
            }
            else if (new Regex("^nb version:.+").IsMatch(msg))
            {
                if (excVals[7] == 1) return;
                t_mod_version.Text = msg.Split(':')[1];
                lblResultShow(lbl_mod_version, true, 7);
            }
            else if (new Regex("net.+").IsMatch(msg))
            {
                if (excVals[8] == 1) return;
                string net = msg.Split(' ')[2];
                if (net.ToLower().Contains("ok"))
                {
                    lbl_net_result.Text = "正常";
                    lblResultShow(lbl_net, true, 8);
                }
                else
                {
                    lbl_net_result.Text = "异常";
                    lblResultShow(lbl_net, false, 8);
                }
            }
            else if (new Regex("\\$.*GSV.*").IsMatch(msg))
            {
                if (excVals[9] == 1) return;

                string[] gpsStr = msg.Split(',');
                if (gpsStr.Length < 3) return;
                int count = int.Parse("".Equals(gpsStr[1]) ? "0" : gpsStr[1]);
                int num = int.Parse("".Equals(gpsStr[2]) ? "0" : gpsStr[2]);
                int cn_shold = int.Parse(gps_shold.Text);
                int num_shold = int.Parse(gps_num.Text);

                if (1 == num) gps = new string[count];
                try
                {
                    if (gps != null)
                    {
                        if (num > gps.Length)
                        {
                            return;
                        }
                        gps[num - 1] = msg;
                        int starNum = 0;
                        if (count == num)
                        {
                            int cunNum = 0;
                            foreach (string ss in gps)
                            {
                                if (null == ss || "".Equals(ss)) continue;
                                string[] tmp = ss.Split(',');
                                if (!new Regex("^\\d+$").IsMatch(tmp[3]))
                                {
                                    continue;
                                }
                                starNum = int.Parse(tmp[3]);
                                int leng = (tmp.Length - 5) / 4;
                                int p = 0;
                                for (int i = 0; i < leng; i++)
                                {
                                    p = i == 0 ? 7 : (p + 4);
                                    if (null == tmp[p] || "".Equals(tmp[p])) continue;
                                    int cn = int.Parse(tmp[p]);
                                    if (cn >= cn_shold) cunNum++;
                                }
                            }
                            lbl_gpsStatus_result.Text = "获取到卫星" + starNum + "颗," + cunNum + "颗星C/N达到" + cn_shold;
                            lblResultShow(lbl_gps_status, cunNum >= num_shold, 9);
                        }
                    }
                }
                catch (Exception e)
                {
                    setManage.writeErrorLog(e);
                }
            }
            else if (new Regex("\\$.*GGA.*").IsMatch(msg))
            {
                if (excVals[10] == 1) return;
                string[] lnglot = msg.Split(',');
                bool b = (lnglot.Length > 4 && null != lnglot[2] && !"".Equals(lnglot[2]));
                lbl_gpsloca_result.Text = b ? "获取位置信息成功" : "获取位置信息失败";
                lblResultShow(lbl_gps_loca, b, 10);
            }
            else if (new Regex("sensor irq:.+").IsMatch(msg))
            {

                if (excVals[11] == 1) return;
                string irq = msg.Substring(11, 1);
                bool b;
                if ("1".Equals(irq))
                {
                    lbl_shock_result.Text = "震动传感器读取正常";
                    b = true;
                }
                else
                {
                    lbl_shock_result.Text = "震动传感器读取异常";
                    b = false;
                }
                lblResultShow(lbl_shock, b, 11);
            }
            else if (new Regex("acc.+").IsMatch(msg))
            {

                if (excVals[12] == 1) return;
                string acc = msg.Split(' ')[1];
                if ("on".Equals(acc))
                {
                    lbl_accStatus_result.Text = "正常";
                    lblResultShow(lbl_acc_status, true, 12);
                }
                else
                {
                    lbl_accStatus_result.Text = "异常";
                    lblResultShow(lbl_acc_status, false, 12);
                }
            }
            else if (new Regex("vbat:.+").IsMatch(msg))
            {
                lbl_vbat_result.Text = msg.Substring(5);
            }
            //else if (new Regex(".*REBOOT_CAUSE_SECURITY_RESET.*").IsMatch(msg)) {
            //    lbl_reset_result.Text = "复位成功";
            //} 



        }

        private void Log_Send_Msg(string msg)
        {
            comresultWrite(false, msg);
        }

        // 异步线程
        public static void RunAsync(Action action)
        {
            ((Action)(delegate () {
                action.Invoke();
            })).BeginInvoke(null, null);
        }

        public delegate void WriteLogEntryDelegate(string message);
        public void Process_log(string message)
        {
            if (comresult.InvokeRequired == true) {
                var d = new WriteLogEntryDelegate(Process_log);
                this.Invoke(d, message);
            } else {
                lock (LockObj) {
                    if (comresult.TextLength > 10000) {
                        comresult.ResetText();
                        comresult.AppendText("数据过长-自动清理\r\n");
                    }
                    comresult.AppendText(message + "\r\n");
                    comresult.ScrollToCaret();
                }
            }
        }

        private void comresultWrite(bool reciveflag, string message)
        {
            if (!running) return;
            Process_log("[" + DateTime.Now.ToString("HH:mm:ss.fff") + "]" + (reciveflag ? "收" : "发") + "←◆" + message);
        }

        private void setTextChange()
        {
            setManage.writeSetStr(csq_shold.Text, gps_num.Text, gps_shold.Text, wifi_shold.Text, 0, 0);
        }

        private void gps_num_TextChanged(object sender, EventArgs e)
        {
            setTextChange();
        }

        private void gps_shold_TextChanged(object sender, EventArgs e)
        {
            setTextChange();
        }

        private void csq_shold_TextChanged(object sender, EventArgs e)
        {
            setTextChange();
        }

        private void wifi_shold_TextChanged(object sender, EventArgs e)
        {
            setTextChange();
        }

        private void cb_company_SelectedIndexChanged(object sender, EventArgs e)
        {
            setTextChange();
        }

        private void cb_Platform_SelectedIndexChanged(object sender, EventArgs e)
        {
            setPlatform = false;
            setTextChange();
        }

        private void btn_clean_Click(object sender, EventArgs e)
        {
            comresult.Text = "";
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            string value = (string)list_device_box.SelectedItem;
            if (value == null || "".Equals(value))
            {
                MessageBox.Show("请先选择测试设备.");
                return;
            }
            bleClient = scanner.Testing_Start(value);
            if (bleClient == null) {
                Process_log("开启测试失败-获取设备异常");
                return;
            }
            list_device_box.Enabled = false;
            btn_re_scan.Enabled = false;
            btn_start.Enabled = false;
            scanner.StopBleDeviceWatcher();
            Process_log(SCAN_END);
            Process_log(START_LINE);
            Process_log("开始连接至-" + value);
            this.running = true;
            this.Reset_coms_status();
            bleClient.MessageChanged += BleCore_MessageChanged;
            bleClient.Connect();
        }

        private void Restart_Test()
        {
            this.running = false;
            Process_log(EXC_OVER);
            list_device_box.Items.Clear();
            Process_log(SCAN_LINE);
            scanner.Scanning();
            list_device_box.Enabled = true;
            btn_re_scan.Enabled = true;
            this.Reset_coms_status();
        }

        private void list_device_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_start.Enabled = list_device_box.SelectedItem != null && !"".Equals(list_device_box.SelectedItem);
        }

        private void lblResultShow(Label lbl, bool b, int index)
        {
            if (excVals[index] == 1) return;
            lbl.Visible = true;
            if (b)
            {
                lbl.Text = "通过";
                lbl.ForeColor = Color.Blue;
                excVals[index] = 1;
            }
            else
            {
                lbl.Text = "未通过";
                lbl.ForeColor = Color.Red;
                excVals[index] = 0;
            }
            VerifyValue();
        }

        private void VerifyValue()
        {
            if (excVals.Length == 0) return;

            if (Array.IndexOf(excVals, 0) == -1)
            {
                btn_submit.Enabled = true;
                Process_log("================== 测试项全部执行通过 ===================");
                running = false;
            }
            else if(!running){
                running = true;
                btn_submit.Enabled = false;
            }
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            bleClient.MessageChanged -= BleCore_MessageChanged;
            bleClient.Dispose();
            bleClient = null;
            comresult.Clear();
            Restart_Test();
        }

        private void btn_vbat_Click(object sender, EventArgs e)
        {
            btn_vbat.Visible = false;
            lblResultShow(lbl_vbat, true, 12);
        }


        private void btn_beep_Click(object sender, EventArgs e)
        {
            btn_beep.Visible = false;
            lblResultShow(lbl_beep, true, 14);
        }


        private void btn_led_Click(object sender, EventArgs e)
        {
            btn_led.Visible = false;
            lblResultShow(lbl_led, true, 16);
        }
        private void btn_oile_Click(object sender, EventArgs e)
        {
            btn_led.Visible = false;
            lblResultShow(lbl_oile, true, 16);
        }


        private void btn_sd_result_Click(object sender, EventArgs e)
        {
            btn_sd_result.Visible = false;
            lblResultShow(lbl_shutdown, true, 18);
        }

        private void btn_open_beep_Click(object sender, EventArgs e)
        {
            Process_log("下发开启蜂鸣器指令-10^1");
            bleClient.Write(Encoding.Default.GetBytes("10^1"));
        }

        private void btn_in_sleep_Click(object sender, EventArgs e)
        {
            Process_log("下发开启休眠模式指令-8004");
            bleClient.Write(Encoding.Default.GetBytes("9^1"));
        }

        private void btn_open_bluetoothKe_Click(object sender, EventArgs e)
        {
            Process_log("下发允许蓝牙钥匙配对指令-8005");
            bleClient.Writes("8005");
        }

        private void btn_close_bluetoothKe_Click(object sender, EventArgs e)
        {
            Process_log("下发禁止蓝牙钥匙配对指令-8006");
            bleClient.Writes("8006");
        }

        private void btn_shutdown_Click(object sender, EventArgs e)
        {
            int index = Array.IndexOf(excVals, 0);
            if (index != -1 && index != 18)
            {
                DialogResult result = MessageBox.Show("暂有其他测试项未通过，确认关机？", "关机提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (DialogResult.OK != result)
                {
                    return;
                }
            }
            Process_log("下发关机指令-8004");
            //bleClient.Write(Encoding.Default.GetBytes("2^1"));
            bleClient.Writes("8004");
        }


        private void btn_submit_Click(object sender, EventArgs e)
        {
            btn_submit.Enabled = false;
            if (current_mac == null || "".Equals(current_mac))
            {
                MessageBox.Show("当前无mac地址，无法提交");
                return;
            }
            string imei = (string)list_device_box.SelectedItem;
            if (imei == null || "".Equals(imei)) {
                MessageBox.Show("当前无设备IMEI，无法提交");
                return;
            }
            string result = setManage.uploadDeviceInfo2Cloud(imei,current_mac.ToUpper());
            if (MessageBox.Show(result, "提交结果", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                btn_submit.Enabled = true;
                if ("提交成功！".Equals(result))
                {
                    bleClient.MessageChanged -= BleCore_MessageChanged;
                    bleClient.Dispose();
                    bleClient = null;
                    Restart_Test();
                }
            }
        }

        private void btn_re_scan_Click(object sender, EventArgs e)
        {
            list_device_box.Items.Clear();
            scanner.StopBleDeviceWatcher();
            scanner.Scanning();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void lbl_led_Click(object sender, EventArgs e)
        {

        }

        private void lbl_oile_Click(object sender, EventArgs e)
        {

        }
        private void labe130_Click(object sender, EventArgs e)
        {

        }

        private void lbl_bma_Click(object sender, EventArgs e)
        {

        }

        private void lbl_bma_result_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lbl_shock_Click(object sender, EventArgs e)
        {

        }
        private void lbl_shock_result_Click(object sender, EventArgs e)
        {

        }
        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void label32_Click(object sender, EventArgs e)
        {

        }
        private void lbl_accStatus_result_Click(object sender, EventArgs e)
        {

        }
        private void lbl_acc_status_Click(object sender, EventArgs e)
        {

        }

        private void lbl_gpsStatus_result_Click(object sender, EventArgs e)
        {

        }

        private void lbl_gps_status_Click(object sender, EventArgs e)
        {

        }

        private void gpb1_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_gps_loca_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lbl_imsi_Click(object sender, EventArgs e)
        {

        }
        private void lbl_imei_Click(object sender, EventArgs e)
        {

        }
    }
}
