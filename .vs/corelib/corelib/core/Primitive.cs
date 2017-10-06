using System;
using System.Collections.Generic;
using System.Text;
using corelib.bsdf;

namespace corelib.core
{
    public class Primitive:PrimitiveInterface
    {
        public UInt32 PrimitiveId { get; set; }
        public UInt32 nextPrimitiveId { get; set; }
       
        public virtual BSDF GetBSDF() { return null; }

        public virtual bool CanInsection() { return false; }

       // public virtual BSDF GetBSDF() { return null; }
        
    }

    public class GeometricPrimitive:Primitive
    {
        private Shape shape;
        private Mat
    }

}
