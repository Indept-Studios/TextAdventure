using System;

namespace TextAdventure
{
    [Serializable]
    public class Creature
    {
        public string name;
        public int id;
        public int coins = 0;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 5;
        public int weaponValue = 1;
        public int difficulty = 0;


        /// <summary>
        /// Get a random health value, depending on the difficulty
        /// </summary>
        /// <returns></returns>
        public int GetHealth()
        {
            int upper = (2 * difficulty + 5);
            int lower = (difficulty + 2);
            return Program.rnd.Next(lower, upper);
        }

        /// <summary>
        /// Get a random power value, depending on the difficulty
        /// </summary>
        /// <returns></returns>
        public int GetPower()
        {
            int upper = (2 * difficulty + 2);
            int lower = (difficulty + 2);
            return Program.rnd.Next(lower, upper);
        }

        /// <summary>
        /// Get a random coin value, depending on the difficulty
        /// </summary>
        /// <returns></returns>
        public int GetCoins()
        {
            int upper = (15 * difficulty + 50);
            int lower = (10 * difficulty + 10);
            return Program.rnd.Next(lower, upper);
        }
    }
}
