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

            string[] lists = new string[] { "58698454901c657ae7eba794", "589ad316b7fbc3e5750c79a6", "590c363d74108d01c3a51321", "58bd6bad04b13291928b4ac7", "58e752764f4eb1ebe1be6b6e", "594907cb09017a136ef88632", "59326aced02f9060b4d0239c", "595a0163be1c060b0f9f13f4" };

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
