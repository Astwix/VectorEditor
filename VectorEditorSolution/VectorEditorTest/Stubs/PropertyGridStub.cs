using System.Windows.Forms;

namespace VectorEditorTest.Stubs
{
    /// <summary>
    /// Стаб PropertyGrid
    /// </summary>
    class PropertyGridStub : PropertyGrid
    {
        /// <summary>
        /// Фейковый вызов события "Изменение свойства"
        /// </summary>
        public void FakePropertyChange()
        {
            OnPropertyValueChanged(new PropertyValueChangedEventArgs
                (SelectedGridItem, SelectedGridItem));
        }
    }
}
