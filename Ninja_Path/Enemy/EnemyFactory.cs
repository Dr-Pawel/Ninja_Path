using Ninja_Path.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja_Path.Enemy
{
    public class EnemyFactory
    {
        public static Enemy CreateBasicBandit()
        {
            return new Enemy(
                name: "Bandit",
                maxHealth: 30,
                weapon: ItemFactory.Kunai()
            );
        }
    }
}
