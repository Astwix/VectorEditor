using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VectorEditorProject.Drawing;
using VectorEditorProject.Figures;

namespace VectorEditorProject
{
    public partial class MainForm : Form
    {
        // временно здесь
        List<BaseFigure> figures = new List<BaseFigure>();
        DrawerFactory drawerFactory = new DrawerFactory();

        public MainForm()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var figure in figures)
            {
                drawerFactory.DrawFigure(figure, e.Graphics);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}
