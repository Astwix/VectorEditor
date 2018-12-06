using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorEditorProject.Figures.Utility;

namespace VectorEditorProject.Figures
{
    public abstract class FilledBaseFigure : BaseFigure
    {
        protected FillSettings _fillSettings;

        public FillSettings FillSettings { get => _fillSettings; set => _fillSettings = value; }
    }
}
