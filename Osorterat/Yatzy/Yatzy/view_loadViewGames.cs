using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{
    class view_loadViewGames
    {
        private int selectViewMenuIndex = 0;

        private List<model_game> games = new List<model_game>();
        private model_game game;
        private bool playRequest = false;
        private int viewSelected = 0;

        public List<model_game> Games
        {
            set { games = value; }
        }

        public model_game Game
        {
            get { return game; }
        }

        public bool PlayRequest
        {
            get { return playRequest; }
        }

        public int ViewSelected
        {
            get { return viewSelected; }
        }

        public view_loadViewGames()
        {
        }

        public void gameList()
        {
            Console.Clear();
            Console.WriteLine("Select game and press T to see tables of the players for each game.");
            Console.WriteLine("Press enter to continue playing unfinished game.");
            Console.WriteLine("===============================================================================");
            Console.WriteLine();
            List<string> players = new List<string>();
            for (int ib = 0; ib < games.Count; ib++)
            {
                string finished = "";
                if (games[ib].Finished == true)
                {
                    finished = ", finished";
                }
                else
                {
                    finished = ", not finished";
                }

                if (ib == selectViewMenuIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.Write(games[ib].Date + " (" + games[ib].GameType + finished + ")" + ": ");

                for (int i = 0; i < games[ib].Players.Count; i++)
                {
                    if (i == (games[ib].Players.Count - 1))
                    {
                        Console.Write(games[ib].Players[i].Name.ToString() + " (" + games[ib].Players[i].Column.TotalScore + " points)" + ".");
                    }
                    else if (i == (games[ib].Players.Count - 2))
                    {
                        Console.Write(games[ib].Players[i].Name.ToString() + " (" + games[ib].Players[i].Column.TotalScore + " points)" + " and ");
                    }
                    else
                    {
                        Console.Write(games[ib].Players[i].Name.ToString() + " (" + games[ib].Players[i].Column.TotalScore + " points)" + ", ");
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
        }

        public void getUserInputViewMenu()
        {
            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.Enter)
            {
                playRequest = true;
                game = games[selectViewMenuIndex];
            }

            else if (input.Key == ConsoleKey.T)
            {
                game = games[selectViewMenuIndex];
                viewSelected = 1;
            }

            else if (input.Key == ConsoleKey.DownArrow)
            {
                if (selectViewMenuIndex == (games.Count - 1))
                {
                    selectViewMenuIndex = 0;
                }
                else
                {
                    selectViewMenuIndex++;
                }
            }

            else if (input.Key == ConsoleKey.UpArrow)
            {
                if (selectViewMenuIndex == 0)
                {
                    selectViewMenuIndex = games.Count - 1;
                }
                else
                {
                    selectViewMenuIndex--;
                }
            }
        }

        public void viewTables()
        {
            model_player lastPlayer = game.Players.Last();
            foreach (model_player player in game.Players)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                viewTable(player);
                Console.ReadKey();
            }
            viewSelected = 0;
        }

        public void viewTable(model_player player)
        {
            Console.Clear();
            Console.WriteLine("Table of " + player.Name);
            Console.WriteLine();

            foreach (model_category ca in player.Column.Categories)
            {
                Console.WriteLine(ca.Title + ": " + ca.Score);
            }

            Console.WriteLine();
            Console.WriteLine("Total score: " + player.Column.TotalScore.ToString());
            Console.WriteLine();
            Console.WriteLine("Press enter...");
        }

    }
}
