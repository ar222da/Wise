using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace workshop_2_senaste
{
    public class ModelMember
    {
        private List<ModelBoat> boats;
        private string name;
        private int mID;
        private string mPIN;
        private int numberOfBoats;

        public ModelMember()
        {
            Boats = new List<ModelBoat>();
        }

        public List<ModelBoat> Boats
        {
            get
            {
                return boats;
            }
            set
            {
                boats = value;
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

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string MPIN
        {
            get
            {
                return mPIN;
            }
            set
            {
                mPIN = value;
            }
        }

        public int NumberOfBoats
        {
            get
            {
                return Boats.Count;
            }
            set
            {
                numberOfBoats = value;
            }
        }

        public void addBoat(ModelBoat boat)
        {
            Boats.Add(boat);
        }

        public void updateBoat(ModelBoat boat)
        {
            foreach (ModelBoat b in Boats)
            {
                if (b.BID == boat.BID)
                {
                    b.Type = boat.Type;
                    b.MID = boat.MID;
                    b.Length = boat.Length;
                }
            }
        }

        public void deleteBoat(ModelBoat boat)
        {
            foreach (ModelBoat b in Boats)
            {
                if (b.BID == boat.BID)
                {
                    Boats.Remove(b);
                }
            } 
        }


    }
}
