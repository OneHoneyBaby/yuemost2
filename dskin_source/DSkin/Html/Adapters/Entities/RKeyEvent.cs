namespace DSkin.Html.Adapters.Entities
{
    using System;

    public sealed class RKeyEvent
    {
        private readonly bool bool_0;
        private readonly bool bool_1;
        private readonly bool bool_2;

        public RKeyEvent(bool control, bool aKeyCode, bool cKeyCode)
        {
            this.bool_0 = control;
            this.bool_1 = aKeyCode;
            this.bool_2 = cKeyCode;
        }

        public bool AKeyCode
        {
            get
            {
                return this.bool_1;
            }
        }

        public bool CKeyCode
        {
            get
            {
                return this.bool_2;
            }
        }

        public bool Control
        {
            get
            {
                return this.bool_0;
            }
        }
    }
}

