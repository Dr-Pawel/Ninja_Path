using Ninja_Path.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninja_Path
{
    public class CombatSystem
    {
        public void StartFight(Player player, Enemy.Enemy enemy)
        {
            while (player.Health > 0 && enemy.Health > 0)
            {
                Console.Clear();
                DisplayStatus(player, enemy);

                Console.WriteLine("Choose Action:");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use Potion");
                Console.WriteLine("3. skip turn");

                int action;

                while (true)
                {
                    Console.Write("Action: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out action) && action >= 1 && action <= 3)
                        break;

                    Console.WriteLine("Invalid input! Enter 1, 2 or 3.");
                }

                //Player Turn
                PlayerAction(action, player, enemy);
                if (enemy.Health <= 0)
                    break;

                //Enemy Turn
                int enemyDmg = enemy.Attack();
                player.Health -= enemyDmg;
                Console.WriteLine($"{enemy.Name} hits {player.Name} for {enemyDmg} damage!");
                Thread.Sleep(1000);
            }

            Console.WriteLine(player.Health <= 0
                ? $"{player.Name} died!"
                :$"{enemy.Name} was defeated!");
        }

        private void PlayerAction(int action, Player player, Enemy.Enemy enemy)
        {
            switch (action)
            {
                case 1:
                    int dmg = player.Attack();
                    enemy.Health -= dmg;
                    Console.WriteLine($"{player.Name} deals {dmg} damage!");
                    break;
                case 2:
                    player.UseHealingPotion();
                    Console.WriteLine($"{player.Name} uses {player.Potion}");
                    break;
                case 3:
                    Console.WriteLine($"{player.Name} skips the turn");
                    break;
            }
        }

        private void DisplayStatus(Player p, Enemy.Enemy e)
        {
            Console.WriteLine($"--- {p.Name} --- HP: {p.Health}/{p.MaxHealth} (CD: {p.PotionCooldownLeft})");
            Console.WriteLine($"--- {e.Name} --- HP: {e.Health}/{e.MaxHealth}");
            Console.WriteLine();
        }
    }
}
