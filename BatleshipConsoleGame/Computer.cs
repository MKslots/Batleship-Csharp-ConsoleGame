using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatleshipConsoleGame
{
    class Computer
    {
        Random random = new Random();
        public Sea Sea { get; set; }
        public int DestroyedShips { get; set; }

        readonly Ship frigate = new Ship(2);
        readonly Ship submarine = new Ship(3);
        readonly Ship destroyer = new Ship(4);

        public Computer(Sea sea)
        {
            Sea = sea;

            frigate.ComputerShipPlacement(Sea);
            submarine.ComputerShipPlacement(Sea);
            destroyer.ComputerShipPlacement(Sea);
        }

     
        
        public void ComputerShoot(Player player)
        {
            bool shoot = false;    
            while (shoot == false)
            {
                int shootX = random.Next(9);
                int shootY = random.Next(9);

                if (player.Sea.GameSea[shootX, shootY].Name != "Empty" && player.Sea.GameSea[shootX, shootY].Name != "Sank" && player.Sea.GameSea[shootX, shootY].Name != "Miss")
                {
                    player.Sea.GameSea[shootX, shootY].Health--;
                    if (player.Sea.GameSea[shootX, shootY].Health > 0)
                    {
                        Console.WriteLine($"Computer Hit {player.Sea.GameSea[shootX, shootY].Name} but not sink!");
                        player.Sea.GameSea[shootX, shootY] = player.Sea.sank;
                        shoot = true;
                    }
                    else if (player.Sea.GameSea[shootX, shootY].Health == 0)
                    {
                        Console.WriteLine($"Computer Hit {player.Sea.GameSea[shootX, shootY].Name} and sank!");
                        player.Sea.GameSea[shootX, shootY] = player.Sea.sank;
                        player.DestroyedShips++;
                        shoot = true;
                    }

                }
                else if (player.Sea.GameSea[shootX, shootY].Name == "Sank")
                {
                    shoot = false;
                    Console.WriteLine("repeta");
                }
                else if (player.Sea.GameSea[shootX, shootY].Name == "Miss")
                {
                    Console.WriteLine("repeat");
                    shoot = false;
                }
                else if (player.Sea.GameSea[shootX, shootY].Name == "Empty")
                {
                    Console.WriteLine("Computer Missed!");
                    player.Sea.GameSea[shootX, shootY] = player.Sea.miss;
                    shoot = true;
                }
            }

        }
        

            
    }
}
