namespace CaterUI
{
    partial class FormSQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSQL));
            this.radioButton_close = new System.Windows.Forms.RadioButton();
            this.radioButton_open = new System.Windows.Forms.RadioButton();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.txt_dbName = new System.Windows.Forms.TextBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_server = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // radioButton_close
            // 
            this.radioButton_close.AutoSize = true;
            this.radioButton_close.BackColor = System.Drawing.Color.DarkOrange;
            this.radioButton_close.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_close.Location = new System.Drawing.Point(533, 12);
            this.radioButton_close.Name = "radioButton_close";
            this.radioButton_close.Size = new System.Drawing.Size(151, 28);
            this.radioButton_close.TabIndex = 36;
            this.radioButton_close.TabStop = true;
            this.radioButton_close.Text = "数据库关闭";
            this.radioButton_close.UseVisualStyleBackColor = false;
            // 
            // radioButton_open
            // 
            this.radioButton_open.AutoSize = true;
            this.radioButton_open.BackColor = System.Drawing.Color.Chartreuse;
            this.radioButton_open.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_open.Location = new System.Drawing.Point(121, 12);
            this.radioButton_open.Name = "radioButton_open";
            this.radioButton_open.Size = new System.Drawing.Size(151, 28);
            this.radioButton_open.TabIndex = 35;
            this.radioButton_open.TabStop = true;
            this.radioButton_open.Text = "数据库开启";
            this.radioButton_open.UseVisualStyleBackColor = false;
            // 
            // txt_pwd
            // 
            this.txt_pwd.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_pwd.Location = new System.Drawing.Point(302, 301);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.PasswordChar = '*';
            this.txt_pwd.Size = new System.Drawing.Size(349, 34);
            this.txt_pwd.TabIndex = 34;
            this.txt_pwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_dbName
            // 
            this.txt_dbName.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_dbName.Location = new System.Drawing.Point(302, 145);
            this.txt_dbName.Name = "txt_dbName";
            this.txt_dbName.Size = new System.Drawing.Size(349, 34);
            this.txt_dbName.TabIndex = 33;
            this.txt_dbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_user
            // 
            this.txt_user.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_user.Location = new System.Drawing.Point(302, 223);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(349, 34);
            this.txt_user.TabIndex = 32;
            this.txt_user.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_server
            // 
            this.txt_server.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_server.Location = new System.Drawing.Point(302, 67);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new System.Drawing.Size(349, 34);
            this.txt_server.TabIndex = 31;
            this.txt_server.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cancel.Location = new System.Drawing.Point(566, 374);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(118, 64);
            this.btn_cancel.TabIndex = 30;
            this.btn_cancel.Text = "退出";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_save.Location = new System.Drawing.Point(121, 374);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(118, 64);
            this.btn_save.TabIndex = 29;
            this.btn_save.Text = "保存并应用";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("华文楷体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(116, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 27);
            this.label4.TabIndex = 28;
            this.label4.Text = "数据库名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("华文楷体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(116, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 27);
            this.label3.TabIndex = 27;
            this.label3.Text = "登录密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("华文楷体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(116, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 27);
            this.label2.TabIndex = 26;
            this.label2.Text = "用户名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文楷体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(116, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 27);
            this.label1.TabIndex = 25;
            this.label1.Text = "数据库地址";
            // 
            // FormSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.radioButton_close);
            this.Controls.Add(this.radioButton_open);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.txt_dbName);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.txt_server);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSQL";
            this.Text = "数据库通讯";
            this.Load += new System.EventHandler(this.FormSQL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_close;
        private System.Windows.Forms.RadioButton radioButton_open;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.TextBox txt_dbName;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.TextBox txt_server;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}