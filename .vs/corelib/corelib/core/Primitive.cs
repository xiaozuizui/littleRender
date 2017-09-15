using System;
using System.Collections.Generic;
using System.Text;
using corelib.bsdf;

namespace corelib.core
{
    public class Primitive:PrimitiveInterface
    {
        public virtual BSDF GetBsdf() { return null; }

        public virtual bool isInsection() { return false; }
        

        
    }
}
