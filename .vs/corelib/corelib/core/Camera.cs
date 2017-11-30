using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    interface CameraInterface
    {
       
        float GenerateRay(CameraSample sample,out Ray ray);
        float GenerateRayDifferential(CameraSample sample, out RayDifferential rd);
        AnimatedTransform CameraToWorld { get; set; }
        float shutterOpen { get; set; }
        float shutterClose { get; set; }

    }

    public abstract class Camera: CameraInterface
    {

        public Camera(AnimatedTransform c2w, float sopen, float sclose, Film f)
        {
            CameraToWorld = c2w;
            film = f;
            
        }

        public virtual float GenerateRay(CameraSample sample, out RayDifferential rd)
        {
            throw new NotImplementedException();
        }

        public virtual float GenerateRay(CameraSample sample,out  Ray ray) { ray = new Ray(); return 0; } // return value gives a weight for how much light arriving at the film (most return one) 

        public virtual float GenerateRayDifferential(CameraSample sample, out RayDifferential rd)
        {
           // rd = new RayDifferential();
            float wt = GenerateRay(sample,out rd);
            //x direction
            CameraSample sshift = sample;
            ++(sshift.imageX);
            Ray rx = new Ray();
            float wtx = GenerateRay(sshift,out rx);
            rd.rxOrigin = rx.o;
            rd.rxDirection = rx.d;

            // y direction
            --(sshift.imageX);
            ++(sshift.imageY);
            Ray ry = new Ray(); ;
            float wty = GenerateRay(sshift,out ry);
            rd.ryOrigin = ry.o;
            rd.ryDirection = ry.d;
            

            if (wtx == 0.0f || wty == 0.0f) return 0.0f;
            rd.hasDifferentials = true;
            return wt;
        }

       

        public AnimatedTransform CameraToWorld { get; set; }
        public Film film { get; set; }
        public float shutterOpen { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float shutterClose { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
