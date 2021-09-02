using DSkin.DSkinSv;
using DSkin.Properties;
using mscorlib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

internal class Class13
{
    private static bool bool_0 = false;
    private static bool bool_1 = true;
    private static bool bool_2 = false;
    private static Class1 class1_0 = new Class1();
    private static DateTime dateTime_0;
    [CompilerGenerated]
    private static MethodInvoker methodInvoker_0;
    private static Thread thread_0 = null;
    private static Thread thread_1 = null;
    private static Thread thread_2 = null;
    private static Thread thread_3 = null;

    [DllImport("wininet")]
    public static extern bool InternetGetConnectedState(out int int_0, int int_1);
    private static void qErOzTmEoH(string string_0)
    {
        MethodInvoker method = null;
        string msg = string_0;
        int num = 0;
    Label_0026:
        num++;
        if (Application.OpenForms.Count <= 0)
        {
            if (num >= 3)
            {
                MessageBox.Show(msg);
                return;
            }
            Thread.Sleep(0x3e8);
            goto Label_0026;
        }
        if (method == null)
        {
            <>c__DisplayClass4 class2;
            method = new MethodInvoker(class2.<ThisMgsBox>b__2);
        }
        Application.OpenForms[0].Invoke(method);
    }

    internal static bool smethod_0()
    {
        return bool_0;
    }

    internal static bool smethod_1()
    {
        return ((IntPtr.Size == 8) || ((IntPtr.Size == 4) && false));
    }

    public static bool smethod_10(string string_0)
    {
        bool flag = true;
        Ping ping = new Ping();
        try
        {
            if (ping.Send(string_0).Status != IPStatus.Success)
            {
                flag = false;
            }
        }
        catch
        {
            flag = false;
        }
        return flag;
    }

    private static DateTime smethod_11()
    {
        try
        {
            Sv sv = new Sv();
            return Convert.ToDateTime(Class5.smethod_1(sv.gt(Class5.smethod_0("TTOk" + new Random().Next(0x3e8), "#GetTime!")), "#SetTime!"));
        }
        catch (Exception)
        {
            return DateTime.Now;
        }
    }

    internal static void smethod_12()
    {
        smethod_13();
        if (null != thread_0)
        {
            thread_0.Abort();
            thread_0 = null;
        }
    }

    private static void smethod_13()
    {
        string str = Class5.smethod_1(smethod_17(typeof(Class13).Assembly.Location), Resources.mm.smethod_2()).smethod_3();
        if (!string.IsNullOrEmpty(str))
        {
            string[] strArray = str.Split(new char[] { '^' });
            if (strArray.Length == 2)
            {
                string str2 = strArray[0];
                int num = Convert.ToInt32(strArray[1]);
                if (!string.IsNullOrEmpty(str2) && (num != 0))
                {
                    bool flag = false;
                    if (num == 1)
                    {
                        string str3 = class1_0.method_2();
                        flag = str2.Equals(str3);
                    }
                    else if (num == 2)
                    {
                        flag = smethod_18().Contains(str2);
                    }
                    if (((num == 1) || (num == 2)) && flag)
                    {
                        if (num == 2)
                        {
                            smethod_14(str2);
                        }
                        if (bool_1 && (null == thread_1))
                        {
                            thread_1 = new Thread(new ParameterizedThreadStart(Class13.smethod_3));
                            thread_1.IsBackground = true;
                            thread_1.Start(str);
                        }
                        bool_0 = true;
                        return;
                    }
                }
            }
        }
        bool_0 = false;
        MessageBox.Show(Class6.smethod_0(Resources.smethod_35()));
        Process.Start(Class6.smethod_0(Resources.smethod_36()));
        Environment.Exit(0);
    }

    private static void smethod_14(object object_0)
    {
        if ((thread_2 == null) || (thread_2.ThreadState != System.Threading.ThreadState.Background))
        {
            thread_2 = new Thread(new ParameterizedThreadStart(Class13.smethod_15));
            thread_2.IsBackground = true;
            thread_2.Start(object_0);
        }
    }

