using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace workshop_2
{
    public class ModelMemberList
    {
        private List<ModelMember> members;

        public ModelMemberList()
        {
            Members = new List<ModelMember>();
        }

        public List<ModelMember> Members
        {
            get
            {
                return members;
            }
            set
            {
                members = value;
            }
        }

        public void addMember(ModelMember member)
        {
            Members.Add(member);
        }

        public void deleteMember(ModelMember member)
        {
            foreach (ModelMember m in Members)
            {
                if (m.MID == member.MID)
                {
                    Members.Remove(m);
                }
            }
        }

        public void updateMember(ModelMember member)
        {
            foreach (ModelMember m in Members)
            {
                if (m.MID == member.MID)
                {
                    m.Name = member.Name;
                    m.MPIN = member.MPIN;
                    m.Boats = member.Boats;
                }
            }
        }

        public void loadMembers()
        {
            string line;
            string[] memberItems;
            using (StreamReader reader = new StreamReader("members.txt"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    memberItems = line.Split(':');
                    ModelMember member = new ModelMember();
                    member.MID = int.Parse(memberItems[0]);
                    member.Name = memberItems[1];
                    member.MPIN = memberItems[2];
                    member.NumberOfBoats = int.Parse(memberItems[3]);
                    Members.Add(member);
                }
            }
        }

        public void saveMembers()
        {
            using (StreamWriter writer = new StreamWriter("members.txt"))
            {
                foreach (ModelMember member in Members)
                {
                    writer.Write(member.MID);
                    writer.Write(":");
                    writer.Write(member.Name);
                    writer.Write(":");
                    writer.Write(member.MPIN);
                    writer.Write(":");
                    writer.Write(member.NumberOfBoats);
                    writer.WriteLine(":");
                    writer.Close();
                }
            }
        }



    }
}
