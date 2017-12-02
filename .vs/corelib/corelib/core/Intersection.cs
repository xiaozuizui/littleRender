using System;
using System.Collections.Generic;
using System.Text;
using corelib.bsdf;

namespace corelib.core
{
    public class Intersection
    {
        public Intersection()
        {
            primitive = null;
            shapeId = primitiveId = 0;
        }
        public Primitive primitive { get; set; }
        public UInt32 shapeId { get; set; }
        public UInt32 primitiveId{get;set;}
        public DifferentialGeometry dg { get; set; }
       // public BSDF GetBsdf() { return null; }

    }
}
