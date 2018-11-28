namespace VectorEditorProject
{
    partial class MainForm
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.topToolBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineButton = new System.Windows.Forms.Button();
            this.polylineButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.ellipseButton = new System.Windows.Forms.Button();
            this.polygonButton = new System.Windows.Forms.Button();
            this.selectionButton = new System.Windows.Forms.Button();
            this.fileClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.topToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(117, 31);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(754, 513);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // topToolBar
            // 
            this.topToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.topToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.topToolBar.Location = new System.Drawing.Point(0, 0);
            this.topToolBar.Name = "topToolBar";
            this.topToolBar.Size = new System.Drawing.Size(926, 28);
            this.topToolBar.TabIndex = 1;
            this.topToolBar.Text = "topToolBar";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOptionsToolStripMenuItem,
            this.fileClearToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // fileOptionsToolStripMenuItem
            // 
            this.fileOptionsToolStripMenuItem.Name = "fileOptionsToolStripMenuItem";
            this.fileOptionsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.fileOptionsToolStripMenuItem.Text = "Параметры";
            this.fileOptionsToolStripMenuItem.Click += new System.EventHandler(this.fileOptionsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.doToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.editToolStripMenuItem.Text = "Правка";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.undoToolStripMenuItem.Text = "Отменить";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // doToolStripMenuItem
            // 
            this.doToolStripMenuItem.Name = "doToolStripMenuItem";
            this.doToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.doToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.doToolStripMenuItem.Text = "Вернуть";
            this.doToolStripMenuItem.Click += new System.EventHandler(this.doToolStripMenuItem_Click);
            // 
            // lineButton
            // 
            this.lineButton.Location = new System.Drawing.Point(12, 31);
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(99, 23);
            this.lineButton.TabIndex = 2;
            this.lineButton.Text = "Линия";
            this.lineButton.UseVisualStyleBackColor = true;
            this.lineButton.Click += new System.EventHandler(this.lineButton_Click);
            // 
            // polylineButton
            // 
            this.polylineButton.Location = new System.Drawing.Point(12, 60);
            this.polylineButton.Name = "polylineButton";
            this.polylineButton.Size = new System.Drawing.Size(99, 23);
            this.polylineButton.TabIndex = 3;
            this.polylineButton.Text = "Полилиния";
            this.polylineButton.UseVisualStyleBackColor = true;
            this.polylineButton.Click += new System.EventHandler(this.polylineButton_Click);
            // 
            // circleButton
            // 
            this.circleButton.Location = new System.Drawing.Point(12, 89);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(99, 23);
            this.circleButton.TabIndex = 4;
            this.circleButton.Text = "Круг";
            this.circleButton.UseVisualStyleBackColor = true;
            this.circleButton.Click += new System.EventHandler(this.circleButton_Click);
            // 
            // ellipseButton
            // 
            this.ellipseButton.Location = new System.Drawing.Point(12, 118);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(99, 23);
            this.ellipseButton.TabIndex = 5;
            this.ellipseButton.Text = "Эллипс";
            this.ellipseButton.UseVisualStyleBackColor = true;
            this.ellipseButton.Click += new System.EventHandler(this.ellipseButton_Click);
            // 
            // polygonButton
            // 
            this.polygonButton.Location = new System.Drawing.Point(12, 147);
            this.polygonButton.Name = "polygonButton";
            this.polygonButton.Size = new System.Drawing.Size(99, 23);
            this.polygonButton.TabIndex = 6;
            this.polygonButton.Text = "Полигон";
            this.polygonButton.UseVisualStyleBackColor = true;
            this.polygonButton.Click += new System.EventHandler(this.polygonButton_Click);
            // 
            // selectionButton
            // 
            this.selectionButton.Location = new System.Drawing.Point(12, 176);
            this.selectionButton.Name = "selectionButton";
            this.selectionButton.Size = new System.Drawing.Size(99, 23);
            this.selectionButton.TabIndex = 7;
            this.selectionButton.Text = "Выделение";
            this.selectionButton.UseVisualStyleBackColor = true;
            this.selectionButton.Click += new System.EventHandler(this.selectionButton_Click);
            // 
            // fileClearToolStripMenuItem
            // 
            this.fileClearToolStripMenuItem.Name = "fileClearToolStripMenuItem";
            this.fileClearToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.fileClearToolStripMenuItem.Text = "Очистить";
            this.fileClearToolStripMenuItem.Click += new System.EventHandler(this.fileClearToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 599);
            this.Controls.Add(this.selectionButton);
            this.Controls.Add(this.polygonButton);
            this.Controls.Add(this.ellipseButton);
            this.Controls.Add(this.circleButton);
            this.Controls.Add(this.polylineButton);
            this.Controls.Add(this.lineButton);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.topToolBar);
            this.MainMenuStrip = this.topToolBar;
            this.Name = "MainForm";
            this.Text = "VectorEditor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.topToolBar.ResumeLayout(false);
            this.topToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.MenuStrip topToolBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOptionsToolStripMenuItem;
        private System.Windows.Forms.Button lineButton;
        private System.Windows.Forms.Button polylineButton;
        private System.Windows.Forms.Button circleButton;
        private System.Windows.Forms.Button ellipseButton;
        private System.Windows.Forms.Button polygonButton;
        private System.Windows.Forms.Button selectionButton;
        private System.Windows.Forms.ToolStripMenuItem fileClearToolStripMenuItem;
    }
}

