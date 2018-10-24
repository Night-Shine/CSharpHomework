using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace program1 
{
    public class Program
    {
        public class Order
        {
            public OrderDetails Detail = new OrderDetails();

            public void SetDate()
            {
                Console.WriteLine("请输入订单信息：");
                Console.Write("订单号：");
                try
                {
                    int Num = Int32.Parse(Console.ReadLine());
                    Detail.Num = Num;
                }
                catch
                {
                    Console.WriteLine("输入订单号错误。");
                }
                Console.Write("客户名：");
                string CustomerName = Console.ReadLine();
                Detail.CutomerName = CustomerName;
                Console.Write("商品名：");
                string ProductName = Console.ReadLine();
                Detail.ProductName = ProductName;
            }
        }

        public class OrderDetails
        {
            public int Num;
            public string CutomerName = "";
            public string ProductName = "";
        }

        public class OrderService
        {
            static public List<Order> orderList = new List<Order>();

            public int findOrder(string num, int b = 0)
            {
                int a = 0;
                foreach (Order Order in orderList)
                {
                    a++;
                }
                if (num == "1")
                {
                    Console.Write("请输入要查询的订单号：");
                    int s = Int32.Parse(Console.ReadLine());
                    for (int i = 0; i < a; i++)
                    {
                        if (orderList[i].Detail.Num == s)
                        {
                            b = i;
                        }
                    }
                    if (b == 0)
                    {
                        Console.Write("查无可证。");
                    }
                }
                else if (num == "2")
                {
                    Console.Write("请输入要查询的商品名称：");
                    string s = Console.ReadLine();
                    for (int i = 0; i < a; i++)
                    {
                        if (orderList[i].Detail.ProductName == s)
                        {
                            b = i;
                        }
                    }
                    if (b == 0)
                    {
                        Console.Write("查无可证。");
                    }
                }
                else if (num == "3")
                {
                    Console.Write("请输入要查询的客户名称：");
                    string s = Console.ReadLine();
                    for (int i = 0; i < a; i++)
                    {
                        if (orderList[i].Detail.CutomerName == s)
                        {
                            b = i;
                        }
                    }
                    if (b == 0)
                    {
                        Console.Write("查无可证。");
                    }
                }
                else
                {
                    Console.Write("查无可证。");
                }
                return b;
            }

            public void getOrder(string num)
            {
                if (num == "1")
                {
                    Order a = new Order();
                    a.SetDate();
                    orderList.Add(a);
                    Console.WriteLine("请继续指令操作或者按任意指令外的键退出：");
                    this.getOrder(Console.ReadLine());
                }
                else if (num == "2")
                {
                    Console.WriteLine("请输入查询订单的条件数字（订单号、商品名称、客户名称以此为1、2、3）：");
                    int b = findOrder(Console.ReadLine(), 0);
                    orderList.Remove(orderList[b]);
                    Console.WriteLine("请继续指令操作或者按任意指令外的键退出：");
                    this.getOrder(Console.ReadLine());
                }
                else if (num == "3")
                {
                    Console.WriteLine("请输入查询订单的条件数字（订单号、商品名称、客户名称以此为1、2、3）：");
                    int b = findOrder(Console.ReadLine(), 0);
                    Console.WriteLine("请继续指令操作或者按任意指令外的键退出：");
                    this.getOrder(Console.ReadLine());
                }
                else if (num == "4")
                {
                    Console.WriteLine("请输入查询订单的条件数字（订单号、商品名称、客户名称以此为1、2、3）：");
                    int b = findOrder(Console.ReadLine(), 0);
                    Console.WriteLine(orderList[b]);
                    Console.WriteLine("请继续指令操作或者按任意指令外的键退出：");
                    this.getOrder(Console.ReadLine());
                }
                else
                {
                    Console.ReadKey();
                }
            }
            static public void Import(XmlSerializer read, string fileName, object obj)
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                orderList = read.Deserialize(fileStream) as List<Order>;
                fileStream.Close();
            }
            static public void Export(XmlSerializer write, string fileName, object obj)
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                write.Serialize(fileStream, obj);
                fileStream.Close();
            }
        }
        static void Main(string[] args)
        {
            OrderService order = new OrderService();
            Console.WriteLine("请输入相应的指令数字（添加订单、删除订单、修改订单、查询订单分别为1、2、3、4）或者按任意指令外的键退出：");
            order.getOrder(Console.ReadLine());

            XmlSerializer readOrwrite = new XmlSerializer(typeof(List<Order>));
            string xmlFileName = @"D:\C#Homework\Homework6\program1\order.xml";
            OrderService.Export(readOrwrite, xmlFileName, OrderService.orderList);

            Console.WriteLine(File.ReadAllText(xmlFileName));
            OrderService.Import(readOrwrite, xmlFileName, OrderService.orderList);

            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }
    }
}
