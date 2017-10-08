using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;

namespace corelib.sampler
{
    public class LowDiscrepancy : Sampler
    {
        public int xPos { get; set; }
        public int yPos { get; set; }
        public int nPixelSamples{get;set;}
        LowDiscrepancy(int xstart,int xend,int ystart,int yend,int spp )
        {
            xPos = xPixelStrat;
            yPos = yPixelStart;
            nPixelSamples = spp;
        }
    }
}
