namespace DSkin.DirectUI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public static class DuiControlExtensions
    {
        public static void DoEffect<T>(this T obj, Func<bool> action)
        {
            obj.DoEffect<T>(15, action);
        }

        public static void DoEffect<T>(this T obj, int frameCount, Action action)
        {
            obj.DoEffect<T>(15, frameCount, action);
        }

        public static void DoEffect<T>(this T obj, int interval, Func<bool> action)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer {
                Interval = interval,
                Enabled = true
            };
            timer.Tick += delegate (object sender, EventArgs e) {
                if (!action.Invoke())
                {
                    timer.Stop();
                    timer.Dispose();
                }
            };
        }

        public static void DoEffect<T>(this T obj, int interval, int frameCount, Action action)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer {
                Interval = interval,
                Enabled = true
            };
            int i = 0;
            timer.Tick += delegate (object sender, EventArgs e) {
                i++;
                if (i >= frameCount)
                {
                    timer.Stop();
                    timer.Dispose();
                }
            };
        }

        public static void DoEffect<T>(this T obj, int from, int to, int timeSpan, string property, Action<bool> action)
        {
            if (from != to)
            {
                if (obj is IEnumerable)
                {
                    foreach (object obj2 in obj as IEnumerable)
                    {
                        obj2.DoEffect<object>(from, to, timeSpan, property, action);
                    }
                }
                else
                {
                    smethod_0<T>(obj, from, to, timeSpan, property, action);
                }
            }
        }

        public static void ForEach<T>(this IEnumerable<T> e, Action<T> action) where T: DuiBaseControl
        {
            foreach (T local in e)
            {
                action(local);
            }
        }

        public static IEnumerable<T> Query<T>(this DuiBaseControl control, Func<T, bool> filter) where T: DuiBaseControl
        {
            IEnumerator<T> iteratorVariable4;
            IEnumerator enumerator = control.Controls.GetEnumerator();
        Label_0068:
            if (!enumerator.MoveNext())
            {
                goto Label_0108;
            }
            DuiBaseControl current = (DuiBaseControl) enumerator.Current;
            if (!(!(current is T) ? true : ((filter == null) ? false : !filter.Invoke(current as T))))
            {
                goto Label_0108;
            }
        Label_00C9:
            iteratorVariable4 = current.Query<T>(filter).GetEnumerator();
            while (iteratorVariable4.MoveNext())
            {
                T iteratorVariable1 = iteratorVariable4.Current;
                yield return iteratorVariable1;
            }
            goto Label_0068;
        Label_0108:
            yield return (current as T);
            goto Label_00C9;
        }

        public static IEnumerable<T> Query<T>(this Control control, Func<T, bool> filter) where T: Control
        {
            IEnumerator<T> iteratorVariable4;
            IEnumerator enumerator = control.Controls.GetEnumerator();
        Label_0068:
            if (!enumerator.MoveNext())
            {
                goto Label_0108;
            }
            Control current = (Control) enumerator.Current;
            if (!(!(current is T) ? true : ((filter == null) ? false : !filter.Invoke(current as T))))
            {
                goto Label_0108;
            }
        Label_00C9:
            iteratorVariable4 = current.Query<T>(filter).GetEnumerator();
            while (iteratorVariable4.MoveNext())
            {
                T iteratorVariable1 = iteratorVariable4.Current;
                yield return iteratorVariable1;
            }
            goto Label_0068;
        Label_0108:
            yield return (current as T);
            goto Label_00C9;
        }

        public static void Sleep(this object obj, int time, Action action)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer {
                Interval = time,
                Enabled = true
            };
            timer.Tick += delegate (object sender, EventArgs e) {
                timer.Enabled = false;
                timer.Dispose();
                action.Invoke();
            };
        }

        private static void smethod_0<uC7j6NWLhSCbqU16jey>(uC7j6NWLhSCbqU16jey QjphwcWQB5QfSfTB2hH, int int_0, int int_1, int int_2, string string_0, Action<bool> action_0)
        {
            Func<bool> func = null;
            uC7j6NWLhSCbqU16jey obj = QjphwcWQB5QfSfTB2hH;
            int to = int_1;
            Action<bool> action = action_0;
            PropertyInfo pi = obj.GetType().GetProperty(string_0);
            double change = (1.0 * (to - int_0)) / ((double) (int_2 / 0x10));
            double now = int_0;
            if (pi == null)
            {
                throw new ApplicationException("未找到该属性");
            }
            pi.SetValue(obj, (int) now, null);
            if (func == null)
            {
                <>c__DisplayClass1e<uC7j6NWLhSCbqU16jey> classe;
                func = new Func<bool>(classe, (IntPtr) this.<Effect>b__1c);
            }
            obj.DoEffect<uC7j6NWLhSCbqU16jey>(func);
        }

        [CompilerGenerated]
        private sealed class <Query>d__0<T> : IEnumerable<T>, IDisposable, IEnumerable, IEnumerator, IEnumerator<T> where T: DuiBaseControl
        {
            public T <_t>5__2;
            private int <>1__state;
            private T <>2__current;
            public DuiBaseControl <>3__control;
            public Func<T, bool> <>3__filter;
            public IEnumerator <>7__wrap3;
            public IDisposable <>7__wrap4;
            public IEnumerator<T> <>7__wrap6;
            private int <>l__initialThreadId;
            public DuiBaseControl <c>5__1;
            public DuiBaseControl control;
            public Func<T, bool> filter;

            [DebuggerHidden]
            public <Query>d__0(int <>1__state)
            {
                this.<>1__state = <>1__state;
                this.<>l__initialThreadId = Thread.CurrentThread.ManagedThreadId;
            }

            private void <>m__Finally5()
            {
                this.<>1__state = -1;
                this.<>7__wrap4 = this.<>7__wrap3 as IDisposable;
                if (this.<>7__wrap4 != null)
                {
                    this.<>7__wrap4.Dispose();
                }
            }

            private void <>m__Finally7()
            {
                this.<>1__state = 1;
                if (this.<>7__wrap6 != null)
                {
                    this.<>7__wrap6.Dispose();
                }
            }

            private bool MoveNext()
            {
                try
                {
                    switch (this.<>1__state)
                    {
                        case 0:
                            this.<>1__state = -1;
                            this.<>7__wrap3 = this.control.Controls.GetEnumerator();
                            this.<>1__state = 1;
                            goto Label_0068;

                        case 2:
                            this.<>1__state = 1;
                            goto Label_00C9;

                        case 4:
                            this.<>1__state = 3;
                            goto Label_00EC;

                        default:
                            goto Label_0104;
                    }
                Label_0062:
                    this.<>m__Finally7();
                Label_0068:
                    if (!this.<>7__wrap3.MoveNext())
                    {
                        goto Label_00FE;
                    }
                    this.<c>5__1 = (DuiBaseControl) this.<>7__wrap3.Current;
                    if (!(!(this.<c>5__1 is T) ? true : ((this.filter == null) ? false : !this.filter.Invoke(this.<c>5__1 as T))))
                    {
                        goto Label_0108;
                    }
                Label_00C9:
                    this.<>7__wrap6 = this.<c>5__1.Query<T>(this.filter).GetEnumerator();
                    this.<>1__state = 3;
                Label_00EC:
                    if (this.<>7__wrap6.MoveNext())
                    {
                        goto Label_0129;
                    }
                    goto Label_0062;
                Label_00FE:
                    this.<>m__Finally5();
                Label_0104:
                    return false;
                Label_0108:
                    this.<>2__current = this.<c>5__1 as T;
                    this.<>1__state = 2;
                    return true;
                Label_0129:
                    this.<_t>5__2 = this.<>7__wrap6.Current;
                    this.<>2__current = this.<_t>5__2;
                    this.<>1__state = 4;
                    return true;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
            }

            [DebuggerHidden]
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                DuiControlExtensions.<Query>d__0<T> d__;
                if ((Thread.CurrentThread.ManagedThreadId == this.<>l__initialThreadId) && (this.<>1__state == -2))
                {
                    this.<>1__state = 0;
                    d__ = (DuiControlExtensions.<Query>d__0<T>) this;
                }
                else
                {
                    d__ = new DuiControlExtensions.<Query>d__0<T>(0);
                }
                d__.control = this.<>3__control;
                d__.filter = this.<>3__filter;
                return d__;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.System.Collections.Generic.IEnumerable<T>.GetEnumerator();
            }

            [DebuggerHidden]
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            void IDisposable.Dispose()
            {
                switch (this.<>1__state)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        try
                        {
                            switch (this.<>1__state)
                            {
                                case 3:
                                case 4:
                                    break;

                                default:
                                    break;
                            }
                            try
                            {
                            }
                            finally
                            {
                                this.<>m__Finally7();
                            }
                        }
                        finally
                        {
                            this.<>m__Finally5();
                        }
                        break;
                }
            }

            T IEnumerator<T>.Current
            {
                [DebuggerHidden]
                get
                {
                    return this.<>2__current;
                }
            }

            object IEnumerator.Current
            {
                [DebuggerHidden]
                get
                {
                    return this.<>2__current;
                }
            }
        }

        [CompilerGenerated]
        private sealed class <Query>d__a<T> : IEnumerable<T>, IDisposable, IEnumerable, IEnumerator, IEnumerator<T> where T: Control
        {
            public T <_t>5__c;
            private int <>1__state;
            private T <>2__current;
            public Control <>3__control;
            public Func<T, bool> <>3__filter;
            public IEnumerator<T> <>7__wrap10;
            public IEnumerator <>7__wrapd;
            public IDisposable <>7__wrape;
            private int <>l__initialThreadId;
            public Control <c>5__b;
            public Control control;
            public Func<T, bool> filter;

            [DebuggerHidden]
            public <Query>d__a(int <>1__state)
            {
                this.<>1__state = <>1__state;
                this.<>l__initialThreadId = Thread.CurrentThread.ManagedThreadId;
            }

            private void <>m__Finally11()
            {
                this.<>1__state = 1;
                if (this.<>7__wrap10 != null)
                {
                    this.<>7__wrap10.Dispose();
                }
            }

            private void <>m__Finallyf()
            {
                this.<>1__state = -1;
                this.<>7__wrape = this.<>7__wrapd as IDisposable;
                if (this.<>7__wrape != null)
                {
                    this.<>7__wrape.Dispose();
                }
            }

            private bool MoveNext()
            {
                try
                {
                    switch (this.<>1__state)
                    {
                        case 0:
                            this.<>1__state = -1;
                            this.<>7__wrapd = this.control.Controls.GetEnumerator();
                            this.<>1__state = 1;
                            goto Label_0068;

                        case 2:
                            this.<>1__state = 1;
                            goto Label_00C9;

                        case 4:
                            this.<>1__state = 3;
                            goto Label_00EC;

                        default:
                            goto Label_0104;
                    }
                Label_0062:
                    this.<>m__Finally11();
                Label_0068:
                    if (!this.<>7__wrapd.MoveNext())
                    {
                        goto Label_00FE;
                    }
                    this.<c>5__b = (Control) this.<>7__wrapd.Current;
                    if (!(!(this.<c>5__b is T) ? true : ((this.filter == null) ? false : !this.filter.Invoke(this.<c>5__b as T))))
                    {
                        goto Label_0108;
                    }
                Label_00C9:
                    this.<>7__wrap10 = this.<c>5__b.Query<T>(this.filter).GetEnumerator();
                    this.<>1__state = 3;
                Label_00EC:
                    if (this.<>7__wrap10.MoveNext())
                    {
                        goto Label_0129;
                    }
                    goto Label_0062;
                Label_00FE:
                    this.<>m__Finallyf();
                Label_0104:
                    return false;
                Label_0108:
                    this.<>2__current = this.<c>5__b as T;
                    this.<>1__state = 2;
                    return true;
                Label_0129:
                    this.<_t>5__c = this.<>7__wrap10.Current;
                    this.<>2__current = this.<_t>5__c;
                    this.<>1__state = 4;
                    return true;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
            }

            [DebuggerHidden]
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                DuiControlExtensions.<Query>d__a<T> _a;
                if ((Thread.CurrentThread.ManagedThreadId == this.<>l__initialThreadId) && (this.<>1__state == -2))
                {
                    this.<>1__state = 0;
                    _a = (DuiControlExtensions.<Query>d__a<T>) this;
                }
                else
                {
                    _a = new DuiControlExtensions.<Query>d__a<T>(0);
                }
                _a.control = this.<>3__control;
                _a.filter = this.<>3__filter;
                return _a;
            }

            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.System.Collections.Generic.IEnumerable<T>.GetEnumerator();
            }

            [DebuggerHidden]
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            void IDisposable.Dispose()
            {
                switch (this.<>1__state)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        try
                        {
                            switch (this.<>1__state)
                            {
                                case 3:
                                case 4:
                                    break;

                                default:
                                    break;
                            }
                            try
                            {
                            }
                            finally
                            {
                                this.<>m__Finally11();
                            }
                        }
                        finally
                        {
                            this.<>m__Finallyf();
                        }
                        break;
                }
            }

            T IEnumerator<T>.Current
            {
                [DebuggerHidden]
                get
                {
                    return this.<>2__current;
                }
            }

            object IEnumerator.Current
            {
                [DebuggerHidden]
                get
                {
                    return this.<>2__current;
                }
            }
        }
    }
}

