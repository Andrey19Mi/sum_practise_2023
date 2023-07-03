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
            KeyDown += Form1_KeyDown;
            KeyPreview = true;
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
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    dm.SaveComponentsToJson(sfd.FileName);
                }
            }
        }
        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                dm.LoadComponentsFromJson(filePath);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().ToLower() == "e")
            {
                MoveButton_Click(sender, e);
            }
            else if (e.KeyChar.ToString().ToLower() == "m" || e.KeyChar.ToString().ToLower() == "v")
            {
                EditButton_Click(sender, e);
            }
            else if (e.KeyChar.ToString().ToLower() == "t")
            {
                AddTextButton_Click(sender, e);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveButton_Click(sender, e);
            }
        }
    }
}
