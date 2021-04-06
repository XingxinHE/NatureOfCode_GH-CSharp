using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Vector
{
    public class PVector
    {
        public double x;
        public double y;

        public PVector(double x_, double y_)
        {
            this.x = x_;
            this.y = y_;
        }

        public void Add(PVector v)
        {
            x += v.x;
            y += v.y;
        }

        public void Sub(PVector v)
        {
            x -= v.x;
            y -= v.y;
        }
    }
}
