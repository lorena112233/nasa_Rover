using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasa_Rover
{
    class Car
    {

        public readonly string[] COORD = {"N", "E", "S", "W" };

        // Attributes
        private int x;
        private int y;
        private int facing;

        // Constructor
        public Car(string position)
        {
            string[] parameters = position.Split(' ');
            this.x = Convert.ToInt16(parameters[0]);
            this.y = Convert.ToInt16(parameters[1]);
            this.facing = Array.IndexOf(COORD, Convert.ToString(parameters[2]));    

        }

        // Getters, Setters
        public int Getx()
        {

            return x;

        }
        public void Setx(int x)
        {

            this.x = x;

        }

        public int Gety()
        {

            return y;

        }
        public void Sety(int y)
        {

            this.y = y;

        }

        public int Getfacing()
        {

            return facing;

        }
        public void Setfacing(int facing)
        {

            this.facing = facing;

        }

        // turning to the Rigth or to the Left
        public void turn(string turn_order)
        {

            switch (turn_order)
            {
                case "L":
                    this.facing += -1;
                    if (this.facing == -1)
                    {
                        this.facing = 3;
                    }
                    break;

                case "R":
                    this.facing += 1;
                    if (this.facing == 4)
                    {
                        this.facing = 0;
                    }
                    break;

            }
        }

        // +1 Move ahead
        public void move()
        {
            //get value of actual facing
            int wohin = this.facing;

            switch(wohin)
            {
                case 0: // COORD[0] = "N"
                    this.y += 1;
                    break;
                case 1: // COORD[1] = "E"
                    this.x += 1;
                    break;
                case 2: // COORD[2] = "S"
                    this.y += -1;
                    break;
                case 3: // COORD[0] = "W"
                    this.x += -1;
                    break;

            };

        }

        //shows actual position of the Car
        public string actual_position()
        {
            // return actual position + (messagge)
            string position = (this.x + " " + this.y + " " + this.facing);
            if(this.x < 0 || this.y < 0)
            {
                return (position + " Rover lost in Mars//Out of Range");
            }
            return (position + " Successfully arrived");
        }


    }
}
