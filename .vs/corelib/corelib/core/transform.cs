﻿using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    public class Matrix4x4
    {
        //public fun
        public Matrix4x4()
        {
            m = new float[4, 4];
        }
        public Matrix4x4(float [,] mm)
        {
            m = new float[4, 4];
            m = mm;
        }

       
        public Matrix4x4(float a11,float a12,float a13,float a14,
                                float a21,float a22,float a23,float a24,
                                float a31,float a32,float a33,float a34,
                                float a41,float a42,float a43,float a44)
        {
            m = new float[4, 4];
            m[0, 0] = a11;m[0, 1] = a12;m[0, 2] = a13;m[0, 3] = a14;
            m[1, 0] = a21;m[1, 1] = a22;m[1, 2] = a23;m[1, 3] = a24;
            m[2, 0] = a31;m[2, 1] = a32;m[2, 2] = a33;m[2, 3] = a34;
            m[3, 0] = a41;m[3, 1] = a42;m[3, 2] = a43;m[3, 3] = a44;
        }


    
        public float [,] m;

    }

    public class Transform:BaseFun
    {

        public Transform()
        {
            m = new Matrix4x4();
            mInv = new Matrix4x4();
            
        }
         
        public Transform(Matrix4x4 M)
        {
         ;

            m = M;
            mInv = Inverse(M);
        }

        public Transform(Matrix4x4 M,Matrix4x4 invM)
        {
            

            m = M;
            mInv = invM;
        }

        public Point3 CaculatePoint(Point3 pt)//pt 通过transform变换
        {
            Point3 ptrans = new Point3();
            float x = pt.x, y = pt.y, z = pt.z;
            ptrans.x = m.m[0,0] * x + m.m[0,1] * y + m.m[0,2] * z + m.m[0,3];
            ptrans.y = m.m[1,0] * x + m.m[1,1] *  y + m.m[1,2] * z + m.m[1,3];
            ptrans.z = m.m[2,0] * x + m.m[2,1] * y + m.m[2,2] * z + m.m[2,3];
            float w = m.m[3,0] * x + m.m[3,1] * y + m.m[3,2] * z + m.m[3,3];
            if (w != 1.0f) ptrans = ptrans/ w;
            return ptrans;
        }

        internal Ray CaculateVector(Ray ray)
        {
            
            throw new NotImplementedException();
        }

        public Vector CaculateVector(Vector v)
        {
            float x = v.x, y = v.y, z = v.z;
            return new Vector(m.m[0,0] * x + m.m[0,1] * y + m.m[0,2] * z,
                          m.m[1,0] * x + m.m[1,1] * y + m.m[1,2] * z,
                          m.m[2,0] * x + m.m[2,1] * y + m.m[2,2] * z);
        }
        public Matrix4x4 m { get; set; }
        public Matrix4x4 mInv { get; set; }
    }


    public class AnimatedTransform:BaseFun
    {
        public AnimatedTransform(Transform transform1,float time1, Transform transform2,float time2)
        {
            startTime = time1;
            endTime = time2;
            startTransform = transform1;
            endTransform = transform2;
            T = new Vector[2];
            R = new Quaternion[2];
            S = new Matrix4x4[2];
            Decompose(startTransform.m, T[0], R[0], S[0]);
            Decompose(endTransform.m, T[1], R[0], S[0]);

        }

       public   void Decompose(Matrix4x4 m,Vector T,Quaternion Rquat,Matrix4x4 S)
        {
            T.x = m.m[0,3];
            T.y = m.m[1,3];
            T.z = m.m[2,3];

            // Compute new transformation matrix _M_ without translation
            Matrix4x4 M = m;
            for (int i = 0; i < 3; ++i)
                M.m[i,3] = M.m[3,i] = 0.0f;
            M.m[3,3] = 1.0f;
            
            // Extract rotation _R_ from transformation matrix
            float norm;
            int count = 0;
            Matrix4x4 R = M;
            do
            {
                // Compute next matrix _Rnext_ in series
                Matrix4x4 Rnext = new Matrix4x4();
                Matrix4x4 Rit = Inverse(Transpose(R));
                for (int i = 0; i < 4; ++i)
                    for (int j = 0; j < 4; ++j)
                        Rnext.m[i,j] = 0.5f * (R.m[i,j] + Rit.m[i,j]);

                // Compute norm of difference between _R_ and _Rnext_
                norm = 0.0f;
                for (int i = 0; i < 3; ++i)
                {
                    float n = Math.Abs(R.m[i,0] - Rnext.m[i,0]) +
                              Math.Abs(R.m[i,1] - Rnext.m[i,1]) +
                              Math.Abs(R.m[i,2] - Rnext.m[i,2]);
                    norm = Math.Max(norm, n);
                }
                R = Rnext;
            } while (++count < 100 && norm > .0001f);
            // XXX TODO FIXME deal with flip...
            Rquat = new Quaternion(R);

            // Compute scale _S_ using rotation and original matrix
            S = Multiply(Inverse(R), M);
        }

        private float startTime, endTime;
        Transform startTransform, endTransform;
        bool actuallyAnimated;
        Vector[] T;
        Quaternion[] R;
        Matrix4x4[] S;
        
    }
}
