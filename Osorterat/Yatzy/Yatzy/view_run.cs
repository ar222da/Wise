using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yatzy
{
    class view_run
    {
        private model_player player;
        private Imodel_rules rules;
        private model_turn turn;

        private List<model_die> menuSelectDiceList = new List<model_die>();
        private int menuSelectDiceListIndex = 0;
        private List<model_category> menuSelectCategoryList = new List<model_category>();
        private int menuSelectCategoryListIndex = 0;
        private int menuSelected = 0;

        private int viewSelected = 0;

        private bool userConfirmedTurnFinished = false;
        private model_category selectedScoredCategory = new model_category();

        public model_player Player
        {
            set { player = value; }
        }

        public Imodel_rules Rules
        {
            set { rules = value; }
        }

        public model_turn Turn
        {
            set { turn = value; }
        }

        public int ViewSelected
        {
            get { return viewSelected; }
        }

        public bool UserConfirmedTurnFinished
        {
            get { return userConfirmedTurnFinished; }
        }

        public model_category SelectedScoredCategory
        {
            get { return selectedScoredCategory; }
        }
        
        public view_run(model_player player, Imodel_rules rules, model_turn turn)
        {
            Player = player;
            Rules = rules;
            Turn = turn;
        }

        public void viewGameAction()
        {
            Console.Clear();

            // If it is the first roll of the round
            if (turn.NumberOfThrowsLeft == 3)
            {
                Console.WriteLine("Get ready " + player.Name + "!");
                Console.WriteLine("This will be your first roll in this round!");
                if (player.PlayerType == model_playerType.computer)
                {
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("Press any key to roll dice");
                    Console.ReadKey();
                }
                turn.throwDice();
                menuSelectDiceListIndex = 0;
                menuSelectCategoryListIndex = 0;
            }

            // Check which categories is possible with the combination of dice
            // given after roll, according to the rules of the game
            rules.checkPossibleCategories(turn.Dice);

            // Fill menu lists 1: Dice
            menuSelectDiceList.Clear();
            foreach (model_die die in turn.Dice)
            {
                menuSelectDiceList.Add(die);
            }

            // Fill menu list 2: Possible categories of the combination of dice
            menuSelectCategoryList.Clear();
            foreach (model_category category in rules.Categories)
            {
                if (category.Score != 0 && player.Column.Categories[category.Id].Score == 0)
                {
                    menuSelectCategoryList.Add(category);
                }
            }

            // Write the menu
            Console.Clear();
            Console.Write("Player: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(player.Name);
            Console.ForegroundColor = ConsoleColor.White;
            
            if (player.PlayerType == model_playerType.person)
            {
                Console.WriteLine("Use arrow keys and press enter to select die or dice to hold for next roll.");
                Console.WriteLine("Yellow means it will be hold. Press enter to select category.");
                Console.Write("Press ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("TAB");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" to switch between dice and category selection.");
            }
            Console.Write("================================================================================");

            for (int i = 0; i < menuSelectDiceList.Count; i++)
            {
                if (menuSelectDiceList[i].Hold == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (i == menuSelectDiceListIndex && menuSelected == 0 && player.PlayerType == model_playerType.person)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }

                Console.WriteLine("Die " + (i + 1) + ": " + turn.Dice[i].FaceValue);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            Console.Write("================================================================================");
            if (!menuSelectCategoryList.Any())
            {
                Console.WriteLine("No categories match the given combination of dice!");
            }
            else
            {
                for (int i = 0; i < menuSelectCategoryList.Count; i++)
                {
                    if (i == menuSelectCategoryListIndex && menuSelected == 1 && player.PlayerType == model_playerType.person)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine(menuSelectCategoryList[i].Title + ": " + menuSelectCategoryList[i].Score);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
            Console.Write("================================================================================");
            if (player.PlayerType == model_playerType.person)
            {
                Console.Write("Press ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("S");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" to save game.");
                Console.Write("Press ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("T");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" to see table of ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(player.Name);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Press ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("M");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" to get back to menu.");
            }            
            
            if (turn.NumberOfThrowsLeft > 0 && player.PlayerType == model_playerType.person)
            {
                Console.Write("Press ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("R");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" to roll dice. Yellow marked dice will not be rolled again.");
                Console.Write("Rolls left in this round: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(turn.NumberOfThrowsLeft);
                Console.ForegroundColor = ConsoleColor.White;
            }

            else if (turn.NumberOfThrowsLeft == 0 && player.PlayerType == model_playerType.person)
            {
                if (!menuSelectCategoryList.Any())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You have no rolls left and no categories to score with the given combination of dice!");
                    Console.WriteLine("You will score 0 in this round!");
                    Console.ForegroundColor = ConsoleColor.White;
                    userConfirmedTurnFinished = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You have no rolls left. You have to select one of the given categories.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public void viewTable()
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
            if (player.PlayerType == model_playerType.person)
            {
                Console.WriteLine("Press enter...");
            }
        }

        public void saveMessage()
        {
            Console.Clear();
            Console.WriteLine("The game has been saved!");
            Console.WriteLine("Press enter to continue game...");
        }

        public void getUserInput()
        {
            ConsoleKeyInfo input = Console.ReadKey(true);

            if (viewSelected == 0)
            {
                if (input.Key == ConsoleKey.Enter)
                {
                    if (menuSelected == 0 && turn.NumberOfThrowsLeft > 0)
                    {
                        if (turn.Dice[menuSelectDiceListIndex].Hold == true)
                        {
                            turn.Dice[menuSelectDiceListIndex].Hold = false;
                        }
                        else
                        {
                            turn.Dice[menuSelectDiceListIndex].Hold = true;
                        }
                    }

                    else if (menuSelected == 1)
                    {
                        selectedScoredCategory = menuSelectCategoryList[menuSelectCategoryListIndex];
                        userConfirmedTurnFinished = true;
                    }
                }


                else if (input.Key == ConsoleKey.Tab)
                {
                    if (menuSelected == 0)
                    {
                        menuSelected = 1;
                        menuSelectCategoryListIndex = 0;
                    }
                    else
                    {
                        menuSelected = 0;
                        menuSelectDiceListIndex = 0;
                    }
                }

                // Arrow down
                else if (input.Key == ConsoleKey.DownArrow)
                {
                    if (menuSelected == 0)
                    {
                        if (menuSelectDiceListIndex < (menuSelectDiceList.Count - 1))
                        {
                            menuSelectDiceListIndex++;
                        }
                        else
                        {
                            menuSelectDiceListIndex = 0;
                        }
                    }

                    if (menuSelected == 1)
                    {
                        if (menuSelectCategoryListIndex < (menuSelectCategoryList.Count - 1))
                        {
                            menuSelectCategoryListIndex++;
                        }
                        else
                        {
                            menuSelectCategoryListIndex = 0;
                        }
                    }
                }

                // Arrow up
                else if (input.Key == ConsoleKey.UpArrow)
                {
                    if (menuSelected == 0)
                    {
                        if (menuSelectDiceListIndex > 0)
                        {
                            menuSelectDiceListIndex--;
                        }
                        else
                        {
                            menuSelectDiceListIndex = menuSelectDiceList.Count - 1;
                        }
                    }

                    if (menuSelected == 1)
                    {
                        if (menuSelectCategoryListIndex > 0)
                        {
                            menuSelectCategoryListIndex--;
                        }
                        else
                        {
                            menuSelectCategoryListIndex = menuSelectCategoryList.Count - 1;
                        }
                    }
                }

                // Roll
                else if (input.Key == ConsoleKey.R)
                {
                    if (turn.NumberOfThrowsLeft > 0)
                    {
                        turn.throwDice();
                    }
                }


                // Change view to table view
                else if (input.Key == ConsoleKey.T)
                {
                    viewSelected = 1;
                }

                // Save game
                else if (input.Key == ConsoleKey.S)
                {
                    viewSelected = 2;
                }

                // Back to menu
                else if (input.Key == ConsoleKey.M)
                {
                    viewSelected = 3;
                }
            }

            else if (viewSelected == 1 || viewSelected == 2)
            {
                if (input.Key == ConsoleKey.Enter)
                {
                    viewSelected = 0;
                }
            }
        }
        
    }
}
