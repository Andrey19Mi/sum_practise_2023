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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            okButton.DialogResult = DialogResult.OK;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        public string WidthText
        {
            get { return widthTextBox.Text; }
        }

        public string HeightText
        {
            get { return heightTextBox.Text; }
        }

        public bool CreateNew
        {
            get { return checkBox.Checked; }
        }
        public CheckBox CheckBox
        {
            get { return checkBox; }
        }

    }
}
