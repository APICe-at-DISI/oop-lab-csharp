using System.Collections.Generic;
using System.Linq;

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
                this.Tail = tail ?? new Empty<THead>();
            }

            public override bool IsNil { get => false; }

            public override int Length { get => 1 + this.Tail.Length; }
        }

        internal sealed class Empty<TList> : List<TList>
        {
            public override TList Head { get => default; }
            public override List<TList> Tail { get => null; }
            public override bool IsNil { get => true; }
            public override int Length { get => 0; }
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

        public IEnumerable<TValue> ToFlat() => Flatten().Select(ht => ht.Head);

        public override string ToString() => "[ " + string.Join(", ", this.Flatten().Select(l => l.Head)) + " ]";

        public static bool operator ==(List<TValue> list1, List<TValue> list2)
        {
            if (list1 is null || list2 is null)
            {
                return list1 == list2;
            } 
            return Enumerable.SequenceEqual(list1.ToFlat(), list2.ToFlat());
        }

        public static bool operator !=(List<TValue> list1, List<TValue> list2) => !(list1 == list2);

        public static bool operator >=(List<TValue> list1, List<TValue> list2) => list1.Length >= list2.Length;

        public static bool operator <=(List<TValue> list1, List<TValue> list2) => list1.Length <= list2.Length;

        public static bool operator <(List<TValue> list1, List<TValue> list2) => list1.Length < list2.Length;

        public static bool operator >(List<TValue> list1, List<TValue> list2) => list1.Length > list2.Length;

        public static List<TValue> operator +(List<TValue> list1, List<TValue> list2) => List.Append(list1, list2);

        public static List<TValue> operator -(List<TValue> list1, List<TValue> list2)
        {
            var second = list2.ToFlat().ToList();
            return List.From(list1.ToFlat().Where(x => !second.Contains(x)));
        }

        public static implicit operator List<TValue>(TValue[] enumerable) => List.From(enumerable as IEnumerable<TValue>);

        public static implicit operator List<TValue>(TValue element) => List.Of(element);

        public static explicit operator TValue[](List<TValue> list) => list.ToFlat().ToArray();
    }

    public static class List
    {
        public static List<TItem> Of<TItem>(TItem head) => List.Of(head, Nil<TItem>());

        public static List<TItem> Of<TItem>(TItem head, List<TItem> tail) => new List<TItem>.HeadTail<TItem>(head, tail);

        public static List<TItem> Nil<TItem>() => new List<TItem>.Empty<TItem>();

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

        public static List<TItem> From<TItem>(TItem item1, params TItem[] items) => List.From(Enumerable.Repeat(item1, 1).Concat(items));

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
