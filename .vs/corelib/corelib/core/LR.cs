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
            Matrix4x4 m2 = Multiply(t1.mInv, t2.mInv);
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


        #region Orthographic
        static Transform Perspective(float fov, float n, float f)
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
    }
}
