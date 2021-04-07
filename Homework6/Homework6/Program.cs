using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();

            orderService.Import();
            List<Order> orders = orderService.orderList;
            orders.ForEach(o => Console.WriteLine(o));
            Console.ReadLine();

        }
    }
}
