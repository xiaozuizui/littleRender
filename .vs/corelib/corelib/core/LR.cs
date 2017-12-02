using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;

namespace corelib.core
{
    public static class LR
    {
        #region Swap 
        /// <summary>
        /// swap two object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        static public void Swap<T>(T first, T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
        #endregion

        #region Lerp
        /// <summary>
        /// return (1.0f - t) * v1 + t * v2;
        /// </summary>
        /// <param name="t"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        static public float Lerp(float t, float v1, float v2)
        {
            return (1.0f - t) * v1 + t * v2;
        }
        #endregion

        #region Clamp
        /// <summary>
        /// Clamp return high or low if val not in [low,high]
        /// </summary>
        /// <param name="val"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        static public float Clamp(float val, float low, float high)
        {
            if (val < low) return low;
            else if (val > high) return high;
            else return val;
        }
        /// <summary>
        ///  Clamp return high or low if val not in [low,high]
        /// </summary>
        /// <param name="val"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        static public int Clamp(int val, int low, int high)
        {
            if (val < low) return low;
            else if (val > high) return high;
            else return val;
        }
        #endregion

        #region Deg to Rad
        /// <summary>
        /// deg to rad
        /// </summary>
        /// <param name="deg">degree</param>
        /// <returns>rad</returns>
        static public float Radians(float deg)
        {
            return ((float)Math.PI / 180.0f) * deg;
        }
        #endregion

        #region Rad to Deg
        /// <summary>
        /// rad to deg
        /// </summary>
        /// <param name="rad">rad</param>
        /// <returns>degree</returns>
        static public float Degress(float rad)
        {
            return (180.0f / (float)(float)Math.PI) * rad;
        }
        #endregion

        #region Matrix and Transform Mutiply

        /// <summary>
        /// return Matrix1*Matrix2
        /// </summary>
        /// <param name="m1">Matrix1</param>
        /// <param name="m2">Matrix2</param>
        /// <returns></returns>
        static public Matrix4x4 Multiply(Matrix4x4 m1, Matrix4x4 m2)
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

        /// <summary>
        /// return Matrix1*Matrix2*Matrix3
        /// </summary>
        /// <param name="m1">Matrix1</param>
        /// <param name="m2">Matrix2</param>
        /// <param name="m3">Matrix3</param>
        /// <returns></returns>
        static Matrix4x4 Multiply(Matrix4x4 m1, Matrix4x4 m2, Matrix4x4 m3)
        {
            return Multiply(Multiply(m1, m2), m3);
        }

        /// <summary>
        /// reutrn Transform1*Transform2
        /// </summary>
        /// <param name="t1">Transform1</param>
        /// <param name="t2">Transform2</param>
        /// <returns></returns>
        static public Transform Multiply(Transform t1, Transform t2)
        {
            Matrix4x4 m1 = Multiply(t1.m, t2.m);
            Matrix4x4 m2 = Multiply(t2.mInv, t1.mInv);
            return new Transform(m1, m2);
        }

        /// <summary>
        /// reutrn Transform1*Transform2*Transform3
        /// </summary>
        /// <param name="t1">Transform1</param>
        /// <param name="t2">Transform2</param>
        /// <param name="t3">Transform3</param>
        /// <returns></returns>
        static public Transform Multiply(Transform t1, Transform t2, Transform t3)
        {
            return Multiply(Multiply(t1, t2), t3);
        }

        #endregion

        #region Transpose
        /// <summary>
        /// Transpose Matrix
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        static public Matrix4x4 Transpose(Matrix4x4 m)
        {
            return new Matrix4x4(m.m[0, 0], m.m[1, 0], m.m[2, 0], m.m[3, 0],
                m.m[0, 1], m.m[1, 1], m.m[2, 1], m.m[3, 1],
                m.m[0, 2], m.m[1, 2], m.m[2, 2], m.m[3, 2],
                m.m[0, 3], m.m[1, 3], m.m[2, 3], m.m[3, 3]);
        }
        #endregion

