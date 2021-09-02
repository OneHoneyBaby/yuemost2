namespace DSkin
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public class PIXELFORMATDESCRIPTOR
    {
        [FieldOffset(0x1b)]
        public byte bReserved;
        [FieldOffset(0x16)]
        public byte cAccumAlphaBits;
        [FieldOffset(0x12)]
        public byte cAccumBits;
        [FieldOffset(0x15)]
        public byte cAccumBlueBits;
        [FieldOffset(20)]
        public byte cAccumGreenBits;
        [FieldOffset(0x13)]
        public byte cAccumRedBits;
        [FieldOffset(0x10)]
        public byte cAlphaBits;
        [FieldOffset(0x11)]
        public byte cAlphaShift;
        [FieldOffset(0x19)]
        public byte cAuxBuffers;
        [FieldOffset(14)]
        public byte cBlueBits;
        [FieldOffset(15)]
        public byte cBlueShift;
        [FieldOffset(9)]
        public byte cColorBits;
        [FieldOffset(0x17)]
        public byte cDepthBits;
        [FieldOffset(12)]
        public byte cGreenBits;
        [FieldOffset(13)]
        public byte cGreenShift;
        [FieldOffset(10)]
        public byte cRedBits;
        [FieldOffset(11)]
        public byte cRedShift;
        [FieldOffset(0x18)]
        public byte cStencilBits;
        [FieldOffset(0x24)]
        public uint dwDamageMask;
        [FieldOffset(4)]
        public uint dwFlags;
        [FieldOffset(0x1c)]
        public uint dwLayerMask;
        [FieldOffset(0x20)]
        public uint dwVisibleMask;
        [FieldOffset(0x1a)]
        public sbyte iLayerType;
        [FieldOffset(8)]
        public byte iPixelType;
        [FieldOffset(0)]
        public ushort nSize;
        [FieldOffset(2)]
        public ushort nVersion;

        public void Init()
        {
            this.nSize = (ushort) Marshal.SizeOf(this);
        }
    }
}

