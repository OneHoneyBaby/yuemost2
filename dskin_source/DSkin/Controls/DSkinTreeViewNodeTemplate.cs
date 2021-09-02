namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;

    public class DSkinTreeViewNodeTemplate : DuiBaseControl
    {
        private bool bool_27 = true;
        private DSkinTreeViewNode dskinTreeViewNode_0;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool AutoOffset
        {
            get
            {
                return this.bool_27;
            }
            set
            {
                this.bool_27 = value;
            }
        }

        public DSkinTreeViewNode Node
        {
            get
            {
                return this.dskinTreeViewNode_0;
            }
            internal set
            {
                this.dskinTreeViewNode_0 = value;
            }
        }
    }
}

