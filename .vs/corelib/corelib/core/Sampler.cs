using System;
using System.Collections.Generic;
using System.Text;

public struct window
{
    int xStart { get; set; }
    int xEnd { get; set; }
    int yStart { get; set; }
    int yEnd { get; set; }
}



namespace corelib.core
{

    public struct CameraSample
    {
        float imageX, imageY;
        float lensU, lensV;
        float time;
    }

    abstract public class Sampler
    {
        public int xPixelStrat {get;set;}
        public int xPixelEnd { get; set; }
        public int yPixelStart { get; set; }
        public int yPixelEnd { get; set; }
        public int SamplePerPixel { get; set; }
      //  public Sampler(int xstart,int xend,int ystart,int yend,int spp) { }
       public virtual int GetMoreSamples(Sampler sample) { return 0; }
       public virtual Sampler GetSubSampler() { return null; }
       public void ComputerSubWindow(int num,int count,window wd)
        {
            int dx = xPixelEnd - xPixelStrat;
            int dy = yPixelEnd - yPixelStart;
            int nx = count;// Determine how many tiles to use in each dimension, _nx_ and _ny_
            int ny = 1;

            while((nx&0x1)==0&&2*dx*ny<dy*nx)
            {
                nx >>= 1;
                ny <<= 1;
            }
        }

    }
}
