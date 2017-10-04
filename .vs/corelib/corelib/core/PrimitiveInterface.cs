using corelib.bsdf;
using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    interface PrimitiveInterface
    {
        UInt32 PrimitiveId { get; set; }
        UInt32 nextPrimitiveId { get; set; }
        BSDF GetBSDF();
        bool CanInsection();
    }
}
