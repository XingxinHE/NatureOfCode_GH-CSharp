using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noises;

namespace Introduction
{
    public class Walker
    {
        //Declare fields
        public double x;
        public double y;
        private Random dice;

        //constructor
        public Walker(double x, double y)
        {
            this.x = x;
            this.y = y;
            this.dice = new Random();
        }
        public Walker(double x, double y, int seed)
        {
            this.x = x;
            this.y = y;
            this.dice = new Random(seed);
            
        }


        //method
        public void Step()
        {
                int choice = (int)dice.Next(0, 4);
                switch (choice)
                {
                    case 0:
                        x++;
                        break;
                    case 1:
                        x--;
                        break;
                    case 2:
                        y++;
                        break;
                    case 3:
                        y--;
                        break;
                }
            
        }
        public void StepNoise(float time, float scale)
        {
            float tempX = Noise.Generate(time);
            float tempY = Noise.Generate(time + 10000); //Y varies from X

            //because the output of Perlin Noise is between {-1,1}
            tempX *= scale;
            tempY *= scale;
            x += (double)tempX;
            y += (double)tempY;
        }
        public void Reset()
        {
            this.x = 0;
            this.y = 0;
        }

    }
}
