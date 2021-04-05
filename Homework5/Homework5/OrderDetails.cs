using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    class OrderDetails
    {
        public Goods Goods;
        public int Quantity;


        public double Amount
        {
            get => Goods.Price * Quantity;
        }

        public OrderDetails(Goods goods, int quantity)
        {
            Goods = goods;
            Quantity = quantity;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   EqualityComparer<Goods>.Default.Equals(Goods, details.Goods);
        }

        public override int GetHashCode()
        {
            return 785010553 + EqualityComparer<Goods>.Default.GetHashCode(Goods);
        }

        public override string ToString()
        {
            return $"OrderDetail:{Goods},{Quantity}";
        }
    }
}
