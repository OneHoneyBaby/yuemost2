namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;

    public class DSkinListItemTemplate : DuiBaseControl
    {
        internal object object_38;

        public object Eval(string dataField)
        {
            return DSkinGridList.GetItemData(this.object_38, dataField);
        }

        protected DSkin.Controls.DSkinListBox DSkinListBox
        {
            get
            {
                return (this.HostControl as DSkin.Controls.DSkinListBox);
            }
        }

        public object RowData
        {
            get
            {
                return this.object_38;
            }
        }
    }
}

