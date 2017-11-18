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
            
        }

        // float GenerateRay()
        public override float GenerateRay(CameraSample sample, Ray ray)
        {

            Point3 Pras = new Point3(sample.imageX, sample.imageY);
            Point3 Pcamera = RasterToCamera.CaculatePoint(Pras);


            return base.GenerateRay(sample, ray);

        }

        private Vector dxCamera { get; set; }
        private Vector dyCamera { get; set; }
    }
}
