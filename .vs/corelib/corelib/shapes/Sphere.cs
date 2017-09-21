using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;

namespace corelib.shapes
{
    public class Sphere:Shape
    {

        public Sphere(float r)
        {
            radius = r;
        }
        float radius;
        public override bool Intersect(ref Transform o2w, Ray ray,ref DifferentialGeometry dg)
        {
            float A = ray.d.x * ray.d.x + ray.d.y * ray.d.y + ray.d.z * ray.d.z;
            float B = 2 * (ray.d.x * ray.o.x + ray.d.y * ray.o.y + ray.d.z * ray.o.z);
            float C = ray.o.x * ray.o.x + ray.o.y * ray.o.y +
                      ray.o.z * ray.o.z - radius * radius;


            float [] t = new float[2];
            if (!Quadratic(A, B, C, t))
                return false;
            

            if (t[0] > ray.maxt || t[1] < ray.mint)
                return false;
            float thit = t[0];
            if (t[0] < ray.mint)
            {
                thit = t[1];
                if (thit > ray.maxt) return false;
            }
            return true;
        }
    }
}
