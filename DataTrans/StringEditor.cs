using HZH_Controls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataTrans
{
    public partial class StringEditor : Form
    {
        public StringEditor()
        {
            InitializeComponent();
        }

        public void refreshlist()
        {
            StringView.Items.Clear();
            DataSet ds = AcceseDatabase.GetAll();
            string direc = "";
            string status = "";
            for (int i = 0; i < ds.Tables["TransData"].Rows.Count; i++)//遍历BookInfo中所有行
            {
                if (ds.Tables["TransData"].Rows[i]["IOROW"].ToString() == "LTM") { direc = "LIS>>仪器"; }
                if (ds.Tables["TransData"].Rows[i]["IOROW"].ToString() == "MTL") { direc = "仪器>>LIS"; }
                if (ds.Tables["TransData"].Rows[i]["IOROW"].ToString() == "==") { direc = "LIS==仪器"; }
                if (ds.Tables["TransData"].Rows[i]["ActiveStatus"].ToString() == "active") { status = "激活"; }
                if (ds.Tables["TransData"].Rows[i]["ActiveStatus"].ToString() == "cancel") { status = "未激活"; }
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems[0].Text = ds.Tables["TransData"].Rows[i]["ID"].ToString();
                lvi.SubItems.AddRange(new string[]{
                    ds.Tables["TransData"].Rows[i]["MacString"].ToString(),
                    direc,
                    ds.Tables["TransData"].Rows[i]["LISString"].ToString(),
                     ds.Tables["TransData"].Rows[i]["Note"].ToString(),
                     status,
                });
                StringView.Items.Add(lvi);//将数据添加到listview中
            }
            foreach (ListViewItem item in StringView.Items)
            {
                if (item.SubItems[5].Text == "未激活") { item.BackColor = Color.FromArgb(255, 77, 59); }
            }
            FrmTips.ShowTipsSuccess(this,"列表加载完成");
        }
        private void StringEditor_Load(object sender, EventArgs e)
        {
            refreshlist();
        }

        private void ADDTrans_Click(object sender, EventArgs e)
        {
           
        }

        private void REMTrans_Click(object sender, EventArgs e)
        {
          
        }

        private void direction_Click(object sender, EventArgs e)
        {
           
        }

        private void RefreshEditor_Click(object sender, EventArgs e)
        {
           
        }

        private void Toggle_Click(object sender, EventArgs e)
        {
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucBtnExt1_BtnClick(object sender, EventArgs e)
        {
            if (direction.BtnText == "仪器>>LIS") { direction.BtnText = "仪器==LIS"; }
            else if (direction.BtnText == "仪器==LIS") { direction.BtnText = "仪器<<LIS"; }
            else { direction.BtnText = "仪器>>LIS"; }
        }

        private void ucBtnExt1_BtnClick_1(object sender, EventArgs e)
        {
            refreshlist();
        }

        private void ucBtnExt2_BtnClick(object sender, EventArgs e)
        {
            if (StringView.SelectedItems.Count == 0)
            {
                FrmTips.ShowTipsError(this, "请选择至少一项");
            }
            else
            {
                string buf = "";
                foreach (ListViewItem cell in StringView.SelectedItems)
                {
                    buf += "序号:" + cell.Text + "    说明:" + cell.SubItems[4].Text + "\r\n";
                }
                if (FrmDialog.ShowDialog(this, "当前选择了" + StringView.SelectedItems.Count + "条转换条目：\r\n\r\n" + buf + "\r\n是否确定切换激活状态", "切换激活状态", true) == DialogResult.OK)
                {

                    string status = "";
                    foreach (ListViewItem item in StringView.SelectedItems)
                    {
                        if (item.SubItems[5].Text == "激活") { status = "cancel"; }
                        if (item.SubItems[5].Text == "未激活") { status = "active"; }
                        AcceseDatabase.ToggleActive(item.Text, status);
                    }
                    refreshlist();
                }
            }
        }

        private void ucBtnExt4_BtnClick(object sender, EventArgs e)
        {
            if (StringView.SelectedItems.Count == 0)
            {
                FrmTips.ShowTipsError(this, "请选择至少一项");
            }
            else
            {
                string buf = "";
                foreach (ListViewItem cell in StringView.SelectedItems)
                {
                    buf += "序号:" + cell.Text + "    说明:" + cell.SubItems[4].Text + "\r\n";
                }
                if (FrmDialog.ShowDialog(this, "当前选择了" + StringView.SelectedItems.Count + "条转换条目：\r\n\r\n" + buf + "\r\n是否确定删除", "删除条目", true) == DialogResult.OK)
                {

                    foreach (ListViewItem item in StringView.SelectedItems)
                    {
                        AcceseDatabase.RemoveItem(item.Text);
                    }
                    refreshlist();
                }
            }
        }

        private void ucBtnExt3_BtnClick(object sender, EventArgs e)
        {
            string direc = "";
            string from = "";
            string to = "";
            if (direction.BtnText == "仪器>>LIS") { direc = "MTL"; from = "仪器";to = "LIS"; }
            if (direction.BtnText == "仪器<<LIS") { direc = "LTM"; from = "LIS"; to = "仪器"; }
            if (direction.BtnText == "仪器==LIS") { direc = "=="; from = "仪器/LIS"; to = "LIS/仪器"; }
            if (oldstring.TextLength > 0 && newstring.TextLength > 0 && direc.Length > 0 && Info.TextLength > 0)
            {
                if (FrmDialog.ShowDialog(this, "将新增一条条目：\r\n\r\n转换条目说明:["+Info.Text+"]\r\n从["+from+"]发送至["+to+"]的数据["+oldstring.Text+"]转换成["+newstring.Text+"]\r\n\r\n确定吗？", "新增条目", true) == DialogResult.OK)
                {
                    AcceseDatabase.InsertItem(oldstring.Text, direc, newstring.Text, Info.Text);
                    refreshlist();
                }
            }
            else { FrmTips.ShowTipsError(this, "请检查输入内容"); }
        }
    }
}
