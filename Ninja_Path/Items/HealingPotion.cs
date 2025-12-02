using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja_Path.Items
{
    public class HealingPotion : Item
    {
        public int HealAmount { get;}
        public int Cooldown { get; }

        public HealingPotion(string name, int healAmount, int cooldown)
        {
            Name = name;
            HealAmount = healAmount;
            Cooldown = cooldown;
        }
    }
}
