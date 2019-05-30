using System;
using System.Drawing;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;

namespace VectorEditorTest.Stubs
{
    /// <summary>
    /// Стаб AddPointCommand
    /// </summary>
    class AddPointCommandStub : AddPointCommand
    {
        /// <summary>
        /// Стаб AddPointCommand
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <param name="point">Добавляемая точка</param>
        /// <param name="controlUnit">ControlUnit</param>
        public AddPointCommandStub(FigureBase figure, PointF point, 
            IControlUnit controlUnit) : base(figure, point, controlUnit)
        {
        }

        /// <summary>
        /// Добавляемая точка
        /// </summary>
        public PointF Point
        {
            get => _point;
        }

        /// <summary>
        /// GUID целевой фигуры
        /// </summary>
        public Guid FigureGuid
        {
            get => _guid;
        }
    }

}
