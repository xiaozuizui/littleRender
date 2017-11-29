using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;

namespace corelib.cameras
{
    class OrthoCamera:ProjectiveCamera
    {
        public OrthoCamera(AnimatedTransform c2w, Transform proj,float[] screenWindow,float sopen,float sclose,float lensr,float focald, float fov, Film f) : base(c2w, proj, screenWindow, sopen, sclose, lensr, focald, f)
        {
            dxCamera = RasterToCamera.Caculate( new Vector(1, 0, 0));
            dyCamera = RasterToCamera.Caculate(new  Vector(0, 1, 0));
        }

        // float GenerateRay()
        public override float GenerateRay(CameraSample sample, Ray ray)
        {

            Point3 Pras = new Point3(sample.imageX, sample.imageY);
            Point3 Pcamera = RasterToCamera.Caculate(Pras);
            ray = new Ray(Pcamera, new Vector(0, 0, 1), 0, 1.0f/0);//正交相机方向固定

            #region modify ray for depth of filed
            if (lensRadius > 0.0f)
            {
                // Sample point on lens
                float lensU=0, lensV=0;

                ConcentricSampleDisk(sample.lensU, sample.lensV, ref lensU, ref lensV);
                lensU *= lensRadius;
                lensV *= lensRadius;
                 
                // Compute point on plane of focus
                float ft = focalDistance / ray.d.z;
                Point3 Pfocus =ray.Transfer(ft);

                // Update ray for effect of lens
                ray.o = new Point3(lensU, lensV, 0.0f);
                ray.d =  Normalize(Pfocus - ray.o);
            }
            #endregion
            ray.time = sample.time;
            ray = CameraToWorld.Caculate(ray);
            return 1.0f;

        }

        public override float GenerateRayDifferential(CameraSample sample, RayDifferential ray)
        {
            Point3 Pras = new Point3(sample.imageX, sample.imageY);
            Point3 Pcamera = RasterToCamera.Caculate(Pras);
            ray = new RayDifferential(Pcamera, new Vector(0, 0, 1), 0, 1.0f/0);

            #region Modify ray for depth of field
            if (lensRadius > 0.0)
            {
                // Sample point on lens
                float lensU=0, lensV=0;
                ConcentricSampleDisk(sample.lensU, sample.lensV, ref lensU, ref lensV);
                lensU *= lensRadius;
                lensV *= lensRadius;

                // Compute point on plane of focus
                float ft = focalDistance / ray.d.z;
                Point3 Pfocus = ray.Transfer(ft);

                // Update ray for effect of lens
                ray.o = new Point3(lensU, lensV, 0.0f);
                ray.d = Normalize(Pfocus - ray.o);
            }
            #endregion
            ray.time = sample.time;

            #region Compute ray differentials for _OrthoCamera_
            if (lensRadius > 0)
            {
                // Compute _OrthoCamera_ ray differentials with defocus blur

                // Sample point on lens
                float lensU=0, lensV=0;
                ConcentricSampleDisk(sample.lensU, sample.lensV, ref lensU,  ref lensV);
                lensU *= lensRadius;
                lensV *= lensRadius;

                float ft = focalDistance / ray.d.z;

                Point3 pFocus = Pcamera + dxCamera + (ft * new Vector(0, 0, 1));
                ray.rxOrigin = new Point3(lensU, lensV, 0.0f);
                ray.rxDirection = Normalize(pFocus - ray.rxOrigin);

                pFocus = Pcamera + dyCamera + (ft * new Vector(0, 0, 1));
                ray.ryOrigin = new Point3(lensU, lensV, 0.0f);
                ray.ryDirection = Normalize(pFocus - ray.ryOrigin);
            }
            else
            {
                ray.rxOrigin = ray.o + dxCamera;
                ray.ryOrigin = ray.o + dyCamera;
                ray.rxDirection = ray.ryDirection = ray.d;
            }
            #endregion

            ray.hasDifferentials = true;
            ray =  CameraToWorld.Caculate( ray);

            return 1.0f;
        }
        private Vector dxCamera { get; set; }
        private Vector dyCamera { get; set; }
    }
}
