namespace DSkin.DirectUI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Reflection;

    [ListBindable(false), Editor("DSkin.Design.DuiControlCollectionEditor,DSkin.Design, Version=16.4.2.6, Culture=neutral, PublicKeyToken=null", typeof(UITypeEditor))]
    public class DuiControlCollection : IList, ICollection, IEnumerable, ICloneable, IEnumerable<DuiBaseControl>
    {
        private DuiBaseControl duiBaseControl_0;
        private List<DuiBaseControl> list_0 = new List<DuiBaseControl>();

        public DuiControlCollection(DuiBaseControl owner)
        {
            this.duiBaseControl_0 = owner;
        }

        public void Add(DuiBaseControl control)
        {
            if (control == null)
            {
                throw new ArgumentNullException("不能添加Null");
            }
            control.Parent = this.duiBaseControl_0;
        }

        public void AddRange(IEnumerable<DuiBaseControl> items)
        {
            foreach (DuiBaseControl control in items)
            {
                this.Add(control);
            }
        }

        public void Clear()
        {
            int count = this.list_0.Count;
            for (int i = 0; i < count; i++)
            {
                this.RemoveAt(this.list_0.Count - 1);
            }
            this.duiBaseControl_0.Invalidate();
        }

        public bool Contains(DuiBaseControl value)
        {
            return this.list_0.Contains(value);
        }

        public void CopyTo(Array array, int index)
        {
            if ((array != null) && (array.Length > 0))
            {
                this.list_0.CopyTo((DuiBaseControl[]) array, index);
            }
        }

        public bool Exists(Predicate<DuiBaseControl> match)
        {
            return this.list_0.Exists(match);
        }

        public DuiBaseControl Find(Predicate<DuiBaseControl> match)
        {
            return this.list_0.Find(match);
        }

        public List<DuiBaseControl> FindAll(Predicate<DuiBaseControl> match)
        {
            return this.list_0.FindAll(match);
        }

        public int FindIndex(Predicate<DuiBaseControl> match)
        {
            return this.list_0.FindIndex(match);
        }

        public DuiBaseControl FindLast(Predicate<DuiBaseControl> match)
        {
            return this.list_0.FindLast(match);
        }

        public int FindLastIndex(Predicate<DuiBaseControl> match)
        {
            return this.list_0.FindLastIndex(match);
        }

        public IEnumerator GetEnumerator()
        {
            return this.list_0.GetEnumerator();
        }

        public int IndexOf(DuiBaseControl value)
        {
            return this.list_0.IndexOf(value);
        }

        public void Insert(int index, DuiBaseControl control)
        {
            DuiBaseControl parent = control.parent as DuiBaseControl;
            if (parent != null)
            {
                control.Parent = null;
            }
            this.list_0.Insert(index, control);
            control.parent = this.duiBaseControl_0;
            this.duiBaseControl_0.OnControlAdded(new DuiControlEventArgs(control));
        }

        internal List<DuiBaseControl> method_0()
        {
            return this.list_0;
        }

        public void Remove(DuiBaseControl value)
        {
            if (value != null)
            {
                value.Parent = null;
            }
        }

        public void RemoveAt(int index)
        {
            DuiBaseControl control = this.list_0[index];
            control.Parent = null;
        }

        public void RemoveRange(int start, int count)
        {
            int num2 = ((start + count) > this.list_0.Count) ? this.list_0.Count : (start + count);
            for (int i = start; i < num2; i++)
            {
                this.RemoveAt(start);
            }
        }

        public void Sort(Comparer<DuiBaseControl> comparer)
        {
            this.list_0.Sort(comparer);
        }

        public void Sort(IComparer<DuiBaseControl> comparer)
        {
            this.list_0.Sort(comparer);
        }

        public void Sort(Comparison<DuiBaseControl> comparison)
        {
            this.list_0.Sort(comparison);
        }

        public void Sort(int index, int count, IComparer<DuiBaseControl> comparer)
        {
            this.list_0.Sort(index, count, comparer);
        }

        IEnumerator<DuiBaseControl> IEnumerable<DuiBaseControl>.GetEnumerator()
        {
            return this.list_0.GetEnumerator();
        }

        int IList.Add(object value)
        {
            if (value is DuiBaseControl)
            {
                ((DuiBaseControl) value).Parent = this.duiBaseControl_0;
                return this.list_0.IndexOf((DuiBaseControl) value);
            }
            return -1;
        }

        bool IList.Contains(object value)
        {
            return this.list_0.Contains((DuiBaseControl) value);
        }

        int IList.IndexOf(object value)
        {
            return this.list_0.IndexOf((DuiBaseControl) value);
        }

        void IList.Insert(int index, object value)
        {
            DuiBaseControl item = value as DuiBaseControl;
            if (item != null)
            {
                DuiBaseControl parent = item.parent as DuiBaseControl;
                if (parent != null)
                {
                    item.Parent = null;
                }
                this.list_0.Insert(index, item);
                item.parent = this.duiBaseControl_0;
                this.duiBaseControl_0.OnControlAdded(new DuiControlEventArgs(item));
            }
        }

        void IList.Remove(object value)
        {
            if (value is DuiBaseControl)
            {
                ((DuiBaseControl) value).Parent = null;
            }
        }

        object ICloneable.Clone()
        {
            DuiControlCollection controls = new DuiControlCollection(this.duiBaseControl_0);
            DuiBaseControl[] array = new DuiBaseControl[this.Count];
            this.CopyTo(array, 0);
            controls.AddRange(array);
            return controls;
        }

        public int Count
        {
            get
            {
                return this.list_0.Count;
            }
        }

        public DuiBaseControl this[int index]
        {
            get
            {
                return this.list_0[index];
            }
        }

        public DuiBaseControl this[string name]
        {
            get
            {
                foreach (DuiBaseControl control in this.list_0)
                {
                    if (control.Name == name)
                    {
                        return control;
                    }
                }
                return null;
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return true;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                return this;
            }
        }

        bool IList.IsFixedSize
        {
            get
            {
                return false;
            }
        }

        bool IList.IsReadOnly
        {
            get
            {
                return false;
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

