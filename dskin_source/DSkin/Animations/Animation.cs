namespace DSkin.Animations
{
    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public class Animation : IDisposable
    {
        private bool bool_0;
        private EventHandler eventHandler_4;
        private IEffects ieffects_0;
        private int int_0;
        private System.Windows.Forms.Timer timer_0;

        public event EventHandler<AnimationEventArgs> AnimationEnd;

        public event EventHandler AnimationStart;

        public event EventHandler<AnimationEventArgs> AnimationStarted;

        public event EventHandler<AnimationEventArgs> FrameChanged;

        public Animation()
        {
            this.timer_0 = new System.Windows.Forms.Timer();
            this.bool_0 = true;
            this.int_0 = 0;
            this.timer_0.Interval = 12;
            this.timer_0.Tick += new EventHandler(this.vmkkYdcjq);
        }

        public Animation(IEffects effect) : this()
        {
            this.ieffects_0 = effect;
        }

        public void Dispose()
        {
            if (this.timer_0 != null)
            {
                this.timer_0.Dispose();
                this.timer_0 = null;
            }
            if (this.ieffects_0 != null)
            {
                this.ieffects_0.Dispose();
                this.ieffects_0 = null;
            }
            GC.SuppressFinalize(this);
        }

        internal void method_0(EventHandler value)
        {
            EventHandler handler2;
            EventHandler handler = this.eventHandler_4;
            do
            {
                handler2 = handler;
                EventHandler handler3 = (EventHandler) Delegate.Combine(handler2, value);
                handler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_4, handler3, handler2);
            }
            while (handler != handler2);
        }

        internal void method_1(EventHandler value)
        {
            EventHandler handler2;
            EventHandler handler = this.eventHandler_4;
            do
            {
                handler2 = handler;
                EventHandler handler3 = (EventHandler) Delegate.Remove(handler2, value);
                handler = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_4, handler3, handler2);
            }
            while (handler != handler2);
        }

        protected virtual void OnAnimationEnd(AnimationEventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        protected virtual void OnAnimationEnded(EventArgs e)
        {
            if (this.eventHandler_4 != null)
            {
                this.eventHandler_4(this, e);
            }
        }

        protected virtual void OnAnimationStart(EventArgs e)
        {
            if (this.eventHandler_3 != null)
            {
                this.eventHandler_3(this, e);
            }
        }

        protected virtual void OnAnimationStarted(AnimationEventArgs e)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, e);
            }
        }

        protected virtual void OnFrameChanged(AnimationEventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        public void Start()
        {
            if (this.ieffects_0 != null)
            {
                this.OnAnimationStart(EventArgs.Empty);
                this.ieffects_0.Reset();
                this.int_0 = 0;
                this.timer_0.Start();
            }
        }

        public void Stop()
        {
            this.timer_0.Stop();
        }

        private void vmkkYdcjq(object sender, EventArgs e)
        {
            if (this.Original == null)
            {
                this.timer_0.Stop();
            }
            else
            {
                Point point;
                AnimationEventArgs args = new AnimationEventArgs(this.ieffects_0.DoEffect(out point), this.int_0, false, point);
                if (this.ieffects_0.IsFinal)
                {
                    args.IsFinal = true;
                }
                this.OnFrameChanged(args);
                if (this.int_0 == 0)
                {
                    this.OnAnimationStarted(args);
                }
                if (this.ieffects_0.IsFinal)
                {
                    this.timer_0.Stop();
                    this.OnAnimationEnd(args);
                    this.OnAnimationEnded(args);
                }
                this.int_0++;
            }
        }

        public bool Asc
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                if (((this.bool_0 != value) && (this.ieffects_0 != null)) && this.ieffects_0.CanDesc)
                {
                    this.bool_0 = value;
                    this.ieffects_0.IsAsc = this.bool_0;
                }
            }
        }

        public IEffects Effect
        {
            get
            {
                return this.ieffects_0;
            }
            set
            {
                if (this.ieffects_0 != value)
                {
                    this.ieffects_0 = value;
                }
            }
        }

        public int Interval
        {
            get
            {
                return this.timer_0.Interval;
            }
            set
            {
                this.timer_0.Interval = value;
            }
        }

        public Bitmap Original
        {
            get
            {
                if (this.ieffects_0 != null)
                {
                    return this.ieffects_0.Original;
                }
                return null;
            }
            set
            {
                if (this.ieffects_0 != null)
                {
                    this.ieffects_0.Original = value;
                }
            }
        }
    }
}

