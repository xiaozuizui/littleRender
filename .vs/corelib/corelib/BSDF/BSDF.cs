using System;
using System.Collections.Generic;
using System.Text;


namespace corelib.BSDF
{   
     public class Color
    {
        public Color() { R = 0;G = 0;B = 0; }
        public Color(float r,float g,float b)
        { R = r;G = g;B = b; }
        float R { get; set; }
        float G { get; set; }
        float B { get; set; }
    }
    public class BSDF
    {

        private Color rgb ;
        private float Reflectiuon { get; set; }
        private float Diffuse { get; set; }
        



        public void SetRGB(float r ,float g,float b)
        {
            
        }
    }
}
