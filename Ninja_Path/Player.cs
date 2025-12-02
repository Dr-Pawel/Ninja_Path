using Ninja_Path.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja_Path
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Level { get; set; }

        public Weapon Weapon { get; set; }
        public HealingPotion Potion { get; set; }

        public int PotionCooldownLeft { get; set; }

        public Player(string name, int maxHealth, Weapon weapon, HealingPotion potion)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            Weapon = weapon;
            Potion = potion;
        }

        public int Attack() => Weapon.RollDamage();

        public bool CanUsePotion() => PotionCooldownLeft == 0;

        public int UseHealingPotion()
        {
            if(!CanUsePotion())
            {
                return -1;
            }
            Health = Math.Min(MaxHealth, Health + Potion.HealAmount);
            PotionCooldownLeft = Potion.Cooldown;
            return Potion.HealAmount;
        }

        public void TickCooldown()
        {
            if (PotionCooldownLeft > 0)
                PotionCooldownLeft--;
        }

    }
}
