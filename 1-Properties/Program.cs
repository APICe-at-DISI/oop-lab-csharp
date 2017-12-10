using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{

    enum ItalianSeeds
    {
        DENARI,
        COPPE,
        SPADE,
        BASTONI
    }


    enum ItalianNames
    {
        ASSO,
        DUE,
        TRE,
        QUATTRO,
        CINQUE,
        SEI,
        SETTE,
        FANTE,
        CAVALLO,
        RE
    }

    class Program
    {
        static void Main(string[] args)
        {
            DeckFactory df = new DeckFactory();

            df.SetNames(Enum.GetNames(typeof(ItalianNames)).ToList());
            df.SetSeeds(Enum.GetNames(typeof(ItalianSeeds)).ToList());

            // TODO understant string format convention
            Console.WriteLine("The {1} deck has {0} cards: ", df.GetDeckSize(), "italian");

            foreach (Card c in df.GetDeck())
            {
                Console.WriteLine(c);
            }

            Console.ReadLine();
        }
    }
}
