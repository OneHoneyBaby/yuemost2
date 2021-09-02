using System;
using System.Text;

internal class Class6
{
    private static string string_0 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";

    internal static string smethod_0(string string_1)
    {
        return Class5.smethod_1(string_1, smethod_1("8MvMnMhIiMtNcNsMdMtNcN"));
    }

    private static string smethod_1(string string_1)
    {
        try
        {
            int index = 0;
            int length = string_0.Length;
            byte[] bytes = new byte[string_1.Length / 2];
            for (int i = 0; i < string_1.Length; i += 2)
            {
                int num4 = string_0.IndexOf(string_1[i]);
                int num5 = string_0.IndexOf(string_1[i + 1]);
                int num6 = num5 / 8;
                num5 -= num6 * 8;
                bytes[index] = (byte) ((num6 * length) + num4);
                bytes[index] = (byte) (bytes[index] ^ num5);
                index++;
            }
            return Encoding.Default.GetString(bytes);
        }
        catch
        {
            return "";
        }
    }
}

