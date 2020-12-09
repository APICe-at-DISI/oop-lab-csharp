using System;
using System.Collections.Generic;

namespace Iterators {

    public static class Java8StreamOperations
    {
        public static void ForEach<TAny>(this IEnumerable<TAny> sequence, Action<TAny> consumer)
        {
            foreach (var element in sequence)
            {
                consumer(element);
            }
        }

        public static IEnumerable<TAny> Peek<TAny>(this IEnumerable<TAny> sequence, Action<TAny> consumer)
        {
            foreach (var element in sequence)
            {
                consumer(element);

                yield return element;
            }
        }

        public static IEnumerable<TOther> Map<TAny, TOther>(this IEnumerable<TAny> sequence, Func<TAny, TOther> mapper)
        {
            foreach (var element in sequence)
            {
                yield return mapper(element);
            }
        }

        public static IEnumerable<TAny> Filter<TAny>(this IEnumerable<TAny> sequence, Predicate<TAny> predicate)
        {
            foreach (var element in sequence)
            {
                if (predicate(element))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<Tuple<int, TAny>> Indexed<TAny>(this IEnumerable<TAny> sequence)
        {
            int i = 0;
            
            foreach (var element in sequence)
            {
                yield return Tuple.Create(i++, element);
            }
        }

        public static TOther Reduce<TAny, TOther>(this IEnumerable<TAny> sequence, TOther seed, Func<TOther, TAny, TOther> reducer)
        {
            bool first = true;
            TOther accumulator = default(TOther);
            
            foreach (var element in sequence)
            {
                if (first)
                {
                    first = false;
                    accumulator = reducer(seed, element);
                }
                else
                {
                    accumulator = reducer(accumulator, element);
                }
            }

            return accumulator;
        }

        public static IEnumerable<TAny> SkipWhile<TAny>(this IEnumerable<TAny> sequence, Predicate<TAny> predicate)
        {
            bool skipping = true;
            
            foreach (var element in sequence)
            {
                if (skipping && !predicate(element))
                {
                    skipping = false;
                }
                else
                {
                    yield return element;
                }
            }
            
        }

        public static IEnumerable<TAny> SkipSome<TAny>(this IEnumerable<TAny> sequence, long count)
        {
            foreach (var element in sequence)
            {
                if (count-- > 0)
                {
                    continue;
                }
                
                yield return element;
            }
        }

        public static IEnumerable<TAny> TakeWhile<TAny>(this IEnumerable<TAny> sequence, Predicate<TAny> predicate)
        {
            
            foreach (var element in sequence)
            {
                if (!predicate(element))
                {
                    break;
                }
                
                yield return element;
            }
        }

        public static IEnumerable<TAny> TakeSome<TAny>(this IEnumerable<TAny> sequence, long count)
        {
            foreach (var element in sequence)
            {
                if (count-- <= 0)
                {
                    break;
                }
                
                yield return element;
            }
        }

        public static IEnumerable<int> Integers(int start)
        {
            int i = 0;

            while (true)
            {
                yield return i++;
            }
        }

        public static IEnumerable<int> Integers() => Integers(0);

        public static IEnumerable<int> Range(int start, int count) => Integers().TakeSome(count);
    }

}
