using System;

namespace DiskraChecker
{
    public enum Suit
    {
        Diamonds = 0, Clubs, Hearts, Spades
    }

    public enum Rank
    {
        Ace = 0, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
    }
    
    public class Card: IEquatable<Card>, IComparable<Card>
    {
        public Suit CardSuit { get; set; }
        
        public Rank CardRank { get; set; }

        public Card(Suit suit, Rank rank)
        {
            CardRank = rank;
            CardSuit = suit;
        }

        public Card(Card copyable)
        {
            CardRank = copyable.CardRank;
            CardSuit = copyable.CardSuit;
        }

        public bool Equals(Card other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CardSuit == other.CardSuit && CardRank == other.CardRank;
        }

        public int CompareTo(Card other)
        {
            return Id.CompareTo(other.Id);
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
                return ((int) CardSuit * 397) ^ (int) CardRank;
            }
        }

        public int Id
        {
            get { return ((int) CardSuit) * 17 + (int) CardRank; }
        }

        public override string ToString()
        {
            return $"{CardSuit} {CardRank}";
        }
    }
}