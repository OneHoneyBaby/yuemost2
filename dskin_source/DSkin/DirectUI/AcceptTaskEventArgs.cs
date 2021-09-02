namespace DSkin.DirectUI
{
    using System;
    using System.Runtime.CompilerServices;

    public class AcceptTaskEventArgs : EventArgs
    {
        private bool bool_0 = false;
        private DuiBaseControl duiBaseControl_0;
        private object object_0;
        internal object object_1;
        [CompilerGenerated]
        private object object_2;
        private string string_0;

        public AcceptTaskEventArgs(DuiBaseControl source, string name, object data)
        {
            this.duiBaseControl_0 = source;
            this.string_0 = name;
            this.object_0 = data;
        }

        public object Data
        {
            get
            {
                return this.object_0;
            }
        }

        public bool Handled
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        public object Result
        {
            [CompilerGenerated]
            get
            {
                return this.object_2;
            }
            [CompilerGenerated]
            set
            {
                this.object_2 = value;
            }
        }

        public DuiBaseControl Source
        {
            get
            {
                return this.duiBaseControl_0;
            }
        }

        public string TaskName
        {
            get
            {
                return this.string_0;
            }
        }
    }
}

