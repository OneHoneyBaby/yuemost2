namespace DSkin.Controls
{
    using DSkin.DirectUI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class DSkinDynamicListBoxItem : DuiButton
    {
        [CompilerGenerated]
        private static Action<bool> action_0;
        [CompilerGenerated]
        private static Action<bool> action_1;
        private bool bool_35 = false;
        private bool bool_36 = false;
        private bool bool_37 = false;
        public bool ChangedMove = false;
        private int int_5 = -1;
        public int MoveToPoint = 0;
        private Point point_2;

        public DSkinDynamicListBoxItem()
        {
            this.Text = "可移动列表项";
            this.IsPureColor = true;
        }

        public void MoveForHorizontal(DSkinDynamicListBoxItem item, GControl0 hostControl)
        {
            Point temp = new Point(hostControl.OffsetLeft + hostControl.GetWidth(item.NewTabPageIndex), 0);
            item.DoEffect<DSkinDynamicListBoxItem>(item.Left, temp.X, 120, "Left", delegate (bool a) {
                if (item.Left == temp.X)
                {
                    item.bool_37 = false;
                }
            });
        }

        public void MoveForVertical(DSkinDynamicListBoxItem item, GControl0 hostControl)
        {
            Point temp = new Point(0, hostControl.OffsetTop + hostControl.GetHeight(item.NewTabPageIndex));
            item.DoEffect<DSkinDynamicListBoxItem>(item.Top, temp.Y, 120, "Top", delegate (bool a) {
                if (item.Top == temp.Y)
                {
                    item.bool_37 = false;
                }
            });
        }

        protected override void OnMouseDown(DuiMouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.HostDSkinDynamicListBox != null)
            {
                if ((e.Button == MouseButtons.Left) && (e.Clicks == 1))
                {
                    this.bool_36 = true;
                    this.IsSelected = true;
                    this.point_2 = new Point(-e.X, -e.Y);
                }
                else if (e.Button != MouseButtons.Right)
                {
                }
            }
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            this.MouseChangeControlState = !this.IsSelected;
            base.OnMouseEnter(e);
            this.MouseChangeControlState = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.MouseChangeControlState = !this.IsSelected;
            base.OnMouseLeave(e);
            this.MouseChangeControlState = true;
        }

        protected override void OnMouseMove(DuiMouseEventArgs e)
        {
            base.OnMouseMove(e);
            if ((e.Button == MouseButtons.Left) && this.bool_36)
            {
                GControl0 hostDSkinDynamicListBox = this.HostDSkinDynamicListBox;
                if (hostDSkinDynamicListBox != null)
                {
                    DSkinDynamicListBoxItem item = hostDSkinDynamicListBox.FindMoveItemToItem(this);
                    if ((item != null) && !item.bool_37)
                    {
                        int newTabPageIndex = item.NewTabPageIndex;
                        item.NewTabPageIndex = this.NewTabPageIndex;
                        this.NewTabPageIndex = newTabPageIndex;
                        item.bool_37 = true;
                        if (hostDSkinDynamicListBox.Orientation == Orientation.Vertical)
                        {
                            this.MoveForVertical(item, hostDSkinDynamicListBox);
                        }
                        else if (hostDSkinDynamicListBox.Orientation == Orientation.Horizontal)
                        {
                            this.MoveForHorizontal(item, hostDSkinDynamicListBox);
                        }
                    }
                    Point mousePosition = Control.MousePosition;
                    mousePosition.Offset(this.point_2.X, this.point_2.Y);
                    Point point = hostDSkinDynamicListBox.PointToClient(mousePosition);
                    if (hostDSkinDynamicListBox.Orientation == Orientation.Vertical)
                    {
                        this.Location = new Point(0, point.Y);
                    }
                    else if (hostDSkinDynamicListBox.Orientation == Orientation.Horizontal)
                    {
                        this.Location = new Point(point.X, 0);
                    }
                }
            }
        }

        protected override void OnMouseUp(DuiMouseEventArgs e)
        {
            this.MouseChangeControlState = !this.IsSelected;
            base.OnMouseUp(e);
            this.MouseChangeControlState = true;
            if (e.Button == MouseButtons.Left)
            {
                this.bool_36 = false;
                GControl0 hostDSkinDynamicListBox = this.HostDSkinDynamicListBox;
                if (hostDSkinDynamicListBox != null)
                {
                    Point point;
                    if (hostDSkinDynamicListBox.Orientation == Orientation.Vertical)
                    {
                        point = new Point(0, hostDSkinDynamicListBox.OffsetTop + hostDSkinDynamicListBox.GetHeight(this.NewTabPageIndex));
                        if (action_0 == null)
                        {
                            action_0 = new Action<bool>(DSkinDynamicListBoxItem.smethod_2);
                        }
                        this.DoEffect<DSkinDynamicListBoxItem>(base.Top, point.Y, 120, "Top", action_0);
                    }
                    else if (hostDSkinDynamicListBox.Orientation == Orientation.Horizontal)
                    {
                        point = new Point(hostDSkinDynamicListBox.OffsetLeft + hostDSkinDynamicListBox.GetWidth(this.NewTabPageIndex), 0);
                        if (action_1 == null)
                        {
                            action_1 = new Action<bool>(DSkinDynamicListBoxItem.smethod_3);
                        }
                        this.DoEffect<DSkinDynamicListBoxItem>(base.Left, point.X, 120, "Left", action_1);
                    }
                }
            }
        }

        [CompilerGenerated]
        private static void smethod_2(bool bool_38)
        {
        }

        [CompilerGenerated]
        private static void smethod_3(bool bool_38)
        {
        }

        public GControl0 HostDSkinDynamicListBox
        {
            get
            {
                return (this.HostControl as GControl0);
            }
        }

        [DefaultValue(true)]
        public override bool IsPureColor
        {
            get
            {
                return base.IsPureColor;
            }
            set
            {
                base.IsPureColor = value;
            }
        }

        [Description("当前标签是否选中")]
        public override bool IsSelected
        {
            get
            {
                return this.bool_35;
            }
            set
            {
                this.bool_35 = value;
                base.IsSelected = value;
                GControl0 hostDSkinDynamicListBox = this.HostDSkinDynamicListBox;
                if (this.bool_35)
                {
                    if (hostDSkinDynamicListBox != null)
                    {
                        hostDSkinDynamicListBox.SelectedItem = this;
                    }
                    base.ControlState = ControlStates.Pressed;
                }
                else
                {
                    base.ControlState = ControlStates.Normal;
                }
            }
        }

        [Description("移动后标签的新下标，用于重新排序位置")]
        public int NewTabPageIndex
        {
            get
            {
                return this.int_5;
            }
            set
            {
                this.int_5 = value;
            }
        }
    }
}

