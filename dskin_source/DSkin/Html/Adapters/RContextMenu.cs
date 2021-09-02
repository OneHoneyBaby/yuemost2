namespace DSkin.Html.Adapters
{
    using DSkin.Html.Adapters.Entities;
    using System;

    public abstract class RContextMenu : IDisposable
    {
        protected RContextMenu()
        {
        }

        public abstract void AddDivider();
        public abstract void AddItem(string text, bool enabled, EventHandler onClick);
        public abstract void Dispose();
        public abstract void RemoveLastDivider();
        public abstract void Show(RControl parent, RPoint location);

        public abstract int ItemsCount { get; }
    }
}

