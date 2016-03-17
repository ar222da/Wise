using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Platform
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        // Spelkaraktär Nalaka
        AnimatedSprite sprite; 
        
        // Fiende
        StaticSprite sprite2;
        
        // Presentation, meny och knappar
        StaticSprite presentation;
        StaticSprite menu;
        StaticSprite startButton; 
        StaticSprite startButtonInactive; 
        StaticSprite quitButton;
        StaticSprite quitButtonInactive;
        StaticSprite yesButton;
        StaticSprite noButton;
        StaticSprite yesButtonInactive;
        StaticSprite noButtonInactive;
        StaticSprite gameOver;
        StaticSprite pause;
        StaticSprite quit;
        StaticSprite finished;
        StaticSprite lifeCounterSprite;

        // Fonter
        SpriteFont font;
        SpriteFont font2;

        // Bakgrundsbilden till spelskärmsbilden
        StaticSprite background;
        
        // State
        // 0 = Inledningen
        // 1 = Meny
        // 2 = Spelar
        // 3 = Game over
        // 4 = Finished game
        // 5 = Pause
        // 6 = Quit confirm
        int state;

        // State för menyn
        int menuState;

        // State för meny vid eventuellt avslut
        int quitMenuState;
        
        // Livsräknare = 3 från början av en spelomgång
        int lives;

        int counterX = 2;
        int counterY = 2;

        KeyboardState _currentKeyboardState;
        KeyboardState _previousKeyboardState;

        SoundEffect soundEffect;
        SoundEffect soundEffect2;
        SoundEffect soundEffect3;
        SoundEffect soundEffect4;

        SoundEffectInstance instance;

        List<List<StaticSprite>> levels_BuildingBlocks = new List<List<StaticSprite>>();
        List<List<EnemySprite>> levels_Enemies = new List<List<EnemySprite>>();

        
        List<Rectangle> nextLevelAreas = new List<Rectangle>();
        List<Vector2> startPositions = new List<Vector2>();


        string[] fileNamesOfLevels_BuildingBlocks;
        string[] fileNamesOfLevels_Enemies;

        int numberOfLevels;

        string result;
        int currentLevel;

        int counter = 1;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = new StaticSprite(Content.Load<Texture2D>("cloudy-240327_1280"), 400, 300);
            background.Origin = new Vector2(background.SpriteWidth / 2, background.SpriteHeight / 2);
            background.Position = new Vector2(0, 0);
            background.SourceRect = new Rectangle(0, 0, 1200, 800);

            presentation = new StaticSprite(Content.Load<Texture2D>("nalaka-pres"), 0, 0);
            presentation.Origin = new Vector2(presentation.SpriteWidth / 2, presentation.SpriteHeight / 2);
            presentation.Position = new Vector2(80, 0);
            presentation.SourceRect = new Rectangle(0, 0, 1200, 800);

            menu = new StaticSprite(Content.Load<Texture2D>("menu"), 0, 0);
            menu.Origin = new Vector2(menu.SpriteWidth / 2, menu.SpriteHeight / 2);
            menu.Position = new Vector2(80, 0);
            menu.SourceRect = new Rectangle(0, 0, 1200, 800);

            startButton = new StaticSprite(Content.Load<Texture2D>("button-start"), 0, 0);
            startButton.Origin = new Vector2(startButton.SpriteWidth / 2, startButton.SpriteHeight / 2);
            startButton.Position = new Vector2(290, 430);
            startButton.SourceRect = new Rectangle(0, 0, 100, 50);

            startButtonInactive = new StaticSprite(Content.Load<Texture2D>("button-start-opacity"), 0, 0);
            startButtonInactive.Origin = new Vector2(startButtonInactive.SpriteWidth / 2, startButtonInactive.SpriteHeight / 2);
            startButtonInactive.Position = new Vector2(290, 430);
            startButtonInactive.SourceRect = new Rectangle(0, 0, 100, 50);

            quitButton = new StaticSprite(Content.Load<Texture2D>("button-quit"), 0, 0);
            quitButton.Origin = new Vector2(quitButton.SpriteWidth / 2, quitButton.SpriteHeight / 2);
            quitButton.Position = new Vector2(410, 430);
            quitButton.SourceRect = new Rectangle(0, 0, 100, 50);

            quitButtonInactive = new StaticSprite(Content.Load<Texture2D>("button-quit-opacity"), 0, 0);
            quitButtonInactive.Origin = new Vector2(quitButtonInactive.SpriteWidth / 2, quitButtonInactive.SpriteHeight / 2);
            quitButtonInactive.Position = new Vector2(410, 430);
            quitButtonInactive.SourceRect = new Rectangle(0, 0, 100, 50);
            
            yesButton = new StaticSprite(Content.Load<Texture2D>("yes"), 0, 0);
            yesButton.Origin = new Vector2(yesButton.SpriteWidth / 2, yesButton.SpriteHeight / 2);
            yesButton.Position = new Vector2(290, 300);
            yesButton.SourceRect = new Rectangle(0, 0, 100, 50);

            noButton = new StaticSprite(Content.Load<Texture2D>("no"), 0, 0);
            noButton.Origin = new Vector2(noButton.SpriteWidth / 2, noButton.SpriteHeight / 2);
            noButton.Position = new Vector2(410, 300);
            noButton.SourceRect = new Rectangle(0, 0, 100, 50);

            yesButtonInactive = new StaticSprite(Content.Load<Texture2D>("yes-op"), 0, 0);
            yesButtonInactive.Origin = new Vector2(yesButtonInactive.SpriteWidth / 2, yesButtonInactive.SpriteHeight / 2);
            yesButtonInactive.Position = new Vector2(290, 300);
            yesButtonInactive.SourceRect = new Rectangle(0, 0, 100, 50);

            noButtonInactive = new StaticSprite(Content.Load<Texture2D>("no-op"), 0, 0);
            noButtonInactive.Origin = new Vector2(noButtonInactive.SpriteWidth / 2, noButtonInactive.SpriteHeight / 2);
            noButtonInactive.Position = new Vector2(410, 300);
            noButtonInactive.SourceRect = new Rectangle(0, 0, 100, 50);

            gameOver = new StaticSprite(Content.Load<Texture2D>("gameover"), 0, 0);
            gameOver.Origin = new Vector2(gameOver.SpriteWidth / 2, gameOver.SpriteHeight / 2);
            gameOver.Position = new Vector2(80, 0);
            gameOver.SourceRect = new Rectangle(0, 0, 1200, 800);
            
            finished = new StaticSprite(Content.Load<Texture2D>("finished"), 0, 0);
            finished.Origin = new Vector2(finished.SpriteWidth / 2, finished.SpriteHeight / 2);
            finished.Position = new Vector2(80, 0);
            finished.SourceRect = new Rectangle(0, 0, 1200, 800);

            pause = new StaticSprite(Content.Load<Texture2D>("pause"), 0, 0);
            pause.Origin = new Vector2(pause.SpriteWidth / 2, pause.SpriteHeight / 2);
            pause.Position = new Vector2(80, 0);
            pause.SourceRect = new Rectangle(0, 0, 1200, 800);

            quit = new StaticSprite(Content.Load<Texture2D>("quit"), 0, 0);
            quit.Origin = new Vector2(quit.SpriteWidth / 2, quit.SpriteHeight / 2);
            quit.Position = new Vector2(80, 0);
            quit.SourceRect = new Rectangle(0, 0, 1200, 800);

            lifeCounterSprite = new StaticSprite(Content.Load<Texture2D>("sheet5"), 40, 46);
            lifeCounterSprite.SourceRect = new Rectangle(0, 0, 40, 46);
            lifeCounterSprite.Origin = new Vector2(lifeCounterSprite.SourceRect.Width / 2, lifeCounterSprite.SourceRect.Height / 2);
            
            sprite = new AnimatedSprite(Content.Load<Texture2D>("sheet5"), 0, 40, 46);

            sprite2 = new StaticSprite(Content.Load<Texture2D>("funny2 (1)"), 40, 46);
            sprite2.SourceRect = new Rectangle(0, 0, 40, 46);
            sprite2.Origin = new Vector2(sprite2.SourceRect.Width / 2, sprite2.SourceRect.Height / 2);
            sprite2.Position = new Vector2(780, 89);

            font = Content.Load<SpriteFont>("font");
            font2 = Content.Load<SpriteFont>("font2");

            soundEffect = Content.Load<SoundEffect>("jump");
            soundEffect2 = Content.Load<SoundEffect>("kill");
            soundEffect3 = Content.Load<SoundEffect>("walking");
            soundEffect4 = Content.Load<SoundEffect>("killEnemy");

            instance = soundEffect3.CreateInstance();

        
            // läs in objekt för varje bana från textfil (numrerade blockobjekt-filerna som ligger i content, motsvarande fiende-filer
            // ligger i underkatalogen "Enemies")
            string directory = Directory.GetCurrentDirectory();
            string contentDirectory = @"Content";
            result = Path.Combine(directory, contentDirectory);
            fileNamesOfLevels_BuildingBlocks = Directory.GetFiles(result, "*.txt");

            Array.Sort(fileNamesOfLevels_BuildingBlocks);
            numberOfLevels = fileNamesOfLevels_BuildingBlocks.Length;
            
            foreach (string s in fileNamesOfLevels_BuildingBlocks)
            {

                string file = @"Content\" + Path.GetFileName(s);
                string[] staticSpriteValues;
                string line;

                List<StaticSprite> sprites = new List<StaticSprite>();

                using (StreamReader r = new StreamReader(file))
                {
                    while ((line = r.ReadLine()) != null)
                    {
                        staticSpriteValues = line.Split(',');

                        if (staticSpriteValues.Length == 13)
                        {
                            // Området där man flyttas till nästa bana ligger på första raden (inte alltid) i varje blockobjekt-fil
                            // och dessa värden läggs in i en lista av rektanglar som anger respektive område
                            Rectangle nextLevelArea = new Rectangle(int.Parse(staticSpriteValues[7]),
                            int.Parse(staticSpriteValues[8]),
                            int.Parse(staticSpriteValues[9]),
                            int.Parse(staticSpriteValues[10]));
                            nextLevelAreas.Add(nextLevelArea);
                            
                            // Startpositionen för spelkaraktären på varje bana ligger också på första raden
                            Vector2 startPosition = new Vector2(int.Parse(staticSpriteValues[11]),
                                int.Parse(staticSpriteValues[12]));
                            startPositions.Add(startPosition);
                        }

                        // Alla andra rader i block-filerna innehåller bara 7 värden (varje blockobjekts värden)
                        StaticSprite sp = new StaticSprite(Content.Load<Texture2D>("brickbibi"), int.Parse(staticSpriteValues[2]), int.Parse(staticSpriteValues[3]));
                        sp.SourceRect = new Rectangle(int.Parse(staticSpriteValues[0]) * int.Parse(staticSpriteValues[2]), int.Parse(staticSpriteValues[1]), int.Parse(staticSpriteValues[2]), int.Parse(staticSpriteValues[3]));
                        sp.Origin = new Vector2(int.Parse(staticSpriteValues[2]) / 2, int.Parse(staticSpriteValues[3]) / 2);
                        sp.Position = new Vector2(int.Parse(staticSpriteValues[4]), int.Parse(staticSpriteValues[5]));
                        sp.Moving = int.Parse(staticSpriteValues[6]);
                        sp.Counter = 2;

                        // OBS!!!
                        // De rader som innehåller värden för block-objekt som kan röra på sig, innehåller också 13 värden!
                        // Därför ligger det "dummy"-värden efter de faktiska värderna bara för att ändra på längden på raden.
                        // Det blir problem om man inte gör det, då hittar den mer än en rad som innehåller 13 värden och 
                        // ökar antalet objekt i listorna "nextLevelAreas" och "startPositions". 
                        // Om block-objektet kan röra på sig innehåller raden 13 värden, men "dummy-värden" ligger i slutet för att
                        // särskilja den från den rad som anger karaktärens startposition och område för att komma till nästa bana (se ovan).
                        if (staticSpriteValues.Length > 7 && int.Parse(staticSpriteValues[6]) == 1)
                        {
                            sp.XSpeed = int.Parse(staticSpriteValues[7]);
                            sp.YSpeed = int.Parse(staticSpriteValues[8]);
                            sp.MinX = int.Parse(staticSpriteValues[9]);
                            sp.MaxX = int.Parse(staticSpriteValues[10]);
                            sp.MinY = int.Parse(staticSpriteValues[11]);
                            sp.MaxY = int.Parse(staticSpriteValues[12]);
                        }

                        
                        sprites.Add(sp);
                    }
                }

                levels_BuildingBlocks.Add(sprites);
            }            
            

            // läs in fiender för varje bana från fil (numrerade filer som ligger i underkatalogen "Enemies")
            directory = Directory.GetCurrentDirectory();
            contentDirectory = @"Content\Enemies";
            result = Path.Combine(directory, contentDirectory);
            fileNamesOfLevels_Enemies = Directory.GetFiles(result, "*.txt");

            Array.Sort(fileNamesOfLevels_Enemies);
            
            foreach (string s in fileNamesOfLevels_Enemies)
            {

                string file = @"Content" + @"\Enemies\" + Path.GetFileName(s);
                string[] enemySpriteValues;
                string line;

                List<EnemySprite> enemies = new List<EnemySprite>();

                using (StreamReader r = new StreamReader(file))
                {
                    while ((line = r.ReadLine()) != null)
                    {
                        enemySpriteValues = line.Split(',');
                        EnemySprite en = new EnemySprite(Content.Load<Texture2D>("en"), int.Parse(enemySpriteValues[0]), int.Parse(enemySpriteValues[1]), int.Parse(enemySpriteValues[2]));
                        en.SourceRect = new Rectangle((int.Parse(enemySpriteValues[0]) * int.Parse(enemySpriteValues[1])), 0, int.Parse(enemySpriteValues[1]), int.Parse(enemySpriteValues[2]));
                        en.Origin = new Vector2(en.SourceRect.Width / 2, en.SourceRect.Height / 2);
                        en.XSpeed = int.Parse(enemySpriteValues[3]);
                        en.YSpeed = int.Parse(enemySpriteValues[4]);
                        en.Position = new Vector2(int.Parse(enemySpriteValues[5]), int.Parse(enemySpriteValues[6]));
                        en.MinX = int.Parse(enemySpriteValues[7]);
                        en.MaxX = int.Parse(enemySpriteValues[8]);
                        en.MinY = int.Parse(enemySpriteValues[9]);
                        en.MaxY = int.Parse(enemySpriteValues[10]);
                        enemies.Add(en);
                        //0,40,46,2,1,40,365,40,100,300,365
                    }
                }

                levels_Enemies.Add(enemies);
            }
        }

        protected override void UnloadContent()
        {
        }

        public void TitleScreen(GameTime gameTime)
        {

            if (_previousKeyboardState.GetPressedKeys().Length == 0)
            {
                if (Keyboard.GetState().GetPressedKeys().Length > 0)
                {
                    menuState = 0;
                    state = 1; 
                }
            }
        }

        public void MenuScreen(GameTime gameTime)
        {
            _currentKeyboardState = Keyboard.GetState();

            if (_previousKeyboardState.GetPressedKeys().Length == 0)
            {

                if ((_currentKeyboardState.IsKeyDown(Keys.Right) && _previousKeyboardState.IsKeyUp(Keys.Right)) ||
                    (_currentKeyboardState.IsKeyDown(Keys.Left) && _previousKeyboardState.IsKeyUp(Keys.Left)) ||
                    (_currentKeyboardState.IsKeyDown(Keys.Up) && _previousKeyboardState.IsKeyUp(Keys.Up)) ||
                    (_currentKeyboardState.IsKeyDown(Keys.Down)) && _previousKeyboardState.IsKeyUp(Keys.Down))
                {
                    if (menuState == 0)
                    {
                        menuState = 1;
                    }

                    else if (menuState == 1)
                    {
                        menuState = 0;
                    }
                }

                if (_currentKeyboardState.IsKeyDown(Keys.Enter))
                {
                    if (menuState == 0)
                    {
                        currentLevel = 0;
                        sprite.Position = startPositions[0];
                        lives = 3;
                        state = 2;
                    }

                    else
                    {
                        this.Exit();
                    }
                }
            }
        }

        public void GameOverScreen(GameTime gameTime)
        {
           
            if (_previousKeyboardState.GetPressedKeys().Length == 0)
            {
                if (Keyboard.GetState().GetPressedKeys().Length > 0)
                {
                    state = 1;
                }
            }
        }

        public void PauseScreen(GameTime gameTime)
        {

            if (_previousKeyboardState.IsKeyUp(Keys.P))
            {

                if (Keyboard.GetState().GetPressedKeys().Length > 0)
                {
                    state = 2;
                }

            }
        }

        public void QuitScreen(GameTime gameTime)
        {
            if (_currentKeyboardState.IsKeyDown(Keys.Y))
            {
                this.Exit();
            }

            else if (_currentKeyboardState.IsKeyDown(Keys.N))
            {
                state = 2;
            }

            else if ((_currentKeyboardState.IsKeyDown(Keys.Right) && _previousKeyboardState.IsKeyUp(Keys.Right)) ||
            (_currentKeyboardState.IsKeyDown(Keys.Left) && _previousKeyboardState.IsKeyUp(Keys.Left)) ||
            (_currentKeyboardState.IsKeyDown(Keys.Up) && _previousKeyboardState.IsKeyUp(Keys.Up)) ||
            (_currentKeyboardState.IsKeyDown(Keys.Down)) && _previousKeyboardState.IsKeyUp(Keys.Down))
            {
                if (quitMenuState == 0)
                {
                    quitMenuState = 1;
                }

                else if (quitMenuState == 1)
                {
                    quitMenuState = 0;
                }
            }

            if (_currentKeyboardState.IsKeyDown(Keys.Enter))
            {
                if (quitMenuState == 1)
                {
                    state = 2;
                }

                else
                {
                    this.Exit();
                }
            }
        }
        
        public void EndScreen(GameTime gameTime)
        {
            sprite.Position = new Vector2(sprite.Position.X + counterX, sprite.Position.Y + counterY);
            sprite2.Position = new Vector2(sprite.Position.X + counterX + 50, sprite.Position.Y + counterY);

            if (sprite.Position.X > 500)
            {
                counterX = -2;
            }

            else if (sprite.Position.X < 300)
            {
                counterX = 2;
            }

            if (sprite.Position.Y > 350)
            {
                counterY = -2;
            }

            else if (sprite.Position.Y < 300)
            {
                counterY = 2;
            }
            if (_previousKeyboardState.GetPressedKeys().Length == 0)
            {
                if (Keyboard.GetState().GetPressedKeys().Length > 0)
                {
                    state = 1;
                }
            }
        }
        
        public void GameScreen(GameTime gameTime)
        {

            // Kollisionshantering mellan blockobjekt och spelkaraktär utifrån karaktärens vänstra sida
            foreach (StaticSprite spr in levels_BuildingBlocks[currentLevel])
            {
                if (sprite.LeftLine.Intersects(spr.BoundingBox))
                {
                    sprite.CollisionLeft = true;
                    break;
                }

                sprite.CollisionLeft = false;

            }

            // Kollisionshantering mellan blockobjekt och spelkaraktär utifrån karaktärens högra sida
            foreach (StaticSprite spr in levels_BuildingBlocks[currentLevel])
            {
                if (sprite.RightLine.Intersects(spr.BoundingBox))
                {
                    sprite.CollisionRight = true;
                    break;
                }

                sprite.CollisionRight = false;

            }

            // Kollisionshantering mellan blockobjekt och spelkaraktär utifrån karaktärens ovansida
            foreach (StaticSprite spr in levels_BuildingBlocks[currentLevel])
            {
                if (sprite.UpLine.Intersects(spr.BoundingBox))
                {
                    sprite.CollisionUp = true;
                    break;
                }

                sprite.CollisionUp = false;
            }

            // Kollisionshantering mellan blockobjekt och spelkaraktär utifrån karaktärens undersida
            foreach (StaticSprite spr in levels_BuildingBlocks[currentLevel])
            {
                if (sprite.DownLine.Intersects(spr.BoundingBox))
                {
                    sprite.CollisionDown = true;
                    break;
                }

                sprite.CollisionDown = false;
            }
            
            
            
            // Detta är motsvarande kollisionshantering mellan varje fiendefigur och blockobjekten på banan
            foreach (EnemySprite ene in levels_Enemies[currentLevel])
            {
                // Kollisionshantering mellan aktuell fiende i loopen och varje blockobjekt utifrån fiendes vänstra sida
                foreach (StaticSprite spr in levels_BuildingBlocks[currentLevel])
                {
                    if (ene.LeftLine.Intersects(spr.BoundingBox))
                    {
                        ene.CollisionLeft = true;
                        break;
                    }

                    ene.CollisionLeft = false;
                }

                // Kollisionshantering mellan aktuell fiende i loopen och varje blockobjekt utifrån fiendes högra sida
                foreach (StaticSprite spr in levels_BuildingBlocks[currentLevel])
                {
                    if (ene.RightLine.Intersects(spr.BoundingBox))
                    {
                        ene.CollisionRight = true;
                        break;
                    }

                    ene.CollisionRight = false;
                }

                // Kollisionshantering mellan aktuell fiende i loopen och varje blockobjekt utifrån fiendes ovansida
                foreach (StaticSprite spr in levels_BuildingBlocks[currentLevel])
                {
                    if (ene.UpLine.Intersects(spr.BoundingBox))
                    {
                        ene.CollisionUp = true;
                        break;
                    }

                    ene.CollisionUp = false;
                }

                // Kollisionshantering mellan aktuell fiende i loopen och varje blockobjekt utifrån fiendes undersida
                foreach (StaticSprite spr in levels_BuildingBlocks[currentLevel])
                {
                    if (ene.DownLine.Intersects(spr.BoundingBox))
                    {
                        ene.CollisionDown = true;
                        break;
                    }

                    ene.CollisionDown = false;
                }

                // Kollisionshantering mellan aktuell fiende i loopen och spelkaraktären
                if (ene.BoundingBox.Intersects(sprite.BoundingBox))
                {
                    // Fiende kan bara dödas om spelkaraktären hoppar på den ovanifrån
                    if ((sprite.DownLine.Intersects(ene.BoundingBox)) && sprite.State != 4)
                    {
                        soundEffect4.Play();
                        ene.Killed = true;
                        sprite.JumpSpeed = -14;
                        sprite.State = 2;
                    }

                    // Vidrör spelkaraktären fienden från något annat håll dör spelkaraktären
                    else
                    {
                        sprite.State = 4;
                        soundEffect2.Play();
                    }
                }

                ene.HandleSpriteMovement(gameTime);
            }
            
            // Ett blockobjekt har förmåga att röra på sig. 
            // Detta för att spelkaraktären ska kunna ta sig över sträckor som den inte kan hoppa mellan.
            // Position 7 på varje rad i blockobjekt-filen avgör detta för varje blockobjekt.
            // 0 = ej rörlig, 1 = rörlig
            foreach (StaticSprite spr in levels_BuildingBlocks[currentLevel])
            {
                if (spr.Moving == 1)
                {
                    spr.Position = new Vector2(spr.Position.X + spr.XSpeed, spr.Position.Y + spr.YSpeed);

                    if (spr.Position.X > spr.MaxX)
                    {
                        spr.XSpeed = spr.XSpeed - (spr.XSpeed * 2);
                    }

                    if (spr.Position.X < spr.MinX)
                    {
                        spr.XSpeed = spr.XSpeed - (spr.XSpeed * 2);
                    }

                    if (spr.Position.Y > spr.MaxY)
                    {
                        spr.YSpeed = spr.YSpeed - (spr.YSpeed * 2);
                    }

                    if (spr.Position.Y < spr.MinY)
                    {
                        spr.YSpeed = spr.YSpeed - (spr.YSpeed * 2);
                    }


                    if ((sprite.DownLine.Intersects(spr.BoundingBox)) && !sprite.CollisionLeft && !sprite.CollisionRight)
                    {
                        if (spr.YSpeed > 0)
                        {
                            sprite.Position = new Vector2(spr.Position.X, (spr.Position.Y - spr.SpriteHeight) + spr.YSpeed);
                        }

                        else
                        {
                            sprite.Position = new Vector2(spr.Position.X, spr.Position.Y - spr.SpriteHeight - spr.YSpeed);
                        }

                    }

                    if (sprite.RightLine.Intersects(spr.BoundingBox))
                    {
                        sprite.Position = new Vector2(spr.Position.X - sprite.SpriteWidth, sprite.Position.Y);
                    }

                    if (sprite.LeftLine.Intersects(spr.BoundingBox))
                    {
                        sprite.Position = new Vector2(spr.Position.X + sprite.SpriteWidth, sprite.Position.Y);
                    }
                }
            }

            if (sprite.Position.Y > 500) // Om spelkaraktär har fallit utanför bild, dör man
            {
                sprite.State = 4;
                soundEffect2.Play();
            }
            
            
            if (sprite.State == 4)
            {
                lives -= 1;
                sprite.State = 3;
                sprite.Position = startPositions[currentLevel];
            }
            
            
            if (lives == -1)
            {
                state = 3;
            }

            if (sprite.BoundingBox.Intersects(nextLevelAreas[currentLevel]))
            {
                if (currentLevel < numberOfLevels)
                {
                    currentLevel++;
                    sprite.Position = startPositions[currentLevel];
                }

                if (currentLevel == numberOfLevels)
                {
                    state = 4;
                }
            }


            sprite2.Position = new Vector2(sprite2.Position.X, sprite2.Position.Y + counter);
            
            if (sprite2.Position.Y < 80)
            {
                counter = 1;
            }

            if (sprite2.Position.Y > 88)
            {
                counter = -1;
            }

            if (_currentKeyboardState.IsKeyDown(Keys.P))
            {
                state = 5;
            }

            if (_currentKeyboardState.IsKeyDown(Keys.Escape))
            {
                state = 6;
            }
            
            
            sprite.HandleSpriteMovement(gameTime);
        }

        

        protected override void Update(GameTime gameTime)
        {
            
        
            _currentKeyboardState = Keyboard.GetState();

            if (state == 0)
            {
                TitleScreen(gameTime);
            }

            else if (state == 1)
            {
                levels_Enemies.Clear();
                levels_BuildingBlocks.Clear();
                LoadContent();
                MenuScreen(gameTime);
            }

            else if (state == 2)
            {
                    
                GameScreen(gameTime);
                
                //Handle sounds

                if (_currentKeyboardState.IsKeyDown(Keys.Up) && _previousKeyboardState.IsKeyUp(Keys.Up))
                {
                    soundEffect.Play();
                }

                if (_currentKeyboardState.IsKeyDown(Keys.Left) && _previousKeyboardState.IsKeyDown(Keys.Left) && sprite.State == 3)
                {

                    if (instance.State == SoundState.Stopped)
                    {
                        instance.Play();
                    }
                }

                if (_currentKeyboardState.IsKeyDown(Keys.Right) && _previousKeyboardState.IsKeyDown(Keys.Right) && sprite.State == 3)
                {
                    if (instance.State == SoundState.Stopped)
                    {
                        instance.Play();
                    }
                }
                
            }

            if (state == 3)
            {
                GameOverScreen(gameTime);
            }

            if (state == 4)
            {
                EndScreen(gameTime);
            }

            if (state == 5)
            {
                PauseScreen(gameTime);
            }

            if (state == 6)
            {
                QuitScreen(gameTime);
            }

            base.Update(gameTime);
            _previousKeyboardState = _currentKeyboardState;
            
        }

           

            
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            if (state == 0)
            {
                spriteBatch.Draw(presentation.Texture, presentation.Position, presentation.SourceRect, Color.White, 0f, presentation.Origin, 0.8f, SpriteEffects.None, 0);
            }

            else if (state == 1)
            {
                spriteBatch.Draw(menu.Texture, menu.Position, menu.SourceRect, Color.White, 0f, menu.Origin, 0.8f, SpriteEffects.None, 0);

                if (menuState == 0)
                {
                    spriteBatch.Draw(startButton.Texture, startButton.Position, startButton.SourceRect, Color.White, 0f, startButton.Origin, 0.8f, SpriteEffects.None, 0);
                    spriteBatch.Draw(quitButtonInactive.Texture, quitButtonInactive.Position, quitButtonInactive.SourceRect, Color.White, 0f, quitButtonInactive.Origin, 0.8f, SpriteEffects.None, 0);
                }

                else if (menuState == 1)
                {
                    spriteBatch.Draw(startButtonInactive.Texture, startButtonInactive.Position, startButtonInactive.SourceRect, Color.White, 0f, startButtonInactive.Origin, 0.8f, SpriteEffects.None, 0);
                    spriteBatch.Draw(quitButton.Texture, quitButton.Position, quitButton.SourceRect, Color.White, 0f, quitButton.Origin, 0.8f, SpriteEffects.None, 0);
                }
            
            }

            else if (state == 2)
            {
                spriteBatch.Draw(background.Texture, background.Position, background.SourceRect, Color.White, 0f, background.Origin, 0.9f, SpriteEffects.None, 0);
                spriteBatch.Draw(sprite.Texture, sprite.Position, sprite.SourceRect, Color.White, 0f, sprite.Origin, 1.0f, SpriteEffects.None, 0);
                // Om det är sista banan, rita ut figuren som spelkaraktären ska rädda
                if (currentLevel == (numberOfLevels - 1))
                {
                    spriteBatch.Draw(sprite2.Texture, sprite2.Position, sprite2.SourceRect, Color.White, 0f, sprite2.Origin, 1.0f, SpriteEffects.None, 0);
                    string text = "Help me!";
                    spriteBatch.DrawString(font2, text, new Vector2(748, 40), Color.White);
                }

                // Rita block-objekten för aktuell bana    
                foreach (StaticSprite spr in levels_BuildingBlocks[currentLevel])
                {
                    spriteBatch.Draw(spr.Texture, spr.Position, spr.SourceRect, Color.White, 0f, spr.Origin, 1.0f, SpriteEffects.None, 0);
                }

                // Rita fiender för aktuell bana
                foreach (EnemySprite enemySprite in levels_Enemies[currentLevel])
                {
                    spriteBatch.Draw(enemySprite.Texture, enemySprite.Position, enemySprite.SourceRect, Color.White, 0f, enemySprite.Origin, 1.0f, SpriteEffects.None, 0);
                }
                //string pos = "Lives: " + lives.ToString();
                //spriteBatch.DrawString(font, pos, new Vector2(0, 0), Color.White);

                for (int i = 0; i < lives; i++)
                {
                    lifeCounterSprite.Position = new Vector2(i * 30 + 20, 20);
                    spriteBatch.Draw(lifeCounterSprite.Texture, lifeCounterSprite.Position, lifeCounterSprite.SourceRect, Color.White, 0f, lifeCounterSprite.Origin, 0.3f, SpriteEffects.None, 0);
                }

            }

            else if (state == 3)
            {
                spriteBatch.Draw(gameOver.Texture, gameOver.Position, gameOver.SourceRect, Color.White, 0f, gameOver.Origin, 0.8f, SpriteEffects.None, 0);
            }

            else if (state == 4)
            {
                Rectangle newSourceforSprite = new Rectangle(120, 0, 40, 46);
                spriteBatch.Draw(finished.Texture, finished.Position, finished.SourceRect, Color.White, 0f, finished.Origin, 0.8f, SpriteEffects.None, 0);
                spriteBatch.Draw(sprite.Texture, sprite.Position, newSourceforSprite, Color.White, 0f, sprite.Origin, 1.0f, SpriteEffects.None, 0);
                spriteBatch.Draw(sprite2.Texture, sprite2.Position, sprite2.SourceRect, Color.White, 0f, sprite2.Origin, 1.0f, SpriteEffects.None, 0);
            }

            else if (state == 5)
            {
                spriteBatch.Draw(pause.Texture, pause.Position, pause.SourceRect, Color.White, 0f, pause.Origin, 0.8f, SpriteEffects.None, 0);
            }

            else if (state == 6)
            {
                spriteBatch.Draw(quit.Texture, quit.Position, quit.SourceRect, Color.White, 0f, quit.Origin, 0.8f, SpriteEffects.None, 0);
                
                if (quitMenuState == 0)
                {
                    spriteBatch.Draw(yesButton.Texture, yesButton.Position, yesButton.SourceRect, Color.White, 0f, yesButton.Origin, 0.8f, SpriteEffects.None, 0);
                    spriteBatch.Draw(noButtonInactive.Texture, noButtonInactive.Position, noButtonInactive.SourceRect, Color.White, 0f, noButtonInactive.Origin, 0.8f, SpriteEffects.None, 0);
                }

                else if (quitMenuState == 1)
                {
                    spriteBatch.Draw(yesButtonInactive.Texture, yesButtonInactive.Position, yesButtonInactive.SourceRect, Color.White, 0f, yesButtonInactive.Origin, 0.8f, SpriteEffects.None, 0);
                    spriteBatch.Draw(noButton.Texture, noButton.Position, noButton.SourceRect, Color.White, 0f, noButton.Origin, 0.8f, SpriteEffects.None, 0);
                }

            }


            spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
