using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureOfCode_Cs._1Vector;

namespace NatureOfCode_Cs._2Force
{
    public class Mover
    {
        public PVector location;
        public PVector velocity;
        public PVector acceleration;
        public double mass;

        public Mover(double m, double x, double y)
        {
            this.mass = m;
            this.location = new PVector(x, y);
            this.velocity = new PVector(0, 0);
            this.acceleration = new PVector(0, 0);
        }

        public void ApplyForce(PVector force)
        {
            PVector f = new PVector(force.x / mass, force.y / mass);
            acceleration.Add(f);
        }

        public void Update()
        {
            velocity.Add(acceleration);
            location.Add(velocity);
            acceleration.Mul(0);
        }

        public void CheckEdges(double width, double height)
        {
            if (location.x > width)
            {
                location.x = width;
                velocity.x *= -1;
            }
            else if (location.x < 0)
            {
                velocity.x *= -1;
                location.x = 0;
            }

            if (location.y > height)
            {
                location.y = height;
                velocity.y *= -1;
            }
            else if (location.y < 0)
            {
                velocity.y *= -1;
                location.y = 0;
            }

        }
    }
}
