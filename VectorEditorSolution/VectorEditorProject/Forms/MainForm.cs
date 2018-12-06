using System;
using System.Windows.Forms;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Drawing;
using VectorEditorProject.Forms;

namespace VectorEditorProject
{
    public partial class MainForm : Form
    {
        private DrawerFactory _drawerFactory;
        private ControlUnit _controlUnit;
        private EditContext _editContext;

        public MainForm()
        {
            InitializeComponent();

            _controlUnit = new ControlUnit(canvas, figureSettingsControl);
            _drawerFactory = new DrawerFactory();
            _editContext = new EditContext(_controlUnit);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            _drawerFactory.DrawCanvas(_controlUnit.GetDocument(), e.Graphics);

            foreach (var figure in _controlUnit.GetDocument().GetFigures())
            {
                _drawerFactory.DrawFigure(figure, e.Graphics);
            }

            _editContext.Draw(e.Graphics);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controlUnit.Undo();
        }

        private void doToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controlUnit.Do();
        }

        private void fileOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Пока без undo/redo
            DocumentForm documentForm = new DocumentForm(_controlUnit.GetDocument());
            if (documentForm.ShowDialog() != DialogResult.Cancel && documentForm.document != null)
            {
                var doc = _controlUnit.GetDocument();
                doc.Name = documentForm.document.Name;
                doc.Size = documentForm.document.Size;
                doc.Color = documentForm.document.Color;
                canvas.Invalidate();
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            _editContext.MouseDown(sender, e);
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            _editContext.MouseUp(sender, e);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            _editContext.MouseMove(sender, e);
        }

        private void lineButton_Click(object sender, EventArgs e)
        {
            _editContext.SetActiveState(EditContext.States.AddLineState);
        }

        private void polylineButton_Click(object sender, EventArgs e)
        {
            _editContext.SetActiveState(EditContext.States.AddPolylineState);
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            _editContext.SetActiveState(EditContext.States.AddCircleState);
        }

        private void ellipseButton_Click(object sender, EventArgs e)
        {
            _editContext.SetActiveState(EditContext.States.AddEllipseState);
        }

        private void polygonButton_Click(object sender, EventArgs e)
        {
            _editContext.SetActiveState(EditContext.States.AddPlygonState);
        }

        private void selectionButton_Click(object sender, EventArgs e)
        {
            _editContext.SetActiveState(EditContext.States.SelectionState);
        }

        private void fileClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var command = new ClearDocumentCommand(_controlUnit.GetDocument());
            _controlUnit.StoreCommand(command);
            _controlUnit.Do();
        }
    }
}
