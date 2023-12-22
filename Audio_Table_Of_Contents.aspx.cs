using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Azure.Storage.Blobs.Models;
using System.Diagnostics.Contracts;
using System.IO;
using System.Windows.Forms.VisualStyles;

namespace Buldoc_Reader_Take_4
{
    public partial class Audio_Table_Of_Contents : System.Web.UI.Page
    { 
        DatabaseConnections connections = new DatabaseConnections();
        private List<AudioRecord> records;

        protected void Page_Load(object sender, EventArgs e)
        {
            records = connections.generateAudio();
            //create_audio_table();
            create_table();
        }

        private void create_table()
        {
            foreach (AudioRecord record in records) 
            {
                if (record != null && !record.recordingName.Contains("OLD"))
                {
                    TableRow row = new TableRow();
                    row.CssClass = "content_row";
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    cell1.CssClass = "content_cell";
                    cell2.CssClass = "content_cell";

                    cell1.Text = record.recordingName;

                    HtmlAudio audio = new HtmlAudio();
                    //audio.ID = "Audio_Player_" + i.ToString();
                    audio.Attributes.Add("type", "audio/mp3");
                    audio.Attributes.Add("class", "sermon_audio_player");
                    audio.Attributes.Add("controls", "controls");
                    audio.Src = record.recordingURL;
                    audio.Attributes.Add("preload", "preload");

                    cell2.Controls.Add(audio);

                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    Audio_Table_of_Contents.Controls.Add(row);

                }
            }


        }
    }
}