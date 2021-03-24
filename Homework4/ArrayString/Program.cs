using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayString
{
    class Program
    {
        static int sum = 0;
        static int max = 0;
        static int min = 99999999;
        static void Sum(int x)
        {
            sum += x;
        }
        static void Max(int x)
        {
            max = max > x ? max : x;
        }

        static void Min(int x)
        {
            min = min < x ? min : x;
        }
        static void Main(string[] args)
        {
            GenericList<int> intlist = new GenericList<int>();
            Random random = new Random();
            for(int x = 0; x < 10; x++)
            {
                intlist.Add(random.Next(1,200));
            }
            max = min = intlist.Head.Data;
            Console.WriteLine("打印链表");
            intlist.ForEach(x => Console.Write(x.ToString()+" "));
            Console.WriteLine();
            Console.WriteLine("求和链表");
            intlist.ForEach(x => Sum(x));
            Console.WriteLine(sum.ToString());
            Console.WriteLine("求最大值");
            intlist.ForEach(x => Max(x));
            Console.WriteLine(max.ToString());
            Console.WriteLine("求最小值");
            intlist.ForEach(x => Min(x));
            Console.WriteLine(min.ToString());
            Console.ReadLine();
        }
    }
}
