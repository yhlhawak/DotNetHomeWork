using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        /*
         * 托普利茨矩阵的判断
         */
        static void Main(string[] args)
        {
            int M = 0, N = 0;
            Console.WriteLine("输入矩阵行数，回车结束");
            if(!Int32.TryParse(Console.ReadLine(),out M))
            {
                Console.WriteLine("输入不合法");
                Console.WriteLine("按任意键继续");
                Console.ReadKey(true);
                return;
            }
            Console.WriteLine("输入矩阵列数，回车结束");
            if (!Int32.TryParse(Console.ReadLine(), out N))
            {
                Console.WriteLine("输入不合法");
                Console.WriteLine("按任意键继续");
                Console.ReadKey(true);
                return;
            }
            int[,] matrix = new int[M, N];
            for(int i = 0; i < M; i++)
            {
                Console.WriteLine($"输入矩阵第{i+1}行数据，以空格隔开，回车结束");
                string []temp = Console.ReadLine().Split(' ');
                if (temp.Length < N)
                {
                    Console.WriteLine("输入不合法");
                    Console.WriteLine("按任意键继续");
                    Console.ReadKey(true);
                    return;
                }
                else for(int j = 0; j < N; j++)
                {
                    matrix[i, j] = Int32.Parse(temp[j]);
                }
            }
            int k = M > N ? N : M;
            for(int i = 1; i < k; i++)
            {
                if (matrix[i, i] != matrix[0, 0])
                {
                    Console.WriteLine("False");
                    Console.WriteLine("按任意键继续");
                    Console.ReadKey(true);
                    return;
                }
            }
            Console.WriteLine("True");
            Console.WriteLine("按任意键继续");
            Console.ReadKey(true);
            return;
        }
    }
}
