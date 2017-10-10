using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    public class RayDifferential : Ray
    {
        public RayDifferential(Point3 p, Vector v, float maxT = 1.0f / 0, float minT = 0f) : base(p, v)
        {
            o = p; d = v; maxt = maxT; mint = minT;
            hasDifferentials = false;
        }

        public void ScaleDifferentials(float s)
        {
            rxOrigin = o + (rxOrigin - o) * s;
            ryOrigin = o + (ryOrigin - o) * s;
            rxDirection = d + (rxDirection - d) * s;
            ryDirection = d + (ryDirection - d) * s;
        }

        public bool hasDifferentials { get; set; }
        public Point3 rxOrigin, ryOrigin;
        public Vector rxDirection, ryDirection;

    }
}
