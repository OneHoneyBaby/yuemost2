namespace DSkin.DirectUI
{
    using System;

    public class DuiControlEventArgs : EventArgs
    {
        private DuiBaseControl duiBaseControl_0;

        public DuiControlEventArgs(DuiBaseControl control)
        {
            this.duiBaseControl_0 = control;
        }

        public DuiBaseControl Control
        {
            get
            {
                return this.duiBaseControl_0;
            }
            set
            {
                this.duiBaseControl_0 = value;
            }
        }
    }
}

