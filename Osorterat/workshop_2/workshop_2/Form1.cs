using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workshop_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(435, 400);
            ModelMemberList m = new ModelMemberList();
            ModelMember memb = new ModelMember();
            /*memb.Name = "Ola Robelius";
            memb.MPIN = "4010261111";
            memb.MID = 143212;
            memb.NumberOfBoats = 3;
            m.addMember(memb);
            m.saveMembers();*/
            m.loadMembers();

            drawListView(m);
        }

        public void drawListView(ModelMemberList memberList)
        {
            ListView listView1 = new ListView();
            listView1.Bounds = new Rectangle(new Point(10, 10), new Size(400, 200));
            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.MultiSelect = false;
            listView1.Sorting = SortOrder.Ascending;

            foreach (ModelMember member in memberList.Members)
            {
                ListViewItem item = new ListViewItem(member.Name.ToString());
                item.SubItems.Add(member.MPIN.ToString());
                item.SubItems.Add(member.MID.ToString());
                item.SubItems.Add(member.NumberOfBoats.ToString());
                listView1.Items.Add(item);
            }

            listView1.Columns.Add("Namn", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Personnummer", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Medlemsnummer", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Antal båtar", -2, HorizontalAlignment.Left);

            this.Controls.Add(listView1);
        }

        
    }
}
