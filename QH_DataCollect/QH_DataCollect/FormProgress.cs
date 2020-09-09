using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaterUI
{
    /// <summary>
    /// 进度条，只作显示作用
    /// </summary>
    public partial class FormProgress : Form
    {
        public FormProgress()
        {
            InitializeComponent();
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 100;
                       
        }
        public static void Run(string text)
        {
            
        }

       

        private void FormProgress_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
        }
    }
}
