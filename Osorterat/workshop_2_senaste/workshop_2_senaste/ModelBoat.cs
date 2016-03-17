using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace workshop_2_senaste
{
    public class ModelBoat
    {
        private ModelBoatType type;
        private int length;
        private int bID;
        private int mID;

        public ModelBoat()
        {

        }

        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }

        public ModelBoatType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public int BID
        {
            get
            {
                return bID;
            }
            set
            {
                bID = value;
            }
        }

        public int MID
        {
            get
            {
                return mID;
            }
            set
            {
                mID = value;
            }
        }
    }
}
