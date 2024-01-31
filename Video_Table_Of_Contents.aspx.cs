using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;

namespace Buldoc_Reader_Take_4
{
    public partial class Video_Table_Of_Contents : System.Web.UI.Page
    {
        DatabaseConnections connections = new DatabaseConnections();
        private List<VideoRecord> records;


        protected void Page_Load(object sender, EventArgs e)
        {
            records = connections.generateVideo();
            create_table();
           
        }

        private void create_table() 
        {
            TableRow row4 = new TableRow();
            TableCell cell4 = new TableCell();
            cell4.CssClass = "content_cell";
            cell4.ColumnSpan = 2;
            cell4.HorizontalAlign = HorizontalAlign.Center;


            Button bolduc_button = new Button();
            bolduc_button.Text = "Bolduc PBS Special - Click Here!";
            bolduc_button.CssClass = "login_button";
            bolduc_button.Click += Bolduc_button_Click;
            bolduc_button.OnClientClick = "target = '_blank';";
            cell4.Controls.Add(bolduc_button);

            row4.Cells.Add(cell4);
            Video_Table_of_Contents.Controls.Add(row4);

            foreach(VideoRecord record in records)
            {
                if(record.videoURL.ToLower().Contains("mp4"))
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

                    Video_Table_of_Contents.Controls.Add(title);
                    Video_Table_of_Contents.Controls.Add(row);
                    Video_Table_of_Contents.Controls.Add(row1);
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

                    Video_Table_of_Contents.Controls.Add(title);
                    Video_Table_of_Contents.Controls.Add(row);
                    Video_Table_of_Contents.Controls.Add(row1);
                }
                
            }

        }

        private void Bolduc_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://vimeo.com/226970628/d2dda720ba");
        }
    }
}
