using System.Collections;
using System.Collections.Generic;

namespace DelegatesAndEvents {

    public class ObservableList<TItem> : IObservableList<TItem>
    {
        private readonly IList<TItem> elements = new List<TItem>();

        public event ListChangeCallback<TItem> ElementInserted;
        public event ListChangeCallback<TItem> ElementRemoved;
        public event ListElementChangeCallback<TItem> ElementChanged;

        public IEnumerator<TItem> GetEnumerator() => elements.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)elements).GetEnumerator();

        public void Add(TItem item)
        {
            elements.Add(item);
            ElementInserted?.Invoke(this, item, elements.Count - 1);
        }

        public void Clear()
        {
            var clone = new List<TItem>(elements);
            elements.Clear();
            for (int i = 0; i < clone.Count; i++)
            {
                ElementRemoved?.Invoke(this, clone[i], i);
            }
        }

        public bool Contains(TItem item) => elements.Contains(item);

        public void CopyTo(TItem[] array, int arrayIndex) => elements.CopyTo(array, arrayIndex);

        public bool Remove(TItem item)
        {
            var removedIndex = elements.IndexOf(item);
            
            if (removedIndex >= 0)
            {
                var removedItem = elements[removedIndex];
                elements.RemoveAt(removedIndex);
                ElementRemoved?.Invoke(this, removedItem, removedIndex);

                return true;
            }

            return false;
        }

        public int Count => elements.Count;

        public bool IsReadOnly => elements.IsReadOnly;

        public int IndexOf(TItem item) => elements.IndexOf(item);

        public void Insert(int index, TItem item)
        {
            elements.Insert(index, item);
            ElementInserted?.Invoke(this, item, index);
        }

        public void RemoveAt(int index)
        {
            var removedItem = elements[index];
            elements.RemoveAt(index);
            ElementRemoved?.Invoke(this, removedItem, index);
        }

        public TItem this[int index]
        {
            get => elements[index];
            set
            {
                var old = elements[index];
                elements[index] = value;
                ElementChanged?.Invoke(this, value, old, index);
            }
        }

        protected bool Equals(ObservableList<TItem> other)
        {
            return elements.Equals(other.elements);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (this == obj)
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals(obj as ObservableList<TItem>);
        }

        public override int GetHashCode() => elements.GetHashCode();

        public override string ToString()
        {
            return "[" + string.Join(", ", elements) + "]";
        }
    }

}
