namespace DSkin.Forms
{
    using DSkin.Common;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class Skin_Mac : DSkinForm
    {
        private IContainer icontainer_1 = null;

        public Skin_Mac()
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Skin_Mac));
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.BorderColor = Color.Gray;
            base.CaptionBackColors = new Color[] { Color.FromArgb(0xe3, 0xe3, 0xe3), Color.FromArgb(0xce, 0xce, 0xce) };
            base.CaptionCenter = true;
            base.CaptionOffset = new Point(0, 3);
            base.ClientSize = new Size(0x11c, 0x106);
            base.CloseBox.BorderHoverColor = Color.Empty;
            base.CloseBox.BorderNormalColor = Color.Empty;
            base.CloseBox.BorderPressColor = Color.Empty;
            base.CloseBox.BorderWidth = 1;
            base.CloseBox.HoverBackColor = Color.FromArgb(100, 200, 200, 200);
            base.CloseBox.HoverColor = Color.Empty;
            base.CloseBox.HoverImage = (Image) manager.GetObject("Skin_Mac.CloseBox.HoverImage");
            base.CloseBox.Name = "";
            base.CloseBox.NormalBackColor = Color.Transparent;
            base.CloseBox.NormalColor = Color.Black;
            base.CloseBox.NormalImage = (Image) manager.GetObject("Skin_Mac.CloseBox.NormalImage");
            base.CloseBox.PressBackColor = Color.FromArgb(250, 200, 0, 0);
            base.CloseBox.PressColor = Color.Empty;
            base.CloseBox.PressImage = (Image) manager.GetObject("Skin_Mac.CloseBox.PressImage");
            base.CloseBox.Size = new Size(0x13, 0x11);
            base.CloseBox.ToolTip = null;
            base.CloseBox.Visible = true;
            base.IconRectangle = new Rectangle(8, 8, 0x10, 0x10);
            base.MaxBox.BorderHoverColor = Color.Empty;
            base.MaxBox.BorderNormalColor = Color.Empty;
            base.MaxBox.BorderPressColor = Color.Empty;
            base.MaxBox.BorderWidth = 1;
            base.MaxBox.HoverBackColor = Color.FromArgb(100, 200, 200, 200);
            base.MaxBox.HoverColor = Color.Empty;
            base.MaxBox.HoverImage = (Image) manager.GetObject("Skin_Mac.MaxBox.HoverImage");
            base.MaxBox.Name = "";
            base.MaxBox.NormalBackColor = Color.Transparent;
            base.MaxBox.NormalColor = Color.Black;
            base.MaxBox.NormalImage = (Image) manager.GetObject("Skin_Mac.MaxBox.NormalImage");
            base.MaxBox.PressBackColor = Color.FromArgb(250, 200, 0, 0);
            base.MaxBox.PressColor = Color.Empty;
            base.MaxBox.PressImage = (Image) manager.GetObject("Skin_Mac.MaxBox.PressImage");
            base.MaxBox.Size = new Size(0x13, 0x11);
            base.MaxBox.ToolTip = null;
            base.MaxBox.Visible = true;
            base.MinBox.BorderHoverColor = Color.Empty;
            base.MinBox.BorderNormalColor = Color.Empty;
            base.MinBox.BorderPressColor = Color.Empty;
            base.MinBox.BorderWidth = 1;
            base.MinBox.HoverBackColor = Color.FromArgb(100, 200, 200, 200);
            base.MinBox.HoverColor = Color.Empty;
            base.MinBox.HoverImage = (Image) manager.GetObject("Skin_Mac.MinBox.HoverImage");
            base.MinBox.Name = "";
            base.MinBox.NormalBackColor = Color.Transparent;
            base.MinBox.NormalColor = Color.Black;
            base.MinBox.NormalImage = (Image) manager.GetObject("Skin_Mac.MinBox.NormalImage");
            base.MinBox.PressBackColor = Color.FromArgb(250, 200, 0, 0);
            base.MinBox.PressColor = Color.Empty;
            base.MinBox.PressImage = (Image) manager.GetObject("Skin_Mac.MinBox.PressImage");
            base.MinBox.Size = new Size(0x13, 0x11);
            base.MinBox.ToolTip = null;
            base.MinBox.Visible = true;
            base.Name = "Skin_Mac";
            base.NormalBox.BorderHoverColor = Color.Empty;
            base.NormalBox.BorderNormalColor = Color.Empty;
            base.NormalBox.BorderPressColor = Color.Empty;
            base.NormalBox.BorderWidth = 1;
            base.NormalBox.HoverBackColor = Color.FromArgb(100, 200, 200, 200);
            base.NormalBox.HoverColor = Color.Empty;
            base.NormalBox.HoverImage = (Image) manager.GetObject("Skin_Mac.NormalBox.HoverImage");
            base.NormalBox.Name = "";
            base.NormalBox.NormalBackColor = Color.Transparent;
            base.NormalBox.NormalColor = Color.Black;
            base.NormalBox.NormalImage = (Image) manager.GetObject("Skin_Mac.NormalBox.NormalImage");
            base.NormalBox.PressBackColor = Color.FromArgb(250, 200, 0, 0);
            base.NormalBox.PressColor = Color.Empty;
            base.NormalBox.PressImage = (Image) manager.GetObject("Skin_Mac.NormalBox.PressImage");
            base.NormalBox.Size = new Size(0x13, 0x11);
            base.NormalBox.ToolTip = null;
            base.NormalBox.Visible = false;
            base.Radius = 10;
            base.RoundStyle = RoundStyle.Top;
            base.SystemButtonsOffset = new Point(10, 7);
            this.Text = "Skin_Mac";
            base.ResumeLayout(false);
        }
    }
}

