namespace DSkin.Common
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [StructLayout(LayoutKind.Sequential)]
    public struct ImeModeConversion
    {
        private static Dictionary<ImeMode, DSkin.Common.ImeModeConversion> dictionary_0;
        internal int int_0;
        internal int int_1;
        private static ImeMode[] imeMode_0;
        private static ImeMode[] imeMode_1;
        private static ImeMode[] imeMode_2;
        private static ImeMode[] imeMode_3;
        internal static ImeMode[] smethod_0()
        {
            return imeMode_2;
        }

        internal static ImeMode[] smethod_1()
        {
            return imeMode_0;
        }

        internal static ImeMode[] smethod_2()
        {
            return imeMode_1;
        }

        internal static ImeMode[] smethod_3()
        {
            return imeMode_3;
        }

        internal static ImeMode[] smethod_4()
        {
            int num2 = (int) (((long) InputLanguage.CurrentInputLanguage.Handle) & 0xffffL);
            if (num2 <= 0x804)
            {
                switch (num2)
                {
                    case 0x411:
                        return imeMode_0;

                    case 0x412:
                        goto Label_006F;

                    case 0x804:
                    case 0x404:
                        goto Label_008F;
                }
            }
            else if (num2 > 0xc04)
            {
                switch (num2)
                {
                    case 0x1004:
                    case 0x1404:
                        goto Label_008F;
                }
            }
            else
            {
                switch (num2)
                {
                    case 0x812:
                        goto Label_006F;

                    case 0xc04:
                        goto Label_008F;
                }
            }
            return imeMode_3;
        Label_006F:
            return imeMode_1;
        Label_008F:
            return imeMode_2;
        }

        public static Dictionary<ImeMode, DSkin.Common.ImeModeConversion> ImeModeConversionBits
        {
            get
            {
                if (dictionary_0 == null)
                {
                    DSkin.Common.ImeModeConversion conversion;
                    dictionary_0 = new Dictionary<ImeMode, DSkin.Common.ImeModeConversion>(7);
                    conversion.int_0 = 9;
                    conversion.int_1 = 2;
                    dictionary_0.Add(ImeMode.Hiragana, conversion);
                    conversion.int_0 = 11;
                    conversion.int_1 = 0;
                    dictionary_0.Add(ImeMode.Katakana, conversion);
                    conversion.int_0 = 3;
                    conversion.int_1 = 8;
                    dictionary_0.Add(ImeMode.KatakanaHalf, conversion);
                    conversion.int_0 = 8;
                    conversion.int_1 = 3;
                    dictionary_0.Add(ImeMode.AlphaFull, conversion);
                    conversion.int_0 = 0;
                    conversion.int_1 = 11;
                    dictionary_0.Add(ImeMode.Alpha, conversion);
                    conversion.int_0 = 9;
                    conversion.int_1 = 0;
                    dictionary_0.Add(ImeMode.HangulFull, conversion);
                    conversion.int_0 = 1;
                    conversion.int_1 = 8;
                    dictionary_0.Add(ImeMode.Hangul, conversion);
                    conversion.int_0 = 1;
                    conversion.int_1 = 10;
                    dictionary_0.Add(ImeMode.OnHalf, conversion);
                }
                return dictionary_0;
            }
        }
        public static bool IsCurrentConversionTableSupported
        {
            get
            {
                return (smethod_4() != smethod_3());
            }
        }
        static ImeModeConversion()
        {
            imeMode_0 = new ImeMode[] { ImeMode.Inherit, ImeMode.Disable, ImeMode.Off, ImeMode.Off, ImeMode.Hiragana, ImeMode.Hiragana, ImeMode.Katakana, ImeMode.KatakanaHalf, ImeMode.AlphaFull, ImeMode.Alpha };
            imeMode_1 = new ImeMode[] { ImeMode.Inherit, ImeMode.Disable, ImeMode.Alpha, ImeMode.Alpha, ImeMode.HangulFull, ImeMode.Hangul, ImeMode.HangulFull, ImeMode.Hangul, ImeMode.AlphaFull, ImeMode.Alpha };
            imeMode_2 = new ImeMode[] { ImeMode.Inherit, ImeMode.Disable, ImeMode.Off, ImeMode.Close, ImeMode.On, ImeMode.OnHalf, ImeMode.On, ImeMode.OnHalf, ImeMode.Off, ImeMode.Off };
            imeMode_3 = new ImeMode[0];
        }
    }
}

