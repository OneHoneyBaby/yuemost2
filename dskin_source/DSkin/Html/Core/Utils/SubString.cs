namespace DSkin.Html.Core.Utils
{
    using System;
    using System.Reflection;

    public sealed class SubString
    {
        private readonly int int_0;
        private readonly int int_1;
        private readonly string string_0;

        public SubString(string fullString)
        {
            ArgChecker.AssertArgNotNull(fullString, "fullString");
            this.string_0 = fullString;
            this.int_0 = 0;
            this.int_1 = fullString.Length;
        }

        public SubString(string fullString, int startIdx, int length)
        {
            ArgChecker.AssertArgNotNull(fullString, "fullString");
            if ((startIdx < 0) || (startIdx >= fullString.Length))
            {
                throw new ArgumentOutOfRangeException("startIdx", "Must within fullString boundries");
            }
            if ((length < 0) || ((startIdx + length) > fullString.Length))
            {
                throw new ArgumentOutOfRangeException("length", "Must within fullString boundries");
            }
            this.string_0 = fullString;
            this.int_0 = startIdx;
            this.int_1 = length;
        }

        public string CutSubstring()
        {
            return ((this.int_1 > 0) ? this.string_0.Substring(this.int_0, this.int_1) : string.Empty);
        }

        public bool IsEmpty()
        {
            return (this.int_1 < 1);
        }

        public bool IsEmptyOrWhitespace()
        {
            for (int i = 0; i < this.int_1; i++)
            {
                if (!char.IsWhiteSpace(this.string_0, this.int_0 + i))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsWhitespace()
        {
            if (this.int_1 < 1)
            {
                return false;
            }
            for (int i = 0; i < this.int_1; i++)
            {
                if (!char.IsWhiteSpace(this.string_0, this.int_0 + i))
                {
                    return false;
                }
            }
            return true;
        }

        public string Substring(int startIdx, int length)
        {
            if ((startIdx < 0) || (startIdx > this.int_1))
            {
                throw new ArgumentOutOfRangeException("startIdx");
            }
            if (length > this.int_1)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            if ((startIdx + length) > this.int_1)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            return this.string_0.Substring(this.int_0 + startIdx, length);
        }

        public override string ToString()
        {
            return string.Format("Sub-string: {0}", (this.int_1 > 0) ? this.string_0.Substring(this.int_0, this.int_1) : string.Empty);
        }

        public string FullString
        {
            get
            {
                return this.string_0;
            }
        }

        public char this[int idx]
        {
            get
            {
                if ((idx < 0) || (idx > this.int_1))
                {
                    throw new ArgumentOutOfRangeException("idx", "must be within the string range");
                }
                return this.string_0[this.int_0 + idx];
            }
        }

        public int Length
        {
            get
            {
                return this.int_1;
            }
        }

        public int StartIdx
        {
            get
            {
                return this.int_0;
            }
        }
    }
}

