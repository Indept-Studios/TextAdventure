using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    [Serializable]
    class Player : Creature
    {
        private static Player instance = null;

        public override int X { get; set; } = 5;
        public override int Y { get; set; } = 5;
        public override string Name { get; set; }
        public override int ID { get; set; }
        public override string Marker { get; set; } = "@";
        public override int Coins { get; set; }
        public override int Health { get; set; } = 10;
        public override int Damage { get; set; } = 1;
        public override int ArmorValue { get; set; } = 0;
        public override int WeaponValue { get; set; } = 0;
        public override int Level { get; set; } = 0;
        public override int XP { get; set; }
        public override int Potions { get; set; } = 0;
        public override int Difficulty { get; set; }

        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player();
                }
                return instance;
            }
        }

        public void Move(Map map)
        {
            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.W || input.Key == ConsoleKey.UpArrow)
            {
                if (map.GetCellIsWalkable(X - 1, Y))
                {
                    X--;
                }
            }
            if (input.Key == ConsoleKey.A || input.Key == ConsoleKey.LeftArrow)
            {
                if (map.GetCellIsWalkable(X, Y - 1))
                {
                    Y--;
                }
            }
            if (input.Key == ConsoleKey.S || input.Key == ConsoleKey.DownArrow)
            {
                if (map.GetCellIsWalkable(X + 1, Y))
                {
                    X++;
                }
            }
            if (input.Key == ConsoleKey.D || input.Key == ConsoleKey.RightArrow)
            {
                if (map.GetCellIsWalkable(X, Y + 1))
                {
                    Y++;
                }
            }
            if (map.IsOccupied(X, Y))
            {
                // ACTION
            }
        }
    }
}
