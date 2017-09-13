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

    public class Vector:Vec3
    {
        public Vector(float xx,float yy,float zz)
        {
            x = xx; y = yy; z = zz;
        }
    }
    
    public class Ray
    {
        public Vec3 o { get; set; }
        public Vec3 d { get; set; }
    }
}
