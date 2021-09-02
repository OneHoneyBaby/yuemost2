namespace DSkin.OpenGL
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct GLYPHMETRICSFLOAT
    {
        public float gmfBlackBoxX;
        public float gmfBlackBoxY;
        public POINTFLOAT gmfptGlyphOrigin;
        public float gmfCellIncX;
        public float gmfCellIncY;
    }
}

