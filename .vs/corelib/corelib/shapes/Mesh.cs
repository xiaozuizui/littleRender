using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;

namespace corelib.shapes
{
    public struct Face
    {
        float v1, v2, v3;
    }
    public class Mesh:Shape
    {
        
        public Mesh()
        {
            P = new List<Point3>();
            F = new List<Face>();
        }
        protected List<Point3> P { get; set; }
        protected List<Face> F { get; set; }
    }
}
