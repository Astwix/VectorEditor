using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using VectorEditorProject.Core.Figures.Utility;

namespace VectorEditorProject.Forms
{
    public partial class FigureSettingsControl : UserControl
    {
        private int _lastValidLineWidth = 1;

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
        }

        private void lineColorButton_Click(object sender, EventArgs e)
        {
            if (lineColorDialog.ShowDialog() != DialogResult.Cancel)
            {
                LineColorButton.BackColor = lineColorDialog.Color;
            }
        }

        private void fillColorButton_Click(object sender, EventArgs e)
        {
            if (fillColorDialog.ShowDialog() != DialogResult.Cancel)
            {
                FillColorButton.BackColor = fillColorDialog.Color;
            }
        }

        public LineSettings GetLineSettings()
        {
            int width = 1;
            if (int.TryParse(LineWidthTextBox.Text, out width))
            {
                _lastValidLineWidth = width;
            }
            else
            {
                width = _lastValidLineWidth;
                LineWidthTextBox.Text = _lastValidLineWidth.ToString();
            }
            return new LineSettings(lineColorDialog.Color, width, (DashStyle)LineTypeComboBox.SelectedItem);
        }

        public FillSettings GetFillSettings()
        {
            return new FillSettings(fillColorDialog.Color);
        }
    }
}
