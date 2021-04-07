using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework6.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddOrderTest()
        {
            Order order = new Order();
            OrderService orderService = new OrderService();
            orderService.AddOrder(order);
            Assert.IsTrue(orderService.orderList.Contains(order));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Order order = new Order();
            OrderService orderService = new OrderService();
            orderService.AddOrder(order);
            Assert.IsTrue(orderService.orderList.Contains(order));
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Customer cu = new Customer();
            Order or1 = new Order(1, cu);
            Order or2 = new Order(2, cu);
            Order or3 = new Order(3, cu);
            Order or4 = new Order(4, cu);
            Order or5 = new Order(5, cu);
            Order or6 = new Order(6, cu);

            OrderService orderService = new OrderService();
            orderService.AddOrder(or1);
            orderService.AddOrder(or2);
            orderService.AddOrder(or3);
            orderService.AddOrder(or4);
            orderService.AddOrder(or5);
            orderService.AddOrder(or6);

            Assert.AreEqual(orderService.GetById(1), or1);
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            Customer cu = new Customer();
            Order or1 = new Order(1, cu);
            Order or2 = new Order(2, cu);
            Order or3 = new Order(3, cu);
            Order or4 = new Order(4, cu);
            Order or5 = new Order(5, cu);
            Order or6 = new Order(6, cu);

            OrderService orderService = new OrderService();
            orderService.AddOrder(or1);
            orderService.AddOrder(or2);
            orderService.AddOrder(or3);
            orderService.AddOrder(or4);
            orderService.AddOrder(or5);
            orderService.AddOrder(or6);
            orderService.RemoveOrder(1);
            Assert.IsNull(orderService.GetById(1));
        }

        [TestMethod()]
        public void QueryByTotalAmountTest()
        {
            Customer customer1 = new Customer(1, "Jack");
            Customer customer2 = new Customer(2, "Mike");

            Goods goods1 = new Goods(1, "goods1", 10.0);
            Goods goods2 = new Goods(2, "goods2", 20.0);
            Goods goods3 = new Goods(3, "goods3", 30.0);


            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetails(goods1, 1));


            Order order2 = new Order(2, customer2);
            order2.AddDetails(new OrderDetails(goods2, 2));
            order2.AddDetails(new OrderDetails(goods3, 3));


            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);

            List<Order> ans = new List<Order>();
            ans.Add(order1);

            Assert.IsTrue(orderService.QueryByTotalAmount(10.0).SequenceEqual(ans));
        }

        [TestMethod()]
        public void QueryByGoodsNameTest()
        {
            Customer customer1 = new Customer(1, "Jack");
            Customer customer2 = new Customer(2, "Mike");

            Goods goods1 = new Goods(1, "goods1", 10.0);
            Goods goods2 = new Goods(2, "goods2", 20.0);
            Goods goods3 = new Goods(3, "goods3", 30.0);


            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetails(goods1, 1));


            Order order2 = new Order(2, customer2);
            order2.AddDetails(new OrderDetails(goods2, 2));
            order2.AddDetails(new OrderDetails(goods3, 3));


            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);


            List<Order> ans = new List<Order>();
            ans.Add(order1);

            Assert.IsTrue(orderService.QueryByGoodsName("goods1").SequenceEqual(ans));
        }

        [TestMethod()]
        public void QueryByCustomerNameTest()
        {
            Customer customer1 = new Customer(1, "Jack");
            Customer customer2 = new Customer(2, "Mike");

            Goods goods1 = new Goods(1, "goods1", 10.0);
            Goods goods2 = new Goods(2, "goods2", 20.0);
            Goods goods3 = new Goods(3, "goods3", 30.0);


            Order order1 = new Order(1, customer1);
            order1.AddDetails(new OrderDetails(goods1, 1));


            Order order2 = new Order(2, customer2);
            order2.AddDetails(new OrderDetails(goods2, 2));
            order2.AddDetails(new OrderDetails(goods3, 3));


            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);

            List<Order> ans = new List<Order>();
            ans.Add(order1);

            Assert.IsTrue(orderService.QueryByCustomerName("Jack").SequenceEqual(ans));
        }
    }
}