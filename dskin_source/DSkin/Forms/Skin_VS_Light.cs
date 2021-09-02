namespace DSkin.Forms
{
    using DSkin;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    public class Skin_VS_Light : DSkinForm
    {
        private IContainer icontainer_1 = null;

        public Skin_VS_Light()
        {
            this.ownrRyDxjb();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.icontainer_1 != null))
            {
                this.icontainer_1.Dispose();
            }
            base.Dispose(disposing);
        }

        private void ownrRyDxjb()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(0xee, 0xee, 0xf2);
            base.BorderColor = Color.FromArgb(0x9a, 0x9f, 0xb9);
            base.CaptionFont = new Font("微软雅黑", 9.75f);
            base.CaptionOffset = new Point(5, 0);
            base.CaptionShowMode = TextShowModes.Ordinary;
            base.CaptionTextRender = TextRenderingHint.AntiAliasGridFit;
            base.ClientSize = new Size(0x11c, 0x106);
            base.CloseBox.BorderHoverColor = Color.Empty;
            base.CloseBox.BorderNormalColor = Color.Empty;
            base.CloseBox.BorderPressColor = Color.Empty;
            base.CloseBox.BorderWidth = 1;
            base.CloseBox.NormalColor = Color.Black;
            base.CloseBox.HoverBackColor = Color.FromArgb(0xfc, 0xfc, 0xfd);
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
            base.MaxBox.NormalColor = Color.Black;
            base.MaxBox.HoverBackColor = Color.FromArgb(0xfc, 0xfc, 0xfd);
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
            base.MinBox.NormalColor = Color.Black;
            base.MinBox.HoverBackColor = Color.FromArgb(0xfc, 0xfc, 0xfd);
            base.MinBox.HoverImage = null;
            base.MinBox.Name = "";
            base.MinBox.NormalBackColor = Color.Transparent;
            base.MinBox.NormalImage = null;
            base.MinBox.PressBackColor = Color.FromArgb(0, 0x7a, 0xcc);
            base.MinBox.PressImage = null;
            base.MinBox.Size = new Size(30, 30);
            base.MinBox.ToolTip = null;
            base.MinBox.Visible = true;
            base.Name = "Skin_VS_Light";
            base.ShadowColor = Color.LightGray;
            base.ShowShadow = true;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Skin_VS_Light";
            base.ResumeLayout(false);
        }
    }
}

