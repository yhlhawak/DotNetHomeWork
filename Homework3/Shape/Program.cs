using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string[] shapeType = { "长方形", "正方形", "三角形" };
            double ans = 0;
            for(int i = 1; i <= 10; i++)
            {
                string shape = shapeType[random.Next(0,3)];
                Console.WriteLine(shape);
                Shape wants = ShapeFactory.getShape(shape);
                if (wants != null) ans += wants.Area();
                else i--;
            }
            Console.WriteLine("这十个图形的面积和为" + ans.ToString());
            Console.WriteLine("按任意键继续");
            Console.ReadKey(true);
        }
    }
}
