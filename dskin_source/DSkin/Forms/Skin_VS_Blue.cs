namespace DSkin.Forms
{
    using DSkin;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    public class Skin_VS_Blue : DSkinForm
    {
        private IContainer icontainer_1 = null;

        public Skin_VS_Blue()
        {
            this.InitializeComponent_1();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.icontainer_1 != null))
            {
                this.icontainer_1.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent_1()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(0xd6, 0xdb, 0xe9);
            base.BorderColor = Color.FromArgb(13, 0x20, 0x2c);
            base.CaptionFont = new Font("微软雅黑", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.CaptionOffset = new Point(5, 0);
            base.CaptionShowMode = TextShowModes.Ordinary;
            base.CaptionTextRender = TextRenderingHint.AntiAliasGridFit;
            base.ClientSize = new Size(300, 300);
            base.CloseBox.BorderHoverColor = Color.FromArgb(0xff, 0xc0, 0x80);
            base.CloseBox.BorderPressColor = Color.FromArgb(0xff, 0xc0, 0x80);
            base.CloseBox.HoverBackColor = Color.FromArgb(0xff, 0xfc, 0xf4);
            base.CloseBox.PressBackColor = Color.FromArgb(0xff, 0xe8, 0xa6);
            base.CloseBox.ToolTip = "关闭";
            base.MaxBox.BorderHoverColor = Color.FromArgb(0xff, 0xc0, 0x80);
            base.MaxBox.BorderPressColor = Color.FromArgb(0xff, 0xc0, 0x80);
            base.MaxBox.HoverBackColor = Color.FromArgb(0xff, 0xfc, 0xf4);
            base.MaxBox.PressBackColor = Color.FromArgb(0xff, 0xe8, 0xa6);
            base.MinBox.BorderHoverColor = Color.FromArgb(0xff, 0xc0, 0x80);
            base.MinBox.BorderPressColor = Color.FromArgb(0xff, 0xc0, 0x80);
            base.MinBox.HoverBackColor = Color.FromArgb(0xff, 0xfc, 0xf4);
            base.MinBox.PressBackColor = Color.FromArgb(0xff, 0xe8, 0xa6);
            base.MinBox.ToolTip = "最小化";
            base.Name = "Skin_VS_Blue";
            base.NormalBox.BorderHoverColor = Color.FromArgb(0xff, 0xc0, 0x80);
            base.NormalBox.BorderPressColor = Color.FromArgb(0xff, 0xc0, 0x80);
            base.NormalBox.HoverBackColor = Color.FromArgb(0xff, 0xfc, 0xf4);
            base.ShowShadow = true;
            base.ShowSystemMenu = true;
            this.Text = "Skin_VS_Blue";
            base.ResumeLayout(false);
        }
    }
}

