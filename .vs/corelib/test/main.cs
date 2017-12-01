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
         
            //Matrix4x4 m1 = new Matrix4x4(-0.0198209956f, -0.328598410f, -0.944261789f, 396.734772f, -0.999803603f, 0.00651442632f, 0.0187198818f, 54.7861862f, 0.000000000f, 0.944447339f, -0.328662962f, 30.0000000f, 0, 0, 0, 1);
            //Matrix4x4 m2 = new Matrix4x4(-0.0198209956f, -0.328598410f, -0.944261789f, 396.734772f, -0.999803603f, 0.00651442632f, 0.0187198818f, 54.7861862f, 0.000000000f, 0.944447339f, -0.328662962f, 30.0000000f, 0, 0, 0, 1);
            //Matrix4x4 m3 = LR.Multiply(m1, m2);
            //Transform t = new Transform(m1);
            //Transform t2 = LR.Multiply(LR.Scale(10, 10, 10), t);

            Transform t11 = new Transform(new Matrix4x4(-0.0198209956f, -0.328598410f, -0.944261789f, 396.734772f, -0.999803603f, 0.00651442632f, 0.0187198818f, 54.7861862f, 0.000000000f, 0.944447339f, -0.328662962f, 30.0000000f, 0, 0, 0, 1));
            Transform t22 = new Transform(new Matrix4x4(-0.0198209956f, -0.328598410f, -0.944261789f, 396.734772f, -0.999803603f, 0.00651442632f, 0.0187198818f, 54.7861862f, 0.000000000f, 0.944447339f, -0.328662962f, 30.0000000f, 0, 0, 0, 1));
            AnimatedTransform cam2word = new AnimatedTransform(t11,0,t22,1);

            float[] screen = new float[4] { -1, 1, -1, 1 };
            Film film = new Film();
            film.xResolution = 700;
            film.yResolution = 700;
            OrthoCamera orthoCamera = new OrthoCamera(cam2word, screen, 0, 1, 0, 0, film);
            CameraSample cameraSample = new CameraSample(689.738220f, 678.709778f, 0.559352338f, 0.253510952f, 0.562246382f);

            //cameraSample.imageX = 689.738220f;
            RayDifferential rd;
            orthoCamera.GenerateRayDifferential(cameraSample, out rd);

        }
        static public void  f(Vector v1)
        {
            v1.x = 10.0f;
        }
    }
}
