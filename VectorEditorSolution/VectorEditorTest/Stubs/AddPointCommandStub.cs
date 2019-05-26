using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;

namespace VectorEditorTest.Stubs
{
    class AddPointCommandStub : AddPointCommand
    {
        public AddPointCommandStub(FigureBase figure, PointF point, 
            IControlUnit controlUnit) : base(figure, point, controlUnit)
        {
        }

        public PointF Point
        {
            get => _point;
        }

        public Guid FigureGuid
        {
            get => _guid;
        }
    }

}
