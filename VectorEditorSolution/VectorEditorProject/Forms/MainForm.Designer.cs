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
            this.TopToolBar = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExtrudeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainLeftSplitContainer = new System.Windows.Forms.SplitContainer();
            this.FigureSettingsControl = new VectorEditorProject.Forms.FigureSettingsControl();
            this.MainLeftBottomSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ToolsUserControl = new VectorEditorProject.Forms.ToolsControl();
            this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.WrapPictureBox = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.TopToolBar.SuspendLayout();
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
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // TopToolBar
            // 
            this.TopToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TopToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem});
            this.TopToolBar.Location = new System.Drawing.Point(0, 0);
            this.TopToolBar.Name = "TopToolBar";
            this.TopToolBar.Size = new System.Drawing.Size(982, 28);
            this.TopToolBar.TabIndex = 1;
            this.TopToolBar.Text = "topToolBar";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileOptionsToolStripMenuItem,
            this.FileClearToolStripMenuItem,
            this.SaveAsToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // FileOptionsToolStripMenuItem
            // 
            this.FileOptionsToolStripMenuItem.Name = "FileOptionsToolStripMenuItem";
            this.FileOptionsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.FileOptionsToolStripMenuItem.Text = "Параметры";
            this.FileOptionsToolStripMenuItem.Click += new System.EventHandler(this.FileOptionsToolStripMenuItem_Click);
            // 
            // FileClearToolStripMenuItem
            // 
            this.FileClearToolStripMenuItem.Name = "FileClearToolStripMenuItem";
            this.FileClearToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.FileClearToolStripMenuItem.Text = "Очистить";
            this.FileClearToolStripMenuItem.Click += new System.EventHandler(this.FileClearToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.SaveAsToolStripMenuItem.Text = "Сохранить как...";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoToolStripMenuItem,
            this.DoToolStripMenuItem,
            this.toolStripSeparator1,
            this.CopyToolStripMenuItem,
            this.ExtrudeToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.DeleteToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.EditToolStripMenuItem.Text = "Правка";
            // 
            // UndoToolStripMenuItem
            // 
            this.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            this.UndoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.UndoToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.UndoToolStripMenuItem.Text = "Отменить";
            this.UndoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // DoToolStripMenuItem
            // 
            this.DoToolStripMenuItem.Name = "DoToolStripMenuItem";
            this.DoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.DoToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.DoToolStripMenuItem.Text = "Вернуть";
            this.DoToolStripMenuItem.Click += new System.EventHandler(this.DoToolStripMenuItem_Click);
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
            // FigureSettingsControl
            // 
            this.FigureSettingsControl.Location = new System.Drawing.Point(3, 3);
            this.FigureSettingsControl.Name = "FigureSettingsControl";
            this.FigureSettingsControl.Size = new System.Drawing.Size(240, 120);
            this.FigureSettingsControl.TabIndex = 8;
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
            // ToolsUserControl
            // 
            this.ToolsUserControl.EditContext = null;
            this.ToolsUserControl.Location = new System.Drawing.Point(3, 3);
            this.ToolsUserControl.Name = "ToolsUserControl";
            this.ToolsUserControl.Size = new System.Drawing.Size(240, 90);
            this.ToolsUserControl.TabIndex = 0;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.WrapPictureBox);
            this.Controls.Add(this.MainLeftSplitContainer);
            this.Controls.Add(this.TopToolBar);
            this.KeyPreview = true;
            this.MainMenuStrip = this.TopToolBar;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainForm";
            this.Text = "VectorEditor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.TopToolBar.ResumeLayout(false);
            this.TopToolBar.PerformLayout();
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
        private System.Windows.Forms.MenuStrip TopToolBar;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UndoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileClearToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
    }
}

