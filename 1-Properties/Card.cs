using System;

namespace Properties {

    /// <summary>
    /// The class models a card.
    /// </summary>
    public class Card
    {
        private readonly string seed;
        private readonly string name;
        private readonly int ordial;

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="name">the name of the card.</param>
        /// <param name="seed">the seed of the card.</param>
        /// <param name="ordial">the ordinal number of the card.</param>
        public Card(string name, string seed, int ordial)
        {
            this.name = name;
            this.ordial = ordial;
            this.seed = seed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="tuple">the informations about the card as a tuple.</param>
        internal Card(Tuple<string, string, int> tuple)
            : this(tuple.Item1, tuple.Item2, tuple.Item3)
        {
        }

        /// <summary>
        /// Gets the seed of the card.
        /// </summary>
        public String Seed
        {
            get { return seed; }
        }

        /// <summary>
        /// Gets the name of the card.
        /// </summary>
        public string Name
        {
            get => name;
        }

        /// <summary>
        /// Gets the ordinal number of the card.
        /// </summary>
        public int Ordial => ordial;

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString()
        {
            // TODO understand string interpolation
            return $"{this.GetType().Name}(Name={this.Name}, Seed={this.Seed}, Ordinal={this.Ordial})";
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        protected bool Equals(Card other)
        {
            return string.Equals(seed, other.seed) && string.Equals(name, other.name) && ordial == other.ordial;
        }

        /// <inheritdoc cref="object.Equals(object?)"/>
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
            return Equals(obj as Card);
        }

        /// <inheritdoc cref="object.GetHashCode"/>
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
