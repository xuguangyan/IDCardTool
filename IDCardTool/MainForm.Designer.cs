namespace IDCardTool
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lbResult = new System.Windows.Forms.Label();
            this.grpBox1 = new System.Windows.Forms.GroupBox();
            this.chkVerify = new System.Windows.Forms.CheckBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtIDCard = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBox2 = new System.Windows.Forms.GroupBox();
            this.chkMale = new System.Windows.Forms.CheckBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comBoxAge = new System.Windows.Forms.ComboBox();
            this.chkFemal = new System.Windows.Forms.CheckBox();
            this.btnCompress = new System.Windows.Forms.Button();
            this.btnDecompress = new System.Windows.Forms.Button();
            this.grpBox1.SuspendLayout();
            this.grpBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(14, 169);
            this.txtResult.Margin = new System.Windows.Forms.Padding(5);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(496, 157);
            this.txtResult.TabIndex = 13;
            this.txtResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResult_KeyDown);
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Location = new System.Drawing.Point(19, 141);
            this.lbResult.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(88, 16);
            this.lbResult.TabIndex = 12;
            this.lbResult.Text = "返回结果：";
            // 
            // grpBox1
            // 
            this.grpBox1.Controls.Add(this.chkVerify);
            this.grpBox1.Controls.Add(this.btnCheck);
            this.grpBox1.Controls.Add(this.txtIDCard);
            this.grpBox1.Controls.Add(this.label1);
            this.grpBox1.Location = new System.Drawing.Point(5, 2);
            this.grpBox1.Name = "grpBox1";
            this.grpBox1.Size = new System.Drawing.Size(513, 69);
            this.grpBox1.TabIndex = 15;
            this.grpBox1.TabStop = false;
            this.grpBox1.Text = "查询";
            // 
            // chkVerify
            // 
            this.chkVerify.AutoSize = true;
            this.chkVerify.Checked = true;
            this.chkVerify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerify.Location = new System.Drawing.Point(398, 29);
            this.chkVerify.Name = "chkVerify";
            this.chkVerify.Size = new System.Drawing.Size(107, 20);
            this.chkVerify.TabIndex = 18;
            this.chkVerify.Text = "启用校验位";
            this.chkVerify.UseVisualStyleBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(309, 19);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(82, 31);
            this.btnCheck.TabIndex = 17;
            this.btnCheck.Text = "查询";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtIDCard
            // 
            this.txtIDCard.Font = new System.Drawing.Font("宋体", 14F);
            this.txtIDCard.Location = new System.Drawing.Point(105, 20);
            this.txtIDCard.Margin = new System.Windows.Forms.Padding(4);
            this.txtIDCard.Name = "txtIDCard";
            this.txtIDCard.Size = new System.Drawing.Size(196, 29);
            this.txtIDCard.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "身份证号：";
            // 
            // grpBox2
            // 
            this.grpBox2.Controls.Add(this.chkMale);
            this.grpBox2.Controls.Add(this.btnGenerate);
            this.grpBox2.Controls.Add(this.txtNum);
            this.grpBox2.Controls.Add(this.label3);
            this.grpBox2.Controls.Add(this.label2);
            this.grpBox2.Controls.Add(this.comBoxAge);
            this.grpBox2.Controls.Add(this.chkFemal);
            this.grpBox2.Location = new System.Drawing.Point(5, 72);
            this.grpBox2.Name = "grpBox2";
            this.grpBox2.Size = new System.Drawing.Size(513, 66);
            this.grpBox2.TabIndex = 16;
            this.grpBox2.TabStop = false;
            this.grpBox2.Text = "生成";
            // 
            // chkMale
            // 
            this.chkMale.AutoSize = true;
            this.chkMale.Checked = true;
            this.chkMale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMale.Location = new System.Drawing.Point(54, 27);
            this.chkMale.Name = "chkMale";
            this.chkMale.Size = new System.Drawing.Size(43, 20);
            this.chkMale.TabIndex = 19;
            this.chkMale.Text = "男";
            this.chkMale.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(398, 21);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(82, 31);
            this.btnGenerate.TabIndex = 18;
            this.btnGenerate.Text = "随机生成";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(336, 23);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(55, 26);
            this.txtNum.TabIndex = 3;
            this.txtNum.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "性别：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "生成数量：";
            // 
            // comBoxAge
            // 
            this.comBoxAge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBoxAge.FormattingEnabled = true;
            this.comBoxAge.Items.AddRange(new object[] {
            "(不限年龄)",
            "18岁以下",
            "18岁-25岁",
            "26岁-40岁",
            "40岁-80岁"});
            this.comBoxAge.Location = new System.Drawing.Point(147, 25);
            this.comBoxAge.Name = "comBoxAge";
            this.comBoxAge.Size = new System.Drawing.Size(104, 24);
            this.comBoxAge.TabIndex = 1;
            // 
            // chkFemal
            // 
            this.chkFemal.AutoSize = true;
            this.chkFemal.Checked = true;
            this.chkFemal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFemal.Location = new System.Drawing.Point(97, 27);
            this.chkFemal.Name = "chkFemal";
            this.chkFemal.Size = new System.Drawing.Size(43, 20);
            this.chkFemal.TabIndex = 0;
            this.chkFemal.Text = "女";
            this.chkFemal.UseVisualStyleBackColor = true;
            // 
            // btnCompress
            // 
            this.btnCompress.Font = new System.Drawing.Font("宋体", 10F);
            this.btnCompress.Location = new System.Drawing.Point(302, 140);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(100, 25);
            this.btnCompress.TabIndex = 17;
            this.btnCompress.Text = "压缩字典文件";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Visible = false;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // btnDecompress
            // 
            this.btnDecompress.Font = new System.Drawing.Font("宋体", 10F);
            this.btnDecompress.Location = new System.Drawing.Point(410, 140);
            this.btnDecompress.Name = "btnDecompress";
            this.btnDecompress.Size = new System.Drawing.Size(100, 25);
            this.btnDecompress.TabIndex = 17;
            this.btnDecompress.Text = "解压字典文件";
            this.btnDecompress.UseVisualStyleBackColor = true;
            this.btnDecompress.Visible = false;
            this.btnDecompress.Click += new System.EventHandler(this.btnDecompress_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 337);
            this.Controls.Add(this.btnDecompress);
            this.Controls.Add(this.btnCompress);
            this.Controls.Add(this.grpBox2);
            this.Controls.Add(this.grpBox1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lbResult);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "身份证号工具";
            this.grpBox1.ResumeLayout(false);
            this.grpBox1.PerformLayout();
            this.grpBox2.ResumeLayout(false);
            this.grpBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.GroupBox grpBox1;
        private System.Windows.Forms.CheckBox chkVerify;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtIDCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBox2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comBoxAge;
        private System.Windows.Forms.CheckBox chkFemal;
        private System.Windows.Forms.CheckBox chkMale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.Button btnDecompress;
    }
}

