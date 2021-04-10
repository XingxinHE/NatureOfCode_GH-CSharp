using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureOfCode_Cs._1Vector
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
        public void Mul(double n)
        {
            x *= n;
            y *= n;
        }
        public void Div(double n)
        {
            x /= n;
            y /= n;
        }
        public double Mag()
        {
            return Math.Sqrt(x * x + y * y);
        }
        public void Normalize()
        {
            double m = Mag();
            if (m != 0)
            {
                Div(m);
            }
        }
    }
}
