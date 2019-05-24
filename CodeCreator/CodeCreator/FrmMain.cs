using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace CodeCreator
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.btnOK.Enabled = false;
        }

        private void btnLogOn_Click(object sender, EventArgs e)
        {
            if (this.inputIp.Text.Length == 0)
            {
                MessageBox.Show("Ip地址不能为空");
                return;
            }
            if (this.inputDBName.Text.Length == 0)
            {
                MessageBox.Show("数据库名称不能为空");
            }
            if (this.inputUid.Text.Length == 0)
            {
                MessageBox.Show("登录账户不能为空");
                return;
            }
            if (this.inputPwd.Text.Length == 0)
            {
                MessageBox.Show("密码不能为空");
                return;
            }

            string connStr = $"Server={this.inputIp.Text};DataBase={this.inputDBName.Text};Uid={this.inputUid.Text};Pwd={this.inputPwd.Text}";
            Creator.Creator.Instance.ConnStr = connStr;
            try
            {
                if (this.cbLstTb.Items.Count != 0) this.cbLstTb.Items.Clear();
                this.cbLstTb.Items.AddRange(Creator.Creator.Instance.LstTbName.ToArray());
                this.btnOK.Enabled = true;
                MessageBox.Show("登录成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Creator.Creator.Instance.CanNull = this.cbCanNull.Checked;
            Creator.Creator.Instance.ProjName = this.inputProjectName.Text;
            Creator.Creator.Instance.IsPage = this.cbPage.Checked;
            Creator.Creator.Instance.IsExistedName = this.cbIsExistedName.Checked;
            int.TryParse(this.txtPageSize.Text,out Creator.Creator.Instance.PageSize);
            if (this.inputBLLSuffix.Text.Length != 0)
                Creator.Creator.Instance.BLLSuffix = this.inputBLLSuffix.Text;
            if (this.inputDALSuffix.Text.Length != 0)
                Creator.Creator.Instance.DALSuffix = this.inputDALSuffix.Text;
            List<string> lst = new List<string>();
            for (int i = 0; i < this.cbLstTb.Items.Count; i++)
            {
                if (this.cbLstTb.GetItemChecked(i))
                {
                    lst.Add(cbLstTb.Items[i].ToString());
                }
            }

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string path = fbd.SelectedPath;
                    Creator.Creator.Instance.Create(path,lst);
                    MessageBox.Show("生成成功");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void cbSelAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.cbLstTb.Items.Count; i++)
            {
                this.cbLstTb.SetItemChecked(i, this.cbSelAll.Checked);
            }
        }
    }
}
