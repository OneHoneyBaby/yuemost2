namespace DSkin.Controls
{
    using DSkin.Common;
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class DSkinGridListRow : IDisposable
    {
        private bool bool_0;
        private Collection<DSkinGridListCell> collection_0;
        private DuiBaseControl duiBaseControl_0;
        private int int_0;
        private object object_0;
        private object object_1;
        private System.Type type_0;

        public DSkinGridListRow()
        {
            this.object_0 = null;
            this.int_0 = 30;
            this.bool_0 = false;
        }

        public DSkinGridListRow(object rowData)
        {
            this.object_0 = null;
            this.int_0 = 30;
            this.bool_0 = false;
            this.object_1 = rowData;
        }

        public DSkinGridListRow(System.Type template, object rowData)
        {
            this.object_0 = null;
            this.int_0 = 30;
            this.bool_0 = false;
            this.type_0 = template;
            this.object_1 = rowData;
        }

        public void DestroyItem()
        {
            foreach (DSkinGridListCell cell in this.Cells)
            {
                cell.DestroyItem();
            }
            if (this.duiBaseControl_0 != null)
            {
                this.duiBaseControl_0.Dispose();
                this.duiBaseControl_0 = null;
            }
        }

        public void Dispose()
        {
            this.DestroyItem();
            GC.SuppressFinalize(this);
        }

        ~DSkinGridListRow()
        {
            this.Dispose();
        }

        private void method_0(object sender, CollectionEventArgs<DSkinGridListCell> e)
        {
            e.Item.dskinGridListRow_0 = this;
            if ((this.duiBaseControl_0 != null) && this.duiBaseControl_0.Loaded)
            {
                this.duiBaseControl_0.Controls.Add(e.Item.CellControl);
            }
        }

        private void method_1(object sender, CollectionEventArgs<DSkinGridListCell> e)
        {
            e.Item.DestroyItem();
        }

        private void method_2()
        {
            DSkinGridList hostControl = this.duiBaseControl_0.HostControl as DSkinGridList;
            if (hostControl != null)
            {
                int left = -hostControl.DuiScrollBar_0.Value;
                if (hostControl.RowTemplate != null)
                {
                    this.RowControl.Margin = new Padding(left, 0, 0, 0);
                    this.duiBaseControl_0.Left = left;
                }
                else
                {
                    for (int i = 0; i < this.Cells.Count; i++)
                    {
                        DSkinGridListCell cell = this.Cells[i];
                        if (((i < hostControl.Columns.Count) && hostControl.Columns[i].Visble) && (cell != null))
                        {
                            cell.CellControl.Visible = true;
                            if ((hostControl.Columns[i].CellTemplate != null) || (cell.Template != null))
                            {
                                cell.CellControl.Size = new Size(hostControl.Columns[i].Width, this.Height);
                            }
                            else if (cell.ItemType == ControlType.DuiLabel)
                            {
                                cell.CellControl.Size = new Size(hostControl.Columns[i].Width, cell.Font.Height);
                            }
                            else if (cell.ItemType == ControlType.DuiPictureBox)
                            {
                                cell.CellControl.Size = cell.ContentSize;
                            }
                            else if ((cell.ItemType == ControlType.DuiCheckBox) || (cell.ItemType == ControlType.DuiRadioButton))
                            {
                                if (string.IsNullOrEmpty(cell.CellControl.Text))
                                {
                                    cell.CellControl.AutoSize = true;
                                }
                                else
                                {
                                    cell.CellControl.AutoSize = false;
                                    cell.CellControl.Width = hostControl.Columns[i].Width;
                                }
                            }
                            else if (cell.ItemType == ControlType.DuiComboBox)
                            {
                                cell.CellControl.Size = new Size(hostControl.Columns[i].Width - 4, cell.Font.Height);
                            }
                            else if (cell.ItemType == ControlType.DuiButton)
                            {
                                cell.CellControl.Size = new Size(hostControl.Columns[i].Width - 4, this.Height - 4);
                            }
                            else if (cell.ItemType == ControlType.DuiTextBox)
                            {
                                cell.CellControl.Width = hostControl.Columns[i].Width - 2;
                            }
                            this.method_3(cell.DockStyle, cell.CellControl, left, new Size(hostControl.Columns[i].Width, this.Height));
                            left += hostControl.Columns[i].Item.Width;
                        }
                        else
                        {
                            cell.CellControl.Visible = false;
                        }
                    }
                }
            }
        }

        private void method_3(DockStyle dockStyle_0, DuiBaseControl duiBaseControl_1, int int_1, Size size_0)
        {
            switch (dockStyle_0)
            {
                case DockStyle.Top:
                    duiBaseControl_1.Location = new Point(int_1 + ((size_0.Width - duiBaseControl_1.Width) / 2), 2);
                    break;

                case DockStyle.Bottom:
                    duiBaseControl_1.Location = new Point(int_1 + ((size_0.Width - duiBaseControl_1.Width) / 2), size_0.Height - duiBaseControl_1.Height);
                    break;

                case DockStyle.Left:
                    duiBaseControl_1.Location = new Point(int_1 + 2, (size_0.Height - duiBaseControl_1.Height) / 2);
                    break;

                case DockStyle.Right:
                    duiBaseControl_1.Location = new Point(((int_1 + size_0.Width) - duiBaseControl_1.Width) - 2, (size_0.Height - duiBaseControl_1.Height) / 2);
                    break;

                case DockStyle.Fill:
                    duiBaseControl_1.Location = new Point(int_1 + ((size_0.Width - duiBaseControl_1.Width) / 2), (size_0.Height - duiBaseControl_1.Height) / 2);
                    if (duiBaseControl_1 is DuiLabel)
                    {
                        duiBaseControl_1.Location = new Point(int_1 + ((size_0.Width - duiBaseControl_1.Width) / 2), (size_0.Height - duiBaseControl_1.Height) / 2);
                    }
                    break;

                default:
                    duiBaseControl_1.Location = new Point(int_1 + ((size_0.Width - duiBaseControl_1.Width) / 2), (size_0.Height - duiBaseControl_1.Height) / 2);
                    break;
            }
            if (duiBaseControl_1 is DuiLabel)
            {
                ((DuiLabel) duiBaseControl_1).TextAlign = (dockStyle_0 == DockStyle.Left) ? ContentAlignment.MiddleLeft : ((dockStyle_0 == DockStyle.Right) ? ContentAlignment.MiddleRight : ContentAlignment.MiddleCenter);
            }
            if (duiBaseControl_1 is DuiCheckBox)
            {
                duiBaseControl_1.Location = new Point(int_1 + ((size_0.Width - duiBaseControl_1.Width) / 2), (size_0.Height - duiBaseControl_1.Height) / 2);
            }
        }

        [CompilerGenerated]
        private void method_4(object sender, PaintEventArgs e)
        {
            DSkinGridList hostControl = this.duiBaseControl_0.HostControl as DSkinGridList;
            if (hostControl != null)
            {
                using (Pen pen = new Pen(hostControl.GridLineColor))
                {
                    if (hostControl.GridLineShowMode != GridLineShowModes.None)
                    {
                        DuiBaseControl control = (DuiBaseControl) sender;
                        if (hostControl.GridLineShowMode != GridLineShowModes.Horizontal)
                        {
                            int num2 = -hostControl.DuiScrollBar_0.Value;
                            for (int i = 0; i < hostControl.Columns.Count; i++)
                            {
                                if (hostControl.Columns[i].Visble)
                                {
                                    num2 += hostControl.Columns[i].Width;
                                    e.Graphics.DrawLine(pen, num2, 0, num2, control.Height);
                                }
                            }
                        }
                        if (hostControl.GridLineShowMode != GridLineShowModes.Vertical)
                        {
                            e.Graphics.DrawLine(pen, 0, control.Height - 1, control.Width, control.Height - 1);
                        }
                    }
                }
            }
        }

        [CompilerGenerated]
        private void method_5(object sender, EventArgs e)
        {
            foreach (DSkinGridListCell cell in this.Cells)
            {
                this.duiBaseControl_0.Controls.Add(cell.CellControl);
            }
        }

        [CompilerGenerated]
        private void method_6(object sender, MouseEventArgs e)
        {
            if ((this.duiBaseControl_0 != null) && !this.IsSelected)
            {
                DSkinGridList hostControl = this.duiBaseControl_0.HostControl as DSkinGridList;
                if ((hostControl != null) && (hostControl.HoverItemsBackColor != Color.Empty))
                {
                    this.duiBaseControl_0.BackColor = hostControl.HoverItemsBackColor;
                }
            }
        }

        [CompilerGenerated]
        private void method_7(object sender, EventArgs e)
        {
            if ((this.duiBaseControl_0 != null) && !this.IsSelected)
            {
                DSkinGridList hostControl = this.duiBaseControl_0.HostControl as DSkinGridList;
                if (hostControl != null)
                {
                    DuiListBox parent = (DuiListBox) ((DuiBaseControl) this.duiBaseControl_0.Parent).Parent;
                    this.duiBaseControl_0.BackColor = ((parent.Items.IndexOf(this.duiBaseControl_0) % 2) != 0) ? hostControl.DoubleItemsBackColor : hostControl.SingleItemsBackColor;
                }
            }
        }

        [CompilerGenerated]
        private void method_8(object sender, EventArgs e)
        {
            this.method_2();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("单元格集合")]
        public Collection<DSkinGridListCell> Cells
        {
            get
            {
                if (this.collection_0 == null)
                {
                    this.collection_0 = new Collection<DSkinGridListCell>();
                    this.collection_0.ItemAdded += new EventHandler<CollectionEventArgs<DSkinGridListCell>>(this.method_0);
                    this.collection_0.ItemRemoved += new EventHandler<CollectionEventArgs<DSkinGridListCell>>(this.method_1);
                }
                return this.collection_0;
            }
        }

        public int Height
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
                    if (this.duiBaseControl_0 != null)
                    {
                        this.duiBaseControl_0.Height = value;
                    }
                }
            }
        }

        public bool IsSelected
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                if (this.bool_0 != value)
                {
                    this.bool_0 = value;
                    if (this.duiBaseControl_0 != null)
                    {
                        DSkinGridList hostControl = this.duiBaseControl_0.HostControl as DSkinGridList;
                        if (hostControl != null)
                        {
                            if (this.bool_0 && (hostControl.SelectedItemsBackColor != Color.Empty))
                            {
                                this.RowControl.BackColor = hostControl.SelectedItemsBackColor;
                            }
                            else
                            {
                                DuiListBox parent = (DuiListBox) ((DuiBaseControl) this.RowControl.Parent).Parent;
                                this.RowControl.BackColor = ((parent.Items.IndexOf(this.RowControl) % 2) != 0) ? hostControl.DoubleItemsBackColor : hostControl.SingleItemsBackColor;
                            }
                        }
                    }
                }
            }
        }

        [Browsable(false)]
        public DuiBaseControl RowControl
        {
            get
            {
                EventHandler<PaintEventArgs> handler = null;
                EventHandler handler2 = null;
                EventHandler<MouseEventArgs> handler3 = null;
                EventHandler handler4 = null;
                EventHandler handler5 = null;
                if (this.duiBaseControl_0 == null)
                {
                    if (this.type_0 != null)
                    {
                        this.duiBaseControl_0 = (DSkinGridListRowTemplate) Activator.CreateInstance(this.type_0);
                        ((DSkinGridListRowTemplate) this.duiBaseControl_0).dskinGridListRow_0 = this;
                        ((DSkinGridListRowTemplate) this.duiBaseControl_0).object_38 = this.object_1;
                    }
                    else
                    {
                        DuiBaseControl control = new DuiBaseControl {
                            Height = this.int_0
                        };
                        this.duiBaseControl_0 = control;
                        this.duiBaseControl_0.Margin = new Padding(0, 0, 0, 0);
                        this.duiBaseControl_0.InheritanceSize = new SizeF(1f, 0f);
                        if (handler == null)
                        {
                            handler = new EventHandler<PaintEventArgs>(this.method_4);
                        }
                        this.duiBaseControl_0.PrePaint += handler;
                        if (handler2 == null)
                        {
                            handler2 = new EventHandler(this.method_5);
                        }
                        this.duiBaseControl_0.Load += handler2;
                    }
                    if (handler3 == null)
                    {
                        handler3 = new EventHandler<MouseEventArgs>(this.method_6);
                    }
                    this.duiBaseControl_0.MouseEnter += handler3;
                    if (handler4 == null)
                    {
                        handler4 = new EventHandler(this.method_7);
                    }
                    this.duiBaseControl_0.MouseLeave += handler4;
                    this.duiBaseControl_0.Tag = this;
                    if (handler5 == null)
                    {
                        handler5 = new EventHandler(this.method_8);
                    }
                    this.RowControl.StartPaint += handler5;
                }
                return this.duiBaseControl_0;
            }
        }

        public object RowData
        {
            get
            {
                return this.object_1;
            }
        }

        public object Tag
        {
            get
            {
                return this.object_0;
            }
            set
            {
                this.object_0 = value;
            }
        }

        public System.Type Template
        {
            get
            {
                return this.type_0;
            }
            set
            {
                this.type_0 = value;
            }
        }
    }
}

