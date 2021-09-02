namespace DSkin.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    [ToolboxItem(true)]
    public class DSkinTextureBrush : DSkinBrush
    {
        private static Bitmap bitmap_0 = new Bitmap(1, 1);
        private System.Drawing.Image image_0;
        private TextureBrush textureBrush_0;
        private System.Drawing.Drawing2D.WrapMode wrapMode_0 = System.Drawing.Drawing2D.WrapMode.Tile;

        protected override Brush CreateBrush()
        {
            if (this.image_0 == null)
            {
                this.textureBrush_0 = new TextureBrush(bitmap_0);
            }
            else
            {
                this.textureBrush_0 = new TextureBrush(this.image_0);
                this.textureBrush_0.WrapMode = this.wrapMode_0;
            }
            return this.textureBrush_0;
        }

        [DefaultValue((string) null), Description("获取与和设置此 System.Drawing.TextureBrush 对象关联的 System.Drawing.Image 对象。")]
        public System.Drawing.Image Image
        {
            get
            {
                return this.image_0;
            }
            set
            {
                if (this.image_0 != value)
                {
                    this.image_0 = value;
                    if (this.textureBrush_0 != null)
                    {
                        this.textureBrush_0.Dispose();
                        this.textureBrush_0 = null;
                        base.Brush = null;
                    }
                }
            }
        }

        [Description("获取或设置 System.Drawing.Drawing2D.WrapMode 枚举，它指示此 System.Drawing.TextureBrush 对象的换行模式。"), DefaultValue(0)]
        public System.Drawing.Drawing2D.WrapMode WrapMode
        {
            get
            {
                return this.wrapMode_0;
            }
            set
            {
                this.wrapMode_0 = value;
                if (this.textureBrush_0 != null)
                {
                    this.textureBrush_0.WrapMode = value;
                }
            }
        }
    }
}

