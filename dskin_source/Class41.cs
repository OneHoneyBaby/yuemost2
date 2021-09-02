using DSkin.Html.Core;
using DSkin.Html.Core.Entities;
using DSkin.Html.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

internal static class Class41
{
    public static void smethod_0(HtmlContainerInt htmlContainerInt_0, string string_0, Dictionary<string, string> dictionary_0, out string string_1, out CssData cssData_0)
    {
        ArgChecker.AssertArgNotNull(htmlContainerInt_0, "htmlContainer");
        string_1 = null;
        cssData_0 = null;
        try
        {
            HtmlStylesheetLoadEventArgs args = new HtmlStylesheetLoadEventArgs(string_0, dictionary_0);
            htmlContainerInt_0.method_6(args);
            if (!string.IsNullOrEmpty(args.SetStyleSheet))
            {
                string_1 = args.SetStyleSheet;
            }
            else if (args.SetStyleSheetData != null)
            {
                cssData_0 = args.SetStyleSheetData;
            }
            else if (args.SetSrc != null)
            {
                string_1 = smethod_1(htmlContainerInt_0, args.SetSrc);
            }
            else
            {
                string_1 = smethod_1(htmlContainerInt_0, string_0);
            }
        }
        catch (Exception exception)
        {
            htmlContainerInt_0.method_8(HtmlRenderErrorType.CssParsing, "Exception in handling stylesheet source", exception);
        }
    }

    private static string smethod_1(HtmlContainerInt htmlContainerInt_0, string string_0)
    {
        Uri uri = Class48.smethod_5(string_0);
        if ((uri == null) || (uri.Scheme == "file"))
        {
            return smethod_2(htmlContainerInt_0, (uri != null) ? uri.AbsolutePath : string_0);
        }
        return smethod_3(htmlContainerInt_0, uri);
    }

    private static string smethod_2(HtmlContainerInt htmlContainerInt_0, string string_0)
    {
        FileInfo info = Class48.smethod_7(string_0);
        if (info != null)
        {
            if (info.Exists)
            {
                using (StreamReader reader = new StreamReader(info.FullName))
                {
                    return reader.ReadToEnd();
                }
            }
            htmlContainerInt_0.method_8(HtmlRenderErrorType.CssParsing, "No stylesheet found by path: " + string_0, null);
        }
        else
        {
            htmlContainerInt_0.method_8(HtmlRenderErrorType.CssParsing, "Failed load image, invalid source: " + string_0, null);
        }
        return string.Empty;
    }

    private static string smethod_3(HtmlContainerInt htmlContainerInt_0, Uri uri_0)
    {
        using (WebClient client = new WebClient())
        {
            string str = client.DownloadString(uri_0);
            try
            {
                str = smethod_4(str, uri_0);
            }
            catch (Exception exception)
            {
                htmlContainerInt_0.method_8(HtmlRenderErrorType.CssParsing, "Error in correcting relative URL in loaded stylesheet", exception);
            }
            return str;
        }
    }

    private static string smethod_4(string string_0, Uri uri_0)
    {
        // This item is obfuscated and can not be translated.
        int startIndex = 0;
        while (startIndex < 0)
        {
        Label_0008:
            if (0 == 0)
            {
                return string_0;
            }
            startIndex = string_0.IndexOf("url(", startIndex, StringComparison.OrdinalIgnoreCase);
            if (startIndex >= 0)
            {
                int index = string_0.IndexOf(')', startIndex);
                if (index > (startIndex + 4))
                {
                    Uri uri;
                    int num3 = 4 + ((string_0[startIndex + 4] == '\'') ? 1 : 0);
                    int num2 = (string_0[index - 1] == '\'') ? 1 : 0;
                    if (Uri.TryCreate(string_0.Substring(startIndex + num3, ((index - startIndex) - num3) - num2), UriKind.Relative, out uri))
                    {
                        uri = new Uri(uri_0, uri);
                        string_0 = string_0.Remove(startIndex + 4, (index - startIndex) - 4);
                        string_0 = string_0.Insert(startIndex + 4, uri.AbsoluteUri);
                        startIndex += uri.AbsoluteUri.Length + 4;
                    }
                    else
                    {
                        startIndex = index + 1;
                    }
                }
                else
                {
                    startIndex += 4;
                }
            }
        }
        goto Label_0008;
    }
}

