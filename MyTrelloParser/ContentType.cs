using System;
using System.Collections.Generic;
using System.Text;

namespace MyTrelloParser
{
    public class ContentTypeCounter
    {
        private readonly Dictionary<string, int> types = new Dictionary<string, int>();

        public void Process(Card card)
        {
            string contentType = card.ContentType;

            if (!String.IsNullOrEmpty(contentType))
            {
                if (types.ContainsKey(contentType))
                {
                    types[contentType] = types[contentType] + 1;
                }
                else
                {
                    types[contentType] = 1;
                }
            }
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