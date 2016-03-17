using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_2
{
    class ModelMemberList
    {
        private List<ModelMember> memberList = new List<ModelMember>();
        
        public List<ModelMember> MemberList
        {
            get {return memberList;}
            set {memberList = value;}
        }

        public void AddMember(ModelMember member)
        {
            MemberList.Add(member);
        }

        public void DeleteMember(int memberIdentity)
        {
            int i = 0;
            foreach (ModelMember member in MemberList)
            {
                if (member.Identity == memberIdentity)
                {
                    MemberList.RemoveAt(i);
                    break;
                }
                i++;
            }
        }

        public void Update()
        {
        }

        public void ModelMemberList()
        {

        }
    }
}
