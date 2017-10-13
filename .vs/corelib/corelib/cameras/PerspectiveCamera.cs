using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;

namespace corelib.cameras
{
    class PerspectiveCamera:ProjectiveCamera
    {
        /// <summary>
        /// PerspectiveCamera 
        /// </summary>
        /// <param name="c2w">c2w</param>
        /// <param name="proj">camer2screen</param>
        /// <param name="f">film</param>
        /// <param name="lensr">lenser</param>
        /// <param name="focald">focald</param>
        /// <param name="screenWindow">float[4]</param>
        /// 
        public PerspectiveCamera(Transform c2w, Film f, float lensr, float focald, float[] screenWindow,float fov) :base(c2w,  c2w,f,lensr,focald,screenWindow)
        {
            
        }
        //public PerspectiveCamera(Transform c2w) { }
        override public float GenerateRay(CameraSample sample, Ray ray)
        {
            Point3 Pras = new Point3(sample.imageX, sample.imageY, 0);
            Point3 Pcamera;


            RasterToCamera(Pras, &Pcamera);
            
            *ray = Ray(Point(0, 0, 0), Normalize(Vector(Pcamera)), 0.f, INFINITY);
            // Modify ray for depth of field
            if (lensRadius > 0.)
            {
                // Sample point on lens
                float lensU, lensV;
                ConcentricSampleDisk(sample.lensU, sample.lensV, &lensU, &lensV);
                lensU *= lensRadius;
                lensV *= lensRadius;

                // Compute point on plane of focus
                float ft = focalDistance / ray->d.z;
                Point Pfocus = (*ray)(ft);

                // Update ray for effect of lens
                ray->o = Point(lensU, lensV, 0.f);
                ray->d = Normalize(Pfocus - ray->o);
            }
            ray->time = sample.time;
            CameraToWorld(*ray, ray);
            return 1.f;
        }
            return 0;
        }
        public Transform cam2world { get; set; }


        

        public Vector dxCamera { get; set; }
         public Vector dyCamera { get; set; }
    }
}
