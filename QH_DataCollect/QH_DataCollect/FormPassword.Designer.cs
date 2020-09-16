namespace CaterUI
{
    partial class FormPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPassword));
            this.CANCELbutton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            this.txt_finalPassword = new System.Windows.Forms.TextBox();
            this.finalpasswordlabel = new System.Windows.Forms.Label();
            this.txt_newPassword = new System.Windows.Forms.TextBox();
            this.newpassword = new System.Windows.Forms.Label();
            this.txt_oldPassword = new System.Windows.Forms.TextBox();
            this.oldpasswordlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CANCELbutton
            // 
            this.CANCELbutton.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CANCELbutton.Location = new System.Drawing.Point(299, 200);
            this.CANCELbutton.Margin = new System.Windows.Forms.Padding(4);
            this.CANCELbutton.Name = "CANCELbutton";
            this.CANCELbutton.Size = new System.Drawing.Size(112, 31);
            this.CANCELbutton.TabIndex = 23;
            this.CANCELbutton.Text = "取消";
            this.CANCELbutton.UseVisualStyleBackColor = true;
            // 
            // OKbutton
            // 
            this.OKbutton.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OKbutton.Location = new System.Drawing.Point(65, 200);
            this.OKbutton.Margin = new System.Windows.Forms.Padding(4);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(112, 31);
            this.OKbutton.TabIndex = 22;
            this.OKbutton.Text = "确认";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // txt_finalPassword
            // 
            this.txt_finalPassword.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_finalPassword.Location = new System.Drawing.Point(175, 130);
            this.txt_finalPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txt_finalPassword.Name = "txt_finalPassword";
            this.txt_finalPassword.PasswordChar = '*';
            this.txt_finalPassword.Size = new System.Drawing.Size(249, 34);
            this.txt_finalPassword.TabIndex = 21;
            // 
            // finalpasswordlabel
            // 
            this.finalpasswordlabel.AutoSize = true;
            this.finalpasswordlabel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.finalpasswordlabel.Location = new System.Drawing.Point(49, 130);
            this.finalpasswordlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.finalpasswordlabel.Name = "finalpasswordlabel";
            this.finalpasswordlabel.Size = new System.Drawing.Size(118, 24);
            this.finalpasswordlabel.TabIndex = 20;
            this.finalpasswordlabel.Text = "确认密码:";
            // 
            // txt_newPassword
            // 
            this.txt_newPassword.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_newPassword.Location = new System.Drawing.Point(175, 78);
            this.txt_newPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txt_newPassword.Name = "txt_newPassword";
            this.txt_newPassword.PasswordChar = '*';
            this.txt_newPassword.Size = new System.Drawing.Size(249, 34);
            this.txt_newPassword.TabIndex = 19;
            // 
            // newpassword
            // 
            this.newpassword.AutoSize = true;
            this.newpassword.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newpassword.Location = new System.Drawing.Point(51, 78);
            this.newpassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newpassword.Name = "newpassword";
            this.newpassword.Size = new System.Drawing.Size(94, 24);
            this.newpassword.TabIndex = 18;
            this.newpassword.Text = "新密码:";
            // 
            // txt_oldPassword
            // 
            this.txt_oldPassword.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_oldPassword.Location = new System.Drawing.Point(175, 25);
            this.txt_oldPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txt_oldPassword.Name = "txt_oldPassword";
            this.txt_oldPassword.PasswordChar = '*';
            this.txt_oldPassword.Size = new System.Drawing.Size(249, 34);
            this.txt_oldPassword.TabIndex = 17;
            // 
            // oldpasswordlabel
            // 
            this.oldpasswordlabel.AutoSize = true;
            this.oldpasswordlabel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.oldpasswordlabel.Location = new System.Drawing.Point(49, 28);
            this.oldpasswordlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.oldpasswordlabel.Name = "oldpasswordlabel";
            this.oldpasswordlabel.Size = new System.Drawing.Size(118, 24);
            this.oldpasswordlabel.TabIndex = 16;
            this.oldpasswordlabel.Text = "原始密码:";
            // 
            // FormPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 257);
            this.Controls.Add(this.CANCELbutton);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.txt_finalPassword);
            this.Controls.Add(this.finalpasswordlabel);
            this.Controls.Add(this.txt_newPassword);
            this.Controls.Add(this.newpassword);
            this.Controls.Add(this.txt_oldPassword);
            this.Controls.Add(this.oldpasswordlabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.FormPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CANCELbutton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.TextBox txt_finalPassword;
        private System.Windows.Forms.Label finalpasswordlabel;
        private System.Windows.Forms.TextBox txt_newPassword;
        private System.Windows.Forms.Label newpassword;
        private System.Windows.Forms.TextBox txt_oldPassword;
        private System.Windows.Forms.Label oldpasswordlabel;
    }
}