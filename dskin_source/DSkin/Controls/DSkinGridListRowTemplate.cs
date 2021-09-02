namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;

    public class DSkinGridListRowTemplate : DuiBaseControl
    {
        internal DSkin.Controls.DSkinGridListRow dskinGridListRow_0;
        internal object object_38;

        public object Eval(string dataField)
        {
            return DSkin.Controls.DSkinGridList.GetItemData(this.object_38, dataField);
        }

        public T Eval<T>(string dataField)
        {
            return (T) DSkin.Controls.DSkinGridList.GetItemData(this.object_38, dataField);
        }

        protected DSkin.Controls.DSkinGridList DSkinGridList
        {
            get
            {
                return (this.HostControl as DSkin.Controls.DSkinGridList);
            }
        }

        protected DSkin.Controls.DSkinGridListRow DSkinGridListRow
        {
            get
            {
                return this.dskinGridListRow_0;
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

