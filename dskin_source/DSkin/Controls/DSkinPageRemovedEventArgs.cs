namespace DSkin.Controls
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class DSkinPageRemovedEventArgs : EventArgs
    {
        [CompilerGenerated]
        private bool bool_0;
        [CompilerGenerated]
        private TabPage tabPage_0;

        public DSkinPageRemovedEventArgs(TabPage page)
        {
            this.Page = page;
            this.Handled = false;
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

        public TabPage Page
        {
            [CompilerGenerated]
            get
            {
                return this.tabPage_0;
            }
            [CompilerGenerated]
            set
            {
                this.tabPage_0 = value;
            }
        }
    }
}