    private static void smethod_15(object object_0)
    {
        while (true)
        {
            if (!smethod_16().Contains(object_0.ToString()))
            {
                smethod_4();
            }
            Thread.Sleep(0xbb8);
        }
    }

    private static List<string> smethod_16()
    {
        List<string> list = new List<string>();
        try
        {
            uint num3;
            if (File.Exists(@"C:\Program Files\ViKey\ViKey32.dll") && File.Exists(@"C:\Program Files\ViKey\ViKey64.dll"))
            {
                bool flag;
                uint num = 0;
                uint num2 = 0;
                if (flag = smethod_1())
                {
                    num3 = Class12.VikeyFind(ref num2);
                }
                else
                {
                    num3 = Class11.VikeyFind(ref num2);
                }
                if (num3 != 0)
                {
                    return list;
                }
                for (ushort i = 0; i < num2; i = (ushort) (i + 1))
                {
                    if (flag)
                    {
                        num3 = Class12.VikeyGetHID(i, ref num);
                    }
                    else
                    {
                        num3 = Class11.VikeyGetHID(i, ref num);
                    }
                    if (num3 != 0)
                    {
                        goto Label_00AE;
                    }
                    string str = num.ToString();
                    if (!string.IsNullOrEmpty(str))
                    {
                        list.Add(str);
                    }
                }
            }
            return list;
        Label_00AE:
            MessageBox.Show(string.Format("error code3: 0x{0:x}", num3));
            return list;
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
        return list;
    }

    private static string smethod_17(string string_0)
    {
        string str = null;
        string str2 = File.ReadAllText(string_0, Encoding.BigEndianUnicode);
        if (str2.Contains(Class6.smethod_0(Resources.f)) && str2.Contains(Class6.smethod_0(Resources.smethod_24())))
        {
            int startIndex = str2.LastIndexOf(Class6.smethod_0(Resources.f));
            int num2 = str2.LastIndexOf(Class6.smethod_0(Resources.smethod_24()));
            str = str2.Substring(startIndex, num2 - startIndex).Replace(Class6.smethod_0(Resources.f), "").Replace(Class6.smethod_0(Resources.smethod_24()), "");
        }
        return str;
    }

    private static List<string> smethod_18()
    {
        List<string> list = new List<string>();
        try
        {
            uint num3;
            if (File.Exists(@"C:\Program Files\ViKey\ViKey32.dll") && File.Exists(@"C:\Program Files\ViKey\ViKey64.dll"))
            {
                bool flag;
                uint num = 0;
                uint num2 = 0;
                byte[] buffer = new byte[0x100];
                string str = Class6.smethod_0(Resources.smethod_13());
                if (flag = smethod_1())
                {
                    num3 = Class12.VikeyFind(ref num2);
                }
                else
                {
                    num3 = Class11.VikeyFind(ref num2);
                }
                if (num3 != 0)
                {
                    return list;
                }
                for (ushort i = 0; i < num2; i = (ushort) (i + 1))
                {
                    buffer = new byte[str.Length];
                    if (flag)
                    {
                        num3 = Class12.VikeyGetSoftIDString(i, buffer);
                    }
                    else
                    {
                        num3 = Class11.VikeyGetSoftIDString(i, buffer);
                    }
                    if (num3 != 0)
                    {
                        goto Label_010C;
                    }
                    string str2 = Encoding.ASCII.GetString(buffer);
                    if (str.Equals(str2))
                    {
                        if (flag)
                        {
                            num3 = Class12.VikeyGetHID(i, ref num);
                        }
                        else
                        {
                            num3 = Class11.VikeyGetHID(i, ref num);
                        }
                        if (num3 != 0)
                        {
                            goto Label_0128;
                        }
                        list.Add(num.ToString());
                    }
                }
            }
            return list;
        Label_010C:
            MessageBox.Show(string.Format("error code2: 0x{0:x}", num3));
            return list;
        Label_0128:
            MessageBox.Show(string.Format("error code3: 0x{0:x}", num3));
            return list;
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
        return list;
    }

    private static bool smethod_19()
    {
        bool flag = false;
        string path = Path.GetDirectoryName(typeof(Class13).Assembly.Location) + Class6.smethod_0(Resources.smethod_16());
        if (File.Exists(path))
        {
            string str2 = File.ReadAllText(path, Encoding.BigEndianUnicode);
            if (str2.Contains(Class6.smethod_0(Resources.smethod_12())) && str2.Contains(Class6.smethod_0(Resources.smethod_15())))
            {
                flag = true;
            }
        }
        return flag;
    }

    internal static void smethod_2()
    {
        try
        {
            if (bool_1)
            {
                smethod_13();
                bool_1 = false;
                dateTime_0 = DateTime.Now;
            }
            else if (DateTime.Now.Subtract(dateTime_0).TotalSeconds >= 60.0)
            {
                dateTime_0 = DateTime.Now;
                if (null != thread_0)
                {
                    thread_0.Abort();
                    thread_0 = null;
                }
                if (null == thread_0)
                {
                    thread_0 = new Thread(new ThreadStart(Class13.smethod_12));
                    thread_0.IsBackground = true;
                    thread_0.Start();
                }
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    [CompilerGenerated]
    private static void smethod_20()
    {
        MessageBox.Show(Class6.smethod_0(Resources.smethod_35()));
        Process.Start(Class6.smethod_0(Resources.smethod_36()));
        Environment.Exit(0);
    }

    private static void smethod_3(object object_0)
    {
        string str = object_0.ToString();
        if (string.IsNullOrEmpty(str))
        {
            smethod_4();
            goto Label_02CC;
        }
        string[] strArray2 = str.Split(new char[] { '^' });
        if (strArray2.Length != 2)
        {
            smethod_4();
            goto Label_02CC;
        }
        string str12 = strArray2[0];
        int num3 = Convert.ToInt32(strArray2[1]);
        string str8 = string.Empty;
        try
        {
            str8 = class1_0.method_2();
        }
        catch (Exception exception)
        {
            if (exception.ToString().Contains("0x80010002"))
            {
                qErOzTmEoH("Windows Management Instrumentation服务没有打开，请打开该服务后重启系统。");
                smethod_4();
            }
        }
        string str11 = class1_0.method_1();
        string str9 = (num3 == 2) ? str12 : string.Empty;
        int num = 5;
    Label_00A8:
        try
        {
            if (!smethod_9())
            {
                Thread.Sleep(0x1388);
                goto Label_00A8;
            }
            Sv sv = new Sv();
            string str10 = (((string.Empty + string.Format("{0}&", smethod_11().ToString("yyyy/MM/dd HH:mm:ss")) + string.Format("{0}&", str8)) + string.Format("{0}&", str11) + string.Format("{0}&", str12)) + string.Format("{0}&", str9) + string.Format("{0}&", num3)) + string.Format("{0}&", Environment.MachineName) + "GetSqYz";
            string str2 = Class5.smethod_1(sv.ddy(Class5.smethod_0(str10, Resources.smethod_14().smethod_2())), Resources.smethod_17().smethod_2());
            if (string.IsNullOrEmpty(str2))
            {
                Thread.Sleep(0x1388);
                num--;
                if (num <= 0)
                {
                    goto Label_02CC;
                }
                goto Label_00A8;
            }
            if (str2 == "erro")
            {
                Thread.Sleep(0x1388);
                num--;
                if (num <= 0)
                {
                    goto Label_02CC;
                }
                goto Label_00A8;
            }
            string[] strArray = str2.Split(new char[] { '*' });
            if (strArray.Length == 6)
            {
                string str3 = strArray[0];
                string str4 = strArray[1];
                string str5 = strArray[2];
                int num2 = Convert.ToInt32(strArray[3]);
                string str6 = strArray[4];
                string str7 = strArray[5];
                if ((((str3.Equals(str8) && str4.Equals(str11)) && (str5.Equals(str9) && (num2 == num3))) && str6.Equals("true")) && str7.Equals("YzSq"))
                {
                    goto Label_02CC;
                }
            }
        }
        catch (Exception)
        {
            Thread.Sleep(0x1388);
            num--;
            if (num <= 0)
            {
                goto Label_02CC;
            }
            goto Label_00A8;
        }
        smethod_4();
        goto Label_00A8;
    Label_02CC:
        if (null != thread_1)
        {
            thread_1.Abort();
            thread_1 = null;
        }
    }

    private static void smethod_4()
    {
        bool_0 = false;
        int num = 0;
    Label_001D:
        num++;
        if (Application.OpenForms.Count <= 0)
        {
            if (num >= 3)
            {
                Process.Start(Class6.smethod_0(Resources.smethod_36()));
                Environment.Exit(0);
                return;
            }
            Thread.Sleep(0x3e8);
            goto Label_001D;
        }
        if (methodInvoker_0 == null)
        {
            methodInvoker_0 = new MethodInvoker(Class13.smethod_20);
        }
        Application.OpenForms[0].Invoke(methodInvoker_0);
    }

    internal static void smethod_5()
    {
        try
        {
            if (!bool_2)
            {
                bool_2 = true;
                thread_3 = new Thread(new ThreadStart(Class13.smethod_6));
                thread_3.IsBackground = true;
                thread_3.Start();
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
        }
    }

    private static void smethod_6()
    {
        string str;
        Thread.Sleep(800);
    Label_000A:
        str = Class5.smethod_1(smethod_17(typeof(Class13).Assembly.Location), Resources.mm.smethod_2()).smethod_3();
        if (!string.IsNullOrEmpty(str))
        {
            string[] strArray = str.Split(new char[] { '^' });
            if (strArray.Length == 2)
            {
                string str2 = strArray[0];
                int num = Convert.ToInt32(strArray[1]);
                bool flag = smethod_8();
                if (string.IsNullOrEmpty(str2))
                {
                    smethod_7(false);
                }
                else
                {
                    System.Boolean ReflectorVariable0;
                    bool flag2 = false;
                    switch (num)
                    {
                        case 1:
                            try
                            {
                                string str3 = class1_0.method_2();
                                flag2 = str2.Equals(str3);
                            }
                            catch (Exception exception)
                            {
                                if (exception.ToString().Contains("0x80010002"))
                                {
                                    qErOzTmEoH("Windows Management Instrumentation服务没有打开，请打开该服务后重启系统。");
                                }
                            }
                            break;

                        case 2:
                            flag2 = smethod_18().Contains(str2);
                            break;
                    }
                    if (num == 1)
                    {
                        ReflectorVariable0 = false;
                    }
                    else
                    {
                        ReflectorVariable0 = true;
                    }
                    if (!(ReflectorVariable0 ? (num != 2) : false))
                    {
                        if (flag2)
                        {
                            if (!flag)
                            {
                                smethod_7(true);
                            }
                            else if (!smethod_19())
                            {
                                goto Label_0041;
                            }
                        }
                        else if (!flag)
                        {
                            smethod_7(false);
                        }
                        else if (!smethod_19())
                        {
                            goto Label_0041;
                        }
                        if (null != thread_3)
                        {
                            thread_3.Abort();
                            thread_3 = null;
                        }
                        return;
                    }
                }
            }
        }
    Label_0041:
        smethod_4();
        goto Label_000A;
    }

    private static void smethod_7(bool bool_3 = false)
    {
        string path = Path.GetDirectoryName(typeof(Class13).Assembly.Location) + Class6.smethod_0(Resources.smethod_16());
        if (File.Exists(path))
        {
            if (bool_3)
            {
                string fileName = Path.GetFileName(Path.GetDirectoryName(path));
                if (fileName.ToLower().Contains("debug") || fileName.ToLower().Contains("release"))
                {
                    qErOzTmEoH(Class6.smethod_0(Resources.smethod_26()));
                }
                else
                {
                    File.Delete(path);
                    qErOzTmEoH(Class6.smethod_0(Resources.smethod_26()));
                }
            }
            else
            {
                File.Delete(path);
            }
        }
    }

    private static bool smethod_8()
    {
        return Debugger.IsAttached;
    }

    public static bool smethod_9()
    {
        int num;
        bool flag;
        if (!(flag = InternetGetConnectedState(out num, 0)))
        {
            flag = smethod_10("www.baid.com");
        }
        return flag;
    }
}

