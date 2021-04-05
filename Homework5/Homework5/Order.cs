using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    class Order
    {
        public int Id;
        public Customer Client;
        public DateTime CreateTime;

        public double Amounts
        {
            get => Details.Sum(d => d.Amount);
        }

        public Order(int id,Customer client)
        {
            Id = id;
            Client = client;
            CreateTime = DateTime.Now;
        }

        public List<OrderDetails> Details = new List<OrderDetails>();

        public void AddDetails(OrderDetails details)
        {
            Details.Add(details);
        }

        public void RemoveDetails(int num)
        {
            Details.RemoveAt(num);
        }
        public void RemoveDetails(OrderDetails detail)
        { 
            Details.Remove(detail);
        }


        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null && Id == order.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public override string ToString()
        {
            String result = $"orderId:{Id}, customer:({Client})";
            Details.ForEach(detail => result += "\n\t" + detail);
            return result;
        }
    }
}
