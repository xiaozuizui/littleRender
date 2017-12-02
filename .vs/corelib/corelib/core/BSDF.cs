using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    enum BxDFType
    {
        BSDF_REFLECTION = 1 << 0,
        BSDF_TRANSMISSION = 1 << 1,

        BSDF_DIFFUSE = 1 << 2,
        BSDF_GLOSSY = 1 << 3,
        BSDF_SPECULAR = 1 << 4,

        BSDF_ALL_TYPES = BSDF_DIFFUSE |
                                BSDF_GLOSSY |
                                BSDF_SPECULAR,

        BSDF_ALL_REFLECTION = BSDF_REFLECTION |
                                BSDF_ALL_TYPES,

        BSDF_ALL_TRANSMISSION = BSDF_TRANSMISSION |
                                BSDF_ALL_TYPES,

        BSDF_ALL = BSDF_ALL_REFLECTION |
                                BSDF_ALL_TRANSMISSION
    }
    class BSDF
    {

    }

    interface BxDFInterface
    {
        Spectrum f(Vector wo, Vector wi);
        Spectrum Sample_f(Vector wo, Vector wi, float u1, float u2, float pdf);
        Spectrum rho(Vector wo, int nSamples, float samples);//hd 
        Spectrum rho(int nSamples, float samples1, float samples2);//hh 
        float Pdf(Vector wi, Vector wo);
        BxDFType type { get; set; }

    }

    class BxDF:BxDFInterface
    {
        public BxDF(BxDFType T) { type = T; }
        public bool MatchesFlags(BxDFType flags)
        {
            return (type & flags) == type;
        }

        public virtual Spectrum f(Vector wo, Vector wi) { return new Spectrum(); }
        public virtual Spectrum Sample_f(Vector wo, Vector wi, float u1, float u2, float pdf) { return new Spectrum(); }//mirror glass
        public virtual Spectrum rho(Vector wo, int nSamples, float samples) { return new Spectrum(); }//计算反射率
        public virtual Spectrum rho(int nSamples, float samples1, float samples2) { return new Spectrum(); }
        public virtual float Pdf(Vector wi, Vector wo) { return 0; }

        public BxDFType type { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    class BRDFTOBTDF:BxDF
    {
        public BRDFTOBTDF(ref BxDF b):base(b.type^(BxDFType.BSDF_TRANSMISSION|BxDFType.BSDF_REFLECTION))
        {
            brdf = b;
        }

        override public Spectrum f(Vector wo, Vector wi) { return brdf.f(wo, BSDFFunction.otherHemisphere(wi)); }
        override public Spectrum Sample_f(Vector wo, Vector wi, float u1, float u2,float pdf) { Spectrum f = brdf.Sample_f(wo, wi, u1, u2, pdf); wi = BSDFFunction.otherHemisphere(wi); return new Spectrum(); }
        override public Spectrum rho( Vector w, int nSamples,  float samples)  { return brdf.rho(BSDFFunction.otherHemisphere(w), nSamples, samples);}
        override public Spectrum rho(int nSamples,  float samples1,  float samples2)  {return brdf.rho(nSamples, samples1, samples2);}
        override public float Pdf(Vector wo, Vector wi) { return 0; }


        private BxDF brdf;

    }

    class ScaledBxdf:BxDF
    {
        
        public ScaledBxdf(BxDF b,Spectrum sc):base(b.type)
        {
            bxdf = b;
            s = sc;
        }
        override public Spectrum f(Vector wo, Vector wi) { return s * bxdf.f(wo, wi); }
        override public Spectrum Sample_f(Vector wo, Vector wi, float u1, float u2, float pdf) { return s * bxdf.Sample_f(wo, wi, u1, u2, pdf); }
        override public Spectrum rho(Vector w, int nSamples, float samples) { return s*bxdf.rho(w, nSamples, samples); }
        override public Spectrum rho(int nSamples, float samples1, float samples2) { return s*bxdf.rho(nSamples, samples1, samples2); }
        override public float Pdf(Vector wo, Vector wi) { return 0; }

        private BxDF bxdf;
        private Spectrum s;
    }


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
            bool entering = cosi > 0.0;
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

    class FresnelConductor:Fresnel
    {

        public Spectrum Evaluate(float cosi) { return new Spectrum(); }

        private Spectrum eta, k;
    }
    
}
