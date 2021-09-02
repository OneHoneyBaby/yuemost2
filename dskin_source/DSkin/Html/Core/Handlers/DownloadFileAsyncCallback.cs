namespace DSkin.Html.Core.Handlers
{
    using System;
    using System.Runtime.CompilerServices;

    public delegate void DownloadFileAsyncCallback(Uri imageUri, string filePath, Exception error, bool canceled);
}

