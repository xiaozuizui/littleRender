using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    public class Shape:BaseFun,ShapeInterface
    {
           public virtual bool Intersect(Transform o2w,Ray r,DifferentialGeometry dg) { return false; } 
    }
}
