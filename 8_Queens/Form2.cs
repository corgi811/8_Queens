using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ExcelSheetSave
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Left += 2;
            if (panel2.Left > 180)
            {
                panel2.Left = -52;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
        }
    }
}
