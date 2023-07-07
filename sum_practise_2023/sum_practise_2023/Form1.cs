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
        SaveFileDialog sfd;
        OpenFileDialog ofd;
        SettingsForm settingsForm;
        bool once = true;

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
            
        }
        private void CreatePanel(ref SettingsForm settingsForm)
        {
            PointF dpi = dm.getDPI();
            
            settingsForm.WidthText = ( ((float)main.Width)/dpi.X ).ToString();
            settingsForm.HeightText = ( ((float)main.Height)/dpi.Y ).ToString();
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                float width, height;
                if (float.TryParse(settingsForm.WidthText, out width) && float.TryParse(settingsForm.HeightText, out height))
                {
                    dm.Size = new PointF(width, height);
                }
                if (settingsForm.CreateNew)
                {
                    dm.DeleteComponents();
                }
            }
        }
        public static void StartEditing(Label l)
        {
            fe.StartParams(ref l);
            fe.ShowDialog();
            
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (once)
            {
                
                once = false;
                CreatePanel(ref settingsForm);
            }
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
            }else if (e.Control && e.KeyCode == Keys.P)
            {
                // print  TODO : need to make a button
                dm.SaveComponentsToPDF("document.pdf");
            }
        }

        private void CreateNewButton_Click(object sender, EventArgs e)
        {
            settingsForm.CheckBox.Visible = true;
            CreatePanel(ref settingsForm);
        }

        private void main_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(main.Width,main.Height + panel1.Height + 40);
            
        }

        private void PDFConvert_Button_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Устанавливаем фильтр для типа файлов
            saveFileDialog.Filter = "PDF Files|*.pdf";

            // Показываем диалоговое окно для сохранения файла
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Получаем путь к файлу
                    var filePath = saveFileDialog.FileName;

                    // Передаем путь файла в функцию создания PDF
                    dm.ConvertPanelToPDF(main, filePath);
                }
                catch (Exception ex)
                {
                    // Обработайте исключение, как это нужно в вашем приложении
                    MessageBox.Show("Error: Could not save file. " + ex.Message);
                }

            }
        }
    }
}
