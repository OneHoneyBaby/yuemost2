namespace DSkin.Forms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    public class SystemButtonCollection : IList, ICollection, IEnumerable
    {
        private DSkinForm dskinForm_0;
        private List<SystemButton> list_0 = new List<SystemButton>();

        public SystemButtonCollection(DSkinForm owner)
        {
            this.dskinForm_0 = owner;
        }

        public int Add(object value)
        {
            ((SystemButton) value).Owner = this.dskinForm_0;
            this.list_0.Add((SystemButton) value);
            return this.list_0.IndexOf((SystemButton) value);
        }

        public void Clear()
        {
            this.list_0.Clear();
            this.dskinForm_0.Invalidate();
        }

        public bool Contains(object value)
        {
            return this.list_0.Contains((SystemButton) value);
        }

        public void CopyTo(Array array, int index)
        {
            if ((array != null) && (array.Length > 0))
            {
                this.list_0.CopyTo((SystemButton[]) array, index);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this.list_0.GetEnumerator();
        }

        public int IndexOf(object value)
        {
            ((SystemButton) value).Owner = this.dskinForm_0;
            return this.list_0.IndexOf((SystemButton) value);
        }

        public void Insert(int index, object value)
        {
            ((SystemButton) value).Owner = this.dskinForm_0;
            this.list_0.Insert(index, (SystemButton) value);
        }

        public void Remove(object value)
        {
            this.list_0.Remove((SystemButton) value);
            this.dskinForm_0.Invalidate();
        }

        public void RemoveAt(int index)
        {
            this.list_0.RemoveAt(index);
            this.dskinForm_0.Invalidate();
        }

        public int Count
        {
            get
            {
                return this.list_0.Count;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return true;
            }
        }

        public SystemButton this[int index]
        {
            get
            {
                return this.list_0[index];
            }
        }

        public object SyncRoot
        {
            get
            {
                return this;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this.list_0[index];
            }
            set
            {
            }
        }
    }
}

