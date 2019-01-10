using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;
using VectorEditorProject.Core.Drawing;

namespace VectorEditorProject.Forms
{
    /// <summary>
    /// Главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Фабрика рисования
        /// </summary>
        private DrawerFactory _drawerFactory;

        /// <summary>
        /// Control Unit
        /// </summary>
        private ControlUnit _controlUnit;

        /// <summary>
        /// Edit Context
        /// </summary>
        private EditContext _editContext;

        /// <summary>
        /// Конмтруктор главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _controlUnit = new ControlUnit(Canvas, FigureSettingsControl, ToolsUserControl, PropertyGrid);
            _drawerFactory = new DrawerFactory();
            _editContext = new EditContext(_controlUnit);
            _controlUnit.EditContext = _editContext;
            ToolsUserControl.EditContext = _editContext;
        }

        /// <summary>
        /// Рисование на канве
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            _drawerFactory.DrawCanvas(_controlUnit.GetDocument(), e.Graphics);

            foreach (var figure in _controlUnit.GetDocument().GetFigures())
            {
                _drawerFactory.DrawFigure(figure, e.Graphics);
            }

            _editContext.Draw(e.Graphics);
        }

        /// <summary>
        /// Загрузка главной формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Клик по кнопке "Отменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controlUnit.Undo();
        }

        /// <summary>
        /// Клик по кнопке "Вернуть"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controlUnit.Do();
        }

        /// <summary>
        /// Клик по кнопке "Параметры"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Нажатие кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            _editContext.MouseDown(sender, e);
        }

        /// <summary>
        /// Отжатие кнопки мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            _editContext.MouseUp(sender, e);
        }

        /// <summary>
        /// Перемещение мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            _editContext.MouseMove(sender, e);
        }
        
        /// <summary>
        /// Клик по кнопке "Очистить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var command = CommandFactory.CreateClearDocumentCommand(_controlUnit);
            _controlUnit.StoreCommand(command);
            _controlUnit.Do();
        }

        /// <summary>
        /// Отпущена нажатая кнопка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _editContext.SetActiveState(EditContext.States.SelectionState);
                return;
            }
        }

        /// <summary>
        /// Клик по кнопке "Копировать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controlUnit.Copy();
        }

        /// <summary>
        /// Клик по кнопке "Вырезать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtrudeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controlUnit.Copy();
            _controlUnit.Delete();
        }

        /// <summary>
        /// Клик по кнопке "Вставить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controlUnit.Paste();
        }

        /// <summary>
        /// Клик по кнопке "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controlUnit.Delete();
        }

        /// <summary>
        /// Клик по кнопке "Сохранить как..."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Клик по кнопке "Открыть"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanClose();

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

        /// <summary>
        /// Клик по кнопке "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Можно ли закрыть файл
        /// </summary>
        /// <returns></returns>
        private bool CanClose()
        {
            if (_controlUnit.IsFileHaveUnsavedChanges())
            {
                var dialogResult = MessageBox.Show(
                    "Есть несохраненные изменения. Сохранить перед закрытием?",
                    "Внимание", MessageBoxButtons.YesNoCancel);

                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        SaveFileToolStripMenuItem_Click(this, new EventArgs());
                        return !_controlUnit.IsFileHaveUnsavedChanges();
                        break;

                    case DialogResult.Cancel:
                        return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Клик по кнопке "Новый"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanClose();

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

        /// <summary>
        /// Закрытие главной формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_controlUnit.IsFileHaveUnsavedChanges())
            {
                var dialogResult = MessageBox.Show(
                    "Есть несохраненные изменения. Сохранить перед закрытием?",
                    "Внимание", MessageBoxButtons.YesNoCancel);

                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        SaveFileToolStripMenuItem_Click(this, e);
                        if (_controlUnit.IsFileHaveUnsavedChanges())
                        {
                            e.Cancel = true;
                        }
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }
    }
}
