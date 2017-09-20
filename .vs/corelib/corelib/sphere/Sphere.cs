using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;

namespace corelib.sphere
{
    class Sphere:Shape
    {
        float radius;
        public override bool Intersect(Ray r,DifferentialGeometry dg)
        {

            return true;
        }
    }
}
