using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;

namespace corelib.core
{
    interface CameraSample
    {
       float imageX { get; set; }
       float imageY { get; set; }
       float lensU { get; set; }
       float lensV { get; set; }
       float time { get; set; }
    }

    struct Sample:CameraSample
    {
        float CameraSample.imageX { get; set; }
        float CameraSample.imageY { get; set; }
        float CameraSample.lensU { get; set; }
        float CameraSample.lensV { get; set; }
        float CameraSample.time { get; set; }

        
    }
}
