namespace DSkin.Forms
{
    using DSkin;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    public class Skin_VS_Dark : DSkinForm
    {
        private IContainer icontainer_1 = null;

        public Skin_VS_Dark()
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
            this.BackColor = Color.FromArgb(0x2d, 0x2d, 0x30);
            base.BorderColor = Color.FromArgb(0, 0x7a, 0xcb);
            base.CaptionColor = Color.FromArgb(0xad, 0xad, 0xad);
            base.CaptionFont = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            base.CaptionShowMode = TextShowModes.Ordinary;
            base.CaptionTextRender = TextRenderingHint.AntiAliasGridFit;
            base.ClientSize = new Size(0x11c, 0x106);
            base.CloseBox.BorderHoverColor = Color.Empty;
            base.CloseBox.BorderNormalColor = Color.Empty;
            base.CloseBox.BorderPressColor = Color.Empty;
            base.CloseBox.BorderWidth = 1;
            base.CloseBox.NormalColor = Color.White;
            base.CloseBox.HoverBackColor = Color.FromArgb(40, 200, 200, 200);
            base.CloseBox.HoverImage = null;
            base.CloseBox.Name = "";
            base.CloseBox.NormalBackColor = Color.Transparent;
            base.CloseBox.NormalImage = null;
            base.CloseBox.PressBackColor = Color.FromArgb(0, 0x7a, 0xcc);
            base.CloseBox.PressImage = null;
            base.CloseBox.Size = new Size(30, 30);
            base.CloseBox.ToolTip = null;
            base.CloseBox.Visible = true;
            base.MaxBox.BorderHoverColor = Color.Empty;
            base.MaxBox.BorderNormalColor = Color.Empty;
            base.MaxBox.BorderPressColor = Color.Empty;
            base.MaxBox.BorderWidth = 1;
            base.MaxBox.NormalColor = Color.White;
            base.MaxBox.HoverBackColor = Color.FromArgb(40, 200, 200, 200);
            base.MaxBox.HoverImage = null;
            base.MaxBox.Name = "";
            base.MaxBox.NormalBackColor = Color.Transparent;
            base.MaxBox.NormalImage = null;
            base.MaxBox.PressBackColor = Color.FromArgb(0, 0x7a, 0xcc);
            base.MaxBox.PressImage = null;
            base.MaxBox.Size = new Size(30, 30);
            base.MaxBox.ToolTip = null;
            base.MaxBox.Visible = true;
            base.MinBox.BorderHoverColor = Color.Empty;
            base.MinBox.BorderNormalColor = Color.Empty;
            base.MinBox.BorderPressColor = Color.Empty;
            base.MinBox.BorderWidth = 1;
            base.MinBox.NormalColor = Color.White;
            base.MinBox.HoverBackColor = Color.FromArgb(40, 200, 200, 200);
            base.MinBox.HoverImage = null;
            base.MinBox.Name = "";
            base.MinBox.NormalBackColor = Color.Transparent;
            base.MinBox.NormalImage = null;
            base.MinBox.PressBackColor = Color.FromArgb(0, 0x7a, 0xcc);
            base.MinBox.PressImage = null;
            base.MinBox.Size = new Size(30, 30);
            base.MinBox.ToolTip = null;
            base.MinBox.Visible = true;
            base.Name = "Skin_VS_Dark";
            base.NormalBox.BorderHoverColor = Color.Empty;
            base.NormalBox.BorderNormalColor = Color.Empty;
            base.NormalBox.BorderPressColor = Color.Empty;
            base.NormalBox.BorderWidth = 1;
            base.NormalBox.NormalColor = Color.White;
            base.NormalBox.HoverBackColor = Color.FromArgb(40, 200, 200, 200);
            base.NormalBox.HoverImage = null;
            base.NormalBox.Name = "";
            base.NormalBox.NormalBackColor = Color.Transparent;
            base.NormalBox.NormalImage = null;
            base.NormalBox.PressBackColor = Color.FromArgb(0, 0x7a, 0xcc);
            base.NormalBox.PressImage = null;
            base.NormalBox.Size = new Size(30, 30);
            base.NormalBox.ToolTip = null;
            base.NormalBox.Visible = false;
            base.ShadowColor = Color.FromArgb(0, 0x7a, 0xcb);
            base.ShowShadow = true;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Skin_VS_Dark";
            base.ResumeLayout(false);
        }
    }
}

