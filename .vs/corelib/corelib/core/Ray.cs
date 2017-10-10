
using System;

namespace corelib.core
{

    public class Vec3
    {
        public static Vec3 operator +(Vec3 v1, Vec3 v2)
        {
            return new Vec3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        public Vec3(float xx=0,float yy=0,float zz=0)
        {
            x = xx;y = yy; z = zz;
        }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        
    }

    public class Point3:Vec3
    {
        static public Point3 operator +(Point3 p,Vector v) { return new Point3(p.x + v.x, p.y + v.y, p.z + v.z); }
        static public Vector operator -(Point3 p1,Point3 p2) { return new Vector(p2.x - p1.x, p2.y - p1.y, p2.z - p1.z); }
        //static public Point3 operator *(Point3 p ,float f) { return new Point3(p.x * f, p.y * f, p.z * f); }
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
        static public Vector operator *(Vector v,float theta) { return new Vector(theta * v.x, theta * v.y, theta * v.z); }

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
        public Ray(float maxT = 1.0f / 0, float minT = 0f)
        {
            o = new Point3();
            d = new Vector();
            maxt = maxT; mint = minT;
        }
        public Ray(Point3 p, Vector v, float maxT = 1.0f / 0, float minT = 0f)
        {
            o = p;d = v;maxt = maxT;mint = minT;
        }

        public Point3 GetHitPoint(float thit)
        {
            return o +  thit*d;
        }
        public Point3 o { get; set; }
        public Vector d { get; set; }

        public float maxt { get; set; }

        public float mint { get; set; }

    }
}
