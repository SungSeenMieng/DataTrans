namespace DataTrans
{
    partial class StringEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StringEditor));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StringView = new System.Windows.Forms.ListView();
            this.EdiorID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StringOld = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IORow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StringNew = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TransNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ActiveStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ucBtnExt4 = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtnExt3 = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtnExt2 = new HZH_Controls.Controls.UCBtnExt();
            this.ucBtnExt1 = new HZH_Controls.Controls.UCBtnExt();
            this.direction = new HZH_Controls.Controls.UCBtnExt();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.TextBox();
            this.newstring = new System.Windows.Forms.TextBox();
            this.oldstring = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucBtnExt4);
            this.splitContainer1.Panel2.Controls.Add(this.ucBtnExt3);
            this.splitContainer1.Panel2.Controls.Add(this.ucBtnExt2);
            this.splitContainer1.Panel2.Controls.Add(this.ucBtnExt1);
            this.splitContainer1.Panel2.Controls.Add(this.direction);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.Info);
            this.splitContainer1.Panel2.Controls.Add(this.newstring);
            this.splitContainer1.Panel2.Controls.Add(this.oldstring);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(798, 446);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.StringView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 263);
            this.panel1.TabIndex = 3;
            // 
            // StringView
            // 
            this.StringView.AutoArrange = false;
            this.StringView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EdiorID,
            this.StringOld,
            this.IORow,
            this.StringNew,
            this.TransNote,
            this.ActiveStatus});
            this.StringView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StringView.FullRowSelect = true;
            this.StringView.GridLines = true;
            this.StringView.HideSelection = false;
            this.StringView.Location = new System.Drawing.Point(0, 0);
            this.StringView.Name = "StringView";
            this.StringView.Size = new System.Drawing.Size(796, 261);
            this.StringView.TabIndex = 2;
            this.StringView.UseCompatibleStateImageBehavior = false;
            this.StringView.View = System.Windows.Forms.View.Details;
            // 
            // EdiorID
            // 
            this.EdiorID.Text = "序号";
            this.EdiorID.Width = 50;
            // 
            // StringOld
            // 
            this.StringOld.Text = "旧字符串";
            this.StringOld.Width = 180;
            // 
            // IORow
            // 
            this.IORow.Text = "方向";
            this.IORow.Width = 90;
            // 
            // StringNew
            // 
            this.StringNew.Text = "新字符串";
            this.StringNew.Width = 180;
            // 
            // TransNote
            // 
            this.TransNote.Text = "说明";
            this.TransNote.Width = 200;
            // 
            // ActiveStatus
            // 
            this.ActiveStatus.Text = "激活状态";
            // 
            // ucBtnExt4
            // 
            this.ucBtnExt4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ucBtnExt4.BackColor = System.Drawing.Color.White;
            this.ucBtnExt4.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnExt4.BtnFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt4.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnExt4.BtnText = "-";
            this.ucBtnExt4.ConerRadius = 5;
            this.ucBtnExt4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt4.EnabledMouseEffect = false;
            this.ucBtnExt4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(144)))));
            this.ucBtnExt4.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt4.IsRadius = true;
            this.ucBtnExt4.IsShowRect = true;
            this.ucBtnExt4.IsShowTips = false;
            this.ucBtnExt4.Location = new System.Drawing.Point(575, 96);
            this.ucBtnExt4.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt4.Name = "ucBtnExt4";
            this.ucBtnExt4.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.ucBtnExt4.RectWidth = 1;
            this.ucBtnExt4.Size = new System.Drawing.Size(128, 26);
            this.ucBtnExt4.TabIndex = 33;
            this.ucBtnExt4.TabStop = false;
            this.ucBtnExt4.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt4.TipsText = "";
            this.ucBtnExt4.BtnClick += new System.EventHandler(this.ucBtnExt4_BtnClick);
            // 
            // ucBtnExt3
            // 
            this.ucBtnExt3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ucBtnExt3.BackColor = System.Drawing.Color.White;
            this.ucBtnExt3.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnExt3.BtnFont = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt3.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnExt3.BtnText = "+";
            this.ucBtnExt3.ConerRadius = 5;
            this.ucBtnExt3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt3.EnabledMouseEffect = false;
            this.ucBtnExt3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(144)))));
            this.ucBtnExt3.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt3.IsRadius = true;
            this.ucBtnExt3.IsShowRect = true;
            this.ucBtnExt3.IsShowTips = false;
            this.ucBtnExt3.Location = new System.Drawing.Point(575, 134);
            this.ucBtnExt3.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt3.Name = "ucBtnExt3";
            this.ucBtnExt3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.ucBtnExt3.RectWidth = 1;
            this.ucBtnExt3.Size = new System.Drawing.Size(128, 26);
            this.ucBtnExt3.TabIndex = 33;
            this.ucBtnExt3.TabStop = false;
            this.ucBtnExt3.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt3.TipsText = "";
            this.ucBtnExt3.BtnClick += new System.EventHandler(this.ucBtnExt3_BtnClick);
            // 
            // ucBtnExt2
            // 
            this.ucBtnExt2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ucBtnExt2.BackColor = System.Drawing.Color.White;
            this.ucBtnExt2.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnExt2.BtnFont = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt2.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnExt2.BtnText = "切换状态";
            this.ucBtnExt2.ConerRadius = 5;
            this.ucBtnExt2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt2.EnabledMouseEffect = false;
            this.ucBtnExt2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(144)))));
            this.ucBtnExt2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnExt2.IsRadius = true;
            this.ucBtnExt2.IsShowRect = true;
            this.ucBtnExt2.IsShowTips = false;
            this.ucBtnExt2.Location = new System.Drawing.Point(575, 57);
            this.ucBtnExt2.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt2.Name = "ucBtnExt2";
            this.ucBtnExt2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.ucBtnExt2.RectWidth = 1;
            this.ucBtnExt2.Size = new System.Drawing.Size(128, 26);
            this.ucBtnExt2.TabIndex = 32;
            this.ucBtnExt2.TabStop = false;
            this.ucBtnExt2.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt2.TipsText = "";
            this.ucBtnExt2.BtnClick += new System.EventHandler(this.ucBtnExt2_BtnClick);
            // 
            // ucBtnExt1
            // 
            this.ucBtnExt1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ucBtnExt1.BackColor = System.Drawing.Color.White;
            this.ucBtnExt1.BtnBackColor = System.Drawing.Color.White;
            this.ucBtnExt1.BtnFont = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucBtnExt1.BtnForeColor = System.Drawing.Color.White;
            this.ucBtnExt1.BtnText = "刷新";
            this.ucBtnExt1.ConerRadius = 5;
            this.ucBtnExt1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucBtnExt1.EnabledMouseEffect = false;
            this.ucBtnExt1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(144)))));
            this.ucBtnExt1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucBtnExt1.IsRadius = true;
            this.ucBtnExt1.IsShowRect = true;
            this.ucBtnExt1.IsShowTips = false;
            this.ucBtnExt1.Location = new System.Drawing.Point(575, 15);
            this.ucBtnExt1.Margin = new System.Windows.Forms.Padding(0);
            this.ucBtnExt1.Name = "ucBtnExt1";
            this.ucBtnExt1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.ucBtnExt1.RectWidth = 1;
            this.ucBtnExt1.Size = new System.Drawing.Size(128, 26);
            this.ucBtnExt1.TabIndex = 31;
            this.ucBtnExt1.TabStop = false;
            this.ucBtnExt1.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.ucBtnExt1.TipsText = "";
            this.ucBtnExt1.BtnClick += new System.EventHandler(this.ucBtnExt1_BtnClick_1);
            // 
            // direction
            // 
            this.direction.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.direction.BackColor = System.Drawing.Color.White;
            this.direction.BtnBackColor = System.Drawing.Color.White;
            this.direction.BtnFont = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.direction.BtnForeColor = System.Drawing.Color.White;
            this.direction.BtnText = "仪器>>LIS";
            this.direction.ConerRadius = 5;
            this.direction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.direction.EnabledMouseEffect = false;
            this.direction.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(144)))));
            this.direction.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.direction.IsRadius = true;
            this.direction.IsShowRect = true;
            this.direction.IsShowTips = false;
            this.direction.Location = new System.Drawing.Point(352, 86);
            this.direction.Margin = new System.Windows.Forms.Padding(0);
            this.direction.Name = "direction";
            this.direction.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.direction.RectWidth = 1;
            this.direction.Size = new System.Drawing.Size(159, 26);
            this.direction.TabIndex = 30;
            this.direction.TabStop = false;
            this.direction.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.direction.TipsText = "";
            this.direction.BtnClick += new System.EventHandler(this.ucBtnExt1_BtnClick);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 36);
            this.label5.TabIndex = 28;
            this.label5.Text = "仪器<<LIS：仅仪器至LIS单向\r\n仪器<<LIS：仅LIS至仪器单向\r\n仪器==LIS：仪器与LIS双向";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "说明";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "新字符串";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "旧字符串";
            // 
            // Info
            // 
            this.Info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Info.Location = new System.Drawing.Point(157, 75);
            this.Info.Multiline = true;
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(187, 93);
            this.Info.TabIndex = 21;
            // 
            // newstring
            // 
            this.newstring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.newstring.Location = new System.Drawing.Point(157, 46);
            this.newstring.Name = "newstring";
            this.newstring.Size = new System.Drawing.Size(354, 21);
            this.newstring.TabIndex = 20;
            // 
            // oldstring
            // 
            this.oldstring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.oldstring.Location = new System.Drawing.Point(157, 15);
            this.oldstring.Name = "oldstring";
            this.oldstring.Size = new System.Drawing.Size(354, 21);
            this.oldstring.TabIndex = 19;
            // 
            // StringEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 446);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(691, 455);
            this.Name = "StringEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "中继数据编辑器";
            this.Load += new System.EventHandler(this.StringEditor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView StringView;
        private System.Windows.Forms.ColumnHeader EdiorID;
        private System.Windows.Forms.ColumnHeader StringOld;
        private System.Windows.Forms.ColumnHeader IORow;
        private System.Windows.Forms.ColumnHeader StringNew;
        private System.Windows.Forms.ColumnHeader TransNote;
        private System.Windows.Forms.ColumnHeader ActiveStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Info;
        private System.Windows.Forms.TextBox newstring;
        private System.Windows.Forms.TextBox oldstring;
        private HZH_Controls.Controls.UCBtnExt direction;
        private HZH_Controls.Controls.UCBtnExt ucBtnExt1;
        private HZH_Controls.Controls.UCBtnExt ucBtnExt2;
        private HZH_Controls.Controls.UCBtnExt ucBtnExt4;
        private HZH_Controls.Controls.UCBtnExt ucBtnExt3;
    }
}