using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    public class Shape:ShapeInterface
    {
        public Shape(Transform O2W=null,Transform W2O=null)
        {
            o2w = O2W;w2o = W2O;
        }
        public Transform o2w { get; set; }
        public Transform w2o { get; set; }
        public virtual bool Intersect( Ray r,ref DifferentialGeometry dg) { return false; } 
    }
}
