namespace DSkin.OpenGL
{
    using System;

    public enum BeginMode : uint
    {
        LineLoop = 2,
        Lines = 1,
        LineStrip = 3,
        Points = 0,
        Polygon = 9,
        Quads = 7,
        QuadStrip = 8,
        TriangleFan = 6,
        Triangles = 4,
        TriangleString = 5
    }
}

