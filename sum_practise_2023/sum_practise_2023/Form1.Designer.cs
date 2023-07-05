namespace sum_practise_2023
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.main = new System.Windows.Forms.Panel();
            this.MoveButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddTextButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CreateNewButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // main
            // 
            this.main.AutoScroll = true;
            this.main.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.main.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.main.Location = new System.Drawing.Point(0, 26);
            this.main.Margin = new System.Windows.Forms.Padding(2);
            this.main.Name = "main";
            this.main.Size = new System.Drawing.Size(484, 285);
            this.main.TabIndex = 0;
            this.main.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // MoveButton
            // 
            this.MoveButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.MoveButton.Location = new System.Drawing.Point(22, 0);
            this.MoveButton.Margin = new System.Windows.Forms.Padding(2);
            this.MoveButton.Name = "MoveButton";
            this.MoveButton.Size = new System.Drawing.Size(22, 25);
            this.MoveButton.TabIndex = 1;
            this.MoveButton.Text = "M";
            this.MoveButton.UseVisualStyleBackColor = true;
            this.MoveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.EditButton.Location = new System.Drawing.Point(0, 0);
            this.EditButton.Margin = new System.Windows.Forms.Padding(2);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(22, 25);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "E";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AddTextButton
            // 
            this.AddTextButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddTextButton.Location = new System.Drawing.Point(44, 0);
            this.AddTextButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddTextButton.Name = "AddTextButton";
            this.AddTextButton.Size = new System.Drawing.Size(22, 25);
            this.AddTextButton.TabIndex = 3;
            this.AddTextButton.Text = "T";
            this.AddTextButton.UseVisualStyleBackColor = true;
            this.AddTextButton.Click += new System.EventHandler(this.AddTextButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.LoadButton.Location = new System.Drawing.Point(462, 0);
            this.LoadButton.Margin = new System.Windows.Forms.Padding(2);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(22, 25);
            this.LoadButton.TabIndex = 4;
            this.LoadButton.Text = "L";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SaveButton.Location = new System.Drawing.Point(440, 0);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(22, 25);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "S";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.CreateNewButton);
            this.panel1.Controls.Add(this.AddTextButton);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Controls.Add(this.MoveButton);
            this.panel1.Controls.Add(this.LoadButton);
            this.panel1.Controls.Add(this.EditButton);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 25);
            this.panel1.TabIndex = 6;
            // 
            // CreateNewButton
            // 
            this.CreateNewButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CreateNewButton.Location = new System.Drawing.Point(418, 0);
            this.CreateNewButton.Margin = new System.Windows.Forms.Padding(2);
            this.CreateNewButton.Name = "CreateNewButton";
            this.CreateNewButton.Size = new System.Drawing.Size(22, 25);
            this.CreateNewButton.TabIndex = 6;
            this.CreateNewButton.Text = "F";
            this.CreateNewButton.UseVisualStyleBackColor = true;
            this.CreateNewButton.Click += new System.EventHandler(this.CreateNewButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.main);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.FormResizeEnd);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel main;
        private System.Windows.Forms.Button MoveButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddTextButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CreateNewButton;
    }
}

