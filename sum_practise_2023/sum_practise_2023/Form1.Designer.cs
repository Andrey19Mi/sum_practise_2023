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
            this.SuspendLayout();
            // 
            // main
            // 
            this.main.AutoScroll = true;
            this.main.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.main.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.main.Location = new System.Drawing.Point(0, 38);
            this.main.Name = "main";
            this.main.Size = new System.Drawing.Size(800, 412);
            this.main.TabIndex = 0;
            this.main.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // MoveButton
            // 
            this.MoveButton.Location = new System.Drawing.Point(12, 9);
            this.MoveButton.Name = "MoveButton";
            this.MoveButton.Size = new System.Drawing.Size(29, 23);
            this.MoveButton.TabIndex = 1;
            this.MoveButton.Text = "M";
            this.MoveButton.UseVisualStyleBackColor = true;
            this.MoveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(47, 9);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(29, 23);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "E";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AddTextButton
            // 
            this.AddTextButton.Location = new System.Drawing.Point(82, 9);
            this.AddTextButton.Name = "AddTextButton";
            this.AddTextButton.Size = new System.Drawing.Size(29, 23);
            this.AddTextButton.TabIndex = 3;
            this.AddTextButton.Text = "T";
            this.AddTextButton.UseVisualStyleBackColor = true;
            this.AddTextButton.Click += new System.EventHandler(this.AddTextButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddTextButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.MoveButton);
            this.Controls.Add(this.main);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel main;
        private System.Windows.Forms.Button MoveButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddTextButton;
    }
}

