namespace VectorEditorProject.Forms
{
    partial class FigureSettingsControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LineColorButton = new System.Windows.Forms.Button();
            this.FillColorButton = new System.Windows.Forms.Button();
            this.LineColorLabel = new System.Windows.Forms.Label();
            this.LineWidthLabel = new System.Windows.Forms.Label();
            this.LineTypeLabel = new System.Windows.Forms.Label();
            this.FillColorLabel = new System.Windows.Forms.Label();
            this.LineWidthTextBox = new System.Windows.Forms.TextBox();
            this.LineTypeComboBox = new System.Windows.Forms.ComboBox();
            this.lineColorDialog = new System.Windows.Forms.ColorDialog();
            this.fillColorDialog = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // LineColorButton
            // 
            this.LineColorButton.Location = new System.Drawing.Point(143, 3);
            this.LineColorButton.Name = "LineColorButton";
            this.LineColorButton.Size = new System.Drawing.Size(88, 23);
            this.LineColorButton.TabIndex = 0;
            this.LineColorButton.UseVisualStyleBackColor = true;
            this.LineColorButton.Click += new System.EventHandler(this.LineColorButton_Click);
            // 
            // FillColorButton
            // 
            this.FillColorButton.Location = new System.Drawing.Point(143, 32);
            this.FillColorButton.Name = "FillColorButton";
            this.FillColorButton.Size = new System.Drawing.Size(88, 23);
            this.FillColorButton.TabIndex = 1;
            this.FillColorButton.UseVisualStyleBackColor = true;
            this.FillColorButton.Click += new System.EventHandler(this.FillColorButton_Click);
            // 
            // LineColorLabel
            // 
            this.LineColorLabel.AutoSize = true;
            this.LineColorLabel.Location = new System.Drawing.Point(3, 6);
            this.LineColorLabel.Name = "LineColorLabel";
            this.LineColorLabel.Size = new System.Drawing.Size(85, 17);
            this.LineColorLabel.TabIndex = 2;
            this.LineColorLabel.Text = "Цвет линии";
            // 
            // LineWidthLabel
            // 
            this.LineWidthLabel.AutoSize = true;
            this.LineWidthLabel.Location = new System.Drawing.Point(3, 64);
            this.LineWidthLabel.Name = "LineWidthLabel";
            this.LineWidthLabel.Size = new System.Drawing.Size(112, 17);
            this.LineWidthLabel.TabIndex = 3;
            this.LineWidthLabel.Text = "Толщина линии";
            // 
            // LineTypeLabel
            // 
            this.LineTypeLabel.AutoSize = true;
            this.LineTypeLabel.Location = new System.Drawing.Point(3, 92);
            this.LineTypeLabel.Name = "LineTypeLabel";
            this.LineTypeLabel.Size = new System.Drawing.Size(77, 17);
            this.LineTypeLabel.TabIndex = 4;
            this.LineTypeLabel.Text = "Тип линии";
            // 
            // FillColorLabel
            // 
            this.FillColorLabel.AutoSize = true;
            this.FillColorLabel.Location = new System.Drawing.Point(3, 35);
            this.FillColorLabel.Name = "FillColorLabel";
            this.FillColorLabel.Size = new System.Drawing.Size(98, 17);
            this.FillColorLabel.TabIndex = 5;
            this.FillColorLabel.Text = "Цвет заливки";
            // 
            // LineWidthTextBox
            // 
            this.LineWidthTextBox.Location = new System.Drawing.Point(143, 61);
            this.LineWidthTextBox.Name = "LineWidthTextBox";
            this.LineWidthTextBox.Size = new System.Drawing.Size(88, 22);
            this.LineWidthTextBox.TabIndex = 6;
            this.LineWidthTextBox.Text = "1";
            // 
            // LineTypeComboBox
            // 
            this.LineTypeComboBox.FormattingEnabled = true;
            this.LineTypeComboBox.Location = new System.Drawing.Point(143, 89);
            this.LineTypeComboBox.Name = "LineTypeComboBox";
            this.LineTypeComboBox.Size = new System.Drawing.Size(88, 24);
            this.LineTypeComboBox.TabIndex = 7;
            // 
            // FigureSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LineTypeComboBox);
            this.Controls.Add(this.LineWidthTextBox);
            this.Controls.Add(this.FillColorLabel);
            this.Controls.Add(this.LineTypeLabel);
            this.Controls.Add(this.LineWidthLabel);
            this.Controls.Add(this.LineColorLabel);
            this.Controls.Add(this.FillColorButton);
            this.Controls.Add(this.LineColorButton);
            this.Name = "FigureSettingsControl";
            this.Size = new System.Drawing.Size(240, 125);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LineColorButton;
        private System.Windows.Forms.Button FillColorButton;
        private System.Windows.Forms.Label LineColorLabel;
        private System.Windows.Forms.Label LineWidthLabel;
        private System.Windows.Forms.Label LineTypeLabel;
        private System.Windows.Forms.Label FillColorLabel;
        private System.Windows.Forms.TextBox LineWidthTextBox;
        private System.Windows.Forms.ComboBox LineTypeComboBox;
        private System.Windows.Forms.ColorDialog lineColorDialog;
        private System.Windows.Forms.ColorDialog fillColorDialog;
    }
}
