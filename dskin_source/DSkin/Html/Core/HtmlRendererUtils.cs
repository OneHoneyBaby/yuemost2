namespace DSkin.Html.Core
{
    using DSkin.Html.Adapters;
    using DSkin.Html.Adapters.Entities;
    using System;

    public static class HtmlRendererUtils
    {
        public static RSize Layout(RGraphics g, HtmlContainerInt htmlContainer, RSize size, RSize minSize, RSize maxSize, bool autoSize, bool autoSizeHeightOnly)
        {
            if (autoSize)
            {
                htmlContainer.MaxSize = new RSize(0.0, 0.0);
            }
            else if (autoSizeHeightOnly)
            {
                htmlContainer.MaxSize = new RSize(size.Width, 0.0);
            }
            else
            {
                htmlContainer.MaxSize = size;
            }
            htmlContainer.PerformLayout(g);
            RSize size2 = size;
            if (autoSize || autoSizeHeightOnly)
            {
                if (autoSize)
                {
                    if ((maxSize.Width > 0.0) && (maxSize.Width < htmlContainer.ActualSize.Width))
                    {
                        htmlContainer.MaxSize = maxSize;
                        htmlContainer.PerformLayout(g);
                    }
                    else if ((minSize.Width > 0.0) && (minSize.Width > htmlContainer.ActualSize.Width))
                    {
                        htmlContainer.MaxSize = new RSize(minSize.Width, 0.0);
                        htmlContainer.PerformLayout(g);
                    }
                    return htmlContainer.ActualSize;
                }
                if (Math.Abs((double) (size.Height - htmlContainer.ActualSize.Height)) > 0.01)
                {
                    double width = size.Width;
                    size2.Height = ((minSize.Height <= 0.0) || (minSize.Height <= htmlContainer.ActualSize.Height)) ? htmlContainer.ActualSize.Height : minSize.Height;
                    if (Math.Abs((double) (width - size.Width)) > 0.01)
                    {
                        return Layout(g, htmlContainer, size, minSize, maxSize, false, true);
                    }
                }
            }
            return size2;
        }

        public static RSize MeasureHtmlByRestrictions(RGraphics g, HtmlContainerInt htmlContainer, RSize minSize, RSize maxSize)
        {
            htmlContainer.PerformLayout(g);
            if ((maxSize.Width > 0.0) && (maxSize.Width < htmlContainer.ActualSize.Width))
            {
                htmlContainer.MaxSize = new RSize(maxSize.Width, 0.0);
                htmlContainer.PerformLayout(g);
            }
            double width = Math.Max((maxSize.Width > 0.0) ? Math.Min(maxSize.Width, (double) ((int) htmlContainer.ActualSize.Width)) : ((double) ((int) htmlContainer.ActualSize.Width)), minSize.Width);
            if (width > htmlContainer.ActualSize.Width)
            {
                htmlContainer.MaxSize = new RSize(width, 0.0);
                htmlContainer.PerformLayout(g);
            }
            return new RSize(width, Math.Max((maxSize.Height > 0.0) ? Math.Min(maxSize.Height, (double) ((int) htmlContainer.ActualSize.Height)) : ((double) ((int) htmlContainer.ActualSize.Height)), minSize.Height));
        }
    }
}

