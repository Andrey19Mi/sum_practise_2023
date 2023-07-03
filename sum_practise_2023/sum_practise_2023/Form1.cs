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
        SaveFileDialog sfd;
        OpenFileDialog ofd;
        public Form1()
        {
            InitializeComponent();
            dm = new Document(main);
            KeyDown += Form1_KeyDown;
            KeyPreview = true;
            sfd = new SaveFileDialog();
            sfd.Filter = "JSON Files (*.json)|*.json";
            sfd.CheckPathExists = true;
            sfd.RestoreDirectory = true;
            ofd = new OpenFileDialog();
            ofd.Filter = "JSON Files (*.json)|*.json";
            ofd.CheckPathExists = true;
            ofd.RestoreDirectory = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
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
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                dm.SaveComponentsToJson(sfd.FileName);
            }
        }
        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                dm.LoadComponentsFromJson(ofd.FileName);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.E)
            {
                MoveButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.M || e.KeyCode == Keys.V)
            {
                EditButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.T)
            {
                AddTextButton_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveButton_Click(sender, e);
            }
        }
    }
}
