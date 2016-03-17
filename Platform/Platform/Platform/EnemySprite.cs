using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Platform
{
    class EnemySprite
    {
        Texture2D spriteTexture;
        int spriteWidth;
        int spriteHeight;
        int currentFrame;
        Rectangle sourceRect;
        Vector2 position;
        Vector2 origin;

        int xSpeed;
        int ySpeed;

        Vector2 startPosition;

        int minX;
        int maxX;
        int minY;
        int maxY;

        int lastXCollision;
        int lastYCollision;

        bool collisionLeft;
        bool collisionRight;
        bool collisionUp;
        bool collisionDown;

        bool inRadar;

        bool killed;

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

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, spriteWidth, spriteHeight);
            }
        }

        public Rectangle RadarBox
        {
            get
            {
                return new Rectangle((int)position.X - 100, (int)position.Y - 100, spriteWidth + 200, spriteHeight + 200);
            }
        }

        public Rectangle LeftLine
        {
            get
            {
                return new Rectangle((int)position.X - xSpeed, (int)position.Y, xSpeed, spriteHeight);
            }
        }

        public Rectangle RightLine
        {
            get
            {
                return new Rectangle((int)position.X + spriteWidth, (int)position.Y, xSpeed, spriteHeight);
            }
        }

        public Rectangle UpLine
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y - ySpeed, spriteWidth - 10, ySpeed);
            }
        }

        public Rectangle DownLine
        {
            get
            {
                return new Rectangle((int)position.X + 5, (int)position.Y + spriteHeight + (int)ySpeed, spriteWidth - 10, (int)ySpeed);
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
        
        public Vector2 StartPosition
        {
            get { return startPosition; }
            set { startPosition = value; }
        }

        public int MinY
        {
            get { return minY; }
            set { minY = value; }
        }
        
        public int MaxY
        {
            get { return maxY; }
            set { maxY = value; }
        }
        
        public int MinX
        {
            get { return minX; }
            set { minX = value; }
        }
        
        public int MaxX
        {
            get { return maxX; }
            set { maxX = value; }
        }

        public int XSpeed
        {
            get { return xSpeed; }
            set { xSpeed = value; }
        }

        public int YSpeed
        {
            get { return ySpeed; }
            set { ySpeed = value; }
        }
        

        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public Texture2D Texture
        {
            get { return spriteTexture; }
            set { spriteTexture = value; }
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

        public bool Killed
        {
            get { return killed; }
            set { killed = value; }
        }
        
        public EnemySprite(Texture2D texture, int currentFrame, int spriteWidth, int spriteHeight)
        {
            this.spriteTexture = texture;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
            this.currentFrame = currentFrame;
            this.SourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
            this.lastXCollision = 0;
            this.lastYCollision = 0;
            this.position = this.startPosition;
            
        }

        public void HandleSpriteMovement(GameTime gameTime)
        {
            //sourceRect = new Rectangle(0, 0, spriteWidth, spriteHeight);

            if (collisionUp || position.Y < minY)
            {
                lastYCollision = 0;
            }

            if (collisionDown || position.Y > maxY)
            {
                lastYCollision = 1;
            }
            
            if (collisionLeft || position.X < minX)
            {
                lastXCollision = 0;
            }
            
            if (collisionRight || position.X > maxX)
            {
                lastXCollision = 1;
            }

            
            if (lastXCollision == 0)
            {
                position.X += xSpeed;
            }

            if (lastXCollision == 1)
            {
                position.X -= xSpeed;
            }

            if (lastYCollision == 0)
            {
                position.Y += ySpeed;
            }

            if (lastYCollision == 1)
            {
                position.Y -= ySpeed;
            }

            if (killed)
            {
                position.Y += 10;
            }

            origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);

        }


    }
}

