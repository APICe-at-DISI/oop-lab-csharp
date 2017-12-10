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
        public IList<string> GetSeeds()
        {
            return this.seeds.ToList();
        }

        // TODO improve
        public void SetSeeds(IList<string> seeds)
        {
            this.seeds = seeds.ToArray();
        }

        // TODO improve
        public IList<string> GetNames()
        {
            return this.seeds.ToList();
        }

        // TODO improve
        public void SetNames(IList<string> names)
        {
            this.names = names.ToArray();
        }

        public int GetDeckSize()
        {
            return this.names.Length * this.seeds.Length;
        }

        public ISet<Card> GetDeck()
        {
            if (this.names == null || this.seeds == null)
            {
                throw new InvalidOperationException();
            }
            return new HashSet<Card>(Enumerable.Range(0, this.names.Length)
                .SelectMany(i => Enumerable.Repeat(i, this.seeds.Length)
                    .Zip(Enumerable.Range(0, this.seeds.Length), (n, s) => Tuple.Create(this.names[n], this.seeds[s], n))
                ).Select(tuple => new Card(tuple))
                .ToList());
        }
    }

}
