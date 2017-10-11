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
        public PerspectiveCamera(Transform c2w, Transform proj, Film f, float lensr, float focald, float[] screenWindow) :base(c2w,proj,f,lensr,focald,screenWindow)
        {

        }
        //public PerspectiveCamera(Transform c2w) { }
        public float GenerateRay(CameraSample sample, Ray ray)
        {
            return 0;
        }
        public Transform cam2world { get; set; }


        private Vector dxCamera, dyCamera;
    }
}
