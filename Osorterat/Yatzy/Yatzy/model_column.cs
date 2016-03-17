using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Yatzy
{
    class model_column
    {
        private string name;
        private int totalScore;
        private bool finished = false;
        private List<model_category> categories = new List<model_category>();

        public model_column()
        {
        }
                       
        public List<model_category> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Finished
        {
            get { return finished; }
            set { finished = value; }
        }

        public int TotalScore
        {
            get 
            {
                totalScore = 0;
                foreach (model_category category in categories)
                {
                    totalScore = totalScore + category.Score;
                }
            
                return totalScore;
            }
        }
        

    }
}
