using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[99];
            for (int i = 0; i < 99; i++)
            {
                a[i] = i + 2;
            }
            int temp = 0;
            for (int b = 2; b < 100; b++)
            {
                for (int c = 2; c < 100; c++)
                {
                    temp = b * c;
                    if (temp <= 100)
                    {
                        a[temp - 2] = 0;
                    }
                }
            }
            Console.Write("2~100以内的素数：");
            for (int j = 0; j < 99; j++)
            {
                if (0 != a[j])
                {
                    Console.Write(" " + a[j]);
                }
            }
        }
    }
}
