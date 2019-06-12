using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiskraChecker
{
    public class CardCollection: IEnumerable<Card>, ICloneable
    {
        private SortedSet<Card> _cards;


        public CardCollection()
        {
            _cards = new SortedSet<Card>();
        }
        public CardCollection(IEnumerable<Card> cards)
        {
            _cards = new SortedSet<Card>();
            foreach (var card in cards)
            {
                _cards.Add(card);
            }
        }

        public void FillDefault()
        {
            if (_cards is null)
            {
                _cards = new SortedSet<Card>();
            }
            foreach (var suit in EnumUtil.GetEnumValues<Suit>())
            {
                foreach (var rank in EnumUtil.GetEnumValues<Rank>())
                {
                    _cards.Add(new Card(suit, rank));
                }
            }
        }

        public void AddCardsRange(IEnumerable<Card> newCards)
        {
            foreach (var card in newCards)
            {
                _cards.Add(card);
            }
        }
        
        public void AddCard(Card newCard)
        {
            _cards.Add(newCard);
        }

        public void RemoveCard(Card cardToRemove)
        {
            _cards.Remove(cardToRemove);
        }

        public void RemoveCardRange(IEnumerable<Card> cards)
        {
            foreach (var el in cards)
            {
                _cards.Remove(el);
            }
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public object Clone()
        {
            CardCollection clone = new CardCollection();
            foreach (var el in this)
            {
                clone.AddCard(new Card(el));
            }

            return clone;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var el in _cards)
            {
                builder = builder.Append("| ");
                builder = builder.Append(el);
                builder = builder.Append(" |");
            }

            return builder.ToString();
        }
    }
}