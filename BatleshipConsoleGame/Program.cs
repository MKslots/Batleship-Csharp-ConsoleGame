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
            Sea PlayerSea = new Sea();            
            Player player1 = new Player(PlayerSea);

            while (true)
            {

                player1.Shoot(player1); 

                if (player1.DestroyedShips >= 3)
                {
                    Console.WriteLine("You Won! Bye!");
                    break;
                }
            }
        }
    }
}
