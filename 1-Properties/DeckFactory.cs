using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    public class DeckFactory
    {
        private string[] seeds;

        private string[] names;

        // TODO improve
        public IList<string> Seeds 
        {
            get { return this.seeds.ToList(); }
            set { this.seeds = value.ToArray(); }
        }

        // TODO improve
        public IList<string> Names
        {
            get { return this.names.ToList(); }
            set { this.names = value.ToArray(); }
        }

        public int DeckSize => 
            this.names.Length * this.seeds.Length;

        public ISet<Card> Deck
        {
            get
            {
                if (this.names == null || this.seeds == null)
                {
                    throw new InvalidOperationException();
                }

                return new HashSet<Card>(Enumerable.Range(0, this.names.Length)
                    .SelectMany(i => Enumerable.Repeat(i, this.seeds.Length)
                        .Zip(Enumerable.Range(0, this.seeds.Length),
                            (n, s) => Tuple.Create(this.names[n], this.seeds[s], n))
                    ).Select(tuple => new Card(tuple))
                    .ToList());
            }
        }
    }

}
