using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop_2_senaste
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelMemberList m = new ModelMemberList();
            m.loadMembers();
            m.loadBoats();
            MemberView v = new MemberView();
            v.Grid(10, 5, m);
        }
    }
}
