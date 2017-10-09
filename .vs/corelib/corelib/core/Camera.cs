using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    interface Camera
    {
       
        float GenerateRay(CameraSample sample, Ray ray);
        Transform cam2world { get; set; }
      

    }
}
