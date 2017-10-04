using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    interface ShapeInterface
    {
        Transform o2w { get; set; }
        Transform w2o { get; set; }
        bool Intersect( Ray r,ref DifferentialGeometry dg);
        
        
    }
}
