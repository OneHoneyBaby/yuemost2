using DSkin.Html.Adapters;
using DSkin.Html.Adapters.Entities;
using DSkin.Html.Core.Dom;
using DSkin.Html.Core.Entities;
using System;
using System.Net;
using System.Threading;

internal sealed class Class24 : CssBox
{
    private readonly bool bool_2;
    private bool bool_3;
    private readonly Class31 class31_0;
    private Class40 class40_1;
    private string string_64;
    private string string_65;
    private string string_66;

    public Class24(CssBox cssBox_2, HtmlTag htmlTag_1) : base(cssBox_2, htmlTag_1)
    {
        Uri uri;
        this.class31_0 = new Class31(this);
        base.Words.Add(this.class31_0);
        if (Uri.TryCreate(base.GetAttribute("src"), UriKind.Absolute, out uri))
        {
            if (uri.Host.IndexOf("youtube.com", StringComparison.InvariantCultureIgnoreCase) > -1)
            {
                this.bool_2 = true;
                this.method_25(uri);
            }
            else if (uri.Host.IndexOf("vimeo.com", StringComparison.InvariantCultureIgnoreCase) > -1)
            {
                this.bool_2 = true;
                this.method_27(uri);
            }
        }
        if (!this.bool_2)
        {
            this.method_34();
        }
    }

    public override void Dispose()
    {
        if (this.class40_1 != null)
        {
            this.class40_1.Dispose();
        }
        base.Dispose();
    }

    public bool method_24()
    {
        return this.bool_2;
    }

    private void method_25(Uri uri_0)
    {
        <>c__DisplayClass1 class2;
        Uri uri = uri_0;
        ThreadPool.QueueUserWorkItem(new WaitCallback(class2.<LoadYoutubeDataAsync>b__0));
    }

