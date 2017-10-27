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
        public float[] sampleBuf { get; set; }

        LowDiscrepancy(int xstart,int xend,int ystart,int yend,int spp )
        {
            xPos = xPixelStrat;
            yPos = yPixelStart;
            nPixelSamples = spp;
        }
        public override int GetMoreSamples(Sampler sample)
        {
            if (yPos == yPixelEnd) return 0;
            if (sampleBuf == null)
                sampleBuf = new float[LDPixelSampleFloatsNeeded(samples,
                                                                nPixelSamples)];
            LDPixelSample(xPos, yPos, shutterOpen, shutterClose,
                          nPixelSamples, samples, sampleBuf, rng);
            if (++xPos == xPixelEnd)
            {
                xPos = xPixelStart;
                ++yPos;
            }
            return base.GetMoreSamples(sample);
        }

    }

    
}
