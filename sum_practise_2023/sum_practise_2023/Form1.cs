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
        static TFEdit fe;
        public Form1()
        {
            InitializeComponent();
            dm = new Document(main);
            fe = new TFEdit();
        }
        public static void StartEditing(Label l)
        {
            fe.StartParams(ref l);
            fe.ShowDialog();
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
            // TODO: use file explorer dialog to chose filename where to save
            dm.SaveComponentsToJson("SavedData.json");
        }
        private void LoadButton_Click(object sender, EventArgs e)
        {
            // TODO: use file explorer dialog to chose filename to load from
            dm.LoadComponentsFromJson("SavedData.json");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // TODO: DO shortcuts 
            // press button to change modes
            // e - edit
            // m/v - view
            // t - add text
            // ctrl+s save file to file from where it was loaded, if none was loaded just invoke savebutton
        }
    }
}
