using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatleshipConsoleGame
{
    public static class PvC
    {
        public static void Play()
        {
            Sea PlayerSea = new Sea();
            Player player1 = new Player(PlayerSea);
            Sea ComputerSea = new Sea();
            Computer computer = new Computer(ComputerSea);

            while (true)
            {
                try
                {
                    //player1.Shoot(computer);
                    computer.ComputerShoot(player1);

                    if (player1.DestroyedShips >= 3 || computer.DestroyedShips >= 3)
                    {
                        Console.WriteLine("You Won! Bye!");
                        break;
                    }

                }
                catch (OutOfBoundsException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("This is not valid input");
                }
            }
        }

    }
}
