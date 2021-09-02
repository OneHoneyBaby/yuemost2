namespace DSkin.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    [Serializable]
    public class ChatBoxContent
    {
        private System.Drawing.Color color_0;
        private Dictionary<uint, Image> dictionary_0;
        private Dictionary<uint, uint> dictionary_1;
        private System.Drawing.Font font_0;
        private List<uint> list_0;
        private string string_0;

        public ChatBoxContent()
        {
            this.string_0 = "";
            this.dictionary_0 = new Dictionary<uint, Image>();
            this.dictionary_1 = new Dictionary<uint, uint>();
            this.list_0 = new List<uint>();
        }

        public ChatBoxContent(string _text, System.Drawing.Font _font, System.Drawing.Color c)
        {
            this.string_0 = "";
            this.dictionary_0 = new Dictionary<uint, Image>();
            this.dictionary_1 = new Dictionary<uint, uint>();
            this.list_0 = new List<uint>();
            this.string_0 = _text;
            this.font_0 = _font;
            this.color_0 = c;
        }

        public void AddEmotion(uint pos, uint emotionIndex)
        {
            this.dictionary_1.Add(pos, emotionIndex);
        }

        public void AddForeignImage(uint pos, Image img)
        {
            this.dictionary_0.Add(pos, img);
        }

        public bool ContainsForeignImage()
        {
            return ((this.dictionary_0 != null) && (this.dictionary_0.Count > 0));
        }

        public string GetTextWithPicPlaceholder(string placeholder)
        {
            if ((this.list_0 == null) || (this.list_0.Count == 0))
            {
                return this.Text;
            }
            string text = this.Text;
            for (int i = this.list_0.Count - 1; i >= 0; i--)
            {
                text = text.Insert(this.list_0[i], placeholder);
            }
            return text;
        }

        public bool IsEmpty()
        {
            return ((string.IsNullOrEmpty(this.string_0) && ((this.dictionary_0 == null) || (this.dictionary_0.Count == 0))) && ((this.dictionary_1 == null) || (this.dictionary_1.Count == 0)));
        }

        public System.Drawing.Color Color
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
            }
        }

        public Dictionary<uint, uint> EmotionDictionary
        {
            get
            {
                return this.dictionary_1;
            }
            set
            {
                this.dictionary_1 = value;
            }
        }

        public System.Drawing.Font Font
        {
            get
            {
                return this.font_0;
            }
            set
            {
                this.font_0 = value;
            }
        }

        public Dictionary<uint, Image> ForeignImageDictionary
        {
            get
            {
                return this.dictionary_0;
            }
            set
            {
                this.dictionary_0 = value;
            }
        }

        public List<uint> PicturePositions
        {
            get
            {
                return this.list_0;
            }
            set
            {
                this.list_0 = value;
            }
        }

        public string Text
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }
    }
}

