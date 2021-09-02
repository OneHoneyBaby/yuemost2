namespace DSkin.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    public class GClass4 : RichTextBox
    {
        private ContextMenuStrip asOdsXsfqG;
        private bool bool_0 = false;
        private ChatBoxContextMenuMode chatBoxContextMenuMode_0 = ChatBoxContextMenuMode.None;
        private Class54 class54_0;
        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private ContextMenuStrip contextMenuStrip3;
        [CompilerGenerated]
        private Control control_0;
        private Dictionary<uint, Image> dictionary_0 = new Dictionary<uint, Image>();
        private IContainer icontainer_0;
        private Image image_0 = null;
        [CompilerGenerated]
        private int int_0;
        private List<Control> list_0 = new List<Control>();
        [CompilerGenerated]
        private Point point_0;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;

        [Description("当文件（夹）拖放到控件内时，触发此事件。")]
        public event CbGeneric<string[]> FileOrFolderDragDrop;

        public GClass4()
        {
            this.method_7();
            this.AllowDrop = false;
            base.DragDrop += new DragEventHandler(this.GClass4_DragDrop);
            base.DragEnter += new DragEventHandler(this.GClass4_DragEnter);
            base.KeyDown += new KeyEventHandler(this.GClass4_KeyDown);
            base.MouseDown += new MouseEventHandler(this.GClass4_MouseDown);
            base.MouseMove += new MouseEventHandler(this.GClass4_MouseMove);
            base.SizeChanged += new EventHandler(this.GClass4_SizeChanged);
            base.DoubleClick += new EventHandler(this.GClass4_DoubleClick);
            base.LinkClicked += new LinkClickedEventHandler(this.GClass4_LinkClicked);
        }

        public void AppendChatBoxContent(ChatBoxContent content, int? StartIndex = new int?())
        {
            try
            {
                if ((content != null) && (content.Text != null))
                {
                    int start = !StartIndex.HasValue ? this.Text.Length : StartIndex.Value;
                    if (content.EmotionDictionary != null)
                    {
                        int num3;
                        string text = content.Text;
                        List<uint> collection = new List<uint>(content.EmotionDictionary.Keys);
                        List<uint> list2 = new List<uint>();
                        list2.AddRange(collection);
                        foreach (uint num2 in content.ForeignImageDictionary.Keys)
                        {
                            list2.Add(num2);
                        }
                        list2.Sort();
                        for (num3 = list2.Count - 1; num3 >= 0; num3--)
                        {
                            text = text.Remove(list2[num3], 1);
                        }
                        base.AppendText(text);
                        for (num3 = 0; num3 < list2.Count; num3++)
                        {
                            uint item = list2[num3];
                            if (collection.Contains(item))
                            {
                                this.InsertDefaultEmotion(content.EmotionDictionary[item], start + ((int) item));
                            }
                            else
                            {
                                this.InsertImage(content.ForeignImageDictionary[item], start + ((int) item));
                            }
                        }
                    }
                    else
                    {
                        base.AppendText(content.Text);
                    }
                    base.Select(start, content.Text.Length);
                    Color color = content.Color;
                    base.SelectionColor = content.Color;
                    if (content.Font != null)
                    {
                        base.SelectionFont = content.Font;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void AppendRichText(string textContent, Font font, Color color, int? StartIndex = new int?())
        {
            try
            {
                int start = !StartIndex.HasValue ? this.Text.Length : StartIndex.Value;
                base.AppendText(textContent);
                base.Select(start, textContent.Length);
                base.SelectionColor = color;
                if (font != null)
                {
                    base.SelectionFont = font;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void AppendRtf(string _rtf)
        {
            try
            {
                base.Select(this.TextLength, 0);
                base.SelectedRtf = _rtf;
                base.Update();
                base.Select(base.Rtf.Length, 0);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void Clear()
        {
            try
            {
                List<REOBJECT> list = this.method_4().method_8();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].dwUser == 0x2710)
                    {
                        ((GifBox) Marshal.GetObjectForIUnknown(list[i].poleobj)).Dispose();
                    }
                }
                base.Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void GClass4_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.bool_0)
                {
                    MouseEventArgs args = e as MouseEventArgs;
                    if (args != null)
                    {
                        Control control = this.OitderlpTF(args.Location, true);
                        if (control is GifBox)
                        {
                            GifBox box = (control == null) ? null : ((GifBox) control);
                            if (box == null)
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void GClass4_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] data = (string[]) e.Data.GetData(DataFormats.FileDrop);
                if (((data != null) && (data.Length != 0)) && (this.cbGeneric_0 != null))
                {
                    this.cbGeneric_0(data);
                }
            }
        }

        private void GClass4_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void GClass4_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && (e.KeyCode == Keys.V)) && Clipboard.ContainsImage())
            {
                Image image = Clipboard.GetImage();
                if (image != null)
                {
                    this.InsertImage(image);
                }
                e.Handled = true;
            }
        }

        private void GClass4_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (e.LinkText.StartsWith("www.") || e.LinkText.StartsWith("http"))
            {
                Process.Start(e.LinkText);
            }
        }

        private void GClass4_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = this.OitderlpTF(e.Location, true);
            if (control != null)
            {
                Point selectControlPoint = this.SelectControlPoint;
                int x = e.Location.X - selectControlPoint.X;
                int y = e.Location.Y - selectControlPoint.Y;
                Point newP = new Point(x, y);
                if (control is RichTxtControl)
                {
                    ((RichTxtControl) control).CtrlMouseDown(this, newP, e);
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                if (this.chatBoxContextMenuMode_0 == ChatBoxContextMenuMode.None)
                {
                    this.ContextMenuStrip = null;
                }
                else if (this.SelectControl is GifBox)
                {
                    GifBox box = (this.SelectControl == null) ? null : ((GifBox) this.SelectControl);
                    if (this.chatBoxContextMenuMode_0 == ChatBoxContextMenuMode.ForInput)
                    {
                        if (box == null)
                        {
                            this.image_0 = null;
                        }
                        else if (string.IsNullOrEmpty(this.SelectedText.Trim()))
                        {
                            this.image_0 = box.Image;
                        }
                        else
                        {
                            this.image_0 = null;
                        }
                        this.toolStripMenuItem9.Visible = !string.IsNullOrEmpty(this.SelectedText);
                        this.toolStripMenuItem1.Visible = !base.ReadOnly;
                        this.ContextMenuStrip = this.contextMenuStrip1;
                    }
                    else if (this.chatBoxContextMenuMode_0 == ChatBoxContextMenuMode.ForOutput)
                    {
                        if (box == null)
                        {
                            if (!string.IsNullOrEmpty(this.SelectedText))
                            {
                                this.image_0 = null;
                                this.ContextMenuStrip = this.asOdsXsfqG;
                            }
                            else
                            {
                                this.image_0 = null;
                                this.ContextMenuStrip = this.contextMenuStrip3;
                            }
                        }
                        else
                        {
                            this.image_0 = box.Image;
                            this.ContextMenuStrip = this.contextMenuStrip2;
                        }
                    }
                }
            }
        }

        private void GClass4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.None)
            {
                Control control = this.OitderlpTF(e.Location, false);
                if (control != null)
                {
                    Point selectControlPoint = this.SelectControlPoint;
                    int x = e.Location.X - selectControlPoint.X;
                    int y = e.Location.Y - selectControlPoint.Y;
                    Point newP = new Point(x, y);
                    if (control is RichTxtControl)
                    {
                        ((RichTxtControl) control).CtrlMouseMove(this, newP, e);
                    }
                }
            }
        }

        private void GClass4_SizeChanged(object sender, EventArgs e)
        {
            if (this.method_4() != null)
            {
                List<REOBJECT> list = this.method_4().method_8();
                for (int i = 0; i < list.Count; i++)
                {
                    GifBox objectForIUnknown = (GifBox) Marshal.GetObjectForIUnknown(list[i].poleobj);
                    objectForIUnknown.Size = this.method_6(objectForIUnknown.Image.Size);
                }
            }
        }

        public ChatBoxContent GetContent()
        {
            ChatBoxContent content = new ChatBoxContent(this.Text, this.Font, this.ForeColor);
            List<REOBJECT> list = this.method_4().method_8();
            for (int i = 0; i < list.Count; i++)
            {
                uint posistion = (uint) list[i].posistion;
                content.PicturePositions.Add(posistion);
                if (list[i].dwUser != 0x2710)
                {
                    content.AddEmotion(posistion, list[i].dwUser);
                }
                else
                {
                    GifBox objectForIUnknown = (GifBox) Marshal.GetObjectForIUnknown(list[i].poleobj);
                    content.AddForeignImage(posistion, objectForIUnknown.Image);
                }
            }
            return content;
        }

        public int GetSelectionLink()
        {
            return this.method_2(0x20, 0x20);
        }

        public void Initialize(Dictionary<uint, Image> defaultEmotions)
        {
            this.dictionary_0 = defaultEmotions ?? new Dictionary<uint, Image>();
        }

        public void InsertControl(Control _oCtrl)
        {
            this.method_4().method_1(_oCtrl);
        }

        public void InsertControl(Control _oCtrl, int _nPostion, uint dwUser)
        {
            this.method_4().method_2(_oCtrl, _nPostion, dwUser);
        }

        public void InsertDefaultEmotion(uint emotionID)
        {
            this.InsertDefaultEmotion(emotionID, this.TextLength);
        }

        public void InsertDefaultEmotion(uint emotionID, int position)
        {
            try
            {
                Image image = this.dictionary_0[emotionID];
                GifBox box = new GifBox {
                    Cursor = Cursors.Hand,
                    BackColor = base.BackColor,
                    Size = this.method_6(image.Size),
                    Image = image
                };
                this.method_4().method_2(box, position, emotionID);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public GifBox InsertImage(Image image)
        {
            return this.InsertImage(image, this.TextLength);
        }

        public GifBox InsertImage(Image image, int position)
        {
            GifBox box = new GifBox();
            try
            {
                box.Cursor = Cursors.Hand;
                box.BackColor = base.BackColor;
                box.Size = this.method_6(image.Size);
                box.Image = image;
                box.MouseDown += new MouseEventHandler(this.method_5);
                box.Tag = position;
                this.method_4().method_2(box, position, 0x2710);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return box;
        }

        public void InsertLink(string text)
        {
            this.InsertLink(text, base.SelectionStart);
        }

        public void InsertLink(string text, int position)
        {
            if ((position < 0) || (position > this.Text.Length))
            {
                throw new ArgumentOutOfRangeException("position");
            }
            base.SelectionStart = position;
            this.SelectedText = text;
            base.Select(position, text.Length);
            this.SetSelectionLink(true);
            base.Select(position + text.Length, 0);
        }

        public void InsertLink(string text, string hyperlink)
        {
            this.InsertLink(text, hyperlink, base.SelectionStart);
        }

        public void InsertLink(string text, string hyperlink, int position)
        {
            if ((position < 0) || (position > this.Text.Length))
            {
                throw new ArgumentOutOfRangeException("position");
            }
            base.SelectionStart = position;
            base.SelectedRtf = @"{\rtf1\ansi " + this.method_0(text + @"\v #" + hyperlink, this.Font) + @"\v0}";
            base.Select(position, (text.Length + hyperlink.Length) + 1);
            this.SetSelectionLink(true);
            base.Select(((position + text.Length) + hyperlink.Length) + 1, 0);
        }

        private string method_0(string string_0, Font font_0)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"\viewkind4\uc1\pard\cf1\f0\fs20");
            builder.Append(@"\highlight2");
            if (font_0.Bold)
            {
                builder.Append(@"\b");
            }
            if (font_0.Italic)
            {
                builder.Append(@"\i");
            }
            if (font_0.Strikeout)
            {
                builder.Append(@"\strike");
            }
            if (font_0.Underline)
            {
                builder.Append(@"\ul");
            }
            builder.Append(@"\f0");
            builder.Append(@"\fs");
            builder.Append((int) Math.Round((double) (2f * font_0.SizeInPoints)));
            builder.Append(" ");
            builder.Append(string_0.Replace("\n", @"\par "));
            builder.Append(@"\highlight0");
            if (font_0.Bold)
            {
                builder.Append(@"\b0");
            }
            if (font_0.Italic)
            {
                builder.Append(@"\i0");
            }
            if (font_0.Strikeout)
            {
                builder.Append(@"\strike0");
            }
            if (font_0.Underline)
            {
                builder.Append(@"\ulnone");
            }
            builder.Append(@"\f0");
            builder.Append(@"\fs20");
            builder.Append(@"\cf0\fs17}");
            return builder.ToString();
        }

        private void method_1(uint uint_0, uint uint_1)
        {
            Struct9 struct2;
            struct2 = new Struct9 {
                uint_0 = (uint) Marshal.SizeOf(struct2),
                uint_1 = uint_0,
                uint_2 = uint_1
            };
            IntPtr ptr = new IntPtr(1);
            IntPtr ptr2 = Marshal.AllocCoTaskMem(Marshal.SizeOf(struct2));
            Marshal.StructureToPtr(struct2, ptr2, false);
            SendMessage(base.Handle, 0x444, ptr, ptr2);
            Marshal.FreeCoTaskMem(ptr2);
        }

        private int method_2(uint uint_0, uint uint_1)
        {
            Struct9 struct2;
            int num;
            struct2 = new Struct9 {
                uint_0 = (uint) Marshal.SizeOf(struct2),
                BwLhOdMyq6 = new char[0x20]
            };
            IntPtr ptr = new IntPtr(1);
            IntPtr ptr2 = Marshal.AllocCoTaskMem(Marshal.SizeOf(struct2));
            Marshal.StructureToPtr(struct2, ptr2, false);
            SendMessage(base.Handle, 0x43a, ptr, ptr2);
            struct2 = (Struct9) Marshal.PtrToStructure(ptr2, typeof(Struct9));
            if ((struct2.uint_1 & uint_0) == uint_0)
            {
                if ((struct2.uint_2 & uint_1) == uint_1)
                {
                    num = 1;
                }
                else
                {
                    num = 0;
                }
            }
            else
            {
                num = -1;
            }
            Marshal.FreeCoTaskMem(ptr2);
            return num;
        }

        private string method_3(string string_0, string string_1, string string_2)
        {
            string extension = Path.GetExtension(string_1);
            SaveFileDialog dialog = new SaveFileDialog {
                Filter = string.Format("The Files (*{0})|*{0}", extension),
                FileName = string_1,
                InitialDirectory = string_2,
                OverwritePrompt = false
            };
            if (string_0 != null)
            {
                dialog.Title = string_0;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return null;
        }

        private Class54 method_4()
        {
            if ((this.class54_0 == null) && base.IsHandleCreated)
            {
                this.class54_0 = new Class54(this);
            }
            return this.class54_0;
        }

        private void method_5(object sender, MouseEventArgs e)
        {
            if ((e.Clicks == 2) && (e.Button == MouseButtons.Left))
            {
                GifBox box = (GifBox) sender;
                int index = 0;
                List<Image> imageList = new List<Image>();
                foreach (KeyValuePair<uint, Image> pair in this.GetContent().ForeignImageDictionary)
                {
                    if (uint.Parse(box.Tag.ToString()) == pair.Key)
                    {
                        index = imageList.Count;
                    }
                    imageList.Add(pair.Value);
                }
                if (this.PopoutImageWhenDoubleClick)
                {
                    new PictureBrowseForm(imageList, index).Show(this);
                }
            }
        }

        private Size method_6(Size size_0)
        {
            int width = base.Width - 20;
            if (size_0.Width <= width)
            {
                return size_0;
            }
            return new Size(width, (width * size_0.Height) / size_0.Width);
        }

        private void method_7()
        {
            this.icontainer_0 = new Container();
            this.contextMenuStrip1 = new ContextMenuStrip(this.icontainer_0);
            this.toolStripMenuItem2 = new ToolStripMenuItem();
            this.toolStripMenuItem1 = new ToolStripMenuItem();
            this.contextMenuStrip2 = new ContextMenuStrip(this.icontainer_0);
            this.toolStripMenuItem3 = new ToolStripMenuItem();
            this.toolStripMenuItem4 = new ToolStripMenuItem();
            this.toolStripMenuItem5 = new ToolStripMenuItem();
            this.toolStripMenuItem6 = new ToolStripMenuItem();
            this.contextMenuStrip3 = new ContextMenuStrip(this.icontainer_0);
            this.toolStripMenuItem7 = new ToolStripMenuItem();
            this.asOdsXsfqG = new ContextMenuStrip(this.icontainer_0);
            this.toolStripMenuItem8 = new ToolStripMenuItem();
            this.toolStripMenuItem9 = new ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.asOdsXsfqG.SuspendLayout();
            base.SuspendLayout();
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] { this.toolStripMenuItem9, this.toolStripMenuItem2, this.toolStripMenuItem1 });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(0x7d, 0x30);
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new Size(0x7c, 0x16);
            this.toolStripMenuItem2.Text = "粘贴";
            this.toolStripMenuItem2.Click += new EventHandler(this.toolStripMenuItem2_Click);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new Size(0x7c, 0x16);
            this.toolStripMenuItem1.Text = "插入图片";
            this.toolStripMenuItem1.Click += new EventHandler(this.toolStripMenuItem1_Click);
            this.contextMenuStrip2.Items.AddRange(new ToolStripItem[] { this.toolStripMenuItem3, this.toolStripMenuItem4, this.toolStripMenuItem5, this.toolStripMenuItem6 });
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new Size(0x89, 0x5c);
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new Size(0x88, 0x16);
            this.toolStripMenuItem3.Text = "复制";
            this.toolStripMenuItem3.Click += new EventHandler(this.toolStripMenuItem3_Click);
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new Size(0x88, 0x16);
            this.toolStripMenuItem4.Text = "另存为";
            this.toolStripMenuItem4.Click += new EventHandler(this.toolStripMenuItem4_Click);
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new Size(0x88, 0x16);
            this.toolStripMenuItem5.Text = "新窗口显示";
            this.toolStripMenuItem5.Click += new EventHandler(this.toolStripMenuItem5_Click);
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new Size(0x88, 0x16);
            this.toolStripMenuItem6.Text = "清屏";
            this.toolStripMenuItem6.Click += new EventHandler(this.toolStripMenuItem6_Click);
            this.contextMenuStrip3.Items.AddRange(new ToolStripItem[] { this.toolStripMenuItem7 });
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new Size(0x65, 0x1a);
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new Size(100, 0x16);
            this.toolStripMenuItem7.Text = "清屏";
            this.toolStripMenuItem7.Click += new EventHandler(this.toolStripMenuItem7_Click);
            this.asOdsXsfqG.Items.AddRange(new ToolStripItem[] { this.toolStripMenuItem8 });
            this.asOdsXsfqG.Name = "contextMenuStrip4";
            this.asOdsXsfqG.Size = new Size(0x65, 0x1a);
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new Size(100, 0x16);
            this.toolStripMenuItem8.Text = "复制";
            this.toolStripMenuItem8.Click += new EventHandler(this.toolStripMenuItem8_Click);
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new Size(0x7c, 0x16);
            this.toolStripMenuItem9.Text = "复制";
            this.toolStripMenuItem9.Click += new EventHandler(this.toolStripMenuItem9_Click);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.asOdsXsfqG.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private string method_8(string string_0, string string_1, params string[] extendNames)
        {
            int num;
            StringBuilder builder = new StringBuilder("(");
            for (num = 0; num < extendNames.Length; num++)
            {
                builder.Append("*");
                builder.Append(extendNames[num]);
                if (num < (extendNames.Length - 1))
                {
                    builder.Append(";");
                }
                else
                {
                    builder.Append(")");
                }
            }
            builder.Append("|");
            for (num = 0; num < extendNames.Length; num++)
            {
                builder.Append("*");
                builder.Append(extendNames[num]);
                if (num < (extendNames.Length - 1))
                {
                    builder.Append(";");
                }
            }
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = builder.ToString(),
                FileName = "",
                InitialDirectory = string_1
            };
            if (string_0 != null)
            {
                dialog.Title = string_0;
            }
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return null;
        }

        private Control OitderlpTF(Point point_1, bool bool_1)
        {
            int charIndexFromPosition = this.GetCharIndexFromPosition(point_1);
            Point positionFromCharIndex = this.GetPositionFromCharIndex(charIndexFromPosition);
            Control control = null;
            bool flag = false;
            List<REOBJECT> list = this.method_4().method_8();
            for (int i = 0; i < list.Count; i++)
            {
                if ((list[i].posistion == charIndexFromPosition) || ((list[i].posistion + 1) == charIndexFromPosition))
                {
                    this.SelectControl = control = (Control) Marshal.GetObjectForIUnknown(list[i].poleobj);
                    if ((list[i].posistion + 1) == charIndexFromPosition)
                    {
                        positionFromCharIndex = new Point(positionFromCharIndex.X - control.Width, positionFromCharIndex.Y);
                        flag = true;
                    }
                    this.SelectControlIndex = flag ? (charIndexFromPosition - 1) : charIndexFromPosition;
                    this.SelectControlPoint = positionFromCharIndex;
                    break;
                }
            }
            if (control == null)
            {
                return null;
            }
            Rectangle rectangle = new Rectangle(positionFromCharIndex.X, positionFromCharIndex.Y, control.Width, control.Height);
            if (!rectangle.Contains(point_1))
            {
                return null;
            }
            if (bool_1)
            {
                base.Select(flag ? (charIndexFromPosition - 1) : charIndexFromPosition, 1);
            }
            return control;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
        }

        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr intptr_0, int int_1, IntPtr intptr_1, IntPtr intptr_2);
        public void SetSelectionLink(bool link)
        {
            this.method_1(0x20, link ? 0x20 : 0);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = this.method_8("请选择图片", null, new string[] { ".jpg", ".bmp", ".png", ".gif" });
                if (filename != null)
                {
                    Image image = Image.FromFile(filename);
                    this.InsertImage(image);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsImage())
                {
                    Image image = Clipboard.GetImage();
                    if (image != null)
                    {
                        this.InsertImage(image);
                    }
                }
                else
                {
                    base.Paste();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetImage(this.image_0);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag;
                string path = this.method_3("请选择保存路径", "image." + ((flag = ImageHelper.IsGif(this.image_0)) ? "gif" : "jpg"), null);
                if (path != null)
                {
                    ImageFormat format = flag ? ImageFormat.Gif : ImageFormat.Jpeg;
                    ImageHelper.Save(this.image_0, path, format);
                    MessageBox.Show("成功保存图片。");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                new ImageForm(this.image_0).Show();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.SelectedText);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.SelectedText);
        }

        [Description("快捷菜单的模式。")]
        public ChatBoxContextMenuMode ContextMenuMode
        {
            get
            {
                return this.chatBoxContextMenuMode_0;
            }
            set
            {
                this.chatBoxContextMenuMode_0 = value;
            }
        }

        public List<Control> ListControl
        {
            get
            {
                this.list_0.Clear();
                List<REOBJECT> list = this.method_4().method_8();
                for (int i = 0; i < list.Count; i++)
                {
                    Control objectForIUnknown = (Control) Marshal.GetObjectForIUnknown(list[i].poleobj);
                    this.list_0.Add(objectForIUnknown);
                }
                return this.list_0;
            }
        }

        [Description("双击图片时，是否弹出图片")]
        public bool PopoutImageWhenDoubleClick
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

        public Control SelectControl
        {
            [CompilerGenerated]
            get
            {
                return this.control_0;
            }
            [CompilerGenerated]
            set
            {
                this.control_0 = value;
            }
        }

        public int SelectControlIndex
        {
            [CompilerGenerated]
            get
            {
                return this.int_0;
            }
            [CompilerGenerated]
            set
            {
                this.int_0 = value;
            }
        }

        public Point SelectControlPoint
        {
            [CompilerGenerated]
            get
            {
                return this.point_0;
            }
            [CompilerGenerated]
            set
            {
                this.point_0 = value;
            }
        }

        public delegate void CbGeneric<T>(T obj);

        [StructLayout(LayoutKind.Sequential)]
        private struct Struct9
        {
            public uint uint_0;
            public uint uint_1;
            public uint uint_2;
            public int int_0;
            public int int_1;
            public int int_2;
            public byte byte_0;
            public byte byte_1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x20)]
            public char[] BwLhOdMyq6;
            public ushort ushort_0;
            public ushort ushort_1;
            public int int_3;
            public int int_4;
            public int int_5;
            public short short_0;
            public short short_1;
            public byte byte_2;
            public byte byte_3;
            public byte byte_4;
            public byte byte_5;
        }
    }
}

