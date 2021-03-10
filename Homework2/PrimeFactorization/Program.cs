using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactorization
{
    /*
     * 使用埃氏筛法帮助分解质因数
     */
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            //List<int> answer = new List<int>();
            Console.WriteLine("请输入一个整数");
            if(!Int32.TryParse(Console.ReadLine(),out number))
            {
                Console.WriteLine("输入不合法请重启程序");
                Console.WriteLine("按任意键继续");
                Console.ReadKey(true);
                return;
            }
            Sieve sieve=new Sieve(number);
            foreach(int a in sieve.prime)
            {
                if (number % a == 0)
                { 
                    Console.Write(a.ToString()+" ");
                    number /= a;
                }
                while (number % a == 0)
                {
                    number /= a;
                }
            }
            Console.WriteLine();
            Console.WriteLine("按任意键继续");
            Console.ReadKey(true);
        }
    }
}
