using System;
using System.Collections.Generic;
using System.Text;

namespace corelib.core
{
    enum BxDFType
    {
        BSDF_REFLECTION = 1 << 0,
        BSDF_TRANSMISSION = 1 << 1,
        BSDF_DIFFUSE = 1 << 2,
        BSDF_GLOSSY = 1 << 3,
        BSDF_SPECULAR = 1 << 4,

        BSDF_ALL_TYPES = BSDF_DIFFUSE |
                                BSDF_GLOSSY |
                                BSDF_SPECULAR,

        BSDF_ALL_REFLECTION = BSDF_REFLECTION |
                                BSDF_ALL_TYPES,

        BSDF_ALL_TRANSMISSION = BSDF_TRANSMISSION |
                                BSDF_ALL_TYPES,

        BSDF_ALL = BSDF_ALL_REFLECTION |
                                BSDF_ALL_TRANSMISSION
    }
    class BSDF
    {
    }

    class BxDF
    {

    }
}
