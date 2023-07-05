﻿using System;
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
        SaveFileDialog sfd;
        OpenFileDialog ofd;
        SettingsForm settingsForm;

        public Form1()
        {
            InitializeComponent();
            dm = new Document(main);
            fe = new TFEdit();
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
            settingsForm = new SettingsForm();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CreatePanel(ref settingsForm);
        }
        private void CreatePanel(ref SettingsForm settingsForm)
        {

            settingsForm.WidthText = (main.Width + 16).ToString();
            settingsForm.HeightText = main.Height.ToString();
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                int width, height;
                if (int.TryParse(settingsForm.WidthText, out width) && int.TryParse(settingsForm.HeightText, out height))
                {
                    SetPanelSize(width, height);
                }
                if (settingsForm.CreateNew)
                {
                    while (main.Controls.Count > 0)
                    {
                        main.Controls[0].Dispose();
                    }
                }
            }
        }
        private void SetPanelSize(int width, int height)
        {
            Width = width;
            main.Height = height;
            Height = height + panel1.Height + 40;
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
            else if (e.Control && e.KeyCode == Keys.S)
            {
                SaveButton_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.F)
            {
                CreateNewButton_Click(sender, e);
            }
        }

        private void CreateNewButton_Click(object sender, EventArgs e)
        {
            settingsForm.CheckBox.Visible = true;
            CreatePanel(ref settingsForm);
        }

        private void FormResizeEnd(object sender, EventArgs e)
        {
            SetPanelSize(Width, Height - (panel1.Height + 40));
        }
    }
}
