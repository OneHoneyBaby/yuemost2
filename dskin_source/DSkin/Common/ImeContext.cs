namespace DSkin.Common
{
    using DSkin;
    using System;
    using System.Windows.Forms;

    public static class ImeContext
    {
        private static IntPtr intptr_0;

        public static void Disable(IntPtr handle)
        {
            if (DSkin.Common.ImeModeConversion.smethod_4() != DSkin.Common.ImeModeConversion.smethod_3())
            {
                if (IsOpen(handle))
                {
                    SetOpenStatus(false, handle);
                }
                IntPtr ptr = DSkin.NativeMethods.ImmAssociateContext(handle, IntPtr.Zero);
                if (ptr != IntPtr.Zero)
                {
                    intptr_0 = ptr;
                }
            }
            smethod_0(handle);
        }

        public static void Enable(IntPtr handle)
        {
            if (DSkin.Common.ImeModeConversion.smethod_4() != DSkin.Common.ImeModeConversion.smethod_3())
            {
                IntPtr hIMC = DSkin.NativeMethods.ImmGetContext(handle);
                if (hIMC == IntPtr.Zero)
                {
                    if (intptr_0 == IntPtr.Zero)
                    {
                        hIMC = DSkin.NativeMethods.ImmCreateContext();
                        if (hIMC != IntPtr.Zero)
                        {
                            DSkin.NativeMethods.ImmAssociateContext(handle, hIMC);
                        }
                    }
                    else
                    {
                        DSkin.NativeMethods.ImmAssociateContext(handle, intptr_0);
                    }
                }
                else
                {
                    DSkin.NativeMethods.ImmReleaseContext(handle, hIMC);
                }
                if (!IsOpen(handle))
                {
                    SetOpenStatus(true, handle);
                }
            }
            smethod_0(handle);
        }

        public static ImeMode GetImeMode(IntPtr handle)
        {
            IntPtr zero = IntPtr.Zero;
            ImeMode noControl = ImeMode.NoControl;
            ImeMode[] modeArray = DSkin.Common.ImeModeConversion.smethod_4();
            if (modeArray == DSkin.Common.ImeModeConversion.smethod_3())
            {
                noControl = ImeMode.Inherit;
            }
            else
            {
                zero = DSkin.NativeMethods.ImmGetContext(handle);
                if (zero == IntPtr.Zero)
                {
                    noControl = ImeMode.Disable;
                }
                else if (!IsOpen(handle))
                {
                    noControl = modeArray[3];
                }
                else
                {
                    int conversion = 0;
                    int sentence = 0;
                    DSkin.NativeMethods.ImmGetConversionStatus(zero, ref conversion, ref sentence);
                    if ((conversion & 1) != 0)
                    {
                        if ((conversion & 2) != 0)
                        {
                            noControl = ((conversion & 8) != 0) ? modeArray[6] : modeArray[7];
                        }
                        else
                        {
                            noControl = ((conversion & 8) != 0) ? modeArray[4] : modeArray[5];
                        }
                    }
                    else
                    {
                        noControl = ((conversion & 8) != 0) ? modeArray[8] : modeArray[9];
                    }
                }
            }
            if (zero != IntPtr.Zero)
            {
                DSkin.NativeMethods.ImmReleaseContext(handle, zero);
            }
            smethod_0(handle);
            return noControl;
        }

        public static bool IsOpen(IntPtr handle)
        {
            IntPtr hIMC = DSkin.NativeMethods.ImmGetContext(handle);
            bool flag = false;
            if (hIMC != IntPtr.Zero)
            {
                flag = DSkin.NativeMethods.ImmGetOpenStatus(hIMC);
                DSkin.NativeMethods.ImmReleaseContext(handle, hIMC);
            }
            return flag;
        }

        public static void SetImeStatus(ImeMode imeMode, IntPtr handle)
        {
            if ((imeMode == ImeMode.Inherit) || (imeMode == ImeMode.NoControl))
            {
                goto Label_00EC;
            }
            ImeMode[] modeArray = DSkin.Common.ImeModeConversion.smethod_4();
            if (modeArray == DSkin.Common.ImeModeConversion.smethod_3())
            {
                goto Label_00EC;
            }
            int num = 0;
            int sentence = 0;
            if (imeMode == ImeMode.Disable)
            {
                Disable(handle);
            }
            else
            {
                Enable(handle);
            }
            switch (imeMode)
            {
                case ImeMode.NoControl:
                case ImeMode.Disable:
                    goto Label_00EC;

                case ImeMode.On:
                    imeMode = ImeMode.Hiragana;
                    goto Label_0093;

                case ImeMode.Off:
                    if (modeArray != DSkin.Common.ImeModeConversion.smethod_1())
                    {
                        imeMode = ImeMode.Alpha;
                        goto Label_0093;
                    }
                    break;

                case ImeMode.Close:
                    break;

                default:
                    goto Label_0093;
            }
            if (modeArray == DSkin.Common.ImeModeConversion.smethod_2())
            {
                imeMode = ImeMode.Alpha;
            }
            else
            {
                SetOpenStatus(false, handle);
                goto Label_00EC;
            }
        Label_0093:
            if (DSkin.Common.ImeModeConversion.ImeModeConversionBits.ContainsKey(imeMode))
            {
                DSkin.Common.ImeModeConversion conversion = DSkin.Common.ImeModeConversion.ImeModeConversionBits[imeMode];
                IntPtr hIMC = DSkin.NativeMethods.ImmGetContext(handle);
                DSkin.NativeMethods.ImmGetConversionStatus(hIMC, ref num, ref sentence);
                num |= conversion.int_0;
                num &= ~conversion.int_1;
                DSkin.NativeMethods.ImmSetConversionStatus(hIMC, num, sentence);
                DSkin.NativeMethods.ImmReleaseContext(handle, hIMC);
            }
        Label_00EC:
            smethod_0(handle);
        }

        public static void SetOpenStatus(bool open, IntPtr handle)
        {
            if (DSkin.Common.ImeModeConversion.smethod_4() != DSkin.Common.ImeModeConversion.smethod_3())
            {
                IntPtr hIMC = DSkin.NativeMethods.ImmGetContext(handle);
                if ((hIMC != IntPtr.Zero) && DSkin.NativeMethods.ImmSetOpenStatus(hIMC, open))
                {
                    DSkin.NativeMethods.ImmReleaseContext(handle, hIMC);
                }
            }
            smethod_0(handle);
        }

        private static void smethod_0(IntPtr intptr_1)
        {
        }
    }
}

