using System;
using System.Collections.Generic;
using System.Text;
using corelib.Integrator;

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
        private Sampler sampler;
        private Camera camera;
        private SurfaceIntegrator surfaceIntegrator;
        //Scene
        public SampleRenderer(Sampler s,Camera c,SurfaceIntegrator f)
        {
            sampler = s;
            camera = c;
            surfaceIntegrator = f;
        }

        public void Renderer(Scene s)
        {

        }

        public RGBSpectrum Li()
        {
            return null;
        }

        public RGBSpectrum Transmittance()
        {
            return null;
        }


        public  void Run()
        {
            //while(sampler.GetMoreSamples())
            for(int i = 0;i<sampler.SamplePerPixel;i++)
            {
              //  camera.GenerateRay();
            }
        }
    }
}
