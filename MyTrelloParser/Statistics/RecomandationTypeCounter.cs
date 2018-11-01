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
            if(card.RecomandationType == RecomandationTypeEnum.Great)
            {
                Great++;
            }

            if (card.RecomandationType == RecomandationTypeEnum.Good)
            {
                Good++;
            }

            if (card.RecomandationType == RecomandationTypeEnum.Maybe)
            {
                Maybe++;
            }

            if (card.RecomandationType == RecomandationTypeEnum.Hmm)
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
