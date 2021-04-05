using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
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

            Console.WriteLine("按订单号查找订单");
            Console.WriteLine(orderService.GetById(1));

            Console.WriteLine("查询全部订单");
            List<Order> orders = orderService.orderList;
            orders.ForEach(o => Console.WriteLine(o));

            Console.WriteLine("按商品名查找订单（如goods1）");
            orders = orderService.QueryByGoodsName("goods1");
            orders.ForEach(o => Console.WriteLine(o));

            Console.WriteLine("按客户名查找订单（如Jack）");
            orders = orderService.QueryByCustomerName("Jack");
            orders.ForEach(o => Console.WriteLine(o));

            Console.WriteLine("按订单金额查找订单（如10）");
            orders = orderService.QueryByTotalAmount(10.0);
            orders.ForEach(o => Console.WriteLine(o));

            Console.WriteLine("删除订单1");
            orderService.RemoveOrder(1);


            Console.WriteLine("展示删除结果");
            orders = orderService.orderList;
            orders.ForEach(o => Console.WriteLine(o));

            Console.ReadLine();
        }
    }
}
