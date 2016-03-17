using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{
    class model_player
    {
        model_playerType playerType;
        private string name;
        private model_column column;

        public model_player()
        {
        }

        public model_playerType PlayerType
        {
            get { return playerType; }
            set { playerType = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public model_column Column
        {
            get { return column; }
            set { column = value; }
        }

    
    }
}
