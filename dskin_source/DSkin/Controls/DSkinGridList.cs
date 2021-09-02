namespace DSkin.Controls
{
    using DSkin.Common;
    using DSkin.DirectUI;
    using DSkin.DirectUI.Transform;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(DataGridView)), Designer("DSkin.Design.DSkinGridListDesigner,DSkin.Design, Version=16.4.2.6, Culture=neutral, PublicKeyToken=null")]
    public class DSkinGridList : DSkinBaseControl, ISupportInitialize
    {
        private bool bool_0 = true;
        private bool bool_1 = false;
        private bool bool_2 = true;
        private bool bool_3 = true;
        private bool bool_4 = false;
        private bool bool_5 = false;
        private bool bool_6 = true;
        private Collection<DSkinGridListRow> collection_0;
        private Collection<GClass2> collection_1;
        private Color color_0 = Color.Black;
        private Color color_1 = Color.Transparent;
        private Color color_2 = Color.FromArgb(0xf5, 0xf5, 0xf5);
        private Color color_3 = Color.LightGoldenrodYellow;
        private Color color_4 = Color.LightGoldenrodYellow;
        private Color color_5 = Color.Silver;
        private ContextMenuStrip contextMenuStrip_0;
        private DSkinBrush dskinBrush_0;
        private DSkinBrush dskinBrush_1;
        private DSkinBrush dskinBrush_2;
        private static DSkinLinearGradientBrush dskinLinearGradientBrush_0;
        private static DSkinLinearGradientBrush dskinLinearGradientBrush_1;
        private static DSkinLinearGradientBrush dskinLinearGradientBrush_2;
        private DuiBaseControl duiBaseControl_1;
        private DuiListBox duiListBox_0;
        private DuiScrollBar duiScrollBar_0;
        private Enum0 enum0_0;
        private Font font_0 = new Font("微软雅黑", 9f);
        private GridLineShowModes gridLineShowModes_0 = GridLineShowModes.All;
        private IContainer icontainer_0 = null;
        private IList ilist_0;
        private int int_0 = 30;
        private int int_1 = 30;
        private int int_2 = 100;
        private int int_3 = 1;
        private int int_4 = 0;
        private List<DSkinGridListRow> list_0;
        private object object_0;
        private DSkin.Controls.PageControl pageControl_0;
        private Point point_0;
        private Point point_1;
        private string string_0 = string.Empty;
        private System.Type type_0;

        public event EventHandler DataSourceChanged;

        [Description("鼠标左键单击Item项时触发的事件"), Category("DSkinGridList自定义事件")]
        public event EventHandler<DSkinGridListMouseEventArgs> ItemClick;

        [Description("双击Item项时触发的事件"), Category("DSkinGridList自定义事件")]
        public event EventHandler<DSkinGridListMouseEventArgs> ItemDoubleClick;

        public event EventHandler PageIndexChanged;

        public event EventHandler<DSkinGridListEventArgs> SelectedItemChanged;

        public DSkinGridList()
        {
            this.method_18();
            this.BackColor = Color.White;
            base.Borders.AllColor = this.GridLineColor;
            base.InnerDuiControl.Controls.Add(this.InnerColumnHeadBaseControl);
            base.InnerDuiControl.Controls.Add(this.InnerListBox);
            base.InnerDuiControl.Controls.Add(this.PageControl);
            base.InnerDuiControl.Controls.Add(this.DuiScrollBar_0);
            this.ColumnHeaderBrush = DSkinGridListDefaultColumnHeaderBrush;
            this.ColumnHeaderHoverBrush = DSkinGridListDefaultColumnHeaderHoverBrush;
            this.ColumnHeaderPressBrush = DSkinGridListDefaultColumnHeaderPressBrush;
        }

        public void BeginInit()
        {
        }

        public void DataBind()
        {
            if (this.object_0 != null)
            {
                if (!((this.int_3 == 1) || this.bool_5))
                {
                    this.int_3 = 1;
                    this.OnPageIndexChanged(EventArgs.Empty);
                }
                this.Rows.Clear();
                DataSet set = this.object_0 as DataSet;
                if (!(string.IsNullOrEmpty(this.string_0) || (set == null)))
                {
                    this.ilist_0 = ((IListSource) set.Tables[this.string_0]).GetList();
                }
                else
                {
                    IListSource source = this.object_0 as IListSource;
                    if (source != null)
                    {
                        this.ilist_0 = source.GetList();
                    }
                    else
                    {
                        this.ilist_0 = this.object_0 as IList;
                    }
                }
            }
            this.LayoutContent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.icontainer_0 != null))
            {
                this.icontainer_0.Dispose();
            }
            this.Columns.Clear();
            this.Rows.Clear();
            base.Dispose(disposing);
        }

        public void EndInit()
        {
            this.LayoutContent();
        }

        public static object GetItemData(object item, string dataField)
        {
            try
            {
                System.Type type;
                if (!(!(item is IDataRecord) || string.IsNullOrEmpty(dataField)))
                {
                    return ((IDataRecord) item)[dataField];
                }
                if (!(!(item is DataRowView) || string.IsNullOrEmpty(dataField)))
                {
                    return ((DataRowView) item)[dataField];
                }
                if ((!(type = item.GetType()).IsValueType && !(item is string)) && !string.IsNullOrEmpty(dataField))
                {
                    PropertyInfo property = type.GetProperty(dataField);
                    if (property != null)
                    {
                        return property.GetValue(item, null);
                    }
                    return null;
                }
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void LayoutContent()
        {
            int num2;
            foreach (GClass2 class2 in this.Columns)
            {
                class2.OrderMode = OrderModes.None;
            }
            if (this.EnablePage)
            {
                int count = this.duiListBox_0.Items.Count;
                for (num2 = 0; num2 < count; num2++)
                {
                    ((DSkinGridListRow) this.duiListBox_0.Items[0].Tag).DestroyItem();
                }
            }
            int pageIndex = this.PageIndex;
            int num3 = this.bool_5 ? ((this.ilist_0 == null) ? 0 : this.ilist_0.Count) : this.RowCount;
            if (this.bool_5)
            {
                pageIndex = 1;
            }
            if (this.ilist_0 != null)
            {
                this.Rows.Clear();
                bool flag = false;
                for (num2 = (pageIndex - 1) * this.PageSize; num2 < num3; num2++)
                {
                    DSkinGridListRow row;
                    if (this.bool_6 && (num2 >= (((pageIndex - 1) * this.PageSize) + this.PageSize)))
                    {
                        break;
                    }
                    if (this.type_0 == null)
                    {
                        row = new DSkinGridListRow(this.ilist_0[num2]);
                        for (int i = 0; i < this.collection_1.Count; i++)
                        {
                            GClass2 class3 = this.collection_1[i];
                            DSkinGridListCell cell = new DSkinGridListCell(GetItemData(this.ilist_0[num2], class3.DataPropertyName), class3.CellTemplate, this.ForeColor, this.Font) {
                                DockStyle = class3.DockStyle,
                                ItemType = class3.ItemType
                            };
                            row.Cells.Add(cell);
                        }
                    }
                    else
                    {
                        row = new DSkinGridListRow(this.type_0, this.ilist_0[num2]);
                    }
                    row.Height = this.int_0;
                    this.collection_0.Add(row);
                    this.duiListBox_0.Items.Add(row.RowControl);
                    row.RowControl.BackColor = flag ? this.DoubleItemsBackColor : this.SingleItemsBackColor;
                    flag = !flag;
                }
            }
            if (this.ilist_0 == null)
            {
                this.duiListBox_0.Items.Clear();
                for (num2 = (pageIndex - 1) * this.PageSize; num2 < this.Rows.Count; num2++)
                {
                    if (this.bool_6 && (num2 >= (((pageIndex - 1) * this.PageSize) + this.PageSize)))
                    {
                        break;
                    }
                    DuiBaseControl rowControl = this.Rows[num2].RowControl;
                    this.duiListBox_0.Items.Add(rowControl);
                    rowControl.BackColor = ((this.duiListBox_0.Items.IndexOf(rowControl) % 2) != 0) ? this.DoubleItemsBackColor : this.SingleItemsBackColor;
                }
            }
            this.pageControl_0.ShowPageinfo();
        }

        private void method_10(object sender, CollectionEventArgs<DSkinGridListRow> e)
        {
            DuiBaseControl rowControl = e.Item.RowControl;
            this.duiListBox_0.Items.Remove(rowControl);
            this.SelectedItems.Remove(e.Item);
            if (this.object_0 == null)
            {
                base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
            }
        }

        private void method_11(object sender, CollectionEventArgs<DSkinGridListRow> e)
        {
            if (this.object_0 == null)
            {
                base.InnerDuiControl.ManagedTask(new Action(this, (IntPtr) this.LayoutContent));
            }
        }

        private void method_12()
        {
            int x = -this.DuiScrollBar_0.Value;
            for (int i = 0; i < this.Columns.Count; i++)
            {
                if (this.Columns[i].Visble)
                {
                    this.Columns[i].Item.Height = this.duiBaseControl_1.Height;
                    this.Columns[i].Item.Location = new Point(x, 0);
                    x += this.Columns[i].Width;
                }
            }
            base.Invalidate();
        }

        private void method_13()
        {
            int num = 1;
            for (int i = 0; i < this.Columns.Count; i++)
            {
                if (this.Columns[i].Visble)
                {
                    num += this.Columns[i].Width;
                }
            }
            if (base.Width >= num)
            {
                this.DuiScrollBar_0.Visible = false;
                this.DuiScrollBar_0.Width = base.Width;
                this.DuiScrollBar_0.Value = 0;
            }
            else
            {
                this.DuiScrollBar_0.Visible = true;
                this.DuiScrollBar_0.Width = base.Width;
                this.DuiScrollBar_0.Maximum = num - base.Width;
                this.DuiScrollBar_0.Minimum = 0;
                int num3 = ((int) (((1.0 * base.Width) / (1.0 * num)) * this.DuiScrollBar_0.Width)) - (this.DuiScrollBar_0.ArrowHeight * 2);
                this.DuiScrollBar_0.ScrollBarLenght = (num3 < 10) ? 10 : num3;
                this.DuiScrollBar_0.Location = new Point(0, (base.Height - this.duiScrollBar_0.Height) - (this.bool_6 ? this.pageControl_0.Height : 0));
            }
            this.duiListBox_0.Height = ((base.Height - this.duiBaseControl_1.Height) - (this.bool_6 ? this.pageControl_0.Height : 0)) - (this.DuiScrollBar_0.Visible ? this.DuiScrollBar_0.Height : 1);
        }

        private void method_14(object sender, DuiMouseEventArgs e)
        {
            ((DuiLabel) sender).BackgroundRender.BackgroundBrush = this.dskinBrush_1;
            if (this.bool_3)
            {
                this.point_0.X = e.X;
                this.point_0.Y = e.Y;
                this.point_1.X = e.X;
                this.point_1.Y = e.Y;
            }
        }

        private void method_15(object sender, EventArgs e)
        {
            ((DuiLabel) sender).BackgroundRender.BackgroundBrush = null;
            ((DuiLabel) sender).Borders.RightColor = Color.Transparent;
            this.enum0_0 = (Enum0) 0;
            ((DuiLabel) sender).Cursor = Cursors.Arrow;
        }

        private Enum0 method_16(Size size_0, MouseEventArgs mouseEventArgs_0)
        {
            if (((((mouseEventArgs_0.X >= -10) | (mouseEventArgs_0.X <= size_0.Width)) | (mouseEventArgs_0.Y >= -10)) | (mouseEventArgs_0.Y <= size_0.Height)) && (mouseEventArgs_0.X >= 10))
            {
                if (mouseEventArgs_0.X > (-10 + size_0.Width))
                {
                    return (Enum0) 1;
                }
                return (Enum0) 9;
            }
            return (Enum0) 0;
        }

        private void method_17(object sender, MouseEventArgs e)
        {
            DuiLabel label = sender as DuiLabel;
            int minWidth = (label.Tag as GClass2).MinWidth;
            int maxWidth = (label.Tag as GClass2).MaxWidth;
            label.BackgroundRender.BackgroundBrush = this.dskinBrush_0;
            if (this.bool_3)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (this.enum0_0 == ((Enum0) 1))
                    {
                        label.Width = (label.Width + e.X) - this.point_1.X;
                        this.point_1.X = e.X;
                        this.point_1.Y = e.Y;
                    }
                    if (label.Width < minWidth)
                    {
                        label.Width = minWidth;
                    }
                    if ((label.Width > maxWidth) && (maxWidth > 0))
                    {
                        label.Width = maxWidth;
                    }
                }
                else
                {
                    this.enum0_0 = this.method_16(label.Size, e);
                    Enum0 enum2 = this.enum0_0;
                    if (enum2 != ((Enum0) 1))
                    {
                        if (enum2 != ((Enum0) 9))
                        {
                            label.Borders.RightColor = Color.Transparent;
                        }
                        else
                        {
                            label.Borders.RightColor = Color.Transparent;
                            label.Cursor = Cursors.Arrow;
                        }
                    }
                    else
                    {
                        label.Borders.RightColor = Color.DodgerBlue;
                        label.Cursor = Cursors.SizeWE;
                    }
                }
            }
        }

        private void method_18()
        {
            this.icontainer_0 = new Container();
        }

        [CompilerGenerated]
        private void method_19(object sender, EventArgs e)
        {
            this.method_12();
            this.method_13();
            base.Invalidate();
        }

        [CompilerGenerated]
        private void method_20(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(this.color_5))
            {
                Graphics graphics = e.Graphics;
                if (this.gridLineShowModes_0 != GridLineShowModes.None)
                {
                    if (this.gridLineShowModes_0 != GridLineShowModes.Horizontal)
                    {
                        int num2 = 0;
                        for (int i = 0; i < this.Columns.Count; i++)
                        {
                            if (this.Columns[i].Visble)
                            {
                                num2 = (this.Columns[i].Item.Left + this.Columns[i].Width) + this.duiBaseControl_1.Left;
                                graphics.DrawLine(pen, num2, 0, num2, this.duiBaseControl_1.Height);
                            }
                        }
                    }
                    if (this.gridLineShowModes_0 != GridLineShowModes.Vertical)
                    {
                        graphics.DrawLine(pen, 0, this.duiBaseControl_1.Height - 1, base.Width, this.duiBaseControl_1.Height - 1);
                    }
                }
            }
        }

        [CompilerGenerated]
        private void method_21(object sender, KeyEventArgs e)
        {
            if ((e.Control && (e.KeyCode == Keys.A)) && this.bool_0)
            {
                this.SelectedItems.Clear();
                for (int i = 0; i < this.InnerListBox.Items.Count; i++)
                {
                    DSkinGridListRow tag = (DSkinGridListRow) this.InnerListBox.Items[i].Tag;
                    tag.IsSelected = true;
                    this.SelectedItems.Add(tag);
                }
            }
        }

        [CompilerGenerated]
        private void method_22(object sender, DuiControlEventArgs e)
        {
            e.Control.MouseDoubleClick += new EventHandler<DuiMouseEventArgs>(this.method_9);
            e.Control.MouseDown += new EventHandler<DuiMouseEventArgs>(this.method_8);
        }

        [CompilerGenerated]
        private void method_23(object sender, DuiControlEventArgs e)
        {
            e.Control.MouseDoubleClick -= new EventHandler<DuiMouseEventArgs>(this.method_9);
            e.Control.MouseDown -= new EventHandler<DuiMouseEventArgs>(this.method_8);
        }

        [CompilerGenerated]
        private void method_24(object sender, EventArgs e)
        {
            this.method_12();
        }

        private void method_6(object sender, CollectionEventArgs<GClass2> e)
        {
            this.duiBaseControl_1.Controls.Remove(e.Item.Item);
            this.method_12();
        }

        private void method_7(object sender, CollectionEventArgs<GClass2> e)
        {
            <>c__DisplayClasse classe;
            e.Item.Item.Height = this.duiBaseControl_1.Height;
            e.Item.Item.Font = this.font_0;
            e.Item.Item.ForeColor = this.color_0;
            e.Item.Item.SizeChanged += new EventHandler(classe.<_columns_ItemAdded>b__a);
            e.Item.Item.VisibleChanged += new EventHandler(this.method_19);
            e.Item.Item.MouseUp += new EventHandler<DuiMouseEventArgs>(classe.<_columns_ItemAdded>b__d);
            e.Item.Item.MouseDown += new EventHandler<DuiMouseEventArgs>(this.method_14);
            e.Item.Item.MouseMove += new EventHandler<DuiMouseEventArgs>(this.method_17);
            e.Item.Item.MouseLeave += new EventHandler(this.method_15);
            this.duiBaseControl_1.Controls.Add(e.Item.Item);
            this.method_12();
            this.method_13();
        }

        private void method_8(object sender, DuiMouseEventArgs e)
        {
            if (((DuiBaseControl) sender).Tag is DSkinGridListRow)
            {
                DSkinGridListRow row;
                DSkinGridListRow tag = (DSkinGridListRow) ((DuiBaseControl) sender).Tag;
                if (this.bool_0)
                {
                    if ((tag.IsSelected && (e.Button == MouseButtons.Right)) && (this.GridListContextMenuStrip != null))
                    {
                        this.GridListContextMenuStrip.Show(Control.MousePosition);
                        return;
                    }
                    tag.IsSelected = true;
                }
                DSkinGridListEventArgs args = new DSkinGridListEventArgs(tag);
                int num2 = 0;
                int num3 = e.X + this.DuiScrollBar_0.Value;
                int num = 0;
                while (num < this.Columns.Count)
                {
                    if (this.Columns[num].Visble)
                    {
                        if ((num2 <= num3) && (num3 < (num2 + this.Columns[num].Width)))
                        {
                            args.CellIndex = num;
                            break;
                        }
                        num2 += this.Columns[num].Width;
                    }
                    num++;
                }
                if ((Control.ModifierKeys == Keys.Control) && this.bool_0)
                {
                    row = (DSkinGridListRow) ((DuiBaseControl) sender).Tag;
                    if (this.SelectedItems.IndexOf(row) >= 0)
                    {
                        this.SelectedItems[this.SelectedItems.IndexOf(row)].IsSelected = false;
                        this.SelectedItems.Remove(row);
                    }
                    else
                    {
                        row.IsSelected = true;
                        this.SelectedItems.Add(row);
                    }
                }
                else
                {
                    bool flag;
                    if ((Control.ModifierKeys == Keys.Shift) && this.bool_0)
                    {
                        if ((this.SelectedItem != null) || (this.SelectedItems.Count != 0))
                        {
                            int num4 = (this.SelectedItems.Count > 0) ? this.duiListBox_0.Items.IndexOf(this.SelectedItems[0].RowControl) : this.duiListBox_0.Items.IndexOf(this.SelectedItem.RowControl);
                            int index = this.duiListBox_0.Items.IndexOf(((DSkinGridListRow) ((DuiBaseControl) sender).Tag).RowControl);
                            for (num = 0; num < this.SelectedItems.Count; num++)
                            {
                                this.SelectedItems[num].IsSelected = false;
                            }
                            this.SelectedItems.Clear();
                            if (index > num4)
                            {
                                for (num = num4; num <= index; num++)
                                {
                                    row = (DSkinGridListRow) this.duiListBox_0.Items[num].Tag;
                                    row.IsSelected = true;
                                    this.SelectedItems.Add(row);
                                }
                            }
                            else
                            {
                                num = num4;
                                while (num >= index)
                                {
                                    row = (DSkinGridListRow) this.duiListBox_0.Items[num].Tag;
                                    row.IsSelected = true;
                                    this.SelectedItems.Add(row);
                                    num--;
                                }
                            }
                            this.duiListBox_0.LayoutContent();
                        }
                        else
                        {
                            flag = false;
                            if (this.SelectedItem != tag)
                            {
                                flag = true;
                            }
                            this.SelectedItems.Add(tag);
                            if (flag)
                            {
                                this.OnSelectedItemChanged(args);
                            }
                        }
                    }
                    else
                    {
                        if (this.bool_0)
                        {
                            for (num = 0; num < this.SelectedItems.Count; num++)
                            {
                                this.SelectedItems[num].IsSelected = false;
                            }
                            this.SelectedItems.Clear();
                            if (this.SelectedItem != null)
                            {
                                this.SelectedItem.IsSelected = false;
                            }
                            flag = false;
                            if (this.SelectedItem != tag)
                            {
                                this.SelectedItem = tag;
                                flag = true;
                            }
                            this.SelectedItem.IsSelected = true;
                            if (flag)
                            {
                                this.OnSelectedItemChanged(args);
                            }
                        }
                        if ((this.GridListContextMenuStrip != null) && (e.Button == MouseButtons.Right))
                        {
                            this.GridListContextMenuStrip.Show(Control.MousePosition);
                        }
                        this.OnItemClick(new DSkinGridListMouseEventArgs(e, args.Item, args.CellIndex));
                    }
                }
            }
        }

        private void method_9(object sender, DuiMouseEventArgs e)
        {
            DSkinGridListRow tag = (DSkinGridListRow) ((DuiBaseControl) sender).Tag;
            DSkinGridListEventArgs args = new DSkinGridListEventArgs(tag);
            int num = 0;
            for (int i = 0; i < this.Columns.Count; i++)
            {
                if ((num <= e.X) && (e.X < (num + this.Columns[i].Width)))
                {
                    args.CellIndex = i;
                    break;
                }
                num += this.Columns[i].Width;
            }
            this.OnItemDoubleClick(new DSkinGridListMouseEventArgs(e, args.Item, args.CellIndex));
        }

        protected virtual void OnDataSourceChanged(EventArgs e)
        {
            if (this.eventHandler_5 != null)
            {
                this.eventHandler_5(this, e);
            }
        }

        protected virtual void OnItemClick(DSkinGridListMouseEventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        protected virtual void OnItemDoubleClick(DSkinGridListMouseEventArgs e)
        {
            if (this.eventHandler_3 != null)
            {
                this.eventHandler_3(this, e);
            }
        }

        protected virtual void OnPageIndexChanged(EventArgs e)
        {
            if (this.eventHandler_6 != null)
            {
                this.eventHandler_6(this, e);
            }
        }

        [Category("DSkinGridList自定义事件"), Description("单选择项改变时触发事件")]
        protected virtual void OnSelectedItemChanged(DSkinGridListEventArgs e)
        {
            if (this.eventHandler_4 != null)
            {
                this.eventHandler_4(this, e);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (this.ColumnFill)
            {
                int num2;
                int num = 0;
                for (num2 = 0; num2 < this.Columns.Count; num2++)
                {
                    if (this.Columns[num2].Visble)
                    {
                        num++;
                    }
                }
                int num3 = (base.Width - 1) / ((num > 0) ? num : 1);
                for (num2 = 0; num2 < this.Columns.Count; num2++)
                {
                    this.Columns[num2].Width = num3;
                }
                if (this.Columns.Count > 1)
                {
                    this.Columns[this.Columns.Count - 1].Width = (base.Width - (num3 * (num - 1))) - 1;
                }
                this.DuiScrollBar_0.Value = 0;
                this.method_12();
            }
            this.method_13();
            base.OnSizeChanged(e);
        }

        [DefaultValue(typeof(Color), "White")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        [Category("分页控件属性"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("分页控件上一页按钮属性设置")]
        public DuiButton BackPageButton
        {
            get
            {
                return this.pageControl_0.BtnBackPage;
            }
        }

        [DefaultValue(true), Category("DSkin"), Description("是否可以选中行")]
        public bool CanSelectRow
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

        [Category("DSkin"), Description("是否整行铺满"), DefaultValue(false)]
        public bool ColumnFill
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                if (this.bool_1 != value)
                {
                    this.bool_1 = value;
                    if (this.bool_1)
                    {
                        int num;
                        int num3 = 0;
                        for (num = 0; num < this.Columns.Count; num++)
                        {
                            if (this.Columns[num].Visble)
                            {
                                num3++;
                            }
                        }
                        int num2 = (base.Width - 1) / ((num3 > 0) ? num3 : 1);
                        for (num = 0; num < this.Columns.Count; num++)
                        {
                            this.Columns[num].Width = num2;
                        }
                        if (this.Columns.Count > 1)
                        {
                            this.Columns[this.Columns.Count - 1].Width = (base.Width - (num2 * (num3 - 1))) - 1;
                        }
                        this.DuiScrollBar_0.Value = 0;
                        this.method_12();
                        this.method_13();
                    }
                }
            }
        }

        [DefaultValue((string) null), Description("头部刷子"), Category("DSkin美化属性")]
        public DSkinBrush ColumnHeaderBrush
        {
            get
            {
                return this.dskinBrush_2;
            }
            set
            {
                if (this.dskinBrush_2 != value)
                {
                    if (base.DesignMode && (value == null))
                    {
                        value = DSkinGridListDefaultColumnHeaderBrush;
                    }
                    this.dskinBrush_2 = value;
                    this.InnerColumnHeadBaseControl.BackgroundRender.BackgroundBrush = value;
                }
            }
        }

        [DefaultValue((string) null), Description("头部鼠标移入刷子"), Category("DSkin美化属性")]
        public DSkinBrush ColumnHeaderHoverBrush
        {
            get
            {
                return this.dskinBrush_0;
            }
            set
            {
                if (this.dskinBrush_0 != value)
                {
                    if (base.DesignMode && (value == null))
                    {
                        value = DSkinGridListDefaultColumnHeaderHoverBrush;
                    }
                    this.dskinBrush_0 = value;
                }
            }
        }

        [Description("头部鼠标按下刷子"), DefaultValue((string) null), Category("DSkin美化属性")]
        public DSkinBrush ColumnHeaderPressBrush
        {
            get
            {
                return this.dskinBrush_1;
            }
            set
            {
                if (this.dskinBrush_1 != value)
                {
                    if (base.DesignMode && (value == null))
                    {
                        value = DSkinGridListDefaultColumnHeaderPressBrush;
                    }
                    this.dskinBrush_1 = value;
                }
            }
        }

        [DefaultValue(true), Category("DSkin"), Description("是否显示标题行")]
        public bool ColumnHeadersVisible
        {
            get
            {
                return this.bool_2;
            }
            set
            {
                if (this.bool_2 != value)
                {
                    this.bool_2 = value;
                    this.duiBaseControl_1.Visible = value;
                    this.duiBaseControl_1.Height = value ? this.int_1 : 1;
                    this.InnerListBox.Size = new Size(base.Width, (base.Height - this.InnerColumnHeadBaseControl.Height) - (this.bool_6 ? this.PageControl.Height : 0));
                    base.InnerDuiControl.LayoutEngine.Layout();
                }
            }
        }

        [Description("列表头高度"), Category("DSkin")]
        public int ColumnHeight
        {
            get
            {
                return this.int_1;
            }
            set
            {
                if (this.int_1 != value)
                {
                    this.int_1 = value;
                    if (this.bool_2)
                    {
                        this.duiBaseControl_1.Height = this.int_1;
                    }
                    this.InnerListBox.Size = new Size(base.Width, (base.Height - this.InnerColumnHeadBaseControl.Height) - (this.bool_6 ? this.PageControl.Height : 0));
                    base.InnerDuiControl.LayoutEngine.Layout();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("DSkin"), Description("列表项集合")]
        public Collection<GClass2> Columns
        {
            get
            {
                if (this.collection_1 == null)
                {
                    this.collection_1 = new Collection<GClass2>();
                    this.collection_1.ItemAdded += new EventHandler<CollectionEventArgs<GClass2>>(this.method_7);
                    this.collection_1.ItemRemoved += new EventHandler<CollectionEventArgs<GClass2>>(this.method_6);
                }
                return this.collection_1;
            }
        }

        [DefaultValue(true), Description("是否可以通过鼠标调整列宽"), Category("DSkin")]
        public bool ColumnWidthCanChange
        {
            get
            {
                return this.bool_3;
            }
            set
            {
                this.bool_3 = value;
            }
        }

        [DefaultValue(false), Description("是否自定义分页，为true可以设置RowCount")]
        public bool CustomPage
        {
            get
            {
                return this.bool_5;
            }
            set
            {
                this.bool_5 = value;
            }
        }

        [Category("数据"), Description("获取或设置数据源显示其数据的列表或表的名称"), DefaultValue(""), Editor("System.Windows.Forms.Design.DataMemberListEditor", typeof(UITypeEditor))]
        public string DataMember
        {
            get
            {
                return this.string_0;
            }
            set
            {
                if (value != this.string_0)
                {
                    this.string_0 = value;
                }
            }
        }

        [AttributeProvider(typeof(IListSource)), Category("数据"), RefreshProperties(RefreshProperties.Repaint), DefaultValue((string) null)]
        public object DataSource
        {
            get
            {
                return this.object_0;
            }
            set
            {
                if (this.object_0 != value)
                {
                    if ((value != null) && (!(value is IList) && !(value is IListSource)))
                    {
                        throw new ArgumentException("数据源必须为集合");
                    }
                    if (value == null)
                    {
                        this.ilist_0 = null;
                    }
                    this.object_0 = value;
                    this.SelectedItem = null;
                    if (!base.DesignMode)
                    {
                        this.DataBind();
                    }
                    this.OnDataSourceChanged(EventArgs.Empty);
                }
            }
        }

        [Category("DSkin美化属性"), DefaultValue(typeof(Color), "245, 245, 245"), Description("双行背景色")]
        public Color DoubleItemsBackColor
        {
            get
            {
                return this.color_2;
            }
            set
            {
                this.color_2 = value;
            }
        }

        public static DSkinLinearGradientBrush DSkinGridListDefaultColumnHeaderBrush
        {
            get
            {
                if (dskinLinearGradientBrush_2 == null)
                {
                    dskinLinearGradientBrush_2 = new DSkinLinearGradientBrush();
                    BlendColor color = new BlendColor {
                        Color = Color.White,
                        Position = 0f
                    };
                    dskinLinearGradientBrush_2.Colors.Add(color);
                    BlendColor color2 = new BlendColor {
                        Color = Color.FromArgb(240, 240, 240),
                        Position = 1f
                    };
                    dskinLinearGradientBrush_2.Colors.Add(color2);
                    RotateTransform transform = new RotateTransform {
                        Angle = 90f
                    };
                    dskinLinearGradientBrush_2.TransformCollection.Add(transform);
                }
                return dskinLinearGradientBrush_2;
            }
        }

        public static DSkinBrush DSkinGridListDefaultColumnHeaderHoverBrush
        {
            get
            {
                if (dskinLinearGradientBrush_0 == null)
                {
                    dskinLinearGradientBrush_0 = new DSkinLinearGradientBrush();
                    BlendColor color = new BlendColor {
                        Color = Color.FromArgb(100, 0xff, 0xff, 0xff),
                        Position = 0f
                    };
                    dskinLinearGradientBrush_0.Colors.Add(color);
                    BlendColor color2 = new BlendColor {
                        Color = Color.FromArgb(100, Color.DodgerBlue),
                        Position = 1f
                    };
                    dskinLinearGradientBrush_0.Colors.Add(color2);
                    RotateTransform transform = new RotateTransform {
                        Angle = 90f
                    };
                    dskinLinearGradientBrush_0.TransformCollection.Add(transform);
                }
                return dskinLinearGradientBrush_0;
            }
        }

        public static DSkinBrush DSkinGridListDefaultColumnHeaderPressBrush
        {
            get
            {
                if (dskinLinearGradientBrush_1 == null)
                {
                    dskinLinearGradientBrush_1 = new DSkinLinearGradientBrush();
                    BlendColor color = new BlendColor {
                        Color = Color.FromArgb(100, 0xff, 0xff, 0xff),
                        Position = 0f
                    };
                    dskinLinearGradientBrush_1.Colors.Add(color);
                    BlendColor color2 = new BlendColor {
                        Color = Color.FromArgb(100, Color.DodgerBlue),
                        Position = 0.5f
                    };
                    dskinLinearGradientBrush_1.Colors.Add(color2);
                    BlendColor color3 = new BlendColor {
                        Color = Color.FromArgb(100, 0xff, 0xff, 0xff),
                        Position = 1f
                    };
                    dskinLinearGradientBrush_1.Colors.Add(color3);
                    RotateTransform transform = new RotateTransform {
                        Angle = 90f
                    };
                    dskinLinearGradientBrush_1.TransformCollection.Add(transform);
                }
                return dskinLinearGradientBrush_1;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override DuiControlCollection DuiControlCollection_0
        {
            get
            {
                return base.DuiControlCollection_0;
            }
        }

        [Category("DSkin"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("横向滚动条")]
        public DuiScrollBar DuiScrollBar_0
        {
            get
            {
                EventHandler handler = null;
                if (this.duiScrollBar_0 == null)
                {
                    DuiScrollBar bar = new DuiScrollBar {
                        Orientation = Orientation.Horizontal
                    };
                    this.duiScrollBar_0 = bar;
                    this.duiScrollBar_0.Width = this.InnerListBox.Width;
                    this.duiScrollBar_0.Height = this.InnerListBox.InnerScrollBar.Width;
                    this.duiScrollBar_0.Fillet = true;
                    this.duiScrollBar_0.Location = new Point(0, (base.Height - this.duiScrollBar_0.Height) - this.pageControl_0.Height);
                    this.duiScrollBar_0.BackColor = this.InnerListBox.InnerScrollBar.BackColor;
                    this.duiScrollBar_0.Visible = false;
                    if (handler == null)
                    {
                        handler = new EventHandler(this.method_24);
                    }
                    this.duiScrollBar_0.ValueChanged += handler;
                }
                return this.duiScrollBar_0;
            }
        }

        [Category("DSkin"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("竖向滚动条")]
        public DuiScrollBar DuiScrollBar_1
        {
            get
            {
                return this.InnerListBox.InnerScrollBar;
            }
        }

        [Description("是否启用排序"), Category("DSkin")]
        public bool EnabledOrder
        {
            get
            {
                return this.bool_4;
            }
            set
            {
                this.bool_4 = value;
            }
        }

        [Description("是否启用分页显示"), Category("DSkin"), DefaultValue(true)]
        public bool EnablePage
        {
            get
            {
                return this.bool_6;
            }
            set
            {
                if (this.bool_6 != value)
                {
                    this.bool_6 = value;
                    this.pageControl_0.Visible = this.bool_6;
                    if (!value && (this.int_3 != 1))
                    {
                        this.int_3 = 1;
                        this.OnPageIndexChanged(EventArgs.Empty);
                    }
                    this.method_13();
                    this.LayoutContent();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("分页控件属性"), Description("分页控件首页按钮属性设置")]
        public DuiButton FirstPageButton
        {
            get
            {
                return this.pageControl_0.BtnFistPage;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("分页控件跳转按钮属性设置"), Category("分页控件属性")]
        public DuiButton GoPageButton
        {
            get
            {
                return this.pageControl_0.BtnGoPage;
            }
        }

        [Category("DSkin美化属性"), Description("网格线颜色")]
        public Color GridLineColor
        {
            get
            {
                return this.color_5;
            }
            set
            {
                this.color_5 = value;
                base.Borders.AllColor = this.color_5;
                this.PageControl.Borders.TopColor = this.color_5;
            }
        }

        [DefaultValue(1), Description("表格线条显示方式"), Category("DSkin美化属性")]
        public GridLineShowModes GridLineShowMode
        {
            get
            {
                return this.gridLineShowModes_0;
            }
            set
            {
                if (this.gridLineShowModes_0 != value)
                {
                    this.gridLineShowModes_0 = value;
                    base.Invalidate();
                }
            }
        }

        [DefaultValue((string) null), Category("DSkin"), Description("Item右键菜单")]
        public ContextMenuStrip GridListContextMenuStrip
        {
            get
            {
                return this.contextMenuStrip_0;
            }
            set
            {
                this.contextMenuStrip_0 = value;
            }
        }

        [Category("DSkin美化属性"), Description("头部字体")]
        public Font HeaderFont
        {
            get
            {
                return this.font_0;
            }
            set
            {
                if (this.font_0 != value)
                {
                    this.font_0 = value;
                    foreach (GClass2 class2 in this.Columns)
                    {
                        class2.Item.Font = value;
                    }
                }
            }
        }

        [DefaultValue(typeof(Color), "Black"), Category("DSkin美化属性"), Description("头部前景色")]
        public Color HeaderForeColor
        {
            get
            {
                return this.color_0;
            }
            set
            {
                if (this.color_0 != value)
                {
                    this.color_0 = value;
                    foreach (GClass2 class2 in this.Columns)
                    {
                        class2.Item.ForeColor = value;
                    }
                }
            }
        }

        [Description("鼠标移入行背景色"), Category("DSkin美化属性"), DefaultValue(typeof(Color), "LightGoldenrodYellow")]
        public Color HoverItemsBackColor
        {
            get
            {
                return this.color_3;
            }
            set
            {
                this.color_3 = value;
            }
        }

        [Description("列表头控件"), Browsable(false), Category("DSkin")]
        public DuiBaseControl InnerColumnHeadBaseControl
        {
            get
            {
                EventHandler<PaintEventArgs> handler = null;
                if (this.duiBaseControl_1 == null)
                {
                    this.duiBaseControl_1 = new DuiBaseControl();
                    this.duiBaseControl_1.Location = new Point(0, 0);
                    this.duiBaseControl_1.Size = new Size(base.Width, 30);
                    this.duiBaseControl_1.Dock = DockStyle.Top;
                    if (handler == null)
                    {
                        handler = new EventHandler<PaintEventArgs>(this.method_20);
                    }
                    this.duiBaseControl_1.PrePaint += handler;
                }
                return this.duiBaseControl_1;
            }
        }

        [Description("Items列表控件"), Browsable(false), Category("DSkin")]
        public DuiListBox InnerListBox
        {
            get
            {
                EventHandler<KeyEventArgs> handler = null;
                EventHandler<DuiControlEventArgs> handler2 = null;
                EventHandler<DuiControlEventArgs> handler3 = null;
                if (this.duiListBox_0 == null)
                {
                    this.duiListBox_0 = new DuiListBox();
                    this.duiListBox_0.Dock = DockStyle.Top;
                    this.duiListBox_0.Size = new Size(base.Width, (base.Height - this.InnerColumnHeadBaseControl.Height) - this.PageControl.Height);
                    this.duiListBox_0.InnerScrollBar.Fillet = true;
                    if (handler == null)
                    {
                        handler = new EventHandler<KeyEventArgs>(this.method_21);
                    }
                    this.duiListBox_0.KeyDown += handler;
                    this.duiListBox_0.InnerScrollBar.Margin = new Padding(1);
                    this.duiListBox_0.InnerScrollBar.MouseEventBubble = true;
                    if (handler2 == null)
                    {
                        handler2 = new EventHandler<DuiControlEventArgs>(this.method_22);
                    }
                    this.duiListBox_0.ItemAdded += handler2;
                    if (handler3 == null)
                    {
                        handler3 = new EventHandler<DuiControlEventArgs>(this.method_23);
                    }
                    this.duiListBox_0.ItemRemoved += handler3;
                }
                return this.duiListBox_0;
            }
        }

        [Category("分页控件属性"), Description("分页控件末页按钮属性设置"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DuiButton LastPageButton
        {
            get
            {
                return this.pageControl_0.BtnLastPage;
            }
        }

        [Description("分页控件下一页按钮属性设置"), Category("分页控件属性"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DuiButton NextPageButton
        {
            get
            {
                return this.pageControl_0.BtnNextPage;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DSkin.Controls.PageControl PageControl
        {
            get
            {
                if (this.pageControl_0 == null)
                {
                    this.pageControl_0 = new DSkin.Controls.PageControl(this);
                    this.pageControl_0.Size = new Size(base.Width, 0x20);
                    this.pageControl_0.Location = new Point(0, base.Height - this.pageControl_0.Height);
                    this.pageControl_0.Dock = DockStyle.Bottom;
                    this.pageControl_0.Borders.TopColor = this.GridLineColor;
                }
                return this.pageControl_0;
            }
            set
            {
                this.pageControl_0 = value;
            }
        }

        [Browsable(false)]
        public int PageCount
        {
            get
            {
                return (((this.RowCount + this.PageSize) - 1) / this.PageSize);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int PageIndex
        {
            get
            {
                return this.int_3;
            }
            set
            {
                if (this.int_3 != value)
                {
                    this.int_3 = (value < 1) ? 1 : value;
                    this.OnPageIndexChanged(EventArgs.Empty);
                    this.LayoutContent();
                }
            }
        }

        [DefaultValue(100), Description("每页显示数据条数"), Category("DSkin")]
        public int PageSize
        {
            get
            {
                return this.int_2;
            }
            set
            {
                if (this.int_2 != value)
                {
                    this.int_2 = value;
                    this.LayoutContent();
                }
            }
        }

        [Description("数据量，总条数"), DefaultValue(0)]
        public int RowCount
        {
            get
            {
                if (this.bool_5)
                {
                    return this.int_4;
                }
                if (this.ilist_0 != null)
                {
                    return this.ilist_0.Count;
                }
                return this.Rows.Count;
            }
            set
            {
                if (this.int_4 != value)
                {
                    this.int_4 = value;
                    if (this.bool_5)
                    {
                        this.PageControl.ShowPageinfo();
                    }
                }
            }
        }

        [Category("DSkin"), DefaultValue(30), Description("行高")]
        public int RowHeight
        {
            get
            {
                return this.int_0;
            }
            set
            {
                if (this.int_0 != value)
                {
                    this.int_0 = value;
                    foreach (DSkinGridListRow row in this.Rows)
                    {
                        row.Height = value;
                    }
                    this.InnerListBox.LayoutContent();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("行集合"), Category("DSkin")]
        public Collection<DSkinGridListRow> Rows
        {
            get
            {
                if (this.collection_0 == null)
                {
                    this.collection_0 = new Collection<DSkinGridListRow>();
                    this.collection_0.ItemAdded += new EventHandler<CollectionEventArgs<DSkinGridListRow>>(this.method_11);
                    this.collection_0.ItemRemoved += new EventHandler<CollectionEventArgs<DSkinGridListRow>>(this.method_10);
                    this.collection_0.Tag = this;
                }
                return this.collection_0;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public System.Type RowTemplate
        {
            get
            {
                return this.type_0;
            }
            set
            {
                if (this.type_0 != value)
                {
                    this.type_0 = value;
                }
            }
        }

        [Description("选中的行"), Category("DSkin"), Browsable(false)]
        public DSkinGridListRow SelectedItem
        {
            get
            {
                if (this.SelectedItems.Count > 0)
                {
                    return this.list_0[this.list_0.Count - 1];
                }
                return null;
            }
            set
            {
                foreach (DSkinGridListRow row in this.SelectedItems)
                {
                    row.IsSelected = false;
                }
                this.SelectedItems.Clear();
                if (value != null)
                {
                    value.IsSelected = true;
                    this.SelectedItems.Add(value);
                }
            }
        }

        [Browsable(false), Description("选中的行集合"), Category("DSkin")]
        public List<DSkinGridListRow> SelectedItems
        {
            get
            {
                if (this.list_0 == null)
                {
                    this.list_0 = new List<DSkinGridListRow>();
                }
                return this.list_0;
            }
        }

        [Description("选中行背景色"), DefaultValue(typeof(Color), "LightGoldenrodYellow"), Category("DSkin美化属性")]
        public Color SelectedItemsBackColor
        {
            get
            {
                return this.color_4;
            }
            set
            {
                this.color_4 = value;
            }
        }

        [Category("DSkin美化属性"), Description("单行背景色"), DefaultValue(typeof(Color), "Transparent")]
        public Color SingleItemsBackColor
        {
            get
            {
                return this.color_1;
            }
            set
            {
                this.color_1 = value;
            }
        }

        private enum Enum0
        {
        }
    }
}

