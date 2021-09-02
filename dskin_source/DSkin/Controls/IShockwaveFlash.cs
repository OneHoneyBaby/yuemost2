namespace DSkin.Controls
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, TypeLibType((short) 0x1040), Guid("D27CDB6C-AE6D-11CF-96B8-444553540000")]
    public interface IShockwaveFlash
    {
        [DispId(-525)]
        int ReadyState { [MethodImpl(MethodImplOptions.InternalCall), DispId(-525)] get; }
        [DispId(0x7c)]
        int TotalFrames { [MethodImpl(MethodImplOptions.InternalCall), DispId(0x7c)] get; }
        [DispId(0x7d)]
        bool Playing { [MethodImpl(MethodImplOptions.InternalCall), DispId(0x7d)] get; [MethodImpl(MethodImplOptions.InternalCall), DispId(0x7d)] set; }
        [DispId(0x69)]
        int Quality { [MethodImpl(MethodImplOptions.InternalCall), DispId(0x69)] get; [MethodImpl(MethodImplOptions.InternalCall), DispId(0x69)] set; }
        [DispId(120)]
        int ScaleMode { [MethodImpl(MethodImplOptions.InternalCall), DispId(120)] get; [MethodImpl(MethodImplOptions.InternalCall), DispId(120)] set; }
        [DispId(0x79)]
        int AlignMode { [MethodImpl(MethodImplOptions.InternalCall), DispId(0x79)] get; [MethodImpl(MethodImplOptions.InternalCall), DispId(0x79)] set; }
        [DispId(0x7b)]
        int BackgroundColor { [MethodImpl(MethodImplOptions.InternalCall), DispId(0x7b)] get; [MethodImpl(MethodImplOptions.InternalCall), DispId(0x7b)] set; }
        [DispId(0x6a)]
        bool Loop { [MethodImpl(MethodImplOptions.InternalCall), DispId(0x6a)] get; [MethodImpl(MethodImplOptions.InternalCall), DispId(0x6a)] set; }
        [DispId(0x66)]
        string Movie { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0x66)] get; [param: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0x66)] set; }
        [DispId(0x6b)]
        int FrameNum { [MethodImpl(MethodImplOptions.InternalCall), DispId(0x6b)] get; [MethodImpl(MethodImplOptions.InternalCall), DispId(0x6b)] set; }
        [DispId(0x85)]
        string WMode { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0x85)] get; [param: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0x85)] set; }
        [DispId(0x86)]
        string SAlign { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0x86)] get; [param: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0x86)] set; }
        [DispId(0x87)]
        bool Menu { [MethodImpl(MethodImplOptions.InternalCall), DispId(0x87)] get; [MethodImpl(MethodImplOptions.InternalCall), DispId(0x87)] set; }
        [DispId(0x88)]
        string Base { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0x88)] get; [param: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0x88)] set; }
        [DispId(0x89)]
        string Scale { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0x89)] get; [param: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0x89)] set; }
        [DispId(0x8a)]
        bool DeviceFont { [MethodImpl(MethodImplOptions.InternalCall), DispId(0x8a)] get; [MethodImpl(MethodImplOptions.InternalCall), DispId(0x8a)] set; }
        [DispId(0x8b)]
        bool EmbedMovie { [MethodImpl(MethodImplOptions.InternalCall), DispId(0x8b)] get; [MethodImpl(MethodImplOptions.InternalCall), DispId(0x8b)] set; }
        [DispId(140)]
        string BGColor { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(140)] get; [param: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(140)] set; }
        [DispId(0x8d)]
        string Quality2 { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0x8d)] get; [param: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0x8d)] set; }
        [DispId(0x9f)]
        string SWRemote { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0x9f)] get; [param: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0x9f)] set; }
        [DispId(170)]
        string FlashVars { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(170)] get; [param: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(170)] set; }
        [DispId(0xab)]
        string AllowScriptAccess { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0xab)] get; [param: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0xab)] set; }
        [DispId(190)]
        string MovieData { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(190)] get; [param: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(190)] set; }
        [DispId(0xbf)]
        object InlineData { [return: MarshalAs(UnmanagedType.IUnknown)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0xbf)] get; [param: MarshalAs(UnmanagedType.IUnknown)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0xbf)] set; }
        [DispId(0xc0)]
        bool SeamlessTabbing { [MethodImpl(MethodImplOptions.InternalCall), DispId(0xc0)] get; [MethodImpl(MethodImplOptions.InternalCall), DispId(0xc0)] set; }
        [DispId(0xc2)]
        bool Profile { [MethodImpl(MethodImplOptions.InternalCall), DispId(0xc2)] get; [MethodImpl(MethodImplOptions.InternalCall), DispId(0xc2)] set; }
        [DispId(0xc3)]
        string ProfileAddress { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0xc3)] get; [param: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0xc3)] set; }
        [DispId(0xc4)]
        int ProfilePort { [MethodImpl(MethodImplOptions.InternalCall), DispId(0xc4)] get; [MethodImpl(MethodImplOptions.InternalCall), DispId(0xc4)] set; }
        [DispId(0xc9)]
        string AllowNetworking { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0xc9)] get; [param: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0xc9)] set; }
        [DispId(0xca)]
        string AllowFullScreen { [return: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0xca)] get; [param: MarshalAs(UnmanagedType.BStr)] [MethodImpl(MethodImplOptions.InternalCall), DispId(0xca)] set; }
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x6d)]
        void SetZoomRect([In] int left, [In] int top, [In] int right, [In] int bottom);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x76)]
        void Zoom([In] int factor);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x77)]
        void Pan([In] int x, [In] int y, [In] int mode);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x70)]
        void Play();
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x71)]
        void Stop();
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x72)]
        void Back();
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x73)]
        void Forward();
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x74)]
        void Rewind();
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x7e)]
        void StopPlay();
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x7f)]
        void GotoFrame([In] int FrameNum);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x80)]
        int CurrentFrame();
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x81)]
        bool IsPlaying();
        [MethodImpl(MethodImplOptions.InternalCall), DispId(130)]
        int PercentLoaded();
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x83)]
        bool FrameLoaded([In] int FrameNum);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x84)]
        int FlashVersion();
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x8e)]
        void LoadMovie([In] int layer, [In, MarshalAs(UnmanagedType.BStr)] string url);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x8f)]
        void imethod_0([In, MarshalAs(UnmanagedType.BStr)] string target, [In] int FrameNum);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x90)]
        void imethod_1([In, MarshalAs(UnmanagedType.BStr)] string target, [In, MarshalAs(UnmanagedType.BStr)] string label);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x91)]
        int TCurrentFrame([In, MarshalAs(UnmanagedType.BStr)] string target);
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x92)]
        string TCurrentLabel([In, MarshalAs(UnmanagedType.BStr)] string target);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x93)]
        void TPlay([In, MarshalAs(UnmanagedType.BStr)] string target);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x94)]
        void imethod_2([In, MarshalAs(UnmanagedType.BStr)] string target);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x97)]
        void SetVariable([In, MarshalAs(UnmanagedType.BStr)] string name, [In, MarshalAs(UnmanagedType.BStr)] string value);
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x98)]
        string GetVariable([In, MarshalAs(UnmanagedType.BStr)] string name);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x99)]
        void TSetProperty([In, MarshalAs(UnmanagedType.BStr)] string target, [In] int property, [In, MarshalAs(UnmanagedType.BStr)] string value);
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x9a)]
        string TGetProperty([In, MarshalAs(UnmanagedType.BStr)] string target, [In] int property);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x9b)]
        void imethod_3([In, MarshalAs(UnmanagedType.BStr)] string target, [In] int FrameNum);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x9c)]
        void imethod_4([In, MarshalAs(UnmanagedType.BStr)] string target, [In, MarshalAs(UnmanagedType.BStr)] string label);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x9d)]
        void TSetPropertyNum([In, MarshalAs(UnmanagedType.BStr)] string target, [In] int property, [In] double value);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0x9e)]
        double TGetPropertyNum([In, MarshalAs(UnmanagedType.BStr)] string target, [In] int property);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0xac)]
        double TGetPropertyAsNumber([In, MarshalAs(UnmanagedType.BStr)] string target, [In] int property);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0xc1)]
        void EnforceLocalSecurity();
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0xc6)]
        string CallFunction([In, MarshalAs(UnmanagedType.BStr)] string request);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(0xc7)]
        void SetReturnValue([In, MarshalAs(UnmanagedType.BStr)] string returnValue);
        [MethodImpl(MethodImplOptions.InternalCall), DispId(200)]
        void DisableLocalSecurity();
    }
}

