using System;

namespace corelib
{

    public class Vec3
    {
        
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class Point3:Vec3
    {
        public Point3(float xx, float yy, float zz)
        {
            x = xx; y = yy; z = zz;
        }
    }

    public class Vector
    {
        public Vec3 o;
        public Vec3 d;
    }

    public class Ray
    {
        public Vector o;
    }
}
