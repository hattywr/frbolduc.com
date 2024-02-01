using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Buldoc_Reader_Take_4
{
    public partial class ResourceSearch : System.Web.UI.Page
    {
        DatabaseConnections connections = new DatabaseConnections();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if(searchTB.Text.Length > 0)
            {
                string searchText = searchTB.Text.Replace(";", "");
                SearchResults results = connections.searchRecords(searchText);
                if(results.audioRecords.Count == 0 && results.imageRecords.Count == 0 && results.sourceRecords.Count == 0 && results.videoRecords.Count == 0)
                {
                    string script = "setTimeout(function() { alert('Search Yielded No Results - Adjust Search and Try Again!'); }, 25);";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
                }
                else
                {
                    generateTable(results);
                }
            }
            else
            {
                string script = "setTimeout(function() { alert('Please enter something to search by!'); }, 25);";
                ClientScript.RegisterStartupScript(this.GetType(), "MyScript", script, true);
            }
        }

        private void generateTable(SearchResults result)
        {
            Table table = new Table();
            table.CssClass = "contents_table";
            content.Controls.Add(table);

            foreach (AudioRecord record in result.audioRecords)
            {
                if (record.recordingName == "Youtube")
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

                    table.Controls.Add(title);
                    table.Controls.Add(row);
                    table.Controls.Add(audioRow);

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

                    TableRow audioRow = new TableRow();
                    row.CssClass = "content_row";
                    TableCell cell3 = new TableCell();
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

                    table.Controls.Add(title);
                    table.Controls.Add(row);
                    table.Controls.Add(audioRow);

                }
            }

            foreach (VideoRecord record in result.videoRecords)
            {
                if (record.videoURL.ToLower().Contains("mp4"))
                {
                    TableRow title = new TableRow();
                    title.CssClass = "table_title";
                    TableCell cell = new TableCell();
                    cell.CssClass = "title_cell";
                    cell.ColumnSpan = 2;
                    cell.Text = record.videoDescription;
                    title.Cells.Add(cell);

                    TableRow row = new TableRow();
                    row.CssClass = "content_row";
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    cell1.CssClass = "content_cell";
                    cell2.CssClass = "content_cell";
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);

                    cell1.Text = $"Date: {record.videoDate}";
                    cell2.Text = $"Length: {record.videoLength}";


                    TableRow row1 = new TableRow();
                    row1.CssClass = "content_row";
                    TableCell cell3 = new TableCell();
                    cell3.CssClass = "content_cell";
                    cell3.ColumnSpan = 2;


                    HtmlVideo video = new HtmlVideo();
                    video.Attributes.Add("type", "video/mp4");
                    video.Attributes.Add("controls", "controls");
                    video.Src = record.videoURL;
                    video.Attributes.Add("preload", "preload");
                    video.Attributes["style"] = "max-width:100%; height:auto; width:auto";

                    cell3.Controls.Add(video);

                    row1.Cells.Add(cell3);

                    table.Controls.Add(title);
                    table.Controls.Add(row);
                    table.Controls.Add(row1);
                }
                else if (record.videoURL.ToLower().Contains("youtu"))
                {
                    TableRow title = new TableRow();
                    title.CssClass = "table_title";
                    TableCell cell = new TableCell();
                    cell.CssClass = "title_cell";
                    cell.ColumnSpan = 2;
                    cell.Text = record.videoDescription;
                    title.Cells.Add(cell);

                    TableRow row = new TableRow();
                    row.CssClass = "content_row";
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    cell1.CssClass = "content_cell";
                    cell2.CssClass = "content_cell";
                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);

                    cell1.Text = $"Date: {record.videoDate}";
                    cell2.Text = $"Length: {record.videoLength}";


                    TableRow row1 = new TableRow();
                    row1.CssClass = "content_row";
                    TableCell cell3 = new TableCell();
                    cell3.CssClass = "content_cell";
                    cell3.ColumnSpan = 2;


                    var iframe = new HtmlGenericControl("iframe");

                    // Set attributes for the iframe
                    iframe.Attributes["width"] = "100%";
                    iframe.Attributes["height"] = "400";
                    iframe.Attributes["src"] = record.videoURL;
                    iframe.Attributes["frameborder"] = "0";
                    iframe.Attributes["allowfullscreen"] = "true";



                    cell3.Controls.Add(iframe);

                    row1.Cells.Add(cell3);

                    table.Controls.Add(title);
                    table.Controls.Add(row);
                    table.Controls.Add(row1);
                }

            }

            foreach (ImageRecord record in result.imageRecords)
            {

                TableRow title = new TableRow();
                title.CssClass = "table_title";
                TableCell cell = new TableCell();
                cell.CssClass = "title_cell";
                cell.ColumnSpan = 2;
                cell.Text = record.pictureDescription;
                title.Cells.Add(cell);



                TableRow row = new TableRow();
                row.CssClass = "content_row";
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                cell1.CssClass = "content_cell";
                cell2.CssClass = "content_cell";
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);

                cell1.Text = $"Date: {record.pictureDate}";
                cell2.Text = $"Number: {record.pictureNumber}";

                TableRow row2 = new TableRow();
                row2.CssClass = "content_row";
                TableCell cell3 = new TableCell();
                cell3.CssClass = "content_cell";
                cell3.ColumnSpan = 2;


                HtmlImage image = new HtmlImage();
                //image.ID = "Image_Player_" + i.ToString();
                image.Attributes["style"] = "max-width:100%; height:auto; width:auto";
                image.Src = record.pictureURL;

                cell3.Controls.Add(image);

                row2.Cells.Add(cell3);

                table.Controls.Add(title);

                table.Controls.Add(row);
                table.Controls.Add(row2);

            }

            foreach (SourceRecord record in result.sourceRecords)
            {
                TableRow title = new TableRow();
                title.CssClass = "table_title";
                TableCell cell = new TableCell();
                cell.CssClass = "title_cell";
                cell.ColumnSpan = 2;
                cell.Text = record.sourceDescription;
                title.Cells.Add(cell);

                TableRow row = new TableRow();
                row.CssClass = "content_row";
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                cell1.CssClass = "content_cell";
                cell2.CssClass = "content_cell";
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                cell1.Text = $"Date: {record.sourceDate}";
                cell2.Text = $"Type: {record.sourceType}";

                TableRow sourceRow = new TableRow();
                sourceRow.CssClass = "content_row";
                TableCell cell4 = new TableCell();
                TableCell cell5 = new TableCell();
                cell4.CssClass = "content_cell";
                cell5.CssClass = "content_cell";

                if (record.sourceNumber == 0)
                {
                    cell4.Text = $"Padre Pio Writeup";
                }
                else
                {
                    cell4.Text = $"Source {record.sourceNumber}";
                }

                HyperLink link = new HyperLink();
                link.Text = "Source Download";
                link.NavigateUrl = record.sourceURL;
                link.Attributes["download"] = record.sourceURL;
                link.Attributes["target"] = "_blank";

                cell5.Controls.Add(link);
                sourceRow.Controls.Add(cell4);
                sourceRow.Controls.Add(cell5);

                table.Controls.Add(title);
                table.Controls.Add(row);
                table.Controls.Add(sourceRow);
            }


        }
    }
}