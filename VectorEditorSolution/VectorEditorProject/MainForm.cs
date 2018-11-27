using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Drawing;
using VectorEditorProject.Figures;
using VectorEditorProject.Figures.Utility;

namespace VectorEditorProject
{
    public partial class MainForm : Form
    {
        DrawerFactory drawerFactory = new DrawerFactory();
        private ControlUnit controlUnit;

        public MainForm()
        {
            InitializeComponent();
            controlUnit = new ControlUnit(canvas);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            drawerFactory.DrawCanvas(controlUnit.GetDocument(), e.Graphics);

            foreach (var figure in controlUnit.GetDocument().GetFigures())
            {
                drawerFactory.DrawFigure(figure, e.Graphics);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlUnit.Undo();
        }

        private void doToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlUnit.Do();
        }
    }
}
