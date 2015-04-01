using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatesDisplay.VisualWebPart1
{
    class PropertyInfoForList
    {
        public string assessmentNumber;
        public string valuationNumber;
        public string valuationYear;
        public string landValue;
        public string capitalValue;
        public string rateable;
        public string landArea;
        public string houseAddress;
        public string formatedAddress;
        public string formatedStreetAddress;
        public string levied;
        public string qvLegalDescription;
        public string zones;
        public string ratingYear;
        public string owners;
        public string postal;

        public PropertyInfoForList (RatesObject ratesObject)
        {

                this.assessmentNumber = ratesObject.assessmentNumber.ToString();
            
            if (ratesObject.valuationNumber != null)
            this.valuationNumber = ratesObject.valuationNumber.ToString();
            else
                this.valuationNumber = "";

            this.valuationYear = ratesObject.valuationYear.ToString();


            this.landValue = ratesObject.landValue.ToString("C");
            

            this.capitalValue = ratesObject.capitalValue.ToString("C");
            
            if (ratesObject.rateable != null)
            if (ratesObject.rateable == "Y")
                this.rateable = "Rateable";
            else
                this.rateable = "Non-Rateable";
            else
                this.rateable = "";

            this.landArea = ratesObject.landArea.ToString() + "ha";
            
            if (ratesObject.houseAddress != null)
            this.houseAddress = ratesObject.houseAddress.ToString();
            else
                this.houseAddress = "";
            if (ratesObject.formatedAddress != null)
            this.formatedAddress = ratesObject.formatedAddress.ToString();
            else
                this.formatedAddress = "";
            if (ratesObject.formatedStreetAddress != null)
            this.formatedStreetAddress = ratesObject.formatedStreetAddress.ToString();
            else
                this.formatedStreetAddress = "";

            this.levied = ratesObject.levied.ToString("C");
          
            if (ratesObject.qvLegalDescription != null)
            this.qvLegalDescription = ratesObject.qvLegalDescription.ToString();
            else
                this.qvLegalDescription = "";
            if (ratesObject.zones != null)
            this.zones = ratesObject.zones.ToString();
            else
                this.zones = "";
            if (ratesObject.ratingYear != null)
            this.ratingYear = ratesObject.ratingYear.ToString();
            else
                this.ratingYear = "";
            if (ratesObject.owners != null)
            this.owners = ratesObject.owners.ToString();
            else
                this.owners = "";
            if (ratesObject.postal != null)
            this.postal = ratesObject.postal.ToString();
            else
                this.postal = "";
        }
    }
        
}
