using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatleshipConsoleGame
{
    class Ship
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }

        public Ship(int health)
        {
            Health = health;
            if (Health == 2)
            {
                Length = 2;
                Name = "Frigate";
            }
            else if (Health == 3)
            {
                Length = 3;
                Name = "Submarine";
            }
            else if (Health == 4)
            {
                Length = 4;
                Name = "Destroyer";
            }
            else if (Health == 0)
            {
                Length = 0;
                Name = "Empty";
            }
            else if (Health == -1)
            {
                Length = -1;
                Name = "Sank";
            }
        }

        public void ShipPlacment(Sea sea)
        {
            bool placed = false;

            while (placed == false)
            {
                try
                {

                    Console.WriteLine($"Select location of your {Name} between 1-10:");
                    Console.Write("Row Location: ");
                    int x = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("Column location: ");
                    int y = int.Parse(Console.ReadLine()) - 1;

                    Console.Write("Enter 1 for Horizontal or 2 Vertical :");
                    string orient = Console.ReadLine();

                    if (!sea.OnSea(x, y))
                    {
                        throw new OutOfBoundsException($"{x - 1}, {y - 1} is outside the boundaries of the sea.");
                    }

                    string notEmpty = $"You already got battleship on {x + 1}, {y + 1} location, please select other location.";



                    if (sea.GameSea[x, y].Name != "Empty")
                    {
                        Console.WriteLine(notEmpty);
                        continue;
                    }
                    else if (sea.GameSea[x, y].Name == "Empty")
                    {
                        if (orient == "1")
                        {
                            for (int i = 0; i < Health; i++, x++)
                            {
                                if (sea.GameSea[x, y].Name != "Empty")
                                {
                                    Console.WriteLine(notEmpty);
                                    continue;
                                }
                                else
                                {
                                    sea.GameSea[x, y] = this;
                                    placed = true;
                                }

                            }
                        }
                        else if (orient == "2")
                        {
                            for (int i = 0; i < Health; i++, y++)
                            {
                                if (sea.GameSea[x, y].Name != "Empty")
                                {
                                    Console.WriteLine(notEmpty);
                                    continue;
                                }
                                else
                                {
                                    sea.GameSea[x, y] = this;
                                    placed = true;
                                }

                            }

                        }
                        else
                        {
                            throw new FormatException();
                        }
                    }
                }
                catch (OutOfBoundsException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("This is not valid input select 1 or 2");
                }

            }

        }
    }
}
