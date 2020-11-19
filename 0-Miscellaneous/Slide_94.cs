using System;
using System.Threading;

namespace PartOne.Esempio1
{
    class Worker
    {
        private int from, count;

        public Worker(int from, int count)
        {
            this.from = from;
            this.count = count;
        }

        public void Run()
        {
            for (int i = from; i < from + count; i++)
            {
                if (IsPrime(i))
                {
                    Console.Write("{0}\n", i);
                }
            }
        }

        private static bool IsPrime(int num)
        {
            int sq = (int) Math.Sqrt(num);
            for (int i = 2; i <= sq; i++)
            {
                if ((num % i) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void Main(string[] args)
        {
            const int n = 1000;
            const int t = 4;
            int from = 2;
            int count = (n - from) / t;
            for (int i = 0; i < t - 1; i++)
            {
                new Thread(new Worker(from, count).Run).Start();
                from += count;
            }

            new Thread(new Worker(from, n - from).Run).Start();
        }
    }
}

namespace Esempio2
{
    class Worker
    {
        private int from, count;

        public Worker(int from, int count)
        {
            this.from = from;
            this.count = count;
        }

        public void Run()
        {
            for (int i = from; i < from + count; i++)
            {
                if (IsPrime(i))
                {
                    Console.Write("{0}\n", i);
                }
            }
        }

        private static bool IsPrime(int num)
        {
            int sq = (int) Math.Sqrt(num);
            for (int i = 2; i <= sq; i++)
            {
                if ((num % i) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void Main(string[] args)
        {
            const int n = 1000;
            const int t = 4;
            int from = 2;
            int count = (n - from) / t;
            for (int i = 0; i < t - 1; i++)
            {
                new Thread(new Worker(from, count).Run).Start();
                from += count;
            }

            new Thread(new Worker(from, n - from).Run).Start();
        }
    }
}