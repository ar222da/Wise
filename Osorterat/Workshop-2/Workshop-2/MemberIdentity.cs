using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Workshop_2
{
    class MemberIdentity
    {
        private int memberIdentityCounter;

        public int MemberIdentityCounter
        {
            get{return memberIdentityCounter;}
            set{memberIdentityCounter = value;}
        }

        public MemberIdentity()
        {
            int counter;
            
            using (StreamReader reader = new StreamReader("MemberIdentity.txt"))
            {
                counter = int.Parse(reader.ReadLine());
            }
            
            memberIdentityCounter = counter;
            counter++;
            
            using (StreamWriter writer = new StreamWriter("MemberIdentity.txt", false))
            {
                writer.Write(counter);
            }
        }
    }
}
