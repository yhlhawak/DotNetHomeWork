using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    public class Goods
    {
        public int Id;
        public string Name;

        public double Price;

        public Goods()
        {
        }

        public Goods(int id , string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }


        public override bool Equals(object obj)
        {
            var goods = obj as Goods;
            return goods != null && Id == goods.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Value:{Price}";
        }
    }
}
