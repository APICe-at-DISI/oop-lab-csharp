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

        public String Seed
        {
            get { return seed; }
        }

        public string Name
        {
            get => name;
        }

        public int Ordial => ordial;


        public override string ToString()
        {
            // TODO understand string interpolation
            return $"{this.GetType().Name}(Name={this.Name}, Seed={this.Seed}, Ordinal={this.Ordial})";
        }

        protected bool Equals(Card other)
        {
            return string.Equals(seed, other.seed) && string.Equals(name, other.name) && ordial == other.ordial;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Card) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (seed != null ? seed.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (name != null ? name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ordial;
                return hashCode;
            }
        }
    }

}