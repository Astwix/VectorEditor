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
            this.fileClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExtrudeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainLeftSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ToolsUserControl = new VectorEditorProject.Forms.ToolsControl();
            this.WrapPictureBox = new System.Windows.Forms.Panel();
            this.figureSettingsControl = new VectorEditorProject.Forms.FigureSettingsControl();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.topToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainLeftSplitContainer)).BeginInit();
            this.MainLeftSplitContainer.Panel1.SuspendLayout();
            this.MainLeftSplitContainer.SuspendLayout();
            this.WrapPictureBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1030, 532);
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
            this.topToolBar.Size = new System.Drawing.Size(1153, 28);
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
            // fileClearToolStripMenuItem
            // 
            this.fileClearToolStripMenuItem.Name = "fileClearToolStripMenuItem";
            this.fileClearToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.fileClearToolStripMenuItem.Text = "Очистить";
            this.fileClearToolStripMenuItem.Click += new System.EventHandler(this.fileClearToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.doToolStripMenuItem,
            this.toolStripSeparator1,
            this.CopyToolStripMenuItem,
            this.ExtrudeToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.DeleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.editToolStripMenuItem.Text = "Правка";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.undoToolStripMenuItem.Text = "Отменить";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // doToolStripMenuItem
            // 
            this.doToolStripMenuItem.Name = "doToolStripMenuItem";
            this.doToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.doToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.doToolStripMenuItem.Text = "Вернуть";
            this.doToolStripMenuItem.Click += new System.EventHandler(this.doToolStripMenuItem_Click);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.CopyToolStripMenuItem.Text = "Копировать";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // ExtrudeToolStripMenuItem
            // 
            this.ExtrudeToolStripMenuItem.Name = "ExtrudeToolStripMenuItem";
            this.ExtrudeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.ExtrudeToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.ExtrudeToolStripMenuItem.Text = "Вырезать";
            this.ExtrudeToolStripMenuItem.Click += new System.EventHandler(this.ExtrudeToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.PasteToolStripMenuItem.Text = "Вставить";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.DeleteToolStripMenuItem.Text = "Удалить";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // MainLeftSplitContainer
            // 
            this.MainLeftSplitContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainLeftSplitContainer.Location = new System.Drawing.Point(0, 67);
            this.MainLeftSplitContainer.Name = "MainLeftSplitContainer";
            this.MainLeftSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainLeftSplitContainer.Panel1
            // 
            this.MainLeftSplitContainer.Panel1.Controls.Add(this.ToolsUserControl);
            this.MainLeftSplitContainer.Size = new System.Drawing.Size(123, 532);
            this.MainLeftSplitContainer.SplitterDistance = 266;
            this.MainLeftSplitContainer.TabIndex = 9;
            // 
            // ToolsUserControl
            // 
            this.ToolsUserControl.EditContext = null;
            this.ToolsUserControl.Location = new System.Drawing.Point(12, 6);
            this.ToolsUserControl.Name = "ToolsUserControl";
            this.ToolsUserControl.Size = new System.Drawing.Size(106, 189);
            this.ToolsUserControl.TabIndex = 0;
            // 
            // WrapPictureBox
            // 
            this.WrapPictureBox.Controls.Add(this.canvas);
            this.WrapPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WrapPictureBox.Location = new System.Drawing.Point(123, 67);
            this.WrapPictureBox.Name = "WrapPictureBox";
            this.WrapPictureBox.Size = new System.Drawing.Size(1030, 532);
            this.WrapPictureBox.TabIndex = 10;
            // 
            // figureSettingsControl
            // 
            this.figureSettingsControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.figureSettingsControl.Location = new System.Drawing.Point(0, 28);
            this.figureSettingsControl.Name = "figureSettingsControl";
            this.figureSettingsControl.Size = new System.Drawing.Size(1153, 39);
            this.figureSettingsControl.TabIndex = 8;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 599);
            this.Controls.Add(this.WrapPictureBox);
            this.Controls.Add(this.MainLeftSplitContainer);
            this.Controls.Add(this.figureSettingsControl);
            this.Controls.Add(this.topToolBar);
            this.KeyPreview = true;
            this.MainMenuStrip = this.topToolBar;
            this.Name = "MainForm";
            this.Text = "VectorEditor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.topToolBar.ResumeLayout(false);
            this.topToolBar.PerformLayout();
            this.MainLeftSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainLeftSplitContainer)).EndInit();
            this.MainLeftSplitContainer.ResumeLayout(false);
            this.WrapPictureBox.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem fileClearToolStripMenuItem;
        private Forms.FigureSettingsControl figureSettingsControl;
        private System.Windows.Forms.SplitContainer MainLeftSplitContainer;
        private System.Windows.Forms.Panel WrapPictureBox;
        private Forms.ToolsControl ToolsUserControl;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExtrudeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

