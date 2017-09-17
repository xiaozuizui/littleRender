using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    public class Shape:ShapeInterface
    {
           public virtual bool Intersect() { return false; } 
    }
}
