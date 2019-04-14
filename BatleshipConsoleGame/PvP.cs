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
            Console.Write("What is Player 1 name? : ");
            string name1 = Console.ReadLine();
            Console.Write("What is Player 2 name? : ");
            string name2 = Console.ReadLine();

            Sea Player1Sea = new Sea();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{name1}");
            Console.ResetColor();
            Console.WriteLine(" Please place battle ships on the sea.");

            Player player1 = new Player(Player1Sea, name1);
        
            Sea Player2Sea = new Sea();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{name2}");
            Console.ResetColor();
            Console.WriteLine(" Please place battle ships on the sea.");
            Player player2 = new Player(Player2Sea, name2);

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
