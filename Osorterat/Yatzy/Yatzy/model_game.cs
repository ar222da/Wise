using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Yatzy
{
    class model_game
    {
        private string date;
        private model_gameType gameType;
        private Imodel_rules rules;
        private List<model_player> players = new List<model_player>();
        private model_turn turn;
        private int sequenceNumber = 0;
        
        private bool finished = false;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public model_gameType GameType
        {
            get { return gameType; }
            set { gameType = value; }
        }

        public Imodel_rules Rules
        {
            get { return rules; }
            set { rules = value; }
        }

        public List<model_player> Players
        {
            get { return players; }
            set { players = value; }
        }

        public model_turn Turn
        {
            get { return turn; }
        }

        public int SequenceNumber
        {
            get { return sequenceNumber; }
            set { sequenceNumber = value; }
        }

        public bool Finished
        {
            get
            {
                foreach (model_player player in players)
                {
                    if (player.Column.Finished == false)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public model_game()
        {
        }

        public void setRules()
        {
            if (gameType == model_gameType.Yahtzee)
            {
                rules = new model_rules_yahtzee();
            }

            else
            {
                rules = new model_rules_maxiYahtzee();
            }
            
            Rules.loadCategories();
        }

        public void setColumns()
        {
            foreach (model_player player in players)
            {
                player.Column = rules.getColumn();
            }
        }

        public void setTurn()
        {
            turn = new model_turn(rules.NumberOfDice);
        }

        public void saveGame(int saveType)
        {
            string fileName = "";
            if (saveType == 1)
            {
                using (StreamReader reader = new StreamReader("files.txt"))
                {
                    fileName = reader.ReadLine();
                    int temp = int.Parse(fileName);
                    temp++;
                    fileName = temp.ToString();
                }
            }
            
            else if (saveType == 0)
            {
                fileName = "restored";
                FileStream f = File.Open(fileName + ".txt", FileMode.Create);
                f.Close();               
            }

            using (var writer = new StreamWriter(fileName + ".gam"))
            {
                writer.WriteLine(DateTime.Today.ToShortDateString());
                writer.WriteLine(gameType);
  
                foreach (model_die die in turn.Dice)
                {
                    writer.Write(die.FaceValue + ":");
                }
                writer.WriteLine();
                foreach (model_die die in turn.Dice)
                {
                    writer.Write(die.Hold + ":");
                }
                writer.WriteLine();
                writer.WriteLine(sequenceNumber);
                writer.WriteLine(turn.NumberOfThrowsLeft);
                
                writer.WriteLine(players.Count);

                foreach (model_player player in players)
                {
                    writer.Write(player.PlayerType + ":");
                    writer.Write(player.Name + ":");
                    foreach (model_category category in player.Column.Categories)
                    {
                        writer.Write(category.Score + ":");
                    }
                    writer.WriteLine();
                }
            }

            if (saveType == 1)
            {
                using (StreamWriter writer = new StreamWriter("files.txt"))
                {
                    writer.Write(fileName);
                }
            }
        }

        public void loadGame(int fileId, int loadType)
        {
            string fileName = "";
            // Filnamnet där senaste oavslutade spel sparats
            if (loadType == 0)
            {
                fileName = "restored";
            }
            // Annars är filnamnet ett indexnummer (ökas för varje gång ett spel sparas, användare ser aldrig filnamn)
            else if (loadType == 1)
            {
                fileName = fileId.ToString();
            }
            // Läs in hela filinnehållet rad för rad i en lista
            List<string> list = new List<string>();
            using (StreamReader reader = new StreamReader(fileName + ".gam"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            gameType = (model_gameType)Enum.Parse(typeof(model_gameType), list[1]);
            // Skapa ett nytt regelobjekt
            // Avgör beroende på strängen i filen vilken speltyp det är, och sätt regelobjektet efter detta
            if (gameType == model_gameType.Yahtzee)
            {
                rules = new model_rules_yahtzee();
            }

            else
            {
                rules = new model_rules_maxiYahtzee();
            }

            // Läs in de kategorier som hör till aktuell speltyp
            rules.loadCategories();
            // Antalet spelare
            int numberOfPlayers = int.Parse(list[6]);
            for (int i = 0; i < numberOfPlayers; i++)
            {
                string[] playersStringArray = list[7 + i].Split(':');
                model_player player = new model_player();
                player.PlayerType = (model_playerType)Enum.Parse(typeof(model_playerType), playersStringArray[0]);
                player.Name = playersStringArray[1];
                players.Add(player);
            }
            setColumns();
            // När spelobjektet skapas läses tomma tabeller (columns) automatiskt i konstruktorn in från regelverket 
            // Här fylls de för varje spelare på med poäng som finns sparat i filen
            for (int i = 0; i < players.Count; i++)
            {
                string[] stringArray = list[7 + i].Split(':');
                for (int ib = 0; ib < Rules.Categories.Count; ib++)
                {
                    players[i].Column.Categories[ib].Score = int.Parse(stringArray[2 + ib]);
                }
            }
            // Spelets datum
            string Date = list[0];
            date = Date;
            setTurn();
            // Tärningarnas värden när spelet sparades
            string[] diceFaceValues;
            diceFaceValues = list[2].Split(':');
            // Om tärningen är vald att behållas för nästa kast
            string[] diceHold;
            diceHold = list[3].Split(':');

            for (int i = 0; i < Rules.NumberOfDice; i++)
            {
                Turn.Dice[i].FaceValue = int.Parse(diceFaceValues[i]);
                Turn.Dice[i].Hold = bool.Parse(diceHold[i]);
            }
            // Vilken spelares tur det var när spelet sparades
            SequenceNumber = int.Parse(list[4]);
            // Antalet kast kvar för spelaren när spelet sparades
            Turn.NumberOfThrowsLeft = int.Parse(list[5]);
        }

        public void run()
        {
            do
            {

                if (Players[SequenceNumber].Column.Finished == false)
                {

                    if (Players[SequenceNumber].PlayerType == model_playerType.person)
                    {
                        view_run view_run = new view_run(Players[SequenceNumber], Rules, Turn);

                        do
                        {
                            if (view_run.ViewSelected == 0)
                            {
                                view_run.viewGameAction();
                            }
                            else if (view_run.ViewSelected == 1)
                            {
                                view_run.viewTable();
                            }
                            else if (view_run.ViewSelected == 2)
                            {
                                saveGame(1);
                                view_run.saveMessage();
                            }
                            else if (view_run.ViewSelected == 3)
                            {
                                return;
                            }
                            saveGame(0);
                            view_run.getUserInput();

                        } while (view_run.UserConfirmedTurnFinished == false);

                        if (view_run.SelectedScoredCategory != null)
                        {
                            Players[SequenceNumber].Column.Categories[view_run.SelectedScoredCategory.Id].Score = view_run.SelectedScoredCategory.Score;
                        }
                    }

                    else if (Players[SequenceNumber].PlayerType == model_playerType.computer)
                    {
                        view_run view_run = new view_run(Players[SequenceNumber], Rules, Turn);
                        bool finished = false;

                        do
                        {
                            view_run.viewGameAction();
                            System.Threading.Thread.Sleep(2000);
                            int categoryId = getNonScoredCategoryId(Players[SequenceNumber]);
                            do
                            {
                                selectDice(categoryId);
                                Turn.throwDice();
                                view_run.viewGameAction();
                                System.Threading.Thread.Sleep(2000);

                            } while (Turn.NumberOfThrowsLeft == 0);

                            if (Rules.Categories[categoryId].Score != 0)
                            {
                                Players[SequenceNumber].Column.Categories[categoryId].Score = Rules.Categories[categoryId].Score;
                                view_run.viewGameAction();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(Players[SequenceNumber].Name + " selected " + Players[SequenceNumber].Column.Categories[categoryId].Title + ".");
                                Console.ForegroundColor = ConsoleColor.White;
                                System.Threading.Thread.Sleep(2000);
                                view_run.viewTable();
                                System.Threading.Thread.Sleep(2000);
                                finished = true;
                            }
                            else
                            {
                                List<model_category> otherCategories = new List<model_category>();
                                foreach (model_category category in Rules.Categories)
                                {
                                    if (category.Score != 0 && Players[SequenceNumber].Column.Categories[category.Id].Score == 0)
                                    {
                                        otherCategories.Add(category);
                                    }
                                }

                                if (otherCategories.Count != 0)
                                {
                                    otherCategories = otherCategories.OrderBy(x => x.Score).ToList();
                                    categoryId = otherCategories[otherCategories.Count - 1].Id;
                                    Players[SequenceNumber].Column.Categories[categoryId].Score = otherCategories[otherCategories.Count - 1].Score;
                                    view_run.viewGameAction();
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine(Players[SequenceNumber].Name + " selected " + Players[SequenceNumber].Column.Categories[categoryId].Title + ".");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    System.Threading.Thread.Sleep(2000);
                                    finished = true;
                                }
                                else
                                {
                                    view_run.viewGameAction();
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine(Players[SequenceNumber].Name + " didn't score this round!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    System.Threading.Thread.Sleep(2000);
                                    finished = true;
                                }
                            }
                        } while (finished == false);
                    }

                    Rules.bonus(Players[SequenceNumber].Column);
                    Rules.finished(Players[SequenceNumber].Column);
                    saveGame(0);
                }

                Turn.newTurn();
                SequenceNumber++;

                if (SequenceNumber == Players.Count)
                {
                    SequenceNumber = 0;
                }


            } while (Finished == false);

        }

        public int getNonScoredCategoryId(model_player computerPlayer)
        {
            int categoryId = 0;
            for (int i = 0; i < rules.Categories.Count; i++)
            {
                if (computerPlayer.Column.Categories[i].Score == 0 && computerPlayer.Column.Categories[i].Id != 6)
                {
                    categoryId = computerPlayer.Column.Categories[i].Id;
                    break;
                }
            }
            return categoryId;
        }

        public int selectDice(int categoryId)
        {
            List<int> indexList = new List<int>();
            indexList = Rules.calculation(Turn.Dice, categoryId);
            foreach (int dieIndex in indexList)
            {
                Turn.Dice[dieIndex].Hold = true;
            }

            return categoryId;
        }





    }
}
