namespace ccgo_bluetooth_tool {
    partial class Ccgo_tool_form {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            bleClient?.Dispose();
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ccgo_tool_form));
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_beep = new System.Windows.Forms.Label();
            this.lbl_vbat = new System.Windows.Forms.Label();
            this.gps_shold = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.wifi_shold = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.gps_num = new System.Windows.Forms.TextBox();
            this.csq_shold = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_beep = new System.Windows.Forms.Button();
            this.btn_vbat = new System.Windows.Forms.Button();
            this.lbl_imsi = new System.Windows.Forms.Label();
            this.lbl_imei = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comresult = new System.Windows.Forms.RichTextBox();
            this.lbl_ccid = new System.Windows.Forms.Label();
            this.lbl_csq = new System.Windows.Forms.Label();
            this.lbl_net = new System.Windows.Forms.Label();
            this.lbl_gps_status = new System.Windows.Forms.Label();
            this.lbl_acc_status = new System.Windows.Forms.Label();
            this.lbl_gps_loca = new System.Windows.Forms.Label();
            this.lbl_shock = new System.Windows.Forms.Label();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btn_clean = new System.Windows.Forms.Button();
            this.btn_restart = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_open_bluetoothKey = new System.Windows.Forms.Button();
            this.btn_close_bluetoothKey = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.lbl_vbat_result = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.list_device_box = new System.Windows.Forms.ListBox();
            this.label21 = new System.Windows.Forms.Label();
            this.gpb1 = new System.Windows.Forms.GroupBox();
            this.lbl_mod_version = new System.Windows.Forms.Label();
            this.lbl_soft_version = new System.Windows.Forms.Label();
            this.t_mod_version = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.t_soft_version = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_led = new System.Windows.Forms.Label();
            this.btn_led = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.lbl_oile = new System.Windows.Forms.Label();
            this.btn_oile = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.lbl_shutdown = new System.Windows.Forms.Label();
            this.btn_sd_result = new System.Windows.Forms.Button();
            this.btn_shutdown = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.lbl_wifi = new System.Windows.Forms.Label();
            this.t_wifi = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lbl_shock_result = new System.Windows.Forms.Label();
            this.lbl_gpsloca_result = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbl_gpsStatus_result = new System.Windows.Forms.Label();
            this.lbl_accStatus_result = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lbl_net_result = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.t_csq = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.t_ccid = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.t_imsi = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.t_imei = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.btn_re_scan = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "GPS阈值：";
            // 
            // lbl_beep
            // 
            this.lbl_beep.AutoSize = true;
            this.lbl_beep.Location = new System.Drawing.Point(415, 381);
            this.lbl_beep.Name = "lbl_beep";
            this.lbl_beep.Size = new System.Drawing.Size(41, 12);
            this.lbl_beep.TabIndex = 52;
            this.lbl_beep.Text = "未执行";
            this.lbl_beep.Visible = false;
            // 
            // lbl_vbat
            // 
            this.lbl_vbat.AutoSize = true;
            this.lbl_vbat.Location = new System.Drawing.Point(415, 348);
            this.lbl_vbat.Name = "lbl_vbat";
            this.lbl_vbat.Size = new System.Drawing.Size(41, 12);
            this.lbl_vbat.TabIndex = 50;
            this.lbl_vbat.Text = "未执行";
            this.lbl_vbat.Visible = false;
            // 
            // gps_shold
            // 
            this.gps_shold.Location = new System.Drawing.Point(167, 20);
            this.gps_shold.Name = "gps_shold";
            this.gps_shold.Size = new System.Drawing.Size(26, 21);
            this.gps_shold.TabIndex = 12;
            this.gps_shold.Tag = "9999";
            this.gps_shold.TextChanged += new System.EventHandler(this.gps_shold_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "颗星C/N达到";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.wifi_shold);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.gps_shold);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.gps_num);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.csq_shold);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(414, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 55);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "参数设置";
            // 
            // wifi_shold
            // 
            this.wifi_shold.Location = new System.Drawing.Point(445, 20);
            this.wifi_shold.Name = "wifi_shold";
            this.wifi_shold.Size = new System.Drawing.Size(29, 21);
            this.wifi_shold.TabIndex = 16;
            this.wifi_shold.Tag = "9999";
            this.wifi_shold.TextChanged += new System.EventHandler(this.wifi_shold_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(359, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 15;
            this.label13.Text = "WIFI强度阈值：";
            // 
            // gps_num
            // 
            this.gps_num.Location = new System.Drawing.Point(65, 19);
            this.gps_num.Name = "gps_num";
            this.gps_num.Size = new System.Drawing.Size(27, 21);
            this.gps_num.TabIndex = 10;
            this.gps_num.Tag = "9999";
            this.gps_num.TextChanged += new System.EventHandler(this.gps_num_TextChanged);
            // 
            // csq_shold
            // 
            this.csq_shold.Location = new System.Drawing.Point(297, 20);
            this.csq_shold.Name = "csq_shold";
            this.csq_shold.Size = new System.Drawing.Size(40, 21);
            this.csq_shold.TabIndex = 8;
            this.csq_shold.Tag = "9999";
            this.csq_shold.TextChanged += new System.EventHandler(this.csq_shold_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "信号强度阈值：";
            // 
            // btn_beep
            // 
            this.btn_beep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_beep.Location = new System.Drawing.Point(415, 376);
            this.btn_beep.Name = "btn_beep";
            this.btn_beep.Size = new System.Drawing.Size(41, 23);
            this.btn_beep.TabIndex = 47;
            this.btn_beep.Text = "通过";
            this.btn_beep.UseVisualStyleBackColor = true;
            this.btn_beep.Click += new System.EventHandler(this.btn_beep_Click);
            // 
            // btn_vbat
            // 
            this.btn_vbat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_vbat.Location = new System.Drawing.Point(415, 343);
            this.btn_vbat.Name = "btn_vbat";
            this.btn_vbat.Size = new System.Drawing.Size(41, 23);
            this.btn_vbat.TabIndex = 45;
            this.btn_vbat.Text = "通过";
            this.btn_vbat.UseVisualStyleBackColor = true;
            this.btn_vbat.Click += new System.EventHandler(this.btn_vbat_Click);
            // 
            // lbl_imsi
            // 
            this.lbl_imsi.AutoSize = true;
            this.lbl_imsi.Location = new System.Drawing.Point(416, 54);
            this.lbl_imsi.Name = "lbl_imsi";
            this.lbl_imsi.Size = new System.Drawing.Size(41, 12);
            this.lbl_imsi.TabIndex = 44;
            this.lbl_imsi.Text = "未执行";
            this.lbl_imsi.Click += new System.EventHandler(this.lbl_imsi_Click);
            // 
            // lbl_imei
            // 
            this.lbl_imei.AutoSize = true;
            this.lbl_imei.Location = new System.Drawing.Point(416, 29);
            this.lbl_imei.Name = "lbl_imei";
            this.lbl_imei.Size = new System.Drawing.Size(41, 12);
            this.lbl_imei.TabIndex = 44;
            this.lbl_imei.Text = "未执行";
            this.lbl_imei.Click += new System.EventHandler(this.lbl_imei_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comresult);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(17, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 454);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "执行过程";
            // 
            // comresult
            // 
            this.comresult.BackColor = System.Drawing.SystemColors.HighlightText;
            this.comresult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.comresult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comresult.Location = new System.Drawing.Point(3, 17);
            this.comresult.Name = "comresult";
            this.comresult.ReadOnly = true;
            this.comresult.Size = new System.Drawing.Size(376, 434);
            this.comresult.TabIndex = 0;
            this.comresult.Text = "";
            // 
            // lbl_ccid
            // 
            this.lbl_ccid.AutoSize = true;
            this.lbl_ccid.Location = new System.Drawing.Point(415, 80);
            this.lbl_ccid.Name = "lbl_ccid";
            this.lbl_ccid.Size = new System.Drawing.Size(41, 12);
            this.lbl_ccid.TabIndex = 43;
            this.lbl_ccid.Text = "未执行";
            // 
            // lbl_csq
            // 
            this.lbl_csq.AutoSize = true;
            this.lbl_csq.Location = new System.Drawing.Point(415, 109);
            this.lbl_csq.Name = "lbl_csq";
            this.lbl_csq.Size = new System.Drawing.Size(41, 12);
            this.lbl_csq.TabIndex = 42;
            this.lbl_csq.Text = "未执行";
            // 
            // lbl_net
            // 
            this.lbl_net.AutoSize = true;
            this.lbl_net.Location = new System.Drawing.Point(415, 219);
            this.lbl_net.Name = "lbl_net";
            this.lbl_net.Size = new System.Drawing.Size(41, 12);
            this.lbl_net.TabIndex = 41;
            this.lbl_net.Text = "未执行";
            // 
            // lbl_gps_status
            // 
            this.lbl_gps_status.AutoSize = true;
            this.lbl_gps_status.Location = new System.Drawing.Point(415, 245);
            this.lbl_gps_status.Name = "lbl_gps_status";
            this.lbl_gps_status.Size = new System.Drawing.Size(41, 12);
            this.lbl_gps_status.TabIndex = 40;
            this.lbl_gps_status.Text = "未执行";
            this.lbl_gps_status.Click += new System.EventHandler(this.lbl_gps_status_Click);
            // 
            // lbl_acc_status
            // 
            this.lbl_acc_status.AutoSize = true;
            this.lbl_acc_status.Location = new System.Drawing.Point(415, 322);
            this.lbl_acc_status.Name = "lbl_acc_status";
            this.lbl_acc_status.Size = new System.Drawing.Size(41, 12);
            this.lbl_acc_status.TabIndex = 40;
            this.lbl_acc_status.Text = "未执行";
            this.lbl_acc_status.Click += new System.EventHandler(this.lbl_acc_status_Click);
            // 
            // lbl_gps_loca
            // 
            this.lbl_gps_loca.AutoSize = true;
            this.lbl_gps_loca.Location = new System.Drawing.Point(415, 270);
            this.lbl_gps_loca.Name = "lbl_gps_loca";
            this.lbl_gps_loca.Size = new System.Drawing.Size(41, 12);
            this.lbl_gps_loca.TabIndex = 39;
            this.lbl_gps_loca.Text = "未执行";
            this.lbl_gps_loca.Click += new System.EventHandler(this.lbl_gps_loca_Click);
            // 
            // lbl_shock
            // 
            this.lbl_shock.AutoSize = true;
            this.lbl_shock.Location = new System.Drawing.Point(415, 297);
            this.lbl_shock.Name = "lbl_shock";
            this.lbl_shock.Size = new System.Drawing.Size(41, 12);
            this.lbl_shock.TabIndex = 38;
            this.lbl_shock.Text = "未执行";
            this.lbl_shock.Click += new System.EventHandler(this.lbl_shock_Click);
            // 
            // btn_submit
            // 
            this.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_submit.Location = new System.Drawing.Point(348, 565);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(100, 23);
            this.btn_submit.TabIndex = 33;
            this.btn_submit.Text = "完成并提交";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_clean
            // 
            this.btn_clean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clean.Location = new System.Drawing.Point(229, 565);
            this.btn_clean.Name = "btn_clean";
            this.btn_clean.Size = new System.Drawing.Size(100, 23);
            this.btn_clean.TabIndex = 31;
            this.btn_clean.Text = "清除端口打印";
            this.btn_clean.UseVisualStyleBackColor = true;
            this.btn_clean.Click += new System.EventHandler(this.btn_clean_Click);
            // 
            // btn_restart
            // 
            this.btn_restart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_restart.Location = new System.Drawing.Point(118, 565);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(100, 23);
            this.btn_restart.TabIndex = 30;
            this.btn_restart.Text = "重新开始";
            this.btn_restart.UseVisualStyleBackColor = true;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // btn_start
            // 
            this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_start.Location = new System.Drawing.Point(12, 565);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(100, 23);
            this.btn_start.TabIndex = 29;
            this.btn_start.Text = "执行";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_open_bluetoothKey
            // 
            this.btn_open_bluetoothKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_open_bluetoothKey.Location = new System.Drawing.Point(13, 526);
            this.btn_open_bluetoothKey.Name = "btn_open_bluetoothKey";
            this.btn_open_bluetoothKey.Size = new System.Drawing.Size(100, 23);
            this.btn_open_bluetoothKey.TabIndex = 26;
            this.btn_open_bluetoothKey.Text = "允许蓝牙钥匙";
            this.btn_open_bluetoothKey.UseVisualStyleBackColor = true;
            this.btn_open_bluetoothKey.Click += new System.EventHandler(this.btn_open_bluetoothKe_Click);
            // 
            // btn_close_bluetoothKey
            // 
            this.btn_close_bluetoothKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close_bluetoothKey.Location = new System.Drawing.Point(119, 526);
            this.btn_close_bluetoothKey.Name = "btn_close_bluetoothKey";
            this.btn_close_bluetoothKey.Size = new System.Drawing.Size(100, 23);
            this.btn_close_bluetoothKey.TabIndex = 26;
            this.btn_close_bluetoothKey.Text = "禁止蓝牙钥匙";
            this.btn_close_bluetoothKey.UseVisualStyleBackColor = true;
            this.btn_close_bluetoothKey.Click += new System.EventHandler(this.btn_close_bluetoothKe_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(26, 381);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
            this.label26.TabIndex = 22;
            this.label26.Text = "蜂鸣器：";
            // 
            // lbl_vbat_result
            // 
            this.lbl_vbat_result.AutoSize = true;
            this.lbl_vbat_result.Location = new System.Drawing.Point(93, 348);
            this.lbl_vbat_result.Name = "lbl_vbat_result";
            this.lbl_vbat_result.Size = new System.Drawing.Size(11, 12);
            this.lbl_vbat_result.TabIndex = 17;
            this.lbl_vbat_result.Text = "-";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.list_device_box);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(14, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 183);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备列表";
            // 
            // list_device_box
            // 
            this.list_device_box.BackColor = System.Drawing.SystemColors.HighlightText;
            this.list_device_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_device_box.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.list_device_box.FormattingEnabled = true;
            this.list_device_box.ItemHeight = 19;
            this.list_device_box.Location = new System.Drawing.Point(4, 16);
            this.list_device_box.Name = "list_device_box";
            this.list_device_box.Size = new System.Drawing.Size(375, 152);
            this.list_device_box.TabIndex = 1;
            this.list_device_box.SelectedIndexChanged += new System.EventHandler(this.list_device_box_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(18, 348);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 16;
            this.label21.Text = "电池电压：";
            // 
            // gpb1
            // 
            this.gpb1.Controls.Add(this.lbl_mod_version);
            this.gpb1.Controls.Add(this.lbl_soft_version);
            this.gpb1.Controls.Add(this.t_mod_version);
            this.gpb1.Controls.Add(this.label1);
            this.gpb1.Controls.Add(this.t_soft_version);
            this.gpb1.Controls.Add(this.label14);
            this.gpb1.Controls.Add(this.lbl_led);
            this.gpb1.Controls.Add(this.btn_led);
            this.gpb1.Controls.Add(this.label23);
            this.gpb1.Controls.Add(this.lbl_oile);
            this.gpb1.Controls.Add(this.btn_oile);
            this.gpb1.Controls.Add(this.label30);
            this.gpb1.Controls.Add(this.lbl_shutdown);
            this.gpb1.Controls.Add(this.btn_sd_result);
            this.gpb1.Controls.Add(this.btn_shutdown);
            this.gpb1.Controls.Add(this.label19);
            this.gpb1.Controls.Add(this.lbl_wifi);
            this.gpb1.Controls.Add(this.t_wifi);
            this.gpb1.Controls.Add(this.label16);
            this.gpb1.Controls.Add(this.lbl_beep);
            this.gpb1.Controls.Add(this.lbl_vbat);
            this.gpb1.Controls.Add(this.btn_beep);
            this.gpb1.Controls.Add(this.btn_vbat);
            this.gpb1.Controls.Add(this.lbl_imsi);
            this.gpb1.Controls.Add(this.lbl_imei);
            this.gpb1.Controls.Add(this.lbl_ccid);
            this.gpb1.Controls.Add(this.lbl_csq);
            this.gpb1.Controls.Add(this.lbl_net);
            this.gpb1.Controls.Add(this.lbl_gps_status);
            this.gpb1.Controls.Add(this.lbl_acc_status);
            this.gpb1.Controls.Add(this.lbl_gps_loca);
            this.gpb1.Controls.Add(this.lbl_shock);
            this.gpb1.Controls.Add(this.btn_submit);
            this.gpb1.Controls.Add(this.btn_clean);
            this.gpb1.Controls.Add(this.btn_restart);
            this.gpb1.Controls.Add(this.btn_start);
            this.gpb1.Controls.Add(this.btn_open_bluetoothKey);
            this.gpb1.Controls.Add(this.btn_close_bluetoothKey);
            this.gpb1.Controls.Add(this.label26);
            this.gpb1.Controls.Add(this.lbl_vbat_result);
            this.gpb1.Controls.Add(this.label21);
            this.gpb1.Controls.Add(this.lbl_shock_result);
            this.gpb1.Controls.Add(this.lbl_gpsloca_result);
            this.gpb1.Controls.Add(this.label17);
            this.gpb1.Controls.Add(this.lbl_gpsStatus_result);
            this.gpb1.Controls.Add(this.lbl_accStatus_result);
            this.gpb1.Controls.Add(this.label15);
            this.gpb1.Controls.Add(this.label32);
            this.gpb1.Controls.Add(this.lbl_net_result);
            this.gpb1.Controls.Add(this.label12);
            this.gpb1.Controls.Add(this.t_csq);
            this.gpb1.Controls.Add(this.label11);
            this.gpb1.Controls.Add(this.t_ccid);
            this.gpb1.Controls.Add(this.label10);
            this.gpb1.Controls.Add(this.t_imsi);
            this.gpb1.Controls.Add(this.label33);
            this.gpb1.Controls.Add(this.t_imei);
            this.gpb1.Controls.Add(this.label9);
            this.gpb1.Controls.Add(this.label31);
            this.gpb1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gpb1.Location = new System.Drawing.Point(414, 75);
            this.gpb1.Name = "gpb1";
            this.gpb1.Size = new System.Drawing.Size(480, 591);
            this.gpb1.TabIndex = 11;
            this.gpb1.TabStop = false;
            this.gpb1.Text = "测试";
            this.gpb1.Enter += new System.EventHandler(this.gpb1_Enter);
            // 
            // lbl_mod_version
            // 
            this.lbl_mod_version.AutoSize = true;
            this.lbl_mod_version.Location = new System.Drawing.Point(415, 195);
            this.lbl_mod_version.Name = "lbl_mod_version";
            this.lbl_mod_version.Size = new System.Drawing.Size(41, 12);
            this.lbl_mod_version.TabIndex = 70;
            this.lbl_mod_version.Text = "未执行";
            // 
            // lbl_soft_version
            // 
            this.lbl_soft_version.AutoSize = true;
            this.lbl_soft_version.Location = new System.Drawing.Point(415, 168);
            this.lbl_soft_version.Name = "lbl_soft_version";
            this.lbl_soft_version.Size = new System.Drawing.Size(41, 12);
            this.lbl_soft_version.TabIndex = 70;
            this.lbl_soft_version.Text = "未执行";
            // 
            // t_mod_version
            // 
            this.t_mod_version.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t_mod_version.Location = new System.Drawing.Point(91, 192);
            this.t_mod_version.Name = "t_mod_version";
            this.t_mod_version.ReadOnly = true;
            this.t_mod_version.Size = new System.Drawing.Size(301, 21);
            this.t_mod_version.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 68;
            this.label1.Text = "模组版本：";
            // 
            // t_soft_version
            // 
            this.t_soft_version.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t_soft_version.Location = new System.Drawing.Point(91, 165);
            this.t_soft_version.Name = "t_soft_version";
            this.t_soft_version.ReadOnly = true;
            this.t_soft_version.Size = new System.Drawing.Size(301, 21);
            this.t_soft_version.TabIndex = 69;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 168);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 68;
            this.label14.Text = "固件版本：";
            // 
            // lbl_led
            // 
            this.lbl_led.AutoSize = true;
            this.lbl_led.Location = new System.Drawing.Point(415, 416);
            this.lbl_led.Name = "lbl_led";
            this.lbl_led.Size = new System.Drawing.Size(41, 12);
            this.lbl_led.TabIndex = 67;
            this.lbl_led.Text = "未执行";
            this.lbl_led.Visible = false;
            this.lbl_led.Click += new System.EventHandler(this.lbl_led_Click);
            // 
            // btn_led
            // 
            this.btn_led.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_led.Location = new System.Drawing.Point(415, 411);
            this.btn_led.Name = "btn_led";
            this.btn_led.Size = new System.Drawing.Size(41, 23);
            this.btn_led.TabIndex = 66;
            this.btn_led.Text = "通过";
            this.btn_led.UseVisualStyleBackColor = true;
            this.btn_led.Click += new System.EventHandler(this.btn_led_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(32, 416);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 12);
            this.label23.TabIndex = 65;
            this.label23.Text = "LED灯：";
            this.label23.Click += new System.EventHandler(this.label23_Click);
            // 
            // lbl_oile
            // 
            this.lbl_oile.AutoSize = true;
            this.lbl_oile.Location = new System.Drawing.Point(416, 451);
            this.lbl_oile.Name = "lbl_oile";
            this.lbl_oile.Size = new System.Drawing.Size(41, 12);
            this.lbl_oile.TabIndex = 67;
            this.lbl_oile.Text = "未执行";
            this.lbl_oile.Visible = false;
            this.lbl_oile.Click += new System.EventHandler(this.lbl_oile_Click);
            // 
            // btn_oile
            // 
            this.btn_oile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_oile.Location = new System.Drawing.Point(415, 446);
            this.btn_oile.Name = "btn_oile";
            this.btn_oile.Size = new System.Drawing.Size(41, 23);
            this.btn_oile.TabIndex = 66;
            this.btn_oile.Text = "通过";
            this.btn_oile.UseVisualStyleBackColor = true;
            this.btn_oile.Click += new System.EventHandler(this.btn_oile_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(38, 451);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(41, 12);
            this.label30.TabIndex = 65;
            this.label30.Text = "油电：";
            this.label30.Click += new System.EventHandler(this.labe130_Click);
            // 
            // lbl_shutdown
            // 
            this.lbl_shutdown.AutoSize = true;
            this.lbl_shutdown.Location = new System.Drawing.Point(415, 489);
            this.lbl_shutdown.Name = "lbl_shutdown";
            this.lbl_shutdown.Size = new System.Drawing.Size(41, 12);
            this.lbl_shutdown.TabIndex = 64;
            this.lbl_shutdown.Text = "未执行";
            this.lbl_shutdown.Visible = false;
            // 
            // btn_sd_result
            // 
            this.btn_sd_result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sd_result.Location = new System.Drawing.Point(415, 484);
            this.btn_sd_result.Name = "btn_sd_result";
            this.btn_sd_result.Size = new System.Drawing.Size(41, 23);
            this.btn_sd_result.TabIndex = 63;
            this.btn_sd_result.Text = "通过";
            this.btn_sd_result.UseVisualStyleBackColor = true;
            this.btn_sd_result.Click += new System.EventHandler(this.btn_sd_result_Click);
            // 
            // btn_shutdown
            // 
            this.btn_shutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_shutdown.Location = new System.Drawing.Point(98, 484);
            this.btn_shutdown.Name = "btn_shutdown";
            this.btn_shutdown.Size = new System.Drawing.Size(100, 23);
            this.btn_shutdown.TabIndex = 62;
            this.btn_shutdown.Text = "关机";
            this.btn_shutdown.UseVisualStyleBackColor = true;
            this.btn_shutdown.Click += new System.EventHandler(this.btn_shutdown_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 489);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 61;
            this.label19.Text = "设备关机：";
            // 
            // lbl_wifi
            // 
            this.lbl_wifi.AutoSize = true;
            this.lbl_wifi.Location = new System.Drawing.Point(415, 139);
            this.lbl_wifi.Name = "lbl_wifi";
            this.lbl_wifi.Size = new System.Drawing.Size(41, 12);
            this.lbl_wifi.TabIndex = 60;
            this.lbl_wifi.Text = "未执行";
            // 
            // t_wifi
            // 
            this.t_wifi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t_wifi.Location = new System.Drawing.Point(91, 136);
            this.t_wifi.Name = "t_wifi";
            this.t_wifi.ReadOnly = true;
            this.t_wifi.Size = new System.Drawing.Size(301, 21);
            this.t_wifi.TabIndex = 59;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 139);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 58;
            this.label16.Text = "WIFI强度：";
            // 
            // lbl_shock_result
            // 
            this.lbl_shock_result.AutoSize = true;
            this.lbl_shock_result.Location = new System.Drawing.Point(93, 297);
            this.lbl_shock_result.Name = "lbl_shock_result";
            this.lbl_shock_result.Size = new System.Drawing.Size(11, 12);
            this.lbl_shock_result.TabIndex = 15;
            this.lbl_shock_result.Text = "-";
            this.lbl_shock_result.Click += new System.EventHandler(this.lbl_shock_result_Click);
            // 
            // lbl_gpsloca_result
            // 
            this.lbl_gpsloca_result.AutoSize = true;
            this.lbl_gpsloca_result.Location = new System.Drawing.Point(91, 270);
            this.lbl_gpsloca_result.Name = "lbl_gpsloca_result";
            this.lbl_gpsloca_result.Size = new System.Drawing.Size(11, 12);
            this.lbl_gpsloca_result.TabIndex = 13;
            this.lbl_gpsloca_result.Text = "-";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(25, 270);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 12);
            this.label17.TabIndex = 12;
            this.label17.Text = "GPS定位：";
            // 
            // lbl_gpsStatus_result
            // 
            this.lbl_gpsStatus_result.AutoSize = true;
            this.lbl_gpsStatus_result.Location = new System.Drawing.Point(91, 245);
            this.lbl_gpsStatus_result.Name = "lbl_gpsStatus_result";
            this.lbl_gpsStatus_result.Size = new System.Drawing.Size(11, 12);
            this.lbl_gpsStatus_result.TabIndex = 11;
            this.lbl_gpsStatus_result.Text = "-";
            this.lbl_gpsStatus_result.Click += new System.EventHandler(this.lbl_gpsStatus_result_Click);
            // 
            // lbl_accStatus_result
            // 
            this.lbl_accStatus_result.AutoSize = true;
            this.lbl_accStatus_result.Location = new System.Drawing.Point(93, 322);
            this.lbl_accStatus_result.Name = "lbl_accStatus_result";
            this.lbl_accStatus_result.Size = new System.Drawing.Size(11, 12);
            this.lbl_accStatus_result.TabIndex = 11;
            this.lbl_accStatus_result.Text = "-";
            this.lbl_accStatus_result.Click += new System.EventHandler(this.lbl_accStatus_result_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 245);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 10;
            this.label15.Text = "GPS状态：";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(25, 322);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(59, 12);
            this.label32.TabIndex = 10;
            this.label32.Text = "ACC状态：";
            this.label32.Click += new System.EventHandler(this.label32_Click);
            // 
            // lbl_net_result
            // 
            this.lbl_net_result.AutoSize = true;
            this.lbl_net_result.Location = new System.Drawing.Point(91, 219);
            this.lbl_net_result.Name = "lbl_net_result";
            this.lbl_net_result.Size = new System.Drawing.Size(11, 12);
            this.lbl_net_result.TabIndex = 9;
            this.lbl_net_result.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 219);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "网络状态：";
            // 
            // t_csq
            // 
            this.t_csq.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t_csq.Location = new System.Drawing.Point(91, 106);
            this.t_csq.Name = "t_csq";
            this.t_csq.ReadOnly = true;
            this.t_csq.Size = new System.Drawing.Size(301, 21);
            this.t_csq.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "信号强度：";
            // 
            // t_ccid
            // 
            this.t_ccid.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t_ccid.Location = new System.Drawing.Point(91, 77);
            this.t_ccid.Name = "t_ccid";
            this.t_ccid.ReadOnly = true;
            this.t_ccid.Size = new System.Drawing.Size(301, 21);
            this.t_ccid.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "CCID：";
            // 
            // t_imsi
            // 
            this.t_imsi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t_imsi.Location = new System.Drawing.Point(91, 51);
            this.t_imsi.Name = "t_imsi";
            this.t_imsi.ReadOnly = true;
            this.t_imsi.Size = new System.Drawing.Size(301, 21);
            this.t_imsi.TabIndex = 4;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(42, 29);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(41, 12);
            this.label33.TabIndex = 3;
            this.label33.Text = "IMEI：";
            this.label33.Click += new System.EventHandler(this.label9_Click);
            // 
            // t_imei
            // 
            this.t_imei.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t_imei.Location = new System.Drawing.Point(91, 24);
            this.t_imei.Name = "t_imei";
            this.t_imei.ReadOnly = true;
            this.t_imei.Size = new System.Drawing.Size(301, 21);
            this.t_imei.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "IMSI：";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(11, 297);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(77, 12);
            this.label31.TabIndex = 0;
            this.label31.Text = "震动传感器：";
            this.label31.Click += new System.EventHandler(this.label31_Click);
            // 
            // btn_re_scan
            // 
            this.btn_re_scan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_re_scan.Location = new System.Drawing.Point(196, 193);
            this.btn_re_scan.Name = "btn_re_scan";
            this.btn_re_scan.Size = new System.Drawing.Size(203, 23);
            this.btn_re_scan.TabIndex = 71;
            this.btn_re_scan.Text = "重新扫描";
            this.btn_re_scan.UseVisualStyleBackColor = true;
            this.btn_re_scan.Click += new System.EventHandler(this.btn_re_scan_Click);
            // 
            // Ccgo_tool_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 678);
            this.Controls.Add(this.btn_re_scan);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpb1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Ccgo_tool_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "嘻嘻狗主板蓝牙测试工具_v2.0.3";
            this.Load += new System.EventHandler(this.Form_load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gpb1.ResumeLayout(false);
            this.gpb1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_beep;
        private System.Windows.Forms.Label lbl_vbat;
        private System.Windows.Forms.TextBox gps_shold;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox gps_num;
        private System.Windows.Forms.TextBox csq_shold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_beep;
        private System.Windows.Forms.Button btn_vbat;
        private System.Windows.Forms.Label lbl_imsi;
        private System.Windows.Forms.Label lbl_imei;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox comresult;
        private System.Windows.Forms.Label lbl_ccid;
        private System.Windows.Forms.Label lbl_csq;
        private System.Windows.Forms.Label lbl_net;
        private System.Windows.Forms.Label lbl_gps_status;
        private System.Windows.Forms.Label lbl_acc_status;
        private System.Windows.Forms.Label lbl_gps_loca;
        private System.Windows.Forms.Label lbl_shock;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btn_clean;
        private System.Windows.Forms.Button btn_restart;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_open_bluetoothKey;
        private System.Windows.Forms.Button btn_close_bluetoothKey;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lbl_vbat_result;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox gpb1;
        private System.Windows.Forms.Label lbl_shock_result;
        private System.Windows.Forms.Label lbl_gpsloca_result;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbl_gpsStatus_result;
        private System.Windows.Forms.Label lbl_accStatus_result;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lbl_net_result;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox t_csq;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox t_ccid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox t_imsi;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox t_imei;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lbl_wifi;
        private System.Windows.Forms.TextBox t_wifi;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox wifi_shold;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl_shutdown;
        private System.Windows.Forms.Button btn_sd_result;
        private System.Windows.Forms.Button btn_shutdown;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbl_led;
        private System.Windows.Forms.Button btn_led;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lbl_oile;
        private System.Windows.Forms.Button btn_oile;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lbl_soft_version;
        private System.Windows.Forms.TextBox t_soft_version;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox list_device_box;
        private System.Windows.Forms.Label lbl_mod_version;
        private System.Windows.Forms.TextBox t_mod_version;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_re_scan;
    }
}

