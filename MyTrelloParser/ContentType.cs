using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrelloParser
{
    public class ContentType
    {
        Dictionary<string, int> types = new Dictionary<string,int>();

        public CardName ParseContentType(string input)
        {
            CardName cardName = new CardName(input);

            if(!String.IsNullOrEmpty(cardName.ContentType))
            {
                if (types.ContainsKey(cardName.ContentType))
                {
                    types[cardName.ContentType] = types[cardName.ContentType] + 1;
                }
                else
                {
                    types[cardName.ContentType] = 1;
                }
            }

            return cardName;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var key in types.Keys)
            {
                builder.AppendFormat("{0}: {1}, ", key, types[key]);
            }

            return builder.ToString();
        }
    }
}