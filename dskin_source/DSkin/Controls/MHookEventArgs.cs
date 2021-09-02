namespace DSkin.Controls
{
    using System;

    public class MHookEventArgs : EventArgs
    {
        private ButtonStatus buttonStatus_0;
        private int int_0;
        private int int_1;

        public MHookEventArgs(ButtonStatus btn, int cx, int cy)
        {
            this.buttonStatus_0 = btn;
            this.int_0 = cx;
            this.int_1 = cy;
        }

        public ButtonStatus MButton
        {
            get
            {
                return this.buttonStatus_0;
            }
        }

        public int X
        {
            get
            {
                return this.int_0;
            }
        }

        public int Y
        {
            get
            {
                return this.int_1;
            }
        }
    }
}

