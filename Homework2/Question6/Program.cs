using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入要进行操作的整数:");
            try
            {
                string s = Console.ReadLine();
                int a = Int32.Parse(s);
                if (a < 2)
                {
                    Console.WriteLine("此数无素数因子");
                }
                else {
                    Console.Write("此数素数因子为:");
                    int i = 2,j = 0,b = a;
                    while (i <= b) {
                        if (a % i == 0)
                        {
                            a = a / i;
                            j++;
                        }
                        else {
                            if (j > 0) {
                                Console.Write(i + " ");
                                j = 0;
                            }
                            i++;
                        }
                    }
                }
            }
            catch (Exception a) {
                Console.WriteLine("输入错误:"+a.Message);
            }
        }
    }
}
