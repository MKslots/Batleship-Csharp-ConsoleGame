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
        public string Name { get; set; }

        readonly Ship frigate = new Ship(2);
        readonly Ship submarine = new Ship(3);
        readonly Ship destroyer = new Ship(4);       
        
        public Player(Sea sea, string name)
        {
            Sea = sea;
            Name = name;

            frigate.ShipPlacment(sea);
            //submarine.ShipPlacment(sea);
            //destroyer.ShipPlacment(sea);
           
        }

        string NameColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;           
            return Name;
        } 

        void ResetColor() => Console.ResetColor();


        public void Shoot(Player player)
        {
            Console.Write($"{NameColor()}");
            ResetColor();
            Console.WriteLine(" Turn ");

            while (true)
            {
           
                Console.Write("X ? : ");
                int shootX = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Y ? : ");
                int shootY = int.Parse(Console.ReadLine()) - 1;

                if (!player.Sea.OnSea(shootX, shootY))
                {
                    throw new OutOfBoundsException($"{shootX - 1}, {shootY - 1} is outside the boundaries of the sea.");
                }

                if (player.Sea.GameSea[shootX, shootY].Name != "Empty" && player.Sea.GameSea[shootX, shootY].Name != "Sank" && player.Sea.GameSea[shootX, shootY].Name != "Miss")
                {
                    player.Sea.GameSea[shootX, shootY].Health--;
                    if (player.Sea.GameSea[shootX, shootY].Health > 0)
                    {
                        Console.WriteLine($"Hit {player.Sea.GameSea[shootX, shootY].Name} but not sink!");
                        player.Sea.GameSea[shootX, shootY] = player.Sea.sank;
                        break;
                    }
                    else if (player.Sea.GameSea[shootX, shootY].Health == 0)
                    {
                        Console.WriteLine($"Hit {player.Sea.GameSea[shootX, shootY].Name} and sank!");
                        player.Sea.GameSea[shootX, shootY] = player.Sea.sank;
                        player.DestroyedShips++;
                        break;
                    }

                }
                else if (player.Sea.GameSea[shootX, shootY].Name == "Sank")
                {
                    Console.WriteLine("You have already attacked this battleship! Please try other spot.");
                    continue;

                }
                else if (player.Sea.GameSea[shootX, shootY].Name == "Miss")
                {
                    Console.WriteLine("You have already attacked this location! Please try other spot.");
                    continue;
                }
                else if (player.Sea.GameSea[shootX, shootY].Name == "Empty")
                {
                    Console.WriteLine("Miss!");
                    player.Sea.GameSea[shootX, shootY] = player.Sea.miss;
                    break;
                }
            }
        }

        public void Shoot(Computer computer)
        {

            Console.Write($"{NameColor()}");
            ResetColor();
            Console.WriteLine(" Turn ");

            while (true)
            {
                Console.Write("X ? : ");
                int shootX = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Y ? : ");
                int shootY = int.Parse(Console.ReadLine()) - 1;

                if (!computer.Sea.OnSea(shootX, shootY))
                {
                    throw new OutOfBoundsException($"{shootX - 1}, {shootY - 1} is outside the boundaries of the sea.");
                }

                if (computer.Sea.GameSea[shootX, shootY].Name != "Empty" && computer.Sea.GameSea[shootX, shootY].Name != "Sank" && computer.Sea.GameSea[shootX, shootY].Name != "Miss")
                {
                    computer.Sea.GameSea[shootX, shootY].Health--;
                    if (computer.Sea.GameSea[shootX, shootY].Health > 0)
                    {
                        Console.WriteLine($"Hit {computer.Sea.GameSea[shootX, shootY].Name} but not sink!");
                        computer.Sea.GameSea[shootX, shootY] = computer.Sea.sank;
                        break;
                    }
                    else if (computer.Sea.GameSea[shootX, shootY].Health == 0)
                    {
                        Console.WriteLine($"Hit {computer.Sea.GameSea[shootX, shootY].Name} and sank!");
                        computer.Sea.GameSea[shootX, shootY] = computer.Sea.sank;
                        computer.DestroyedShips++;
                        break;
                    }

                }
                else if (computer.Sea.GameSea[shootX, shootY].Name == "Sank")
                {
                    Console.WriteLine("You have already attacked this battleship! Please try other spot.");
                    continue;
                }
                else if (computer.Sea.GameSea[shootX, shootY].Name == "Miss")
                {
                    Console.WriteLine("You have already attacked this location! Please try other spot.");
                    continue;
                }
                else if (computer.Sea.GameSea[shootX, shootY].Name == "Empty")
                {
                    Console.WriteLine("Miss!");
                    computer.Sea.GameSea[shootX, shootY] = computer.Sea.miss;
                    break;
                }
            }
        }
    }
}
