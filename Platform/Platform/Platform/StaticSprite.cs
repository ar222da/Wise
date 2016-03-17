using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Platform
{
    class StaticSprite
    {
        Texture2D spriteTexture;
        int spriteWidth;
        int spriteHeight;
        int currentFrame;
        Rectangle sourceRect;
        Vector2 position;
        Vector2 origin;
        int moving;
        int xSpeed;
        int ySpeed;
        int minX;
        int maxX;
        int minY;
        int maxY;
        int counter;

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

        public Texture2D Texture
        {
            get { return spriteTexture; }
            set { spriteTexture = value; }
        }
        
        public int Moving
        {
            get { return moving; }
            set { moving = value; }
        }

        public int Counter
        {
            get { return counter; }
            set { counter = value; }
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
        

        public StaticSprite(Texture2D texture, int spriteWidth, int spriteHeight)
        {
            this.spriteTexture = texture;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
        }

        public void HandleSpriteMovement(GameTime gameTime)
        {
            
            
            if (moving == 1)
            {

            }
        }

    }
}
