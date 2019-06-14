using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiskraChecker
{

    public interface IRankDistribuitonCounter
    {
        void AddToDistribution(IEnumerable<Card> cards);

        IEnumerable<(string, int)> GetDistributionReport();
    }
    
    public class RankDistributionCounter: IRankDistribuitonCounter
    {
        private List<string> _distributions = new List<string>();

        public void AddToDistribution(IEnumerable<Card> cards)
        {
            StringBuilder builder = new StringBuilder();

            var groupedCards = cards.GroupBy(card => card.CardRank).Select(el => el.Count())
                                    .OrderByDescending(el => el).ToList();
            
            foreach (var cardGroupCount in groupedCards)
            {
                builder = builder.Append(cardGroupCount);
            }
            
            _distributions.Add(builder.ToString());
        }

        public IEnumerable<(string, int)> GetDistributionReport()
        {
            return _distributions.Distinct().Select(dis => (dis, _distributions.Count(el => el == dis))).ToList();
        }
    }
}