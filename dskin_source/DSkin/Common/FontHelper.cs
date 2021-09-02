namespace DSkin.Common
{
    using DSkin.Properties;
    using System;
    using System.Drawing;
    using System.Drawing.Text;

    public static class FontHelper
    {
        private static FontFamily fontFamily_0;
        private static PrivateFontCollection privateFontCollection_0 = new PrivateFontCollection();

        public static FontFamily FontAwesome
        {
            get
            {
                if (fontFamily_0 == null)
                {
                    byte[] buffer2;
                    byte[] buffer = Resources.smethod_20();
                    if (((buffer2 = buffer) != null) && (buffer2.Length != 0))
                    {
                        numRef = buffer2;
                        goto Label_002A;
                    }
                    fixed (byte* numRef = null)
                    {
                    Label_002A:
                        privateFontCollection_0.AddMemoryFont((IntPtr) numRef, buffer.Length);
                    }
                    fontFamily_0 = privateFontCollection_0.Families[0];
                }
                return fontFamily_0;
            }
        }
    }
}

