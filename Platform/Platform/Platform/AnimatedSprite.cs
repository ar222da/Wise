using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Platform
{
       
    class AnimatedSprite
    {
        KeyboardState currentKBState;
        KeyboardState previousKBState;

        Texture2D spriteTexture;
        float timer = 0f;
        float interval = 100f;
        int currentFrame = 0;
        int spriteWidth = 40;
        int spriteHeight = 46;
        int spriteSpeed = 5;
        Rectangle sourceRect;
        Vector2 position;
        Vector2 origin;

        int jumpSpeed;
        float fallSpeed;
        int state;
        int collision;
        
        bool collisionLeft;
        bool collisionRight;
        bool collisionUp;
        bool collisionDown;

        bool transported;

        bool killed;
        int killedSpeed = -5;

        bool jumping;


        public int SpriteWidth
        {
            get { return spriteWidth; }
            set { spriteWidth = value; }
        }

        public int SpriteHeight
        {
            get { return spriteHeight; }
            set { spriteHeight = value; }
        }

        public int Collision
        {
            get { return collision; }
            set { collision = value; }
        }

        public bool CollisionLeft
        {
            get { return collisionLeft; }
            set { collisionLeft = value; }
        }

        public bool CollisionRight
        {
            get { return collisionRight; }
            set { collisionRight = value; }
        }

        public bool CollisionUp
        {
            get { return collisionUp; }
            set { collisionUp = value; }
        }

        public bool CollisionDown
        {
            get { return collisionDown; }
            set { collisionDown = value; }
        }

        public bool Transported
        {
            get { return transported; }
            set { transported = value; }
        }

        public bool Jumping
        {
            get { return jumping; }
            set { jumping = value; }
        }

        public bool Killed
        {
            get { return killed; }
            set { killed = value; }
        }
        
        public int State
        {
            get { return state; }
            set { state = value; }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, spriteWidth, spriteHeight);
            }
        }

        public Rectangle LeftLine
        {
            get
            {
                //return new Rectangle((int)position.X - spriteSpeed, (int)position.Y + 10, spriteSpeed, spriteHeight -20);
                return new Rectangle((int)position.X - spriteSpeed, (int)position.Y, spriteSpeed, spriteHeight);
            }
        }
        
        public Rectangle RightLine
        {
            get
            {
                //return new Rectangle((int)position.X + spriteWidth, (int)position.Y + 10, spriteSpeed, spriteHeight - 20);
                return new Rectangle((int)position.X + spriteWidth, (int)position.Y, spriteSpeed, spriteHeight);
            }
        }

        public Rectangle UpLine
        {
            get
            {
                //return new Rectangle((int)position.X + 10, (int)position.Y + jumpSpeed, spriteWidth - 20, (-1 * jumpSpeed));
                return new Rectangle((int)position.X + 10, (int)position.Y + jumpSpeed, spriteWidth - 10, (-1 * jumpSpeed));
            }
        }

        public Rectangle DownLine
        {
            get
            {
                //return new Rectangle((int)position.X + 10, (int)position.Y + spriteHeight + (int)fallSpeed, spriteWidth - 20, (int)fallSpeed);
                return new Rectangle((int)position.X + 5, (int)position.Y + spriteHeight + (int)fallSpeed, spriteWidth - 10, (int)fallSpeed);
            }
            
        }


        public Rectangle SourceRect
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public float FallSpeed
        {
            get { return fallSpeed; }
            set { fallSpeed = value; }
        }
        
        public int JumpSpeed
        {
            get { return jumpSpeed; }
            set { jumpSpeed = value; }
        }

        
        public Texture2D Texture
        {
            get { return spriteTexture; }
            set { spriteTexture = value; }
        }

        public AnimatedSprite(Texture2D texture, int currentFrame, int spriteWidth, int spriteHeight)
        {
            this.spriteTexture = texture;
            this.currentFrame = currentFrame;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
            this.jumpSpeed = -14;
            this.fallSpeed = 3;
            this.state = 1;
        }

        public void HandleSpriteMovement(GameTime gameTime)
        {
            previousKBState = currentKBState;
            currentKBState = Keyboard.GetState();

            sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);

            if (state == 1) // falling
            {
                if (!collisionDown)
                {
                    if (fallSpeed < 10)
                    {
                        fallSpeed += 0.3F;
                    }

                    if (fallSpeed > 10)
                    {
                       fallSpeed = 10;
                    }
                    position.Y += fallSpeed;
                }

                else if (collisionDown && fallSpeed == 1)
                {
                    state = 3;
                }
                
                else 
                {
                    position.Y += fallSpeed-2;
                    state = 3;
                    fallSpeed = 1;
                }
            }

            if (state == 2) // jumping
            {
                if (!collisionUp && jumpSpeed < 0 && position.Y > 20)
                {
                    position.Y += jumpSpeed;
                    jumpSpeed += 1;
                }

                else if (collisionUp)
                {
                    state = 3;
                }

                else
                {
                    state = 1;
                    //jumping = false;
                    fallSpeed = 3;
                }
             }

            if (state == 3) // foothold
            {
                //jumpSpeed = -14;
                if (!collisionDown)
                {
                    fallSpeed = 3;
                    state = 1;
                }

                
            }

            if (state == 4) // killed
            {
            }
            
            
            

            
            
                if (currentKBState.GetPressedKeys().Length == 0 && state == 3)
                {
                    if (currentFrame > -1 && currentFrame < 4)
                    {
                        currentFrame = 0;
                    }

                    if (currentFrame > 3 && currentFrame < 8)
                    {
                        currentFrame = 7;
                    }
                }

                if (currentKBState.IsKeyDown(Keys.Right) == true)
                {
                    AnimateRight(gameTime);
                    if (position.X < 780 && !collisionRight && !killed)
                    {
                        position.X += spriteSpeed;
                    }
                }

                if (currentKBState.IsKeyDown(Keys.Left) == true)
                {
                    AnimateLeft(gameTime);
                    if (position.X > 20 && !collisionLeft && !killed)
                    {
                        position.X -= spriteSpeed;
                    }
                }

                if (currentKBState.IsKeyDown(Keys.Up) == true && state == 3)
                {
                    if (currentFrame > -1 && currentFrame < 2)
                    {
                        currentFrame = 3;
                    }

                    if (currentFrame > 5 && currentFrame < 8)
                    {
                        currentFrame = 4;
                    }

                    state = 2;
                    jumpSpeed = -14;
                }

                if (currentKBState.IsKeyDown(Keys.Up) == true && currentKBState.IsKeyDown(Keys.Left) == true)
                {
                    currentFrame = 4;
                }

                if (currentKBState.IsKeyDown(Keys.Up) == true && currentKBState.IsKeyDown(Keys.Right) == true)
                {
                    currentFrame = 3;
                }

                if (currentKBState.IsKeyDown(Keys.Right) == true && currentKBState.IsKeyDown(Keys.Left) == true)
                {
                    currentFrame = 0;
                }

            origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);
        }

        public void AnimateRight(GameTime gameTime)
        {
            if (currentKBState != previousKBState)
            {
                currentFrame = 0;
            }

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame > 2)
                {
                    currentFrame = 1;
                }
                timer = 0f;
            }

        }

        public void AnimateLeft(GameTime gameTime)
        {
            if (currentKBState != previousKBState)
            {
                currentFrame = 7;
            }

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;

                if (currentFrame > 6)
                {
                    currentFrame = 5;
                }
                timer = 0f;
            }
        }


    }
}
