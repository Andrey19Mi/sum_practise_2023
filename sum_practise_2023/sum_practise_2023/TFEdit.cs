using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sum_practise_2023
{
    public partial class TFEdit : Form
    {
        Label _source;
        public TFEdit()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            LoadFonts();
        }
        private void LoadFonts()
        {
            InstalledFontCollection installedFonts = new InstalledFontCollection();
            foreach (FontFamily fontFamily in installedFonts.Families)
            {
                FontBox.Items.Add(fontFamily.Name);
            }
        }
        public void StartParams(ref Label l)
        {
            Size size;
            _source = l;
            richTextBox1.Text = _source.Text;
            VCButton.Value = (decimal)_source.Font.Size;
            size = _source.Size;
            WSButton.Value = size.Width;
            HSButton.Value = size.Height;
            FontStyle currentStyle = _source.Font.Style;
            for (int i = 0; i < checkedListTS.Items.Count; i++)
            {
                switch (checkedListTS.Items[i].ToString())
                {
                    case "Bold":
                        checkedListTS.SetItemChecked(i, currentStyle.HasFlag(FontStyle.Bold));
                        break;
                    case "Italic":
                        checkedListTS.SetItemChecked(i, currentStyle.HasFlag(FontStyle.Italic));
                        break;
                    case "Underline":
                        checkedListTS.SetItemChecked(i, currentStyle.HasFlag(FontStyle.Underline));
                        break;
                    case "Strikeout":
                        checkedListTS.SetItemChecked(i, currentStyle.HasFlag(FontStyle.Strikeout));
                        break;
                }
            }
            richTextBox1.Font = _source.Font;
            FontBox.Text = _source.Font.Name;
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CloseButton_TC(object sender, EventArgs e)
        {
            _source.Text = richTextBox1.Text;
        }

        private void VCButton_Click(object sender, EventArgs e)
        {
            _source.Font = new Font(_source.Font.FontFamily, (float)VCButton.Value);
            richTextBox1.Font = new Font(_source.Font.FontFamily, (float)VCButton.Value);
        }

        private void HSChange(object sender, EventArgs e)
        {
             _source.Size = new Size((int)WSButton.Value, (int)HSButton.Value);
        }


        private void WSChange(object sender, EventArgs e)
        {
            _source.Size = new Size((int)WSButton.Value, (int)HSButton.Value);
        }
        private void FontBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedFont = (string)comboBox.SelectedItem;
            _source.Font = new Font(selectedFont, _source.Font.Size, _source.Font.Style);
            comboBox.Text = _source.Font.Name;
            richTextBox1.Font = _source.Font;
        }
        private void checkedListTS_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox list = (CheckedListBox)sender;

            FontStyle style = _source.Font.Style;

            if (e.NewValue == CheckState.Checked)
            {
                switch (list.Items[e.Index].ToString())
                {
                    case "Bold":
                        style |= FontStyle.Bold;
                        break;
                    case "Italic":
                        style |= FontStyle.Italic;
                        break;
                    case "Underline":
                        style |= FontStyle.Underline;
                        break;
                    case "Strikeout":
                        style |= FontStyle.Strikeout;
                        break;
                }
            }
            else
            {
                switch (list.Items[e.Index].ToString())
                {
                    case "Bold":
                        style &= ~FontStyle.Bold;
                        break;
                    case "Italic":
                        style &= ~FontStyle.Italic;
                        break;
                    case "Underline":
                        style &= ~FontStyle.Underline;
                        break;
                    case "Strikeout":
                        style &= ~FontStyle.Strikeout;
                        break;
                }
            }
            _source.Font = new Font(_source.Font, style);
            richTextBox1.Font = _source.Font;
        }

        public enum FontStyleCheck
        {
            Bold = 0,
            Italic = 1,
            Underline = 2,
            Strikeout = 3
        }

    }
}