        #region Inverse
        /// <summary>
        /// Inverse Matrix
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        static public Matrix4x4 Inverse(Matrix4x4 m)
        {

            int[] indxc = new int[4];
            int[] indxr = new int[4];
            int[] ipiv = new int[4] { 0,0,0,0};
           
            float[,] minv = new float[4, 4];
            for (int i = 0; i < 4; i++)//使用值传递
                for (int j = 0; j < 4; j++)
                    minv[i, j] = m.m[i, j];

            for (int i = 0; i < 4; i++)
            {
                int irow = -1, icol = -1;
                float big = 0.0f;
                // Choose pivot
                for (int j = 0; j < 4; j++)
                {
                    if (ipiv[j] != 1)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            if (ipiv[k] == 0)
                            {
                                if ((float)Math.Abs(minv[j, k]) >= big)
                                {
                                    big = ((float)Math.Abs(minv[j, k]));
                                    irow = j;
                                    icol = k;
                                }
                            }
                            else if (ipiv[k] > 1)
                                return null;
                            // Error("Singular matrix in MatrixInvert");
                        }
                    }
                }
                ++ipiv[icol];
                // Swap rows _irow_ and _icol_ for pivot
                if (irow != icol)
                {
                    for (int k = 0; k < 4; ++k)
                        Swap(minv[irow, k], minv[icol, k]);
                }
                indxr[i] = irow;
                indxc[i] = icol;
                if (minv[icol, icol] == 0.0f)
                    return null;
                //Error("Singular matrix in MatrixInvert");

                // Set $m[icol][icol]$ to one by scaling row _icol_ appropriately
                float pivinv = 1.0f / minv[icol, icol];
                minv[icol, icol] = 1.0f;
                for (int j = 0; j < 4; j++)
                    minv[icol, j] *= pivinv;

