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
        public PerspectiveCamera(Transform c2w, Film f, float lensr, float focald, float[] screenWindow, float fov) : base(c2w, c2w, f, lensr, focald, screenWindow)
        {

        }
        //public PerspectiveCamera(Transform c2w) { }
        override public float GenerateRay(CameraSample sample, Ray ray)
        {
            Point3 Pras = new Point3(sample.imageX, sample.imageY, 0); //光栅坐标

            Point3 Pcamera;


            Pcamera = RasterToCamera.CaculatePoint(Pras);//光栅坐标转换为相机坐标 相机为原点

            ray = new Ray(new Point3(0, 0, 0), Normalize(new Vector(Pcamera)), 0.0f, INFINITY); 
            // Modify ray for depth of field
            if (lensRadius > 0.0)
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

        override public float GenerateRayDifferential(CameraSample sample, RayDifferential ray)
        {
            // Generate raster and camera samples
        
            Point3 Pcamera = RasterToCamera.CaculatePoint(new Point3(sample.imageX, sample.imageY, 0));

            Vector dir = Normalize(new Vector(Pcamera.x, Pcamera.y, Pcamera.z));
            ray = new RayDifferential(new Point3(0, 0, 0), dir, 0.0f, INFINITY);
            // Modify ray for depth of field
            if (lensRadius > 0.0)
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

            // Compute offset rays for _PerspectiveCamera_ ray differentials
            if (lensRadius > 0.)
            {
                // Compute _PerspectiveCamera_ ray differentials with defocus blur

                // Sample point on lens
                float lensU, lensV;
                ConcentricSampleDisk(sample.lensU, sample.lensV, &lensU, &lensV);
                lensU *= lensRadius;
                lensV *= lensRadius;

                Vector dx = Normalize(Vector(Pcamera + dxCamera));
                float ft = focalDistance / dx.z;
                Point pFocus = Point(0, 0, 0) + (ft * dx);
                ray->rxOrigin = Point(lensU, lensV, 0.f);
                ray->rxDirection = Normalize(pFocus - ray->rxOrigin);

                Vector dy = Normalize(Vector(Pcamera + dyCamera));
                ft = focalDistance / dy.z;
                pFocus = Point(0, 0, 0) + (ft * dy);
                ray->ryOrigin = Point(lensU, lensV, 0.f);
                ray->ryDirection = Normalize(pFocus - ray->ryOrigin);
            }
            else
            {
                ray->rxOrigin = ray->ryOrigin = ray->o;
                ray->rxDirection = Normalize(Vector(Pcamera) + dxCamera);
                ray->ryDirection = Normalize(Vector(Pcamera) + dyCamera);
            }

            ray->time = sample.time;
            CameraToWorld(*ray, ray);
            ray->hasDifferentials = true;
            return 1.f;
        }


        //public Transform cam2world { get; set; }




        public Vector dxCamera { get; set; }
         public Vector dyCamera { get; set; }
    }
}
