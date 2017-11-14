using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;
using corelib.Integrator;

namespace corelib.core
{
    public interface CameraSample
    {
       float imageX { get; set; }
       float imageY { get; set; }
       float lensU { get; set; }
       float lensV { get; set; }
       float time { get; set; }
    }

    class Sample:CameraSample
    {
        float CameraSample.imageX { get; set; }
        float CameraSample.imageY { get; set; }
        float CameraSample.lensU { get; set; }
        float CameraSample.lensV { get; set; }
        float CameraSample.time { get; set; }

        Stack<UInt32> n1D, n2D;
        int Add1D(UInt32 num) { n1D.Push(num);return n1D.Count - 1; }
        int Add2D(UInt32 num) { n2D.Push(num);return n2D.Count - 1; }


        public Sample(Sampler sampler,SurfaceIntegrator surfaceIntegrator,VolumeIntegrator volumeIntegrator,Scene scene)
        {

        }
    }
}
