using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    public class CoefficientSpectrum
    {
        CoefficientSpectrum(int n)
        {
            nSamples = n;
            c = new float[n];
        }
        int nSamples;
        protected float [] c;
    }
    public class RGBSpectrum
    {
        
    }
    public class Spectrum
    {


        static public Spectrum operator +(Spectrum s1, Spectrum s2)
        {
            return new Spectrum(s1.color[0]+s2.color[0],s1.color[1]+s2.color[1],s1.color[2]+s2.color[2]);
        }
        //static public Spectrum operator +(Spectrum s1, Spectrum s2)
        //{
        //    return new Spectrum(s1.color[0] + s2.color[0], s1.color[1] + s2.color[1], s1.color[2] + s2.color[2]);
        //}

        static public Spectrum operator -(Spectrum s1, Spectrum s2)
        {
            return new Spectrum(s1.color[0] - s2.color[0], s1.color[1] - s2.color[1], s1.color[2] - s2.color[2]);
        }

        static public Spectrum operator *(Spectrum s1, Spectrum s2)
        {
            return new Spectrum(s1.color[0] * s2.color[0], s1.color[1] * s2.color[1], s1.color[2] * s2.color[2]);
        }
        static public Spectrum operator *(Spectrum s1, float f)
        {
            return new Spectrum(s1.color[0] * f, s1.color[1] * f, s1.color[2] * f);
        }
        static public Spectrum operator *(float f,Spectrum s1)
        {
            return new Spectrum(s1.color[0] * f, s1.color[1] * f, s1.color[2] * f);
        }

        static public Spectrum operator /(Spectrum s1, Spectrum s2)
        {
            return new Spectrum(s1.color[0] / s2.color[0], s1.color[1] / s2.color[1], s1.color[2] / s2.color[2]);
        }
        static public Spectrum operator /(Spectrum s1, float f)
        {
            return new Spectrum(s1.color[0] / f, s1.color[1] / f, s1.color[2] / f);
        }


        public Spectrum()
        {
            color = new float[3] { 0.0f, 0.0f, 0.0f };
        }

        public Spectrum(float[] c)
        {
            //color = new float[3];
            color = c;
        }
        public Spectrum(float c1,float c2,float c3)
        {
            color = new float[3];
            color[0] = c1;
            color[1] = c2;
            color[2] = c3;
        }

        private float[] color;

    }
}
