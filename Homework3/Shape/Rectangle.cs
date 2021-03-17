using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Rectangle:Shape
    {
        double length, width;

        public Rectangle(double length , double width)
        {
            this.length = length;
            this.width = width;
        }
        public double Area()
        {

            return length*width;
        }
    }
}
