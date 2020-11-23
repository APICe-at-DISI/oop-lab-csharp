using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{

    public delegate void ListChangeCallback<TValue>(IObservableList<TValue> list, TValue value, int index);

    public delegate void ListElementChangeCallback<TValue>(IObservableList<TValue> list, TValue value, TValue oldValue, int index);

    public interface IObservableList<TItem> : IList<TItem>
    {
        event ListChangeCallback<TItem> ElementInserted;

        event ListChangeCallback<TItem> ElementRemoved;

        event ListElementChangeCallback<TItem> ElementChanged;
    }

}
