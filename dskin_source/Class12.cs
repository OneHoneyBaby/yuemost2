using System;
using System.Runtime.InteropServices;

internal class Class12
{
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint VikeyAdminLogin(ushort ushort_0, byte[] byte_0);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint ViKeyCheckModule(ushort ushort_0, ushort ushort_1, ref ushort ushort_2, ref ushort ushort_3);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint ViKeyDecraseModule(ushort ushort_0, ushort ushort_1);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint VikeyFind(ref uint uint_0);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint VikeyGetHID(ushort ushort_0, ref uint uint_0);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint VikeyGetPtroductName(ushort ushort_0, byte[] byte_0);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint VikeyGetSoftIDString(ushort ushort_0, byte[] byte_0);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint VikeyGetTime(ushort ushort_0, byte[] byte_0);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint VikeyGetType(ushort ushort_0, ref uint uint_0);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint VikeyLogoff(ushort ushort_0);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint ViKeyRandom(ushort ushort_0, ref ushort ushort_1, ref ushort ushort_2, ref ushort ushort_3, ref ushort ushort_4);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint VikeyReadData(ushort ushort_0, ushort ushort_1, ushort ushort_2, byte[] byte_0);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint VikeyResetPassword(ushort ushort_0, byte[] byte_0, byte[] byte_1);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint VikeySeed(ushort ushort_0, ref uint uint_0, ref ushort ushort_1, ref ushort ushort_2, ref ushort ushort_3, ref ushort ushort_4);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint ViKeySetModule(ushort ushort_0, ushort ushort_1, ushort ushort_2, ushort ushort_3);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint VikeySetPtroductName(ushort ushort_0, byte[] byte_0);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint VikeySetSoftIDString(ushort ushort_0, byte[] byte_0);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint VikeyUserLogin(ushort ushort_0, byte[] byte_0);
    [DllImport(@"C:\Program Files\ViKey\ViKey64.dll")]
    internal static extern uint VikeyWriteData(ushort ushort_0, ushort ushort_1, ushort ushort_2, byte[] byte_0);
}

