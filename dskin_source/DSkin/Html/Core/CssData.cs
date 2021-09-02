namespace DSkin.Html.Core
{
    using DSkin.Html.Adapters;
    using DSkin.Html.Core.Entities;
    using DSkin.Html.Core.Utils;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public sealed class CssData
    {
        private readonly Dictionary<string, Dictionary<string, List<CssBlock>>> dictionary_0 = new Dictionary<string, Dictionary<string, List<CssBlock>>>(StringComparer.InvariantCultureIgnoreCase);
        private static readonly List<CssBlock> list_0 = new List<CssBlock>();

        internal CssData()
        {
            this.dictionary_0.Add("all", new Dictionary<string, List<CssBlock>>(StringComparer.InvariantCultureIgnoreCase));
        }

        public void AddCssBlock(string media, CssBlock cssBlock)
        {
            Dictionary<string, List<CssBlock>> dictionary;
            List<CssBlock> list;
            if (!this.dictionary_0.TryGetValue(media, out dictionary))
            {
                dictionary = new Dictionary<string, List<CssBlock>>(StringComparer.InvariantCultureIgnoreCase);
                this.dictionary_0.Add(media, dictionary);
            }
            if (!dictionary.ContainsKey(cssBlock.Class))
            {
                list = new List<CssBlock> {
                    cssBlock
                };
                dictionary[cssBlock.Class] = list;
                return;
            }
            bool flag = false;
            list = dictionary[cssBlock.Class];
            using (List<CssBlock>.Enumerator enumerator = list.GetEnumerator())
            {
                CssBlock current;
                while (enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    if (current.EqualsSelector(cssBlock))
                    {
                        goto Label_008C;
                    }
                }
                goto Label_00A6;
            Label_008C:
                flag = true;
                current.Merge(cssBlock);
            }
        Label_00A6:
            if (!flag)
            {
                if (cssBlock.Selectors == null)
                {
                    list.Insert(0, cssBlock);
                }
                else
                {
                    list.Add(cssBlock);
                }
            }
        }

        public CssData Clone()
        {
            CssData data = new CssData();
            foreach (KeyValuePair<string, Dictionary<string, List<CssBlock>>> pair in this.dictionary_0)
            {
                Dictionary<string, List<CssBlock>> dictionary = new Dictionary<string, List<CssBlock>>(StringComparer.InvariantCultureIgnoreCase);
                foreach (KeyValuePair<string, List<CssBlock>> pair2 in pair.Value)
                {
                    List<CssBlock> list = new List<CssBlock>();
                    foreach (CssBlock block in pair2.Value)
                    {
                        list.Add(block.Clone());
                    }
                    dictionary[pair2.Key] = list;
                }
                data.dictionary_0[pair.Key] = dictionary;
            }
            return data;
        }

        public void Combine(CssData other)
        {
            ArgChecker.AssertArgNotNull(other, "other");
            foreach (KeyValuePair<string, Dictionary<string, List<CssBlock>>> pair in other.method_0())
            {
                foreach (KeyValuePair<string, List<CssBlock>> pair2 in pair.Value)
                {
                    foreach (CssBlock block in pair2.Value)
                    {
                        this.AddCssBlock(pair.Key, block);
                    }
                }
            }
        }

        public bool ContainsCssBlock(string className, string media = "all")
        {
            Dictionary<string, List<CssBlock>> dictionary;
            return (this.dictionary_0.TryGetValue(media, out dictionary) && dictionary.ContainsKey(className));
        }

        public IEnumerable<CssBlock> GetCssBlock(string className, string media = "all")
        {
            List<CssBlock> list = null;
            Dictionary<string, List<CssBlock>> dictionary;
            if (this.dictionary_0.TryGetValue(media, out dictionary))
            {
                dictionary.TryGetValue(className, out list);
            }
            return (list ?? list_0);
        }

        internal IDictionary<string, Dictionary<string, List<CssBlock>>> method_0()
        {
            return this.dictionary_0;
        }

        public static CssData Parse(RAdapter adapter, string stylesheet, bool combineWithDefault = true)
        {
            Class42 class2 = new Class42(adapter);
            return class2.method_0(stylesheet, combineWithDefault);
        }
    }
}

