using Ninja_Path.Enemy;
using Ninja_Path.Items;
using System.Runtime.CompilerServices;

namespace Ninja_Path
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayLogo();

            int action;
            while (true)
            {
                Console.WriteLine("1. Start Game");
                Console.WriteLine("2. Load Game");
                Console.WriteLine("3. Quit Game");
                string input = Console.ReadLine();

                if (int.TryParse(input, out action) && action >= 1 && action <= 3)
                    break;

                Console.WriteLine("Invalid input! Enter 1, 2 or 3.");
            }
            MainMenuOptions(action);
        }

        public static void MainMenuOptions(int action)
        {
            switch(action)
            {
                case 1:
                    StartNewGame();
                    break;
                case 2:
                    Console.WriteLine("No game file to load");
                    break;
                case 3:
                    QuitGame();
                    break;
            }
        }

        private static void StartNewGame()
        {
            Console.Clear();
            var player = new Player(
                "Ninja",
                100,
                ItemFactory.Katana(),
                ItemFactory.smallPotion()
                );

            var combat = new CombatSystem();
            while (true)
            {
                var enemy = EnemyFactory.CreateBasicBandit();
                combat.StartFight(player, enemy);

                Console.WriteLine("Play Again t/n");
                if (Console.ReadLine().ToLower() != "t")
                    break;

                player.Health = player.MaxHealth;
            }
        }

        private static void QuitGame()
        {
            System.Environment.Exit(0);
        }

        private static void DisplayLogo()
        {
            Console.WriteLine(" /$$   /$$ /$$                               /$$$$$$$             /$$     /$$      \r\n" +
                              "| $$$ | $$|__/                              | $$__  $$           | $$    | $$      \r\n" +
                              "| $$$$| $$ /$$ /$$$$$$$  /$$  /$$$$$$       | $$  \\ $$ /$$$$$$  /$$$$$$  | $$$$$$$ \r\n" +
                              "| $$ $$ $$| $$| $$__  $$|__/ |____  $$      | $$$$$$$/|____  $$|_  $$_/  | $$__  $$\r\n" +
                              "| $$  $$$$| $$| $$  \\ $$ /$$  /$$$$$$$      | $$____/  /$$$$$$$  | $$    | $$  \\ $$\r\n" +
                              "| $$\\  $$$| $$| $$  | $$| $$ /$$__  $$      | $$      /$$__  $$  | $$ /$$| $$  | $$\r\n" +
                              "| $$ \\  $$| $$| $$  | $$| $$|  $$$$$$$      | $$     |  $$$$$$$  |  $$$$/| $$  | $$\r\n" +
                              "|__/  \\__/|__/|__/  |__/| $$ \\_______/      |__/      \\_______/   \\___/  |__/  |__/\r\n" +
                              "                   /$$  | $$                                                       \r\n" +
                              "                  |  $$$$$$/                                                       \r\n" +
                              "                   \\______/" +
                              "\n");
        }
    }
}
