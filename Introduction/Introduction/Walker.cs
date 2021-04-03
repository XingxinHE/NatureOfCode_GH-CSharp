using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    public class Walker
    {
        //Declare fields
        public double x;
        public double y;
        //public bool Move = false;
        private Random dice = new Random();

        //constructor

        public Walker(double x, double y)
        {
            this.x = x;
            this.y = y;
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
        public void Reset()
        {
            this.x = 0;
            this.y = 0;
        }

    }
}
