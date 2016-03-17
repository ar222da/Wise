using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace _1DV437_Laboration_2_2.model
{
    class SmokeSystem
    {
        public SmokeParticle[] particles = new SmokeParticle[100];

        public SmokeSystem()
        {
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                Vector2 randomVelocity = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
                Vector2 pos = new Vector2(0.5F, 0.2F);
                particles[i] = new SmokeParticle(pos, randomVelocity, 1.0F, 0.3F);
            }
        }

        public void Update(float elapsedTimeSeconds)
        {
            for (int i = 0; i < 100; i++)
            {
                particles[i].Update(elapsedTimeSeconds);
            }
        }


    }
}
