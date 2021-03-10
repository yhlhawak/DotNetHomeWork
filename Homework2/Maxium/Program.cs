using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxium
{
    class Program
    {
        /*
         * 数组计算的实现
         */

        static double arrayMax(double[] arr)
        {
            double max = arr[0];
            foreach(double a in arr)
            {
                if (a > max) max = a;
            }
            return max;
        }
        static double arrayMin(double[] arr)
        {
            double min = arr[0];
            foreach (double a in arr)
            {
                if (a < min) min = a;
            }
            return min;
        }
        static double arraySum(double[] arr)
        {
            double sum = 0;
            foreach (double a in arr)
            {
                sum += a;
            }
            return sum;
        }
        static double arrayAve(double[] arr)
        {   
            return arraySum(arr)/arr.Length;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数列数据，以空格隔开，回车结束");
            string[] s = Console.ReadLine().Split(' ');
            double[] arr = new double[s.Length];
            for(int i=0;i< s.Length;i++)
            {
                arr[i] = Double.Parse(s[i]);
            }
            Console.WriteLine("数组的最大值为：" + arrayMax(arr).ToString());
            Console.WriteLine("数组的最小值为：" + arrayMin(arr).ToString());
            Console.WriteLine("数组的和为：" + arraySum(arr).ToString());
            Console.WriteLine("数组的平均值为：" + arrayAve(arr).ToString());
            Console.WriteLine("按任意键继续");
            Console.ReadKey(true);
        }
    }
}
