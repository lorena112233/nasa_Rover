using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Nasa_Rover
{
    static class Program
    {
        static void Main(string[] args)
        {
            // save max value (x,y) = plateau size
            int plateau_sizeX, plateau_sizeY;

            //------------------ PLATEAU -------------------------
            // get dimensions of the plateau
            string[] plateau = create_plateau();
            plateau_sizeX = Convert.ToInt32(plateau[0]);
            plateau_sizeY = Convert.ToInt32(plateau[1]);


            //------------------ ROVER 1 -------------------------
            // get initial position for Rover1: format integers ('1 2 2')
            Car Rover1 = create_Rover_position(plateau_sizeX, plateau_sizeY);
            // get input for movements and move Rover1
            Rover_movements(Rover1);

            //------------------ ROVER 2 -------------------------
            // Creating Rover2//get initial position
            Car Rover2 = create_Rover_position(plateau_sizeX, plateau_sizeY);
            // get input for movements and move Rover2
            Rover_movements(Rover2);

            Console.WriteLine("Rover1: " + Rover1.actual_position());
            Console.WriteLine("Rover2: " + Rover2.actual_position());
            Console.ReadLine();
        }

        public static string[] create_plateau()
        {
            string size;
      
            // input: size for the plateau must be between 1-9. Ex: 5 9
            Regex regex_size = new Regex(@"^[1-9][ ][1-9]$");

            // get plateau's size
            do
            {
                Console.WriteLine("Introduce the size of the plateau:");
                size = Console.ReadLine();

            } while (regex_size.IsMatch(size) != true);

            string[] plateau = size.Split(' ');

            return plateau;
        }


        // create Car object
        public static Car create_Rover_position(int plateau_sizeX, int plateau_sizeY)
        {
            string inicialPosition;

            // input: initial position format (3 digits: x, y, facing)
            Regex regex_position = new Regex(@"^[0-9][ ][0-9][ ][N|E|S|W]$");

            do
            {
                Console.WriteLine("Introduce the initial position (format: '1 2 S') ");
                inicialPosition = (Console.ReadLine()).ToUpper();


            } while ( regex_position.IsMatch(inicialPosition) != true || verify_input(inicialPosition, plateau_sizeX, plateau_sizeY) != true );


            Console.WriteLine("inicialPosition  " + inicialPosition);

            // creating Rover1:
            Car Rover = new Car(inicialPosition);

            return Rover;
        }

        // get parameters for movements
        public static void Rover_movements(Car Rover)
        {
            string movements_char;

            // input: movements format (valid: "M" or "L" or "R" + minimun 1 character)
            Regex regex_movements = new Regex(@"^(M|L|R){1,}$");

            do
            {
                Console.WriteLine("Introduce the secuence of movements withous spaces in between: (format: 'LML') ");
                movements_char = (Console.ReadLine().ToUpper());
            } while (regex_movements.IsMatch(movements_char) != true);

            foreach (char m in movements_char)
            {
                string movement = Convert.ToString(m);
                getValues(Rover, movement);

            }
        }

        // update object values based on input parameters
        public static void getValues(Car Rover, string movement)
        {
            switch (movement)
            {
                case "L":
                case "R":
                    Rover.turn(movement);
                    //Console.WriteLine(movement + "--> Rover.actual_position_" + Rover.actual_position());
                    //Console.ReadLine();
                    break;

                case "M":
                    Rover.move();
                    //Console.WriteLine(movement + "--> Rover.actual_position_" + Rover.actual_position());
                    //Console.ReadLine();
                    break;
                default:
                    throw new InvalidOperationException("Unexpected value");
            }
        }

        public static bool verify_input(string input_text, int plateau_sizeX, int plateau_sizeY)
        {

            string[] parameters = input_text.Split(' ');

            if (parameters.Length != 3)
            {
                Console.WriteLine("3 parameters needed ( format: 0 0 N )");
                return false;
            }
            else
            {
                int x = Convert.ToInt16(parameters[0]);
                int y = Convert.ToInt16(parameters[1]);
                if(x > plateau_sizeX || y > plateau_sizeY)
                {
                    Console.WriteLine(" Out of Range / The Rover will land out of the plateau. Please set its initial position once again: ");
                    return false;
                }
                else
                {
                    return true;
                }

            }


        }
        




    }
}
