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

namespace VectorEditorProject.Forms
{
    public partial class DocumentForm : Form
    {
        public Document document;

        public DocumentForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор для изменения существующего документа
        /// </summary>
        /// <param name="document"></param>
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

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != DialogResult.Cancel)
            {
                colorButton.BackColor = colorDialog.Color;
            }
        }
    }
}
