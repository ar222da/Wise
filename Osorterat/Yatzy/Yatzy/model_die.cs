using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{
    class model_die
    {
        private static readonly Random randomSeed = new Random();

        private int faceValue;
        private Random random;
        private bool hold = false;

        public model_die()
        {
            random = new Random(randomSeed.Next());
            //Throw();
        }

        public int FaceValue
        {
            get { return faceValue; }
            set { faceValue = value; }
        }

        public bool Hold
        {
            get { return hold; }
            set { hold = value; }
        }

        public int Throw()
        {
            faceValue = random.Next(1, 7);
            return faceValue;
        }

    }
}
