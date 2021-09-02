using DSkin.Html.Core.Handlers;
using DSkin.Html.Core.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;

internal sealed class Class38 : IDisposable
{
    private readonly Dictionary<string, List<DownloadFileAsyncCallback>> dictionary_0 = new Dictionary<string, List<DownloadFileAsyncCallback>>();
    private readonly List<WebClient> list_0 = new List<WebClient>();

    public void Dispose()
    {
        this.method_5();
    }

    public void method_0(Uri uri_0, string string_0, bool bool_0, DownloadFileAsyncCallback downloadFileAsyncCallback_0)
    {
        ArgChecker.AssertArgNotNull(uri_0, "imageUri");
        ArgChecker.AssertArgNotNull(downloadFileAsyncCallback_0, "cachedFileCallback");
        bool flag = true;
        lock (this.dictionary_0)
        {
            if (this.dictionary_0.ContainsKey(string_0))
            {
                flag = false;
                this.dictionary_0[string_0].Add(downloadFileAsyncCallback_0);
            }
            else
            {
                List<DownloadFileAsyncCallback> list = new List<DownloadFileAsyncCallback> {
                    downloadFileAsyncCallback_0
                };
                this.dictionary_0[string_0] = list;
            }
        }
        if (flag)
        {
            string tempFileName = Path.GetTempFileName();
            if (bool_0)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.method_2), new Class39(uri_0, tempFileName, string_0));
            }
            else
            {
                this.method_1(uri_0, tempFileName, string_0);
            }
        }
    }

    private void method_1(Uri uri_0, string string_0, string string_1)
    {
        try
        {
            using (WebClient client = new WebClient())
            {
                this.list_0.Add(client);
                client.DownloadFile(uri_0, string_0);
                this.method_4(client, uri_0, string_0, string_1, null, false);
            }
        }
        catch (Exception exception)
        {
            this.method_4(null, uri_0, string_0, string_1, exception, false);
        }
    }

    private void method_2(object object_0)
    {
        Class39 userToken = (Class39) object_0;
        try
        {
            WebClient item = new WebClient();
            this.list_0.Add(item);
            item.DownloadFileCompleted += new AsyncCompletedEventHandler(this.method_3);
            item.DownloadFileAsync(userToken.uri_0, userToken.string_0, userToken);
        }
        catch (Exception exception)
        {
            this.method_4(null, userToken.uri_0, userToken.string_0, userToken.string_1, exception, false);
        }
    }

    private void method_3(object sender, AsyncCompletedEventArgs e)
    {
        Class39 userState = (Class39) e.UserState;
        try
        {
            using (WebClient client = (WebClient) sender)
            {
                client.DownloadFileCompleted -= new AsyncCompletedEventHandler(this.method_3);
                this.method_4(client, userState.uri_0, userState.string_0, userState.string_1, e.Error, e.Cancelled);
            }
        }
        catch (Exception exception)
        {
            this.method_4(null, userState.uri_0, userState.string_0, userState.string_1, exception, false);
        }
    }

    private void method_4(WebClient webClient_0, Uri uri_0, string string_0, string string_1, Exception exception_0, bool bool_0)
    {
        bool flag;
        List<DownloadFileAsyncCallback> list;
        Dictionary<string, List<DownloadFileAsyncCallback>> dictionary;
        object expressionStack_8A_0;
        if (bool_0)
        {
            goto Label_008C;
        }
        if (exception_0 == null)
        {
            int expressionStack_2A_0;
            string str = Class48.smethod_8(webClient_0);
            if (str != null)
            {
                expressionStack_2A_0 = (int) str.StartsWith("image", StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                expressionStack_2A_0 = 0;
            }
            if (expressionStack_2A_0 == 0)
            {
                exception_0 = new Exception("Failed to load image, not image content type: " + str);
            }
        }
        if (exception_0 != null)
        {
            goto Label_008C;
        }
        if (System.IO.File.Exists(string_0))
        {
            try
            {
                System.IO.File.Move(string_0, string_1);
            }
            catch (Exception exception)
            {
                exception_0 = new Exception("Failed to move downloaded image from temp to cache location", exception);
            }
        }
        if (!System.IO.File.Exists(string_1))
        {
            if (exception_0 != null)
            {
                expressionStack_8A_0 = exception_0;
                goto Label_008A;
            }
            else
            {
                Exception expressionStack_7C_0 = exception_0;
            }
            expressionStack_8A_0 = new Exception("Failed to download image, unknown error");
        }
        else
        {
            expressionStack_8A_0 = null;
        }
    Label_008A:
        exception_0 = (Exception) expressionStack_8A_0;
    Label_008C:
        flag = false;
        try
        {
            Monitor.Enter(dictionary = this.dictionary_0, ref flag);
            if (this.dictionary_0.TryGetValue(string_1, out list))
            {
                this.dictionary_0.Remove(string_1);
            }
        }
        finally
        {
            if (flag)
            {
                Monitor.Exit(dictionary);
            }
        }
        if (list != null)
        {
            foreach (DownloadFileAsyncCallback callback in list)
            {
                try
                {
                    callback(uri_0, string_1, exception_0, bool_0);
                }
                catch
                {
                }
            }
        }
    }

    private void method_5()
    {
        this.dictionary_0.Clear();
        while (this.list_0.Count > 0)
        {
            try
            {
                WebClient client = this.list_0[0];
                client.CancelAsync();
                client.Dispose();
                this.list_0.RemoveAt(0);
                continue;
            }
            catch
            {
                continue;
            }
        }
    }

    private sealed class Class39
    {
        public readonly string string_0;
        public readonly string string_1;
        public readonly Uri uri_0;

        public Class39(Uri uri_1, string string_2, string string_3)
        {
            this.uri_0 = uri_1;
            this.string_0 = string_2;
            this.string_1 = string_3;
        }
    }
}

