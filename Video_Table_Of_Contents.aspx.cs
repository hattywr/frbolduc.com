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
            TableRow row3 = new TableRow();
            TableRow row4 = new TableRow();
            row3.CssClass = "content_row";
            TableCell cell3 = new TableCell();
            TableCell cell4 = new TableCell();
            cell3.CssClass = "title_cell";
            cell3.ColumnSpan = 2;
            cell4.CssClass = "content_cell";
            cell4.ColumnSpan = 2;
            cell4.HorizontalAlign = HorizontalAlign.Center;
            cell3.Text = "Link to External Bolduc PBS Special";


            Button bolduc_button = new Button();
            bolduc_button.Text = "Bolduc PBS Special - Click Here!";
            bolduc_button.CssClass = "login_button";
            bolduc_button.Click += Bolduc_button_Click;
            bolduc_button.OnClientClick = "target = '_blank';";
            cell4.Controls.Add(bolduc_button);

            row3.Cells.Add(cell3);
            row4.Cells.Add(cell4);
            Video_Table_of_Contents.Controls.Add(row3);
            Video_Table_of_Contents.Controls.Add(row4);

            foreach(VideoRecord record in records)
            {
                TableRow row1 = new TableRow();
                TableRow row2 = new TableRow();
                row1.CssClass = "content_row";
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                cell1.CssClass = "title_cell";
                cell1.ColumnSpan = 2;
                cell2.CssClass = "content_cell";
                cell2.ColumnSpan = 2;
                cell2.HorizontalAlign = HorizontalAlign.Center;

                cell1.Text = record.videoName;

                HtmlVideo video = new HtmlVideo();
                
                video.Attributes.Add("type", "video/mp4");
                video.Attributes.Add("controls", "controls");
                video.Src = record.videoURL;
                video.Attributes.Add("preload", "preload");

                cell2.Controls.Add(video);

                row1.Cells.Add(cell1);
                row2.Cells.Add(cell2);
                Video_Table_of_Contents.Controls.Add(row1);
                Video_Table_of_Contents.Controls.Add(row2);
            }

        }

        private void Bolduc_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://vimeo.com/226970628/d2dda720ba");
        }
    }
}
