using System;
using System.Collections.Generic;
using System.Text;
using corelib.bsdf;

namespace corelib.core
{
    public class Primitive:PrimitiveInterface
    {
        public BSDF bsdf;
        public Shape shape;
       // public virtual BSDF GetBsdf() { return null; }

        public virtual bool isInsection() { return false; }

        public virtual BSDF GetBSDF() { return null; }
        
    }
}
