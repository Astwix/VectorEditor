using System.Drawing;
using VectorEditorProject.Core;
using VectorEditorProject.Core.Commands;

namespace VectorEditorTest.Stubs
{
    /// <summary>
    /// Стаб ChangingDocumentOptionsCommand
    /// </summary>
    class ChangingDocumentOptionsCommandStub : ChangingDocumentOptionsCommand
    {
        /// <summary>
        /// Стаб ChangingDocumentOptionsCommand
        /// </summary>
        /// <param name="controlUnit">controlUnit</param>
        /// <param name="newOptions">Новые параметры</param>
        public ChangingDocumentOptionsCommandStub(IControlUnit controlUnit, 
            Document newOptions) : base(controlUnit, newOptions)
        {
        }

        /// <summary>
        /// Новый размер
        /// </summary>
        public Size NewSize
        {
            get => _newSize;
        }

        /// <summary>
        /// Резервный размер
        /// </summary>
        public Size BackUpSize
        {
            get => _backUpSize;
        }

        /// <summary>
        /// Новый цвет
        /// </summary>
        public Color NewColor
        {
            get => _newColor;
        }

        /// <summary>
        /// Резервный цвет
        /// </summary>
        public Color BackUpColor
        {
            get => _backUpColor;
        }

        /// <summary>
        /// Новое название
        /// </summary>
        public string NewName
        {
            get => _newName;
        }

        /// <summary>
        /// Резервное название
        /// </summary>
        public string BackUpName
        {
            get => _backUpName;
        }
    }

}
