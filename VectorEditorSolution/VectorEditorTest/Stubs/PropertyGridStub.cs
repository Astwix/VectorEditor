using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
