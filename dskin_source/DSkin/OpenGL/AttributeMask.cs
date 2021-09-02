namespace DSkin.OpenGL
{
    using System;

    [Flags]
    public enum AttributeMask : uint
    {
        AccumBuffer = 0x200,
        All = 0xfffff,
        ColorBuffer = 0x4000,
        Current = 1,
        DepthBuffer = 0x100,
        Enable = 0x2000,
        Eval = 0x10000,
        Fog = 0x80,
        Hint = 0x8000,
        Lighting = 0x40,
        Line = 4,
        List = 0x20000,
        None = 0,
        PixelMode = 0x20,
        Point = 2,
        Polygon = 8,
        PolygonStipple = 0x10,
        Scissor = 0x80000,
        StencilBuffer = 0x400,
        Texture = 0x40000,
        Transform = 0x1000,
        Viewport = 0x800
    }
}

