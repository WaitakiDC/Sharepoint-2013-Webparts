using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RatesDisplay.VisualWebPart1
{
    public class RatesObject
    {
        public int assessmentNumber;
        public string valuationNumber;
        public Int16 valuationYear;
        public int landValue;
        public int capitalValue;
        public string rateable;
        public Decimal landArea;
        public string houseAddress;
        public string streetName;
        public string streetType;
        public string suburbName;
        public string formatedAddress;
        public string formatedStreetAddress;
        public decimal levied;
        public string qvLegalDescription;
        public string waterScheme;
        public decimal waterUnits;
        public string zones;
        public int districtCode;
        public string district;
        public string ratingYear;
        public string owners;
        public string postal;
        public decimal volume;
        public string parcelFlag;
        public List<RatesLevyDetail> levyDetails;
    }
}