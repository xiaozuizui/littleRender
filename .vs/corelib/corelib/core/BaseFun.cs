﻿using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;
namespace corelib.core
{
    public abstract class BaseFun
    {
        protected float INFINITY = 99999999;

        /// <summary>
        /// Swap
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        protected void Swap<T>(T first,T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
        /// <summary>
        /// 插值
        /// </summary>
        /// <param name="t"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        protected float Lerp(float t, float v1, float v2)
        {
            return (1.0f - t) * v1 + t * v2;
        }

        /// <summary>
        /// 角度转弧度
        /// </summary>
        /// <param name="deg">输入角度</param>
        /// <returns></returns>
        protected float Radians(float deg)
        {
            return ((float)Math.PI / 180.0f) * deg;
        }

        /// <summary>
        /// 弧度转角度
        /// </summary>
        /// <param name="rad">输入弧度</param>
        /// <returns></returns>
        protected float Degress(float rad)
        {
            return (180.0f / (float)Math.PI) * rad;
        }

        /// <summary>
        /// 矩阵乘法
        /// </summary>
        /// <param name="m1">first Matrix</param>
        /// <param name="m2">second Matrix</param>
        /// <returns></returns>
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

        /// <summary>
        /// Inverse
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public Matrix4x4 Inverse( Matrix4x4 m) 
        { 

            int[] indxc = new int[4];
            int[] indxr = new int[4];
            int[] ipiv = new int[4];
            for (int i = 0; i < 4; i++)
                ipiv[i] = 0;

            float[,] minv = new float[4, 4];
            for (int i = 0; i < 4; i++)//使用值传递
                for (int j = 0; j < 4; j++)
                    minv[i, j] = m.m[i, j];

            for (int i = 0; i< 4; i++)
            {
                int irow = -1, icol = -1;
                float big = 0.0f;
        // Choose pivot
                for (int j = 0; j< 4; j++)
                {
                    if (ipiv[j] != 1)
                    {
                        for (int k = 0; k< 4; k++)
                        {
                            if (ipiv[k] == 0)
                            {
                                if (Math.Abs(minv[j, k]) >= big)
                                {
                                    big = (Math.Abs(minv[j, k]));
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
                    for (int k = 0; k< 4; ++k)
                    Swap(minv[irow,k], minv[icol,k]);
                }   
                indxr[i] = irow;
                indxc[i] = icol;
                if (minv[icol, icol] == 0.0f) ;
                    //Error("Singular matrix in MatrixInvert");

                // Set $m[icol][icol]$ to one by scaling row _icol_ appropriately
                float pivinv = 1.0f / minv[icol,icol];
                minv[icol,icol] = 1.0f;
                for (int j = 0; j< 4; j++)
                    minv[icol,j] *= pivinv;

                // Subtract this row from others to zero out their columns
                for (int j = 0; j< 4; j++)
                {
                    if (j != icol)
                    {
                        float save = minv[j,icol];
                        minv[j,icol] = 0;
                        for (int k = 0; k< 4; k++)
                            minv[j,k] -= minv[icol,k]* save;
                    }
                }
            }
            // Swap columns to reflect permutation
            for (int j = 3; j >= 0; j--)
            {
                if (indxr[j] != indxc[j])
                {
                    for (int k = 0; k< 4; k++)
                        Swap(minv[k,indxr[j]], minv[k,indxc[j]]);
                }
            }
        return  new Matrix4x4(minv);
        }


        /// <summary>
        /// 解一元二次方程
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="t"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 向量点积
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        protected float Dot(Vector v1, Vector v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        /// <summary>
        /// 向量叉积
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
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