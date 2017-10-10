using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;

namespace corelib.cameras
{
    class PerspectiveCamera:Camera
    {

        public PerspectiveCamera(Transform c2w) { }
        public float GenerateRay(CameraSample sample, Ray ray)
        {
            return 0;
        }
        public Transform cam2world { get; set; }


        private Vector dxCamera, dyCamera;
    }
}
