using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;
using corelib.bsdf;


namespace corelib.sphere
{
    public class Quad:Shape
    {
        private Vector set;
        private Vector position;
        private Vector up;

        public Quad(Vector s,Vector p,Vector u)
        {
            set = s; position = p; up = u;
        }

       

    }
}
