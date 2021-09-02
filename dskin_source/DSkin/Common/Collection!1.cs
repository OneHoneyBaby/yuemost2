namespace DSkin.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using System.Threading;

    public class Collection<T> : IEnumerable<T>, IList, ICollection, IEnumerable
    {
        private List<T> list_0;
        private object object_0;

        public event EventHandler<CollectionEventArgs<T>> ItemAdded;

        public event EventHandler<CollectionEventArgs<T>> ItemRemoved;

        public Collection()
        {
            this.list_0 = new List<T>();
        }

        public void Add(T value)
        {
            this.list_0.Add(value);
            this.OnItemAdded(value, this.list_0.Count - 1);
        }

        public void AddRange(T[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                this.Add(items[i]);
            }
        }

        public void Clear()
        {
            int count = this.list_0.Count;
            for (int i = 0; i < count; i++)
            {
                this.RemoveAt(0);
            }
        }

        public bool Contains(T value)
        {
            return this.list_0.Contains(value);
        }

        public void CopyTo(Array array, int index)
        {
            this.list_0.CopyTo(array, index);
        }

        public bool Exists(Predicate<T> match)
        {
            return this.list_0.Exists(match);
        }

        public T Find(Predicate<T> match)
        {
            return this.list_0.Find(match);
        }

        public List<T> FindAll(Predicate<T> match)
        {
            return this.list_0.FindAll(match);
        }

        public int FindIndex(Predicate<T> match)
        {
            return this.list_0.FindIndex(match);
        }

        public T FindLast(Predicate<T> match)
        {
            return this.list_0.FindLast(match);
        }

        public int FindLastIndex(Predicate<T> match)
        {
            return this.list_0.FindLastIndex(match);
        }

        public IEnumerator GetEnumerator()
        {
            return this.list_0.GetEnumerator();
        }

        public int IndexOf(T value)
        {
            return this.list_0.IndexOf(value);
        }

        public void Insert(int index, T item)
        {
            this.list_0.Insert(index, item);
            this.OnItemAdded(item, index);
        }

        protected virtual void OnItemAdded(T e, int index)
        {
            if (this.eventHandler_0 != null)
            {
                this.eventHandler_0(this, new CollectionEventArgs<T>(e, index));
            }
        }

        protected virtual void OnItemRemoved(T e, int index)
        {
            if (this.eventHandler_1 != null)
            {
                this.eventHandler_1(this, new CollectionEventArgs<T>(e, index));
            }
        }

        public void Remove(T value)
        {
            int index = this.list_0.IndexOf(value);
            this.list_0.RemoveAt(index);
            this.OnItemRemoved(value, index);
        }

        public void RemoveAt(int index)
        {
            T e = this.list_0[index];
            this.list_0.RemoveAt(index);
            this.OnItemRemoved(e, index);
        }

        public void RemoveRange(int start, int count)
        {
            for (int i = start; i < count; i++)
            {
                this.RemoveAt(start);
            }
        }

        public void Sort(Comparer<T> comparer)
        {
            this.list_0.Sort(comparer);
        }

        public void Sort(IComparer<T> comparer)
        {
            this.list_0.Sort(comparer);
        }

        public void Sort(Comparison<T> comparison)
        {
            this.list_0.Sort(comparison);
        }

        public void Sort(int index, int count, IComparer<T> comparer)
        {
            this.list_0.Sort(index, count, comparer);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.list_0.GetEnumerator();
        }

        int IList.Add(object value)
        {
            this.list_0.Add((T) value);
            this.OnItemAdded((T) value, this.list_0.Count - 1);
            return (this.list_0.Count - 1);
        }

        bool IList.Contains(object value)
        {
            return this.list_0.Contains((T) value);
        }

        int IList.IndexOf(object value)
        {
            return this.list_0.IndexOf((T) value);
        }

        void IList.Insert(int index, object value)
        {
            this.list_0.Insert(index, (T) value);
            this.OnItemAdded((T) value, index);
        }

        void IList.Remove(object value)
        {
            int index = this.list_0.IndexOf((T) value);
            this.list_0.RemoveAt(index);
            this.OnItemRemoved((T) value, index);
        }

        public int Count
        {
            get
            {
                return this.list_0.Count;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<T> InnerList
        {
            get
            {
                return this.list_0;
            }
        }

        public T this[int index]
        {
            get
            {
                return this.list_0[index];
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

        public object Tag
        {
            get
            {
                return this.object_0;
            }
            set
            {
                this.object_0 = value;
            }
        }
    }
}

