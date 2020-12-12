namespace DelegatesAndEvents
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

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

        /// <inheritdoc cref="ICollection{T}.Count" />
        public int Count => this.elements.Count;

        /// <inheritdoc cref="ICollection{T}.IsReadOnly" />
        public bool IsReadOnly => this.elements.IsReadOnly;

        /// <inheritdoc cref="IList{T}.this" />
        public TItem this[int index]
        {
            get => this.elements[index];
            set
            {
                var old = this.elements[index];
                this.elements[index] = value;
                this.ElementChanged?.Invoke(this, value, old, index);
            }
        }

        /// <inheritdoc cref="IEnumerable{T}.GetEnumerator" />
        public IEnumerator<TItem> GetEnumerator() => this.elements.GetEnumerator();

        /// <inheritdoc cref="IEnumerable.GetEnumerator" />
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this.elements).GetEnumerator();

        /// <inheritdoc cref="ICollection{T}.Add" />
        public void Add(TItem item)
        {
            this.elements.Add(item);
            this.ElementInserted?.Invoke(this, item, this.elements.Count - 1);
        }

        /// <inheritdoc cref="ICollection{T}.Clear" />
        public void Clear()
        {
            var clone = new List<TItem>(this.elements);
            this.elements.Clear();
            for (int i = 0; i < clone.Count; i++)
            {
                this.ElementRemoved?.Invoke(this, clone[i], i);
            }
        }

        /// <inheritdoc cref="ICollection{T}.Contains" />
        public bool Contains(TItem item) => this.elements.Contains(item);

        /// <inheritdoc cref="ICollection{T}.CopyTo" />
        public void CopyTo(TItem[] array, int arrayIndex) => this.elements.CopyTo(array, arrayIndex);

        /// <inheritdoc cref="ICollection{T}.Remove" />
        public bool Remove(TItem item)
        {
            var removedIndex = this.elements.IndexOf(item);

            if (removedIndex >= 0)
            {
                var removedItem = this.elements[removedIndex];
                this.elements.RemoveAt(removedIndex);
                this.ElementRemoved?.Invoke(this, removedItem, removedIndex);

                return true;
            }

            return false;
        }

        /// <inheritdoc cref="IList{T}.IndexOf" />
        public int IndexOf(TItem item) => this.elements.IndexOf(item);

        /// <inheritdoc cref="IList{T}.RemoveAt" />
        public void Insert(int index, TItem item)
        {
            this.elements.Insert(index, item);
            this.ElementInserted?.Invoke(this, item, index);
        }

        /// <inheritdoc cref="IList{T}.RemoveAt" />
        public void RemoveAt(int index)
        {
            var removedItem = this.elements[index];
            this.elements.RemoveAt(index);
            this.ElementRemoved?.Invoke(this, removedItem, index);
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        public bool Equals(ObservableList<TItem> other)
        {
            return this.elements.Equals(other.elements);
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

            return this.Equals(obj as ObservableList<TItem>);
        }

        /// <inheritdoc cref="object.GetHashCode" />
        public override int GetHashCode() => this.elements.GetHashCode();

        /// <inheritdoc cref="object.ToString" />
        public override string ToString()
        {
            return "[" + string.Join(", ", this.elements) + "]";
        }
    }
}
