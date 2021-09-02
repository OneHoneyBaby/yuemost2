namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [Description("Flash播放控件，在Layered模式下可以支持透明播放")]
    public class DSkinFlashBox : DSkinPanel
    {
        private bool bool_0 = false;
        private bool bool_1 = true;
        private bool bool_2 = true;
        private bool bool_3 = true;
        private bool bool_4 = false;
        private bool bool_5 = false;
        private FlashBox flashBox_0;
        private int int_0 = 0;
        private int int_1 = -1;
        private int int_2 = 0;
        private int int_3 = 1;
        private int int_4 = 0;
        private string string_0 = null;
        private string string_1 = null;
        private string string_2 = null;
        private string string_3 = null;
        private string string_4 = null;
        private string string_5 = "";
        private string string_6 = "";
        private string string_7 = null;
        private string string_8 = null;
        private string string_9 = null;

        public void Back()
        {
            this.flashBox_0.Back();
        }

        public virtual string CallFunction(string request)
        {
            return this.flashBox_0.CallFunction(request);
        }

        protected override void CreateHandle()
        {
            EventHandler handler = null;
            base.CreateHandle();
            if (!base.DesignMode)
            {
                this.flashBox_0 = new FlashBox();
                this.flashBox_0.Dock = DockStyle.Fill;
                if (handler == null)
                {
                    handler = new EventHandler(this.method_6);
                }
                this.flashBox_0.HandleCreated += handler;
                base.Controls.Add(this.flashBox_0);
                this.flashBox_0.SendToBack();
            }
        }

        public virtual int CurrentFrame()
        {
            return this.flashBox_0.CurrentFrame();
        }

        public virtual void DisableLocalSecurity()
        {
            this.flashBox_0.DisableLocalSecurity();
        }

        public virtual void EnforceLocalSecurity()
        {
            this.flashBox_0.EnforceLocalSecurity();
        }

        public virtual int FlashVersion()
        {
            return this.flashBox_0.FlashVersion();
        }

        public void Forward()
        {
            this.flashBox_0.Forward();
        }

        public virtual bool FrameLoaded(int frameNum)
        {
            return this.flashBox_0.FrameLoaded(frameNum);
        }

        public virtual string GetVariable(string name)
        {
            return this.flashBox_0.GetVariable(name);
        }

        public void GotoFrame(int FrameNum)
        {
            this.flashBox_0.GotoFrame(FrameNum);
        }

        public virtual bool IsPlaying()
        {
            return this.flashBox_0.IsPlaying();
        }

        public void LoadMovie(int layer, string url)
        {
            this.flashBox_0.LoadMovie(layer, url);
        }

        [CompilerGenerated]
        private void method_6(object sender, EventArgs e)
        {
            this.flashBox_0.AlignMode = this.int_0;
            this.flashBox_0.AllowFullScreen = this.string_0;
            this.flashBox_0.AllowNetworking = this.string_1;
            this.flashBox_0.AllowScriptAccess = this.string_2;
            this.flashBox_0.BackgroundColor = this.int_1;
            this.flashBox_0.Base = this.string_3;
            this.flashBox_0.CtlScale = this.string_4;
            this.flashBox_0.DeviceFont = this.bool_1;
            this.flashBox_0.EmbedMovie = this.bool_2;
            this.flashBox_0.EnableTransparent = this.bool_0;
            this.flashBox_0.FlashVars = this.string_5;
            this.flashBox_0.FrameNum = this.int_2;
            this.flashBox_0.Loop = this.bool_3;
            this.flashBox_0.Menu = this.bool_4;
            this.flashBox_0.Movie = this.string_6;
            this.flashBox_0.Playing = this.bool_5;
            this.flashBox_0.Quality = this.int_3;
            this.flashBox_0.Quality2 = this.string_7;
            this.flashBox_0.SAlign = this.string_8;
            this.flashBox_0.ScaleMode = this.int_4;
            this.flashBox_0.WMode = this.string_9;
        }

        public void Pan(int x, int y, int mode)
        {
            this.flashBox_0.Pan(x, y, mode);
        }

        public virtual int PercentLoaded()
        {
            return this.flashBox_0.PercentLoaded();
        }

        public void Play()
        {
            this.flashBox_0.Play();
        }

        public virtual void Rewind()
        {
            this.flashBox_0.Rewind();
        }

        public virtual void SetReturnValue(string returnValue)
        {
            this.flashBox_0.SetReturnValue(returnValue);
        }

        public virtual void SetVariable(string name, string value)
        {
            this.flashBox_0.SetVariable(name, value);
        }

        public virtual void SetZoomRect(int left, int top, int right, int bottom)
        {
            this.flashBox_0.SetZoomRect(left, top, right, bottom);
        }

        public virtual void Stop()
        {
            this.flashBox_0.Stop();
        }

        public virtual void StopPlay()
        {
            this.flashBox_0.StopPlay();
        }

        public virtual int TCurrentFrame(string target)
        {
            return this.flashBox_0.TCurrentFrame(target);
        }

        public virtual string TCurrentLabel(string target)
        {
            return this.flashBox_0.TCurrentLabel(target);
        }

        public virtual string TGetProperty(string target, int property)
        {
            return this.flashBox_0.TGetProperty(target, property);
        }

        public virtual double TGetPropertyAsNumber(string target, int property)
        {
            return this.flashBox_0.TGetPropertyAsNumber(target, property);
        }

        public virtual double TGetPropertyNum(string target, int property)
        {
            return this.flashBox_0.TGetPropertyNum(target, property);
        }

        public virtual void TPlay(string target)
        {
            this.flashBox_0.TPlay(target);
        }

        public virtual void TSetProperty(string target, int property, string value)
        {
            this.flashBox_0.TSetProperty(target, property, value);
        }

        public virtual void TSetPropertyNum(string target, int property, double value)
        {
            this.flashBox_0.TSetPropertyNum(target, property, value);
        }

        public virtual void vmethod_0(string target, int frameNum)
        {
            this.flashBox_0.vmethod_0(target, frameNum);
        }

        public virtual void vmethod_1(string target, string label)
        {
            this.flashBox_0.vmethod_1(target, label);
        }

        public virtual void vmethod_2(string target)
        {
            this.flashBox_0.vmethod_2(target);
        }

        public virtual void vmethod_3(string target, int frameNum)
        {
            this.flashBox_0.vmethod_3(target, frameNum);
        }

        public virtual void vmethod_4(string target, string label)
        {
            this.flashBox_0.vmethod_4(target, label);
        }

        public virtual void Zoom(int factor)
        {
            this.flashBox_0.Zoom(factor);
        }

        [Description("对齐方式,（与 SAlign 属性联动）1：左对齐(0001)　　2：右对齐(0010)　　4：顶对齐(0100)　　8：底对齐(1000) "), Category("Flash"), DefaultValue(0)]
        public virtual int AlignMode
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.AlignMode;
                }
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.AlignMode = value;
                }
            }
        }

        [Description("允许全屏"), Category("Flash"), DefaultValue((string) null)]
        public virtual string AllowFullScreen
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.AllowFullScreen;
                }
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.AllowFullScreen = value;
                }
            }
        }

        [DefaultValue((string) null), Category("Flash"), Description("\"all\"（默认值）― SWF 文件中允许使用所有网络 API。 \"internal\"― SWF 文件可能不调用浏览器导航或浏览器交互 API，但是它会调用任何其它网络 API。 \"none\"― SWF 文件可能不调用浏览器导航或浏览器交互 API，并且它无法使用任何 SWF 到 SWF 通信 API。 可以控制 SWF 文件对网络功能的访问。调用被禁止的 API 会引发 SecurityError 异常。 ")]
        public virtual string AllowNetworking
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.AllowNetworking;
                }
                return this.string_1;
            }
            set
            {
                this.string_1 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.AllowNetworking = value;
                }
            }
        }

        [DefaultValue((string) null), Category("Flash"), Description("sameDomain：仅当 SWF 文件和网页位于同一域中时才允许执行外出脚本访问。这是 AVM2 内容的默认值。 never：外出脚本访问将始终失败。 always：外出脚本访问将始终成功。 AllowScriptAccess 参数可以防止从一个域中承载的 SWF 文件访问来自另一个域的 HTML 页面中的脚本。 对从另一个域承载的所有 SWF 文件使用 AllowScriptAccess=\"never\" 可以确保位于 HTML 页面中的脚本的安全性。")]
        public virtual string AllowScriptAccess
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.AllowScriptAccess;
                }
                return this.string_2;
            }
            set
            {
                this.string_2 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.AllowScriptAccess = value;
                }
            }
        }

        [Category("Flash"), DefaultValue(-1), Description("影片的背景色（与 BGColor 联动）。以（红\x00d7 65536 ＋绿\x00d7 256 ＋蓝）计算颜色值。红绿蓝颜色取 值范围（0-255 ）。默认的影片背景色为 -1 。如果影片 设置了底色或有图片当作背景，那么看不出来该属性值的 改变会有什么影响 。例子：将影片背景色设为蓝色 ：movie.BackgroundColor = 255")]
        public virtual int BackgroundColor
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.BackgroundColor;
                }
                return this.int_1;
            }
            set
            {
                this.int_1 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.BackgroundColor = value;
                }
            }
        }

        [Category("Flash"), DefaultValue((string) null), Description("指定用于解决影片中所有相对路径的声明的基 地址。当影片与其需要的其他文件不在同一目录中的时候该 属性特别有用。如不特别指定，Base 的值默认为 \".\"，也就 是当前影片所在的路径。例子 ：movie.Base = \"Http://www.dskin.net/pathname1/pathname2\"")]
        public string Base
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.Base;
                }
                return this.string_3;
            }
            set
            {
                this.string_3 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.Base = value;
                }
            }
        }

        [Description("缩放模式（与 ScaleMode 联动）。Scale 可以 取:ShowAll ——在控件内显示全部影片区域，保持影片 长宽比例不变，影片的大小决定于控件长或宽中较小的一 边 。NoBorder ——在控件内显示部分影片区域，保持影片 长宽比例不变，影片的大小决定于控件长或宽中较大的一 边 。ExactFit ——在控件内显示全部影片区域，将影片的长 宽比例强制等于控件的长宽比例"), DefaultValue((string) null), Category("Flash")]
        public string CtlScale
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.CtlScale;
                }
                return this.string_4;
            }
            set
            {
                this.string_4 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.CtlScale = value;
                }
            }
        }

        [Category("Flash"), DefaultValue(true), Description("决定是否使用影片内嵌的字体 ，将该属性值设为 True 则强制播放器不使用影片中 内嵌的字体而使用本地系统字体。")]
        public bool DeviceFont
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.DeviceFont;
                }
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.DeviceFont = value;
                }
            }
        }

        [Description("影片是否被存贮到控件所在的容器中。当你已载入一个影片后将该属性设为 True ，播放影片时就不必再去读 SWF 文件了。这使得在 Powerpoint 简报或 VB 程序 里使用 Flash 影片更容易。但将该属性设为 True 后，控 件的 Movie 属性就不再接受新的值了。要想播放另一个影 片（给 Movie 属性赋新值），必须先将 EmbedMovie 属 性设为 False 。"), Category("Flash"), DefaultValue(true)]
        public bool EmbedMovie
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.EmbedMovie;
                }
                return this.bool_2;
            }
            set
            {
                this.bool_2 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.EmbedMovie = value;
                }
            }
        }

        [DefaultValue(false), Category("DSkin"), Description("启用透明Flash播放，注意会影响性能，透明效果需要在Layered模式下才能生效")]
        public bool EnableTransparent
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        [Category("Flash"), DefaultValue(""), Description("Flash参数")]
        public string FlashVars
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.FlashVars;
                }
                return this.string_5;
            }
            set
            {
                this.string_5 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.FlashVars = value;
                }
            }
        }

        [Category("Flash"), DefaultValue(0), Description("影片当前帧的编号 （从 0 开始计数 ）。设置 该属性值将使影片停在由 FrameNum 指定的帧处。")]
        public int FrameNum
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.FrameNum;
                }
                return this.int_2;
            }
            set
            {
                this.int_2 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.FrameNum = value;
                }
            }
        }

        [Category("Flash"), DefaultValue(true), Description("是否循环播放。设为 True 是循环播放，设为 False 则只播放一次。")]
        public bool Loop
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.Loop;
                }
                return this.bool_3;
            }
            set
            {
                this.bool_3 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.Loop = value;
                }
            }
        }

        [DefaultValue(false), Description("是否显示菜单。设为 True 显示所有菜单，设为 False 菜单被屏蔽"), Category("Flash")]
        public virtual bool Menu
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.Menu;
                }
                return this.bool_4;
            }
            set
            {
                this.bool_4 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.Menu = value;
                }
            }
        }

        [Category("Flash"), DefaultValue(""), Description("要播放的影片路径（URL ）。设置该属性为 一个 SWF 文件的 URL 将载入文件并播放它。若影片是在 本地硬盘上，要写成从盘符开始的绝对路径；若影片是在 某网站上，也要写全 URL 地址。")]
        public virtual string Movie
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.Movie;
                }
                return this.string_6;
            }
            set
            {
                this.string_6 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.Movie = value;
                }
            }
        }

        [DefaultValue(false), Category("Flash"), Description("当前播放状态。如果影片正在播放，该属性 值为 True ，否则为 False ")]
        public bool Playing
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.Playing;
                }
                return this.bool_5;
            }
            set
            {
                this.bool_5 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.Playing = value;
                }
            }
        }

        [Description("画面质量（与 Quality2 联动）。Quality 可 以取:0 ——相当于 Quality2 取 \"Low\"1 ——相当于 Quality2 取 \"High\"2 ——相当于 Quality2 取 \"AutoLow\"3 ——相当于 Quality2 取 \"AutoHigh\" "), Category("Flash"), DefaultValue(1)]
        public int Quality
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.Quality;
                }
                return this.int_3;
            }
            set
            {
                this.int_3 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.Quality = value;
                }
            }
        }

        [Description("画面质量(与 Quality 联动)。Quality2 可以取: Low ：偏重于播放速度而不管显示效果，而且不启用消锯齿功能 。High ：偏重于画面而不管播放速度，并且总是启用 消锯齿功能。如果影片中不包含动画就平滑处理位图；如 果有动画，那么位图就不被平滑处理。（这里的动画应该 是把一张图片做平移或旋转）AutoLow ：先着重于播放速度，但只要有可能就改 善显示效果。一开始播放时先禁用消锯齿功能。如果播放 器检测到处理器能承受得了 ，就启用消锯齿功能 。AutoHigh：一开始是播放速度和显示效果并重，但 如有必要就牺牲画质确保速度。开始播放时就启用消锯齿 功能。但如果实际的帧速率比设计时指定的速率慢了，就 禁用消锯齿功能来提高播放速度。"), Category("Flash"), DefaultValue((string) null)]
        public string Quality2
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.Quality2;
                }
                return this.string_7;
            }
            set
            {
                this.string_7 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.Quality2 = value;
                }
            }
        }

        [Browsable(false)]
        public int ReadyState
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.ReadyState;
                }
                return 4;
            }
        }

        [Category("Flash"), DefaultValue((string) null), Description("对齐模式（与 AlignMode 联动）。当 AlignMode代表各对齐模式的位被置“1”时，SAlign 值也相应被设为“L”（Left）、“T”（Top）、“R”（Right）、“B”（Bottom）各 字符的组合。（‘L’、‘T’、‘R’、‘B’的先后顺序不变）")]
        public string SAlign
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.SAlign;
                }
                return this.string_8;
            }
            set
            {
                this.string_8 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.SAlign = value;
                }
            }
        }

        [Description("缩放模式(与 Scale 联动)。ScaleMode 可以取：0 ——相当于 Scale 取 \"ShowAll\"1 ——相当于 Scale 取 \"NoBorder\"2 ——相当于 Scale 取 \"ExactFit\""), Category("Flash"), DefaultValue(0)]
        public int ScaleMode
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.ScaleMode;
                }
                return this.int_4;
            }
            set
            {
                this.int_4 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.ScaleMode = value;
                }
            }
        }

        [Browsable(false)]
        public int TotalFrames
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.TotalFrames;
                }
                return 0;
            }
        }

        [Category("Flash"), Description("控件的窗口模式。WMode 可以取： Window —— WMode 属性的默认值，按 Flash 播放器典型的方式工作，即在控件的矩形窗口中播放影片，这样一 般都能提供最快的动画效果。Opaque ——使影片不透明。 Transparent ——创建一个透明的影片。如果影片中有透明的片段，放到这里时，就可以看到控件下面的背景。但 使用此属性值，动画的播放速度可能会慢一些。"), DefaultValue((string) null)]
        public string WMode
        {
            get
            {
                if (this.flashBox_0 != null)
                {
                    return this.flashBox_0.WMode;
                }
                return this.string_9;
            }
            set
            {
                this.string_9 = value;
                if (this.flashBox_0 != null)
                {
                    this.flashBox_0.WMode = value;
                }
            }
        }
    }
}

