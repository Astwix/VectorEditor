using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Core.Drawing;

namespace VectorEditorProject.Forms
{
    public partial class MainForm : Form
    {
        private DrawerFactory _drawerFactory;
        private ControlUnit _controlUnit;
        private EditContext _editContext;

        public MainForm()
        {
            InitializeComponent();

            _controlUnit = new ControlUnit(Canvas, FigureSettingsControl, ToolsUserControl, PropertyGrid);
            _drawerFactory = new DrawerFactory();
            _editContext = new EditContext(_controlUnit);
            _controlUnit.EditContext = _editContext;
            ToolsUserControl.EditContext = _editContext;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
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

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controlUnit.Undo();
        }

        private void DoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controlUnit.Do();
        }

        private void FileOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentForm documentForm = new DocumentForm(_controlUnit.GetDocument());
            if (documentForm.ShowDialog() != DialogResult.Cancel && documentForm.document != null)
            {
                var command = CommandFactory.CreateChangingDocumentOptionsCommand
                    (_controlUnit, documentForm.document);
                _controlUnit.StoreCommand(command);
                _controlUnit.Do();
            }
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            _editContext.MouseDown(sender, e);
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            _editContext.MouseUp(sender, e);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            _editContext.MouseMove(sender, e);
        }
        
        private void FileClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var command = CommandFactory.CreateClearDocumentCommand(_controlUnit);
            _controlUnit.StoreCommand(command);
            _controlUnit.Do();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _editContext.SetActiveState(EditContext.States.SelectionState);
                return;
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controlUnit.Copy();
        }

        private void ExtrudeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controlUnit.Copy();
            _controlUnit.Delete();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controlUnit.Paste();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controlUnit.Delete();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG|*.png|JPEG|*.jpeg";
            saveFileDialog.FileName = _controlUnit.GetDocument().Name;

            if (saveFileDialog.ShowDialog() != DialogResult.Cancel && 
                saveFileDialog.FileName != "")
            {
                var size = _controlUnit.GetDocument().Size;
                Bitmap bitmap = new Bitmap(size.Width, size.Height);
                Canvas.DrawToBitmap(bitmap, new Rectangle(0, 0, size.Width, size.Height));

                ImageFormat selectedFormat;
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        selectedFormat = ImageFormat.Png;
                        break;

                    case 2:
                        selectedFormat = ImageFormat.Jpeg;
                        break;

                    default:
                        selectedFormat = ImageFormat.Png;
                        break;
                }

                bitmap.Save(saveFileDialog.FileName, selectedFormat);
            }
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ElectroCute|*.pika";

            if (openFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                using (var stream = openFileDialog.OpenFile())
                {
                    _controlUnit.Deserialize(stream);
                }
            }
        }

        private void SaveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = _controlUnit.GetDocument().Name;
            saveFileDialog.Filter = "ElectoCute|*.pika";

            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                using (var stream = saveFileDialog.OpenFile())
                {
                    _controlUnit.Serialize(stream);
                }
            }
        }

        private void NewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentForm documentForm = new DocumentForm(_controlUnit.GetDocument());
            if (documentForm.ShowDialog() != DialogResult.Cancel && documentForm.document != null)
            {
                _controlUnit.Reset();
                _controlUnit.GetDocument().ClearCanvas();

                var command = CommandFactory.CreateChangingDocumentOptionsCommand
                    (_controlUnit, documentForm.document);
                command.Do();
                _controlUnit.UpdateCanvas();
            }
        }
    }
}
