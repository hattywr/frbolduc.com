using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buldoc_Reader_Take_4
{
    public class VideoRecord
    {
        public int ID;
        public string videoName;
        public string videoURL;
        public string videoDescription;
        public string videoLength;
        public string videoDate;
        public string videoLocation;
        public VideoRecord(int recordID, string recordName, string recordURL, string recordDescription, string recordLength, string recordDate, string recordLocation) 
        { 
            ID = recordID;
            videoName = recordName;
            videoURL = recordURL;      
            videoDescription = recordDescription;
            videoLength = recordLength;
            videoDate = recordDate;
            videoLocation = recordLocation;
        }

    }
}