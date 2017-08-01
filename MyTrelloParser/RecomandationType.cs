using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrelloParser
{
    public class RecomandationType
    {
        public int Must { get; set; }
        public int Should { get; set; }
        public int Maybe { get; set; }
        public int Naah { get; set; }

        public RecomandationType()
        {
            Must = Should = Maybe = Naah = 0;
        }

        internal static bool IsRecomandationType(string labelName)
        {
            if (String.Equals(labelName, "MUST", StringComparison.InvariantCultureIgnoreCase) ||
                String.Equals(labelName, "SHOULD", StringComparison.InvariantCultureIgnoreCase) ||
                String.Equals(labelName, "MAYBE", StringComparison.InvariantCultureIgnoreCase) ||
                String.Equals(labelName, "NAAH", StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }

        internal void Parse(string labelName)
        {
            if (String.Equals(labelName, "MUST", StringComparison.InvariantCultureIgnoreCase))
            {
                this.Must++;
            }

            if (String.Equals(labelName, "SHOULD", StringComparison.InvariantCultureIgnoreCase))
            {
                this.Should++;
            }

            if (String.Equals(labelName, "MAYBE", StringComparison.InvariantCultureIgnoreCase))
            {
                this.Maybe++;
            }

            if (String.Equals(labelName, "NAAH", StringComparison.InvariantCultureIgnoreCase))
            {
                this.Naah++;
            }
        }

        public override string ToString()
        {
            return String.Format("Must: {0}, Should: {1}, Maybe: {2}, Naah: {3}", Must, Should, Maybe, Naah);
        }
    }
}
