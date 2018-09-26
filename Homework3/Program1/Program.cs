using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        public class Tu
        {
            public double s;
        }
        public class San:Tu {
            public San(double a,double b,double c){
                double p = (a + b + c) / 2;
                this.s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                }
        }
        public class Yuan : Tu
        {
            public Yuan(double a)
            {
                this.s = Math.PI * a * a;
            }
        }
        public class Zhe : Tu
        {
            public Zhe(double a)
            {
                this.s = a * a;
            }
        }
        public class Cha : Tu
        {
            public Cha(double a, double b)
            {
                this.s = a * b;
            }
        }
        class Factory
        {
            public static Tu getTu(string name)
            {
                Tu tu = null;
                if (name == "San")
                {
                    Console.WriteLine("请依次输入三边长：");
                    try
                    {
                        int a = Int32.Parse(Console.ReadLine());
                        int b = Int32.Parse(Console.ReadLine());
                        int c = Int32.Parse(Console.ReadLine());
                        tu = new San(a, b, c);
                    }
                    catch (Exception a) {
                        Console.WriteLine("输入错误:" + a.Message);
                    }
                }
                else if (name == "Yuan")
                {
                    Console.WriteLine("请输入半径：");
                    try
                    {
                        int a = Int32.Parse(Console.ReadLine());
                        tu = new Yuan(a);
                    }
                    catch (Exception a)
                    {
                        Console.WriteLine("输入错误:" + a.Message);
                    }
                }
                else if (name == "Zhe")
                {
                    Console.WriteLine("请输入边长：");
                    try
                    {
                        int a = Int32.Parse(Console.ReadLine());
                        tu = new Zhe(a);
                    }
                    catch (Exception a)
                    {
                        Console.WriteLine("输入错误:" + a.Message);
                    }
                }
                else if (name == "Cha")
                {
                    Console.WriteLine("请依次输入两边长：");
                    try
                    {
                        int a = Int32.Parse(Console.ReadLine());
                        int b = Int32.Parse(Console.ReadLine());
                        tu = new Cha(a, b);
                    }
                    catch (Exception a)
                    {
                        Console.WriteLine("输入错误:" + a.Message);
                    }
                }
                return tu;
            }
            static void Main(string[] args)
            {
                try {
                    Tu tu;
                    Console.WriteLine("请输入图形名：");
                    tu = Factory.getTu(Console.ReadLine());
                    Console.WriteLine("此图形的面积为：" + tu.s);
                }
                catch (Exception a) {
                    Console.WriteLine("输入错误:" + a.Message);
                }
            }
        }
    }
}
