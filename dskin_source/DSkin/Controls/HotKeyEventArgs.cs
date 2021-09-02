namespace DSkin.Controls
{
    using System;
    using System.Windows.Forms;

    public class HotKeyEventArgs : EventArgs
    {
        private KeyModifiers keyModifiers_0 = KeyModifiers.None;
        private Keys keys_0;

        public HotKeyEventArgs(KeyModifiers keyModifier, Keys key)
        {
            this.keyModifiers_0 = keyModifier;
            this.keys_0 = key;
        }

        public Keys Key
        {
            get
            {
                return this.keys_0;
            }
            set
            {
                this.keys_0 = value;
            }
        }

        public KeyModifiers KeyModifier
        {
            get
            {
                return this.keyModifiers_0;
            }
            set
            {
                this.keyModifiers_0 = value;
            }
        }
    }
}

