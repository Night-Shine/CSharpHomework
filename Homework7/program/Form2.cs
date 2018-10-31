using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            int a = 0;
            foreach (program1.Program.Order Order in Form1.testList)
            {
                a++;
            }
            label4.Text = Form1.testList[a-1].Detail.Num;
            label5.Text = Form1.testList[a-1].Detail.CutomerName;
            label6.Text = Form1.testList[a-1].Detail.ProductName;

        }
    }
}
