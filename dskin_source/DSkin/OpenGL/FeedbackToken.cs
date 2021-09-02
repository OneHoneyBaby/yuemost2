namespace DSkin.OpenGL
{
    using System;

    public enum FeedbackToken : uint
    {
        BitmapToken = 0x704,
        CopyPixelToken = 0x706,
        DrawPixelToken = 0x705,
        LineResetToken = 0x707,
        LineToken = 0x702,
        PassThroughToken = 0x700,
        PointToken = 0x701,
        PolygonToken = 0x703
    }
}

