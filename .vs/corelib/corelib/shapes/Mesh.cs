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
            vertexIndex = new int[nverts * 3];
           // F = new List<Face>();
        }
        
        public Mesh(int nt,int nv,ref int [] vi,ref List<Point3> p)
        {
            ntris = nt;
            nverts = nv;
            P = new List<Point3>();
            P = p;
            vertexIndex = new int[nverts * 3];
        }
        private List<Point3> P { get; set; }
        //private List<Face> F { get; set; }
        private int[] vertexIndex { get; set; }
        private int ntris, nverts;
    }

    public class Triangle:Shape
    {

        public Triangle()
        {
            v = new int[3];
        }
        private  Mesh m { get; set; }
        private int[] v;
        
    }
}
