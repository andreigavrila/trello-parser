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
            if (String.Equals(labelName, RecomandationTypeEnum.Great.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
                String.Equals(labelName, RecomandationTypeEnum.Good.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
                String.Equals(labelName, RecomandationTypeEnum.Maybe.ToString(), StringComparison.InvariantCultureIgnoreCase) ||
                String.Equals(labelName, RecomandationTypeEnum.Hmm.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }

        public static RecomandationTypeEnum Parse(string labelName)
        {
            if (String.Equals(labelName, RecomandationTypeEnum.Great.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return RecomandationTypeEnum.Great;
            }

            if (String.Equals(labelName, RecomandationTypeEnum.Good.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return RecomandationTypeEnum.Good;
            }

            if (String.Equals(labelName, RecomandationTypeEnum.Maybe.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return RecomandationTypeEnum.Maybe;
            }

            if (String.Equals(labelName, RecomandationTypeEnum.Hmm.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return RecomandationTypeEnum.Hmm;
            }

            return RecomandationTypeEnum.None;
        }
    }
}
