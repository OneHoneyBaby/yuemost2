namespace DSkin.Controls
{
    using DSkin;
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    [DefaultProperty("Key"), DefaultEvent("HotKeyTrigger")]
    public class DSkinHotKey : Component
    {
        private bool bool_0;
        private bool bool_1;
        private Class60 class60_0;
        private GCHandle gchandle_0;
        private int int_0;
        private IntPtr intptr_0;
        private KeyModifiers keyModifiers_0;
        private Keys keys_0;
        private object object_0;

        [Description("热键被按下时发生")]
        public event EventHandler<HotKeyEventArgs> HotKeyTrigger;

        public DSkinHotKey()
        {
            this.keyModifiers_0 = KeyModifiers.None;
            this.bool_0 = false;
            this.bool_1 = false;
            this.int_0 = new Random().Next(1, 0x3e8);
        }

        public DSkinHotKey(IContainer container) : this()
        {
            container.Add(this);
        }

        public DSkinHotKey(KeyModifiers keyModifier, Keys key) : this()
        {
            this.keyModifiers_0 = keyModifier;
            this.keys_0 = key;
        }

        protected override void Dispose(bool disposing)
        {
            this.method_1();
            if ((disposing && (this.class60_0 != null)) && (this.class60_0.Handle != IntPtr.Zero))
            {
                this.class60_0.DestroyHandle();
            }
            if (this.gchandle_0.IsAllocated)
            {
                this.gchandle_0.Free();
            }
            this.bool_1 = false;
            this.class60_0 = null;
            base.Dispose(disposing);
        }

        private void method_0()
        {
            if (DSkin.NativeMethods.RegisterHotKey(this.intptr_0, this.int_0, this.keyModifiers_0, this.keys_0))
            {
                this.bool_0 = true;
            }
        }

        private void method_1()
        {
            if (DSkin.NativeMethods.UnregisterHotKey(this.intptr_0, this.int_0))
            {
                this.bool_0 = false;
            }
        }

        private void method_2()
        {
            if ((this.keys_0 != Keys.None) && !base.DesignMode)
            {
                if (this.bool_1)
                {
                    if (this.class60_0 == null)
                    {
                        this.class60_0 = new Class60(this);
                    }
                    if (this.bool_0)
                    {
                        this.method_1();
                    }
                    if (!this.gchandle_0.IsAllocated)
                    {
                        this.gchandle_0 = GCHandle.Alloc(this);
                        this.class60_0.method_0();
                        this.intptr_0 = this.class60_0.Handle;
                    }
                    this.method_0();
                }
                else
                {
                    this.method_1();
                    if (this.gchandle_0.IsAllocated)
                    {
                        if (this.class60_0 != null)
                        {
                            this.class60_0.DestroyHandle();
                        }
                        this.gchandle_0.Free();
                    }
                }
            }
        }

        protected void OnTriggerHotKey(HotKeyEventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        [Description("是否启用")]
        public bool Enabled
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                if (this.bool_1 != value)
                {
                    this.bool_1 = value;
                    this.method_2();
                }
            }
        }

        [Browsable(false)]
        public IntPtr Handle
        {
            get
            {
                return this.intptr_0;
            }
        }

        [Browsable(false)]
        public int Id
        {
            get
            {
                return this.int_0;
            }
        }

        [Browsable(false)]
        public bool IsRegistered
        {
            get
            {
                return this.bool_0;
            }
        }

        [Description("按键，必须填写按键，请勿添加修饰键，修饰键在辅助键 KeyModifier 属性那边设置")]
        public Keys Key
        {
            get
            {
                return this.keys_0;
            }
            set
            {
                if (this.keys_0 != value)
                {
                    this.keys_0 = value;
                    this.method_2();
                }
            }
        }

        [Description("辅助按键，多辅助键写法  Alt, Ctrl")]
        public KeyModifiers KeyModifier
        {
            get
            {
                return this.keyModifiers_0;
            }
            set
            {
                if (this.keyModifiers_0 != value)
                {
                    this.keyModifiers_0 = value;
                    this.method_2();
                }
            }
        }

        public object Tag
        {
            get
            {
                return this.object_0;
            }
            set
            {
                this.object_0 = value;
            }
        }

        private class Class60 : NativeWindow
        {
            private DSkinHotKey dskinHotKey_0;
            private static HandleRef handleRef_0 = new HandleRef(null, new IntPtr(-3));

            public Class60(DSkinHotKey dskinHotKey_1)
            {
                this.dskinHotKey_0 = dskinHotKey_1;
            }

            public bool method_0()
            {
                if (base.Handle == IntPtr.Zero)
                {
                    CreateParams cp = new CreateParams {
                        Style = 0,
                        ExStyle = 0,
                        ClassStyle = 0,
                        Caption = base.GetType().Name
                    };
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    {
                        cp.Parent = (IntPtr) handleRef_0;
                    }
                    this.CreateHandle(cp);
                }
                return (base.Handle != IntPtr.Zero);
            }

            protected override void WndProc(ref Message m)
            {
                if ((m.Msg == 0x312) && ((this.dskinHotKey_0.Id != 0) && m.WParam.ToString().Equals(this.dskinHotKey_0.Id.ToString())))
                {
                    this.dskinHotKey_0.OnTriggerHotKey(new HotKeyEventArgs(this.dskinHotKey_0.KeyModifier, this.dskinHotKey_0.Key));
                }
                base.WndProc(ref m);
            }
        }
    }
}

