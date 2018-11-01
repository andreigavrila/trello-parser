using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrelloParser.Statistics
{
    public class RecomandationTypeCounter
    {
        public int Great { get; set; }
        public int Good { get; set; }
        public int Maybe { get; set; }
        public int Hmm { get; set; }

        public RecomandationTypeCounter()
        {
            Great = Good = Maybe = Hmm = 0;
        }

        public void Process(Card card)
        {
            if(card.RecomandationType == RecomandationType.Great)
            {
                Great++;
            }

            if (card.RecomandationType == RecomandationType.Good)
            {
                Good++;
            }

            if (card.RecomandationType == RecomandationType.Maybe)
            {
                Maybe++;
            }

            if (card.RecomandationType == RecomandationType.Hmm)
            {
                Hmm++;
            }
        }

        public override string ToString()
        {
            return String.Format("Great: {0}, Good: {1}, Maybe: {2}, Hmm: {3}", Great, Good, Maybe, Hmm);
        }
    }
}
