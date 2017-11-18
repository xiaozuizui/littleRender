using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    interface CameraInterface
    {
       
        float GenerateRay(CameraSample sample, Ray ray);
        float GenerateRayDifferential(CameraSample sample, RayDifferential rd);
        Transform Cam2World { get; set; }
        float shutterOpen { get; set; }
        float shutterClose { get; set; }

    }

    public abstract class Camera: BaseFun,CameraInterface
    {

        public Camera(Transform c2w, float sopen, float sclose, Film f)
        {
            Cam2World = c2w;
            film = f;
            
        }

        public virtual float GenerateRay(CameraSample sample, Ray ray) { return 0; } // return value gives a weight for how much light arriving at the film (most return one) 

        public virtual float GenerateRayDifferential(CameraSample sample, RayDifferential rd)
        {
            float wt = GenerateRay(sample, rd);
            //x direction
            CameraSample sshift = sample;
            ++(sshift.imageX);
            Ray rx = new Ray();
            float wtx = GenerateRay(sshift, rx);
            rd.rxOrigin = rx.o;
            rd.rxDirection = rx.d;

            // y direction
            --(sshift.imageX);
            ++(sshift.imageY);
            Ray ry = new Ray(); ;
            float wty = GenerateRay(sshift, ry);
            rd.ryOrigin = ry.o;
            rd.ryDirection = ry.d;
            

            if (wtx == 0.0f || wty == 0.0f) return 0.0f;
            rd.hasDifferentials = true;
            return wt;
        }

        public Transform Cam2World { get; set; }
        public Film film { get; set; }
        public float shutterOpen { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float shutterClose { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
