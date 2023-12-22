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
		public AudioRecord(int recordID, string recordName, string recordURL) 
		{ 
			ID = recordID;
			recordingName = recordName;
			recordingURL = recordURL;
		
		}
	}
}