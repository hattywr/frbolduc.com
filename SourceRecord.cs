using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buldoc_Reader_Take_4
{
    public class SourceRecord
    {
        public int ID;
        public string fileExtension;
        public int sourceNumber;
        public string sourceURL;
        public SourceRecord(int recordID, string recordExtension, int recordNumber, string recordURL) 
        {
            ID = recordID;
            fileExtension = recordExtension;
            sourceNumber = recordNumber;
            sourceURL = recordURL;            
        }

    }
}