using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Square:Rectangle
    {
        double length;
        public Square(double length) : base(length, length)
        {
            this.length = length;
        }
    }
}