    private void method_26(object sender, DownloadStringCompletedEventArgs e)
    {
        try
        {
            if (!e.Cancelled)
            {
                if (e.Error == null)
                {
                    int num3;
                    int index = e.Result.IndexOf("\"media$title\"", StringComparison.Ordinal);
                    if (index > -1)
                    {
                        index = e.Result.IndexOf("\"$t\"", index);
                        if (index > -1)
                        {
                            index = e.Result.IndexOf('"', index + 4);
                            if (index > -1)
                            {
                                num3 = e.Result.IndexOf('"', index + 1);
                                while (e.Result[num3 - 1] == '\\')
                                {
                                    num3 = e.Result.IndexOf('"', num3 + 1);
                                }
                                if (num3 > -1)
                                {
                                    this.string_64 = e.Result.Substring(index + 1, (num3 - index) - 1).Replace("\\\"", "\"");
                                }
                            }
                        }
                    }
                    index = e.Result.IndexOf("\"media$thumbnail\"", StringComparison.Ordinal);
                    if (index > -1)
                    {
                        int startIndex = e.Result.IndexOf("sddefault", index);
                        if (startIndex > -1)
                        {
                            if (string.IsNullOrEmpty(base.Width))
                            {
                                base.Width = "640px";
                            }
                            if (string.IsNullOrEmpty(base.Height))
                            {
                                base.Height = "480px";
                            }
                        }
                        else
                        {
                            startIndex = e.Result.IndexOf("hqdefault", index);
                            if (startIndex > -1)
                            {
                                if (string.IsNullOrEmpty(base.Width))
                                {
                                    base.Width = "480px";
                                }
                                if (string.IsNullOrEmpty(base.Height))
                                {
                                    base.Height = "360px";
                                }
                            }
                            else
                            {
                                startIndex = e.Result.IndexOf("mqdefault", index);
                                if (startIndex > -1)
                                {
                                    if (string.IsNullOrEmpty(base.Width))
                                    {
                                        base.Width = "320px";
                                    }
                                    if (string.IsNullOrEmpty(base.Height))
                                    {
                                        base.Height = "180px";
                                    }
                                }
                                else
                                {
                                    startIndex = e.Result.IndexOf("default", index);
                                    if (string.IsNullOrEmpty(base.Width))
                                    {
                                        base.Width = "120px";
                                    }
                                    if (string.IsNullOrEmpty(base.Height))
                                    {
                                        base.Height = "90px";
                                    }
                                }
                            }
                        }
                        startIndex = e.Result.LastIndexOf("http:", startIndex, StringComparison.Ordinal);
                        if (startIndex > -1)
                        {
                            num3 = e.Result.IndexOf('"', startIndex);
                            if (num3 > -1)
                            {
                                this.string_65 = e.Result.Substring(startIndex, num3 - startIndex).Replace("\\\"", "\"").Replace(@"\", "");
                            }
                        }
                    }
                    index = e.Result.IndexOf("\"link\"", StringComparison.Ordinal);
                    if (index > -1)
                    {
                        index = e.Result.IndexOf("http:", index);
                        if (index > -1)
                        {
                            num3 = e.Result.IndexOf('"', index);
                            if (num3 > -1)
                            {
                                this.string_66 = e.Result.Substring(index, num3 - index).Replace("\\\"", "\"").Replace(@"\", "");
                            }
                        }
                    }
                }
                else
                {
                    this.method_29(e.Error, "YouTube");
                }
            }
        }
        catch (Exception exception)
        {
            base.HtmlContainer.method_8(HtmlRenderErrorType.Iframe, "Failed to parse YouTube video response", exception);
        }
        this.method_30(sender);
    }

    private void method_27(Uri uri_0)
    {
        <>c__DisplayClass4 class2;
        Uri uri = uri_0;
        ThreadPool.QueueUserWorkItem(new WaitCallback(class2.<LoadVimeoDataAsync>b__3));
    }

    private void method_28(object sender, DownloadStringCompletedEventArgs e)
    {
        try
        {
            if (!e.Cancelled)
            {
                if (e.Error == null)
                {
                    int num;
                    int index = e.Result.IndexOf("\"title\"", StringComparison.Ordinal);
                    if (index > -1)
                    {
                        index = e.Result.IndexOf('"', index + 7);
                        if (index > -1)
                        {
                            num = e.Result.IndexOf('"', index + 1);
                            while (e.Result[num - 1] == '\\')
                            {
                                num = e.Result.IndexOf('"', num + 1);
                            }
                            if (num > -1)
                            {
                                this.string_64 = e.Result.Substring(index + 1, (num - index) - 1).Replace("\\\"", "\"");
                            }
                        }
                    }
                    index = e.Result.IndexOf("\"thumbnail_large\"", StringComparison.Ordinal);
                    if (index > -1)
                    {
                        if (string.IsNullOrEmpty(base.Width))
                        {
                            base.Width = "640";
                        }
                        if (string.IsNullOrEmpty(base.Height))
                        {
                            base.Height = "360";
                        }
                    }
                    else
                    {
                        index = e.Result.IndexOf("thumbnail_medium", index);
                        if (index > -1)
                        {
                            if (string.IsNullOrEmpty(base.Width))
                            {
                                base.Width = "200";
                            }
                            if (string.IsNullOrEmpty(base.Height))
                            {
                                base.Height = "150";
                            }
                        }
                        else
                        {
                            index = e.Result.IndexOf("thumbnail_small", index);
                            if (string.IsNullOrEmpty(base.Width))
                            {
                                base.Width = "100";
                            }
                            if (string.IsNullOrEmpty(base.Height))
                            {
                                base.Height = "75";
                            }
                        }
                    }
                    if (index > -1)
                    {
                        index = e.Result.IndexOf("http:", index);
                        if (index > -1)
                        {
                            num = e.Result.IndexOf('"', index);
                            if (num > -1)
                            {
                                this.string_65 = e.Result.Substring(index, num - index).Replace("\\\"", "\"").Replace(@"\", "");
                            }
                        }
                    }
                    index = e.Result.IndexOf("\"url\"", StringComparison.Ordinal);
                    if (index > -1)
                    {
                        index = e.Result.IndexOf("http:", index);
                        if (index > -1)
                        {
                            num = e.Result.IndexOf('"', index);
                            if (num > -1)
                            {
                                this.string_66 = e.Result.Substring(index, num - index).Replace("\\\"", "\"").Replace(@"\", "");
                            }
                        }
                    }
                }
                else
                {
                    this.method_29(e.Error, "Vimeo");
                }
            }
        }
        catch (Exception exception)
        {
            base.HtmlContainer.method_8(HtmlRenderErrorType.Iframe, "Failed to parse Vimeo video response", exception);
        }
        this.method_30(sender);
    }

    private void method_29(Exception exception_0, string string_67)
    {
        WebException exception = exception_0 as WebException;
        HttpWebResponse response = (exception != null) ? (exception.Response as HttpWebResponse) : null;
        if ((response != null) && (response.StatusCode == HttpStatusCode.NotFound))
        {
            this.string_64 = "The video is not found, possibly removed by the user.";
        }
        else
        {
            base.HtmlContainer.method_8(HtmlRenderErrorType.Iframe, "Failed to load " + string_67 + " video data", exception_0);
        }
    }

    private void method_30(object object_0)
    {
        try
        {
            if (this.string_65 == null)
            {
                this.bool_3 = true;
                this.method_34();
            }
            WebClient client = (WebClient) object_0;
            client.DownloadStringCompleted -= new DownloadStringCompletedEventHandler(this.method_26);
            client.DownloadStringCompleted -= new DownloadStringCompletedEventHandler(this.method_28);
            client.Dispose();
            base.HtmlContainer.RequestRefresh(this.method_36());
        }
        catch
        {
        }
    }

    private void method_31(RGraphics rgraphics_0, RPoint rpoint_1, RRect rrect_0)
    {
        if (this.class31_0.Image != null)
        {
            if ((rrect_0.Width > 0.0) && (rrect_0.Height > 0.0))
            {
                if (this.class31_0.method_1() == RRect.Empty)
                {
                    rgraphics_0.DrawImage(this.class31_0.Image, rrect_0);
                }
                else
                {
                    rgraphics_0.DrawImage(this.class31_0.Image, rrect_0, this.class31_0.method_1());
                }
                if (this.class31_0.Selected)
                {
                    rgraphics_0.DrawRectangle(base.GetSelectionBackBrush(rgraphics_0, true), this.class31_0.Left + rpoint_1.X, this.class31_0.Top + rpoint_1.Y, this.class31_0.Width + 2.0, Class50.smethod_15(this.class31_0).LineHeight);
                }
            }
        }
        else if (!(!this.bool_2 || this.bool_3))
        {
            Class53.smethod_1(rgraphics_0, base.HtmlContainer, rrect_0);
            if ((rrect_0.Width > 19.0) && (rrect_0.Height > 19.0))
            {
                rgraphics_0.DrawRectangle(rgraphics_0.GetPen(RColor.LightGray), rrect_0.X, rrect_0.Y, rrect_0.Width, rrect_0.Height);
            }
        }
    }

    private void method_32(RGraphics rgraphics_0, RRect rrect_0)
    {
        if (((this.string_64 != null) && (this.class31_0.Width > 40.0)) && (this.class31_0.Height > 40.0))
        {
            RFont font = base.HtmlContainer.method_0().GetFont("Arial", 9.0, RFontStyle.Regular);
            rgraphics_0.DrawRectangle(rgraphics_0.GetSolidBrush(RColor.FromArgb(160, 0, 0, 0)), rrect_0.Left, rrect_0.Top, rrect_0.Width, base.ActualFont.Height + 7.0);
            RRect rect = new RRect(rrect_0.Left + 3.0, rrect_0.Top + 3.0, rrect_0.Width - 6.0, rrect_0.Height - 6.0);
            rgraphics_0.DrawString(this.string_64, font, RColor.WhiteSmoke, rect.Location, RSize.Empty, false);
        }
    }

    private void method_33(RGraphics rgraphics_0, RRect rrect_0)
    {
        if ((this.bool_2 && (this.class31_0.Width > 70.0)) && (this.class31_0.Height > 50.0))
        {
            object prevMode = rgraphics_0.SetAntiAliasSmoothingMode();
            RSize size = new RSize(60.0, 40.0);
            double x = rrect_0.Left + ((rrect_0.Width - size.Width) / 2.0);
            double y = rrect_0.Top + ((rrect_0.Height - size.Height) / 2.0);
            rgraphics_0.DrawRectangle(rgraphics_0.GetSolidBrush(RColor.FromArgb(160, 0, 0, 0)), x, y, size.Width, size.Height);
            RPoint[] points = new RPoint[] { new RPoint((x + (size.Width / 3.0)) + 1.0, y + ((3.0 * size.Height) / 4.0)), new RPoint((x + (size.Width / 3.0)) + 1.0, y + (size.Height / 4.0)), new RPoint((x + ((2.0 * size.Width) / 3.0)) + 1.0, y + (size.Height / 2.0)) };
            rgraphics_0.DrawPolygon(rgraphics_0.GetSolidBrush(RColor.White), points);
            rgraphics_0.ReturnPreviousSmoothingMode(prevMode);
        }
    }

    private void method_34()
    {
        base.SetAllBorders("solid", "2px", "#A0A0A0");
        base.BorderRightColor = base.BorderBottomColor = "#E3E3E3";
    }

    private void method_35(RImage rimage_0, RRect rrect_0, bool bool_4)
    {
        this.class31_0.Image = rimage_0;
        this.class31_0.method_2(rrect_0);
        this.bool_3 = true;
        base._wordsSizeMeasured = false;
        if (this.bool_3 && (rimage_0 == null))
        {
            this.method_34();
        }
        if (bool_4)
        {
            base.HtmlContainer.RequestRefresh(this.method_36());
        }
    }

    private bool method_36()
    {
        Class30 class2 = new Class30(base.Width);
        Class30 class3 = new Class30(base.Height);
        return (((class2.method_0() <= 0.0) || (class2.method_4() != ((Enum4) 2))) || ((class3.method_0() <= 0.0) || (class3.method_4() != ((Enum4) 2))));
    }

    protected override void PaintImp(RGraphics g)
    {
        if ((this.string_65 != null) && (this.class40_1 == null))
        {
            this.class40_1 = new Class40(base.HtmlContainer, new Delegate3<RImage, RRect, bool>(this.method_35));
            this.class40_1.method_1(this.string_65, (base.HtmlTag != null) ? base.HtmlTag.Attributes : null);
        }
        RRect rect = Class48.smethod_6<CssLineBox, RRect>(base.Rectangles, new RRect());
        RPoint pos = (base.HtmlContainer != null) ? base.HtmlContainer.ScrollOffset : RPoint.Empty;
        rect.Offset(pos);
        bool flag = Class53.smethod_0(g, this);
        base.PaintBackground(g, rect, true, true);
        Class35.smethod_0(g, this, rect, true, true);
        CssRect rect2 = base.Words[0];
        RRect rectangle = rect2.Rectangle;
        rectangle.Offset(pos);
        rectangle.Height -= ((base.ActualBorderTopWidth + base.ActualBorderBottomWidth) + base.ActualPaddingTop) + base.ActualPaddingBottom;
        rectangle.Y += base.ActualBorderTopWidth + base.ActualPaddingTop;
        rectangle.X = Math.Floor(rectangle.X);
        rectangle.Y = Math.Floor(rectangle.Y);
        RRect rect4 = rectangle;
        this.method_31(g, pos, rect4);
        this.method_32(g, rect4);
        this.method_33(g, rect4);
        if (flag)
        {
            g.PopClip();
        }
    }

    internal override void vmethod_0(RGraphics g)
    {
        if (!base._wordsSizeMeasured)
        {
            base.MeasureWordSpacing(g);
            base._wordsSizeMeasured = true;
        }
        Class28.smethod_0(this.class31_0);
    }

    public override string HrefLink
    {
        get
        {
            return (this.string_66 ?? base.GetAttribute("src"));
        }
    }

    public override bool IsClickable
    {
        get
        {
            return true;
        }
    }
}

