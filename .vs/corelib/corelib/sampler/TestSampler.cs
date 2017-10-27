using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;

namespace corelib.sampler
{
    class TestSampler:Sampler
    {
        public TestSampler(int xs,int xe,int ys,int ye)
        {
            xPixelStrat = xs;
            xPixelEnd = xe;
            yPixelStart = ys;
            yPixelEnd = ye;

        }

    }
}
