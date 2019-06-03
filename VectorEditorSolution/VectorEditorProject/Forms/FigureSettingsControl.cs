using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SDK;

namespace VectorEditorProject.Forms
{
    /// <summary>
    /// Пользовательский control с настройками фигуры
    /// </summary>
    public partial class FigureSettingsControl : UserControl
    {
        /// <summary>
        /// Толщина линии
        /// </summary>
        private int _lastValidLineWidth = 1;

        /// <summary>
        /// Тип линии
        /// </summary>
        private int _lastValidLineType;

        /// <summary>
        /// Конструктор control'а с настройками фигуры
        /// </summary>
        public FigureSettingsControl()
        {
            InitializeComponent();

            lineColorDialog.Color = Color.Black;
            fillColorDialog.Color = Color.White;
            LineColorButton.BackColor = lineColorDialog.Color;
            FillColorButton.BackColor = fillColorDialog.Color;

            LineTypeComboBox.Items.Add(DashStyle.Solid);
            LineTypeComboBox.Items.Add(DashStyle.Dash);
            LineTypeComboBox.Items.Add(DashStyle.DashDot);
            LineTypeComboBox.Items.Add(DashStyle.DashDotDot);
            LineTypeComboBox.Items.Add(DashStyle.Dot);
            LineTypeComboBox.SelectedIndex = 0;

            _lastValidLineType = LineTypeComboBox.SelectedIndex;
        }

        /// <summary>
        /// Клик по кнопке "цвет линии"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineColorButton_Click(object sender, EventArgs e)
        {
            if (lineColorDialog.ShowDialog() != DialogResult.Cancel)
            {
                LineColorButton.BackColor = lineColorDialog.Color;
            }
        }

        /// <summary>
        /// Клик по кнопке "цвет заливки"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillColorButton_Click(object sender, EventArgs e)
        {
            if (fillColorDialog.ShowDialog() != DialogResult.Cancel)
            {
                FillColorButton.BackColor = fillColorDialog.Color;
            }
        }

        /// <summary>
        /// Получить настройки линии
        /// </summary>
        /// <returns></returns>
        public LineSettings GetLineSettings()
        {
            if (!int.TryParse(LineWidthTextBox.Text, out var width) || (width < 1))
            {
                width = _lastValidLineWidth;
                LineWidthTextBox.Text = _lastValidLineWidth.ToString();
            }

            _lastValidLineWidth = width;

            if (LineTypeComboBox.SelectedItem == null)
            {
                LineTypeComboBox.SelectedIndex = _lastValidLineType;
            }

            _lastValidLineType = LineTypeComboBox.SelectedIndex;

            return new LineSettings(lineColorDialog.Color, width,
                (DashStyle) LineTypeComboBox.SelectedItem);
        }

        /// <summary>
        /// Получить настройки заливки
        /// </summary>
        /// <returns></returns>
        public FillSettings GetFillSettings()
        {
            return new FillSettings(fillColorDialog.Color);
        }
    }
}
