using System.Security.Cryptography.X509Certificates;

var deck = new Deck();
deck = deck.ShuffleDeck(deck);
deck.PrintDeckofCards();



public class Deck
{
    public Deck() { if (cards.Count == 0) AddCards(); }

    public List<Card> cards = new List<Card>();
    
    public void AddCards()
    {
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (CardValue cardValue in Enum.GetValues(typeof(CardValue)))
            {
                var card = new Card
                {
                    Suit = suit,
                    CardValue = cardValue
                };
                cards.Add(card);
            }
        }
    }

    public void PrintDeckofCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Console.Write(i+1 + ": ");
            cards[i].PrintCardName();
        }
    }

    public Deck ShuffleDeck(Deck deck)
    {
        Deck ShuffledDeck = new Deck();
        Random index = new Random();
        int position = 0;

        while (deck.cards.Count > 0)
        {
            position = index.Next(0, deck.cards.Count); // Pick random position
            ShuffledDeck.cards.RemoveAt(position); // remove old card in position
            ShuffledDeck.cards.Add(deck.cards[position]); // add random card in position
            deck.cards.RemoveAt(position);
        }
            return ShuffledDeck;
    }
}


public class Card
{
    public Suit Suit { get; set; }
    public CardValue CardValue { get; set; }

    public void PrintCardName() { Console.WriteLine("{0} of {1}", CardValue, Suit); }
}

public enum CardValue
{
    Ace = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13
}

public enum Suit
{
    Clubs,
    Hearts,
    Spades,
    Dimonds
}