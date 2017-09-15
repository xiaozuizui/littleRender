using System;
using System.Collections.Generic;
using System.Text;


namespace corelib.bsdf
{   
     public class Color
    {
        public Color() { R = 0;G = 0;B = 0; }
        public Color(float r,float g,float b)
        { R = r;G = g;B = b; }
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
    }
    public class BSDF
    {
 
        private Color rgb ;
        private float Reflectiuon { get; set; }
        private float Diffuse { get; set; }
        
        public BSDF()
        {
            rgb = new Color();
        }


        public void SetRGB(float r ,float g,float b)
        {
            rgb.R = r;rgb.G = g;rgb.B = b;
        }
    }
}
