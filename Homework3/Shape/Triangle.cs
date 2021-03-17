using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Triangle:Shape
    {
        double a, b, c;
        public Triangle(double a,double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public double Area()
        {
            double s = (a + b + c) / 2;

            double ans = Math.Sqrt(s*(s-a)*(s-b)*(s-c));
            
            return ans;
        }
    }
}
