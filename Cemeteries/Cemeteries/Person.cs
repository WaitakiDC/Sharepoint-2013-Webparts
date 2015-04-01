using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cemeteries
{
    public class RecordHolder
    {
        public List<cemRecord> records;
    }
    public class cemRecord
    {
        public string rFirstName;
        public string rLastName;
        public string rAge;
        public string rBurialDate;
        public string rDateOfDeath;
        public string rBlock;
        public string rPlotNumber;
        public string rCemetery;

        public cemRecord()
        {

        }

        public cemRecord(string firstName, string lastName, string age, string burialDate, string dateOfDeath, string block, string plotNumber, string cemetery)
        {
            this.rFirstName = firstName;
            this.rLastName = lastName;
            this.rAge = age;
            this.rBurialDate = burialDate;
            this.rBlock = block;
            this.rPlotNumber = plotNumber;
            this.rCemetery = cemetery;
            this.rDateOfDeath = dateOfDeath;
        }
    }

}
