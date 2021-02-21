using System;
using System.Collections.Generic;
using System.Text;

namespace BanasTutorial
{
    class TVRemote
    {
        public static IElectronicDevice GetDevice()
        {
            return new Television();
        }
    }
}
