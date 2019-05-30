using System.Windows.Forms;

namespace VectorEditorTest.Stubs
{
    class PropertyGridStub : PropertyGrid
    {
        public void FakePropertyChange()
        {
            OnPropertyValueChanged(new PropertyValueChangedEventArgs
                (SelectedGridItem, SelectedGridItem));
        }
    }
}
