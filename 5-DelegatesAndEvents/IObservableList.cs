namespace DelegatesAndEvents
{
    using System.Collections.Generic;

    /// <summary>
    /// Event handler for list changes in <see cref="IObservableList{TItem}"/>.
    /// </summary>
    /// <param name="list">the emitter list.</param>
    /// <param name="value">the value which was added/removed.</param>
    /// <param name="index">the index of the item which changed.</param>
    /// <typeparam name="TValue">the type of elements in the list.</typeparam>
    public delegate void ListChangeCallback<TValue>(IObservableList<TValue> list, TValue value, int index);

    /// <summary>
    /// Event handler for item changes in <see cref="IObservableList{TItem}"/>.
    /// </summary>
    /// <param name="list">the emitter list.</param>
    /// <param name="value">the new value.</param>
    /// <param name="oldValue">the old value.</param>
    /// <param name="index">the index of the item which changed its value.</param>
    /// <typeparam name="TValue">the type of elements in the list.</typeparam>
    public delegate void ListElementChangeCallback<TValue>(IObservableList<TValue> list, TValue value, TValue oldValue, int index);

    /// <summary>
    /// The interface models a <see cref="IList{T}">list</see> which is observable through events.
    /// </summary>
    /// <inheritdoc cref="IList{T}"/>
    public interface IObservableList<TItem> : IList<TItem>
    {
        /// <summary>
        /// The event is emitted whenever an item of this list is added.
        /// </summary>
        event ListChangeCallback<TItem> ElementInserted;

        /// <summary>
        /// The event is emitted whenever an item of this list is removed.
        /// </summary>
        event ListChangeCallback<TItem> ElementRemoved;

        /// <summary>
        /// The event is emitted whenever an item of this list is changed.
        /// </summary>
        event ListElementChangeCallback<TItem> ElementChanged;
    }
}
