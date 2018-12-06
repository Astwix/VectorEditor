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
            this.LineButton = new System.Windows.Forms.Button();
            this.PolylineButton = new System.Windows.Forms.Button();
            this.SelectionButton = new System.Windows.Forms.Button();
            this.CircleButton = new System.Windows.Forms.Button();
            this.PolygonButton = new System.Windows.Forms.Button();
            this.EllipseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LineButton
            // 
            this.LineButton.Location = new System.Drawing.Point(3, 3);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(99, 25);
            this.LineButton.TabIndex = 8;
            this.LineButton.Text = "Линия";
            this.LineButton.UseVisualStyleBackColor = true;
            this.LineButton.Click += new System.EventHandler(this.CreateFigure);
            // 
            // PolylineButton
            // 
            this.PolylineButton.Location = new System.Drawing.Point(3, 34);
            this.PolylineButton.Name = "PolylineButton";
            this.PolylineButton.Size = new System.Drawing.Size(99, 25);
            this.PolylineButton.TabIndex = 9;
            this.PolylineButton.Text = "Полилиния";
            this.PolylineButton.UseVisualStyleBackColor = true;
            this.PolylineButton.Click += new System.EventHandler(this.CreateFigure);
            // 
            // SelectionButton
            // 
            this.SelectionButton.Location = new System.Drawing.Point(3, 158);
            this.SelectionButton.Name = "SelectionButton";
            this.SelectionButton.Size = new System.Drawing.Size(99, 25);
            this.SelectionButton.TabIndex = 13;
            this.SelectionButton.Text = "Выделение";
            this.SelectionButton.UseVisualStyleBackColor = true;
            this.SelectionButton.Click += new System.EventHandler(this.selectionButton_Click);
            // 
            // CircleButton
            // 
            this.CircleButton.Location = new System.Drawing.Point(3, 65);
            this.CircleButton.Name = "CircleButton";
            this.CircleButton.Size = new System.Drawing.Size(99, 25);
            this.CircleButton.TabIndex = 10;
            this.CircleButton.Text = "Круг";
            this.CircleButton.UseVisualStyleBackColor = true;
            this.CircleButton.Click += new System.EventHandler(this.CreateFigure);
            // 
            // PolygonButton
            // 
            this.PolygonButton.Location = new System.Drawing.Point(3, 127);
            this.PolygonButton.Name = "PolygonButton";
            this.PolygonButton.Size = new System.Drawing.Size(99, 25);
            this.PolygonButton.TabIndex = 12;
            this.PolygonButton.Text = "Полигон";
            this.PolygonButton.UseVisualStyleBackColor = true;
            this.PolygonButton.Click += new System.EventHandler(this.CreateFigure);
            // 
            // EllipseButton
            // 
            this.EllipseButton.Location = new System.Drawing.Point(3, 96);
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new System.Drawing.Size(99, 25);
            this.EllipseButton.TabIndex = 11;
            this.EllipseButton.Text = "Эллипс";
            this.EllipseButton.UseVisualStyleBackColor = true;
            this.EllipseButton.Click += new System.EventHandler(this.CreateFigure);
            // 
            // ToolsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LineButton);
            this.Controls.Add(this.PolylineButton);
            this.Controls.Add(this.SelectionButton);
            this.Controls.Add(this.CircleButton);
            this.Controls.Add(this.PolygonButton);
            this.Controls.Add(this.EllipseButton);
            this.Name = "ToolsControl";
            this.Size = new System.Drawing.Size(106, 189);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LineButton;
        private System.Windows.Forms.Button PolylineButton;
        private System.Windows.Forms.Button SelectionButton;
        private System.Windows.Forms.Button CircleButton;
        private System.Windows.Forms.Button PolygonButton;
        private System.Windows.Forms.Button EllipseButton;
    }
}
