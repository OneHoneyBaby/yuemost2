namespace DSkin.Html.Core.Entities
{
    using DSkin.Html.Core.Utils;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public sealed class CssBlock
    {
        private readonly bool bool_0;
        private readonly Dictionary<string, string> dictionary_0;
        private readonly List<CssBlockSelectorItem> list_0;
        private readonly string string_0;

        public CssBlock(string @class, Dictionary<string, string> properties, List<CssBlockSelectorItem> selectors = null, bool hover = false)
        {
            ArgChecker.AssertArgNotNullOrEmpty(@class, "@class");
            ArgChecker.AssertArgNotNull(properties, "properties");
            this.string_0 = @class;
            this.list_0 = selectors;
            this.dictionary_0 = properties;
            this.bool_0 = hover;
        }

        public CssBlock Clone()
        {
            return new CssBlock(this.string_0, new Dictionary<string, string>(this.dictionary_0), (this.list_0 != null) ? new List<CssBlockSelectorItem>(this.list_0) : null, false);
        }

        public bool Equals(CssBlock other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            if (!object.ReferenceEquals(this, other))
            {
                if (!object.Equals(other.string_0, this.string_0))
                {
                    return false;
                }
                if (!object.Equals(other.dictionary_0.Count, this.dictionary_0.Count))
                {
                    return false;
                }
                foreach (KeyValuePair<string, string> pair in this.dictionary_0)
                {
                    if (!other.dictionary_0.ContainsKey(pair.Key))
                    {
                        return false;
                    }
                    if (!object.Equals(other.dictionary_0[pair.Key], pair.Value))
                    {
                        return false;
                    }
                }
                if (!this.EqualsSelector(other))
                {
                    return false;
                }
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }
            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof(CssBlock))
            {
                return false;
            }
            return this.Equals((CssBlock) obj);
        }

        public bool EqualsSelector(CssBlock other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }
            if (!object.ReferenceEquals(this, other))
            {
                if (other.Hover != this.Hover)
                {
                    return false;
                }
                if ((other.list_0 == null) && (this.list_0 != null))
                {
                    return false;
                }
                if ((other.list_0 != null) && (this.list_0 == null))
                {
                    return false;
                }
                if ((other.list_0 != null) && (this.list_0 != null))
                {
                    if (!object.Equals(other.list_0.Count, this.list_0.Count))
                    {
                        return false;
                    }
                    for (int i = 0; i < this.list_0.Count; i++)
                    {
                        CssBlockSelectorItem item = other.list_0[i];
                        item = this.list_0[i];
                        if (!object.Equals(item.Class, item.Class))
                        {
                            return false;
                        }
                        item = other.list_0[i];
                        item = this.list_0[i];
                        if (!object.Equals(item.DirectParent, item.DirectParent))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return ((((this.string_0 != null) ? this.string_0.GetHashCode() : 0) * 0x18d) ^ ((this.dictionary_0 != null) ? this.dictionary_0.GetHashCode() : 0));
        }

        public void Merge(CssBlock other)
        {
            ArgChecker.AssertArgNotNull(other, "other");
            foreach (string str in other.dictionary_0.Keys)
            {
                this.dictionary_0[str] = other.dictionary_0[str];
            }
        }

        public override string ToString()
        {
            string str = this.string_0 + " { ";
            foreach (KeyValuePair<string, string> pair in this.dictionary_0)
            {
                str = str + string.Format("{0}={1}; ", pair.Key, pair.Value);
            }
            return (str + " }");
        }

        public string Class
        {
            get
            {
                return this.string_0;
            }
        }

        public bool Hover
        {
            get
            {
                return this.bool_0;
            }
        }

        public IDictionary<string, string> Properties
        {
            get
            {
                return this.dictionary_0;
            }
        }

        public List<CssBlockSelectorItem> Selectors
        {
            get
            {
                return this.list_0;
            }
        }
    }
}

