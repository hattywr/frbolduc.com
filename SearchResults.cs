using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buldoc_Reader_Take_4
{
    public class SearchResults
    {
        public List<AudioRecord> audioRecords;
        public List<VideoRecord> videoRecords;
        public List<ImageRecord> imageRecords;
        public List<SourceRecord> sourceRecords;

        public SearchResults(List<AudioRecord> audio, List<VideoRecord> video, List<ImageRecord> image, List<SourceRecord> source) 
        {
            audioRecords = audio;
            videoRecords = video;
            imageRecords = image;
            sourceRecords = source;
        }

    }
}