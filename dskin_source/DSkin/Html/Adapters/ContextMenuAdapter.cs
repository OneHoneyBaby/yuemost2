namespace DSkin.Html.Adapters
{
    using DSkin.Html;
    using DSkin.Html.Adapters.Entities;
    using DSkin.Html.Core.Utils;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public sealed class ContextMenuAdapter : RContextMenu
    {
        private readonly ContextMenuStrip contextMenuStrip_0 = new ContextMenuStrip();

        public ContextMenuAdapter()
        {
            this.contextMenuStrip_0.ShowImageMargin = false;
        }

        public override void AddDivider()
        {
            this.contextMenuStrip_0.Items.Add("-");
        }

        public override void AddItem(string text, bool enabled, EventHandler onClick)
        {
            ArgChecker.AssertArgNotNullOrEmpty(text, "text");
            ArgChecker.AssertArgNotNull(onClick, "onClick");
            this.contextMenuStrip_0.Items.Add(text, null, onClick).Enabled = enabled;
        }

        public override void Dispose()
        {
            this.contextMenuStrip_0.Dispose();
        }

        public override void RemoveLastDivider()
        {
            if (this.contextMenuStrip_0.Items[this.contextMenuStrip_0.Items.Count - 1].Text == string.Empty)
            {
                this.contextMenuStrip_0.Items.RemoveAt(this.contextMenuStrip_0.Items.Count - 1);
            }
        }

        public override void Show(RControl parent, RPoint location)
        {
            if (parent is ControlAdapter)
            {
                this.contextMenuStrip_0.Show(((ControlAdapter) parent).Control, Utils.ConvertRound(location));
            }
            else if (parent is DuiControlAdapter)
            {
                Point locationToScreen = ((DuiControlAdapter) parent).DuiControl.LocationToScreen;
                this.contextMenuStrip_0.Show(new Point(locationToScreen.X + ((int) location.X), locationToScreen.Y + ((int) location.Y)));
            }
        }

        public override int ItemsCount
        {
            get
            {
                return this.contextMenuStrip_0.Items.Count;
            }
        }
    }
}

