using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrelloParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var includeContentType = true;
            var includeRecommandationType = true;

            string[] lists = new string[] { "5a48fb9eed304f607a0fd5b1", "5a7229582d13b55f7fd3276f", "5a9a5b66201a52ca049c6935", "5ac11cf8e23a67cc60610574"};

            RecomandationType recommandationType = new RecomandationType();
            ContentType contentType = new ContentType();

            using (StreamWriter w = new StreamWriter("output.txt"))
            {
                using (StreamReader r = new StreamReader("trello.json"))
                {
                    string json = r.ReadToEnd();

                    dynamic root = JsonConvert.DeserializeObject(json);

                    foreach (var card in root.cards)
                    {
                        if (lists.Contains((String)card.idList))
                        {
                            CardName cardName = contentType.ParseContentType((String)card.name);

                            Console.WriteLine(cardName.FullTitle);

                            if (includeContentType)
                            {
                                w.Write(cardName.FullTitle);
                            }
                            else
                            {
                                w.Write(cardName.Title);
                            }

                            foreach (var label in card.labels)
                            {
                                string labelName = (String)label.name;

                                if (RecomandationType.IsRecomandationType(labelName))
                                {
                                    recommandationType.Parse(labelName);
                                    if (includeRecommandationType)
                                    {
                                        w.Write(", {0}", label.name);
                                    }
                                }
                                else
                                {
                                    w.Write(", {0}", label.name);
                                }
                            }

                            w.WriteLine();
                        }
                    }

                    w.WriteLine(recommandationType.ToString());
                    w.WriteLine(contentType.ToString());
                }
            }
        }

        
    }
}
