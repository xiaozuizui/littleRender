using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;

namespace corelib.cameras
{
    public abstract class ProjectiveCamera:Camera
    {
       

       public ProjectiveCamera(Transform c2w,Transform proj,Film f, float lensr, float focald, float [] screenWindow) :base(c2w,f) 
        {
            // Initialize depth of field parameters
            lensRadius = lensr;
            focalDistance = focald;
            
            // Compute projective camera transformations
            CameraToScreen = proj;

            // Compute projective camera screen transformations
            ScreenToRaster = Multiply( //

               Scale(film.xResolution,
                                   film.yResolution, 1.0f),
                Scale(1.0f / (screenWindow[1] - screenWindow[0]),
                      1.0f / (screenWindow[2] - screenWindow[3]), 1.0f) ,
                      
                Translate(new Vector(-screenWindow[0], -screenWindow[3], 0.0f)));


            RasterToScreen = Inverse(ScreenToRaster);
            RasterToCamera = Multiply(Inverse(CameraToScreen) , RasterToScreen);
        }

       
       

        protected Transform CameraToScreen, RasterToCamera; 
        protected Transform ScreenToRaster, RasterToScreen;
        protected float lensRadius, focalDistance;
    }
}
