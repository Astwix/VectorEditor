using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorEditorProject.Core.Commands
{
    public abstract class BaseCommand
    {
        public abstract void Do();
        public abstract void Undo();
    }
}
