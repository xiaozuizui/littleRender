using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{

    interface Renderer
    {
        void Renderer(Scene scene);
        RGBSpectrum Li();
        RGBSpectrum Transmittance();

    }
    class SampleRenderer:Renderer
    {
        Sampler sampler;
        Camera camera;
        //Scene
        SampleRenderer(Scene s)
        {

        }

        void Renderer(Scene s)
        {

        }

        RGBSpectrum Li()
        {
            return null;
        }

        RGBSpectrum Transmittance()
        {
            return null;
        }
        public  void Run()
        {
            while(sampler.GetMoreSamples())
            for(int i = 0;i<sampler.SamplePerPixel;i++)
            {
              //  camera.GenerateRay();
            }
        }
    }
}
