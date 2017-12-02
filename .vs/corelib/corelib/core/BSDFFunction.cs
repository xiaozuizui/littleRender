using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    public static class BSDFFunction 
    {

        #region shading coordinate 转换

        /// <summary>
        /// 计算w对应的cosθ
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        public static float CosTheta(Vector w) { return w.z; }
        public static float AbsCosTheta(Vector w) { return (float)Math.Abs(w.z); }
        /// <summary>
        /// 计算w对应的sin2θ
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        public static float SinTheta2(Vector w) { return (float)Math.Max(0.0, 1.0 - CosTheta(w) * CosTheta(w)); }
        public static float SinTheta(Vector w) { return (float)Math.Sqrt(SinTheta2(w)); }


        public static float CosPhi(Vector w)
        {
            float sintheta = SinTheta(w);
            if (sintheta == 0.0f) return 1.0f;//垂直
            return LR.Clamp(w.x / sintheta, -1.0f, 1.0f);
        }

        public static float SinPhi(Vector w)
        {
            float sintheta = SinTheta(w);
            if (sintheta == 0.0f) return 0.0f;
                return LR.Clamp(w.y / sintheta, -1.0f, 1.0f);
        }
        #endregion

        public static bool SameHemisphere(Vector w, Vector wp)
        {
            return w.z* wp.z > 0.0f;
        }

       public static Vector otherHemisphere(Vector w)
       {
            return new Vector(w.x, w.y, -w.z);
       }

}
}
