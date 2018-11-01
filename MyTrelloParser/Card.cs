using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;

namespace MyTrelloParser
{
    public class Card
    {
        private dynamic jsonCard;

        public string ContentType { get; set; }
        public string Name { get; set; }
        public RecomandationTypeEnum RecomandationType { get; set; }
        public List<string> Labels { get; set; }

        public List<string> Alerts { get; set; }

        public string FullTitle
        {
            get
            {
                return String.Concat(ContentType, " ", Name);
            }
        }

        public Card(dynamic jsonCard)
        {
            if (jsonCard == null)
            {
                throw new NullReferenceException();
            }

            this.Labels = new List<string>();
            this.Alerts = new List<string>();
            this.jsonCard = jsonCard;

            ProcessCardTitle(jsonCard);

            ProcessLabels(jsonCard);
        }

        private void ProcessCardTitle(dynamic jsonCard)
        {
            try
            {
                string[] processedName = ((String)jsonCard.name).Split('[', ']');

                if (processedName.Length == 1)
                {
                    Name = processedName[0];
                    Alerts.Add(String.Format("The card {0} does not have a content type", Name));
                }
                else
                {
                    ContentType = processedName[1].Trim();
                    Name = processedName[2].Trim();
                }
            }
            catch (RuntimeBinderException)
            {
                throw new Exception(String.Format("The card {0} does not contain a property name", jsonCard));
            }
        }
        private void ProcessLabels(dynamic jsonCard)
        {
            try
            {
                foreach (var label in jsonCard.labels)
                {
                    string labelName = (String)label.name;

                    RecomandationTypeEnum recommandation = RecomandationTypeHelper.Parse(labelName);

                    if (recommandation != RecomandationTypeEnum.None)
                    {
                        RecomandationType = recommandation;
                    }
                    else
                    {
                        Labels.Add(labelName);
                    }
                }
            }
            catch (RuntimeBinderException)
            {
                throw new Exception(String.Format("The card {0} does not contain a property name", jsonCard));
            }
        }
    }
}