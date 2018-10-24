using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using program1;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShowListtest()
        {
            List<Program.Order> testList = new List<Program.Order>();
            foreach (Program.Order order in testList)
            {
                Console.WriteLine(order.ToString());
            }
            Assert.IsNotNull(testList);
            Assert.IsNull(testList);
        }
        [TestMethod()]
        public void addOrdertest()
        {
            List<Program.Order> testList = new List<Program.Order>();
            Program.Order order = new Program.Order();
            order.Detail.Num = 0;
            testList.Add(order);
            Assert.IsNotNull(testList);
        }
        [TestMethod()]
        public void deletOrderTest()
        {
            List<Program.Order> testList = new List<Program.Order>();
            testList.RemoveAt(1);
            Assert.IsNull(testList);
            Assert.IsNotNull(testList);
        }
        [TestMethod()]
        public void ChangeListTest()
        {
            List<Program.Order> testList = new List<Program.Order>();
            Program.Order order = new Program.Order();
            testList.RemoveAt(1);
            order.Detail.Num = 1;
            Assert.IsNull(testList);
            Assert.IsNotNull(testList);
        }
        [TestMethod()]
        public void SearchListTest()
        {
            List<Program.Order> testList = new List<Program.Order>();
            Program.Order order = new Program.Order();
            order.Detail.CutomerName = "122";
            order.Detail.ProductName = "111";
            order.Detail.Num = 1;
            Assert.IsNull(testList);
            Assert.IsNotNull(testList);
        }
    }
}
