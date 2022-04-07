using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Monster : Creature
    {
        public override int X { get; set; }
        public override int Y { get; set; }
        public override string Name { get; set; }
        public override int ID { get; set; }
        public override string Marker { get; set; } 
        public override int Coins { get; set; }
        public override int Health { get; set; }
        public override int Damage { get; set; } 
        public override int ArmorValue { get; set; } 
        public override int WeaponValue { get; set; } 
        public override int Level { get; set; } 
        public override int XP { get; set; }
        public override int Potions { get; set; } 
        public override int Difficulty { get; set; }

        public Monster()
        {
            Name = GetName();
        }

        private string GetName()
        {
            switch (Game.rnd.Next(0, 4))
            {
                case 0:
                    return "Skeleton";
                case 1:
                    return "Zombie";
                case 2:
                    return "Human Cultist";
                case 3:
                    return "Grave Robber";
            }
            return "Human Rouge";
        }

        /// <summary>
        /// Set a random potion value
        /// </summary>
        /// <returns></returns>
        public int SetPotionValue()
        {
            return Game.rnd.Next(0, 2);
        }

        /// <summary>
        /// Set a random health value, depending on the difficulty
        /// </summary>
        /// <returns></returns>
        public int SetHealthValue()
        {
            int upper = (2 * Game.Difficulty + 10);   //12,20,30
            int lower = (Game.Difficulty + 2);       //2,7,12
            return Game.rnd.Next(lower, upper);
        }

        /// <summary>
        /// Set a random power value, depending on the difficulty
        /// </summary>
        /// <returns></returns>
        public int SetDamageValue()
        {
            int upper = (2 * Game.Difficulty + 2);   //4,12,22
            int lower = (Game.Difficulty + 1);       //2,6,11
            return Game.rnd.Next(lower, upper);
        }

        /// <summary>
        /// Set a random coin value, depending on the difficulty
        /// </summary>
        /// <returns></returns>
        /// <THINKING>Easy = more Coins, hard = less Coins</THINKING>
        public int SetCoinsValue()
        {
            int upper = ((15 * Game.Difficulty + 50) / Game.Difficulty); //65,25,20
            int lower = ((10 * Game.Difficulty + 10) / Game.Difficulty); //20,30,11
            return Game.rnd.Next(lower, upper);
        }

        /// <summary>
        /// Get a random xp value, depending on player level
        /// </summary>
        /// <returns></returns>
        public int SetXPValue()
        {
            int upper = (6 * Game.CurrentPlayer.Level);
            int lower = (1 * Game.CurrentPlayer.Level);
            return Game.rnd.Next(lower, upper);
        }
    }
}
