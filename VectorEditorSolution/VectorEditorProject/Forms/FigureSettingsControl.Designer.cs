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
            this.lineColorButton = new System.Windows.Forms.Button();
            this.fillColorButton = new System.Windows.Forms.Button();
            this.lineColorLabel = new System.Windows.Forms.Label();
            this.lineWidthLabel = new System.Windows.Forms.Label();
            this.lineTypeLabel = new System.Windows.Forms.Label();
            this.fillColorLabel = new System.Windows.Forms.Label();
            this.lineWidthTextBox = new System.Windows.Forms.TextBox();
            this.lineTypeComboBox = new System.Windows.Forms.ComboBox();
            this.lineColorDialog = new System.Windows.Forms.ColorDialog();
            this.fillColorDialog = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // lineColorButton
            // 
            this.lineColorButton.Location = new System.Drawing.Point(94, 3);
            this.lineColorButton.Name = "lineColorButton";
            this.lineColorButton.Size = new System.Drawing.Size(75, 23);
            this.lineColorButton.TabIndex = 0;
            this.lineColorButton.UseVisualStyleBackColor = true;
            this.lineColorButton.Click += new System.EventHandler(this.lineColorButton_Click);
            // 
            // fillColorButton
            // 
            this.fillColorButton.Location = new System.Drawing.Point(777, 3);
            this.fillColorButton.Name = "fillColorButton";
            this.fillColorButton.Size = new System.Drawing.Size(75, 23);
            this.fillColorButton.TabIndex = 1;
            this.fillColorButton.UseVisualStyleBackColor = true;
            this.fillColorButton.Click += new System.EventHandler(this.fillColorButton_Click);
            // 
            // lineColorLabel
            // 
            this.lineColorLabel.AutoSize = true;
            this.lineColorLabel.Location = new System.Drawing.Point(3, 6);
            this.lineColorLabel.Name = "lineColorLabel";
            this.lineColorLabel.Size = new System.Drawing.Size(85, 17);
            this.lineColorLabel.TabIndex = 2;
            this.lineColorLabel.Text = "Цвет линии";
            // 
            // lineWidthLabel
            // 
            this.lineWidthLabel.AutoSize = true;
            this.lineWidthLabel.Location = new System.Drawing.Point(195, 6);
            this.lineWidthLabel.Name = "lineWidthLabel";
            this.lineWidthLabel.Size = new System.Drawing.Size(112, 17);
            this.lineWidthLabel.TabIndex = 3;
            this.lineWidthLabel.Text = "Толщина линии";
            // 
            // lineTypeLabel
            // 
            this.lineTypeLabel.AutoSize = true;
            this.lineTypeLabel.Location = new System.Drawing.Point(439, 6);
            this.lineTypeLabel.Name = "lineTypeLabel";
            this.lineTypeLabel.Size = new System.Drawing.Size(77, 17);
            this.lineTypeLabel.TabIndex = 4;
            this.lineTypeLabel.Text = "Тип линии";
            // 
            // fillColorLabel
            // 
            this.fillColorLabel.AutoSize = true;
            this.fillColorLabel.Location = new System.Drawing.Point(673, 6);
            this.fillColorLabel.Name = "fillColorLabel";
            this.fillColorLabel.Size = new System.Drawing.Size(98, 17);
            this.fillColorLabel.TabIndex = 5;
            this.fillColorLabel.Text = "Цвет заливки";
            // 
            // lineWidthTextBox
            // 
            this.lineWidthTextBox.Location = new System.Drawing.Point(313, 3);
            this.lineWidthTextBox.Name = "lineWidthTextBox";
            this.lineWidthTextBox.Size = new System.Drawing.Size(100, 22);
            this.lineWidthTextBox.TabIndex = 6;
            this.lineWidthTextBox.Text = "1";
            // 
            // lineTypeComboBox
            // 
            this.lineTypeComboBox.FormattingEnabled = true;
            this.lineTypeComboBox.Location = new System.Drawing.Point(522, 3);
            this.lineTypeComboBox.Name = "lineTypeComboBox";
            this.lineTypeComboBox.Size = new System.Drawing.Size(121, 24);
            this.lineTypeComboBox.TabIndex = 7;
            // 
            // FigureSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lineTypeComboBox);
            this.Controls.Add(this.lineWidthTextBox);
            this.Controls.Add(this.fillColorLabel);
            this.Controls.Add(this.lineTypeLabel);
            this.Controls.Add(this.lineWidthLabel);
            this.Controls.Add(this.lineColorLabel);
            this.Controls.Add(this.fillColorButton);
            this.Controls.Add(this.lineColorButton);
            this.Name = "FigureSettingsControl";
            this.Size = new System.Drawing.Size(865, 39);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lineColorButton;
        private System.Windows.Forms.Button fillColorButton;
        private System.Windows.Forms.Label lineColorLabel;
        private System.Windows.Forms.Label lineWidthLabel;
        private System.Windows.Forms.Label lineTypeLabel;
        private System.Windows.Forms.Label fillColorLabel;
        private System.Windows.Forms.TextBox lineWidthTextBox;
        private System.Windows.Forms.ComboBox lineTypeComboBox;
        private System.Windows.Forms.ColorDialog lineColorDialog;
        private System.Windows.Forms.ColorDialog fillColorDialog;
    }
}
