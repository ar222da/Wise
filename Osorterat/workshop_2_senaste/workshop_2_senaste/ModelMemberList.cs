using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace workshop_2_senaste
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

        public void loadBoats()
        {
            string line;
            string[] boatItems;
            using (StreamReader reader = new StreamReader("boats.txt", Encoding.Default))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    boatItems = line.Split(':');
                    foreach (ModelMember member in Members)
                    {
                        if (int.Parse(boatItems[0]) == member.MID)
                        {
                            ModelBoat boat = new ModelBoat();
                            boat.MID = int.Parse(boatItems[0]);
                            boat.BID = int.Parse(boatItems[1]);
                            boat.Type = (ModelBoatType)Enum.Parse(typeof(ModelBoatType), boatItems[2].ToString());
                            boat.Length = int.Parse(boatItems[3]);
                            member.Boats.Add(boat);
                        }
                    }
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
