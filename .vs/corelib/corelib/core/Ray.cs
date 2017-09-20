using System;

namespace corelib.core
{

    public class Vec3
    {
        public Vec3(float xx=0,float yy=0,float zz=0)
        {
            x = xx;y = yy; z = zz;
        }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public static Vec3 operator +(Vec3 v1,Vec3 v2)
        {
            return new Vec3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
    }

    public class Point3:Vec3
    {
        public Point3(float xx=0, float yy=0, float zz=0)
        {
            x = xx; y = yy; z = zz;
        }
    }

    public class Vector : Vec3
    {

        static public Vector operator +(Vector v1 ,Vector v2) { return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z); }
        static public Vector operator  -(Vector v1,Vector v2) { return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z); }
        static public Vector operator *(float theta,Vector v) { return new Vector(theta * v.x, theta * v.y, theta * v.z); }

        public Vector(float xx=0,float yy=0,float zz=0)
        {
           x = xx; y = yy; z = zz;
        }
    }
    
    public class Normal:Vec3
    {
        public Normal(float xx = 0, float yy = 0, float zz = 0)
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
