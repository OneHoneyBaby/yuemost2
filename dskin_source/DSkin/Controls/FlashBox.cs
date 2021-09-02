namespace DSkin.Controls
{
    using DSkin;
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    public class FlashBox : AxHost, ILayered, IDuiContainer
    {
        private Bitmap bitmap_0;
        private bool bool_0;
        private bool bool_1;
        private bool bool_2;
        private DuiBaseControl duiBaseControl_0;
        private IntPtr intptr_0;
        private IShockwaveFlash ishockwaveFlash_0;

        [Description("层控件需要重绘时发生")]
        public event EventHandler<PaintEventArgs> LayeredPaintEvent;

        public FlashBox() : base("d27cdb6e-ae6d-11cf-96b8-444553540000")
        {
            this.bool_0 = true;
            this.intptr_0 = IntPtr.Zero;
            this.bool_1 = false;
            this.bool_2 = false;
            base.Width = 100;
            base.Height = 100;
            this.InnerDuiControl.Parent = this;
            this.InnerDuiControl.PrePaint += new EventHandler<PaintEventArgs>(this.method_1);
            this.InnerDuiControl.SizeChanged += new EventHandler(this.method_0);
            this.InnerDuiControl.BitmapCache = true;
        }

        public void Back()
        {
            this.ishockwaveFlash_0.Back();
        }

        public virtual string CallFunction(string request)
        {
            return this.ishockwaveFlash_0.CallFunction(request);
        }

        public virtual int CurrentFrame()
        {
            return this.ishockwaveFlash_0.CurrentFrame();
        }

        public virtual void DisableLocalSecurity()
        {
            this.ishockwaveFlash_0.DisableLocalSecurity();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.intptr_0 != IntPtr.Zero)
            {
                Marshal.Release(this.intptr_0);
            }
            this.InnerDuiControl.Dispose();
            if (this.bitmap_0 != null)
            {
                this.bitmap_0.Dispose();
            }
            base.Dispose(disposing);
        }

        public virtual void DisposeCanvas()
        {
            this.InnerDuiControl.DisposeCanvas();
        }

        public virtual void EnforceLocalSecurity()
        {
            this.ishockwaveFlash_0.EnforceLocalSecurity();
        }

        public virtual int FlashVersion()
        {
            return this.ishockwaveFlash_0.FlashVersion();
        }

        public void Forward()
        {
            this.ishockwaveFlash_0.Forward();
        }

        public virtual bool FrameLoaded(int frameNum)
        {
            return this.ishockwaveFlash_0.FrameLoaded(frameNum);
        }

        public virtual string GetVariable(string name)
        {
            return this.ishockwaveFlash_0.GetVariable(name);
        }

        public void GotoFrame(int FrameNum)
        {
            this.ishockwaveFlash_0.GotoFrame(FrameNum);
        }

        public void Invalidate()
        {
            this.InnerDuiControl.Invalidate();
        }

        public void Invalidate(Rectangle rect)
        {
            this.InnerDuiControl.Invalidate(rect);
        }

        public virtual bool IsPlaying()
        {
            return this.ishockwaveFlash_0.IsPlaying();
        }

        public void LoadMovie(int layer, string url)
        {
            this.ishockwaveFlash_0.LoadMovie(layer, url);
        }

        private void mbAlclsgDj(Graphics graphics_0, Rectangle rectangle_0)
        {
            IntPtr hdc = graphics_0.GetHdc();
            DSkin.NativeMethods.OleDraw(this.intptr_0, 1, hdc, ref rectangle_0);
            graphics_0.ReleaseHdc(hdc);
        }

        private void method_0(object sender, EventArgs e)
        {
            base.Size = this.InnerDuiControl.Size;
        }

        private unsafe void method_1(object sender, PaintEventArgs e)
        {
            if (((this.intptr_0 != IntPtr.Zero) && !base.DesignMode) && base.Created)
            {
                if (this.bool_1)
                {
                    this.BackgroundColor = 0;
                }
                this.mbAlclsgDj(e.Graphics, e.ClipRectangle);
                if (this.bool_1)
                {
                    if ((this.bitmap_0 == null) || this.bool_0)
                    {
                        this.bool_0 = false;
                        if (this.bitmap_0 != null)
                        {
                            this.bitmap_0.Dispose();
                        }
                        this.bitmap_0 = new Bitmap(base.Width, base.Height);
                    }
                    using (Graphics graphics = Graphics.FromImage(this.bitmap_0))
                    {
                        this.BackgroundColor = -1;
                        this.mbAlclsgDj(graphics, e.ClipRectangle);
                    }
                    BitmapData bitmapdata = this.bitmap_0.LockBits(new Rectangle(0, 0, base.Width, base.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                    BitmapData data2 = this.InnerDuiControl.bitmap_0.LockBits(new Rectangle(0, 0, base.Width, base.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                    byte* numPtr = (byte*) bitmapdata.Scan0;
                    byte* numPtr2 = (byte*) data2.Scan0;
                    int num6 = bitmapdata.Stride - (base.Width * 4);
                    for (int i = 0; i < base.Height; i++)
                    {
                        for (int j = 0; j < base.Width; j++)
                        {
                            int num2 = numPtr[2] - numPtr2[2];
                            int num3 = numPtr[1] - numPtr2[1];
                            int num4 = numPtr[0] - numPtr2[0];
                            int num5 = ((num2 + num3) + num4) / 3;
                            numPtr2[3] = (byte) (0xff - num5);
                            numPtr2 += 4;
                            numPtr += 4;
                        }
                        numPtr += num6;
                        numPtr2 += num6;
                    }
                    this.bitmap_0.UnlockBits(bitmapdata);
                    this.InnerDuiControl.bitmap_0.UnlockBits(data2);
                }
            }
            this.OnLayeredPaint(e);
        }

        [CompilerGenerated]
        private void method_2(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.ishockwaveFlash_0 = (IShockwaveFlash) base.GetOcx();
            if (!base.DesignMode && this.IsLayeredMode)
            {
                IntPtr iUnknownForObject = Marshal.GetIUnknownForObject(base.GetOcx());
                Marshal.QueryInterface(iUnknownForObject, ref DSkin.NativeMethods.IID_IViewObject, out this.intptr_0);
                Marshal.Release(iUnknownForObject);
                System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer {
                    Enabled = true,
                    Interval = 0x19
                };
                timer2.Tick += new EventHandler(this.method_2);
            }
        }

        protected virtual void OnLayeredPaint(PaintEventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.bool_0 = true;
            this.InnerDuiControl.Size = base.Size;
            base.OnSizeChanged(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            this.Invalidate();
        }

        public void PaintControl(Graphics g, Rectangle invalidateRect)
        {
            this.InnerDuiControl.PaintControl(g, invalidateRect);
        }

        public void Pan(int x, int y, int mode)
        {
            this.ishockwaveFlash_0.Pan(x, y, mode);
        }

        public virtual int PercentLoaded()
        {
            return this.ishockwaveFlash_0.PercentLoaded();
        }

        public void Play()
        {
            this.ishockwaveFlash_0.Play();
        }

        public virtual void Rewind()
        {
            this.ishockwaveFlash_0.Rewind();
        }

        public virtual void SetReturnValue(string returnValue)
        {
            this.ishockwaveFlash_0.SetReturnValue(returnValue);
        }

        public virtual void SetVariable(string name, string value)
        {
            this.ishockwaveFlash_0.SetVariable(name, value);
        }

        public virtual void SetZoomRect(int left, int top, int right, int bottom)
        {
            this.ishockwaveFlash_0.SetZoomRect(left, top, right, bottom);
        }

        public virtual void Stop()
        {
            this.ishockwaveFlash_0.Stop();
        }

        public virtual void StopPlay()
        {
            this.ishockwaveFlash_0.StopPlay();
        }

        public virtual int TCurrentFrame(string target)
        {
            return this.ishockwaveFlash_0.TCurrentFrame(target);
        }

        public virtual string TCurrentLabel(string target)
        {
            return this.ishockwaveFlash_0.TCurrentLabel(target);
        }

        public virtual string TGetProperty(string target, int property)
        {
            return this.ishockwaveFlash_0.TGetProperty(target, property);
        }

        public virtual double TGetPropertyAsNumber(string target, int property)
        {
            return this.ishockwaveFlash_0.TGetPropertyAsNumber(target, property);
        }

        public virtual double TGetPropertyNum(string target, int property)
        {
            return this.ishockwaveFlash_0.TGetPropertyNum(target, property);
        }

        public virtual void TPlay(string target)
        {
            this.ishockwaveFlash_0.TPlay(target);
        }

        public virtual void TSetProperty(string target, int property, string value)
        {
            this.ishockwaveFlash_0.TSetProperty(target, property, value);
        }

        public virtual void TSetPropertyNum(string target, int property, double value)
        {
            this.ishockwaveFlash_0.TSetPropertyNum(target, property, value);
        }

        public virtual void vmethod_0(string target, int frameNum)
        {
            this.ishockwaveFlash_0.imethod_0(target, frameNum);
        }

        public virtual void vmethod_1(string target, string label)
        {
            this.ishockwaveFlash_0.imethod_1(target, label);
        }

        public virtual void vmethod_2(string target)
        {
            this.ishockwaveFlash_0.imethod_2(target);
        }

        public virtual void vmethod_3(string target, int frameNum)
        {
            this.ishockwaveFlash_0.imethod_3(target, frameNum);
        }

        public virtual void vmethod_4(string target, string label)
        {
            this.ishockwaveFlash_0.imethod_4(target, label);
        }

        protected override void WndProc(ref Message m)
        {
            if ((m.Msg != 0x204) || this.Menu)
            {
                base.WndProc(ref m);
            }
        }

        public virtual void Zoom(int factor)
        {
            this.ishockwaveFlash_0.Zoom(factor);
        }

        [DispId(0x79), Description("对齐方式,（与 SAlign 属性联动）1：左对齐(0001)　　2：右对齐(0010)　　4：顶对齐(0100)　　8：底对齐(1000) "), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int AlignMode
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.AlignMode;
                }
                return 0;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.AlignMode = value;
                }
            }
        }

        [DispId(0xca), Description("允许全屏"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string AllowFullScreen
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.AllowFullScreen;
                }
                return null;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.AllowFullScreen = value;
                }
            }
        }

        [DispId(0xc9), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("\"all\"（默认值）― SWF 文件中允许使用所有网络 API。 \"internal\"― SWF 文件可能不调用浏览器导航或浏览器交互 API，但是它会调用任何其它网络 API。 \"none\"― SWF 文件可能不调用浏览器导航或浏览器交互 API，并且它无法使用任何 SWF 到 SWF 通信 API。 可以控制 SWF 文件对网络功能的访问。调用被禁止的 API 会引发 SecurityError 异常。 ")]
        public virtual string AllowNetworking
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.AllowNetworking;
                }
                return null;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.AllowNetworking = value;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(0xab), Description("sameDomain：仅当 SWF 文件和网页位于同一域中时才允许执行外出脚本访问。这是 AVM2 内容的默认值。 never：外出脚本访问将始终失败。 always：外出脚本访问将始终成功。 AllowScriptAccess 参数可以防止从一个域中承载的 SWF 文件访问来自另一个域的 HTML 页面中的脚本。 对从另一个域承载的所有 SWF 文件使用 AllowScriptAccess=\"never\" 可以确保位于 HTML 页面中的脚本的安全性。")]
        public virtual string AllowScriptAccess
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.AllowScriptAccess;
                }
                return null;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.AllowScriptAccess = value;
                }
            }
        }

        [Description("影片的背景色（与 BGColor 联动）。以（红\x00d7 65536 ＋绿\x00d7 256 ＋蓝）计算颜色值。红绿蓝颜色取 值范围（0-255 ）。默认的影片背景色为 -1 。如果影片 设置了底色或有图片当作背景，那么看不出来该属性值的 改变会有什么影响 。例子：将影片背景色设为蓝色 ：movie.BackgroundColor = 255")]
        public virtual int BackgroundColor
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.BackgroundColor;
                }
                return -1;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.BackgroundColor = value;
                }
            }
        }

        [Description("指定用于解决影片中所有相对路径的声明的基 地址。当影片与其需要的其他文件不在同一目录中的时候该 属性特别有用。如不特别指定，Base 的值默认为 \".\"，也就 是当前影片所在的路径。例子 ：movie.Base = \"Http://www.dskin.net/pathname1/pathname2\"")]
        public string Base
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.Base;
                }
                return null;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.Base = value;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool BitmapCache
        {
            get
            {
                return this.InnerDuiControl.BitmapCache;
            }
            set
            {
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual Bitmap Canvas
        {
            get
            {
                return this.InnerDuiControl.Canvas;
            }
            set
            {
                this.InnerDuiControl.Canvas = value;
            }
        }

        [Description("缩放模式（与 ScaleMode 联动）。Scale 可以 取:ShowAll ——在控件内显示全部影片区域，保持影片 长宽比例不变，影片的大小决定于控件长或宽中较小的一 边 。NoBorder ——在控件内显示部分影片区域，保持影片 长宽比例不变，影片的大小决定于控件长或宽中较大的一 边 。ExactFit ——在控件内显示全部影片区域，将影片的长 宽比例强制等于控件的长宽比例")]
        public string CtlScale
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.Scale;
                }
                return null;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.Scale = value;
                }
            }
        }

        [Description("决定是否使用影片内嵌的字体 ，将该属性值设为 True 则强制播放器不使用影片中 内嵌的字体而使用本地系统字体。")]
        public bool DeviceFont
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.DeviceFont;
                }
                return true;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.DeviceFont = value;
                }
            }
        }

        protected virtual DuiBaseControl DuiControl
        {
            get
            {
                return new DuiBaseControl();
            }
        }

        [Description("影片是否被存贮到控件所在的容器中。当你已载入一个影片后将该属性设为 True ，播放影片时就不必再去读 SWF 文件了。这使得在 Powerpoint 简报或 VB 程序 里使用 Flash 影片更容易。但将该属性设为 True 后，控 件的 Movie 属性就不再接受新的值了。要想播放另一个影 片（给 Movie 属性赋新值），必须先将 EmbedMovie 属 性设为 False 。")]
        public bool EmbedMovie
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.EmbedMovie;
                }
                return true;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.EmbedMovie = value;
                }
            }
        }

        [DefaultValue(false), Category("DSkin"), Description("启用透明Flash播放，注意会影响性能，透明效果需要在Layered模式下才能生效")]
        public bool EnableTransparent
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
            }
        }

        [Description("Flash参数")]
        public string FlashVars
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.FlashVars;
                }
                return "";
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.FlashVars = value;
                }
            }
        }

        [Description("影片当前帧的编号 （从 0 开始计数 ）。设置 该属性值将使影片停在由 FrameNum 指定的帧处。")]
        public int FrameNum
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.FrameNum;
                }
                return 0;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.FrameNum = value;
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImageAttributes ImageAttribute
        {
            get
            {
                return this.InnerDuiControl.ImageAttribute;
            }
            set
            {
                this.InnerDuiControl.ImageAttribute = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public IImageEffect ImageEffect
        {
            get
            {
                return this.InnerDuiControl.ImageEffect;
            }
            set
            {
                this.InnerDuiControl.ImageEffect = value;
            }
        }

        [Description("内部数据"), Browsable(false)]
        public object InlineData
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.InlineData;
                }
                return null;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.InlineData = value;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public DuiBaseControl InnerDuiControl
        {
            get
            {
                if (this.duiBaseControl_0 == null)
                {
                    this.duiBaseControl_0 = this.DuiControl;
                }
                return this.duiBaseControl_0;
            }
        }

        [Browsable(false)]
        public bool IsLayeredMode
        {
            get
            {
                return DSkinBaseControl.ControlLayeredMode(this);
            }
        }

        [Description("是否循环播放。设为 True 是循环播放，设为 False 则只播放一次。")]
        public bool Loop
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.Loop;
                }
                return true;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.Loop = value;
                }
            }
        }

        [Description("是否显示菜单。设为 True 显示所有菜单，设为 False 菜单被屏蔽")]
        public virtual bool Menu
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                this.bool_2 = value;
            }
        }

        [Description("要播放的影片路径（URL ）。设置该属性为 一个 SWF 文件的 URL 将载入文件并播放它。若影片是在 本地硬盘上，要写成从盘符开始的绝对路径；若影片是在 某网站上，也要写全 URL 地址。")]
        public virtual string Movie
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.Movie;
                }
                return "";
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.Movie = value;
                }
            }
        }

        public string MovieData
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.MovieData;
                }
                return "";
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.MovieData = value;
                }
            }
        }

        [Description("当前播放状态。如果影片正在播放，该属性 值为 True ，否则为 False ")]
        public bool Playing
        {
            get
            {
                return ((this.ishockwaveFlash_0 != null) && this.ishockwaveFlash_0.Playing);
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.Playing = value;
                }
            }
        }

        public bool Profile
        {
            get
            {
                return ((this.ishockwaveFlash_0 != null) && this.ishockwaveFlash_0.Profile);
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.Profile = value;
                }
            }
        }

        public string ProfileAddress
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.ProfileAddress;
                }
                return "";
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.ProfileAddress = value;
                }
            }
        }

        public int ProfilePort
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.ProfilePort;
                }
                return 0;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.ProfilePort = value;
                }
            }
        }

        [Description("画面质量（与 Quality2 联动）。Quality 可 以取:0 ——相当于 Quality2 取 \"Low\"1 ——相当于 Quality2 取 \"High\"2 ——相当于 Quality2 取 \"AutoLow\"3 ——相当于 Quality2 取 \"AutoHigh\" ")]
        public int Quality
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.Quality;
                }
                return 1;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.Quality = value;
                }
            }
        }

        [Description("画面质量(与 Quality 联动)。Quality2 可以取: Low ：偏重于播放速度而不管显示效果，而且不启用消锯齿功能 。High ：偏重于画面而不管播放速度，并且总是启用 消锯齿功能。如果影片中不包含动画就平滑处理位图；如 果有动画，那么位图就不被平滑处理。（这里的动画应该 是把一张图片做平移或旋转）AutoLow ：先着重于播放速度，但只要有可能就改 善显示效果。一开始播放时先禁用消锯齿功能。如果播放 器检测到处理器能承受得了 ，就启用消锯齿功能 。AutoHigh：一开始是播放速度和显示效果并重，但 如有必要就牺牲画质确保速度。开始播放时就启用消锯齿 功能。但如果实际的帧速率比设计时指定的速率慢了，就 禁用消锯齿功能来提高播放速度。")]
        public string Quality2
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.Quality2;
                }
                return null;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.Quality2 = value;
                }
            }
        }

        [Description("影片的当前状态。ReadyState 可以取：0 ——正在载入1 ——未初始化2 ——已载入3 ——正在交互4 ——完成")]
        public int ReadyState
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.ReadyState;
                }
                return 4;
            }
        }

        [Description("对齐模式（与 AlignMode 联动）。当 AlignMode代表各对齐模式的位被置“1”时，SAlign 值也相应被设为“L”（Left）、“T”（Top）、“R”（Right）、“B”（Bottom）各 字符的组合。（‘L’、‘T’、‘R’、‘B’的先后顺序不变）")]
        public string SAlign
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.SAlign;
                }
                return null;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.SAlign = value;
                }
            }
        }

        [Description("缩放模式(与 Scale 联动)。ScaleMode 可以取：0 ——相当于 Scale 取 \"ShowAll\"1 ——相当于 Scale 取 \"NoBorder\"2 ——相当于 Scale 取 \"ExactFit\"")]
        public int ScaleMode
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.ScaleMode;
                }
                return 0;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.ScaleMode = value;
                }
            }
        }

        public bool SeamlessTabbing
        {
            get
            {
                return ((this.ishockwaveFlash_0 != null) && this.ishockwaveFlash_0.SeamlessTabbing);
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.SeamlessTabbing = value;
                }
            }
        }

        public string SWRemote
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.SWRemote;
                }
                return "";
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.SWRemote = value;
                }
            }
        }

        [Browsable(false)]
        public int TotalFrames
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.TotalFrames;
                }
                return 0;
            }
        }

        [Description("控件的窗口模式。WMode 可以取： Window —— WMode 属性的默认值，按 Flash 播放器典型的方式工作，即在控件的矩形窗口中播放影片，这样一 般都能提供最快的动画效果。Opaque ——使影片不透明。 Transparent ——创建一个透明的影片。如果影片中有透明的片段，放到这里时，就可以看到控件下面的背景。但 使用此属性值，动画的播放速度可能会慢一些。")]
        public string WMode
        {
            get
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    return this.ishockwaveFlash_0.WMode;
                }
                return null;
            }
            set
            {
                if (this.ishockwaveFlash_0 != null)
                {
                    this.ishockwaveFlash_0.WMode = value;
                }
            }
        }
    }
}