                // Subtract this row from others to zero out their columns
                for (int j = 0; j < 4; j++)
                {
                    if (j != icol)
                    {
                        float save = minv[j, icol];
                        minv[j, icol] = 0;
                        for (int k = 0; k < 4; k++)
                            minv[j, k] -= minv[icol, k] * save;
                    }
                }
            }
            // Swap columns to reflect permutation
            for (int j = 3; j >= 0; j--)
            {
                if (indxr[j] != indxc[j])
                {
                    for (int k = 0; k < 4; k++)
                        Swap(minv[k, indxr[j]], minv[k, indxc[j]]);
                }
            }
            return new Matrix4x4(minv);
        }

        /// <summary>
        /// Inverse Tansform
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        static public Transform Inverse(Transform t)
        {
            return new Transform(t.mInv, t.m);
        }
        #endregion

        #region Scale
        /// <summary>
        /// Scale Transform
        /// </summary>
        /// <param name="x">x scale</param>
        /// <param name="y">y scale</param>
        /// <param name="z">z scale</param>
        /// <returns></returns>
        static public Transform Scale(float x, float y, float z)
        {
            Matrix4x4 m = new Matrix4x4(x, 0, 0, 0,
                0, y, 0, 0,
                0, 0, z, 0,
                0, 0, 0, 1);
            Matrix4x4 minv = new Matrix4x4(1.0f / x, 0, 0, 0,
                   0, 1.0f / y, 0, 0,
                   0, 0, 1.0f / z, 0,
                   0, 0, 0, 1);

            return new Transform(m, minv);
        }
        #endregion

        #region Translate
        /// <summary>
        /// Translate Transform
        /// </summary>
        /// <param name="delta">delta vector</param>
        /// <returns></returns>
        static public Transform Translate(Vector delta)
        {
            Matrix4x4 m = new Matrix4x4(1, 0, 0, delta.x,
               0, 1, 0, delta.y,
               0, 0, 1, delta.z,
               0, 0, 0, 1);
            Matrix4x4 minv = new Matrix4x4(1, 0, 0, -delta.x,
                       0, 1, 0, -delta.y,
                       0, 0, 1, -delta.z,
                       0, 0, 0, 1);
            return new Transform(m, minv);
        }
        #endregion

        #region Rotate
        /// <summary>
        /// Rotate X Transform
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        static public Transform RotateX(float angle)
        {
            float sin_t = (float)(float)Math.Sin(Radians(angle));
            float cos_t = (float)(float)Math.Cos(Radians(angle));
            Matrix4x4 m = new Matrix4x4(1, 0, 0, 0,
                0, cos_t, -sin_t, 0,
                0, sin_t, cos_t, 0,
                0, 0, 0, 1);
            return new Transform(m, Transpose(m));
        }

        /// <summary>
        /// Rotate Y Transform
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        static public Transform RotateY(float angle)
        {
            float sin_t = (float)(float)Math.Sin(Radians(angle));
            float cos_t = (float)(float)Math.Cos(Radians(angle));
            Matrix4x4 m = new Matrix4x4(cos_t, 0, sin_t, 0,
                 0, 1, 0, 0,
                -sin_t, 0, cos_t, 0,
                 0, 0, 0, 1);
            return new Transform(m, Transpose(m));
        }

        /// <summary>
        /// Rotate Z Tranform
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        static public Transform RotateZ(float angle)
        {
            float sin_t = (float)(float)Math.Sin(Radians(angle));
            float cos_t = (float)(float)Math.Cos(Radians(angle));
            Matrix4x4 m = new Matrix4x4(cos_t, -sin_t, 0, 0,
                sin_t, cos_t, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
            return new Transform(m, Transpose(m));
        }
        #endregion

        #region Orthographic
        /// <summary>
        /// Return Orthographic Transform (CameraToScreen)
        /// </summary>
        /// <param name="znear">near</param>
        /// <param name="zfar">far</param>
        /// <returns></returns>
        static public Transform Orthographic(float znear, float zfar)
        {
            return Multiply(Scale(1.0f, 1.0f, 1.0f / (zfar - znear)),
                   Translate(new Vector(0.0f, 0.0f, -znear)));
        }

        #endregion

        #region Perspective
        /// <summary>
        /// Return Perspective Transform
        /// </summary>
        /// <param name="fov">fov</param>
        /// <param name="n">near</param>
        /// <param name="f">far</param>
        /// <returns></returns>
        static public Transform Perspective(float fov, float n, float f)
        {
            // Perform projective divide
            Matrix4x4 persp = new Matrix4x4(1, 0, 0, 0,
                                        0, 1, 0, 0,
                                        0, 0, f / (f - n), -f * n / (f - n),
                                        0, 0, 1, 0);

            // Scale to canonical viewing volume
            float invTanAng = 1.0f / (float)Math.Tan(Radians(fov) / 2.0f);
            return Multiply(Scale(invTanAng, invTanAng, 1), new Transform(persp));
        }
        #endregion

        #region Quadratic Equation
        /// <summary>
        /// Quadratic 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="t">float t[2]</param>
        /// <returns></returns>
        static public bool Quadratic(float A, float B, float C, out float[] t) //求一元二次方程跟
        {
            // Find quadratic discriminant
            t = new float[2];
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
        #endregion

        #region Vector Dot and Cross
        /// <summary>
        /// Dot(v1,v2)
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        static public float Dot(Vector v1, Vector v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        /// <summary>
        /// Normalize Vector
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        static public Vector Normalize(Vector v)
        {
            float length = v.Length();
            return new Vector(v.x / length, v.y / length, v.z / length);
        }

        /// <summary>
        /// Cross(v1,v2)
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        static public Vector Cross(Vector v1, Vector v2)
        {
            float v1x = v1.x, v1y = v1.y, v1z = v1.z;
            float v2x = v2.x, v2y = v2.y, v2z = v2.z;
            return new Vector((v1y * v2z) - (v1z * v2y),
                          (v1z * v2x) - (v1x * v2z),
                          (v1x * v2y) - (v1y * v2x));
        }

        #endregion

        #region LookAt Transform
        /// <summary>
        /// LookAt Transform 
        /// </summary>
        /// <param name="pos">position</param>
        /// <param name="look">look vector</param>
        /// <param name="up">up vector</param>
        /// <returns></returns>
        static public Transform LookAtTransform(Point3 pos, Point3 look, Vector up)
        {
            float[,] m = new float[4, 4];

            m[0, 3] = pos.x;
            m[1, 3] = pos.y;
            m[2, 3] = pos.z;
            m[3, 3] = 1;

            // Initialize first three columns of viewing matrix
            Vector dir = Normalize(look - pos);
            if (Cross(Normalize(up), dir).Length() == 0)
            {

                return null;
            }
            Vector left = Normalize(Cross(Normalize(up), dir));
            Vector newUp = Cross(dir, left);
            m[0, 0] = left.x;
            m[1, 0] = left.y;
            m[2, 0] = left.z;
            m[3, 0] = 0.0f;
            m[0, 1] = newUp.x;
            m[1, 1] = newUp.y;
            m[2, 1] = newUp.z;
            m[3, 1] = 0.0f;
            m[0, 2] = dir.x;
            m[1, 2] = dir.y;
            m[2, 2] = dir.z;
            m[3, 2] = 0.0f;
            Matrix4x4 camToWorld = new Matrix4x4(m);
            return new Transform(Inverse(camToWorld), camToWorld);
        }
        #endregion

        #region Quaternion Dot
        /// <summary>
        /// Quaternion Dot
        /// </summary>
        /// <param name="q1"></param>
        /// <param name="q2"></param>
        /// <returns></returns>
        static public float Dot(Quaternion q1, Quaternion q2)
        {
            return Dot(q1.v, q2.v) + q1.w * q2.w;
        }

        /// <summary>
        /// Quaternion Normalize
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        static public Quaternion Normalize(Quaternion q)
        {
            return q / (float)(float)Math.Sqrt(Dot(q, q));
        }
        #endregion

        #region Quaternion Slerp
        /// <summary>
        /// Quaternion Slerp
        /// </summary>
        /// <param name="t"></param>
        /// <param name="q1"></param>
        /// <param name="q2"></param>
        /// <returns></returns>
        static public Quaternion Slerp(float t, Quaternion q1, Quaternion q2)
        {
            float cosTheta = Dot(q1, q2);
            if (cosTheta > .9995f)
                return Normalize(q1 * (1.0f - t) + q2 * t);
            else
            {
                float theta = (float)Math.Acos(Clamp(cosTheta, -1.0f, 1.0f));
                float thetap = theta * t;
                Quaternion qperp = Normalize(q2 - q1 * cosTheta);
                return q1 * (float)Math.Cos(thetap) + qperp * (float)Math.Sin(thetap);
            }
        }
        #endregion

        #region ConcentricSampleDisk
                static public void ConcentricSampleDisk(float u1, float u2, ref float dx, ref float dy)
                {
                    float r, theta;
                    // Map uniform random numbers to $[-1,1]^2$
                    float sx = 2 * u1 - 1;
                    float sy = 2 * u2 - 1;

                    // Map square to $(r,\theta)$

                    // Handle degeneracy at the origin
                    if (sx == 0.0 && sy == 0.0)
                    {
                        dx = 0.0f;
                        dy = 0.0f;
                        return;
                    }
                    if (sx >= -sy)
                    {
                        if (sx > sy)
                        {
                            // Handle first region of disk
                            r = sx;
                            if (sy > 0.0) theta = sy / r;
                            else theta = 8.0f + sy / r;
                        }
                        else
                        {
                            // Handle second region of disk
                            r = sy;
                            theta = 2.0f - sx / r;
                        }
                    }
                    else
                    {
                        if (sx <= sy)
                        {
                            // Handle third region of disk
                            r = -sx;
                            theta = 4.0f - sy / r;
                        }
                        else
                        {
                            // Handle fourth region of disk
                            r = -sy;
                            theta = 6.0f + sx / r;
                        }
                    }
                    theta *= (float)(float)Math.PI / 4.0f;
                    dx = r * (float)(float)Math.Cos(theta);
                    dy = r * (float)(float)Math.Sin(theta);
                }
        #endregion

        public static float INFINITY = 99999999;
    }
}
