namespace DSkin.OpenGL
{
    using System;

    public enum StencilOperation : uint
    {
        Decrease = 0x1e03,
        Increase = 0x1e02,
        Invert = 0x150a,
        Keep = 0x1e00,
        Replace = 0x1e01,
        Zero = 0
    }
}

