using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;
namespace corelib.core
{
    public abstract class BaseFun
    {
        public Matrix4x4 Multiply(Matrix4x4 m1,Matrix4x4 m2)
        {
            float[,] r = new float[4, 4];
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 4; ++j)
                    r[i,j] = m1.m[i,0] * m2.m[0,j] +
                                m1.m[i,1] * m2.m[1,j] +
                                m1.m[i,2] * m2.m[2,j] +
                                m1.m[i,3] * m2.m[3,j];
            return new Matrix4x4(r);
        }

        public bool Quadratic(float A, float B, float C, params float [] t ) //求一元二次方程跟
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
    }
}
