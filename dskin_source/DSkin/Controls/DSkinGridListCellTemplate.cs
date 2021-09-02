namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.Threading;

    public class DSkinGridListCellTemplate : DuiBaseControl
    {
        internal DSkin.Controls.DSkinGridListCell dskinGridListCell_0;
        private object object_38;

        public event EventHandler ValueChanged;

        public object Eval(string dataField)
        {
            return DSkin.Controls.DSkinGridList.GetItemData(this.dskinGridListCell_0.dskinGridListRow_0.RowData, dataField);
        }

        public T Eval<T>(string dataField)
        {
            return (T) DSkin.Controls.DSkinGridList.GetItemData(this.dskinGridListCell_0.dskinGridListRow_0.RowData, dataField);
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        protected DSkin.Controls.DSkinGridList DSkinGridList
        {
            get
            {
                return (this.HostControl as DSkin.Controls.DSkinGridList);
            }
        }

        protected DSkin.Controls.DSkinGridListCell DSkinGridListCell
        {
            get
            {
                return this.dskinGridListCell_0;
            }
        }

        public object Value
        {
            get
            {
                return this.object_38;
            }
            set
            {
                if (this.object_38 != value)
                {
                    this.object_38 = value;
                    this.OnValueChanged(EventArgs.Empty);
                }
            }
        }
    }
}

