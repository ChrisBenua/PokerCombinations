using System;
using System.Linq;

namespace DiskraChecker
{

    public interface ICombinationRulesProvider
    {
        Func<CardCollection, bool> GetRoyalFlushRule();
        
        Func<CardCollection, bool> GetTwoOfKindRule();

        Func<CardCollection, bool> GetFlushRule();
    }
    
    public class DefaultCombinationRulesProvider: ICombinationRulesProvider
    {
        public Func<CardCollection, bool> GetRoyalFlushRule()
        {
            return new Func<CardCollection, bool>((cards) =>
            {
                foreach (var suit in EnumUtil.GetEnumValues<Suit>())
                {
                    var currentSuitCards = cards.Where(card => card.CardSuit == suit);
                    var suitCards = currentSuitCards.ToList();
                    if (suitCards.Any(el => el.CardRank == Rank.Ace) &&
                        suitCards.Any(el => el.CardRank == Rank.Ten) &&
                        suitCards.Any(el => el.CardRank == Rank.Jack) &&
                        suitCards.Any(el => el.CardRank == Rank.Queen) &&
                        suitCards.Any(el => el.CardRank == Rank.King))
                    {
                        return true;
                    }
                }

                return false;
            });
        }

        public Func<CardCollection, bool> GetTwoOfKindRule()
        {
            return (collection) =>
            {
                return collection.GroupBy(el => el.CardRank).Any(el => el.Count() >= 2);
            };
        }

        public Func<CardCollection, bool> GetFlushRule()
        {
            return (collection) => { return collection.GroupBy(el => el.CardSuit).Any(el => el.Count() >= 5); };
        }
    }
}