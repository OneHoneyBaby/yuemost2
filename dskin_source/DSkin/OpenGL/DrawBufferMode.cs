namespace DSkin.OpenGL
{
    using System;

    public enum DrawBufferMode : uint
    {
        Auxilliary0 = 0x409,
        Auxilliary1 = 0x40a,
        Auxilliary2 = 0x40b,
        Auxilliary3 = 0x40c,
        Back = 0x405,
        BackLeft = 0x402,
        BackRight = 0x403,
        Front = 0x404,
        FrontAndBack = 0x408,
        FrontLeft = 0x400,
        FrontRight = 0x401,
        Left = 0x406,
        None = 0,
        Right = 0x407
    }
}

