using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    public class Quaternion
    {

        static public Quaternion operator+(Quaternion q1,Quaternion q2) { return new Quaternion(q1.v + q2.v, q1.w + q2.w);  }
        static public Quaternion operator- (Quaternion q1,Quaternion q2) { return new Quaternion(q1.v - q2.v, q1.w - q2.w); }
        static public Quaternion operator *(Quaternion q1, float f) { return new Quaternion(q1.v * f, q1.w * f); }
        static public Quaternion operator /(Quaternion q1, float f) { return new Quaternion(q1.v / f, q1.w / f); }

        public Quaternion(Vector V,float W)
        {
            v = V;
            w = W;
        }
        public Vector v { get; set; }
        public float w { get; set; }
    }
}
