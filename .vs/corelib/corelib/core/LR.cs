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
        #region Mutiply
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
        #endregion
    }
}
