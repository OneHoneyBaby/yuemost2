namespace DSkin.Animations
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    public class RandomCurtainEffect : IEffects, IDisposable
    {
        private Bitmap bitmap_0;
        private Bitmap bitmap_1;
        private bool bool_0;
        private bool bool_1 = false;
        private bool bool_2 = false;
        private bool bool_3 = false;
        private int int_0;
        private int[] int_1;
        private Random random_0 = new Random();
        private Region region_0 = new Region(new GraphicsPath());

        public void Dispose()
        {
            if (this.bitmap_0 != null)
            {
                this.bitmap_0.Dispose();
                this.bitmap_0 = null;
            }
            if (this.region_0 != null)
            {
                this.region_0.Dispose();
                this.region_0 = null;
            }
            GC.SuppressFinalize(this);
        }

        public Bitmap DoEffect(out Point offset)
        {
            offset = new Point();
            if ((this.bitmap_0 == null) || (this.bitmap_0.Size != this.bitmap_1.Size))
            {
                this.bitmap_0 = new Bitmap(this.bitmap_1.Width, this.bitmap_1.Height);
            }
            using (Graphics graphics = Graphics.FromImage(this.bitmap_0))
            {
                int num;
                graphics.Clear(Color.Transparent);
                if (!this.bool_3)
                {
                    this.bool_3 = true;
                }
                if (this.bool_2)
                {
                    goto Label_018B;
                }
                this.bool_1 = false;
                this.bool_2 = false;
                using (TextureBrush brush = new TextureBrush(this.bitmap_1))
                {
                    num = 0;
                    while (num < this.int_0)
                    {
                        int index = this.random_0.Next(this.int_0);
                        if (this.int_1[index] < this.bitmap_0.Height)
                        {
                            this.int_1[index] += 6;
                            RectangleF rect = new RectangleF(index * 15f, 0f, 15f, (float) this.int_1[index]);
                            this.region_0.Union(rect);
                        }
                        else
                        {
                            num--;
                        }
                        num++;
                    }
                    graphics.FillRegion(brush, this.region_0);
                }
                this.bool_2 = true;
                for (num = 0; num < this.int_1.Length; num++)
                {
                    if (this.int_1[num] < this.bitmap_0.Height)
                    {
                        goto Label_0182;
                    }
                }
                goto Label_01AF;
            Label_0182:
                this.bool_2 = false;
                goto Label_01AF;
            Label_018B:
                graphics.DrawImage(this.bitmap_1, 0, 0);
                this.bool_1 = true;
            }
        Label_01AF:
            return this.bitmap_0;
        }

        public void Reset()
        {
            this.bool_3 = false;
            this.bool_2 = false;
            this.int_0 = (int) Math.Ceiling((double) (((float) this.bitmap_1.Width) / 15f));
            this.int_1 = new int[this.int_0];
            this.region_0.MakeEmpty();
        }

        public bool CanDesc
        {
            get
            {
                return false;
            }
        }

        public bool IsAsc
        {
            get
            {
                return this.IsAsc;
            }
            set
            {
                this.bool_0 = value;
            }
        }

        public bool IsFinal
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
            }
        }

        public string Name
        {
            get
            {
                return "随机落幕";
            }
        }

        public Bitmap Original
        {
            get
            {
                return this.bitmap_1;
            }
            set
            {
                this.bitmap_1 = value;
            }
        }
    }
}

