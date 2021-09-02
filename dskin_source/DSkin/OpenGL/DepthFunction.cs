namespace DSkin.OpenGL
{
    using System;

    public enum DepthFunction : uint
    {
        Always = 0x207,
        Equal = 0x202,
        Great = 0x204,
        GreaterThanOrEqual = 0x206,
        Less = 0x201,
        LessThanOrEqual = 0x203,
        Never = 0x200,
        NotEqual = 0x205
    }
}

