using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;
namespace corelib.core
{
    public abstract class BaseFun
    {
        protected float INFINITY = 99999999;

        protected float Lerp(float t, float v1, float v2)
        {
            return (1.0f - t) * v1 + t * v2;
        }

        protected float Radians(float deg)
        {
            return ((float)Math.PI / 180.0f) * deg;
        }

        protected float Degress(float rad)
        {
            return (180.0f / (float)Math.PI) * rad;
        }

        protected Matrix4x4 Multiply(Matrix4x4 m1, Matrix4x4 m2)
        {
            float[,] r = new float[4, 4];
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 4; ++j)
                    r[i, j] = m1.m[i, 0] * m2.m[0, j] +
                                m1.m[i, 1] * m2.m[1, j] +
                                m1.m[i, 2] * m2.m[2, j] +
                                m1.m[i, 3] * m2.m[3, j];
            return new Matrix4x4(r);
        }

        protected bool Quadratic(float A, float B, float C, params float[] t) //求一元二次方程跟
        {
            // Find quadratic discriminant
            float discrim = B * B - 4.0f * A * C;
            if (discrim < .0f) return false;
            float rootDiscrim = (float)Math.Sqrt(discrim);

            // Compute quadratic _t_ values
            float q;
            if (B < 0) q = -.5f * (B - rootDiscrim);
            else q = -.5f * (B + rootDiscrim);
            t[0] = q / A;
            t[1] = C / q;
            if (t[0] > t[1])
            {
                float temp = t[0];
                t[0] = t[1];
                t[1] = temp;
            }

            return true;
        }

        protected float Dot(Vector v1, Vector v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        protected Vector Cross(Vector v1, Vector v2)
        {
            float v1x = v1.x, v1y = v1.y, v1z = v1.z;
            float  v2x = v2.x, v2y = v2.y, v2z = v2.z;
            return new Vector((v1y * v2z) - (v1z * v2y),
                          (v1z * v2x) - (v1x * v2z),
                          (v1x * v2y) - (v1y * v2x));
        }

    }
}
