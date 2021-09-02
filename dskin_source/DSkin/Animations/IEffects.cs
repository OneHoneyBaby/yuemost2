namespace DSkin.Animations
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    public interface IEffects : IDisposable
    {
        Bitmap DoEffect(out Point locationOffset);
        void Reset();

        bool CanDesc { get; }

        bool IsAsc { set; }

        bool IsFinal { get; }

        string Name { get; }

        Bitmap Original { get; set; }
    }
}

