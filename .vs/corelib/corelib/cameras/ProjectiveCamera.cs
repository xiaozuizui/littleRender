using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;

namespace corelib.cameras
{
    public class ProjectiveCamera:Camera
    {

       public ProjectiveCamera() { }
       public  float GenerateRay(CameraSample sample, Ray ray) { return 0; }
       public Transform cam2world { get; set; }
    }
}
