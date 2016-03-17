using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_2
{
    public enum ModelBoatType
    {
        Segelbåt,
        Motorseglare,
        Motorbåt,
        Kajak,
        Övrigt
    }

    class ModelBoat
    {
        private int identity;
        private int memberIdentity;
        private ModelBoatType boatType;
        private int length;

        public int Identity
        {
            get{return identity;}
            set{identity = value;}
        }

        public int MemberIdentity
        {
            get{return memberIdentity;}
            set{memberIdentity = value;}
        }

        public ModelBoatType BoatType
        {
            get{return boatType;}
            set{boatType = value;}
        }

        public int Length
        {
            get{return length;}
            set{length = value;}
        }

        public ModelBoat(int identity, int memberIdentity, ModelBoatType boatType, int length)
        {
            Identity = identity;
            MemberIdentity = memberIdentity;
            BoatType = boatType;
            Length = length;

        }
    }
}
