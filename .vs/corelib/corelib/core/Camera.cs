using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    interface CameraInterface
    {
       
        float GenerateRay(CameraSample sample, Ray ray);
        float GenerateRayDifferential(CameraSample sample, RayDifferential rd);
        Transform cam2world { get; set; }
      

    }

    public class Camera: BaseFun,CameraInterface
    {
        
        public Camera(Transform c2w,Film f)
        {
            cam2world = c2w;
            film = f;
        }

        public virtual float GenerateRay(CameraSample sample, Ray ray) { return 0; }

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

        public Transform cam2world { get; set; }
        public Film film { get; set; }
    }
}
