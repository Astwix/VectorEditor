using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VectorEditorProject.Figures.Utility;

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
            lineColorButton.BackColor = lineColorDialog.Color;
            fillColorButton.BackColor = fillColorDialog.Color;

            lineTypeComboBox.Items.Add(DashStyle.Solid);
            lineTypeComboBox.Items.Add(DashStyle.Dash);
            lineTypeComboBox.Items.Add(DashStyle.DashDot);
            lineTypeComboBox.Items.Add(DashStyle.DashDotDot);
            lineTypeComboBox.Items.Add(DashStyle.Dot);
            lineTypeComboBox.SelectedIndex = 0;
        }

        private void lineColorButton_Click(object sender, EventArgs e)
        {
            if (lineColorDialog.ShowDialog() != DialogResult.Cancel)
            {
                lineColorButton.BackColor = lineColorDialog.Color;
            }
        }

        private void fillColorButton_Click(object sender, EventArgs e)
        {
            if (fillColorDialog.ShowDialog() != DialogResult.Cancel)
            {
                fillColorButton.BackColor = fillColorDialog.Color;
            }
        }

        public LineSettings GetLineSettings()
        {
            int width = 1;
            if (int.TryParse(lineWidthTextBox.Text, out width))
            {
                _lastValidLineWidth = width;
            }
            else
            {
                width = _lastValidLineWidth;
                lineWidthTextBox.Text = _lastValidLineWidth.ToString();
            }
            return new LineSettings(lineColorDialog.Color, width, (DashStyle)lineTypeComboBox.SelectedItem);
        }

        public FillSettings GetFillSettings()
        {
            return new FillSettings(fillColorDialog.Color);
        }
    }
}
