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
        public Document document;

        /// <summary>
        /// Конструктор формы настроек документа
        /// </summary>
        public DocumentForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор для изменения существующего документа
        /// </summary>
        /// <param name="document">Документ</param>
        public DocumentForm(Document document)
        {
            this.document = document;
            InitializeComponent();
            this.Text = "Параметры <" + document.Name + ">";

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
            try
            {
                int width = int.Parse(widthTextBox.Text);
                int height = int.Parse(heightTextBox.Text);

                Size docSize = new Size(width, height);
                document = new Document(documentNameTextBox.Text, colorDialog.Color, docSize);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exception)
            {
            }
        }

        /// <summary>
        /// Клик по кнопке "Смена цвета"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.Cancel)
            {
                colorButton.BackColor = colorDialog.Color;
            }
        }
    }
}
