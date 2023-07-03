using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sum_practise_2023
{
    public partial class Form1 : Form
    {
        Document dm;
        public Form1()
        {
            InitializeComponent();
            dm = new Document(main);
        }


        // enables moving motion
        private void MoveButton_Click(object sender, EventArgs e)
        {
            dm.mode = Document.Mode.View;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            dm.mode = Document.Mode.Edit;
        }

        private void AddTextButton_Click(object sender, EventArgs e)
        {
            dm.mode = Document.Mode.Add;
            dm.addMode = Document.AddMode.TextField;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // TODO: use file explorer dialog to chose filename where to save
            dm.SaveComponentsToJson("SavedData.json");
        }
        private void LoadButton_Click(object sender, EventArgs e)
        {
            // TODO: use file explorer dialog to chose filename to load from
            dm.LoadComponentsFromJson("SavedData.json");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.E)
                dm.mode = Document.Mode.Edit;
            else if (e.KeyCode == Keys.V)
                dm.mode = Document.Mode.View;
            else if (e.KeyCode == Keys.T)
                dm.mode = Document.Mode.Add;
            else if (e.Control && e.KeyCode == Keys.S)
            {
                if (dm.Path == null)
                    SaveButton.PerformClick();
                else
                    dm.SaveComponentsToJson(dm.Path);
            }
                

        }
    }
}
