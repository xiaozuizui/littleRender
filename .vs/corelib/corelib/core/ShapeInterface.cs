using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    interface ShapeInterface
    {
        bool Intersect(ref Transform o2w,Ray r,ref DifferentialGeometry dg);
        
    }
}
