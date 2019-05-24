namespace CodeCreator
{
    partial class FrmMain
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
            this.gpBoxTop = new System.Windows.Forms.GroupBox();
            this.btnLogOn = new System.Windows.Forms.Button();
            this.inputPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inputUid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.inputDBName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCanNull = new System.Windows.Forms.CheckBox();
            this.inputBLLSuffix = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.inputDALSuffix = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.inputProjectName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbLstTb = new System.Windows.Forms.CheckedListBox();
            this.cbPage = new System.Windows.Forms.CheckBox();
            this.cbSelAll = new System.Windows.Forms.CheckBox();
            this.txtPageSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbIsExistedName = new System.Windows.Forms.CheckBox();
            this.gpBoxTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpBoxTop
            // 
            this.gpBoxTop.Controls.Add(this.btnLogOn);
            this.gpBoxTop.Controls.Add(this.inputPwd);
            this.gpBoxTop.Controls.Add(this.label3);
            this.gpBoxTop.Controls.Add(this.inputUid);
            this.gpBoxTop.Controls.Add(this.label4);
            this.gpBoxTop.Controls.Add(this.inputDBName);
            this.gpBoxTop.Controls.Add(this.label2);
            this.gpBoxTop.Controls.Add(this.inputIp);
            this.gpBoxTop.Controls.Add(this.label1);
            this.gpBoxTop.Font = new System.Drawing.Font("汉仪综艺体简", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpBoxTop.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gpBoxTop.Location = new System.Drawing.Point(36, 12);
            this.gpBoxTop.Name = "gpBoxTop";
            this.gpBoxTop.Size = new System.Drawing.Size(687, 141);
            this.gpBoxTop.TabIndex = 0;
            this.gpBoxTop.TabStop = false;
            this.gpBoxTop.Text = "数据库登录信息";
            // 
            // btnLogOn
            // 
            this.btnLogOn.Location = new System.Drawing.Point(556, 25);
            this.btnLogOn.Name = "btnLogOn";
            this.btnLogOn.Size = new System.Drawing.Size(84, 81);
            this.btnLogOn.TabIndex = 4;
            this.btnLogOn.Text = "登录服务器";
            this.btnLogOn.UseVisualStyleBackColor = true;
            this.btnLogOn.Click += new System.EventHandler(this.btnLogOn_Click);
            // 
            // inputPwd
            // 
            this.inputPwd.Font = new System.Drawing.Font("黑体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputPwd.Location = new System.Drawing.Point(365, 78);
            this.inputPwd.Name = "inputPwd";
            this.inputPwd.Size = new System.Drawing.Size(111, 22);
            this.inputPwd.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(268, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "登录密码:";
            // 
            // inputUid
            // 
            this.inputUid.Font = new System.Drawing.Font("黑体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputUid.Location = new System.Drawing.Point(138, 78);
            this.inputUid.Name = "inputUid";
            this.inputUid.Size = new System.Drawing.Size(111, 22);
            this.inputUid.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(41, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "登录账号：";
            // 
            // inputDBName
            // 
            this.inputDBName.Font = new System.Drawing.Font("黑体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputDBName.Location = new System.Drawing.Point(365, 32);
            this.inputDBName.Name = "inputDBName";
            this.inputDBName.Size = new System.Drawing.Size(111, 22);
            this.inputDBName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(268, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据库名称:";
            // 
            // inputIp
            // 
            this.inputIp.Font = new System.Drawing.Font("黑体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputIp.Location = new System.Drawing.Point(138, 34);
            this.inputIp.Name = "inputIp";
            this.inputIp.Size = new System.Drawing.Size(111, 22);
            this.inputIp.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(41, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器IP地址:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCanNull);
            this.groupBox1.Controls.Add(this.inputBLLSuffix);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.inputDALSuffix);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.inputProjectName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(36, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 251);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本配置信息";
            // 
            // cbCanNull
            // 
            this.cbCanNull.AutoSize = true;
            this.cbCanNull.Location = new System.Drawing.Point(34, 84);
            this.cbCanNull.Name = "cbCanNull";
            this.cbCanNull.Size = new System.Drawing.Size(132, 16);
            this.cbCanNull.TabIndex = 15;
            this.cbCanNull.Text = "Model字段是否允许?";
            this.cbCanNull.UseVisualStyleBackColor = true;
            // 
            // inputBLLSuffix
            // 
            this.inputBLLSuffix.Font = new System.Drawing.Font("宋体", 10F);
            this.inputBLLSuffix.Location = new System.Drawing.Point(96, 199);
            this.inputBLLSuffix.Name = "inputBLLSuffix";
            this.inputBLLSuffix.Size = new System.Drawing.Size(96, 23);
            this.inputBLLSuffix.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(6, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "逻辑类后缀:";
            // 
            // inputDALSuffix
            // 
            this.inputDALSuffix.Font = new System.Drawing.Font("宋体", 10F);
            this.inputDALSuffix.Location = new System.Drawing.Point(96, 122);
            this.inputDALSuffix.Name = "inputDALSuffix";
            this.inputDALSuffix.Size = new System.Drawing.Size(96, 23);
            this.inputDALSuffix.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(6, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "访问类后缀:";
            // 
            // inputProjectName
            // 
            this.inputProjectName.Font = new System.Drawing.Font("宋体", 10F);
            this.inputProjectName.Location = new System.Drawing.Point(96, 38);
            this.inputProjectName.Name = "inputProjectName";
            this.inputProjectName.Size = new System.Drawing.Size(96, 23);
            this.inputProjectName.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "项目名称:";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("汉仪综艺体简", 14.25F);
            this.btnOK.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnOK.Location = new System.Drawing.Point(668, 357);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 81);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "生成所有代码";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbLstTb
            // 
            this.cbLstTb.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbLstTb.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cbLstTb.FormattingEnabled = true;
            this.cbLstTb.Location = new System.Drawing.Point(282, 194);
            this.cbLstTb.Name = "cbLstTb";
            this.cbLstTb.Size = new System.Drawing.Size(230, 202);
            this.cbLstTb.TabIndex = 11;
            // 
            // cbPage
            // 
            this.cbPage.AutoSize = true;
            this.cbPage.Font = new System.Drawing.Font("宋体", 9F);
            this.cbPage.Location = new System.Drawing.Point(302, 172);
            this.cbPage.Name = "cbPage";
            this.cbPage.Size = new System.Drawing.Size(72, 16);
            this.cbPage.TabIndex = 12;
            this.cbPage.Text = "是否分页";
            this.cbPage.UseVisualStyleBackColor = true;
            // 
            // cbSelAll
            // 
            this.cbSelAll.AutoSize = true;
            this.cbSelAll.Font = new System.Drawing.Font("宋体", 9F);
            this.cbSelAll.Location = new System.Drawing.Point(369, 422);
            this.cbSelAll.Name = "cbSelAll";
            this.cbSelAll.Size = new System.Drawing.Size(48, 16);
            this.cbSelAll.TabIndex = 13;
            this.cbSelAll.Text = "全选";
            this.cbSelAll.UseVisualStyleBackColor = true;
            this.cbSelAll.CheckedChanged += new System.EventHandler(this.cbSelAll_CheckedChanged);
            // 
            // txtPageSize
            // 
            this.txtPageSize.Font = new System.Drawing.Font("黑体", 10F);
            this.txtPageSize.Location = new System.Drawing.Point(471, 165);
            this.txtPageSize.Name = "txtPageSize";
            this.txtPageSize.Size = new System.Drawing.Size(20, 23);
            this.txtPageSize.TabIndex = 7;
            this.txtPageSize.Text = "5";
            this.txtPageSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(380, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "每页显示数量";
            // 
            // cbIsExistedName
            // 
            this.cbIsExistedName.AutoSize = true;
            this.cbIsExistedName.Font = new System.Drawing.Font("宋体", 9F);
            this.cbIsExistedName.Location = new System.Drawing.Point(524, 168);
            this.cbIsExistedName.Name = "cbIsExistedName";
            this.cbIsExistedName.Size = new System.Drawing.Size(228, 16);
            this.cbIsExistedName.TabIndex = 14;
            this.cbIsExistedName.Text = "是否名称查重（字段名称必须为Name）";
            this.cbIsExistedName.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 450);
            this.Controls.Add(this.cbIsExistedName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPageSize);
            this.Controls.Add(this.cbSelAll);
            this.Controls.Add(this.cbPage);
            this.Controls.Add(this.cbLstTb);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpBoxTop);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".NET三层代码生成器";
            this.gpBoxTop.ResumeLayout(false);
            this.gpBoxTop.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpBoxTop;
        private System.Windows.Forms.Button btnLogOn;
        private System.Windows.Forms.TextBox inputPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputUid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inputDBName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox inputProjectName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inputBLLSuffix;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox inputDALSuffix;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox cbCanNull;
        private System.Windows.Forms.CheckedListBox cbLstTb;
        private System.Windows.Forms.CheckBox cbPage;
        private System.Windows.Forms.CheckBox cbSelAll;
        private System.Windows.Forms.TextBox txtPageSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbIsExistedName;
    }
}

