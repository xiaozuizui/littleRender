using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    public class Shape:BaseFun,ShapeInterface
    {
           public virtual bool Intersect(ref Transform o2w,Ray r,ref DifferentialGeometry dg) { return false; } 
    }
}
