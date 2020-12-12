using System;
using System.Linq;

namespace Properties
{
    /// <summary>
    /// The seeds of italian cards.
    /// </summary>
    enum ItalianSeeds
    {
        DENARI,
        COPPE,
        SPADE,
        BASTONI
    }

    /// <summary>
    /// The names of italian cards.
    /// </summary>
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

    /// <summary>
    /// The runnable entrypoint of the exercise.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            DeckFactory df = new DeckFactory();

            df.Names = Enum.GetNames(typeof(ItalianNames)).ToList();
            df.Seeds = Enum.GetNames(typeof(ItalianSeeds)).ToList();

            // TODO understand string format convention
            Console.WriteLine("The {1} deck has {0} cards: ", df.DeckSize, "italian");

            foreach (Card c in df.Deck)
            {
                Console.WriteLine(c);
            }

            Console.ReadLine();
        }
    }
}
