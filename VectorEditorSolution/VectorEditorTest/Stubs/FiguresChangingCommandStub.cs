using System.Collections.Generic;
using SDK;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;

namespace VectorEditorTest.Stubs
{
    /// <summary>
    /// Стаб FiguresChangingCommand
    /// </summary>
    class FiguresChangingCommandStub : FiguresChangingCommand
    {
        /// <summary>
        /// Стаб FiguresChangingCommand
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="newValues">Новые значения</param>
        public FiguresChangingCommandStub(IControlUnit controlUnit, 
            List<FigureBase> newValues) : base(controlUnit, newValues)
        {
        }

        /// <summary>
        /// Стаб FiguresChangingCommand
        /// </summary>
        /// <param name="controlUnit">Control Unit</param>
        /// <param name="newValues">Новое значение</param>
        public FiguresChangingCommandStub(IControlUnit controlUnit, 
            FigureBase newValues) : base(controlUnit, newValues)
        {
        }

        /// <summary>
        /// Список новых значений
        /// </summary>
        public List<FigureBase> NewValues
        {
            get => _newValues;
        }

        /// <summary>
        /// Список старыех значений
        /// </summary>
        public List<FigureBase> OldValues
        {
            get => _oldValues;
        }
    }
}
