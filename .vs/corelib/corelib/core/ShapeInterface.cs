using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    interface ShapeInterface
    {
        bool Intersect(Transform o2w,Ray r,DifferentialGeometry dg);
        
    }
}
