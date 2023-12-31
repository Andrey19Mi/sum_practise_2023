﻿namespace sum_practise_2023
{
    partial class TFEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.VCButton = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HSButton = new System.Windows.Forms.NumericUpDown();
            this.WSButton = new System.Windows.Forms.NumericUpDown();
            this.checkedListTS = new System.Windows.Forms.CheckedListBox();
            this.FontBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VCButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HSButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WSButton)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(388, 202);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Close";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 117);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(365, 108);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.CloseButton_TC);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Font size";
            // 
            // VCButton
            // 
            this.VCButton.Location = new System.Drawing.Point(73, 12);
            this.VCButton.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.VCButton.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.VCButton.Name = "VCButton";
            this.VCButton.Size = new System.Drawing.Size(52, 20);
            this.VCButton.TabIndex = 8;
            this.VCButton.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.VCButton.ValueChanged += new System.EventHandler(this.VCButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Width size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Height size";
            // 
            // HSButton
            // 
            this.HSButton.InterceptArrowKeys = false;
            this.HSButton.Location = new System.Drawing.Point(73, 38);
            this.HSButton.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.HSButton.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HSButton.Name = "HSButton";
            this.HSButton.Size = new System.Drawing.Size(52, 20);
            this.HSButton.TabIndex = 10;
            this.HSButton.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HSButton.ValueChanged += new System.EventHandler(this.HSChange);
            // 
            // WSButton
            // 
            this.WSButton.InterceptArrowKeys = false;
            this.WSButton.Location = new System.Drawing.Point(73, 64);
            this.WSButton.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.WSButton.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WSButton.Name = "WSButton";
            this.WSButton.Size = new System.Drawing.Size(52, 20);
            this.WSButton.TabIndex = 12;
            this.WSButton.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WSButton.ValueChanged += new System.EventHandler(this.WSChange);
            // 
            // checkedListTS
            // 
            this.checkedListTS.CheckOnClick = true;
            this.checkedListTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListTS.FormattingEnabled = true;
            this.checkedListTS.Items.AddRange(new object[] {
            "Bold",
            "Italic",
            "Underline",
            "Strikeout"});
            this.checkedListTS.Location = new System.Drawing.Point(389, 117);
            this.checkedListTS.Name = "checkedListTS";
            this.checkedListTS.Size = new System.Drawing.Size(74, 64);
            this.checkedListTS.TabIndex = 14;
            this.checkedListTS.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListTS_ItemCheck);
            // 
            // FontBox
            // 
            this.FontBox.FormattingEnabled = true;
            this.FontBox.Location = new System.Drawing.Point(73, 90);
            this.FontBox.Name = "FontBox";
            this.FontBox.Size = new System.Drawing.Size(390, 21);
            this.FontBox.TabIndex = 15;
            this.FontBox.SelectedIndexChanged += new System.EventHandler(this.FontBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Current font";
            // 
            // TFEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 239);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FontBox);
            this.Controls.Add(this.checkedListTS);
            this.Controls.Add(this.WSButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.HSButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.VCButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.backButton);
            this.Name = "TFEdit";
            this.Text = "TFEdit";
            ((System.ComponentModel.ISupportInitialize)(this.VCButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HSButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WSButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown VCButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown HSButton;
        private System.Windows.Forms.NumericUpDown WSButton;
        private System.Windows.Forms.CheckedListBox checkedListTS;
        private System.Windows.Forms.ComboBox FontBox;
        private System.Windows.Forms.Label label1;
    }
}