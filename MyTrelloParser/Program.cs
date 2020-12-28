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
    static class Program
    {
        private const string RESULTS_FILE_NAME = "output.txt";
        private const string INPUT_FILE_NAME = "trello.json";
        static bool includeContentType = true;
        static bool includeRecommandationType = true;

        static void Main(string[] args)
        {
            string[] lists = new string[] { "5fc7df08750fa96d41a9764b", "5fa05cae67d30c0e85b2015b", "5f7ec0e5f134646f9781bedc", "5f4e5de970b38446c1fc0487", "5f2e7afe94a53d27e5b41e1b", "5f01a22c51f8b417935a40a0", "5ecd1771f0214e327d3ca442", "5ead4d66a5c32e62368dca69", "5e8749c0cc604238c91c7f3f", "5e5b6401d05793695b471336", "5e35f912c3d1c1813621afe5", "5e0384a7352563886c120aa0" };

            RecomandationTypeCounter recommandationTypeCounter = new RecomandationTypeCounter();
            ContentTypeCounter contentTypeCounter = new ContentTypeCounter();

            using (StreamWriter w = new StreamWriter(RESULTS_FILE_NAME))
            {
                using (StreamReader r = new StreamReader(INPUT_FILE_NAME))
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