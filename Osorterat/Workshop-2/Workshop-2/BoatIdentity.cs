using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Workshop_2
{
    class BoatIdentity
    {
        private int boatIdentityCounter;

        public int BoatIdentityCounter
        {
            get{return boatIdentityCounter;}
            set{boatIdentityCounter = value;}
        }

        public BoatIdentity()
        {
            int counter;
            
            using (StreamReader reader = new StreamReader("BoatIdentity.txt"))
            {
                counter = int.Parse(reader.ReadLine());
            }
            
            boatIdentityCounter = counter;
            counter++;
            
            using (StreamWriter writer = new StreamWriter("BoatIdentity.txt", false))
            {
                writer.Write(counter);
            }
        }

    }
}
