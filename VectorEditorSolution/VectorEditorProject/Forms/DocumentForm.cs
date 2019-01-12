using System;
using System.Drawing;
using System.Windows.Forms;
using VectorEditorProject.Core;

namespace VectorEditorProject.Forms
{
    /// <summary>
    /// Форма настроек документа
    /// </summary>
    public partial class DocumentForm : Form
    {
        /// <summary>
        /// Документ
        /// </summary>
        //public Document document;

        /// <summary>
        /// Конструктор формы настроек документа
        /// </summary>
        public DocumentForm()
        {
            InitializeComponent();

            documentNameTextBox.Text = "Untitled";
            widthTextBox.Text = "400";
            heightTextBox.Text = "400";
            colorDialog.Color = Color.White;
            colorButton.BackColor = colorDialog.Color;
        }

        /// <summary>
        /// Конструктор для изменения существующего документа
        /// </summary>
        /// <param name="document">Документ</param>
        public DocumentForm(Document document)
        {
            InitializeComponent();

            documentNameTextBox.Text = document.Name;
            widthTextBox.Text = document.Size.Width.ToString();
            heightTextBox.Text = document.Size.Height.ToString();
            colorDialog.Color = document.Color;
            colorButton.BackColor = colorDialog.Color;
        }

        /// <summary>
        /// Клик по кнопке "ОК"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(widthTextBox.Text, out var width) &&
                int.TryParse(heightTextBox.Text, out var height) &&
                width > 1 && 
                height > 1)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Клик по кнопке "Смена цвета"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.Cancel)
            {
                colorButton.BackColor = colorDialog.Color;
            }
        }

        /// <summary>
        /// Создание документа
        /// </summary>
        /// <returns>Параметры документа</returns>
        public Document CreateDocument()
        {
            int.TryParse(widthTextBox.Text, out var width);
            int.TryParse(heightTextBox.Text, out var height);

            return new Document(documentNameTextBox.Text, colorDialog.Color, new Size(width, height));
        }
    }
}
