namespace VectorEditorProject.Forms
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
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.topToolBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExtrudeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainLeftSplitContainer = new System.Windows.Forms.SplitContainer();
            this.MainLeftBottomSplitContainer = new System.Windows.Forms.SplitContainer();
            this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.WrapPictureBox = new System.Windows.Forms.Panel();
            this.FigureSettingsControl = new VectorEditorProject.Forms.FigureSettingsControl();
            this.ToolsUserControl = new VectorEditorProject.Forms.ToolsControl();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.topToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainLeftSplitContainer)).BeginInit();
            this.MainLeftSplitContainer.Panel1.SuspendLayout();
            this.MainLeftSplitContainer.Panel2.SuspendLayout();
            this.MainLeftSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainLeftBottomSplitContainer)).BeginInit();
            this.MainLeftBottomSplitContainer.Panel1.SuspendLayout();
            this.MainLeftBottomSplitContainer.Panel2.SuspendLayout();
            this.MainLeftBottomSplitContainer.SuspendLayout();
            this.WrapPictureBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(729, 525);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // topToolBar
            // 
            this.topToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.topToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.topToolBar.Location = new System.Drawing.Point(0, 0);
            this.topToolBar.Name = "topToolBar";
            this.topToolBar.Size = new System.Drawing.Size(982, 28);
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
            this.fileOptionsToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.fileOptionsToolStripMenuItem.Text = "Параметры";
            this.fileOptionsToolStripMenuItem.Click += new System.EventHandler(this.fileOptionsToolStripMenuItem_Click);
            // 
            // fileClearToolStripMenuItem
            // 
            this.fileClearToolStripMenuItem.Name = "fileClearToolStripMenuItem";
            this.fileClearToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
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
            this.MainLeftSplitContainer.Location = new System.Drawing.Point(0, 28);
            this.MainLeftSplitContainer.Name = "MainLeftSplitContainer";
            this.MainLeftSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainLeftSplitContainer.Panel1
            // 
            this.MainLeftSplitContainer.Panel1.Controls.Add(this.FigureSettingsControl);
            // 
            // MainLeftSplitContainer.Panel2
            // 
            this.MainLeftSplitContainer.Panel2.Controls.Add(this.MainLeftBottomSplitContainer);
            this.MainLeftSplitContainer.Size = new System.Drawing.Size(253, 525);
            this.MainLeftSplitContainer.SplitterDistance = 117;
            this.MainLeftSplitContainer.TabIndex = 9;
            // 
            // MainLeftBottomSplitContainer
            // 
            this.MainLeftBottomSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLeftBottomSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainLeftBottomSplitContainer.Name = "MainLeftBottomSplitContainer";
            this.MainLeftBottomSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainLeftBottomSplitContainer.Panel1
            // 
            this.MainLeftBottomSplitContainer.Panel1.Controls.Add(this.ToolsUserControl);
            // 
            // MainLeftBottomSplitContainer.Panel2
            // 
            this.MainLeftBottomSplitContainer.Panel2.Controls.Add(this.PropertyGrid);
            this.MainLeftBottomSplitContainer.Size = new System.Drawing.Size(253, 404);
            this.MainLeftBottomSplitContainer.SplitterDistance = 100;
            this.MainLeftBottomSplitContainer.TabIndex = 1;
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGrid.HelpVisible = false;
            this.PropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.PropertyGrid.Margin = new System.Windows.Forms.Padding(5);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.PropertyGrid.Size = new System.Drawing.Size(253, 300);
            this.PropertyGrid.TabIndex = 0;
            this.PropertyGrid.ToolbarVisible = false;
            // 
            // WrapPictureBox
            // 
            this.WrapPictureBox.Controls.Add(this.Canvas);
            this.WrapPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WrapPictureBox.Location = new System.Drawing.Point(253, 28);
            this.WrapPictureBox.Name = "WrapPictureBox";
            this.WrapPictureBox.Size = new System.Drawing.Size(729, 525);
            this.WrapPictureBox.TabIndex = 10;
            // 
            // FigureSettingsControl
            // 
            this.FigureSettingsControl.Location = new System.Drawing.Point(3, 3);
            this.FigureSettingsControl.Name = "FigureSettingsControl";
            this.FigureSettingsControl.Size = new System.Drawing.Size(240, 120);
            this.FigureSettingsControl.TabIndex = 8;
            // 
            // ToolsUserControl
            // 
            this.ToolsUserControl.EditContext = null;
            this.ToolsUserControl.Location = new System.Drawing.Point(3, 3);
            this.ToolsUserControl.Name = "ToolsUserControl";
            this.ToolsUserControl.Size = new System.Drawing.Size(240, 90);
            this.ToolsUserControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.WrapPictureBox);
            this.Controls.Add(this.MainLeftSplitContainer);
            this.Controls.Add(this.topToolBar);
            this.KeyPreview = true;
            this.MainMenuStrip = this.topToolBar;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainForm";
            this.Text = "VectorEditor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.topToolBar.ResumeLayout(false);
            this.topToolBar.PerformLayout();
            this.MainLeftSplitContainer.Panel1.ResumeLayout(false);
            this.MainLeftSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainLeftSplitContainer)).EndInit();
            this.MainLeftSplitContainer.ResumeLayout(false);
            this.MainLeftBottomSplitContainer.Panel1.ResumeLayout(false);
            this.MainLeftBottomSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainLeftBottomSplitContainer)).EndInit();
            this.MainLeftBottomSplitContainer.ResumeLayout(false);
            this.WrapPictureBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.MenuStrip topToolBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileClearToolStripMenuItem;
        private Forms.FigureSettingsControl FigureSettingsControl;
        private System.Windows.Forms.SplitContainer MainLeftSplitContainer;
        private System.Windows.Forms.Panel WrapPictureBox;
        private Forms.ToolsControl ToolsUserControl;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExtrudeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PropertyGrid PropertyGrid;
        private System.Windows.Forms.SplitContainer MainLeftBottomSplitContainer;
    }
}

