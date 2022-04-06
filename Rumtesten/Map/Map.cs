using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Map
    {
        private List<Cell> cells = new List<Cell>();

        private Town town;

        public Map() { }

        public Map(int height, int width)
        {
            town = new Town(Game.rnd.Next(1, height), Game.rnd.Next(1, width));

            MapCreation();
        }


        public void DrawMap(Player player)
        {
            for (int k = 0; k < cells.Count; k++)
            {
                if (cells[k].Y != Game.WIDTH - 1)
                {
                    if (cells[k].IsWalkable)
                    {
                        if (player.X == cells[k].X && player.Y == cells[k].Y)
                        {
                            Console.Write(player.Marker);
                            cells[k].IsOccupied = true;
                        }
                        else if (town.X == cells[k].X && town.Y == cells[k].Y)
                        {
                            Console.Write(town.Sym);
                            cells[k].IsOccupied = true;
                        }
                        else
                        {
                            Console.Write(cells[k].isWalkableChar);
                            cells[k].IsOccupied = false;
                        }
                    }
                    else
                    {
                        Console.Write(cells[k].isNotWalkableChar);
                    }
                }
                else
                {
                    if (cells[k].IsWalkable)
                    {
                        Console.WriteLine(cells[k].isWalkableChar);
                    }
                    else
                    {
                        Console.WriteLine(cells[k].isNotWalkableChar);
                    }
                }

            }

        }

        public bool IsOccupied(int x, int y)
        {
            return true;
        }

        public bool GetCellIsWalkable(int x, int y)
        {
            foreach (var cell in cells)
            {
                if (x == cell.X && y == cell.Y)
                {
                    if (cell.IsWalkable)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// is Used for map creation
        /// </summary>
        void MapCreation()
        {
            for (int x = 0; x < Game.HEIGHT; x++)
            {
                for (int y = 0; y < Game.WIDTH; y++)
                {
                    if (x == 0)
                    {
                        cells.Add(new Cell(x, y, false, false));
                    }
                    else if (y == 0)
                    {
                        cells.Add(new Cell(x, y, false, false));
                    }
                    else if (x == Game.HEIGHT - 1)
                    {
                        cells.Add(new Cell(x, y, false, false));
                    }
                    else if (y == Game.WIDTH - 1)
                    {
                        cells.Add(new Cell(x, y, false, false));
                    }
                    else
                    {
                        cells.Add(new Cell(x, y, true, false));
                    }
                }
            }
        }
    }
}
