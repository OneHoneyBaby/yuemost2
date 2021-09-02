namespace DSkin.Controls
{
    using DSkin.Common;
    using DSkin.DirectUI;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class ProfessionalToolStripRendererEx : ToolStripRenderer
    {
        private ToolStripColorTable toolStripColorTable_0;

        public ProfessionalToolStripRendererEx()
        {
            this.ColorTable = new ToolStripColorTable();
        }

        public ProfessionalToolStripRendererEx(ToolStripColorTable colorTable)
        {
            this.ColorTable = colorTable;
        }

        private void method_0(Graphics graphics_0, Rectangle rectangle_0, bool bool_0, bool bool_1, Color color_0, Color color_1)
        {
            rectangle_0.Height -= 3;
            Point point = new Point(rectangle_0.X, rectangle_0.Y);
            Rectangle rectangle = new Rectangle(0, 0, 2, 2);
            using (new SmoothingModeGraphics(graphics_0))
            {
                int num;
                int num2;
                int num3;
                IntPtr hdc;
                int height;
                if (bool_0)
                {
                    height = rectangle_0.Height;
                    point.Y += 8;
                    for (num = 0; point.Y > 4; num += 4)
                    {
                        point.Y = height - (2 + num);
                        if (bool_1)
                        {
                            rectangle.Location = point;
                            this.method_1(graphics_0, rectangle, color_1, color_0);
                        }
                        else
                        {
                            num2 = ColorTranslator.ToWin32(color_0);
                            num3 = ColorTranslator.ToWin32(color_1);
                            hdc = graphics_0.GetHdc();
                            SetPixel(hdc, point.X, point.Y, num2);
                            SetPixel(hdc, point.X + 1, point.Y, num3);
                            SetPixel(hdc, point.X, point.Y + 1, num3);
                            SetPixel(hdc, point.X + 3, point.Y, num2);
                            SetPixel(hdc, point.X + 4, point.Y, num3);
                            SetPixel(hdc, point.X + 3, point.Y + 1, num3);
                            graphics_0.ReleaseHdc(hdc);
                        }
                    }
                }
                else
                {
                    rectangle_0.Inflate(-2, 0);
                    height = rectangle_0.Width;
                    point.X += 2;
                    for (num = 1; point.X > 0; num += 4)
                    {
                        point.X = height - (2 + num);
                        if (bool_1)
                        {
                            rectangle.Location = point;
                            this.method_1(graphics_0, rectangle, color_1, color_0);
                        }
                        else
                        {
                            num2 = ColorTranslator.ToWin32(color_0);
                            num3 = ColorTranslator.ToWin32(color_1);
                            hdc = graphics_0.GetHdc();
                            SetPixel(hdc, point.X, point.Y, num2);
                            SetPixel(hdc, point.X + 1, point.Y, num3);
                            SetPixel(hdc, point.X, point.Y + 1, num3);
                            SetPixel(hdc, point.X + 3, point.Y, num2);
                            SetPixel(hdc, point.X + 4, point.Y, num3);
                            SetPixel(hdc, point.X + 3, point.Y + 1, num3);
                            graphics_0.ReleaseHdc(hdc);
                        }
                    }
                }
            }
        }

        private void method_1(Graphics graphics_0, Rectangle rectangle_0, Color color_0, Color color_1)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(rectangle_0);
                path.CloseFigure();
                using (Pen pen = new Pen(color_0))
                {
                    graphics_0.DrawPath(pen, path);
                }
                using (Brush brush = new SolidBrush(color_1))
                {
                    graphics_0.FillPath(brush, path);
                }
            }
        }

        private void method_2(Graphics graphics_0, Rectangle rectangle_0, Color color_0, Color color_1)
        {
            Rectangle rectangle = new Rectangle(0, 0, 2, 2) {
                X = rectangle_0.Width - 0x11,
                Y = rectangle_0.Height - 8
            };
            using (new SmoothingModeGraphics(graphics_0))
            {
                this.method_1(graphics_0, rectangle, color_1, color_0);
                rectangle.X = rectangle_0.Width - 12;
                this.method_1(graphics_0, rectangle, color_1, color_0);
                rectangle.X = rectangle_0.Width - 7;
                this.method_1(graphics_0, rectangle, color_1, color_0);
                rectangle.Y = rectangle_0.Height - 13;
                this.method_1(graphics_0, rectangle, color_1, color_0);
                rectangle.Y = rectangle_0.Height - 0x12;
                this.method_1(graphics_0, rectangle, color_1, color_0);
                rectangle.Y = rectangle_0.Height - 13;
                rectangle.X = rectangle_0.Width - 12;
                this.method_1(graphics_0, rectangle, color_1, color_0);
            }
        }

        private void method_3(Graphics graphics_0, Rectangle rectangle_0, Color color_0, Color color_1)
        {
            using (new SmoothingModeGraphics(graphics_0))
            {
                using (Pen pen = new Pen(color_0))
                {
                    using (Pen pen2 = new Pen(color_1))
                    {
                        graphics_0.DrawLine(pen2, new Point(rectangle_0.Width - 14, rectangle_0.Height - 6), new Point(rectangle_0.Width - 4, rectangle_0.Height - 0x10));
                        graphics_0.DrawLine(pen, new Point(rectangle_0.Width - 13, rectangle_0.Height - 6), new Point(rectangle_0.Width - 4, rectangle_0.Height - 15));
                        graphics_0.DrawLine(pen2, new Point(rectangle_0.Width - 12, rectangle_0.Height - 6), new Point(rectangle_0.Width - 4, rectangle_0.Height - 14));
                        graphics_0.DrawLine(pen, new Point(rectangle_0.Width - 11, rectangle_0.Height - 6), new Point(rectangle_0.Width - 4, rectangle_0.Height - 13));
                        graphics_0.DrawLine(pen2, new Point(rectangle_0.Width - 10, rectangle_0.Height - 6), new Point(rectangle_0.Width - 4, rectangle_0.Height - 12));
                        graphics_0.DrawLine(pen, new Point(rectangle_0.Width - 9, rectangle_0.Height - 6), new Point(rectangle_0.Width - 4, rectangle_0.Height - 11));
                        graphics_0.DrawLine(pen2, new Point(rectangle_0.Width - 8, rectangle_0.Height - 6), new Point(rectangle_0.Width - 4, rectangle_0.Height - 10));
                        graphics_0.DrawLine(pen, new Point(rectangle_0.Width - 7, rectangle_0.Height - 6), new Point(rectangle_0.Width - 4, rectangle_0.Height - 9));
                        graphics_0.DrawLine(pen2, new Point(rectangle_0.Width - 6, rectangle_0.Height - 6), new Point(rectangle_0.Width - 4, rectangle_0.Height - 8));
                        graphics_0.DrawLine(pen, new Point(rectangle_0.Width - 5, rectangle_0.Height - 6), new Point(rectangle_0.Width - 4, rectangle_0.Height - 7));
                    }
                }
            }
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            if (e.Item.Enabled)
            {
                e.ArrowColor = this.ColorTable.Arrow;
            }
            if ((e.Item.Owner is ToolStripDropDown) && (e.Item is ToolStripMenuItem))
            {
                Rectangle arrowRectangle = e.ArrowRectangle;
                e.ArrowRectangle = arrowRectangle;
            }
            base.OnRenderArrow(e);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            Bitmap baseItemMouse;
            Color baseItemHover;
            ToolStrip toolStrip = e.ToolStrip;
            ToolStripButton item = e.Item as ToolStripButton;
            Graphics graphics = e.Graphics;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            if ((item == null) || (toolStrip == null))
            {
                return;
            }
            LinearGradientMode mode = (toolStrip.Orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
            SmoothingModeGraphics graphics2 = new SmoothingModeGraphics(graphics);
            Rectangle bounds = new Rectangle(Point.Empty, item.Size);
            if (item.BackgroundImage != null)
            {
                Rectangle clipRect = item.Selected ? item.ContentRectangle : bounds;
                ControlPaintEx.DrawBackgroundImage(graphics, item.BackgroundImage, this.ColorTable.Back, item.BackgroundImageLayout, bounds, clipRect);
            }
            if (item.CheckState == CheckState.Unchecked)
            {
                if (item.Selected)
                {
                    baseItemMouse = item.Pressed ? ((Bitmap) this.ColorTable.BaseItemDown) : ((Bitmap) this.ColorTable.BaseItemMouse);
                    if (baseItemMouse != null)
                    {
                        ImageDrawRect.DrawRect(graphics, baseItemMouse, bounds, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
                    }
                    else
                    {
                        baseItemHover = this.ColorTable.BaseItemHover;
                        if (item.Pressed)
                        {
                            baseItemHover = this.ColorTable.BaseItemPressed;
                        }
                        Class16.smethod_1(graphics, bounds, baseItemHover, this.ColorTable.BaseItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, this.ColorTable.BaseItemBorderShow, this.ColorTable.BaseItemAnamorphosis, mode);
                    }
                    goto Label_03BA;
                }
                if (this.ColorTable.BaseItemNorml != null)
                {
                    ImageDrawRect.DrawRect(graphics, (Bitmap) this.ColorTable.BaseItemNorml, bounds, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
                }
                if (!(toolStrip is ToolStripOverflow))
                {
                    goto Label_03BA;
                }
                using (Brush brush = new SolidBrush(this.ColorTable.ItemHover))
                {
                    graphics.FillRectangle(brush, bounds);
                    goto Label_03BA;
                }
            }
            baseItemMouse = (Bitmap) this.ColorTable.BaseItemMouse;
            baseItemHover = ControlPaint.Light(this.ColorTable.ItemHover);
            if (item.Selected)
            {
                baseItemHover = this.ColorTable.ItemHover;
                baseItemMouse = (Bitmap) this.ColorTable.BaseItemMouse;
            }
            if (item.Pressed)
            {
                baseItemHover = this.ColorTable.ItemPressed;
                baseItemMouse = (Bitmap) this.ColorTable.BaseItemDown;
            }
            if (baseItemMouse == null)
            {
                Class16.smethod_1(graphics, bounds, baseItemHover, this.ColorTable.BaseItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, this.ColorTable.BaseItemBorderShow, this.ColorTable.BaseItemAnamorphosis, mode);
            }
            else
            {
                ImageDrawRect.DrawRect(graphics, baseItemMouse, bounds, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
            }
        Label_03BA:
            graphics2.Dispose();
        }

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            ToolStripDropDownItem item = e.Item as ToolStripDropDownItem;
            if (item == null)
            {
                return;
            }
            LinearGradientMode mode = (toolStrip.Orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
            Graphics graphics = e.Graphics;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            SmoothingModeGraphics graphics2 = new SmoothingModeGraphics(graphics);
            Rectangle r = new Rectangle(Point.Empty, item.Size);
            if (item.Pressed && item.HasDropDownItems)
            {
                if (this.ColorTable.BaseItemDown != null)
                {
                    ImageDrawRect.DrawRect(graphics, (Bitmap) this.ColorTable.BaseItemDown, r, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
                }
                else
                {
                    Class16.smethod_1(graphics, r, this.ColorTable.BaseItemPressed, this.ColorTable.BaseItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, this.ColorTable.BaseItemBorderShow, this.ColorTable.BaseItemAnamorphosis, mode);
                }
            }
            else if (item.Selected)
            {
                if (this.ColorTable.BaseItemDown != null)
                {
                    ImageDrawRect.DrawRect(graphics, (Bitmap) this.ColorTable.BaseItemMouse, r, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
                }
                else
                {
                    Class16.smethod_1(graphics, r, this.ColorTable.BaseItemHover, this.ColorTable.BaseItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, this.ColorTable.BaseItemBorderShow, this.ColorTable.BaseItemAnamorphosis, mode);
                }
            }
            else
            {
                if (toolStrip is ToolStripOverflow)
                {
                    using (Brush brush = new SolidBrush(this.ColorTable.Back))
                    {
                        graphics.FillRectangle(brush, r);
                        goto Label_02F9;
                    }
                }
                if (this.ColorTable.BaseItemNorml != null)
                {
                    ImageDrawRect.DrawRect(graphics, (Bitmap) this.ColorTable.BaseItemNorml, r, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
                }
                base.OnRenderDropDownButtonBackground(e);
            }
        Label_02F9:
            graphics2.Dispose();
        }

        protected override void OnRenderGrip(ToolStripGripRenderEventArgs e)
        {
            if (e.GripStyle == ToolStripGripStyle.Visible)
            {
                Rectangle gripBounds = e.GripBounds;
                bool flag = e.GripDisplayStyle == ToolStripGripDisplayStyle.Vertical;
                ToolStrip toolStrip = e.ToolStrip;
                Graphics graphics = e.Graphics;
                graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                if (flag)
                {
                    gripBounds.X = e.AffectedBounds.X;
                    gripBounds.Width = e.AffectedBounds.Width;
                    if (toolStrip is MenuStrip)
                    {
                        if (e.AffectedBounds.Height > e.AffectedBounds.Width)
                        {
                            flag = false;
                            gripBounds.Y = e.AffectedBounds.Y;
                        }
                        else
                        {
                            toolStrip.GripMargin = new Padding(0, 2, 0, 2);
                            gripBounds.Y = e.AffectedBounds.Y;
                            gripBounds.Height = e.AffectedBounds.Height;
                        }
                    }
                    else
                    {
                        toolStrip.GripMargin = new Padding(2, 2, 4, 2);
                        gripBounds.X++;
                        gripBounds.Width++;
                    }
                }
                else
                {
                    gripBounds.Y = e.AffectedBounds.Y;
                    gripBounds.Height = e.AffectedBounds.Height;
                }
                this.method_0(graphics, gripBounds, flag, false, this.ColorTable.Back, ControlPaint.Dark(this.ColorTable.Base, 0.3f));
            }
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics graphics = e.Graphics;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Rectangle affectedBounds = e.AffectedBounds;
            if (toolStrip is ToolStripDropDown)
            {
                bool flag = toolStrip.RightToLeft == RightToLeft.Yes;
                Rectangle rectangle4 = affectedBounds;
                Rectangle rect = affectedBounds;
                if (flag)
                {
                    rect.X -= 2;
                    rectangle4.X = rect.X;
                }
                else
                {
                    rect.X += 2;
                    rectangle4.X = rect.Right;
                }
                rect.Y++;
                rect.Height -= 2;
                using (LinearGradientBrush brush = new LinearGradientBrush(rect, this.ColorTable.TitleColor, this.ColorTable.Back, 90f))
                {
                    Blend blend = new Blend();
                    float[] numArray = new float[3];
                    numArray[1] = 0.2f;
                    numArray[2] = 1f;
                    blend.Positions = numArray;
                    numArray = new float[3];
                    numArray[1] = 0.1f;
                    numArray[2] = 0.9f;
                    blend.Factors = numArray;
                    brush.Blend = blend;
                    rect.Y++;
                    rect.Height -= 2;
                    using (GraphicsPath path = GraphicsPathHelper.CreatePath(rect, this.ColorTable.TitleRadius, this.ColorTable.TitleRadiusStyle, false))
                    {
                        using (new SmoothingModeGraphics(graphics))
                        {
                            if (this.ColorTable.TitleAnamorphosis)
                            {
                                graphics.FillPath(brush, path);
                            }
                            else
                            {
                                SolidBrush brush2 = new SolidBrush(this.ColorTable.TitleColor);
                                graphics.FillPath(brush2, path);
                            }
                        }
                    }
                }
                using (Pen pen = new Pen(this.ColorTable.TitleLineColor))
                {
                    graphics.DrawLine(pen, new Point(e.AffectedBounds.Right + 2, e.AffectedBounds.Top), new Point(e.AffectedBounds.Right + 2, e.AffectedBounds.Bottom));
                    return;
                }
            }
            base.OnRenderImageMargin(e);
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics graphics = e.Graphics;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            if ((toolStrip is ToolStripDropDown) && (e.Item is ToolStripMenuItem))
            {
                Rectangle imageRectangle = e.ImageRectangle;
                if (e.Item.RightToLeft == RightToLeft.Yes)
                {
                    imageRectangle.X -= 2;
                }
                else
                {
                    imageRectangle.X += 2;
                }
                imageRectangle.Width = 13;
                imageRectangle.Y++;
                imageRectangle.Height -= 3;
                using (new SmoothingModeGraphics(graphics))
                {
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddRectangle(imageRectangle);
                        using (PathGradientBrush brush = new PathGradientBrush(path))
                        {
                            brush.CenterColor = Color.White;
                            brush.SurroundColors = new Color[] { ControlPaint.Light(this.ColorTable.Back) };
                            Blend blend = new Blend();
                            float[] numArray = new float[3];
                            numArray[1] = 0.3f;
                            numArray[2] = 1f;
                            blend.Positions = numArray;
                            numArray = new float[3];
                            numArray[1] = 0.5f;
                            numArray[2] = 1f;
                            blend.Factors = numArray;
                            brush.Blend = blend;
                            graphics.FillRectangle(brush, imageRectangle);
                        }
                    }
                    using (Pen pen = new Pen(ControlPaint.Light(this.ColorTable.Back)))
                    {
                        graphics.DrawRectangle(pen, imageRectangle);
                    }
                    ControlPaintEx.DrawCheckedFlag(graphics, imageRectangle, this.ColorTable.Fore);
                    return;
                }
            }
            base.OnRenderItemCheck(e);
        }

        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics graphics = e.Graphics;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            if ((toolStrip is ToolStripDropDown) && (e.Item is ToolStripMenuItem))
            {
                ToolStripMenuItem item = (ToolStripMenuItem) e.Item;
                if (item.Checked)
                {
                    return;
                }
                Rectangle imageRectangle = e.ImageRectangle;
                if (e.Item.RightToLeft == RightToLeft.Yes)
                {
                    imageRectangle.X -= 2;
                }
                else
                {
                    imageRectangle.X += 2;
                }
                using (new InterpolationModeGraphics(graphics))
                {
                    ToolStripItemImageRenderEventArgs args = new ToolStripItemImageRenderEventArgs(graphics, e.Item, e.Image, imageRectangle);
                    base.OnRenderItemImage(args);
                    return;
                }
            }
            base.OnRenderItemImage(e);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            Rectangle textRectangle;
            ToolStrip toolStrip = e.ToolStrip;
            ToolStripItem item = e.Item;
            Graphics dc = e.Graphics;
            dc.TextRenderingHint = this.toolStripColorTable_0.TextRenderMode;
            e.TextRectangle = new Rectangle(new Point(e.TextRectangle.X + this.ColorTable.BaseForeOffset.X, e.TextRectangle.Y + this.ColorTable.BaseForeOffset.Y), e.TextRectangle.Size);
            if (this.ColorTable.SkinAllColor)
            {
                if (toolStrip is ToolStripDropDown)
                {
                    e.TextColor = item.Selected ? this.ColorTable.HoverFore : this.ColorTable.Fore;
                }
                else
                {
                    e.TextColor = item.Selected ? this.ColorTable.BaseHoverFore : this.ColorTable.BaseFore;
                }
            }
            if ((toolStrip is ToolStripDropDown) && (e.Item is ToolStripMenuItem))
            {
                textRectangle = e.TextRectangle;
                e.TextRectangle = textRectangle;
            }
            if (!(((toolStrip is ToolStripDropDown) || !this.ColorTable.BaseForeAnamorphosis) || string.IsNullOrEmpty(e.Item.Text)))
            {
                Image image = SkinTools.ImageLightEffect(e.Item.Text, e.Item.Font, e.TextColor, this.ColorTable.BaseForeAnamorphosisColor, this.ColorTable.BaseForeAnamorphosisBorder);
                dc.DrawImage(image, (int) (e.TextRectangle.Left - (this.ColorTable.BaseForeAnamorphosisBorder / 2)), (int) (e.TextRectangle.Top - (this.ColorTable.BaseForeAnamorphosisBorder / 2)));
            }
            else
            {
                Color textColor = e.TextColor;
                Font textFont = e.TextFont;
                string text = e.Text;
                Rectangle rect = e.TextRectangle;
                TextFormatFlags textFormat = e.TextFormat;
                textColor = item.Enabled ? textColor : SystemColors.GrayText;
                if (((e.TextDirection != ToolStripTextDirection.Horizontal) && (rect.Width > 0)) && (rect.Height > 0))
                {
                    Size size = LayoutUtils.FlipSize(rect.Size);
                    using (Bitmap bitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppPArgb))
                    {
                        using (Graphics graphics2 = Graphics.FromImage(bitmap))
                        {
                            graphics2.TextRenderingHint = TextRenderingHint.AntiAlias;
                            TextRenderer.DrawText(graphics2, text, textFont, new Rectangle(Point.Empty, size), textColor, textFormat);
                            bitmap.RotateFlip((e.TextDirection == ToolStripTextDirection.Vertical90) ? RotateFlipType.Rotate90FlipNone : RotateFlipType.Rotate270FlipNone);
                            dc.DrawImage(bitmap, rect);
                        }
                        return;
                    }
                }
                if ((item is ToolStripMenuItem) && (item.GetCurrentParent() is ToolStripDropDownMenu))
                {
                    TextRenderer.DrawText(dc, text, textFont, rect, textColor, textFormat);
                }
                else if (!string.IsNullOrEmpty(text))
                {
                    string str2 = text;
                    int index = -1;
                    index = text.IndexOf('&');
                    if (index > -1)
                    {
                        str2 = text.Replace("&", "");
                    }
                    DuiTextBox box = new DuiTextBox {
                        Size = rect.Size,
                        Font = textFont,
                        ForeColor = textColor,
                        Text = str2,
                        BackColor = Color.Transparent,
                        TextRenderMode = this.toolStripColorTable_0.TextRenderMode
                    };
                    box.Height += 2;
                    if (index > -1)
                    {
                        ((DuiChar) box.Items[index]).Font = new Font(textFont, FontStyle.Underline);
                    }
                    int num = 0;
                    foreach (ILayoutElement element in box.Items)
                    {
                        num += element.Size.Width;
                    }
                    Region clip = dc.Clip;
                    Point location = rect.Location;
                    location.Y += (rect.Height - box.method_29()) / 2;
                    if ((textFormat & TextFormatFlags.HorizontalCenter) == TextFormatFlags.HorizontalCenter)
                    {
                        location.X += (rect.Width - num) / 2;
                    }
                    else
                    {
                        location.X++;
                    }
                    dc.TranslateTransform((float) location.X, (float) location.Y);
                    textRectangle = new Rectangle(0, 0, box.Width, box.Height);
                    box.PaintControl(dc, textRectangle);
                    dc.TranslateTransform((float) -location.X, (float) -location.Y);
                    dc.Clip = clip;
                    box.Dispose();
                }
            }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            ToolStripItem item = e.Item;
            if (item.Enabled)
            {
                Graphics graphics = e.Graphics;
                Rectangle rectangle = new Rectangle(Point.Empty, e.Item.Size);
                if (toolStrip is MenuStrip)
                {
                    LinearGradientMode mode = (toolStrip.Orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
                    if (item.Selected)
                    {
                        Class16.smethod_1(graphics, rectangle, this.ColorTable.ItemHover, this.ColorTable.ItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, this.ColorTable.BaseItemBorderShow, this.ColorTable.BaseItemAnamorphosis, mode);
                    }
                    else if (item.Pressed)
                    {
                        Class16.smethod_1(graphics, rectangle, this.ColorTable.ItemPressed, this.ColorTable.ItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, this.ColorTable.BaseItemBorderShow, this.ColorTable.BaseItemAnamorphosis, mode);
                    }
                    else
                    {
                        base.OnRenderMenuItemBackground(e);
                    }
                }
                else if (toolStrip is ToolStripDropDown)
                {
                    rectangle = new Rectangle(new Point(-2, 0), new Size(e.Item.Size.Width + 5, e.Item.Size.Height + 1));
                    if (item.RightToLeft == RightToLeft.Yes)
                    {
                        rectangle.X += 4;
                    }
                    else
                    {
                        rectangle.X += 4;
                    }
                    rectangle.Width -= 8;
                    rectangle.Height--;
                    if (item.Selected)
                    {
                        Class16.smethod_1(graphics, rectangle, this.ColorTable.ItemHover, this.ColorTable.ItemBorder, this.ColorTable.Back, this.ColorTable.ItemRadiusStyle, this.ColorTable.ItemRadius, this.ColorTable.ItemBorderShow, this.ColorTable.ItemAnamorphosis, LinearGradientMode.Vertical);
                    }
                    else
                    {
                        base.OnRenderMenuItemBackground(e);
                    }
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }
        }

        protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            Pen pen;
            ToolStripItem item = e.Item;
            ToolStrip toolStrip = e.ToolStrip;
            Graphics graphics = e.Graphics;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            bool rightToLeft = item.RightToLeft == RightToLeft.Yes;
            new SmoothingModeGraphics(graphics);
            this.RenderOverflowBackground(e, rightToLeft);
            bool flag2 = toolStrip.Orientation == Orientation.Horizontal;
            Rectangle empty = Rectangle.Empty;
            if (rightToLeft)
            {
                empty = new Rectangle(0, item.Height - 8, 10, 5);
            }
            else
            {
                empty = new Rectangle(item.Width - 12, item.Height - 8, 10, 5);
            }
            ArrowDirection direction = flag2 ? ArrowDirection.Down : ArrowDirection.Right;
            int x = (!rightToLeft || !flag2) ? 1 : -1;
            empty.Offset(x, 1);
            Color color = toolStrip.Enabled ? this.ColorTable.Fore : SystemColors.ControlDark;
            using (Brush brush = new SolidBrush(color))
            {
                Class16.smethod_3(graphics, empty, direction, brush);
            }
            if (flag2)
            {
                using (pen = new Pen(color))
                {
                    graphics.DrawLine(pen, (int) (empty.Right - 8), (int) (empty.Y - 2), (int) (empty.Right - 2), (int) (empty.Y - 2));
                    graphics.DrawLine(pen, (int) (empty.Right - 8), (int) (empty.Y - 1), (int) (empty.Right - 2), (int) (empty.Y - 1));
                    return;
                }
            }
            using (pen = new Pen(color))
            {
                graphics.DrawLine(pen, empty.X, empty.Y, empty.X, empty.Bottom - 1);
                graphics.DrawLine(pen, empty.X, empty.Y + 1, empty.X, empty.Bottom);
            }
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Rectangle contentRectangle = e.Item.ContentRectangle;
            Graphics g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            if (toolStrip is ToolStripDropDown)
            {
                if (e.Item.RightToLeft != RightToLeft.Yes)
                {
                    contentRectangle.X += 0x1a;
                }
                contentRectangle.Width -= 0x1c;
            }
            this.RenderSeparatorLine(g, contentRectangle, this.ColorTable.BaseItemSplitter, this.ColorTable.Back, SystemColors.ControlLightLight, e.Vertical);
        }

        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            ToolStripSplitButton item = e.Item as ToolStripSplitButton;
            if (item != null)
            {
                Pen pen;
                Graphics graphics = e.Graphics;
                graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                LinearGradientMode mode = (toolStrip.Orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
                Rectangle bounds = new Rectangle(Point.Empty, item.Size);
                new SmoothingModeGraphics(graphics);
                Color arrowColor = toolStrip.Enabled ? this.ColorTable.Fore : SystemColors.ControlDark;
                if (item.BackgroundImage != null)
                {
                    Rectangle clipRect = item.Selected ? item.ContentRectangle : bounds;
                    ControlPaintEx.DrawBackgroundImage(graphics, item.BackgroundImage, this.ColorTable.Back, item.BackgroundImageLayout, bounds, clipRect);
                }
                if (item.ButtonPressed)
                {
                    if (this.ColorTable.BaseItemDown != null)
                    {
                        ImageDrawRect.DrawRect(graphics, (Bitmap) this.ColorTable.BaseItemDown, bounds, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
                    }
                    else
                    {
                        Rectangle buttonBounds = item.ButtonBounds;
                        Padding padding = (item.RightToLeft == RightToLeft.Yes) ? new Padding(0, 1, 1, 1) : new Padding(1, 1, 0, 1);
                        buttonBounds = LayoutUtils.DeflateRect(buttonBounds, padding);
                        Class16.smethod_1(graphics, bounds, this.ColorTable.BaseItemHover, this.ColorTable.BaseItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, this.ColorTable.BaseItemBorderShow, this.ColorTable.BaseItemAnamorphosis, mode);
                        buttonBounds.Inflate(-1, -1);
                        graphics.SetClip(buttonBounds);
                        Class16.smethod_0(graphics, buttonBounds, this.ColorTable.BaseItemPressed, this.ColorTable.BaseItemBorder, this.ColorTable.Back, RoundStyle.Left, false, true, mode);
                        graphics.ResetClip();
                        using (pen = new Pen(this.ColorTable.BaseItemSplitter))
                        {
                            graphics.DrawLine(pen, item.SplitterBounds.Left, item.SplitterBounds.Top, item.SplitterBounds.Left, item.SplitterBounds.Bottom);
                        }
                    }
                    base.DrawArrow(new ToolStripArrowRenderEventArgs(graphics, item, item.DropDownButtonBounds, arrowColor, ArrowDirection.Down));
                }
                else if (item.Pressed || item.DropDownButtonPressed)
                {
                    if (this.ColorTable.BaseItemDown != null)
                    {
                        ImageDrawRect.DrawRect(graphics, (Bitmap) this.ColorTable.BaseItemDown, bounds, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
                    }
                    else
                    {
                        Class16.smethod_1(graphics, bounds, this.ColorTable.BaseItemPressed, this.ColorTable.BaseItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, this.ColorTable.BaseItemBorderShow, this.ColorTable.BaseItemAnamorphosis, mode);
                    }
                    base.DrawArrow(new ToolStripArrowRenderEventArgs(graphics, item, item.DropDownButtonBounds, arrowColor, ArrowDirection.Down));
                }
                else if (item.Selected)
                {
                    if (this.ColorTable.BaseItemMouse != null)
                    {
                        ImageDrawRect.DrawRect(graphics, (Bitmap) this.ColorTable.BaseItemMouse, bounds, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
                    }
                    else
                    {
                        Class16.smethod_1(graphics, bounds, this.ColorTable.BaseItemHover, this.ColorTable.BaseItemBorder, this.ColorTable.Back, this.ColorTable.BaseItemRadiusStyle, this.ColorTable.BaseItemRadius, this.ColorTable.BaseItemBorderShow, this.ColorTable.BaseItemAnamorphosis, mode);
                        using (pen = new Pen(this.ColorTable.BaseItemSplitter))
                        {
                            graphics.DrawLine(pen, item.SplitterBounds.Left, item.SplitterBounds.Top, item.SplitterBounds.Left, item.SplitterBounds.Bottom);
                        }
                    }
                    base.DrawArrow(new ToolStripArrowRenderEventArgs(graphics, item, item.DropDownButtonBounds, arrowColor, ArrowDirection.Down));
                }
                else
                {
                    if (this.ColorTable.BaseItemNorml != null)
                    {
                        ImageDrawRect.DrawRect(graphics, (Bitmap) this.ColorTable.BaseItemNorml, bounds, Rectangle.FromLTRB(this.ColorTable.BackRectangle.X, this.ColorTable.BackRectangle.Y, this.ColorTable.BackRectangle.Width, this.ColorTable.BackRectangle.Height), 1, 1);
                    }
                    base.DrawArrow(new ToolStripArrowRenderEventArgs(graphics, item, item.DropDownButtonBounds, arrowColor, ArrowDirection.Down));
                }
            }
            else
            {
                base.OnRenderSplitButtonBackground(e);
            }
        }

        protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            this.method_3(e.Graphics, e.AffectedBounds, this.ColorTable.Back, ControlPaint.Dark(this.ColorTable.Base, 0.3f));
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics graphics = e.Graphics;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Rectangle affectedBounds = e.AffectedBounds;
            if (toolStrip is ToolStripDropDown)
            {
                RegionHelper.CreateRegion(toolStrip, affectedBounds, this.ColorTable.BackRadius, this.ColorTable.RadiusStyle);
                using (SolidBrush brush = new SolidBrush(this.ColorTable.Back))
                {
                    graphics.FillRectangle(brush, affectedBounds);
                    return;
                }
            }
            LinearGradientMode mode = (toolStrip.Orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
            Class16.smethod_2(graphics, affectedBounds, this.ColorTable.Base, this.ColorTable.ItemBorder, this.ColorTable.Back, this.ColorTable.RadiusStyle, this.ColorTable.BackRadius, 0.35f, false, false, mode);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            ToolStrip toolStrip = e.ToolStrip;
            Graphics graphics = e.Graphics;
            Rectangle affectedBounds = e.AffectedBounds;
            if (toolStrip is ToolStripDropDown)
            {
                Pen pen;
                if (this.ColorTable.RadiusStyle == RoundStyle.None)
                {
                    affectedBounds.Width--;
                    affectedBounds.Height--;
                }
                using (new SmoothingModeGraphics(graphics))
                {
                    using (GraphicsPath path = GraphicsPathHelper.CreatePath(affectedBounds, this.ColorTable.BackRadius, this.ColorTable.RadiusStyle, true))
                    {
                        using (pen = new Pen(this.ColorTable.DropDownImageSeparator))
                        {
                            path.Widen(pen);
                            graphics.DrawPath(pen, path);
                        }
                    }
                }
                if (toolStrip is ToolStripOverflow)
                {
                    return;
                }
                affectedBounds.Inflate(-1, -1);
                using (GraphicsPath path2 = GraphicsPathHelper.CreatePath(affectedBounds, this.ColorTable.BackRadius, this.ColorTable.RadiusStyle, true))
                {
                    using (pen = new Pen(this.ColorTable.Back))
                    {
                        graphics.DrawPath(pen, path2);
                    }
                    return;
                }
            }
            base.OnRenderToolStripBorder(e);
        }

        public void RenderOverflowBackground(ToolStripItemRenderEventArgs e, bool rightToLeft)
        {
            bool flag2;
            Color empty = Color.Empty;
            Graphics graphics = e.Graphics;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            ToolStrip toolStrip = e.ToolStrip;
            ToolStripOverflowButton item = e.Item as ToolStripOverflowButton;
            Rectangle bounds = new Rectangle(Point.Empty, item.Size);
            Rectangle withinBounds = bounds;
            bool flag = !(item.GetCurrentParent() is MenuStrip);
            if (flag2 = toolStrip.Orientation == Orientation.Horizontal)
            {
                bounds.X += (bounds.Width - 12) + 1;
                bounds.Width = 12;
                if (rightToLeft)
                {
                    bounds = LayoutUtils.RTLTranslate(bounds, withinBounds);
                }
            }
            else
            {
                bounds.Y = (bounds.Height - 12) + 1;
                bounds.Height = 12;
            }
            if (item.Pressed)
            {
                empty = this.ColorTable.ItemPressed;
            }
            else if (item.Selected)
            {
                empty = this.ColorTable.ItemHover;
            }
            else
            {
                empty = this.ColorTable.Base;
            }
            if (flag)
            {
                using (Pen pen = new Pen(this.ColorTable.Base))
                {
                    Point point3 = new Point(bounds.Left - 1, bounds.Height - 2);
                    Point point4 = new Point(bounds.Left, bounds.Height - 2);
                    if (rightToLeft)
                    {
                        point3.X = bounds.Right + 1;
                        point4.X = bounds.Right;
                    }
                    graphics.DrawLine(pen, point3, point4);
                }
            }
            LinearGradientMode mode = flag2 ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal;
            Class16.smethod_2(graphics, bounds, empty, this.ColorTable.ItemBorder, this.ColorTable.Back, RoundStyle.None, 0, 0.35f, false, false, mode);
            if (flag)
            {
                Brush brush;
                using (brush = new SolidBrush(this.ColorTable.Base))
                {
                    if (flag2)
                    {
                        Point point = new Point(bounds.X - 2, 0);
                        Point point2 = new Point(bounds.X - 1, 1);
                        if (rightToLeft)
                        {
                            point.X = bounds.Right + 1;
                            point2.X = bounds.Right;
                        }
                        graphics.FillRectangle(brush, point.X, point.Y, 1, 1);
                        graphics.FillRectangle(brush, point2.X, point2.Y, 1, 1);
                    }
                    else
                    {
                        graphics.FillRectangle(brush, bounds.Width - 3, bounds.Top - 1, 1, 1);
                        graphics.FillRectangle(brush, bounds.Width - 2, bounds.Top - 2, 1, 1);
                    }
                }
                using (brush = new SolidBrush(this.ColorTable.Base))
                {
                    if (flag2)
                    {
                        Rectangle rect = new Rectangle(bounds.X - 1, 0, 1, 1);
                        if (rightToLeft)
                        {
                            rect.X = bounds.Right;
                        }
                        graphics.FillRectangle(brush, rect);
                    }
                    else
                    {
                        graphics.FillRectangle(brush, bounds.X, bounds.Top - 1, 1, 1);
                    }
                }
            }
        }

        public void RenderSeparatorLine(Graphics g, Rectangle rect, Color baseColor, Color backColor, Color shadowColor, bool vertical)
        {
            LinearGradientBrush brush;
            Pen pen;
            if (vertical)
            {
                rect.Y += 2;
                rect.Height -= 4;
                using (brush = new LinearGradientBrush(rect, baseColor, backColor, LinearGradientMode.Vertical))
                {
                    using (pen = new Pen(brush))
                    {
                        g.DrawLine(pen, rect.X, rect.Y, rect.X, rect.Bottom);
                    }
                    return;
                }
            }
            using (brush = new LinearGradientBrush(rect, baseColor, backColor, 180f))
            {
                Blend blend = new Blend {
                    Positions = new float[] { 0f, 0.2f, 0.5f, 0.8f, 1f },
                    Factors = new float[] { 1f, 0.3f, 0f, 0.3f, 1f }
                };
                brush.Blend = blend;
                using (pen = new Pen(brush))
                {
                    g.DrawLine(pen, rect.X, rect.Y, rect.Right, rect.Y);
                    brush.LinearColors = new Color[] { shadowColor, backColor };
                    pen.Brush = brush;
                    g.DrawLine(pen, rect.X, rect.Y + 1, rect.Right, rect.Y + 1);
                }
            }
        }

        [DllImport("gdi32.dll")]
        private static extern uint SetPixel(IntPtr intptr_0, int int_0, int int_1, int int_2);

        public ToolStripColorTable ColorTable
        {
            get
            {
                return this.toolStripColorTable_0;
            }
            set
            {
                this.toolStripColorTable_0 = value;
            }
        }
    }
}

