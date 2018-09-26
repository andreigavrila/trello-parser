using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrelloParser
{
    public class CardName
    {
        public string ContentType { get; set; }
        public string Title { get; set; }

        public string FullTitle { get; set; }

        public CardName(string cardName)
        {
            FullTitle = cardName;

            if (!cardName.Contains("[") || !cardName.Contains("]"))
            {
                Title = cardName;
            }
            else
            {
                ContentType = cardName.Split('[', ']')[1].Trim();
                Title = cardName.Split('[', ']')[2].Trim();
            }
        }
    }
}
