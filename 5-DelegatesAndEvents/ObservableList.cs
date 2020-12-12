using System;
using System.Collections;
using System.Collections.Generic;

namespace DelegatesAndEvents {

    /// <inheritdoc cref="IObservableList{T}" />
    public class ObservableList<TItem> : IObservableList<TItem>
    {
        private readonly IList<TItem> elements = new List<TItem>();

        /// <inheritdoc cref="IObservableList{T}.ElementInserted" />
        public event ListChangeCallback<TItem> ElementInserted;

        /// <inheritdoc cref="IObservableList{T}.ElementRemoved" />
        public event ListChangeCallback<TItem> ElementRemoved;

        /// <inheritdoc cref="IObservableList{T}.ElementChanged" />
        public event ListElementChangeCallback<TItem> ElementChanged;

        /// <inheritdoc cref="IEnumerable{T}.GetEnumerator" />
        public IEnumerator<TItem> GetEnumerator() => elements.GetEnumerator();

        /// <inheritdoc cref="IEnumerable.GetEnumerator" />
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)elements).GetEnumerator();

        /// <inheritdoc cref="ICollection{T}.Add" />
        public void Add(TItem item)
        {
            elements.Add(item);
            ElementInserted?.Invoke(this, item, elements.Count - 1);
        }

        /// <inheritdoc cref="ICollection{T}.Clear" />
        public void Clear()
        {
            var clone = new List<TItem>(elements);
            elements.Clear();
            for (int i = 0; i < clone.Count; i++)
            {
                ElementRemoved?.Invoke(this, clone[i], i);
            }
        }

        /// <inheritdoc cref="ICollection{T}.Contains" />
        public bool Contains(TItem item) => elements.Contains(item);

        /// <inheritdoc cref="ICollection{T}.CopyTo" />
        public void CopyTo(TItem[] array, int arrayIndex) => elements.CopyTo(array, arrayIndex);

        /// <inheritdoc cref="ICollection{T}.Remove" />
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

        /// <inheritdoc cref="ICollection{T}.Count" />
        public int Count => elements.Count;

        /// <inheritdoc cref="ICollection{T}.IsReadOnly" />
        public bool IsReadOnly => elements.IsReadOnly;

        /// <inheritdoc cref="IList{T}.IndexOf" />
        public int IndexOf(TItem item) => elements.IndexOf(item);

        /// <inheritdoc cref="IList{T}.RemoveAt" />
        public void Insert(int index, TItem item)
        {
            elements.Insert(index, item);
            ElementInserted?.Invoke(this, item, index);
        }

        /// <inheritdoc cref="IList{T}.RemoveAt" />
        public void RemoveAt(int index)
        {
            var removedItem = elements[index];
            elements.RemoveAt(index);
            ElementRemoved?.Invoke(this, removedItem, index);
        }

        /// <inheritdoc cref="IList{T}.this" />
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

        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        protected bool Equals(ObservableList<TItem> other)
        {
            return elements.Equals(other.elements);
        }

        /// <inheritdoc cref="object.Equals(object?)" />
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

        /// <inheritdoc cref="object.GetHashCode" />
        public override int GetHashCode() => elements.GetHashCode();

        /// <inheritdoc cref="object.ToString" />
        public override string ToString()
        {
            return "[" + string.Join(", ", elements) + "]";
        }
    }

}
