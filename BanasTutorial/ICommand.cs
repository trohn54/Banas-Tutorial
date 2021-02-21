using System;
using System.Collections.Generic;
using System.Text;

namespace BanasTutorial
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }
}
