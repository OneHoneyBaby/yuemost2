namespace DSkin.Forms
{
    using System;
    using System.Runtime.CompilerServices;

    public class SystemButtonMouseClickEventArgs : EventArgs
    {
        [CompilerGenerated]
        private bool bool_0;
        [CompilerGenerated]
        private SystemButton systemButton_0;

        public SystemButtonMouseClickEventArgs(SystemButton button, bool handled)
        {
            this.Button = button;
            this.Handled = handled;
        }

        public SystemButton Button
        {
            [CompilerGenerated]
            get
            {
                return this.systemButton_0;
            }
            [CompilerGenerated]
            set
            {
                this.systemButton_0 = value;
            }
        }

        public bool Handled
        {
            [CompilerGenerated]
            get
            {
                return this.bool_0;
            }
            [CompilerGenerated]
            set
            {
                this.bool_0 = value;
            }
        }
    }
}

