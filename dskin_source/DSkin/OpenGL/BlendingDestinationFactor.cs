namespace DSkin.OpenGL
{
    using System;

    public enum BlendingDestinationFactor : uint
    {
        DestinationAlpha = 0x304,
        One = 1,
        OneMinusDestinationAlpha = 0x305,
        OneMinusSourceAlpha = 0x303,
        OneMinusSourceColor = 0x301,
        SourceAlpha = 770,
        SourceColor = 0x300,
        Zero = 0
    }
}

