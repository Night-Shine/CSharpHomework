using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入整数数组长度:");
            try
            {
                string s = Console.ReadLine();
                int a = Int32.Parse(s);
                int[] arry = new int[a];
                Console.WriteLine("请输入整数数组:");
                int i = 0;
                while (!(i == a))
                {
                    s = Console.ReadLine();
                    arry[i] = Int32.Parse(s);
                    i++;
                }
                int max = arry[0];
                for (i = 1; i < a; i++)
                {
                    if (max < arry[i])
                    {
                        max = arry[i];
                    }
                }
                int min = arry[0];
                for (i = 1; i < a; i++)
                {
                    if (min > arry[i])
                    {
                        min = arry[i];
                    }
                }
                int mix = 0;
                for (i = 0; i < a; i++)
                {
                    mix += arry[i];
                }
                double average = (double)mix / a;
                Console.Write("最大值：" + max + "  最小值：" + min + "  平均值：" + average + "  所有数组元素的和：" + mix);
            }
            catch (Exception a)
            {
                Console.WriteLine("输入错误:" + a.Message);
            }
        }
    }
}
