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
    public partial class Form1 : Form
    {
        public static List<program1.Program.Order> testList = new List<program1.Program.Order>();
        public static int c;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            program1.Program.Order a = new program1.Program.Order();
            a.Detail.Num = textBox1.Text;
            a.Detail.CutomerName = textBox2.Text;
            a.Detail.ProductName = textBox3.Text;
            testList.Add(a);
            Form2 fm = new Form2();
            fm.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = 0;
            foreach (program1.Program.Order Order in testList)
            {
                a++;
            }
            int b = 0;
            for (int i = 0; i < a; i++)
            {
                if (testList[i].Detail.Num == textBox1.Text)
                {
                    b = i;
                }
            }
            for (int i = 0; i < a; i++)
            {
                if (testList[i].Detail.ProductName == textBox3.Text)
                {
                    b = i;
                }
            }
            for (int i = 0; i < a; i++)
            {
                if (testList[i].Detail.CutomerName == textBox2.Text)
                {
                    b = i;
                }
            }
            c = b;
            Form3 fm = new Form3();
            fm.ShowDialog();
        }
    }
}
