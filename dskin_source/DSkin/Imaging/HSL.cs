namespace DSkin.Imaging
{
    using System;

    public class HSL
    {
        private double double_0;
        private double double_1;
        private int mVrmyvflqj;

        public HSL()
        {
        }

        public HSL(int hue, double saturation, double luminance)
        {
            this.Hue = hue;
            this.Saturation = saturation;
            this.Luminance = luminance;
        }

        public override string ToString()
        {
            return string.Format("HSL [H={0}, S={1}, L={2}]", this.mVrmyvflqj, this.double_0, this.double_1);
        }

        public int Hue
        {
            get
            {
                return this.mVrmyvflqj;
            }
            set
            {
                if (value < 0)
                {
                    this.mVrmyvflqj = 0;
                }
                else if (value <= 360)
                {
                    this.mVrmyvflqj = value;
                }
                else
                {
                    this.mVrmyvflqj = value % 360;
                }
            }
        }

        public double Luminance
        {
            get
            {
                return this.double_1;
            }
            set
            {
                if (value < 0.0)
                {
                    this.double_1 = 0.0;
                }
                else
                {
                    this.double_1 = Math.Min(value, 1.0);
                }
            }
        }

        public double Saturation
        {
            get
            {
                return this.double_0;
            }
            set
            {
                if (value < 0.0)
                {
                    this.double_0 = 0.0;
                }
                else
                {
                    this.double_0 = Math.Min(value, 1.0);
                }
            }
        }
    }
}

