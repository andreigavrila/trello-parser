using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;

namespace MyTrelloParser
{
    public class Card
    {
        public string ContentType { get; set; }
        public string Name { get; set; }
        public RecomandationType RecomandationType { get; set; }
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
                throw new System.ArgumentException("jsonCard cannot be null");
            }

            this.Labels = new List<string>();
            this.Alerts = new List<string>();

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
                throw new System.ArgumentException(String.Format("The card {0} does not contain a property name", jsonCard));
            }
        }
        private void ProcessLabels(dynamic jsonCard)
        {
            try
            {
                foreach (var label in jsonCard.labels)
                {
                    string labelName = (String)label.name;

                    RecomandationType recommandation = RecomandationTypeHelper.Parse(labelName);

                    if (recommandation != RecomandationType.None)
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
                throw new System.ArgumentException(String.Format("The card {0} does not contain a property name", jsonCard));
            }
        }
    }
}