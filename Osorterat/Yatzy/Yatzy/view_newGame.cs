using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Yatzy
{
    class view_newGame
    {
        private model_gameType gameType = new model_gameType();
        private List<model_player> players = new List<model_player>();

        public model_gameType GameType
        {
            get { return gameType; }
        }

        public List<model_player> Players
        {
            get { return players; }
        }
        
        public view_newGame()
        {
        }

        public void selectGameType()
        {
            bool gameSelected = false;
            do
            {
                Console.Clear();
                Console.WriteLine(DateTime.Today.ToShortDateString());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Select game");
                Console.WriteLine("1. Yathzee");
                Console.WriteLine("2. Maxi-Yahtzee");
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.D1)
                {
                    gameType = model_gameType.Yahtzee;
                    gameSelected = true;
                }

                else if (input.Key == ConsoleKey.D2)
                {
                    gameType = model_gameType.MaxiYahtzee;
                    gameSelected = true;
                }

            } while (gameSelected == false);

        }

        public void getPlayers()
        {
            int numberOfPlayers = 0;

            // Get number of players
            bool inputNumberOfPlayer = false;
            do
            {
                Console.Clear();
                Console.Write("How many players? (1-5)");
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.D1)
                {
                    numberOfPlayers = 1;
                    inputNumberOfPlayer = true;
                }
                else if (input.Key == ConsoleKey.D2)
                {
                    numberOfPlayers = 2;
                    inputNumberOfPlayer = true;
                }
                else if (input.Key == ConsoleKey.D3)
                {
                    numberOfPlayers = 3;
                    inputNumberOfPlayer = true;
                }
                else if (input.Key == ConsoleKey.D4)
                {
                    numberOfPlayers = 4;
                    inputNumberOfPlayer = true;
                }
                else if (input.Key == ConsoleKey.D5)
                {
                    numberOfPlayers = 5;
                    inputNumberOfPlayer = true;
                }
                else
                {
                    inputNumberOfPlayer = false;
                }

            } while (inputNumberOfPlayer == false);

            if (numberOfPlayers == 1)
            {
                model_player player = new model_player();
                model_column column = new model_column();
                player.Column = column;
                player.PlayerType = model_playerType.computer;
                player.Name = "Computer";
                players.Add(player);
            }

            // Get players names and types
            for (int i = 0; i < numberOfPlayers; i++)
            {
                model_player player = new model_player();
                model_column column = new model_column();
                player.Column = column;
                bool correctNameInput = false;
                do
                {
                    Console.Clear();
                    Console.Write("Name of player " + (i + 1) + ": ");
                    string name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Please type a name of player!");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        player.Name = name;
                        correctNameInput = true;
                    }
                } while (correctNameInput == false);

                bool correctPlayerTypeInput = false;
                do
                {
                    Console.Clear();
                    if (numberOfPlayers > 1)
                    {
                        Console.Write("Is " + player.Name + " a person or computer? (p/c)");
                        ConsoleKeyInfo input = Console.ReadKey(true);

                        if (input.Key == ConsoleKey.P)
                        {
                            player.PlayerType = model_playerType.person;
                            correctPlayerTypeInput = true;
                        }
                        else if (input.Key == ConsoleKey.C)
                        {
                            player.PlayerType = model_playerType.computer;
                            correctPlayerTypeInput = true;
                        }
                        else
                        {
                            correctPlayerTypeInput = false;
                        }
                    }
                    else
                    {
                        correctPlayerTypeInput = true;
                    }
                } while (correctPlayerTypeInput == false);

                players.Add(player);
            }

            if (players.Count == 2)
            {
                players.Reverse();
            }   
        }       

    }
}
