namespace CaterUI
{
    partial class FormTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            this.lbl_result = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_value = new System.Windows.Forms.TextBox();
            this.btn_write = new System.Windows.Forms.Button();
            this.txt_node = new System.Windows.Forms.TextBox();
            this.btn_read = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_result.Location = new System.Drawing.Point(22, 216);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(52, 15);
            this.lbl_result.TabIndex = 19;
            this.lbl_result.Text = "结果：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(22, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "输入节点值";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "节点名称";
            // 
            // txt_value
            // 
            this.txt_value.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_value.Location = new System.Drawing.Point(25, 151);
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(290, 25);
            this.txt_value.TabIndex = 16;
            this.txt_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_value.WordWrap = false;
            // 
            // btn_write
            // 
            this.btn_write.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_write.Location = new System.Drawing.Point(374, 150);
            this.btn_write.Name = "btn_write";
            this.btn_write.Size = new System.Drawing.Size(88, 26);
            this.btn_write.TabIndex = 15;
            this.btn_write.Text = "写入";
            this.btn_write.UseVisualStyleBackColor = true;
            this.btn_write.Click += new System.EventHandler(this.btn_write_Click);
            // 
            // txt_node
            // 
            this.txt_node.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_node.Location = new System.Drawing.Point(25, 56);
            this.txt_node.Name = "txt_node";
            this.txt_node.Size = new System.Drawing.Size(290, 25);
            this.txt_node.TabIndex = 14;
            this.txt_node.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_node.WordWrap = false;
            // 
            // btn_read
            // 
            this.btn_read.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_read.Location = new System.Drawing.Point(374, 55);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(88, 26);
            this.btn_read.TabIndex = 13;
            this.btn_read.Text = "读取";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.Btn_read_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 260);
            this.Controls.Add(this.lbl_result);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_value);
            this.Controls.Add(this.btn_write);
            this.Controls.Add(this.txt_node);
            this.Controls.Add(this.btn_read);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTest";
            this.Text = "PLC读写测试";
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_result;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.Button btn_write;
        private System.Windows.Forms.TextBox txt_node;
        private System.Windows.Forms.Button btn_read;
    }
}