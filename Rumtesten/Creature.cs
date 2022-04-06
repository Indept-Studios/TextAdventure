using System;

namespace TextAdventure
{
    [Serializable]
    abstract class Creature
    {
        public abstract int X { get; set; }
        public abstract int Y { get; set; }
        public abstract string Name { get; set; }
        public abstract int  ID { get; set; }
        public abstract string Marker { get; set; }
        public abstract int Coins { get; set; }
        public abstract int Health { get; set; }
        public abstract int Damage { get; set; }
        public abstract int ArmorValue { get; set; }
        public abstract int WeaponValue { get; set; }
        public abstract int Level { get; set; }
        public abstract int XP { get; set; }
        public abstract int Potions { get; set; }
        public abstract int Difficulty { get; set; }

    }
}
