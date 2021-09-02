namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.InteropServices;

    public class JsValue
    {
        private IntPtr intptr_0;
        private long long_0;

        public JsValue(long value, IntPtr jsExecState)
        {
            this.long_0 = value;
            this.intptr_0 = jsExecState;
        }

        public JsValue(IntPtr jsExecState, int argIndex)
        {
            this.intptr_0 = jsExecState;
            this.long_0 = EweCore.wkeJSParam(this.intptr_0, argIndex);
        }

        public static int ArgCount(IntPtr jsExecState)
        {
            return EweCore.wkeJSParamCount(jsExecState);
        }

        public static long JsDouble(IntPtr jsExecState, double d)
        {
            return EweCore.wkeJSDouble(jsExecState, d);
        }

        public static long JsFalse(IntPtr jsExecState)
        {
            return EweCore.wkeJSFalse(jsExecState);
        }

        public static long JsFloat(IntPtr jsExecState, float f)
        {
            return EweCore.wkeJSFloat(jsExecState, f);
        }

        public static long JsInt(IntPtr jsExecState, int n)
        {
            return EweCore.wkeJSInt(jsExecState, n);
        }

        public static long JsNull(IntPtr jsExecState)
        {
            return EweCore.wkeJSNull(jsExecState);
        }

        public static long JsString(IntPtr jsExecState, string str)
        {
            return EweCore.wkeJSString(jsExecState, str);
        }

        public static long JsTrue(IntPtr jsExecState)
        {
            return EweCore.wkeJSTrue(jsExecState);
        }

        public static long JsUndefined(IntPtr jsExecState)
        {
            return EweCore.wkeJSUndefined(jsExecState);
        }

        public bool ToBool()
        {
            return EweCore.wkeJSToBool(this.intptr_0, this.long_0);
        }

        public double ToDouble()
        {
            return EweCore.wkeJSToDouble(this.intptr_0, this.long_0);
        }

        public float ToFloat()
        {
            return EweCore.wkeJSToFloat(this.intptr_0, this.long_0);
        }

        public int ToInt()
        {
            return EweCore.wkeJSToInt(this.intptr_0, this.long_0);
        }

        public override string ToString()
        {
            if (this.intptr_0 == IntPtr.Zero)
            {
                return string.Empty;
            }
            return Marshal.PtrToStringUni(EweCore.wkeJSToString(this.intptr_0, this.long_0));
        }

        public wkeJSType JsType
        {
            get
            {
                return EweCore.wkeJSTypeOf(this.intptr_0, this.long_0);
            }
        }

        public long Value
        {
            get
            {
                return this.long_0;
            }
        }
    }
}

