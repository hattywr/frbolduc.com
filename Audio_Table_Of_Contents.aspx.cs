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
using System.Windows.Media.Media3D;

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
                if(record.recordingName == "Youtube")
                {
                    var iframe = new HtmlGenericControl("iframe");

                    // Set attributes for the iframe
                    iframe.Attributes["width"] = "100%";
                    iframe.Attributes["height"] = "400";
                    iframe.Attributes["src"] = record.recordingURL;
                    iframe.Attributes["frameborder"] = "0";
                    iframe.Attributes["allowfullscreen"] = "true";



                    TableRow title = new TableRow();
                    title.CssClass = "table_title";
                    TableCell cell = new TableCell();
                    cell.CssClass = "title_cell";
                    cell.ColumnSpan = 2;
                    cell.Text = record.recordingDescription;
                    title.Cells.Add(cell);



                    TableRow row = new TableRow();
                    row.CssClass = "content_row";
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    cell1.CssClass = "content_cell";
                    cell2.CssClass = "content_cell";
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);

                    cell1.Text = $"Date: {record.recordingDate}";
                    cell2.Text = $"Length: {record.recordingLength}";

                    TableRow audioRow = new TableRow();
                    row.CssClass = "content_row";
                    TableCell cell3 = new TableCell();
                    cell3.CssClass = "content_cell";
                    cell3.ColumnSpan = 2;


                    cell3.Controls.Add(iframe);
                    //cell3.Controls.Add(iframe);

                    audioRow.Controls.Add(cell3);

                    Audio_Table_of_Contents.Controls.Add(title);
                    Audio_Table_of_Contents.Controls.Add(row);
                    Audio_Table_of_Contents.Controls.Add(audioRow);

                }

                else if (record != null && !record.recordingName.Contains("OLD"))

                {
                    TableRow title = new TableRow();
                    title.CssClass = "table_title";
                    TableCell cell = new TableCell();
                    cell.CssClass = "title_cell";
                    cell.ColumnSpan = 2;
                    cell.Text = record.recordingDescription;
                    title.Cells.Add(cell);

                    

                    TableRow row = new TableRow();
                    row.CssClass = "content_row";
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    cell1.CssClass = "content_cell";
                    cell2.CssClass = "content_cell";
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);

                    cell1.Text = $"Date: {record.recordingDate}";
                    cell2.Text = $"Length: {record.recordingLength}"; 

                    TableRow audioRow = new TableRow() ;
                    row.CssClass = "content_row";
                    TableCell cell3 = new TableCell() ;
                    cell3.CssClass = "content_cell";
                    cell3.ColumnSpan = 2;

                    HtmlAudio audio = new HtmlAudio();
                    //audio.ID = "Audio_Player_" + i.ToString();
                    audio.Attributes.Add("type", "audio/mp3");
                    audio.Attributes.Add("class", "sermon_audio_player");
                    audio.Attributes.Add("controls", "controls");
                    audio.Src = record.recordingURL;
                    audio.Attributes.Add("preload", "preload");

                    cell3.Controls.Add(audio);

                    audioRow.Controls.Add(cell3);

                    Audio_Table_of_Contents.Controls.Add(title);
                    Audio_Table_of_Contents.Controls.Add(row);
                    Audio_Table_of_Contents.Controls.Add(audioRow);

                }
            }


        }
    }
}