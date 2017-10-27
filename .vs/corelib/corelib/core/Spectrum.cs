using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    public class RGBSpectrum
    {
        float [] color;

        public RGBSpectrum()
        {
            color = new float[3] { 0.0f,0.0f,0.0f};
        }

        public RGBSpectrum(float[] c)
        {
            color = c;
        }
    }
}
