using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatleshipConsoleGame
{
    class Sea
    {
        public Ship[,] GameSea { get; set; }
        readonly Ship empty = new Ship(0);
        public readonly Ship sank = new Ship(-1);
        public Ship miss = new Ship(-2);

        public Sea()
        {
            GameSea = new Ship[10, 10];
            FillSea();
        }

        public void FillSea()
        {
            for (int xIndex = 0; xIndex < GameSea.GetLength(0); xIndex++)
            {
                for (int yIndex = 0; yIndex < GameSea.GetLength(1); yIndex++)
                {
                    GameSea[xIndex, yIndex] = empty;
                }
            }
        }

        public bool OnSea(int X, int Y)
        {
            return X >= 0 && X < GameSea.GetLength(0) &&
                   Y >= 0 && Y < GameSea.GetLength(1);
        }

    }
}
