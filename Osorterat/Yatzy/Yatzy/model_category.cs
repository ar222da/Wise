using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{
    class model_category
    {
        private int id;
        private string title;
        private int score;

        public model_category()
        {
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

    }
}
