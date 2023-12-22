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
        public VideoRecord(int recordID, string recordName, string recordURL) 
        { 
            ID = recordID;
            videoName = recordName;
            videoURL = recordURL;        
        }

    }
}