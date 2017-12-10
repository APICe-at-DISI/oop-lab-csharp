using System;
using System.Collections.Generic;

namespace Iterators {

    public static class Java8StreamOperations
    {
        public static void ForEach<TAny>(this IEnumerable<TAny> sequence, Action<TAny> consumer)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<TAny> Peek<TAny>(this IEnumerable<TAny> sequence, Action<TAny> consumer)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<TOther> Map<TAny, TOther>(this IEnumerable<TAny> sequence, Func<TAny, TOther> mapper)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<TAny> Filter<TAny>(this IEnumerable<TAny> sequence, Predicate<TAny> consumer)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Tuple<int, TAny>> Indexed<TAny>(this IEnumerable<TAny> sequence)
        {
            throw new NotImplementedException();
        }

        public static TOther Reduce<TAny, TOther>(this IEnumerable<TAny> sequence, TOther seed, Func<TOther, TAny, TOther> reducer)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<TAny> SkipWhile<TAny>(this IEnumerable<TAny> sequence, Predicate<TAny> consumer)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<TAny> SkipSome<TAny>(this IEnumerable<TAny> sequence, long count)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<TAny> TakeWhile<TAny>(this IEnumerable<TAny> sequence, Predicate<TAny> consumer)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<TAny> TakeSome<TAny>(this IEnumerable<TAny> sequence, long count)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<int> Integers(int start)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<int> Integers()
        {
            return Integers(0);
        }

        public static IEnumerable<int> Range(int start, int count)
        {
            return Integers().TakeSome(count);
        }
    }

}