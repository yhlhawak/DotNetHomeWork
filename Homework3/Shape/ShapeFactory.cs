using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class ShapeFactory
    { 
        public static Shape getShape(string shapeType)
        {
            if(shapeType == null)
            {
                return null;
            }
            switch (shapeType)
            {
                case "长方形":
                    Console.WriteLine("请输入长与宽，空格隔开");
                    string inits = Console.ReadLine();
                    string[] init = inits.Split(' ');
                    double length, width;
                    if (init.Length > 2||!Double.TryParse(init[0],out length)|| !Double.TryParse(init[1], out width))
                    {
                        Console.WriteLine("输入不合法");
                        return null;
                    }
                    else
                    {
                        return new Rectangle(length, width);
                    }
                    break;
                case "正方形":
                    Console.WriteLine("请输入边长");
                    inits = Console.ReadLine();
                    init = inits.Split(' ');
                    if (init.Length > 1 || !Double.TryParse(init[0], out length))
                    {
                        Console.WriteLine("输入不合法");
                        return null;
                    }
                    else
                    {
                        return new Square(length);
                    }
                    break;
                case "三角形":
                    Console.WriteLine("请输入三边长度，空格隔开");
                    inits = Console.ReadLine();
                    init = inits.Split(' ');
                    double a, b, c;
                    if (init.Length > 3 || !Double.TryParse(init[0], out a)|| !Double.TryParse(init[1], out b)|| !Double.TryParse(init[2], out c))
                    {
                        Console.WriteLine("输入不合法");
                        return null;
                    }
                    else if (a + b <= c || Math.Abs(a - b) >= c)
                    {
                        Console.WriteLine("此三边无法构成三角形");
                        return null;
                    }
                    else
                    {
                        return new Triangle(a,b,c);
                    }
                    break;
            }
            return null;
        }
    }
}
