using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    interface MC_Integrator
    {
        void Initialization(Scene s,Camera c);

    }

    public class SurfaceIntegrator : MC_Integrator
    {
        void MC_Integrator.Initialization(Scene s, Camera c)
        {

        }
    }

    public class VolumeIntegrator:MC_Integrator
    {
        void MC_Integrator.Initialization(Scene s, Camera c)
        {

        }
    }
}
