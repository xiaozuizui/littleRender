


using System;

namespace corelib.core
{
    interface Fresnel
    {
        float Evaluate(float cosi);
    }

    class FresnelDielectric : Fresnel
    {
        public float Evaluate(float cosi)
        {
            cosi = LR.Clamp(cosi, -1.0f, 1.0f);

            // Compute indices of refraction for dielectric
            bool entering = cosi > 0.0;//>0 入射
            float ei = eta_i, et = eta_t;

            if (!entering)
                LR.Swap(ei, et);

            // Compute _sint_ using Snell's law 
            float sint = ei / et * (float)Math.Sqrt(Math.Max(0.0f, 1.0f - cosi * cosi));
            if (sint >= 1.0)
            {
                // Handle total internal reflection
                return 1.0f;
            }
            else
            {
                float cost = (float)Math.Sqrt(Math.Max(0.0f, 1.0f - sint * sint));
                return BSDFFunction.FrDiel(Math.Abs(cosi), cost, ei, et);
            }
        }
        private float eta_i, eta_t;//反射率
    }

    class FresnelConductor : Fresnel
    {

        public float Evaluate(float cosi) { return BSDFFunction.FrCond(cosi, eta, k); }

        private float eta, k;
    }

    class SpecularReflection:BxDF
    {
        public SpecularReflection(Spectrum r,Fresnel f):base(BxDFType.BSDF_REFLECTION|BxDFType.BSDF_SPECULAR)
        {

        }


        Spectrum R;
        Fresnel fresnel;

    }
}