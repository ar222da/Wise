using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workshop_2
{
    public partial class Form1 : Form
    {
        static int i = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Size = new Size(500, 500);
            ListView listView1 = new ListView();
            listView1.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));
            listView1.MultiSelect = false;
            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Sorting = SortOrder.Ascending;

            ListViewItem item1 = new ListViewItem("item1", 0);
            item1.SubItems.Add("1");
            item1.SubItems.Add("2");
            item1.SubItems.Add("3");

            ListViewItem item2 = new ListViewItem("item2", 1);
            item2.SubItems.Add("4");
            item2.SubItems.Add("5");
            item2.SubItems.Add("6");
            
            ListViewItem item3 = new ListViewItem("item3", 0);
            item3.SubItems.Add("7");
            item3.SubItems.Add("8");
            item3.SubItems.Add("9");
            item3.SubItems.Add("10");

            // Create columns for the items and subitems. 
            // Width of -2 indicates auto-size.
            listView1.Columns.Add("Namn", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Medlemsnummer", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Antal båtar", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

            listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

           

            this.Controls.Add(listView1);
            
            
        }
    }
}
