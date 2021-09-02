using DSkin.Controls;
using DSkin.Forms;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

internal class Form0 : DSkinForm
{
    private DSkinButton[] dskinButton_0;
    public DSkinLabel dSkinLabel1;
    private DSkinPictureBox dSkinPictureBox1;
    private IDisposable idisposable_0 = null;
    private MessageBoxIcon messageBoxIcon_0 = MessageBoxIcon.None;

    public Form0()
    {
        this.InitializeComponent_1();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.idisposable_0 != null))
        {
            this.idisposable_0.Dispose();
        }
        base.Dispose(disposing);
    }

    private void Form0_Load(object sender, EventArgs e)
    {
        if (base.Owner != null)
        {
            base.TopMost = base.Owner.TopMost;
        }
    }

    private void InitializeComponent_1()
    {
        this.dSkinLabel1 = new DSkinLabel();
        this.dSkinPictureBox1 = new DSkinPictureBox();
        base.SuspendLayout();
        this.dSkinLabel1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
        this.dSkinLabel1.AutoSize = false;
        this.dSkinLabel1.BackgroundImageLayout = ImageLayout.None;
        this.dSkinLabel1.Borders.AllWidth = 1;
        this.dSkinLabel1.Location = new Point(10, 0x25);
        this.dSkinLabel1.Name = "dSkinLabel1";
        this.dSkinLabel1.Size = new Size(0xdf, 0x33);
        this.dSkinLabel1.TabIndex = 0;
        this.dSkinLabel1.Text = "dSkinLabel1";
        this.dSkinLabel1.TextAlign = ContentAlignment.TopCenter;
        this.dSkinPictureBox1.BackgroundImageLayout = ImageLayout.None;
        this.dSkinPictureBox1.Borders.AllWidth = 1;
        this.dSkinPictureBox1.Image = null;
        this.dSkinPictureBox1.Images = null;
        this.dSkinPictureBox1.Interval = 100;
        this.dSkinPictureBox1.Location = new Point(15, 40);
        this.dSkinPictureBox1.Name = "dSkinPictureBox1";
        this.dSkinPictureBox1.Size = new Size(0x30, 0x30);
        this.dSkinPictureBox1.TabIndex = 1;
        this.dSkinPictureBox1.Text = "dSkinPictureBox1";
        base.AutoScaleDimensions = new SizeF(6f, 12f);
        base.AutoScaleMode = AutoScaleMode.Font;
        base.CanResize = false;
        base.ClientSize = new Size(240, 0x87);
        base.Controls.Add(this.dSkinPictureBox1);
        base.Controls.Add(this.dSkinLabel1);
        base.DoubleClickMaximized = false;
        base.DragChangeBackImage = false;
        base.FormBorderStyle = FormBorderStyle.None;
        base.InheritTheme = true;
        base.KeyPreview = true;
        base.MaximizeBox = false;
        base.MinimizeBox = false;
        base.Name = "DSkinMessageBoxForm";
        base.ShowInTaskbar = false;
        base.ShowShadow = true;
        this.Text = "";
        base.Load += new EventHandler(this.Form0_Load);
        base.ResumeLayout(false);
    }

    public string method_24()
    {
        return this.dSkinLabel1.Text;
    }

    public void method_25(string string_0)
    {
        this.dSkinLabel1.Text = string_0;
    }

    public string method_26()
    {
        return this.Text;
    }

    public void method_27(string string_0)
    {
        this.Text = string_0;
    }

    public DSkinButton[] method_28()
    {
        return this.dskinButton_0;
    }

    public void method_29(DSkinButton[] dskinButton_1)
    {
        if (this.dskinButton_0 != dskinButton_1)
        {
            this.dskinButton_0 = dskinButton_1;
            if (this.dskinButton_0 != null)
            {
                int num2 = base.Width / (this.dskinButton_0.Length + 1);
                for (int i = 0; i < this.dskinButton_0.Length; i++)
                {
                    DSkinButton button = this.dskinButton_0[i];
                    button.Location = new Point((num2 * (i + 1)) - (button.Width / 2), base.Height - 0x2d);
                    base.Controls.Add(button);
                    button.BringToFront();
                }
            }
        }
    }

    public MessageBoxIcon method_30()
    {
        return this.messageBoxIcon_0;
    }

    public void method_31(MessageBoxIcon messageBoxIcon_1)
    {
        Icon error = null;
        switch (messageBoxIcon_1)
        {
            case MessageBoxIcon.None:
                error = null;
                break;

            case MessageBoxIcon.Hand:
                error = SystemIcons.Error;
                SystemSounds.Hand.Play();
                break;

            case MessageBoxIcon.Question:
                error = SystemIcons.Question;
                SystemSounds.Question.Play();
                break;

            case MessageBoxIcon.Exclamation:
                error = SystemIcons.Exclamation;
                SystemSounds.Exclamation.Play();
                break;

            case MessageBoxIcon.Asterisk:
                error = SystemIcons.Asterisk;
                SystemSounds.Asterisk.Play();
                break;
        }
        if (error != null)
        {
            this.dSkinPictureBox1.Image = error.ToBitmap();
            this.dSkinLabel1.Left = 0x3a;
            base.Width += 0x3a;
            this.dSkinLabel1.Width = 220;
        }
        this.messageBoxIcon_0 = messageBoxIcon_1;
    }

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        if (e.KeyChar == '\x0003')
        {
            e.Handled = true;
            Clipboard.SetDataObject(this.method_26() + Environment.NewLine + Environment.NewLine + this.method_24(), true);
        }
        base.OnKeyPress(e);
    }

    protected override void OnThemeChanged(EventArgs e)
    {
        base.OnThemeChanged(e);
    }
}

