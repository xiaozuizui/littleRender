using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;

namespace corelib.cameras
{
    class PerspectiveCamera : ProjectiveCamera
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
        public PerspectiveCamera(AnimatedTransform c2w, Transform proj,float[] screenWindow,float sopen,float sclose,float lensr,float focald, float fov,Film f) : base(c2w,  proj,  screenWindow,sopen,sclose,lensr,focald,f)
        {
            
        }
        //public PerspectiveCamera(Transform c2w) { }
        override public float GenerateRay(CameraSample sample,out Ray ray)
        {
            Point3 Pras = new Point3(sample.imageX, sample.imageY, 0); //光栅坐标

            Point3 Pcamera;
            

            Pcamera = RasterToCamera.Caculate(Pras);//光栅坐标转换为相机坐标 相机为原点

            ray = new Ray(new Point3(0, 0, 0), LR.Normalize(new Vector(Pcamera)), 0.0f, 1.0f/0);
            // Modify ray for depth of field
            if (lensRadius > 0.0)
            {
                // Sample point on lens
                float lensU, lensV;
                //  ConcentricSampleDisk(sample.lensU, sample.lensV, &lensU, &lensV);
                //lensU *= lensRadius;
                //lensV *= lensRadius;

                // Compute point on plane of focus
                //    float ft = focalDistance / ray->d.z;
                //    Point Pfocus = (*ray)(ft);

                //    // Update ray for effect of lens
                //    ray->o = Point(lensU, lensV, 0.f);
                //    ray->d = Normalize(Pfocus - ray->o);
                //}
                //ray->time = sample.time;
                //CameraToWorld(*ray, ray);
              
            }

            return 1.0f;
        }

        override public float GenerateRayDifferential(CameraSample sample, out RayDifferential ray)
        {
            // Generate raster and camera samples
            ray = new RayDifferential(new Point3(),new Vector());
            return 0.0f;
        }


        //public Transform cam2world { get; set; }




        private Vector dxCamera { get; set; }
        private Vector dyCamera { get; set; }
    }
}
