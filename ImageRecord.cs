using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buldoc_Reader_Take_4
{
    public class ImageRecord
    {
        public int ID;
        public string pictureName;
        public int pictureNumber;
        public string pictureURL;
        public string pictureDate;
        public string pictureDescription;

        public ImageRecord(int recordID, string recordName, int recordNumber, string recordURL, string recordDate, string recordDescription) 
        {
            ID = recordID;
            pictureName = recordName;
            pictureNumber = recordNumber;
            pictureURL = recordURL;         
            pictureDate = recordDate;
            pictureDescription = recordDescription;
        
        }

    }
}