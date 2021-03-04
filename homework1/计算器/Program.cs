using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double a,b,ans;
            string s;
            char x;
            Console.WriteLine("请输入第一个数字");
            s = Console.ReadLine();
            if (Double.TryParse(s, out a)) ;
            else 
            { 
                Console.WriteLine("输入不合法请重新运行程序");
                Console.WriteLine("按任意键继续");
                Console.ReadKey(true);
                return;
            }
            Console.WriteLine("请输入第二个数字");
            s = Console.ReadLine();
            if (Double.TryParse(s, out b)) ;
            else
            {
                Console.WriteLine("输入不合法请重新运行程序");
                Console.WriteLine("按任意键继续");
                Console.ReadKey(true);
                return;
            }
            Console.WriteLine("请输入运算符号");
            s = Console.ReadLine();
            if (Char.TryParse(s, out x)) ;
            else
            {
                Console.WriteLine("输入不合法请重新运行程序");
                Console.WriteLine("按任意键继续");
                Console.ReadKey(true);
                return;
            }
            switch (x)
            {
                case '+':
                    ans = a + b;
                    break;
                case '-':
                    ans = a - b;
                    break;
                case '*':
                    ans = a * b;
                    break;
                case '/':
                    if(b!=0)
                    ans = a / b;
                    else
                    {
                        Console.WriteLine("输入不合法请重新运行程序");
                        Console.WriteLine("按任意键继续");
                        Console.ReadKey(true);
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("输入不合法请重新运行程序");
                    Console.WriteLine("按任意键继续");
                    Console.ReadKey(true);
                    return;
                    break;
            }
            Console.WriteLine(ans);
            
        }
    }
}
