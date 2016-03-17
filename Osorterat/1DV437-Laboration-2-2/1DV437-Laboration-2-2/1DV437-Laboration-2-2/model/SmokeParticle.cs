using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace _1DV437_Laboration_2_2.model
{
    class SmokeParticle
    {
        public Vector2 startPosition;
        public Vector2 centerPosition;
        public Vector2 velocity;

        public float maxTimeToLive;
        public float timeLived;
        public float maxSize;
        public float minSize;
        public float size;

        public float upwardAcceleration = 0.2F;

        public SmokeParticle(Vector2 startPosition, Vector2 velocity, float maxTimeToLive, float maxSize)
        {
            centerPosition = startPosition;
            this.startPosition.X = 0.5F;
            this.startPosition.Y = 0.5F;

            this.velocity = velocity;
            this.maxTimeToLive = maxTimeToLive;
            this.maxSize = maxSize;
            this.minSize = 0.5F;
            timeLived = 0;
        }

        public void Update(float elapsedTimeSeconds)
        {
            timeLived += elapsedTimeSeconds;
            float lifePercent = timeLived / maxTimeToLive;
            size = minSize + lifePercent * maxSize;
            velocity.Y += upwardAcceleration * elapsedTimeSeconds;
            centerPosition -= velocity * elapsedTimeSeconds;

            if (lifePercent >= 1.0F)
            {
                size = minSize;
                centerPosition = startPosition;
                timeLived = 0;
                velocity.Y = 0;
            }
        }



    }
}
