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
        public int Nope { get; set; }

        public void Process(Card card)
        {
            if(card.RecomandationType == RecomandationType.Great)
            {
                Great++;
            }

            else if (card.RecomandationType == RecomandationType.Good)
            {
                Good++;
            }

            else if (card.RecomandationType == RecomandationType.Maybe)
            {
                Maybe++;
            }

            else if (card.RecomandationType == RecomandationType.Nope)
            {
                Nope++;
            }
        }

        public override string ToString()
        {
            return $"Great: {Great}, Good: {Good}, Maybe: {Maybe}, Hmm: {Nope}";
        }
    }
}
