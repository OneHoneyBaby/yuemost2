namespace DSkin.Html.Adapters
{
    using DSkin.Html.Adapters.Entities;
    using DSkin.Html.Core.Utils;
    using System;
    using System.Runtime.InteropServices;

    public abstract class RControl
    {
        private readonly RAdapter oPlfuExZca;

        protected RControl(RAdapter adapter)
        {
            ArgChecker.AssertArgNotNull(adapter, "adapter");
            this.oPlfuExZca = adapter;
        }

        public abstract void DoDragDropCopy(object dragDropData);
        public abstract void Invalidate();
        public abstract void MeasureString(string str, RFont font, double maxWidth, out int charFit, out double charFitWidth);
        public abstract void SetCursorDefault();
        public abstract void SetCursorHand();
        public abstract void SetCursorIBeam();

        public RAdapter Adapter
        {
            get
            {
                return this.oPlfuExZca;
            }
        }

        public abstract bool LeftMouseButton { get; }

        public abstract RPoint MouseLocation { get; }

        public abstract bool RightMouseButton { get; }
    }
}

