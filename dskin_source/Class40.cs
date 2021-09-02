using DSkin.Html.Adapters;
using DSkin.Html.Adapters.Entities;
using DSkin.Html.Core;
using DSkin.Html.Core.Entities;
using DSkin.Html.Core.Handlers;
using DSkin.Html.Core.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

internal sealed class Class40 : IDisposable
{
    private bool bool_0;
    private bool bool_1;
    private bool bool_2;
    private bool bool_3 = false;
    private readonly Delegate3<RImage, RRect, bool> delegate3_0;
    private readonly HtmlContainerInt htmlContainerInt_0;
    private object object_0;
    private RImage rimage_0;
    private RRect rrect_0;

    public Class40(HtmlContainerInt htmlContainerInt_1, Delegate3<RImage, RRect, bool> delegate3_1)
    {
        ArgChecker.AssertArgNotNull(htmlContainerInt_1, "htmlContainer");
        ArgChecker.AssertArgNotNull(delegate3_1, "loadCompleteCallback");
        this.htmlContainerInt_0 = htmlContainerInt_1;
        this.delegate3_0 = delegate3_1;
    }

    public void Dispose()
    {
        try
        {
            ImageAdapter adapter = this.rimage_0 as ImageAdapter;
            if ((adapter != null) && this.bool_3)
            {
                ImageAnimator.StopAnimate(adapter.Image, new EventHandler(this.method_0));
            }
        }
        catch (Exception)
        {
        }
        this.bool_2 = true;
        this.method_11();
    }

    private void method_0(object sender, EventArgs e)
    {
        if ((!this.bool_2 && (this.htmlContainerInt_0.Control != null)) && (this.rimage_0 != null))
        {
            MethodInvoker method = null;
            ImageAdapter image = this.rimage_0 as ImageAdapter;
            if (image != null)
            {
                Control hostControl = null;
                if (this.htmlContainerInt_0.Control is ControlAdapter)
                {
                    hostControl = ((ControlAdapter) this.htmlContainerInt_0.Control).Control;
                }
                if (this.htmlContainerInt_0.Control is DuiControlAdapter)
                {
                    hostControl = ((DuiControlAdapter) this.htmlContainerInt_0.Control).DuiControl.HostControl;
                }
                if (((((hostControl != null) && !hostControl.Disposing) && !hostControl.IsDisposed) && hostControl.Created) && (((hostControl.Site == null) || !hostControl.Site.DesignMode) ? hostControl.Visible : false))
                {
                    if (method == null)
                    {
                        <>c__DisplayClass2 class2;
                        method = new MethodInvoker(class2.<OnFrameChanged>b__0);
                    }
                    hostControl.BeginInvoke(method);
                }
            }
        }
    }

    public void method_1(string string_0, Dictionary<string, string> dictionary_0)
    {
        try
        {
            HtmlImageLoadEventArgs args = new HtmlImageLoadEventArgs(string_0, dictionary_0, new HtmlImageLoadCallback(this.method_2));
            this.htmlContainerInt_0.method_7(args);
            this.bool_0 = !this.htmlContainerInt_0.AvoidAsyncImagesLoading;
            if (!args.Handled)
            {
                if (!string.IsNullOrEmpty(string_0))
                {
                    if (string_0.StartsWith("data:image", StringComparison.CurrentCultureIgnoreCase))
                    {
                        this.method_3(string_0);
                    }
                    else
                    {
                        this.method_5(string_0);
                    }
                }
                else
                {
                    this.method_10(false);
                }
            }
        }
        catch (Exception exception)
        {
            this.htmlContainerInt_0.method_8(HtmlRenderErrorType.Image, "Exception in handling image source", exception);
            this.method_10(false);
        }
    }

    private void method_10(bool bool_4 = true)
    {
        if (this.bool_2)
        {
            this.method_11();
        }
        else
        {
            this.delegate3_0(this.rimage_0, this.rrect_0, bool_4);
        }
    }

    private void method_11()
    {
        lock (this.delegate3_0)
        {
            if (this.bool_1 && (this.rimage_0 != null))
            {
                this.rimage_0.Dispose();
                this.rimage_0 = null;
            }
            if (this.object_0 != null)
            {
                this.object_0.Dispose();
                this.object_0 = null;
            }
        }
    }

    private void method_2(string string_0, object object_1, RRect rrect_1)
    {
        if (!this.bool_2)
        {
            this.rrect_0 = rrect_1;
            if (object_1 != null)
            {
                this.Image = this.htmlContainerInt_0.method_0().ConvertImage(object_1);
                this.method_10(this.bool_0);
            }
            else if (!string.IsNullOrEmpty(string_0))
            {
                this.method_5(string_0);
            }
            else
            {
                this.method_10(this.bool_0);
            }
        }
    }

