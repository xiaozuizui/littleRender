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
        
        public Mesh(Transform O2W,Transform W2O)
        {
            o2w = O2W;
            w2o = W2O;
            //P = new List<Point3>();
            vertexIndex = new int[nverts * 3];
           // F = new List<Face>();
        }
        
        public Mesh(int nt,int nv,ref int [] vi,ref List<Point3> p, Transform O2W, Transform W2O)
        {
            o2w = O2W;
            w2o = W2O;
            ntris = nt;
            nverts = nv;
           // P = new List<Point3>();
            P = p;
            vertexIndex = new int[ntris * 3];
            vertexIndex = vi;
        }

        public void Refine(List<Triangle> refined)
        {
            for(int i=0; i<ntris;i++)
            {
                refined.Add(new Triangle(w2o,o2w,this,i));
            }
        }
        public List<Point3> P { get; set; }
        //private List<Face> F { get; set; }
        public int[] vertexIndex { get; set; }
        private int ntris, nverts;
    }

    public class Triangle:Shape
    {

        public Triangle()
        {
            v = new int[3];
        }
        public Triangle(Transform W2O,Transform O2W,Mesh M,int n)
        {
            o2w = O2W;
            w2o = W2O;
            v = new int[3];
            m = M;
            v[0] = m.vertexIndex[n];
            v[1] = m.vertexIndex[n + 1];
            v[2] = m.vertexIndex[n + 2];
        }

        public override bool Intersect(Ray ray, ref DifferentialGeometry dg)
        {
            Point3 p1 = m.P[v[0]];
            Point3 p2 = m.P[v[1]];
            Point3 p3 = m.P[v[2]];

            Vector e1 = p2 - p1;
            Vector e2 = p3 - p1;
            Vector s1 = LR.Cross(ray.d, e2);

            float divisor = LR.Dot(s1, e1);

            if (divisor == 0.0f)
                return false;
            float invDivisor = 1.0f / divisor;

            // Compute first barycentric coordinate
            Vector s = ray.o - p1;
            float b1 = LR.Dot(s, s1) * invDivisor;
            if (b1 < 0.0f || b1 > 1.0f)
                return false;

            // Compute second barycentric coordinate
            Vector s2 = LR.Cross(s, e1);
            float b2 = LR.Dot(ray.d, s2) * invDivisor;
            if (b2 < 0.0f || b1 + b2 > 1.0f)
                return false;

            // Compute _t_ to intersection point
            float t = LR.Dot(e2, s2) * invDivisor;
            if (t < ray.mint || t > ray.maxt)
                return false;


            return false;
        }
        private  Mesh m { get; set; }
        private int[] v;
        
    }
}
