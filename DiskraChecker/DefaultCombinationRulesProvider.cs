using System;
using System.Linq;

namespace DiskraChecker
{

    public interface ICombinationRulesProvider
    {
        Func<CardCollection, bool> GetRoyalFlushRule();//
        
        Func<CardCollection, bool> GetTwoOfKindRule();//

        Func<CardCollection, bool> GetStraightFlushRule();

        Func<CardCollection, bool> GetFlushRule();//

        Func<CardCollection, bool> GetTwoPairsRule();//

        Func<CardCollection, bool> GetFourOfKindRule();//

        Func<CardCollection, bool> GetThreePlusTwoOfKindRule();//FullHouse

        Func<CardCollection, bool> GetStraightRule();//

        Func<CardCollection, bool> GetThreeOfKindRule();//
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

        public Func<CardCollection, bool> GetStraightFlushRule()
        {
            return (collection) =>
            {
                var groupedCollection = collection.GroupBy(el => el.CardSuit).Where(el => el.Count() >= 5);
                if (!groupedCollection.Any())
                {
                    return false;
                }

                foreach (var group in groupedCollection)
                {
                    for (int i = 0; i < 10; ++i) //check rules in wiki
                    {
                        bool ok = true;
                        for (int j = 0; j < 5; ++j)
                        {
                            ok &= group.Any(crd => (int) crd.CardRank == (i + j) % 13);
                        }

                        if (ok)
                        {
                            return true;
                        }
                    }
                }

                return false;

            };
        }

        public Func<CardCollection, bool> GetFlushRule()
        {
            return (collection) => { return collection.GroupBy(el => el.CardSuit).Any(el => el.Count() >= 5); };
        }

        public Func<CardCollection, bool> GetTwoPairsRule()
        {
            return (collection) =>
                {
                    var res = collection.GroupBy(el => el.CardRank).Select(el => el.Count());
                    return res.Count(el => el >= 2) >= 2;
                };
        }

        public Func<CardCollection, bool> GetFourOfKindRule()
        {
            return collection => collection.GroupBy(el => el.CardRank).Any(el => el.Count() >= 4);
        }

        public Func<CardCollection, bool> GetThreePlusTwoOfKindRule()
        {
            return (collection) =>
            {
                bool ok = true;
                var grouped = collection.GroupBy(el => el.CardRank);
                ok &= grouped.Count(el => el.Count() >= 3) >= 1;
                ok &= grouped.Count(el => el.Count() >= 2) >= 2;
                return ok;
            };
        }

        public Func<CardCollection, bool> GetStraightRule()
        {
            return (collection) =>
            {
                var dict = collection.GroupBy(el => el.CardRank)
                    .ToDictionary(cards => (int) cards.Key, cards => cards.Count());
                for (int i = 0; i < 10; ++i) //check rules
                {
                    bool ok = true;
                    for (int j = 0; j < 5; ++j)
                    {
                        ok &= dict.ContainsKey((i+j) % 13);
                    }

                    if (ok)
                    {
                        return true;
                    }
                }

                return false;
            };
        }

        public Func<CardCollection, bool> GetThreeOfKindRule()
        {
            return (collection) => { return collection.GroupBy(el => el.CardRank).Any(el => el.Count() >= 3); };
        }
    }
}