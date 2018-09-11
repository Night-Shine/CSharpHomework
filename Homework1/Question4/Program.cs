using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            double a, b;
            Console.Write("Please input the first double:");
            s = Console.ReadLine();
            a = Double.Parse(s);
            Console.Write("Please input the second double:");
            s = Console.ReadLine();
            b = Double.Parse(s);
            double c = a * b;
            Console.WriteLine("The product of them is:" + c);
        }
    }
}
