using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrelloParser
{
    public static class RecomandationTypeHelper
    {
        public static bool IsRecomandationType(string labelName)
        {
            if (String.Equals(labelName, RecomandationType.Great.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
                String.Equals(labelName, RecomandationType.Good.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
                String.Equals(labelName, RecomandationType.Maybe.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
                String.Equals(labelName, RecomandationType.Hmm.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }

        public static RecomandationType Parse(string labelName)
        {
            if (String.Equals(labelName, RecomandationType.Great.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return RecomandationType.Great;
            }

            if (String.Equals(labelName, RecomandationType.Good.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return RecomandationType.Good;
            }

            if (String.Equals(labelName, RecomandationType.Maybe.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return RecomandationType.Maybe;
            }

            if (String.Equals(labelName, RecomandationType.Hmm.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return RecomandationType.Hmm;
            }

            return RecomandationType.None;
        }
    }
}
