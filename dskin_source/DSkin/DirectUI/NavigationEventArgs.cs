namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;

    public class NavigationEventArgs : EventArgs
    {
        [CompilerGenerated]
        private string string_0;
        [CompilerGenerated]
        private wkeNavigationAction wkeNavigationAction_0;
        [CompilerGenerated]
        private DSkin.DirectUI.wkeNavigationType wkeNavigationType_0;

        public wkeNavigationAction NavigationAction
        {
            [CompilerGenerated]
            get
            {
                return this.wkeNavigationAction_0;
            }
            [CompilerGenerated]
            set
            {
                this.wkeNavigationAction_0 = value;
            }
        }

        public DSkin.DirectUI.wkeNavigationType NavigationType
        {
            [CompilerGenerated]
            get
            {
                return this.wkeNavigationType_0;
            }
            [CompilerGenerated]
            set
            {
                this.wkeNavigationType_0 = value;
            }
        }

        public string Url
        {
            [CompilerGenerated]
            get
            {
                return this.string_0;
            }
            [CompilerGenerated]
            set
            {
                this.string_0 = value;
            }
        }
    }
}

