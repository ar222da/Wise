using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{
    class model_turn
    {
        private List<model_die> dice = new List<model_die>();
        private int numberOfThrowsLeft;
        
        public model_turn(int numberOfDice)
        {
            for (int i = 0; i < numberOfDice; i++)
            {
                model_die die = new model_die();
                dice.Add(die);
            }
        }

        public List<model_die> Dice
        {
            get { return dice; }
            set { dice = value; }
        }

        public int NumberOfThrowsLeft
        {
            get { return numberOfThrowsLeft; }
            set { numberOfThrowsLeft = value; }
        }

        public void newTurn()
        {
            numberOfThrowsLeft = 3;
            foreach (model_die die in dice)
            {
                die.Hold = false;
            }
        }

        public void throwDice()
        {
            for (int i = 0; i < dice.Count; i++)
            {
                if (dice[i].Hold == false)
                {
                    dice[i].Throw();
                }
            }

            numberOfThrowsLeft--;
  
        }

    }
}
