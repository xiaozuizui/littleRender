﻿using System;
using System.Collections.Generic;
using System.Text;
using corelib.core;

namespace corelib.cameras
{
    public abstract class ProjectiveCamera:Camera //投影相机
    {
       

       public ProjectiveCamera(AnimatedTransform c2w,Transform proj, float [] screenWindow,float sopen,float sclose, float lensr, float focald,Film f) :base(c2w,sopen,sclose,f) 
        {
            // Initialize depth of field parameters
            lensRadius = lensr;
            focalDistance = focald;

            // Compute projective camera transformations
            CameraToScreen = //Perspective(fov, 1e-2f, 1000.f);
                proj;

            // Compute projective camera screen transformations

            ScreenToRaster = LR.Multiply(LR.Scale(film.xResolution, film.yResolution, 1.0f),
                LR.Scale(1.0f / (screenWindow[1] - screenWindow[0]), 1.0f / (screenWindow[2] - screenWindow[3]), 1.0f),
                LR.Translate(new Vector(-screenWindow[0], -screenWindow[3], 0.0f))
                );

            RasterToScreen = LR.Inverse(ScreenToRaster);
            RasterToCamera = LR.Multiply(LR.Inverse(CameraToScreen) , RasterToScreen);
        }

       
       
        
        protected Transform CameraToScreen, RasterToCamera; 
        protected Transform ScreenToRaster, RasterToScreen;
        protected float lensRadius, focalDistance;
    }
}
