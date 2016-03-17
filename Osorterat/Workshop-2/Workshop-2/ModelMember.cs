using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_2
{
    class ModelMember
    {
        private int identity;
        private string name;
        private int personalIdentityNumber;
        private List<ModelBoat> boats = new List<ModelBoat>();

        public int Identity
        {
            get{return identity;}
            set{identity = value;}
        }

        public string Name
        {
            get{return name;}
            set{name = value;}
        }

        public int PersonalIdentityNumber
        {
            get{return personalIdentityNumber;}
            set{personalIdentityNumber = value;}
        }

        public List<ModelBoat> Boats
        {
            get {return boats;}
            set {boats = value;}
        }

        public ModelMember(int identity, string name, int personalIdentityNumber)
        {
            Identity = identity;
            Name = name;
            PersonalIdentityNumber = personalIdentityNumber;
        }

        public void AddBoat(ModelBoat boat)
        {
            Boats.Add(boat);
        }

        public void DeleteBoat(int boatIdentity)
        {

        }

        public void UpdateBoat(int boatIdentity)
        {

        }

    }
}
