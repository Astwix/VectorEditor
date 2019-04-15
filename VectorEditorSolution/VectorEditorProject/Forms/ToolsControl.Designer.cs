namespace VectorEditorProject.Forms
{
    partial class ToolsControl
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
            this.SelectionButton = new System.Windows.Forms.Button();
            this.FiguresGroupBox = new System.Windows.Forms.GroupBox();
            this.FiguresPanel = new System.Windows.Forms.Panel();
            this.FiguresGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectionButton
            // 
            this.SelectionButton.Location = new System.Drawing.Point(3, 3);
            this.SelectionButton.Name = "SelectionButton";
            this.SelectionButton.Size = new System.Drawing.Size(110, 25);
            this.SelectionButton.TabIndex = 13;
            this.SelectionButton.Text = "Выделение";
            this.SelectionButton.UseVisualStyleBackColor = true;
            this.SelectionButton.Click += new System.EventHandler(this.selectionButton_Click);
            // 
            // FiguresGroupBox
            // 
            this.FiguresGroupBox.Controls.Add(this.FiguresPanel);
            this.FiguresGroupBox.Location = new System.Drawing.Point(3, 34);
            this.FiguresGroupBox.Name = "FiguresGroupBox";
            this.FiguresGroupBox.Size = new System.Drawing.Size(234, 199);
            this.FiguresGroupBox.TabIndex = 14;
            this.FiguresGroupBox.TabStop = false;
            this.FiguresGroupBox.Text = "Список фигур";
            // 
            // FiguresPanel
            // 
            this.FiguresPanel.AutoScroll = true;
            this.FiguresPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FiguresPanel.Location = new System.Drawing.Point(3, 18);
            this.FiguresPanel.Name = "FiguresPanel";
            this.FiguresPanel.Size = new System.Drawing.Size(228, 178);
            this.FiguresPanel.TabIndex = 0;
            // 
            // ToolsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FiguresGroupBox);
            this.Controls.Add(this.SelectionButton);
            this.Name = "ToolsControl";
            this.Size = new System.Drawing.Size(240, 236);
            this.FiguresGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SelectionButton;
        private System.Windows.Forms.GroupBox FiguresGroupBox;
        private System.Windows.Forms.Panel FiguresPanel;
    }
}
