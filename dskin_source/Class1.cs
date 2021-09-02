using System;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;

internal class Class1
{
    private string method_0()
    {
        string str = string.Empty;
        string[] strArray2 = new string[] { "c", "d", "e", "f", "g" };
        foreach (string str3 in strArray2)
        {
            if (Directory.Exists(string.Format(@"{0}:\", str3)))
            {
                str = str3;
                break;
            }
        }
        if (str == string.Empty)
        {
            return string.Empty;
        }
        using (new ManagementClass("Win32_NetworkAdapterConfiguration"))
        {
            ManagementObject obj2 = new ManagementObject(string.Format("win32_logicaldisk.deviceid=\"{0}:\"", str));
            obj2.Get();
            if (obj2.GetPropertyValue("VolumeSerialNumber") != null)
            {
                return obj2.GetPropertyValue("VolumeSerialNumber").ToString();
            }
            return string.Empty;
        }
    }

    internal string method_1()
    {
        string str = string.Empty;
        using (ManagementClass class2 = new ManagementClass("Win32_Processor"))
        {
            foreach (ManagementObject obj2 in class2.GetInstances())
            {
                if ((obj2.Properties["ProcessorId"] != null) && !string.IsNullOrEmpty(obj2.Properties["ProcessorId"].Value))
                {
                    str = obj2.Properties["ProcessorId"].Value.ToString();
                    obj2.Dispose();
                }
            }
        }
        return str.ToString();
    }

    internal string method_2()
    {
        string str = this.method_0();
        string str2 = (str == string.Empty) ? this.method_1() : str;
        string s = str2.Substring(0, str2.Length - 2);
        int num = 0;
        while (true)
        {
            string str5 = "";
            byte[] buffer = MD5.Create().ComputeHash(Encoding.Unicode.GetBytes(s));
            for (int i = 0; i < buffer.Length; i++)
            {
                str5 = str5 + buffer[i].ToString("x");
            }
            num++;
            if (num >= 2)
            {
                return str5;
            }
            s = str5;
        }
    }
}

