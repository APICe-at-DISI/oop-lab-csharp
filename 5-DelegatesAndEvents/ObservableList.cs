using System;
using System.Collections;
using System.Collections.Generic;

namespace DelegatesAndEvents {

    public class ObservableList<TItem> : IObservableList<TItem>
    {
        public IEnumerator<TItem> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(TItem item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(TItem item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(TItem[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(TItem item)
        {
            throw new System.NotImplementedException();
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public int IndexOf(TItem item)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(int index, TItem item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }

        public TItem this[int index]
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public event ListChangeCallback<TItem> ElementInserted;
        public event ListChangeCallback<TItem> ElementRemoved;
        public event ListElementChangeCallback<TItem> ElementChanged;

        public override string ToString()
        {
            // TODO improve
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            // TODO improve
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            // TODO improve
            return base.GetHashCode();
        }
    }

}