    private void method_3(string string_0)
    {
        this.Image = this.method_4(string_0);
        if (this.rimage_0 == null)
        {
            this.htmlContainerInt_0.method_8(HtmlRenderErrorType.Image, "Failed extract image from inline data", null);
        }
        this.bool_1 = true;
        this.method_10(false);
    }

    private RImage method_4(string string_0)
    {
        string[] strArray = string_0.Substring(string_0.IndexOf(':') + 1).Split(new char[] { ',' }, 2);
        if (strArray.Length == 2)
        {
            int num = 0;
            int num2 = 0;
            foreach (string str2 in strArray[0].Split(new char[] { ';' }))
            {
                string str = str2.Trim();
                if (str.StartsWith("image/", StringComparison.InvariantCultureIgnoreCase))
                {
                    num++;
                }
                if (str.Equals("base64", StringComparison.InvariantCultureIgnoreCase))
                {
                    num2++;
                }
            }
            if (num > 0)
            {
                byte[] buffer = (num2 > 0) ? Convert.FromBase64String(strArray[1].Trim()) : new UTF8Encoding().GetBytes(Uri.UnescapeDataString(strArray[1].Trim()));
                return this.htmlContainerInt_0.method_0().ImageFromStream(new MemoryStream(buffer));
            }
        }
        return null;
    }

    private void method_5(string string_0)
    {
        Uri uri = Class48.smethod_5(string_0);
        if ((uri != null) && (uri.Scheme != "file"))
        {
            this.method_8(uri);
        }
        else
        {
            FileInfo info = Class48.smethod_7((uri != null) ? uri.AbsolutePath : string_0);
            if (info != null)
            {
                this.method_6(info);
            }
            else
            {
                this.htmlContainerInt_0.method_8(HtmlRenderErrorType.Image, "Failed load image, invalid source: " + string_0, null);
                this.method_10(false);
            }
        }
    }

    private void method_6(FileInfo fileInfo_0)
    {
        WaitCallback callBack = null;
        FileInfo source = fileInfo_0;
        if (source.Exists)
        {
            if (this.htmlContainerInt_0.AvoidAsyncImagesLoading)
            {
                this.method_7(source.FullName);
            }
            else
            {
                if (callBack == null)
                {
                    <>c__DisplayClass6 class2;
                    callBack = new WaitCallback(class2.<SetImageFromFile>b__4);
                }
                ThreadPool.QueueUserWorkItem(callBack);
            }
        }
        else
        {
            this.method_10(true);
        }
    }

    private void method_7(string string_0)
    {
        try
        {
            FileStream stream = File.Open(string_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            lock (this.delegate3_0)
            {
                this.object_0 = stream;
                if (!this.bool_2)
                {
                    this.Image = this.htmlContainerInt_0.method_0().ImageFromStream((Stream) this.object_0);
                }
                this.bool_1 = true;
            }
            this.method_10(true);
        }
        catch (Exception exception)
        {
            this.htmlContainerInt_0.method_8(HtmlRenderErrorType.Image, "Failed to load image from disk: " + string_0, exception);
            this.method_10(true);
        }
    }

    private void method_8(Uri uri_0)
    {
        FileInfo info = Class48.smethod_9(uri_0);
        if (info.Exists && (info.Length > 0L))
        {
            this.method_6(info);
        }
        else
        {
            this.htmlContainerInt_0.method_11().method_0(uri_0, info.FullName, !this.htmlContainerInt_0.AvoidAsyncImagesLoading, new DownloadFileAsyncCallback(this.method_9));
        }
    }

    private void method_9(Uri uri_0, string string_0, Exception exception_0, bool bool_4)
    {
        if (!bool_4 && !this.bool_2)
        {
            if (exception_0 == null)
            {
                this.method_7(string_0);
            }
            else
            {
                this.htmlContainerInt_0.method_8(HtmlRenderErrorType.Image, "Failed to load image from URL: " + uri_0, exception_0);
                this.method_10(true);
            }
        }
    }

    public RImage Image
    {
        get
        {
            return this.rimage_0;
        }
        set
        {
            if (this.rimage_0 != value)
            {
                this.rimage_0 = value;
                ImageAdapter adapter = this.rimage_0 as ImageAdapter;
                if (adapter != null)
                {
                    this.bool_3 = ImageAnimator.CanAnimate(adapter.Image);
                    if (this.bool_3)
                    {
                        ImageAnimator.Animate(adapter.Image, new EventHandler(this.method_0));
                    }
                }
            }
        }
    }

    public RRect Rectangle
    {
        get
        {
            return this.rrect_0;
        }
    }
}

