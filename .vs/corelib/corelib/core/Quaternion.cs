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

        public Quaternion()
        {
            v =new  Vector();
            w = 1.0f;
        }
        public Quaternion(Transform t)
        {
            v = new Vector();
            Matrix4x4  m = t.m;
            float trace = t.m.m[0,0] + t.m.m[1,1] + t.m.m[2,2];
            if (trace > 0.0f)
            {
                // Compute w from matrix trace, then xyz
                // 4w^2 = m[0,0] + m[1,1] + m[2,2] + m[3,3] (but m[3,3] == 1)
                float s =(float)Math.Sqrt(trace + 1.0);
                w = s / 2.0f;
                s = 0.5f / s;
                v.x = (m.m[2,1] - m.m[1,2]) * s;
                v.y = (m.m[0,2] - m.m[2,0]) * s;
                v.z = (m.m[1,0] - m.m[0,1]) * s;
            }
            else
            {
                // Compute largest of $x$, $y$, or $z$, then remaining components
                 int [] nxt = { 1, 2, 0 };
                float[]  q = new float[3];
                int i = 0;
                if (m.m[1,1] > m.m[0,0]) i = 1;
                if (m.m[2,2] > m.m[i,i]) i = 2;
                int j = nxt[i];
                int k = nxt[j];
                float s = (float)(float)Math.Sqrt((m.m[i,i] - (m.m[j,j] + m.m[k,k])) + 1.0);
                q[i] = s * 0.5f;
                if (s != 0.0f) s = 0.5f / s;
                w = (m.m[k,j] - m.m[j,k]) * s;
                q[j] = (m.m[j,i] + m.m[i,j]) * s;
                q[k] = (m.m[k,i] + m.m[i,k]) * s;
                v.x = q[0];
                v.y = q[1];
                v.z = q[2];
            }
        }
        public Quaternion(Vector V,float W)
        {
            v = V;
            w = W;
        }
        public Quaternion(Quaternion q)
        {
            v = q.v;
            w = q.w;
        }

        /// <summary>
        /// v' = q*v*q-1
        /// v' = M*v
        /// </summary>
        /// <returns></returns>
        public Transform ToTransform()
        {
            float xx = v.x * v.x, yy = v.y * v.y, zz = v.z * v.z;
            float xy = v.x * v.y, xz = v.x * v.z, yz = v.y * v.z;
            float wx = v.x * w, wy = v.y * w, wz = v.z * w;

            Matrix4x4 m = new Matrix4x4();
            m.m[0,0] = 1.0f - 2.0f * (yy + zz);
            m.m[0,1] = 2.0f * (xy + wz);
            m.m[0,2] = 2.0f * (xz - wy);
            m.m[1,0] = 2.0f * (xy - wz);
            m.m[1,1] = 1.0f - 2.0f * (xx + zz);
            m.m[1,2] = 2.0f * (yz + wx);
            m.m[2,0] = 2.0f * (xz + wy);
            m.m[2,1] = 2.0f * (yz - wx);
            m.m[2,2] = 1.0f - 2.0f * (xx + yy);

            // Transpose since we are left-handed.  Ugh.
            return new Transform(LR.Transpose(m), m);
        }
        public Vector v { get; set; }
        public float w { get; set; }
    }
}
