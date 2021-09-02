namespace DSkin.Controls
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;

    public class MouseHook
    {
        private GCHandle gchandle_0;
        private IntPtr intptr_0 = IntPtr.Zero;

        public event MHookEventHandler Event_0;

        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        private int method_0(int int_0, IntPtr intptr_1, IntPtr intptr_2)
        {
            if ((int_0 >= 0) && (this.mhookEventHandler_0 != null))
            {
                MSLLHOOTSTRUCT msllhootstruct = (MSLLHOOTSTRUCT) Marshal.PtrToStructure(intptr_2, typeof(MSLLHOOTSTRUCT));
                ButtonStatus none = ButtonStatus.None;
                if (intptr_1 == ((IntPtr) 0x201L))
                {
                    none = ButtonStatus.LeftDown;
                }
                else if (intptr_1 == ((IntPtr) 0x202L))
                {
                    none = ButtonStatus.LeftUp;
                }
                else if (intptr_1 == ((IntPtr) 0x204L))
                {
                    none = ButtonStatus.RightDown;
                }
                else if (intptr_1 == ((IntPtr) 0x205L))
                {
                    none = ButtonStatus.RightUp;
                }
                this.mhookEventHandler_0(this, new MHookEventArgs(none, msllhootstruct.pt.X, msllhootstruct.pt.Y));
            }
            return CallNextHookEx(this.intptr_0, int_0, intptr_1, intptr_2);
        }

        public bool SetHook()
        {
            if (this.intptr_0 == IntPtr.Zero)
            {
                HookProc lpfn = new HookProc(this.method_0);
                this.intptr_0 = SetWindowsHookEx(14, lpfn, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
                if (this.intptr_0 != IntPtr.Zero)
                {
                    this.gchandle_0 = GCHandle.Alloc(lpfn);
                    return true;
                }
            }
            return false;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hmod, int dwThreadid);
        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(IntPtr hHook);
        public bool UnLoadHook()
        {
            if ((this.intptr_0 != IntPtr.Zero) && UnhookWindowsHookEx(this.intptr_0))
            {
                this.intptr_0 = IntPtr.Zero;
                this.gchandle_0.Free();
                return true;
            }
            return false;
        }

        public IntPtr HHook
        {
            get
            {
                return this.intptr_0;
            }
        }

        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        public delegate void MHookEventHandler(object sender, MHookEventArgs e);

        [StructLayout(LayoutKind.Sequential)]
        public struct MSLLHOOTSTRUCT
        {
            public MouseHook.POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }
    }
}

