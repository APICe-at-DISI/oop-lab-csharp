using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsOverloading
{
    public abstract class List<TValue> 
    {
        internal sealed class HeadTail<THead> : List<THead>
        {
            public override THead Head { get; }
            public override List<THead> Tail { get; }

            public HeadTail(THead head, List<THead> tail)
            {
                this.Head = head;
                this.Tail = tail ?? new List<THead>.Empty<THead>();
            }

            public override bool IsNil
            {
                get { return false; }
            }

            public override int Length
            {
                get { return 1 + this.Tail.Length; }
            }
        }

        internal sealed class Empty<TList> : List<TList>
        {
            public override TList Head { get { return default(TList); } }
            public override List<TList> Tail { get { return null; } }
            public override bool IsNil { get { return true; } }
            public override int Length
            {
                get { return 0; }
            }
        }

        public abstract TValue Head { get; }

        public abstract List<TValue> Tail { get; }

        public abstract bool IsNil { get; }

        public abstract int Length { get; }

        public IEnumerable<List<TValue>> Flatten()
        {
            List<TValue> curr = this;
            for (; !curr.IsNil; curr = curr.Tail)
            {
                yield return curr;
            }
        }

        public IEnumerable<TValue> ToFlat()
        {
            return Flatten().Select(ht => ht.Head);
        }

        public override string ToString()
        {
            return "[ " + string.Join(", ", this.Flatten()
                       .Select(l => l.Head)) +" ]";
        }

        public static bool operator ==(List<TValue> list1, List<TValue> list2)
        {
            if (ReferenceEquals(list1, null)|| ReferenceEquals(list2, null))
            {
                return list1 == list2;
            } 
            return Enumerable.SequenceEqual(
                list1.ToFlat(),
                list2.ToFlat()
            );
        }

        public static bool operator !=(List<TValue> list1, List<TValue> list2)
        {
            return !(list1 == list2);
        }

        public static bool operator >=(List<TValue> list1, List<TValue> list2)
        {
            return list1.Length >= list2.Length;
        }

        public static bool operator <=(List<TValue> list1, List<TValue> list2)
        {
            return list1.Length <= list2.Length;
        }

        public static bool operator <(List<TValue> list1, List<TValue> list2)
        {
            return list1.Length < list2.Length;
        }

        public static bool operator >(List<TValue> list1, List<TValue> list2)
        {
            return list1.Length > list2.Length;
        }

        public static List<TValue> operator +(List<TValue> list1, List<TValue> list2)
        {
            return List.Append(list1, list2);
        }

        public static List<TValue> operator -(List<TValue> list1, List<TValue> list2)
        {
            var second = list2.ToFlat().ToList();
            return List.From(
                list1.ToFlat().Where(x => !second.Contains(x))
            );
        }

        public static implicit operator List<TValue>(TValue[] enumerable)
        {
            return List.From(enumerable as IEnumerable<TValue>);
        }

        public static implicit operator List<TValue>(TValue element)
        {
            return List.Of(element);
        }

        public static explicit operator TValue[] (List<TValue> list)
        {
            return list.ToFlat().ToArray();
        }
    }

    public static class List
    {
        public static List<TItem> Of<TItem>(TItem head)
        {
            return List.Of(head, Nil<TItem>());
        }

        public static List<TItem> Of<TItem>(TItem head, List<TItem> tail)
        {
            return new List<TItem>.HeadTail<TItem>(head, tail);
        }

        public static List<TItem> Nil<TItem>()
        {
            return new List<TItem>.Empty<TItem>();
        }

        public static List<TItem> From<TItem>(IEnumerable<TItem> items)
        {
            var elems = items.Reverse().ToArray();
            List<TItem> curr = List.Of(elems.First());

            foreach (var e in elems.Skip(1))
            {
                curr = List.Of(e, curr);
            }

            return curr;
        }

        public static List<TItem> From<TItem>(TItem item1, params TItem[] items)
        {
            return List.From(Enumerable.Repeat(item1, 1).Concat(items));
        }

        public static List<TItem> Append<TItem>(List<TItem> list1, List<TItem> list2)
        {
            var elems = list1.Flatten().Select(l => l.Head).Reverse().ToArray();
            List<TItem> curr = List.Of(elems.First(), list2);

            foreach (var e in elems.Skip(1))
            {
                curr = List.Of(e, curr);
            }

            return curr;
        }
    }


    

}
