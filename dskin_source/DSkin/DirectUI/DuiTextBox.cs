namespace DSkin.DirectUI
{
    using DSkin;
    using DSkin.Common;
    using DSkin.Controls;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;

    public class DuiTextBox : DuiBaseControl
    {
        private bool bool_27;
        private bool bool_28;
        private bool bool_29;
        private bool bool_30;
        private bool bool_31;
        private bool bool_32;
        private bool bool_33;
        private bool bool_34;
        private bool bool_35;
        private char char_0;
        private Collection<TextLine> collection_0;
        private Collection<ILayoutElement> collection_1;
        private Collection<KeywordsStyle> collection_2;
        private Color color_2;
        private Color color_3;
        private Color color_4;
        private DuiBaseControl duiBaseControl_1;
        private DuiScrollBar duiScrollBar_0;
        [CompilerGenerated]
        private static EventHandler<DuiControlEventArgs> eventHandler_3;
        [CompilerGenerated]
        private static EventHandler<CollectionEventArgs<ILayoutElement>> eventHandler_4;
        [CompilerGenerated]
        private static Func<ILayoutElement, bool> func_0;
        private HorizontalAlignment horizontalAlignment_0;
        private ILayoutElement[] ilayoutElement_0;
        private int int_1;
        private int int_2;
        private int int_3;
        private int int_4;
        private int int_5;
        private int int_6;
        private int int_7;
        private PictureBrowseForm pictureBrowseForm_0;
        private string string_3;
        private string string_4;
        private static StringFormat stringFormat_0 = StringFormat.GenericTypographic;
        private TextRenderingHint textRenderingHint_0;
        private System.Windows.Forms.Timer timer_0;
        private System.Windows.Forms.Timer timer_1;

        public event EventHandler LayoutContented;

        public event EventHandler<PopupImageEventArgs> PopupImage;

        [Description("文本内容改变之后发生")]
        public event EventHandler TextChanged;

        public DuiTextBox()
        {
            EventHandler handler = null;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer {
                Interval = 200
            };
            this.timer_0 = timer;
            this.bool_27 = false;
            this.timer_1 = new System.Windows.Forms.Timer();
            this.bool_28 = false;
            this.int_1 = 0;
            this.int_2 = 0;
            this.collection_0 = new Collection<TextLine>();
            DuiScrollBar bar = new DuiScrollBar {
                Visible = false,
                DesignModeCanSelect = false,
                DesignModeCanMove = false,
                DesignModeCanResize = false
            };
            this.duiScrollBar_0 = bar;
            this.int_3 = 12;
            DuiBaseControl control = new DuiBaseControl {
                DesignModeCanSelect = false,
                Name = "DuiTextBoxInnerContainer"
            };
            this.duiBaseControl_1 = control;
            this.char_0 = '\0';
            this.textRenderingHint_0 = TextRenderingHint.SystemDefault;
            this.string_4 = string.Empty;
            this.int_4 = 0;
            this.bool_29 = true;
            this.bool_30 = false;
            this.color_2 = Control.DefaultForeColor;
            this.color_3 = Color.Gray;
            this.color_4 = Color.White;
            this.int_5 = 0;
            this.int_6 = 0;
            this.bool_31 = false;
            this.bool_32 = true;
            this.bool_33 = false;
            this.bool_34 = false;
            this.horizontalAlignment_0 = HorizontalAlignment.Left;
            this.bool_35 = true;
            this.collection_2 = new Collection<KeywordsStyle>();
            this.int_7 = 0;
            this.Cursor = Cursors.IBeam;
            this.timer_1.Interval = 500;
            this.timer_1.Tick += new EventHandler(this.timer_1_Tick);
            base.Height = 12;
            this.BackColor = Color.FromArgb(100, Color.White);
            this.TabStop = true;
            if (eventHandler_3 == null)
            {
                eventHandler_3 = new EventHandler<DuiControlEventArgs>(DuiTextBox.smethod_3);
            }
            this.duiBaseControl_1.ControlAdded += eventHandler_3;
            this.duiBaseControl_1.Parent = this;
            this.duiScrollBar_0.Parent = this;
            this.duiScrollBar_0.SmallChange = 5;
            this.duiScrollBar_0.ClientRectangle = new Rectangle(new Point(base.Width - this.duiScrollBar_0.Width, 0), new Size(10, base.Height));
            this.duiScrollBar_0.ValueChanged += new EventHandler(this.duiScrollBar_0_ValueChanged);
            this.duiScrollBar_0.LargeChange = 10;
            this.duiScrollBar_0.KeyChangeValue = false;
            if (handler == null)
            {
                handler = new EventHandler(this.method_40);
            }
            this.timer_0.Tick += handler;
        }

        public void Copy()
        {
            if ((this.bool_30 || (this.char_0 == '\0')) && (this.SelectionLength > 0))
            {
                string selectedText = this.SelectedText;
                DataObject data = new DataObject();
                if (!string.IsNullOrEmpty(selectedText))
                {
                    string str = "<pre>" + this.SelectedText + "</pre>";
                    data.SetData(DataFormats.UnicodeText, true, this.SelectedText);
                    data.SetData(DataFormats.Html, smethod_0(str));
                }
                for (int i = this.int_5; i < (this.int_5 + this.int_6); i++)
                {
                    DuiPictureBox box = this.Items[i] as DuiPictureBox;
                    if (box != null)
                    {
                        data.SetImage(box.Image);
                        break;
                    }
                }
                Clipboard.Clear();
                Clipboard.SetDataObject(data, true);
            }
        }

        public void Cut()
        {
            if ((this.bool_30 || (this.char_0 == '\0')) && (this.SelectionLength > 0))
            {
                this.Copy();
                this.method_36(this.SelectionStart, this.SelectionLength);
                this.LayoutContent();
                this.CaretIndex = this.SelectionStart;
                this.SelectionLength = 0;
            }
        }

        protected override void Dispose(bool disposing)
        {
            this.collection_0.Clear();
            this.timer_1.Dispose();
            base.Dispose(disposing);
        }

        private void duiScrollBar_0_ValueChanged(object sender, EventArgs e)
        {
            if (this.duiScrollBar_0.IsMouseDown)
            {
                this.duiBaseControl_1.Top = (-this.duiScrollBar_0.Value * (this.int_2 - base.Height)) / 100;
            }
        }

        public int GetCareIndex(Point location)
        {
            int num2;
            if ((this.collection_0.Count == 0) || (this.Items.Count == 0))
            {
                return 0;
            }
            int num3 = 0;
            int lineIndex = this.GetLineIndex(location);
            location.Offset(-this.duiBaseControl_1.Left, -this.duiBaseControl_1.Top);
            if (lineIndex == -1)
            {
                return num3;
            }
            TextLine line = this.collection_0[lineIndex];
            int count = -1;
            if ((this.bool_34 || (location.X <= (line[0].Left + (line[0].Width / 2)))) ? (!this.bool_34 || (location.X <= (line[line.Count - 1].Left + (line[line.Count - 1].Width / 2)))) : false)
            {
                count = 0;
            }
            else
            {
                num2 = 0;
                while (num2 < (line.Count - 1))
                {
                    ILayoutElement element = line[num2 + (this.bool_34 ? 1 : 0)];
                    ILayoutElement element2 = line[num2 + (this.bool_34 ? 0 : 1)];
                    if ((location.X > (element.Left + (element.Width / 2))) && (location.X <= (element2.Left + (element2.Width / 2))))
                    {
                        count = num2 + (this.bool_34 ? 0 : 1);
                        break;
                    }
                    num2++;
                }
                if (count == -1)
                {
                    ILayoutElement element3 = line[line.Count - 1];
                    if (location.X >= (element3.Left + (element3.Width / 2)))
                    {
                        if ((element3 is DuiChar) && (((DuiChar) element3).Char == '\n'))
                        {
                            count = line.Count - 1;
                        }
                        else
                        {
                            count = line.Count;
                        }
                    }
                }
            }
            if (count != -1)
            {
                for (num2 = 0; num2 < lineIndex; num2++)
                {
                    num3 += this.collection_0[num2].Count;
                }
                return (num3 + count);
            }
            return this.Items.Count;
        }

        public Rectangle GetCaretRange()
        {
            ILayoutElement element;
            if (!(this.bool_30 || (this.Items.Count != 0)))
            {
                switch (this.horizontalAlignment_0)
                {
                    case HorizontalAlignment.Left:
                        return new Rectangle(1, (base.Height - this.Font.Height) / 2, 1, this.Font.Height);

                    case HorizontalAlignment.Right:
                        return new Rectangle(base.Width - 1, (base.Height - this.Font.Height) / 2, 1, this.Font.Height);

                    case HorizontalAlignment.Center:
                        return new Rectangle(base.Width / 2, (base.Height - this.Font.Height) / 2, 1, this.Font.Height);
                }
            }
            if (this.Items.Count > this.int_4)
            {
                element = this.Items[this.int_4];
                return new Rectangle(element.Location.X + this.duiBaseControl_1.Left, element.Location.Y + this.duiBaseControl_1.Top, 1, element.Height + 1);
            }
            if (this.Items.Count > 0)
            {
                element = this.Items[this.collection_1.Count - 1];
                if ((element is DuiChar) && (((DuiChar) element).Char == '\n'))
                {
                    return new Rectangle(this.duiBaseControl_1.Left, (element.Location.Y + this.Font.Height) + this.duiBaseControl_1.Top, 1, element.Height + 1);
                }
                return new Rectangle((element.Location.X + element.Width) + this.duiBaseControl_1.Left, element.Location.Y + this.duiBaseControl_1.Top, 1, element.Height + 1);
            }
            return new Rectangle(this.duiBaseControl_1.Left + 1, this.duiBaseControl_1.Top, 1, this.Font.Height);
        }

        public int GetLineIndex(Point location)
        {
            location.Offset(-this.duiBaseControl_1.Left, -this.duiBaseControl_1.Top);
            int num = -1;
            int num2 = 0;
            if (location.Y <= this.duiBaseControl_1.Top)
            {
                return 0;
            }
            for (int i = 0; i < this.collection_0.Count; i++)
            {
                if ((location.Y >= num2) && (location.Y < (num2 + this.collection_0[i].Height)))
                {
                    num = i;
                    break;
                }
                num2 += this.collection_0[i].Height;
            }
            if (num == -1)
            {
                num = this.collection_0.Count - 1;
            }
            return num;
        }

        public DuiPictureBox InsertImage(int index, Image image)
        {
            if (image == null)
            {
                return null;
            }
            DuiPictureBox pic = new DuiPictureBox {
                Image = image,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            if (image.Width < ((base.Width - this.duiScrollBar_0.Width) / 2))
            {
                pic.Size = image.Size;
            }
            else
            {
                pic.Width = (base.Width - this.duiScrollBar_0.Width) / 2;
                pic.Height = (int) (((1.0 * image.Height) / ((double) image.Width)) * pic.Width);
            }
            pic.MouseUp += delegate (object sender, DuiMouseEventArgs e) {
                Point location = new Point(pic.Left - this.duiBaseControl_1.Left, (pic.Top - this.duiBaseControl_1.Top) + (pic.Height / 2));
                int careIndex = this.GetCareIndex(location);
                this.SelectionStart = careIndex;
                this.SelectionLength = 1;
            };
            pic.MouseDoubleClick += delegate (object sender, DuiMouseEventArgs e) {
                PopupImageEventArgs args2 = new PopupImageEventArgs {
                    Handled = false,
                    Image = pic.Image,
                    Position = this.Items.IndexOf(pic)
                };
                this.OnPopupImage(args2);
                if (!args2.Handled)
                {
                    if ((this.pictureBrowseForm_0 == null) || this.pictureBrowseForm_0.IsDisposed)
                    {
                        this.pictureBrowseForm_0 = new PictureBrowseForm();
                    }
                    this.pictureBrowseForm_0.Image = pic.Image;
                    this.pictureBrowseForm_0.Show();
                }
            };
            this.Items.Insert(index, pic);
            this.LayoutContent();
            return pic;
        }

        public void InsertText(string text)
        {
            if (!this.ReadOnly)
            {
                string str;
                int num2;
                if (!this.bool_30)
                {
                    text = text.Replace("\n", string.Empty);
                    text = text.Replace("\r", string.Empty);
                }
                if (this.SelectionLength > 0)
                {
                    if (!this.bool_30 && (this.char_0 != '\0'))
                    {
                        this.string_4 = this.string_4.Remove(this.SelectionStart, this.SelectionLength);
                        this.string_4 = this.string_4.Insert(this.SelectionStart, text);
                        str = string.Empty;
                        for (num2 = 0; num2 < text.Length; num2++)
                        {
                            str = str + this.char_0;
                        }
                        this.method_35(this.SelectionStart, this.SelectionLength, this.StringToElement(str));
                    }
                    else
                    {
                        this.method_35(this.SelectionStart, this.SelectionLength, this.StringToElement(text));
                    }
                    this.int_6 = 0;
                }
                else
                {
                    str = text;
                    if (!this.bool_30 && (this.char_0 != '\0'))
                    {
                        str = string.Empty;
                        this.string_4 = this.string_4.Insert(this.int_4, text);
                        for (num2 = 0; num2 < text.Length; num2++)
                        {
                            str = str + this.char_0;
                        }
                    }
                    foreach (ILayoutElement element in this.StringToElement(str))
                    {
                        this.Items.Insert(this.CaretIndex, element);
                        this.int_4++;
                    }
                    this.LayoutContent();
                }
            }
        }

        public virtual void LayoutContent()
        {
            int num;
            TextLine line;
            if (this.bool_30)
            {
                int num4 = base.Width - (this.duiScrollBar_0.Visible ? (this.duiScrollBar_0.Width - this.duiScrollBar_0.Margin.Horizontal) : 0);
                this.int_2 = 0;
                this.collection_0.Clear();
                Rectangle rectangle = new Rectangle();
                line = new TextLine();
                bool flag = false;
                for (int i = 0; i < this.Items.Count; i++)
                {
                    ILayoutElement element = this.Items[i];
                    if (element.Visible)
                    {
                        num = (rectangle.Width + element.Width) + element.Margin.Horizontal;
                        if (!(((num < num4) || (line.Count == 0)) ? flag : true))
                        {
                            rectangle.Width = num;
                            rectangle.Height = (rectangle.Height > (element.Height + element.Margin.Vertical)) ? rectangle.Height : (element.Height + element.Margin.Vertical);
                            if ((element is DuiChar) && (((DuiChar) element).Char == '\n'))
                            {
                                flag = true;
                            }
                            line.Add(element);
                        }
                        else
                        {
                            if ((element is DuiChar) && (((DuiChar) element).Char == '\n'))
                            {
                                flag = true;
                            }
                            else
                            {
                                flag = false;
                            }
                            this.method_31(num4, rectangle, line);
                            line.Height = rectangle.Height;
                            this.collection_0.Add(line);
                            line = new TextLine();
                            rectangle.Y = rectangle.Bottom;
                            rectangle.Size = new Size(element.Width + element.Margin.Horizontal, element.Height + element.Margin.Vertical);
                            line.Add(element);
                            if (!(this.duiScrollBar_0.Visible || (this.duiScrollBar_0.Visible == (this.int_2 > base.Height))))
                            {
                                this.duiScrollBar_0.Visible = this.int_2 > base.Height;
                                this.LayoutContent();
                                return;
                            }
                        }
                    }
                    if ((line.Count > 0) && (i == (this.Items.Count - 1)))
                    {
                        this.method_31(num4, rectangle, line);
                        this.collection_0.Add(line);
                        line = new TextLine();
                        if (this.duiScrollBar_0.Visible != (this.int_2 > base.Height))
                        {
                            this.duiScrollBar_0.Visible = this.int_2 > base.Height;
                            this.LayoutContent();
                            return;
                        }
                    }
                }
                if (this.bool_33)
                {
                    base.Height = this.int_2;
                }
                if (this.duiScrollBar_0.Visible && !this.duiScrollBar_0.IsMouseDown)
                {
                    if (this.int_2 < base.Height)
                    {
                        this.duiScrollBar_0.Visible = false;
                    }
                    this.duiScrollBar_0.Value = (-this.duiBaseControl_1.Top * 100) / (this.int_2 - base.Height);
                }
                if (this.int_2 > 0)
                {
                    int num2 = (int) ((base.Height - (this.duiScrollBar_0.ArrowHeight * 2)) * ((1.0 * base.Height) / ((double) this.int_2)));
                    this.duiScrollBar_0.ScrollBarLenght = (num2 < 20) ? 20 : num2;
                }
                if ((this.int_2 > base.Height) && (this.duiBaseControl_1.Top < (base.Height - this.int_2)))
                {
                    this.duiBaseControl_1.Top = base.Height - this.int_2;
                }
                else if (this.int_2 < base.Height)
                {
                    this.duiBaseControl_1.Top = 0;
                }
                this.duiBaseControl_1.Size = new Size(base.Width - (this.duiScrollBar_0.Visible ? (this.duiScrollBar_0.Width - this.duiScrollBar_0.Margin.Horizontal) : 0), this.int_2);
            }
            else
            {
                num = 0;
                int num6 = 0;
                if (this.bool_34)
                {
                    int num5 = 0;
                    foreach (ILayoutElement element in this.Items)
                    {
                        if (element.Visible)
                        {
                            num5 += element.Width + element.Margin.Horizontal;
                        }
                    }
                    num = num5;
                    int x = num5;
                    foreach (ILayoutElement element in this.Items)
                    {
                        if (element.Visible)
                        {
                            num6 = (num6 > (element.Height + element.Margin.Top)) ? num6 : (element.Height + element.Margin.Top);
                            x -= element.Width + element.Margin.Right;
                            element.Location = new Point(x, element.Margin.Top);
                            x -= element.Margin.Left;
                        }
                    }
                    this.int_2 = num6;
                }
                else
                {
                    if ((this.Items.Count > 0) && this.collection_1[0].Visible)
                    {
                        int left = this.Items[0].Margin.Left;
                        foreach (ILayoutElement element in this.Items)
                        {
                            if (element.Visible)
                            {
                                num6 = (num6 > (element.Height + element.Margin.Top)) ? num6 : (element.Height + element.Margin.Top);
                                element.Location = new Point(left, element.Margin.Top);
                                left += element.Width + element.Margin.Horizontal;
                            }
                        }
                        num = left;
                    }
                    this.int_2 = num6;
                }
                this.collection_0.Clear();
                line = new TextLine();
                foreach (ILayoutElement element in this.Items)
                {
                    if (element.Visible)
                    {
                        line.Add(element);
                    }
                }
                line.Height = this.int_2;
                this.collection_0.Add(line);
                if (num < base.Width)
                {
                    switch (this.horizontalAlignment_0)
                    {
                        case HorizontalAlignment.Left:
                            this.duiBaseControl_1.Left = 0;
                            break;

                        case HorizontalAlignment.Right:
                            this.duiBaseControl_1.Left = (base.Width - num) - 2;
                            break;

                        case HorizontalAlignment.Center:
                            this.duiBaseControl_1.Left = (base.Width - num) / 2;
                            break;
                    }
                }
                else if (this.duiBaseControl_1.Left < ((base.Width - num) - 2))
                {
                    this.duiBaseControl_1.Left = (base.Width - num) - 2;
                }
                else if (this.duiBaseControl_1.Left > 0)
                {
                    this.duiBaseControl_1.Left = 0;
                }
                this.duiBaseControl_1.Top = (base.Height - this.int_2) / 2;
                this.duiBaseControl_1.Size = new Size(num, this.int_2);
                this.duiScrollBar_0.Visible = false;
            }
            this.bool_27 = true;
            this.OnLayoutContented(EventArgs.Empty);
            this.Invalidate();
        }

        internal int method_29()
        {
            return this.int_2;
        }

        private void method_30()
        {
            if (func_0 == null)
            {
                func_0 = new Func<ILayoutElement, bool>(null, (IntPtr) smethod_5);
            }
            if (this.Items.FirstOrDefault<ILayoutElement>(func_0) != null)
            {
                DuiChar ch;
                Dictionary<int, string> dictionary = new Dictionary<int, string>();
                StringBuilder builder = new StringBuilder();
                int key = 0;
                int num2 = 0;
                while (num2 < this.Items.Count)
                {
                    ch = this.collection_1[num2] as DuiChar;
                    if (ch != null)
                    {
                        ch.ForeColor = Color.Empty;
                        ch.Font = this.Font;
                        builder.Append(ch.Char);
                    }
                    else
                    {
                        if (builder.Length > 0)
                        {
                            dictionary.Add(key, builder.ToString());
                            builder.Remove(0, builder.Length);
                        }
                        key = num2 + 1;
                    }
                    num2++;
                }
                if (builder.Length > 0)
                {
                    dictionary.Add(key, builder.ToString());
                }
                foreach (KeyValuePair<int, string> pair in dictionary)
                {
                    string input = pair.Value;
                    foreach (KeywordsStyle style in this.collection_2)
                    {
                        int startIndex = 0;
                        if (!string.IsNullOrEmpty(style.Keywords))
                        {
                            if (style.IsRegex)
                            {
                                RegexOptions options = style.IgnoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
                                foreach (Match match in Regex.Matches(input, style.Keywords, options))
                                {
                                    num2 = match.Index + pair.Key;
                                    while (num2 < ((match.Index + pair.Key) + match.Length))
                                    {
                                        if (num2 < this.collection_1.Count)
                                        {
                                            ch = this.collection_1[num2] as DuiChar;
                                            if (ch != null)
                                            {
                                                ch.Font = (style.Font == null) ? this.Font : style.Font;
                                                ch.ForeColor = style.Color;
                                            }
                                        }
                                        num2++;
                                    }
                                }
                            }
                            else
                            {
                                StringComparison comparisonType = style.IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
                                while ((startIndex = input.IndexOf(style.Keywords, startIndex, comparisonType)) > -1)
                                {
                                    for (num2 = startIndex + pair.Key; num2 < ((startIndex + pair.Key) + style.Keywords.Length); num2++)
                                    {
                                        if (num2 < this.collection_1.Count)
                                        {
                                            ch = this.collection_1[num2] as DuiChar;
                                            if (ch != null)
                                            {
                                                ch.Font = (style.Font == null) ? this.Font : style.Font;
                                                ch.ForeColor = style.Color;
                                            }
                                        }
                                    }
                                    startIndex++;
                                }
                            }
                        }
                    }
                }
            }
            this.bool_27 = false;
            this.Invalidate();
        }

        private void method_31(int int_8, Rectangle rectangle_2, TextLine textLine_0)
        {
            int width = 0;
            if (this.bool_34)
            {
                width = rectangle_2.Width;
            }
            for (int i = 0; i < textLine_0.Count; i++)
            {
                ILayoutElement element = textLine_0[i];
                element.Location = new Point(this.bool_34 ? ((width - element.Width) - element.Margin.Horizontal) : (width + element.Margin.Left), (rectangle_2.Bottom - element.Margin.Bottom) - element.Height);
                width = this.bool_34 ? ((width - element.Width) - element.Margin.Horizontal) : ((width + element.Width) + element.Margin.Horizontal);
            }
            this.int_2 = rectangle_2.Bottom;
        }

        private void method_32()
        {
            for (int i = 0; i < this.collection_1.Count; i++)
            {
                DuiBaseControl control;
                DuiChar ch = this.collection_1[i] as DuiChar;
                if ((i >= this.SelectionStart) && (i < (this.SelectionStart + this.SelectionLength)))
                {
                    if (ch != null)
                    {
                        ch.method_1(true);
                    }
                    else
                    {
                        control = this.collection_1[i] as DuiBaseControl;
                        if (control != null)
                        {
                            control.BackColor = this.color_3;
                            control.Borders.AllColor = Color.Black;
                        }
                    }
                }
                else if (ch != null)
                {
                    ch.method_1(false);
                }
                else
                {
                    control = this.collection_1[i] as DuiBaseControl;
                    if (control != null)
                    {
                        control.BackColor = Color.Transparent;
                        control.Borders.AllColor = Color.Transparent;
                    }
                }
            }
            this.Invalidate();
        }

        private void method_33(char char_1, Keys keys_0, Keys keys_1 = 0)
        {
            if ((keys_0 == Keys.C) && (keys_1 == Keys.Control))
            {
                this.Copy();
            }
            if (!this.ReadOnly)
            {
                switch (keys_0)
                {
                    case Keys.Back:
                        if (this.SelectionLength > 0)
                        {
                            this.method_36(this.SelectionStart, this.SelectionLength);
                            this.LayoutContent();
                            if (!((this.char_0 == '\0') || this.bool_30))
                            {
                                this.string_4 = this.string_4.Remove(this.SelectionStart, this.SelectionLength);
                            }
                            this.int_6 = 0;
                            this.CaretIndex = this.SelectionStart;
                        }
                        else if (this.CaretIndex > 0)
                        {
                            this.method_37();
                            this.CaretIndex--;
                            this.Items.RemoveAt(this.CaretIndex);
                            if (!((this.char_0 == '\0') || this.bool_30))
                            {
                                this.string_4 = this.string_4.Remove(this.CaretIndex, 1);
                            }
                            this.LayoutContent();
                        }
                        break;

                    case Keys.Delete:
                        if (this.int_6 > 0)
                        {
                            this.method_36(this.SelectionStart, this.SelectionLength);
                            this.LayoutContent();
                            if (!((this.char_0 == '\0') || this.bool_30))
                            {
                                this.string_4 = this.string_4.Remove(this.SelectionStart, this.SelectionLength);
                            }
                            this.int_6 = 0;
                            this.CaretIndex = this.SelectionStart;
                        }
                        else if (this.CaretIndex < this.Items.Count)
                        {
                            this.method_37();
                            this.Items.RemoveAt(this.CaretIndex);
                            if (!((this.char_0 == '\0') || this.bool_30))
                            {
                                this.string_4 = this.string_4.Remove(this.CaretIndex, 1);
                            }
                            this.LayoutContent();
                        }
                        break;

                    case Keys.V:
                        if (keys_1 == Keys.Control)
                        {
                            this.Paste();
                        }
                        break;

                    case Keys.X:
                        if (keys_1 == Keys.Control)
                        {
                            this.Cut();
                        }
                        break;

                    case Keys.Z:
                        if (keys_1 == Keys.Control)
                        {
                            this.Undo();
                        }
                        break;

                    case Keys.A:
                        if (keys_1 == Keys.Control)
                        {
                            this.SelectionStart = 0;
                            this.SelectionLength = this.Items.Count;
                        }
                        break;
                }
                if ((((char_1 == '\n') || (char_1 == '\t')) || (char_1 == '\r')) || (char_1 > '\x001f'))
                {
                    if (!(this.bool_30 || (((char_1 != '\r') && (char_1 != '\n')) && (char_1 != '\t'))))
                    {
                        return;
                    }
                    if (char_1 == '\r')
                    {
                        char_1 = '\n';
                    }
                    if ((!this.bool_30 && (this.char_0 != '\0')) && (char_1 == '\t'))
                    {
                        return;
                    }
                    this.method_37();
                    if (this.SelectionLength > 0)
                    {
                        if (!(this.bool_30 || (this.char_0 == '\0')))
                        {
                            this.string_4 = this.string_4.Remove(this.SelectionStart, this.SelectionLength);
                            this.string_4 = this.string_4.Insert(this.SelectionStart, char_1.ToString());
                            char_1 = this.char_0;
                        }
                        this.method_35(this.SelectionStart, this.SelectionLength, this.StringToElement(char_1.ToString()));
                        this.int_6 = 0;
                        this.CaretIndex = this.SelectionStart + 1;
                    }
                    else
                    {
                        if (!(this.bool_30 || (this.char_0 == '\0')))
                        {
                            this.string_4 = this.string_4.Insert(this.CaretIndex, char_1.ToString());
                            char_1 = this.char_0;
                        }
                        this.Items.Insert(this.CaretIndex, this.StringToElement(char_1.ToString())[0]);
                        this.LayoutContent();
                        this.CaretIndex++;
                    }
                }
                if (this.string_3 != this.Text)
                {
                    this.OnTextChanged(EventArgs.Empty);
                    base.OnPropertyChanged("Text");
                }
            }
        }

        private void method_34(char char_1)
        {
            this.method_33(char_1, Keys.None, Keys.None);
        }

        private void method_35(int int_8, int int_9, ILayoutElement[] ilayoutElement_1)
        {
            this.method_36(int_8, int_9);
            for (int i = 0; i < ilayoutElement_1.Length; i++)
            {
                this.Items.Insert(int_8 + i, ilayoutElement_1[i]);
            }
            this.LayoutContent();
        }

        private void method_36(int int_8, int int_9)
        {
            this.method_37();
            for (int i = int_8; i < (int_9 + int_8); i++)
            {
                DuiBaseControl control = this.collection_1[i] as DuiBaseControl;
                if (control != null)
                {
                    this.duiBaseControl_1.Controls.Remove(control);
                }
            }
            this.Items.InnerList.RemoveRange(int_8, int_9);
        }

        private void method_37()
        {
            if ((this.ilayoutElement_0 == null) || (this.ilayoutElement_0.Length != this.Items.Count))
            {
                this.ilayoutElement_0 = new ILayoutElement[this.collection_1.Count];
            }
            this.collection_1.InnerList.CopyTo(this.ilayoutElement_0);
            this.string_3 = this.Text;
        }

        private bool method_38(int int_8, char char_1)
        {
            return (((int_8 == 0) && Class48.smethod_1(char_1, false)) || (((int_8 == 1) && Class48.smethod_2(char_1)) || ((int_8 == 2) && Class48.smethod_0(char_1))));
        }

        private void method_39(Rectangle rectangle_2)
        {
            if (this.HostControl != null)
            {
                IntPtr handle = this.HostControl.Handle;
                IntPtr hIMC = DSkin.NativeMethods.ImmGetContext(handle);
                if (hIMC != IntPtr.Zero)
                {
                    Point locationToControl = base.LocationToControl;
                    locationToControl.Offset(rectangle_2.X, rectangle_2.Y + 2);
                    DSkin.NativeMethods.COMPOSITIONFORM lpCompForm = new DSkin.NativeMethods.COMPOSITIONFORM {
                        dwStyle = 2,
                        ptCurrentPos = new DSkin.POINT(locationToControl.X, locationToControl.Y)
                    };
                    DSkin.NativeMethods.ImmSetCompositionWindow(hIMC, ref lpCompForm);
                }
                DSkin.NativeMethods.ImmReleaseContext(handle, hIMC);
            }
        }

        [CompilerGenerated]
        private void method_40(object sender, EventArgs e)
        {
            if (this.bool_27)
            {
                this.method_30();
            }
        }

        [CompilerGenerated]
        private void method_41(object sender, CollectionEventArgs<ILayoutElement> e)
        {
            DuiChar item = e.Item as DuiChar;
            if (item != null)
            {
                if (item.Font == null)
                {
                    item.Font = this.Font;
                }
            }
            else
            {
                DuiBaseControl control = e.Item as DuiBaseControl;
                if (control != null)
                {
                    control.Parent = this.duiBaseControl_1;
                }
            }
        }

        protected override void OnFocusedChanged(EventArgs e)
        {
            if (this.Focused)
            {
                this.timer_1.Start();
                if (this.HostControl != null)
                {
                    IntPtr handle = this.HostControl.Handle;
                    if ((this.char_0 == '\0') || this.bool_30)
                    {
                        DSkin.Common.ImeContext.Enable(handle);
                        this.method_39(this.GetCaretRange());
                    }
                    else
                    {
                        DSkin.Common.ImeContext.Disable(handle);
                    }
                }
            }
            else
            {
                this.bool_28 = false;
                this.timer_1.Stop();
                this.Invalidate();
            }
            base.OnFocusedChanged(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            for (int i = 0; i < this.Items.Count; i++)
            {
                DuiChar ch = this.collection_1[i] as DuiChar;
                if (ch != null)
                {
                    ch.Font = this.Font;
                }
            }
            this.LayoutContent();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!e.Handled)
            {
                this.method_33('\0', e.KeyCode, e.Modifiers);
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (!e.Handled && (((this.int_7 <= 0) || (this.Items.Count < this.int_7)) || (this.SelectionLength != 0)))
            {
                this.method_34(e.KeyChar);
                e.Handled = true;
            }
        }

        protected virtual void OnLayoutContented(EventArgs e)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, e);
            }
        }

        protected override void OnMouseDoubleClick(DuiMouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            ILayoutElement element = null;
            int num = -1;
            if (this.int_4 < this.Items.Count)
            {
                element = this.collection_1[this.int_4];
                num = this.int_4;
            }
            else if (this.collection_1.Count > 0)
            {
                element = this.collection_1[this.collection_1.Count - 1];
                num = this.collection_1.Count - 1;
            }
            if (element != null)
            {
                int num5 = num;
                int num4 = 1;
                DuiChar ch = element as DuiChar;
                int num3 = 3;
                if (ch != null)
                {
                    int num2;
                    DuiChar ch2;
                    if (Class48.smethod_1(ch.Char, false))
                    {
                        num3 = 0;
                    }
                    else if (Class48.smethod_2(ch.Char))
                    {
                        num3 = 1;
                    }
                    else if (Class48.smethod_0(ch.Char))
                    {
                        num3 = 2;
                    }
                    if (num > 0)
                    {
                        for (num2 = num - 1; num2 >= 0; num2--)
                        {
                            ch2 = this.collection_1[num2] as DuiChar;
                            if ((ch2 == null) || !this.method_38(num3, ch2.Char))
                            {
                                break;
                            }
                            num4++;
                            num5 = num2;
                        }
                    }
                    if (num < this.collection_1.Count)
                    {
                        for (num2 = num + 1; num2 < this.collection_1.Count; num2++)
                        {
                            ch2 = this.collection_1[num2] as DuiChar;
                            if ((ch2 == null) || !this.method_38(num3, ch2.Char))
                            {
                                break;
                            }
                            num4++;
                        }
                    }
                    this.SelectionLength = num4;
                    this.SelectionStart = num5;
                }
            }
        }

        protected override void OnMouseDown(DuiMouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                if (!(this.duiScrollBar_0.Visible && (!this.duiScrollBar_0.Visible || this.duiScrollBar_0.ClientRectangle.Contains(e.Location))))
                {
                    this.CaretIndex = this.GetCareIndex(e.Location);
                }
                if (!this.duiScrollBar_0.Visible || (this.duiScrollBar_0.Visible && !this.duiScrollBar_0.ClientRectangle.Contains(e.Location)))
                {
                    if (Control.ModifierKeys != Keys.Shift)
                    {
                        this.int_1 = this.CaretIndex;
                        this.SelectionStart = 0;
                        this.SelectionLength = 0;
                    }
                    else if (Control.ModifierKeys == Keys.Shift)
                    {
                        int careIndex = this.GetCareIndex(e.Location);
                        this.CaretIndex = careIndex;
                        if (careIndex > this.int_1)
                        {
                            this.SelectionLength = careIndex - this.int_1;
                            this.SelectionStart = this.int_1;
                        }
                        else if (careIndex < this.int_1)
                        {
                            this.SelectionLength = this.int_1 - careIndex;
                            this.SelectionStart = careIndex;
                        }
                        else
                        {
                            this.SelectionLength = 0;
                        }
                    }
                }
            }
        }

        protected override void OnMouseMove(DuiMouseEventArgs e)
        {
            base.OnMouseMove(e);
            if ((base.IsMouseDown && (e.Button == MouseButtons.Left)) && !this.duiScrollBar_0.IsMouseDown)
            {
                int careIndex = this.GetCareIndex(e.Location);
                this.CaretIndex = careIndex;
                if (careIndex > this.int_1)
                {
                    this.SelectionLength = careIndex - this.int_1;
                    this.SelectionStart = this.int_1;
                }
                else if (careIndex < this.int_1)
                {
                    this.SelectionLength = this.int_1 - careIndex;
                    this.SelectionStart = careIndex;
                }
                else
                {
                    this.SelectionLength = 0;
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (this.int_2 >= base.Height)
            {
                if ((e.Delta > 0) && (this.duiBaseControl_1.Top < 0))
                {
                    this.duiBaseControl_1.Top += this.int_3;
                    if (this.duiBaseControl_1.Top > 0)
                    {
                        this.duiBaseControl_1.Top = 0;
                    }
                }
                else if ((e.Delta < 0) && (this.duiBaseControl_1.Top > (base.Height - this.int_2)))
                {
                    this.duiBaseControl_1.Top -= this.int_3;
                    if (this.duiBaseControl_1.Top < (base.Height - this.int_2))
                    {
                        this.duiBaseControl_1.Top = base.Height - this.int_2;
                    }
                }
                if (!(!this.duiScrollBar_0.Visible || this.duiScrollBar_0.IsMouseDown))
                {
                    this.duiScrollBar_0.Value = (-this.duiBaseControl_1.Top * 100) / (this.int_2 - base.Height);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.bool_28)
            {
                using (Pen pen = new Pen(this.ForeColor))
                {
                    Rectangle caretRange = this.GetCaretRange();
                    e.Graphics.DrawLine(pen, new Point(caretRange.Left, caretRange.Top), new Point(caretRange.Left, (caretRange.Top + caretRange.Height) - 2));
                }
            }
            base.OnPaint(e);
        }

        protected virtual void OnPopupImage(PopupImageEventArgs e)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, e);
            }
        }

        protected override void OnPrePaint(PaintEventArgs e)
        {
            base.OnPrePaint(e);
            Graphics graphics = e.Graphics;
            graphics.TextRenderingHint = this.textRenderingHint_0;
            using (SolidBrush brush = new SolidBrush(Color.FromArgb((this.ForeColor.A == 0xff) ? 0xfe : this.ForeColor.A, this.ForeColor)))
            {
                using (SolidBrush brush2 = new SolidBrush(this.SelectionBackColor))
                {
                    SolidBrush brush3 = null;
                    if (this.color_4 != Color.Empty)
                    {
                        brush3 = new SolidBrush(Color.FromArgb((this.SelectionColor.A == 0xff) ? 0xfe : this.SelectionColor.A, this.SelectionColor));
                    }
                    foreach (ILayoutElement element in this.Items)
                    {
                        DuiChar ch = element as DuiChar;
                        if (ch != null)
                        {
                            Point location = ch.Location;
                            location.Offset(this.duiBaseControl_1.Location);
                            Rectangle rect = new Rectangle(location, ch.Size);
                            if (rect.IntersectsWith(e.ClipRectangle))
                            {
                                if (ch.method_0())
                                {
                                    graphics.FillRectangle(brush2, rect);
                                }
                                if (ch.ForeColor != Color.Empty)
                                {
                                    using (SolidBrush brush4 = new SolidBrush(Color.FromArgb((ch.ForeColor.A == 0xff) ? 0xfe : ch.ForeColor.A, ch.ForeColor)))
                                    {
                                        graphics.DrawString(ch.Char.ToString(), (ch.Font == null) ? this.Font : ch.Font, (!ch.method_0() || (brush3 == null)) ? brush4 : brush3, (PointF) location, stringFormat_0);
                                        continue;
                                    }
                                }
                                graphics.DrawString(ch.Char.ToString(), (ch.Font == null) ? this.Font : ch.Font, (!ch.method_0() || (brush3 == null)) ? brush : brush3, (PointF) location, stringFormat_0);
                            }
                        }
                    }
                    if (brush3 != null)
                    {
                        brush3.Dispose();
                    }
                }
            }
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            Rectangle caretRange;
            base.OnPreviewKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.PageUp:
                    if (this.bool_30)
                    {
                        caretRange = this.GetCaretRange();
                        this.CaretIndex = this.GetCareIndex(new Point(caretRange.X, -base.Height));
                    }
                    break;

                case Keys.Next:
                    if (this.bool_30)
                    {
                        caretRange = this.GetCaretRange();
                        this.CaretIndex = this.GetCareIndex(new Point(caretRange.X, 2 * base.Height));
                    }
                    break;

                case Keys.End:
                    caretRange = this.GetCaretRange();
                    this.CaretIndex = this.GetCareIndex(new Point(base.Width, caretRange.Y));
                    break;

                case Keys.Home:
                    caretRange = this.GetCaretRange();
                    this.CaretIndex = this.GetCareIndex(new Point(0, caretRange.Y));
                    break;

                case Keys.Left:
                    this.Invalidate(this.GetCaretRange());
                    this.SelectionLength = 0;
                    this.CaretIndex--;
                    e.IsInputKey = true;
                    break;

                case Keys.Up:
                    caretRange = this.GetCaretRange();
                    this.SelectionLength = 0;
                    if (this.CaretIndex > 0)
                    {
                        this.CaretIndex = this.GetCareIndex(new Point(caretRange.X, caretRange.Y - 3));
                    }
                    e.IsInputKey = true;
                    break;

                case Keys.Right:
                    this.Invalidate(this.GetCaretRange());
                    this.SelectionLength = 0;
                    this.CaretIndex++;
                    e.IsInputKey = true;
                    break;

                case Keys.Down:
                    caretRange = this.GetCaretRange();
                    if (this.CaretIndex != this.Items.Count)
                    {
                        this.SelectionLength = 0;
                        this.CaretIndex = this.GetCareIndex(new Point(caretRange.X, (caretRange.Y + caretRange.Height) + 2));
                    }
                    e.IsInputKey = true;
                    break;

                case Keys.Tab:
                    if (this.bool_30)
                    {
                        e.IsInputKey = true;
                    }
                    break;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.LayoutContent();
        }

        protected override void OnStartPaint(EventArgs e)
        {
            base.OnStartPaint(e);
            this.duiScrollBar_0.DesignModeCanSelect = false;
            this.duiScrollBar_0.ClientRectangle = new Rectangle(new Point(base.Width - this.duiScrollBar_0.Width, 0), new Size(this.duiScrollBar_0.Width, base.Height));
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (this.eventHandler_2 != null)
            {
                this.eventHandler_2(this, e);
            }
        }

        public void Paste()
        {
            this.method_37();
            string text = null;
            if (Clipboard.ContainsText())
            {
                text = Clipboard.GetText();
            }
            Image image = Clipboard.GetImage();
            if (text != null)
            {
                this.InsertText(text);
            }
            if (this.bool_30 && this.bool_35)
            {
                string str2 = Clipboard.GetText(TextDataFormat.Html);
                if (!string.IsNullOrEmpty(str2))
                {
                    byte[] bytes = Encoding.Default.GetBytes(str2);
                    foreach (string str3 in smethod_2(Encoding.UTF8.GetString(bytes)))
                    {
                        string str4 = str3;
                        if (!string.IsNullOrEmpty(str4) && (str4.IndexOf("file:///") == 0))
                        {
                            str4 = str4.Substring(8, str4.Length - 8);
                            try
                            {
                                Image original = Image.FromFile(str4);
                                this.InsertImage(this.int_4, new Bitmap(original));
                                original.Dispose();
                                this.int_4++;
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
                if (image != null)
                {
                    this.InsertImage(this.int_4, image);
                    this.int_4++;
                }
            }
            if ((this.int_7 > 0) && (this.Items.Count > this.int_7))
            {
                this.method_36(this.int_7, this.collection_1.Count - this.int_7);
                this.LayoutContent();
                this.int_4 = this.collection_1.Count;
            }
        }

        public void SelectAll()
        {
            this.SelectionLength = this.Items.Count;
            this.SelectionStart = 0;
        }

        private static MemoryStream smethod_0(string string_5)
        {
            Encoding encoding = Encoding.UTF8;
            string format = "Version:0.9\r\nStartHTML:{0:000000}\r\nEndHTML:{1:000000}\r\nStartFragment:{2:000000}\r\nEndFragment:{3:000000}\r\n";
            string s = "<html>\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=" + encoding.WebName + "\">\r\n<title>HTML clipboard</title>\r\n</head>\r\n<body>\r\n<!--StartFragment-->";
            string str3 = "<!--EndFragment-->\r\n</body>\r\n</html>\r\n";
            string str4 = string.Format(format, new object[] { 0, 0, 0, 0 });
            int byteCount = encoding.GetByteCount(str4);
            int num2 = encoding.GetByteCount(s);
            int num3 = encoding.GetByteCount(string_5);
            int num4 = encoding.GetByteCount(str3);
            string str5 = string.Format(format, new object[] { byteCount, ((byteCount + num2) + num3) + num4, byteCount + num2, (byteCount + num2) + num3 }) + s + string_5 + str3;
            return new MemoryStream(encoding.GetBytes(str5));
        }

        private static string smethod_1(string string_5)
        {
            Match match = new Regex("<img\\b[^<>]*?\\bsrc[\\s\\t\\r\\n]*=[\\s\\t\\r\\n]*[\"']?[\\s\\t\\r\\n]*(?<imgUrl>[^\\t\\r\\n\"'<>]*)[^<>]*?/?[\\s\\t\\r\\n]*>", RegexOptions.IgnoreCase).Match(string_5);
            if (match.Success)
            {
                return match.Groups["imgUrl"].Value;
            }
            return string.Empty;
        }

        private static List<string> smethod_2(string string_5)
        {
            List<string> list = new List<string>();
            foreach (Match match in Regex.Matches(string_5, "<img\\b[^<>]*?\\bsrc[\\s\\t\\r\\n]*=[\\s\\t\\r\\n]*[\"']?[\\s\\t\\r\\n]*(?<imgUrl>[^\\t\\r\\n\"'<>]*)[^<>]*?/?[\\s\\t\\r\\n]*>", RegexOptions.IgnoreCase))
            {
                list.Add(match.Groups["imgUrl"].Value);
            }
            return list;
        }

        [CompilerGenerated]
        private static void smethod_3(object sender, DuiControlEventArgs e)
        {
            e.Control.CanActive = false;
            e.Control.IsMoveParentPaint = false;
        }

        [CompilerGenerated]
        private static void smethod_4(object sender, CollectionEventArgs<ILayoutElement> e)
        {
            DuiBaseControl item = e.Item as DuiBaseControl;
            if (item != null)
            {
                item.Parent = null;
            }
        }

        [CompilerGenerated]
        private static bool smethod_5(object object_38)
        {
            return (object_38 is DuiChar);
        }

        public ILayoutElement[] StringToElement(string text)
        {
            List<ILayoutElement> list = new List<ILayoutElement>();
            if (text != null)
            {
                foreach (char ch in text)
                {
                    if (ch != '\r')
                    {
                        DuiChar item = new DuiChar(ch);
                        list.Add(item);
                    }
                }
            }
            return list.ToArray();
        }

        public ILayoutElement[] StringToElement(string text, Font font, Color color)
        {
            List<ILayoutElement> list = new List<ILayoutElement>();
            if (text != null)
            {
                foreach (char ch in text)
                {
                    if (ch != '\r')
                    {
                        DuiChar item = new DuiChar(ch, font, color);
                        list.Add(item);
                    }
                }
            }
            return list.ToArray();
        }

        private void timer_1_Tick(object sender, EventArgs e)
        {
            this.bool_28 = !this.bool_28;
            this.Invalidate(this.GetCaretRange());
        }

        public void Undo()
        {
            ILayoutElement[] array = new ILayoutElement[this.Items.Count];
            this.Items.InnerList.CopyTo(array);
            string text = this.Text;
            if (this.ilayoutElement_0 != null)
            {
                this.collection_1.InnerList.Clear();
                this.duiBaseControl_1.Controls.Clear();
                this.collection_1.InnerList.AddRange(this.ilayoutElement_0);
                foreach (ILayoutElement element in this.collection_1)
                {
                    DuiBaseControl control = element as DuiBaseControl;
                    DuiChar ch = element as DuiChar;
                    if (control != null)
                    {
                        control.Parent = this.duiBaseControl_1;
                        control.Borders.AllColor = Color.Transparent;
                        control.BackColor = Color.Transparent;
                    }
                    else if (ch != null)
                    {
                        ch.method_1(false);
                    }
                }
                if (this.int_4 > this.collection_1.Count)
                {
                    this.int_4 = this.collection_1.Count;
                }
                if (this.char_0 != '\0')
                {
                    this.string_4 = this.string_3;
                }
                this.LayoutContent();
            }
            this.ilayoutElement_0 = array;
            this.string_3 = text;
            if (this.string_3 != this.Text)
            {
                this.OnTextChanged(EventArgs.Empty);
                base.OnPropertyChanged("Text");
            }
        }

        [DefaultValue(true), Description("是否允许粘贴图片")]
        public bool AllowPasteImage
        {
            get
            {
                return this.bool_35;
            }
            set
            {
                this.bool_35 = value;
            }
        }

        [DefaultValue(false), Description("自动高度，多行模式下才有效，并且滚动条将被隐藏")]
        public bool AutoHeight
        {
            get
            {
                return this.bool_33;
            }
            set
            {
                if (this.bool_33 != value)
                {
                    this.bool_33 = value;
                    if (value)
                    {
                        this.duiScrollBar_0.Visible = false;
                        this.LayoutContent();
                    }
                }
            }
        }

        [DefaultValue(typeof(Color), "100,255,255,255")]
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool CanFocus
        {
            get
            {
                return true;
            }
            set
            {
                base.CanFocus = value;
            }
        }

        [Description("光标颜色"), DefaultValue(typeof(Color), "ControlText")]
        public Color CaretColor
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CaretIndex
        {
            get
            {
                return this.int_4;
            }
            set
            {
                if (this.int_4 != value)
                {
                    this.bool_28 = true;
                    if (value < 0)
                    {
                        this.int_4 = 0;
                    }
                    else if (value > this.Items.Count)
                    {
                        this.int_4 = this.Items.Count;
                    }
                    else
                    {
                        this.int_4 = value;
                    }
                    Rectangle caretRange = this.GetCaretRange();
                    if (this.bool_30)
                    {
                        if (this.int_2 > base.Height)
                        {
                            if ((caretRange.Y + caretRange.Height) > base.Height)
                            {
                                this.duiBaseControl_1.Top -= ((caretRange.Y + caretRange.Height) - base.Height) + 2;
                                if (this.duiBaseControl_1.Top < (base.Height - this.int_2))
                                {
                                    this.duiBaseControl_1.Top = base.Height - this.int_2;
                                }
                            }
                            if (caretRange.Y < 0)
                            {
                                this.duiBaseControl_1.Top -= caretRange.Y - 2;
                                if (this.duiBaseControl_1.Top > 0)
                                {
                                    this.duiBaseControl_1.Top = 0;
                                }
                            }
                        }
                        else if (this.duiBaseControl_1.Top < 0)
                        {
                            this.duiBaseControl_1.Top = 0;
                        }
                    }
                    else if (caretRange.X < 0)
                    {
                        this.duiBaseControl_1.Left += this.Font.Height;
                        if (this.duiBaseControl_1.Left > 0)
                        {
                            this.duiBaseControl_1.Left = 0;
                        }
                    }
                    else if (caretRange.X > (base.Width - 1))
                    {
                        if ((this.duiBaseControl_1.Left - this.Font.Height) < (base.Width - this.duiBaseControl_1.Width))
                        {
                            this.duiBaseControl_1.Left = (base.Width - this.duiBaseControl_1.Width) - 2;
                        }
                        else
                        {
                            this.duiBaseControl_1.Left -= this.Font.Height;
                        }
                    }
                    this.method_39(caretRange);
                    if (!(!this.duiScrollBar_0.Visible || this.duiScrollBar_0.IsMouseDown))
                    {
                        this.duiScrollBar_0.Value = (-this.duiBaseControl_1.Top * 100) / (this.int_2 - base.Height);
                    }
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(typeof(Cursors), "IBeam")]
        public override System.Windows.Forms.Cursor Cursor
        {
            get
            {
                return base.Cursor;
            }
            set
            {
                this.duiBaseControl_1.Cursor = value;
                base.Cursor = value;
            }
        }

        [Description("是否启用关键词渲染，KeywordsStyles属性来定义关键词"), DefaultValue(false)]
        public bool EnabledRenderKeywords
        {
            get
            {
                return this.timer_0.Enabled;
            }
            set
            {
                this.timer_0.Enabled = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DuiScrollBar InnerScrollBar
        {
            get
            {
                return this.duiScrollBar_0;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool IsInsert
        {
            get
            {
                return this.bool_29;
            }
            set
            {
                this.bool_29 = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public Collection<ILayoutElement> Items
        {
            get
            {
                EventHandler<CollectionEventArgs<ILayoutElement>> handler = null;
                if (this.collection_1 == null)
                {
                    this.collection_1 = new Collection<ILayoutElement>();
                    if (handler == null)
                    {
                        handler = new EventHandler<CollectionEventArgs<ILayoutElement>>(this.method_41);
                    }
                    this.collection_1.ItemAdded += handler;
                    if (eventHandler_4 == null)
                    {
                        eventHandler_4 = new EventHandler<CollectionEventArgs<ILayoutElement>>(DuiTextBox.smethod_4);
                    }
                    this.collection_1.ItemRemoved += eventHandler_4;
                }
                return this.collection_1;
            }
        }

        [Description("关键词样式集合"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Collection<KeywordsStyle> KeywordsStyles
        {
            get
            {
                return this.collection_2;
            }
        }

        [Browsable(false)]
        public Collection<TextLine> Lines
        {
            get
            {
                return this.collection_0;
            }
        }

        [Description("最大长度"), DefaultValue(0)]
        public int MaxLength
        {
            get
            {
                return this.int_7;
            }
            set
            {
                this.int_7 = value;
            }
        }

        [DefaultValue(false), Description("是否多行")]
        public bool Multiline
        {
            get
            {
                return this.bool_30;
            }
            set
            {
                this.bool_30 = value;
            }
        }

        [Description("指示为单行文本编辑控件的密码输入显示的字符"), DefaultValue(typeof(char), "")]
        public char PasswordChar
        {
            get
            {
                return this.char_0;
            }
            set
            {
                if (this.char_0 != value)
                {
                    this.char_0 = value;
                }
            }
        }

        [Description("是否只读"), DefaultValue(false)]
        public bool ReadOnly
        {
            get
            {
                return this.bool_31;
            }
            set
            {
                this.bool_31 = value;
            }
        }

        [Description("获取或设置一个值，该值指示是否将控件的元素对齐以支持使用从右向左的字体的区域设置。"), DefaultValue(false)]
        public bool RightToLeft
        {
            get
            {
                return this.bool_34;
            }
            set
            {
                if (this.bool_34 != value)
                {
                    this.bool_34 = value;
                    this.LayoutContent();
                }
            }
        }

        [DefaultValue(12), Description("滚轮每格滚动的像素")]
        public int RollSize
        {
            get
            {
                return this.int_3;
            }
            set
            {
                this.int_3 = value;
            }
        }

        [Browsable(false)]
        public int RowCount
        {
            get
            {
                return this.collection_0.Count;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string SelectedText
        {
            get
            {
                if (this.SelectionLength > 0)
                {
                    StringBuilder builder = new StringBuilder();
                    for (int i = this.SelectionStart; i < (this.SelectionStart + this.SelectionLength); i++)
                    {
                        if (this.Items[i] is DuiChar)
                        {
                            DuiChar ch = (DuiChar) this.Items[i];
                            if (ch.Char == '\n')
                            {
                                builder.Append("\r\n");
                            }
                            else
                            {
                                builder.Append(ch.Char);
                            }
                        }
                    }
                    return builder.ToString();
                }
                return string.Empty;
            }
        }

        [Description("被选中的文字背景颜色"), DefaultValue(typeof(Color), "Gray")]
        public Color SelectionBackColor
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

        [DefaultValue(typeof(Color), "White"), Description("被选中的文字颜色")]
        public Color SelectionColor
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

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionLength
        {
            get
            {
                return this.int_6;
            }
            set
            {
                if (this.int_6 != value)
                {
                    if (value > this.Items.Count)
                    {
                        this.int_6 = this.Items.Count;
                    }
                    else
                    {
                        this.int_6 = value;
                    }
                    this.method_32();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int SelectionStart
        {
            get
            {
                return this.int_5;
            }
            set
            {
                if (this.int_5 != value)
                {
                    if (value < 0)
                    {
                        this.int_5 = 0;
                    }
                    else
                    {
                        this.int_5 = value;
                    }
                    this.method_32();
                }
            }
        }

        [Description("显示滚动条"), DefaultValue(true)]
        public bool ShowScrollBar
        {
            get
            {
                return this.bool_32;
            }
            set
            {
                this.bool_32 = value;
            }
        }

        [DefaultValue(true)]
        public override bool TabStop
        {
            get
            {
                return base.TabStop;
            }
            set
            {
                base.TabStop = value;
            }
        }

        [DefaultValue(""), Description("文本内容")]
        public override string Text
        {
            get
            {
                if ((this.char_0 == '\0') || this.bool_30)
                {
                    StringBuilder builder = new StringBuilder();
                    foreach (ILayoutElement element in this.Items)
                    {
                        if (element is DuiChar)
                        {
                            builder.Append(((DuiChar) element).Char);
                        }
                    }
                    this.string_4 = builder.ToString();
                }
                return this.string_4;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                this.string_4 = value;
                this.collection_1.InnerList.Clear();
                this.duiBaseControl_1.Controls.Clear();
                if ((this.char_0 == '\0') || this.bool_30)
                {
                    this.Items.AddRange(this.StringToElement(this.string_4));
                }
                else
                {
                    string text = string.Empty;
                    for (int i = 0; i < this.string_4.Length; i++)
                    {
                        text = text + this.char_0;
                    }
                    this.Items.AddRange(this.StringToElement(text));
                }
                this.LayoutContent();
                this.int_4 = this.Items.Count;
                if (!this.Focused)
                {
                    this.bool_28 = false;
                }
                this.OnTextChanged(EventArgs.Empty);
                base.OnPropertyChanged("Text");
            }
        }

        [Description("文本对齐方式，只支持单行模式"), DefaultValue(0)]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return this.horizontalAlignment_0;
            }
            set
            {
                if (this.horizontalAlignment_0 != value)
                {
                    this.horizontalAlignment_0 = value;
                    this.LayoutContent();
                }
            }
        }

        [Description("文字渲染模式"), DefaultValue(typeof(TextRenderingHint), "SystemDefault")]
        public TextRenderingHint TextRenderMode
        {
            get
            {
                return this.textRenderingHint_0;
            }
            set
            {
                if (this.textRenderingHint_0 != value)
                {
                    this.textRenderingHint_0 = value;
                    this.Invalidate();
                }
            }
        }
    }
}

