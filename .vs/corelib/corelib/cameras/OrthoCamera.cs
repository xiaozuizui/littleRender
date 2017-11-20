using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;

namespace corelib.cameras
{
    class OrthoCamera:ProjectiveCamera
    {
        public OrthoCamera(Transform c2w, Transform proj,float[] screenWindow,float sopen,float sclose,float lensr,float focald, float fov, Film f) : base(c2w, proj, screenWindow, sopen, sclose, lensr, focald, f)
        {
            dxCamera = RasterToCamera.CaculateVector( new Vector(1, 0, 0));
            dyCamera = RasterToCamera.CaculateVector(new  Vector(0, 1, 0));
        }

        // float GenerateRay()
        public override float GenerateRay(CameraSample sample, Ray ray)
        {

            Point3 Pras = new Point3(sample.imageX, sample.imageY);
            Point3 Pcamera = RasterToCamera.CaculatePoint(Pras);
            ray = new Ray(Pcamera, new Vector(0, 0, 1), 0, INFINITY);

            if (lensRadius > 0.0f)
            {
                // Sample point on lens
                float lensU, lensV;

                ConcentricSampleDisk(sample.lensU, sample.lensV, lensU, &lensV);
                lensU *= lensRadius;
                lensV *= lensRadius;
                 
                // Compute point on plane of focus
                float ft = focalDistance / ray->d.z;
                Point Pfocus = (*ray)(ft);

                // Update ray for effect of lens
                ray->o = Point(lensU, lensV, 0.f);
                ray->d = Normalize(Pfocus - ray->o);
            }

            ray.time = sample.time;
            ray = CameraToWorld.CaculateVector(ray);
            return 1.f;

        }

        public override float GenerateRayDifferential(CameraSample sample, RayDifferential rd)
        {
            Point3 Pras = new Point3(sample.imageX, sample.imageY);
            Point3 Pcamera = RasterToCamera.CaculatePoint(Pras);
            rd = new RayDifferential(Pcamera, new Vector(0, 0, 1), 0, INFINITY);

           

            return base.GenerateRayDifferential(sample, rd);
        }
        private Vector dxCamera { get; set; }
        private Vector dyCamera { get; set; }
    }
}
