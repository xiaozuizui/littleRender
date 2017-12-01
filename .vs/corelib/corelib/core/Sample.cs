using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;
using corelib.Integrator;

namespace corelib.core
{
    public interface CameraSampleInterface
    {
       float imageX { get; set; }
       float imageY { get; set; }
       float lensU { get; set; }
       float lensV { get; set; }
       float time { get; set; }
    }

    public struct CameraSample:CameraSampleInterface
    {
        public CameraSample(float ImageX,float ImageY,float lU,float lV,float Time)
        {
            imageX = ImageX;
            imageY = ImageY;

            //imageX = imageY = 0.0f;
            lensU = lU;
            lensV = lV;
            time = Time;
        }
        public float imageX { get; set; }
        public float imageY { get; set; }
        public float lensU { get; set; }
        public float lensV { get; set; }
        public float time { get; set; }
    }

    class Sample:CameraSampleInterface
    {

        float CameraSampleInterface.imageX { get; set; }
        float CameraSampleInterface.imageY { get; set; }
        float CameraSampleInterface.lensU { get; set; }
        float CameraSampleInterface.lensV { get; set; }
        float CameraSampleInterface.time { get; set; }

        Stack<UInt32> n1D, n2D;
        float[][] oneD, twoD;
        int Add1D(UInt32 num) { n1D.Push(num);return n1D.Count - 1; }
        int Add2D(UInt32 num) { n2D.Push(num);return n2D.Count - 1; }


        public Sample(Sampler sampler,SurfaceIntegrator surfaceIntegrator,VolumeIntegrator volumeIntegrator,Scene scene)
        {
            int nPtrs = n1D.Count + n2D.Count;
            if(nPtrs==0)
            {
                oneD = twoD = null;
            }
        }

        //public void 
    }
}
