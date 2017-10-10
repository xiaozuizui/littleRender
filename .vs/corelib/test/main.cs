using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using corelib.core;
using corelib.shapes;

namespace test
{
    class main
    {
        static void Main(string[] args)
        {
            // Vector v1 = new Vector(1.0f,2.0f,3.0f);
            // Vector v2 = new Vector(1.0f, 2.0f, 3.0f);

            // Sphere sp = new Sphere(1.0f);
            // Ray R = new Ray(new Point3(1.0f, 1.0f, 1.0f), new Vector(-0.5f,-0.5f,-0.5f),2,0);
            // //bool hit =  sp.Intersect(null, R, null);
            //// Mesh m = new Mesh();

            Matrix4x4 M = new Matrix4x4(0.832801f, 0.182353f, 0.522677f, -0, -0, 0.944187f, -0.329411f, -0, 0.553573f, -0.274334f, -0.786319f, -0, -5.59444f, -2.78217f, 7.45666f, 1);
            Transform t = new Transform(M);
            
        }
        static public void  f(Vector v1)
        {
            v1.x = 10.0f;
        }
    }
}
