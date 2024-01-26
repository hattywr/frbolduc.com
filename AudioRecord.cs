using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buldoc_Reader_Take_4
{
	public class AudioRecord
	{
		public int ID;
		public string recordingName;
		public string recordingURL;
		public string recordingDate;
		public string recordingLength;
		public string recordingDescription;
		public AudioRecord(int recordID, string recordName, string recordURL, string recordDate, string recordLength, string recordDescription) 
		{ 
			ID = recordID;
			recordingName = recordName;
			recordingURL = recordURL;
			recordingDate = recordDate;
			recordingLength = recordLength;	
			recordingDescription = recordDescription;
		
		}
	}
}