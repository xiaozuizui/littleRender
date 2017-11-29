using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using corelib.core;
using corelib.shapes;
using corelib.cameras;
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
            //float[,] m = new float[4,4] {{ 0.832801f, 0.182353f, 0.522677f, -0 },{ -0, 0.944187f, -0.329411f, -0}, { 0.553573f, -0.274334f, -0.786319f, -0}, { -5.59444f, -2.78217f, 7.45666f, 1} };
            //Matrix4x4 M = new Matrix4x4(m);
            //m[0, 0] = 0;
            ////Matrix4x4 M = new Matrix4x4(0.832801f, 0.182353f, 0.522677f, -0, -0, 0.944187f, -0.329411f, -0, 0.553573f, -0.274334f, -0.786319f, -0, -5.59444f, -2.78217f, 7.45666f, 1);

            //Transform t = new Transform(M);

            // ProjectiveCamera pjc = new ProjectiveCamera(t, t, null, 2, 2, new float[4] { 1.0f, 2.0f, 3.0f, 4.0f });
            Transform t1 = new Transform(new Matrix4x4(-0.0198209956f, -0.328598410f, -0.944261789f, 396.734772f, -0.999803603f, 0.00651442632f, 0.0187198818f, 54.7861862f, 0.000000000f, 0.944447339f, -0.328662962f, 30.0000000f, 0, 0, 0, 1));
            Transform t2 = new Transform(new Matrix4x4(-0.0198209956f, -0.328598410f, -0.944261789f, 396.734772f, -0.999803603f, 0.00651442632f, 0.0187198818f, 54.7861862f, 0.000000000f, 0.944447339f, -0.328662962f, 30.0000000f, 0, 0, 0, 1));
            AnimatedTransform cam2word = new AnimatedTransform(t1,0,t2,1);
            
        }
        static public void  f(Vector v1)
        {
            v1.x = 10.0f;
        }
    }
}
