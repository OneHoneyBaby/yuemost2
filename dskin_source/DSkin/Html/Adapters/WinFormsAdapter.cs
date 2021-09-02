namespace DSkin.Html.Adapters
{
    using DSkin.Html;
    using DSkin.Html.Adapters.Entities;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public sealed class WinFormsAdapter : RAdapter
    {
        private static readonly WinFormsAdapter winFormsAdapter_0 = new WinFormsAdapter();

        private WinFormsAdapter()
        {
            base.AddFontFamilyMapping("monospace", "Courier New");
            base.AddFontFamilyMapping("Helvetica", "Arial");
            foreach (FontFamily family in FontFamily.Families)
            {
                base.AddFontFamily(new FontFamilyAdapter(family));
            }
        }

        protected override RImage ConvertImageInt(object image)
        {
            return ((image != null) ? new ImageAdapter((Image) image) : null);
        }

        protected override RContextMenu CreateContextMenuInt()
        {
            return new ContextMenuAdapter();
        }

        protected override RFont CreateFontInt(RFontFamily family, double size, RFontStyle style)
        {
            FontStyle style2 = (FontStyle) style;
            return new FontAdapter(new Font(((FontFamilyAdapter) family).FontFamily, (float) size, style2));
        }

        protected override RFont CreateFontInt(string family, double size, RFontStyle style)
        {
            FontStyle style2 = (FontStyle) style;
            return new FontAdapter(new Font(family, (float) size, style2));
        }

        protected override RBrush CreateLinearGradientBrush(RRect rect, RColor color1, RColor color2, double angle)
        {
            return new BrushAdapter(new LinearGradientBrush(Utils.Convert(rect), Utils.Convert(color1), Utils.Convert(color2), (float) angle), true);
        }

        protected override RPen CreatePen(RColor color)
        {
            return new PenAdapter(new Pen(Utils.Convert(color)));
        }

        protected override RBrush CreateSolidBrush(RColor color)
        {
            Brush brush;
            if (color == RColor.White)
            {
                brush = new SolidBrush(Color.FromArgb(0xfe, Color.White));
            }
            else if (color == RColor.Black)
            {
                brush = new SolidBrush(Color.FromArgb(0xfe, Color.Black));
            }
            else if (color.A < 1)
            {
                brush = new SolidBrush(Color.FromArgb(1, Color.White));
            }
            else
            {
                brush = new SolidBrush(Color.FromArgb((color.A >= 0xff) ? 0xfe : color.A, color.R, color.G, color.B));
            }
            return new BrushAdapter(brush, false);
        }

        protected override object GetClipboardDataObjectInt(string html, string plainText)
        {
            return Class22.smethod_0(html, plainText);
        }

        protected override RColor GetColorInt(string colorName)
        {
            return Utils.Convert(Color.FromName(colorName));
        }

        protected override RImage ImageFromStreamInt(Stream memoryStream)
        {
            return new ImageAdapter(Image.FromStream(memoryStream));
        }

        protected override void SaveToFileInt(RImage image, string name, string extension, RControl control = null)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "Images|*.png;*.bmp;*.jpg";
                dialog.FileName = name;
                dialog.DefaultExt = extension;
                DialogResult result = (control == null) ? dialog.ShowDialog() : dialog.ShowDialog(((ControlAdapter) control).Control);
                if (result == DialogResult.OK)
                {
                    ((ImageAdapter) image).Image.Save(dialog.FileName);
                }
            }
        }

        protected override void SetToClipboardInt(RImage image)
        {
            Clipboard.SetImage(((ImageAdapter) image).Image);
        }

        protected override void SetToClipboardInt(string text)
        {
            Class22.smethod_2(text);
        }

        protected override void SetToClipboardInt(string html, string plainText)
        {
            Class22.smethod_1(html, plainText);
        }

        public static WinFormsAdapter Instance
        {
            get
            {
                return winFormsAdapter_0;
            }
        }
    }
}

