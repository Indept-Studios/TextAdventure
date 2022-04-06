using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Cell
    {
        public Cell(int x, int y, bool isWalkable, bool isOccupied)
        {
            X = x;
            Y = y;
            IsWalkable = isWalkable;
            IsOccupied = isOccupied;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsWalkable { get; set; }
        public char isWalkableChar = '.';
        public char isNotWalkableChar = '#';
    }
}
