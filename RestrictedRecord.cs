using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buldoc_Reader_Take_4
{
    public class RestrictedRecord
    {
        public int ID;
        public string recordName;
        public int recordNumber;
        public string recordURL;
        public RestrictedRecord(int recordID, string name, int number, string url) 
        {
            ID = recordID;
            recordName = name;
            recordNumber = number;
            recordURL = url;
            
        }
    }
}