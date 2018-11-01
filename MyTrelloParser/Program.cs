using MyTrelloParser.Statistics;
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
        static bool includeContentType = true;
        static bool includeRecommandationType = true;

        static void Main(string[] args)
        {
            string[] lists = new string[] { "5bb314fee854c333677d8a0e", "5b93e733f2ef885fb29be8f4", "5b61a4483272e781c65b9fa5", "5b392905df03486c76f6278a", "5b0d6c6e6014559ecc8d9c4c", "5ae864b4252da993a942e236", "5ac11cf8e23a67cc60610574", "5a9a5b66201a52ca049c6935", "5a7229582d13b55f7fd3276f", "5a48fb9eed304f607a0fd5b1" };

            RecomandationTypeCounter recommandationTypeCounter = new RecomandationTypeCounter();
            ContentTypeCounter contentTypeCounter = new ContentTypeCounter();

            using (StreamWriter w = new StreamWriter("output.txt"))
            {
                using (StreamReader r = new StreamReader("trello.json"))
                {
                    string json = r.ReadToEnd();

                    dynamic root = JsonConvert.DeserializeObject(json);

                    foreach (var jsonCard in root.cards)
                    {
                        if (lists.Contains((String)jsonCard.idList))
                        {
                            Card card = new Card(jsonCard);

                            Console.WriteLine(card.FullTitle);

                            if (includeContentType)
                            {
                                w.Write(card.FullTitle);
                            }
                            else
                            {
                                w.Write(card.Name);
                            }

                            if (includeRecommandationType)
                            {
                                w.Write(", {0}", card.RecomandationType.ToString());
                            }

                            foreach (var label in card.Labels)
                            {
                                w.Write(", {0}", label);
                            }

                            w.WriteLine();

                            recommandationTypeCounter.Process(card);
                            contentTypeCounter.Process(card);
                        }
                    }

                    w.WriteLine(recommandationTypeCounter.ToString());
                    w.WriteLine(contentTypeCounter.ToString());
                }
            }
        }

        
    }
}
