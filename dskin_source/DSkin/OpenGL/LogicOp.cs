namespace DSkin.OpenGL
{
    using System;

    public enum LogicOp : uint
    {
        And = 0x1501,
        AndInverted = 0x1504,
        AndReverse = 0x1502,
        Clear = 0x1500,
        Copy = 0x1503,
        CopyInverted = 0x150c,
        Equiv = 0x1509,
        Invert = 0x150a,
        NAnd = 0x150e,
        NoOp = 0x1505,
        NOr = 0x1508,
        Or = 0x1507,
        OrInverted = 0x150d,
        OrReverse = 0x150b,
        Set = 0x150f,
        XOr = 0x1506
    }
}

