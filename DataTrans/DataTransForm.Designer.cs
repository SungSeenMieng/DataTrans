namespace DataTrans
{
    partial class DataTransForm
    {
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataTransForm));
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuMachineName = new System.Windows.Forms.ToolStripTextBox();
            this.传输记录器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据编辑器toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.打开程序配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.设为开机启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开日志目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加桌面快捷方式toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.清空窗口日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出传输程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogPathTimer = new System.Windows.Forms.Timer(this.components);
            this.CleaningTimer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ucBtnExt5 = new HZH_Controls.Controls.UCBtnExt();
            this.label5 = new System.Windows.Forms.Label();
            this.LISLogBox = new System.Windows.Forms.TextBox();
            this.ucBtnExt4 = new HZH_Controls.Controls.UCBtnExt();
            this.label6 = new System.Windows.Forms.Label();
            this.MacLogBox = new System.Windows.Forms.TextBox();
            this.ucWave2 = new HZH_Controls.Controls.UCWave();
            this.label2 = new System.Windows.Forms.Label();
            this.ucWave1 = new HZH_Controls.Controls.UCWave();
            this.ucBtnExt3 = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtnExt2 = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtnExt1 = new HZH_Controls.Controls.UCBtnExt();
            this.label7 = new System.Windows.Forms.Label();
            this.MachineName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LISIP = new System.Windows.Forms.TextBox();
            this.MACIP = new System.Windows.Forms.TextBox();
            this.TransModuleRefresh = new System.Windows.Forms.Timer(this.components);
            this.FileTimer = new System.Windows.Forms.Timer(this.components);
            this.LogsCleaningTimer = new System.Windows.Forms.Timer(this.components);
            this.ucBtnExt6 = new HZH_Controls.Controls.UCBtnExt();
            this.NotifyMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NotifyIcon.BalloonTipText = "程序正在运行";
            this.NotifyIcon.BalloonTipTitle = "LIS网口中继";
            this.NotifyIcon.ContextMenuStrip = this.NotifyMenu;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "LIS网口中继";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // NotifyMenu
            // 
            this.NotifyMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(144)))));
            this.NotifyMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.NotifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuMachineName,
            this.传输记录器ToolStripMenuItem,
            this.数据编辑器toolStripMenuItem1,
            this.打开程序配置ToolStripMenuItem,
            this.toolStripSeparator1,
            this.设为开机启动ToolStripMenuItem,
            this.打开日志目录ToolStripMenuItem,
            this.添加桌面快捷方式toolStripMenuItem1,
            this.toolStripSeparator2,
            this.清空窗口日志ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.退出传输程序ToolStripMenuItem});
            this.NotifyMenu.Name = "NotifyMenu";
            this.NotifyMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.NotifyMenu.Size = new System.Drawing.Size(173, 239);
            this.NotifyMenu.Opening += new System.ComponentModel.CancelEventHandler(this.NotifyMenu_Opening);
            // 
            // MenuMachineName
            // 
            this.MenuMachineName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(144)))));
            this.MenuMachineName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.MenuMachineName.ForeColor = System.Drawing.Color.White;
            this.MenuMachineName.Name = "MenuMachineName";
            this.MenuMachineName.ReadOnly = true;
            this.MenuMachineName.Size = new System.Drawing.Size(100, 23);
            this.MenuMachineName.Text = "仪器：检验仪器";
            // 
            // 传输记录器ToolStripMenuItem
            // 
            this.传输记录器ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.传输记录器ToolStripMenuItem.Name = "传输记录器ToolStripMenuItem";
            this.传输记录器ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.传输记录器ToolStripMenuItem.Text = "主界面";
            this.传输记录器ToolStripMenuItem.ToolTipText = "打开传输过程面板";
            this.传输记录器ToolStripMenuItem.Click += new System.EventHandler(this.打开监听程序ToolStripMenuItem_Click);
            // 
            // 数据编辑器toolStripMenuItem1
            // 
            this.数据编辑器toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.数据编辑器toolStripMenuItem1.Name = "数据编辑器toolStripMenuItem1";
            this.数据编辑器toolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.数据编辑器toolStripMenuItem1.Text = "数据编辑器";
            this.数据编辑器toolStripMenuItem1.ToolTipText = "打开数据编辑器面板";
            this.数据编辑器toolStripMenuItem1.Click += new System.EventHandler(this.数据编辑器toolStripMenuItem1_Click);
            // 
            // 打开程序配置ToolStripMenuItem
            // 
            this.打开程序配置ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.打开程序配置ToolStripMenuItem.Name = "打开程序配置ToolStripMenuItem";
            this.打开程序配置ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.打开程序配置ToolStripMenuItem.Text = "程序配置页面";
            this.打开程序配置ToolStripMenuItem.ToolTipText = "打开程序配置窗口";
            this.打开程序配置ToolStripMenuItem.Click += new System.EventHandler(this.打开监听配置ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // 设为开机启动ToolStripMenuItem
            // 
            this.设为开机启动ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.设为开机启动ToolStripMenuItem.Name = "设为开机启动ToolStripMenuItem";
            this.设为开机启动ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.设为开机启动ToolStripMenuItem.Text = "开机自启动";
            this.设为开机启动ToolStripMenuItem.Click += new System.EventHandler(this.设为开机启动ToolStripMenuItem_Click);
            // 
            // 打开日志目录ToolStripMenuItem
            // 
            this.打开日志目录ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.打开日志目录ToolStripMenuItem.Name = "打开日志目录ToolStripMenuItem";
            this.打开日志目录ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.打开日志目录ToolStripMenuItem.Text = "打开日志目录";
            this.打开日志目录ToolStripMenuItem.ToolTipText = "打开设置界面";
            this.打开日志目录ToolStripMenuItem.Click += new System.EventHandler(this.打开日志目录ToolStripMenuItem_Click);
            // 
            // 添加桌面快捷方式toolStripMenuItem1
            // 
            this.添加桌面快捷方式toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.添加桌面快捷方式toolStripMenuItem1.Name = "添加桌面快捷方式toolStripMenuItem1";
            this.添加桌面快捷方式toolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.添加桌面快捷方式toolStripMenuItem1.Text = "添加桌面快捷方式";
            this.添加桌面快捷方式toolStripMenuItem1.ToolTipText = "添加一个桌面快捷方式";
            this.添加桌面快捷方式toolStripMenuItem1.Click += new System.EventHandler(this.添加桌面快捷方式toolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // 清空窗口日志ToolStripMenuItem
            // 
            this.清空窗口日志ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.清空窗口日志ToolStripMenuItem.Name = "清空窗口日志ToolStripMenuItem";
            this.清空窗口日志ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.清空窗口日志ToolStripMenuItem.Text = "清空所有窗口日志";
            this.清空窗口日志ToolStripMenuItem.ToolTipText = "清空传输记录器记录";
            this.清空窗口日志ToolStripMenuItem.Click += new System.EventHandler(this.清空窗口日志ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem1.Text = "重启传输程序";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 退出传输程序ToolStripMenuItem
            // 
            this.退出传输程序ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.退出传输程序ToolStripMenuItem.Name = "退出传输程序ToolStripMenuItem";
            this.退出传输程序ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.退出传输程序ToolStripMenuItem.Text = "退出程序";
            this.退出传输程序ToolStripMenuItem.Click += new System.EventHandler(this.退出监听程序ToolStripMenuItem_Click);
            // 
            // LogPathTimer
            // 
            this.LogPathTimer.Interval = 30000;
            this.LogPathTimer.Tick += new System.EventHandler(this.LogPathTimer_Tick);
            // 
            // CleaningTimer
            // 
            this.CleaningTimer.Interval = 1800000;
            this.CleaningTimer.Tick += new System.EventHandler(this.CleaningTimer_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1MinSize = 600;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucBtnExt6);
            this.splitContainer1.Panel2.Controls.Add(this.ucWave2);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.ucWave1);
            this.splitContainer1.Panel2.Controls.Add(this.ucBtnExt3);
            this.splitContainer1.Panel2.Controls.Add(this.ucBtnExt2);
            this.splitContainer1.Panel2.Controls.Add(this.ucBtnExt1);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.MachineName);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.LISIP);
            this.splitContainer1.Panel2.Controls.Add(this.MACIP);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(1150, 524);
            this.splitContainer1.SplitterDistance = 979;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ucBtnExt5);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.LISLogBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ucBtnExt4);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.MacLogBox);
            this.splitContainer2.Size = new System.Drawing.Size(979, 524);
            this.splitContainer2.SplitterDistance = 489;
            this.splitContainer2.TabIndex = 0;
            // 
            // ucBtnExt5
            // 
            this.ucBtnExt5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBtnExt5.BackColor = System.Drawing.Color.White;
            this.ucBtnExt5.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnExt5.BtnFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt5.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnExt5.BtnText = "清空日志";
            this.ucBtnExt5.ConerRadius = 5;
            this.ucBtnExt5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt5.EnabledMouseEffect = false;
            this.ucBtnExt5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(144)))));
            this.ucBtnExt5.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnExt5.IsRadius = true;
            this.ucBtnExt5.IsShowRect = true;
            this.ucBtnExt5.IsShowTips = false;
            this.ucBtnExt5.Location = new System.Drawing.Point(412, 4);
            this.ucBtnExt5.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt5.Name = "ucBtnExt5";
            this.ucBtnExt5.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.ucBtnExt5.RectWidth = 1;
            this.ucBtnExt5.Size = new System.Drawing.Size(75, 23);
            this.ucBtnExt5.TabIndex = 17;
            this.ucBtnExt5.TabStop = false;
            this.ucBtnExt5.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt5.TipsText = "";
            this.ucBtnExt5.BtnClick += new System.EventHandler(this.ucBtnExt5_BtnClick);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "LIS日志";
            // 
            // LISLogBox
            // 
            this.LISLogBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LISLogBox.Location = new System.Drawing.Point(3, 30);
            this.LISLogBox.Multiline = true;
            this.LISLogBox.Name = "LISLogBox";
            this.LISLogBox.ReadOnly = true;
            this.LISLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LISLogBox.Size = new System.Drawing.Size(484, 492);
            this.LISLogBox.TabIndex = 0;
            // 
            // ucBtnExt4
            // 
            this.ucBtnExt4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBtnExt4.BackColor = System.Drawing.Color.White;
            this.ucBtnExt4.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnExt4.BtnFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt4.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnExt4.BtnText = "清空日志";
            this.ucBtnExt4.ConerRadius = 5;
            this.ucBtnExt4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt4.EnabledMouseEffect = false;
            this.ucBtnExt4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(144)))));
            this.ucBtnExt4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnExt4.IsRadius = true;
            this.ucBtnExt4.IsShowRect = true;
            this.ucBtnExt4.IsShowTips = false;
            this.ucBtnExt4.Location = new System.Drawing.Point(408, 4);
            this.ucBtnExt4.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt4.Name = "ucBtnExt4";
            this.ucBtnExt4.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.ucBtnExt4.RectWidth = 1;
            this.ucBtnExt4.Size = new System.Drawing.Size(75, 23);
            this.ucBtnExt4.TabIndex = 16;
            this.ucBtnExt4.TabStop = false;
            this.ucBtnExt4.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt4.TipsText = "";
            this.ucBtnExt4.BtnClick += new System.EventHandler(this.ucBtnExt4_BtnClick);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(215, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "仪器日志";
            // 
            // MacLogBox
            // 
            this.MacLogBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MacLogBox.Location = new System.Drawing.Point(3, 30);
            this.MacLogBox.Multiline = true;
            this.MacLogBox.Name = "MacLogBox";
            this.MacLogBox.ReadOnly = true;
            this.MacLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MacLogBox.Size = new System.Drawing.Size(483, 492);
            this.MacLogBox.TabIndex = 0;
            // 
            // ucWave2
            // 
            this.ucWave2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucWave2.Location = new System.Drawing.Point(30, 194);
            this.ucWave2.Name = "ucWave2";
            this.ucWave2.Size = new System.Drawing.Size(105, 33);
            this.ucWave2.TabIndex = 17;
            this.ucWave2.Text = "ucWave2";
            this.ucWave2.WaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucWave2.WaveHeight = 30;
            this.ucWave2.WaveSleep = 80;
            this.ucWave2.WaveWidth = 200;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(2, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "仪器连接状态";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucWave1
            // 
            this.ucWave1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucWave1.Location = new System.Drawing.Point(30, 65);
            this.ucWave1.Name = "ucWave1";
            this.ucWave1.Size = new System.Drawing.Size(105, 33);
            this.ucWave1.TabIndex = 16;
            this.ucWave1.Text = "ucWave1";
            this.ucWave1.WaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucWave1.WaveHeight = 30;
            this.ucWave1.WaveSleep = 80;
            this.ucWave1.WaveWidth = 200;
            // 
            // ucBtnExt3
            // 
            this.ucBtnExt3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBtnExt3.BackColor = System.Drawing.Color.White;
            this.ucBtnExt3.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnExt3.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt3.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnExt3.BtnText = "数据编辑器";
            this.ucBtnExt3.ConerRadius = 5;
            this.ucBtnExt3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt3.EnabledMouseEffect = false;
            this.ucBtnExt3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(144)))));
            this.ucBtnExt3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnExt3.IsRadius = true;
            this.ucBtnExt3.IsShowRect = true;
            this.ucBtnExt3.IsShowTips = false;
            this.ucBtnExt3.Location = new System.Drawing.Point(30, 359);
            this.ucBtnExt3.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt3.Name = "ucBtnExt3";
            this.ucBtnExt3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.ucBtnExt3.RectWidth = 1;
            this.ucBtnExt3.Size = new System.Drawing.Size(110, 35);
            this.ucBtnExt3.TabIndex = 15;
            this.ucBtnExt3.TabStop = false;
            this.ucBtnExt3.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt3.TipsText = "";
            this.ucBtnExt3.BtnClick += new System.EventHandler(this.ucBtnExt3_BtnClick);
            // 
            // ucBtnExt2
            // 
            this.ucBtnExt2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBtnExt2.BackColor = System.Drawing.Color.White;
            this.ucBtnExt2.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnExt2.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt2.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnExt2.BtnText = "重启服务";
            this.ucBtnExt2.ConerRadius = 5;
            this.ucBtnExt2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt2.EnabledMouseEffect = false;
            this.ucBtnExt2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(144)))));
            this.ucBtnExt2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnExt2.IsRadius = true;
            this.ucBtnExt2.IsShowRect = true;
            this.ucBtnExt2.IsShowTips = false;
            this.ucBtnExt2.Location = new System.Drawing.Point(30, 400);
            this.ucBtnExt2.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt2.Name = "ucBtnExt2";
            this.ucBtnExt2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.ucBtnExt2.RectWidth = 1;
            this.ucBtnExt2.Size = new System.Drawing.Size(110, 35);
            this.ucBtnExt2.TabIndex = 14;
            this.ucBtnExt2.TabStop = false;
            this.ucBtnExt2.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt2.TipsText = "";
            this.ucBtnExt2.BtnClick += new System.EventHandler(this.ucBtnExt2_BtnClick);
            // 
            // ucBtnExt1
            // 
            this.ucBtnExt1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBtnExt1.BackColor = System.Drawing.Color.White;
            this.ucBtnExt1.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnExt1.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt1.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnExt1.BtnText = "设置";
            this.ucBtnExt1.ConerRadius = 5;
            this.ucBtnExt1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt1.EnabledMouseEffect = false;
            this.ucBtnExt1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(144)))));
            this.ucBtnExt1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnExt1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ucBtnExt1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ucBtnExt1.IsRadius = true;
            this.ucBtnExt1.IsShowRect = true;
            this.ucBtnExt1.IsShowTips = false;
            this.ucBtnExt1.Location = new System.Drawing.Point(30, 440);
            this.ucBtnExt1.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt1.Name = "ucBtnExt1";
            this.ucBtnExt1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.ucBtnExt1.RectWidth = 1;
            this.ucBtnExt1.Size = new System.Drawing.Size(110, 35);
            this.ucBtnExt1.TabIndex = 13;
            this.ucBtnExt1.TabStop = false;
            this.ucBtnExt1.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt1.TipsText = "";
            this.ucBtnExt1.BtnClick += new System.EventHandler(this.ucBtnExt1_BtnClick);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(6, 488);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 25);
            this.label7.TabIndex = 12;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MachineName
            // 
            this.MachineName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MachineName.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MachineName.Location = new System.Drawing.Point(3, 278);
            this.MachineName.Name = "MachineName";
            this.MachineName.Size = new System.Drawing.Size(161, 26);
            this.MachineName.TabIndex = 8;
            this.MachineName.Text = "检验仪器";
            this.MachineName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "仪器连接地址";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(5, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "LIS连接地址";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "LIS连接状态";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LISIP
            // 
            this.LISIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LISIP.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LISIP.Location = new System.Drawing.Point(17, 253);
            this.LISIP.Name = "LISIP";
            this.LISIP.ReadOnly = true;
            this.LISIP.Size = new System.Drawing.Size(130, 22);
            this.LISIP.TabIndex = 1;
            this.LISIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MACIP
            // 
            this.MACIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MACIP.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MACIP.Location = new System.Drawing.Point(17, 125);
            this.MACIP.Name = "MACIP";
            this.MACIP.ReadOnly = true;
            this.MACIP.Size = new System.Drawing.Size(130, 22);
            this.MACIP.TabIndex = 0;
            this.MACIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TransModuleRefresh
            // 
            this.TransModuleRefresh.Interval = 10000;
            this.TransModuleRefresh.Tick += new System.EventHandler(this.TransModuleRefresh_Tick);
            // 
            // FileTimer
            // 
            this.FileTimer.Interval = 10000;
            this.FileTimer.Tick += new System.EventHandler(this.FileTimer_Tick);
            // 
            // LogsCleaningTimer
            // 
            this.LogsCleaningTimer.Interval = 1800000;
            this.LogsCleaningTimer.Tick += new System.EventHandler(this.LogsCleaningTimer_Tick);
            // 
            // ucBtnExt6
            // 
            this.ucBtnExt6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBtnExt6.BackColor = System.Drawing.Color.White;
            this.ucBtnExt6.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnExt6.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt6.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnExt6.BtnText = "实时日志";
            this.ucBtnExt6.ConerRadius = 5;
            this.ucBtnExt6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt6.EnabledMouseEffect = false;
            this.ucBtnExt6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(144)))));
            this.ucBtnExt6.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnExt6.IsRadius = true;
            this.ucBtnExt6.IsShowRect = true;
            this.ucBtnExt6.IsShowTips = false;
            this.ucBtnExt6.Location = new System.Drawing.Point(30, 315);
            this.ucBtnExt6.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt6.Name = "ucBtnExt6";
            this.ucBtnExt6.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.ucBtnExt6.RectWidth = 1;
            this.ucBtnExt6.Size = new System.Drawing.Size(110, 35);
            this.ucBtnExt6.TabIndex = 18;
            this.ucBtnExt6.TabStop = false;
            this.ucBtnExt6.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt6.TipsText = "";
            this.ucBtnExt6.BtnClick += new System.EventHandler(this.ucBtnExt6_BtnClick);
            // 
            // DataTransForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 524);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1166, 469);
            this.Name = "DataTransForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LIS仪器数据转发";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DM_FormClosing);
            this.Load += new System.EventHandler(this.DM_Load);
            this.NotifyMenu.ResumeLayout(false);
            this.NotifyMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip NotifyMenu;
        private System.Windows.Forms.ToolStripMenuItem 传输记录器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出传输程序ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空窗口日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设为开机启动ToolStripMenuItem;
        private System.Windows.Forms.Timer LogPathTimer;
        private System.Windows.Forms.ToolStripMenuItem 打开日志目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加桌面快捷方式toolStripMenuItem1;
        private System.Windows.Forms.Timer CleaningTimer;
        private System.Windows.Forms.ToolStripMenuItem 数据编辑器toolStripMenuItem1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox LISLogBox;
        private System.Windows.Forms.TextBox MacLogBox;
        private System.Windows.Forms.TextBox LISIP;
        private System.Windows.Forms.TextBox MACIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer TransModuleRefresh;
        private System.Windows.Forms.Label MachineName;
        private System.Windows.Forms.ToolStripTextBox MenuMachineName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 打开程序配置ToolStripMenuItem;
        private System.Windows.Forms.Timer FileTimer;
        private System.Windows.Forms.Timer LogsCleaningTimer;
        private HZH_Controls.Controls.UCBtnExt ucBtnExt1;
        private HZH_Controls.Controls.UCBtnExt ucBtnExt2;
        private HZH_Controls.Controls.UCBtnExt ucBtnExt3;
        private HZH_Controls.Controls.UCBtnExt ucBtnExt4;
        private HZH_Controls.Controls.UCBtnExt ucBtnExt5;
        private System.Windows.Forms.Label label7;
        private HZH_Controls.Controls.UCWave ucWave1;
        private HZH_Controls.Controls.UCWave ucWave2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private HZH_Controls.Controls.UCBtnExt ucBtnExt6;
    }
}

