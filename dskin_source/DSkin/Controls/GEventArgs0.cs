namespace DSkin.Controls
{
    using System;
    using System.Runtime.CompilerServices;

    public class GEventArgs0 : EventArgs
    {
        [CompilerGenerated]
        private DSkin.Controls.DSkinTabItem dskinTabItem_0;

        public GEventArgs0(DSkin.Controls.DSkinTabItem item)
        {
            this.DSkinTabItem = item;
        }

        public DSkin.Controls.DSkinTabItem DSkinTabItem
        {
            [CompilerGenerated]
            get
            {
                return this.dskinTabItem_0;
            }
            [CompilerGenerated]
            set
            {
                this.dskinTabItem_0 = value;
            }
        }
    }
}

