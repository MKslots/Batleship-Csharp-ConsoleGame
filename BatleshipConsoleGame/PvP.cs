using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatleshipConsoleGame
{
    public static class PvP
    {
        public static void Play()
        {
            Sea Player1Sea = new Sea();
            Player player1 = new Player(Player1Sea);
            Sea Player2Sea = new Sea();
            Player player2 = new Player(Player2Sea);

            while (true)
            {
                try
                {
                    player1.Shoot(player2);
                    player2.Shoot(player1);

                    if (player1.DestroyedShips >= 3 || player2.DestroyedShips >= 3)
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
