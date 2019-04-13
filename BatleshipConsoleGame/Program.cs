using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatleshipConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Battle Ship Console Game.");
            Console.WriteLine("Please select game mode :");
            Console.WriteLine("1. Player vs Computer");
            Console.WriteLine("2. Player vs Player");
            while (true)
            {
                try
                {
                    int mode = int.Parse(Console.ReadLine());
                    if (mode == 1)
                    {
                        PvC.Play();
                        break;
                    }
                    else if (mode == 2)
                    {
                        PvP.Play();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please select 1 or 2.");
                        continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("This is not valid input, please select 1 or 2.");
                }
            }



        }
    }
}
