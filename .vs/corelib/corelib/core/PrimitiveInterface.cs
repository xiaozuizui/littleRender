using corelib.bsdf;
using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    interface PrimitiveInterface
    {
        
        BSDF GetBSDF();
        bool isInsection();
    }
}
