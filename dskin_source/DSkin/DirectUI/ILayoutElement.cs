namespace DSkin.DirectUI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public interface ILayoutElement
    {
        int Height { get; }

        int Left { get; }

        Point Location { get; set; }

        Padding Margin { get; set; }

        System.Drawing.Size Size { get; set; }

        int Top { get; }

        bool Visible { get; set; }

        int Width { get; }
    }
}

