
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

var deck = new Deck();
deck.ShuffleDeck();
deck.PrintDeckofCards();            // test if deck is shuffled

var hand = new Hand();
hand.drawXcardsFromDeck(7, deck);

Console.WriteLine("Hand:");
hand.PrintHand();                   // Test hand

Console.WriteLine("Deck after cards removed:");
deck.PrintDeckofCards();            // Test if top cards are removed.

public class Hand
{
    private List<Card> hand = new List<Card>();
    public void drawXcardsFromDeck(int x, Deck deck)
    {
        hand = deck.DrawTopCards(x);
    }
    public void PrintHand()
    {
        for(int i = 0; i < hand.Count; i++){
            hand[i].PrintCardName();
        }
    }
}
public class Deck
{
    public Deck() { if (cards.Count == 0) AddCards(); }

    private List<Card> cards = new List<Card>();
    
    private void AddCards()
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
 
    public void ShuffleDeck()
    {
        // Shuffle by moving random cards from pile 1 to pile 2
        Random random = new Random();
        int randomCard = 0;
        var newPile = new List<Card>();

        while (cards.Count > 0)
        {
            randomCard = random.Next(0, cards.Count);
            newPile.Add(cards[randomCard]);
            cards.RemoveAt(randomCard);
        }
        cards = newPile;
    }
    public List<Card> DrawTopCards(int top)
    {
        if (cards.Count < top)
            throw new ArgumentOutOfRangeException("Cant draw more cards than what is in the deck");

        var topcards = new List<Card>();
        for (int i = 0; i < top; i++)
        {
            topcards.Add(cards[cards.Count-1]);
            cards.RemoveAt(cards.Count-1);
        }
        return topcards;
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

/*
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
 */