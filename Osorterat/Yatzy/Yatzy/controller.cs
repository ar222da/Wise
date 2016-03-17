using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Yatzy
{
    class controller
    {
        private List<model_game> games = new List<model_game>();
        public bool quitRequest;

        public controller()
        {
            quitRequest = false;
        }

        public List<model_game> Games
        {
            get { return games; }
        }

        public void start()
        {
            do
            {
                menu();
            } while (quitRequest == false);
        }

        public void menu()
        {
            view_menu view_menu = new view_menu();
            
            do
            {
                view_menu.menu();

            } while (view_menu.Selected == 0);

            // Nytt spel
            if (view_menu.Selected == 1)
            {
                view_newGame view_newGame = new view_newGame();
                view_newGame.selectGameType();
                view_newGame.getPlayers();
                model_game game = new model_game();
                game.GameType = view_newGame.GameType;
                game.Players = view_newGame.Players;
                game.setRules();
                game.setColumns();
                game.setTurn();
                game.Turn.newTurn();
                game.run();
            }
            
            // Återuppta senast oavslutade spel
            else if (view_menu.Selected == 2)
            {
                model_game game = new model_game();
                game.loadGame(0, 0);
                game.run();
            }

            // Se tidigare spel och fortsätt spela
            else if (view_menu.Selected == 3)
            {
                loadGames();
                view_loadViewGames view_loadViewGames = new view_loadViewGames();
                view_loadViewGames.Games = games;
                do
                {
                    view_loadViewGames.gameList();
                    view_loadViewGames.getUserInputViewMenu();
                    if (view_loadViewGames.ViewSelected == 1)
                    {
                        view_loadViewGames.viewTables();
                    }

                } while (view_loadViewGames.PlayRequest == false);
                
                view_loadViewGames.Game.run();
            }
            
            // Avsluta
            else if (view_menu.Selected == 4)
            {
                quitRequest = true;
            }
           
        }

        public model_game newGame()
        {
            view_newGame view_newGame = new view_newGame();
            view_newGame.selectGameType();
            view_newGame.getPlayers();
            model_game game = new model_game();
            game.GameType = view_newGame.GameType;
            game.Players = view_newGame.Players;
            return game;
        }

        public void loadGames()
        {
            games.Clear();
            var fileList = Directory.GetFiles(@".", "*.gam");
            if (fileList.Length > 0)
            {
                for (int i = 0; i < fileList.Length -1; i++)
                {
                    model_game game = new model_game();
                    game.loadGame(i + 1, 1);
                    games.Add(game);
                }
            }
        }
        
    }
}
