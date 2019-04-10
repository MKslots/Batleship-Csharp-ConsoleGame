using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatleshipConsoleGame
{
    class Player
    {
        public Sea Sea { get; set; }
        public int DestroyedShips { get; set; }

        readonly Ship frigate = new Ship(2);
        readonly Ship submarine = new Ship(3);
        readonly Ship destroyer = new Ship(4);       
        
        public Player(Sea sea)
        {
            Sea = sea;

            frigate.ShipPlacment(sea);
            submarine.ShipPlacment(sea);
            destroyer.ShipPlacment(sea);
           
        }
           

        public void Shoot(Player player)
        {
            Console.WriteLine("X ?");
            int shootX = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Y ?");
            int shootY = int.Parse(Console.ReadLine()) - 1;

            if (!player.Sea.OnSea(shootX, shootY))
            {
                throw new OutOfBoundsException($"{shootX - 1}, {shootY - 1} is outside the boundaries of the sea.");
            }

            if (player.Sea.GameSea[shootX, shootY].Name != "Empty" && player.Sea.GameSea[shootX, shootY].Name != "Sank")
            {
                player.Sea.GameSea[shootX, shootY].Health--;
                if (player.Sea.GameSea[shootX, shootY].Health > 0)
                {
                    Console.WriteLine($"Hit {player.Sea.GameSea[shootX, shootY].Name} but not sink!");
                    player.Sea.GameSea[shootX, shootY] = player.Sea.sank;
                }
                else if (player.Sea.GameSea[shootX, shootY].Health == 0)
                {
                    Console.WriteLine($"Hit {player.Sea.GameSea[shootX, shootY].Name} and sank!");
                    player.Sea.GameSea[shootX, shootY] = player.Sea.sank;
                    player.DestroyedShips++;
                }

            }
            else if (player.Sea.GameSea[shootX, shootY].Name == "Sank")
            {
                Console.WriteLine("You have already attacked this battleship! Please try other spot.");
            }
            else if (player.Sea.GameSea[shootX, shootY].Name == "Empty")
            {
                Console.WriteLine("Miss!");
            }
        }
    }
}
