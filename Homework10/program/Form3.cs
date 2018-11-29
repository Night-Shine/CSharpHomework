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
    public partial class Form3 : Form
    {
        public Form3()
        {
            int a = Form1.c;
            InitializeComponent();
            textBox1.Text = Form1.testList[a].Detail.Num;
            textBox2.Text = Form1.testList[a].Detail.CutomerName;
            textBox3.Text = Form1.testList[a].Detail.ProductName;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = Form1.c;
            Form1.testList[a].Detail.Num = textBox1.Text;
            Form1.testList[a].Detail.CutomerName = textBox2.Text;
            Form1.testList[a].Detail.ProductName = textBox3.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.testList.Remove(Form1.testList[Form1.c]);
        }
    }
}
