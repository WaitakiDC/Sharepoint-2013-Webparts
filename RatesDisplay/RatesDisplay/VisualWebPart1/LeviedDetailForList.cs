using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatesDisplay.VisualWebPart1
{
    public class LeviedDetailForList
    {
        public string levyDescription { get; set; }
        public string rate { get; set; }
        public string basis { get; set; }
        public string levied { get; set; }

        public LeviedDetailForList(string levydesc, Decimal rate, Decimal basis, Decimal levied)
        {

            this.basis = basis.ToString();
            this.rate = rate.ToString("#.000000");
            this.levyDescription = levydesc;
            this.levied = levied.ToString("C");
        }

        public LeviedDetailForList(string levydesc, string rate, string basis, string levied)
        {

            this.basis = basis.ToString();
            this.rate = rate;
            this.levyDescription = levydesc;
            this.levied = levied;
        }

        public LeviedDetailForList(string levydesc, Decimal levied)
        {
            this.levyDescription = levydesc;
            this.levied = "$" + levied.ToString();
        }
    }
}