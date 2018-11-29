using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Xsl;
using System.Data.Entity.Validation;

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
            int q=0,p=0,w=1;
            if (textBox1.Text.Length == 11)
            {
                q = 1;
            }
            else
            {
                q = 0;
                textBox1.Text = "不是正确的订单号格式！";
            }
            if (textBox2.Text.Length < 11 || textBox2.Text[0] != '1')
            {
                p = 0;
                textBox2.Text = "不是正确的电话格式！";
            }
            else
            {
                foreach (char tt in textBox2.Text)
                {
                    if (tt < '0' || tt > '9')
                    {
                        p = 0;
                        textBox2.Text="不是正确的电话格式！";
                    }
                    else
                    {
                        p = 1;
                    }
                }
            }
            int b = 0;
            foreach (program1.Program.Order Order in Form1.testList)
            {
                b++;
            }
            for (int i = 0; i < b; i++) {
                if (testList[i].Detail.Num == textBox1.Text) {
                    w = 0;
                }
            }
            if (q == 1 && p == 1 && w == 1) {
                program1.Program.Order a = new program1.Program.Order();
                a.Detail.Num = textBox1.Text;
                a.Detail.CutomerName = textBox2.Text;
                a.Detail.ProductName = textBox3.Text;
                try
                {
                    using (var db = new EFDemo.OrderDB())
                    {
                        db.Order.Add(a);
                        //db.Order.Attach(order);
                        //db.Entry(order).State = EntityState.Added;
                        db.SaveChanges();
                    }
                }

                catch (DbEntityValidationException ex)
                {

                }

                testList.Add(a);
                Form2 fm = new Form2();
                fm.ShowDialog();
            }
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

        public static void XmlSerializer(XmlSerializer ser, string fileName, ref program1.Program.Order order)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            int a = 0;
            ser.Serialize(fs, order);
            fs.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                XmlSerializer xmlser = new XmlSerializer(typeof(program1.Program.Order));
                program1.Program.Order order = testList[0];
                XmlSerializer(xmlser, "program.xml", ref order);
                XslCompiledTransform trans = new XslCompiledTransform();
                trans.Load(@"../../../program.xsl");
                trans.Transform("program.xml", "program.html");

            

        }
    }
}
