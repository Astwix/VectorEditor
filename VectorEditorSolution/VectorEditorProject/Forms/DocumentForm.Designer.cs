namespace VectorEditorProject.Forms
{
    partial class DocumentForm
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
            this.documentNameTextBox = new System.Windows.Forms.TextBox();
            this.documentNameLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.heightLabel = new System.Windows.Forms.Label();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // documentNameTextBox
            // 
            this.documentNameTextBox.Location = new System.Drawing.Point(184, 12);
            this.documentNameTextBox.Name = "documentNameTextBox";
            this.documentNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.documentNameTextBox.TabIndex = 0;
            // 
            // documentNameLabel
            // 
            this.documentNameLabel.AutoSize = true;
            this.documentNameLabel.Location = new System.Drawing.Point(12, 15);
            this.documentNameLabel.Name = "documentNameLabel";
            this.documentNameLabel.Size = new System.Drawing.Size(82, 17);
            this.documentNameLabel.TabIndex = 1;
            this.documentNameLabel.Text = "Имя файла";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(12, 43);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(97, 17);
            this.widthLabel.TabIndex = 3;
            this.widthLabel.Text = "Ширина, пикс";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(184, 40);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(100, 22);
            this.widthTextBox.TabIndex = 2;
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(12, 71);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(95, 17);
            this.heightLabel.TabIndex = 5;
            this.heightLabel.Text = "Высота, пикс";
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(184, 68);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(100, 22);
            this.heightTextBox.TabIndex = 4;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(12, 99);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(41, 17);
            this.colorLabel.TabIndex = 6;
            this.colorLabel.Text = "Цвет";
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(184, 96);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(100, 23);
            this.colorButton.TabIndex = 7;
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(184, 159);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(100, 23);
            this.OKButton.TabIndex = 8;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // DocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 191);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.documentNameLabel);
            this.Controls.Add(this.documentNameTextBox);
            this.MaximumSize = new System.Drawing.Size(314, 238);
            this.MinimumSize = new System.Drawing.Size(314, 238);
            this.Name = "DocumentForm";
            this.Text = "Document";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox documentNameTextBox;
        private System.Windows.Forms.Label documentNameLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}