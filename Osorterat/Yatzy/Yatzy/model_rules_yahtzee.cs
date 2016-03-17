using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Yatzy
{
    class model_rules_yahtzee : Imodel_rules
    {
        private int ones;
        private int twos;
        private int threes;
        private int fours;
        private int fives;
        private int sixes;
        private int numberOfDice = 5;
        private List<model_category> categories = new List<model_category>();

        public List<model_category> Categories
        {
            get { return categories; }
        }

        public int NumberOfDice
        {
            get { return numberOfDice; }
        }

        public void loadCategories()
        {
            using (StreamReader reader = new StreamReader("YatzyCategories.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(':');
                    model_category category = new model_category();
                    category.Id = int.Parse(fields[0]);
                    category.Title = fields[1];
                    categories.Add(category);
                }
            }
        }

        public model_column getColumn()
        {
            model_column column = new model_column();
            using (StreamReader reader = new StreamReader("YatzyCategories.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(':');
                    model_category category = new model_category();
                    category.Id = int.Parse(fields[0]);
                    category.Title = fields[1];
                    category.Score = 0;
                    column.Categories.Add(category);
                }
            }
            
            return column;
        }


        public void checkPossibleCategories(List<model_die> dice)
        {
            foreach (model_category category in categories)
            {
                category.Score = 0;
            }

            ones = twos = threes = fours = fives = sixes = 0;

            foreach (model_die die in dice)
            {
                if (die.FaceValue == 1)
                {
                    ones++;
                }
                if (die.FaceValue == 2)
                {
                    twos++;
                }
                if (die.FaceValue == 3)
                {
                    threes++;
                }
                if (die.FaceValue == 4)
                {
                    fours++;
                }
                if (die.FaceValue == 5)
                {
                    fives++;
                }
                if (die.FaceValue == 6)
                {
                    sixes++;
                }
            }

                categories[0].Score = ones * 1;
                categories[1].Score = twos * 2;
                categories[2].Score = threes * 3;
                categories[3].Score = fours * 4;
                categories[4].Score = fives * 5;
                categories[5].Score = sixes * 6;
                
                // Chance
                categories[13].Score = (ones * 1) + (twos * 2) + (threes * 3) + (fours * 4) + (fives * 5) + (sixes * 6);

                // Three-of-a-kind
                if (ones == 3)
                {
                    categories[7].Score = 3 + (twos * 2) + (threes * 3) + (fours * 4) + (fives * 5) + (sixes * 6);
                }

                if (twos == 3)
                {
                    categories[7].Score = 6 + (ones * 1) + (threes * 3) + (fours * 4) + (fives * 5) + (sixes * 6);
                }

                if (threes == 3)
                {
                    categories[7].Score = 9 + (ones * 1) + (twos * 2) + (fours * 4) + (fives * 5) + (sixes * 6);
                }

                if (fours == 3)
                {
                    categories[7].Score = 12 + (ones * 1) + (twos * 2) + (threes * 3) + (fives * 5) + (sixes * 6);
                }

                if (fives == 3)
                {
                    categories[7].Score = 15 + (ones * 1) + (twos * 2) + (fours * 4) + (sixes * 6);
                }

                if (sixes == 3)
                {
                    categories[7].Score = 18 + (ones * 1) + (twos * 2) + (threes * 3) + (fours * 4) + (fives * 5);
                }

                // Four-of-a-kind
                if (ones == 4)
                {
                    categories[8].Score = 4 + (twos * 2) + (threes * 3) + (fours * 4) + (fives * 5) + (sixes * 6);
                }

                if (twos == 4)
                {
                    categories[8].Score = 8 + (ones * 1) + (threes * 3) + (fours * 4) + (fives * 5) + (sixes * 6);
                }

                if (threes == 4)
                {
                    categories[8].Score = 12 + (ones * 1) + (twos * 2) + (fours * 4) + (fives * 5) + (sixes * 6);
                }

                if (fours == 4)
                {
                    categories[8].Score = 16 + (ones * 1) + (twos * 2) + (threes * 3) + (fives * 5) + (sixes * 6);
                }

                if (fives == 4)
                {
                    categories[8].Score = 20 + (ones * 1) + (twos * 2) + (fours * 4) + (sixes * 6);
                }

                if (sixes == 4)
                {
                    categories[8].Score = 24 + (ones * 1) + (twos * 2) + (threes * 3) + (fours * 4) + (fives * 5);
                }

                // Full House
                if ((ones == 3 || twos == 3 || threes == 3 || fours == 3 || fives == 3 || sixes == 3) &&
                (ones == 2 || twos == 2 || threes == 2 || fours == 2 || fives == 2 || sixes == 2))
                {
                    categories[9].Score = 25;
                }

                // Small Straight
                if ((ones >= 1 && twos >= 1 && threes >= 1 && fours >= 1) || (twos >= 1 && threes >= 1 && fours >= 1 && fives >= 1)
                || (threes >= 1 && fours >= 1 && fives >= 1 && sixes >= 1))
                {
                    categories[10].Score = 30;
                }

                // Large Straight
                if ((ones == 1 && twos == 1 && threes == 1 && fours == 1 && fives == 1) || (twos == 1 && threes == 1 && fours == 1 && fives == 1 && sixes == 1))
                {
                    categories[11].Score = 40;
                }

                // Yahtzee
                if (ones == 5 || twos == 5 || threes == 5 || fours == 5 || fives == 5 || sixes == 5)
                {
                    categories[12].Score = 50;
                }

            }

        public void bonus(model_column column)
        {
            if ((column.Categories[0].Score + column.Categories[1].Score + column.Categories[2].Score + column.Categories[3].Score
                + column.Categories[4].Score + column.Categories[5].Score) >= 63)
            {
                column.Categories[6].Score = 35;
            }
        }

        public void finished(model_column column)
        {
            bool foundEmpty = false;
            foreach (model_category category in column.Categories)
            {
                if (category.Score == 0 && category.Id != 6)
                {
                    foundEmpty = true;
                    break;
                }
            }

            if (foundEmpty == false)
            {
                column.Finished = true;
            }
            
            else
            {
                column.Finished = false;
            }
        }

        public List<int> calculation(List<model_die> dice, int categoryId)
        {
            ones = twos = threes = fours = fives = sixes = 0;

            foreach (model_die die in dice)
            {
                if (die.FaceValue == 1)
                {
                    ones++;
                }
                if (die.FaceValue == 2)
                {
                    twos++;
                }
                if (die.FaceValue == 3)
                {
                    threes++;
                }
                if (die.FaceValue == 4)
                {
                    fours++;
                }
                if (die.FaceValue == 5)
                {
                    fives++;
                }
                if (die.FaceValue == 6)
                {
                    sixes++;
                }
            }
            List<int> indexList = new List<int>();

            if (categoryId == 0 && ones >= 1)
            {
                for (int i = 0; i < dice.Count; i++)
                {
                    if (dice[i].FaceValue == 1)
                    {
                        indexList.Add(i);
                    }
                }

                return indexList;
            }

            if (categoryId == 1 && twos >= 1)
            {
                for (int i = 0; i < dice.Count; i++)
                {
                    if (dice[i].FaceValue == 2)
                    {
                        indexList.Add(i);
                    }
                }

                return indexList;
            }

            if (categoryId == 2 && threes >= 1)
            {
                for (int i = 0; i < dice.Count; i++)
                {
                    if (dice[i].FaceValue == 3)
                    {
                        indexList.Add(i);
                    }
                }

                return indexList;
            }

            if (categoryId == 3 && fours >= 1)
            {
                for (int i = 0; i < dice.Count; i++)
                {
                    if (dice[i].FaceValue == 4)
                    {
                        indexList.Add(i);
                    }
                }

                return indexList;
            }

            if (categoryId == 4 && fives >= 1)
            {
                for (int i = 0; i < dice.Count; i++)
                {
                    if (dice[i].FaceValue == 5)
                    {
                        indexList.Add(i);
                    }
                }

                return indexList;
            }

            if (categoryId == 5 && sixes >= 1)
            {
                for (int i = 0; i < dice.Count; i++)
                {
                    if (dice[i].FaceValue == 6)
                    {
                        indexList.Add(i);
                    }
                }

                return indexList;
            }

            // Three-of-a-kind, Four-of-a-kind
            if ((categoryId == 7 || categoryId == 8) && (sixes >= 1 || fives >= 1 || fours >= 1 || threes >= 1 || twos >= 1 || ones >= 1))
            {
                List<int> faceValues = new List<int>();

                faceValues.Add(ones);
                faceValues.Add(twos);
                faceValues.Add(threes);
                faceValues.Add(fours);
                faceValues.Add(fives);
                faceValues.Add(sixes);
                faceValues.Sort();
                int numberOfFaceValue = faceValues[faceValues.Count - 1];

                if (ones == numberOfFaceValue)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 1)
                        {
                            indexList.Add(i);
                        }
                    }
                }
                else if (twos == numberOfFaceValue)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 2)
                        {
                            indexList.Add(i);
                        }
                    }
                }
                else if (threes == numberOfFaceValue)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 3)
                        {
                            indexList.Add(i);
                        }
                    }
                }
                else if (fours == numberOfFaceValue)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 4)
                        {
                            indexList.Add(i);
                        }
                    }
                }
                else if (fives == numberOfFaceValue)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 5)
                        {
                            indexList.Add(i);
                        }
                    }
                }
                else if (sixes == numberOfFaceValue)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 6)
                        {
                            indexList.Add(i);
                        }
                    }
                }
                return indexList;
            }

            // Full House
            if (categoryId == 9)
            {
                if (ones >= 2)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 1)
                        {
                            indexList.Add(i);
                        }
                    }
                }
                if (twos >= 2)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 2)
                        {
                            indexList.Add(i);
                        }
                    }
                }
                if (threes >= 2)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 3)
                        {
                            indexList.Add(i);
                        }
                    }
                }
                if (fours >= 2)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 4)
                        {
                            indexList.Add(i);
                        }
                    }
                }
                if (fives >= 2)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 5)
                        {
                            indexList.Add(i);
                        }
                    }
                }
                if (sixes >= 2)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 6)
                        {
                            indexList.Add(i);
                        }
                    }
                }

                return indexList;

            }

            // Small or Large Straight
            if (categoryId == 10 || categoryId == 11)
            {
                bool onesFound = false;
                bool twosFound = false;
                bool threesFound = false;
                bool foursFound = false;
                bool fivesFound = false;
                bool sixesFound = false;

                if ((ones >= 1 && twos >= 1) || (twos >= 1 && threes >= 1) || (threes >= 1 && fours >= 1)
                    || (fours >= 1 && fives >= 1) || (fives >= 1 && sixes >= 1))
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 1 && !onesFound)
                        {
                            indexList.Add(i);
                            onesFound = true;
                        }
                        if (dice[i].FaceValue == 2 && !twosFound)
                        {
                            indexList.Add(i);
                            twosFound = true;
                        }
                        if (dice[i].FaceValue == 3 && !threesFound)
                        {
                            indexList.Add(i);
                            threesFound = true;
                        }
                        if (dice[i].FaceValue == 4 && !foursFound)
                        {
                            indexList.Add(i);
                            foursFound = true;
                        }
                        if (dice[i].FaceValue == 5 && !fivesFound)
                        {
                            indexList.Add(i);
                            fivesFound = true;
                        }
                        if (dice[i].FaceValue == 6 && !sixesFound)
                        {
                            indexList.Add(i);
                            sixesFound = true;
                        }
                    }
                }

                return indexList;
            }

            // Yathzee
            if (categoryId == 12)
            {
                if (ones >= 2)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 1)
                        {
                            indexList.Add(i);
                        }
                    }
                }
                else if (twos >= 2)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 2)
                        {
                            indexList.Add(i);
                        }
                    }
                }
                else if (threes >= 2)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 3)
                        {
                            indexList.Add(i);
                        }
                    }
                }
                else if (fours >= 2)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 4)
                        {
                            indexList.Add(i);
                        }
                    }
                }
                else if (fives >= 2)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 5)
                        {
                            indexList.Add(i);
                        }
                    }
                }
                else if (sixes >= 2)
                {
                    for (int i = 0; i < dice.Count; i++)
                    {
                        if (dice[i].FaceValue == 6)
                        {
                            indexList.Add(i);
                        }
                    }
                }

                return indexList;
            }

            return indexList;
        }
            

        

    
    
    }

}