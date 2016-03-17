using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Yatzy
{
    class Program
    {
        static void Main(string[] args)
        {
            controller c = new controller();
            c.start();
        }
    }
}

/*            
            
            
            
            //Spelet

bool won = false;
do
{


    foreach (model_player player in players)
    {

        // Skapa en runda
        model_turn turn = new model_turn(numberOfDice);

        
        // Tärningsset
        List<model_die> dice = new List<model_die>();
        
        // Skapa tärningarna och lägg in i tärningsset
        for (int i = 0; i < numberOfDice; i++)
        {
            model_die die = new model_die();
            dice.Add(die);
        }

        // Skapa regler
        Imodel_rules rules = new model_rules_yahtzee();
        rules.LoadCategories();

        // View- och menyrelaterat
        int menuSelectDiceListIndex = 0;
        int menuSelectCategoryListIndex = 0;
        int menuSelected = 0;
        bool scored = false;

        // Loopa rundan tills den är slut
        do
        {
            Console.Clear();
            if (turn.NumberOfThrowsLeft == 3)
            {
                Console.WriteLine("Get ready " + player.Name + "!");
                Console.WriteLine("This will be your first roll in this round!");
                Console.WriteLine("Press any key to roll dice");
                Console.ReadKey();
                
                
                
                turn.Throw(dice);
            }


            else if (turn.NumberOfThrowsLeft < 3)
            {
                List<model_die> menuSelectDiceList = new List<model_die>();
                List<model_category> menuSelectCategoryList = new List<model_category>();
                foreach (model_die die in dice)
                {
                    menuSelectDiceList.Add(die);
                }

                rules.CheckPossibleCategories(turn.DiceSet);
                
                foreach (model_category category in rules.Categories)
                {
                    if (category.Score != 0 && player.Column.Categories[category.Id - 1].Score == 0)
                    {
                        menuSelectCategoryList.Add(category);
                    }
                }

                Console.WriteLine("Dice");
                Console.WriteLine("Use arrow keys and press enter to select die or dice");
                Console.WriteLine("to hold for next roll. Yellow means it will be hold.");
                Console.WriteLine("Press tab to switch to category selection.");
                Console.WriteLine("==========================================================");

                for (int i = 0; i < menuSelectDiceList.Count; i++)
                {
                    if (menuSelectDiceList[i].Hold == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    if (i == menuSelectDiceListIndex && menuSelected == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine("Die " + (i + 1) + ": " + turn.DiceSet[i] + " " + dice[i].Hold);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine();
                Console.WriteLine("Categories");
                Console.WriteLine("Use arrow keys and press enter to select possible");
                Console.WriteLine("categories to score in your table.");
                Console.WriteLine("Press tab to switch to dice selection.");
                Console.WriteLine("=============================================================");

                if (!menuSelectCategoryList.Any())
                {
                    Console.WriteLine("No categories match the given combination of dice!");
                }
                else
                {
                    for (int i = 0; i < menuSelectCategoryList.Count; i++)
                    {
                        if (i == menuSelectCategoryListIndex && menuSelected == 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        Console.WriteLine(menuSelectCategoryList[i].Title + ": " + menuSelectCategoryList[i].Score);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Press (s) to save game");

                if (turn.NumberOfThrowsLeft > 0)
                {
                    Console.WriteLine("Press (r) to roll dice. Yellow marked dice will not be rolled again.");
                    Console.WriteLine("Rolls left in this round: " + turn.NumberOfThrowsLeft);
                }
                
                else if (turn.NumberOfThrowsLeft == 0)
                {
                    if (!menuSelectCategoryList.Any())
                    {
                        Console.WriteLine("You have no rolls left and no categories to score with the given combination of dice!");
                        Console.WriteLine("You will score 0 in this round!");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You have no rolls left. You have to select one of the given categories.");
                    }

                }    
                
                ConsoleKeyInfo input = Console.ReadKey(true);
                int sizeOfMenu = menuSelectDiceList.Count + menuSelectCategoryList.Count;
                // Trycker enter
                if (input.Key == ConsoleKey.Enter)
                {

                    if (menuSelected == 0)
                    {
                        if (dice[menuSelectDiceListIndex].Hold == true)
                        {
                            dice[menuSelectDiceListIndex].Hold = false;
                        }
                        else
                        {
                            dice[menuSelectDiceListIndex].Hold = true;
                        }
                    }

                    else if (menuSelected == 1)
                    {
                        int id = menuSelectCategoryList[menuSelectCategoryListIndex].Id;
                        int score = menuSelectCategoryList[menuSelectCategoryListIndex].Score;
                        player.Column.Categories[id - 1].Score = score;
                        scored = true;
                        turn.Finished = true;
                    }
                }

                else if (input.Key == ConsoleKey.Tab)
                {
                    if (menuSelected == 0)
                    {
                        menuSelected = 1;
                    }
                    else
                    {
                        menuSelected = 0;
                    }
                }

                // Trycker pil nedåt
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

                // Trycker pil uppåt
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

                // Trycker R
                else if (input.Key == ConsoleKey.R)
                {
                    if (turn.NumberOfThrowsLeft > 0)
                    {
                        turn.Throw(dice);
                    }
                }

            }

        } while (turn.Finished == false || scored == false);

        rules.Bonus(player.Column);
        Console.Clear();
        Console.WriteLine("Table of " + player.Name);
        Console.WriteLine();

        foreach (model_category ca in player.Column.Categories)
        {
            Console.WriteLine(ca.Title + ": " + ca.Score);
        }

        Console.WriteLine();

        Console.WriteLine("Press any key for next players round...");
        Console.ReadKey();
    } //Foreach player slut




} while (won == false);
Console.Clear();
Console.WriteLine("Congratulations!!!");
            
        }   
    }
}
    */