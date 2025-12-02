using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja_Path.Items
{
    public class ItemFactory
    {
        public static Weapon ōdachi() => new Weapon("ōdachi", 12, 15);
        public static Weapon Katana() => new Weapon("Katana", 8, 12);
        public static Weapon Tanto() => new Weapon("Tanto", 5, 8);
        public static Weapon Kunai() => new Weapon("Katana", 3, 5);
        public static HealingPotion smallPotion() => new HealingPotion("Small Potion", 20, 3);
    }
}
