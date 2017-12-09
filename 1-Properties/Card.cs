using System;

namespace Properties {

    public class Card
    {
        private readonly string seed;
        private readonly string name;
        private readonly int ordial;

        public Card(string name, string seed, int ordial)
        {
            this.name = name;
            this.ordial = ordial;
            this.seed = seed;
        }

        internal Card(Tuple<string, string, int> tuple)
            : this(tuple.Item1, tuple.Item2, tuple.Item3) { }

        public string GetSeed()
        {
            return this.seed;
        }

        public string GetName()
        {
            return this.name;
        }

        public int GetOrdinal()
        {
            return this.ordial;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}(Name={this.GetName()}, Seed={this.GetSeed()}, Ordinal={this.GetOrdinal()})";
        }

        public override bool Equals(object obj)
        {
            // TODO improve
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            // TODO improve
            return base.GetHashCode();
        }
    }

}