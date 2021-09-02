using DSkin.Properties;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

internal static class Class5
{
    internal static string smethod_0(string string_0, string string_1)
    {
        if (string_0 == "")
        {
            return "";
        }
        if (string_1.Length < 8)
        {
            string_1 = string_1 + Resources.smethod_11().smethod_2();
        }
        if (string_1.Length > 8)
        {
            string_1 = string_1.Substring(0, 8);
        }
        DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
        byte[] bytes = Encoding.Default.GetBytes(string_0);
        provider.Key = Encoding.Default.GetBytes(string_1);
        provider.IV = Encoding.Default.GetBytes(string_1);
        MemoryStream stream = new MemoryStream();
        CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
        stream2.Write(bytes, 0, bytes.Length);
        stream2.FlushFinalBlock();
        StringBuilder builder = new StringBuilder();
        foreach (byte num2 in stream.ToArray())
        {
            builder.AppendFormat("{0:X2}", num2);
        }
        builder.ToString();
        return builder.ToString();
    }

    internal static string smethod_1(string string_0, string string_1)
    {
        if (string_0 == "")
        {
            return null;
        }
        if (string_1.Length < 8)
        {
            string_1 = string_1 + Resources.smethod_11().smethod_2();
        }
        if (string_1.Length > 8)
        {
            string_1 = string_1.Substring(0, 8);
        }
        try
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] buffer = new byte[string_0.Length / 2];
            for (int i = 0; i < (string_0.Length / 2); i++)
            {
                int num2 = Convert.ToInt32(string_0.Substring(i * 2, 2), 0x10);
                buffer[i] = (byte) num2;
            }
            provider.Key = Encoding.Default.GetBytes(string_1);
            provider.IV = Encoding.Default.GetBytes(string_1);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            new StringBuilder();
            return Encoding.Default.GetString(stream.ToArray());
        }
        catch
        {
            return null;
        }
    }

    internal static string smethod_2(this string string_0)
    {
        if (string.IsNullOrEmpty(string_0))
        {
            return null;
        }
        string str3 = Class6.smethod_0(Resources.smethod_45());
        int length = str3.Length;
        int num4 = 0;
        string str = "";
        int num3 = Convert.ToInt32(Convert.ToString(Convert.ToInt32(string_0.Substring(0, 2), 0x10), 10));
        for (int i = 2; i < string_0.Length; i += 2)
        {
            int num6 = Convert.ToInt32(Convert.ToString(Convert.ToInt32(string_0.Substring(i, 2), 0x10), 10));
            if (num4 < length)
            {
                num4++;
            }
            else
            {
                num4 = 1;
            }
            char ch1 = str3[num4 - 1];
            int num2 = num6 ^ str3[num4 - 1];
            if (num2 <= num3)
            {
                num2 = (0xff + num2) - num3;
            }
            else
            {
                num2 -= num3;
            }
            str = str + ((char) num2);
            num3 = num6;
        }
        return str;
    }

    internal static string smethod_3(this string string_0)
    {
        string str;
        if (string.IsNullOrEmpty(string_0))
        {
            return null;
        }
        DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
        try
        {
            int num = 1;
            byte[] buffer = new byte[] { 8, 20, 1, 20, 0x15, 5, 9, 0x16 };
            byte[] buffer2 = new byte[] { 8, 20, 1, 20, 0x15, 5, 9, 0x16 };
            byte[] buffer3 = new byte[string_0.Length / 2];
            for (int i = 0; i < (string_0.Length / 2); i++)
            {
                int num5 = Convert.ToInt32(string_0.Substring(i * 2, 2), 0x10);
                buffer3[i] = (byte) num5;
            }
            Encoding unicode = Encoding.Unicode;
            byte[] bytes = new byte[1];
            StringBuilder builder = new StringBuilder();
            string[] strArray2 = new string[] { "22", "11", "32", "45", "76" };
            for (int j = 1; j < num; j++)
            {
                int num6 = int.Parse(strArray2[j % 5]);
                char ch = string_0[j];
                int num7 = unicode.GetBytes(ch.ToString())[0];
                bytes[0] = Convert.ToByte((int) (num6 ^ num7));
                builder.Append(unicode.GetString(bytes));
            }
            provider.Key = buffer;
            provider.IV = buffer2;
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(buffer3, 0, buffer3.Length);
            stream2.FlushFinalBlock();
            string str2 = "";
            char[] chArray = Encoding.Default.GetString(stream.ToArray()).ToCharArray();
            for (int k = 0; k < chArray.Length; k++)
            {
                int num8 = chArray[k] - num;
                chArray[k] = (char) num8;
                str2 = str2 + chArray[k];
            }
            str = str2;
        }
        finally
        {
            provider = null;
        }
        return str;
    }
}

