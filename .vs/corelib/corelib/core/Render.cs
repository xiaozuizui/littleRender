﻿using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    class Render
    {
        Sampler sampler;
        Camera camera;

        public  void Run()
        {
            for(int i = 0;i<sampler.SamplePerPixel;i++)
            {
              //  camera.GenerateRay();
            }
        }
    }
}