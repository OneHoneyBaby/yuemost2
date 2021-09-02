namespace DSkin.OpenGL
{
    using System;

    public enum LightParameter : uint
    {
        Ambient = 0x1200,
        ConstantAttenuatio = 0x1207,
        Diffuse = 0x1201,
        LinearAttenuation = 0x1208,
        Position = 0x1203,
        QuadraticAttenuation = 0x1209,
        Specular = 0x1202,
        SpotCutoff = 0x1206,
        SpotDirection = 0x1204,
        SpotExponent = 0x1205
    }
}

