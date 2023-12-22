using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;

namespace Buldoc_Reader_Take_4
{
    public partial class Admin_Controls : System.Web.UI.Page
    {
        DatabaseConnections connections = new DatabaseConnections();
        private List<RestrictedRecord> records;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["authenticated"] != null)
            {
                bool authenticated = (bool)Session["authenticated"];

                if (authenticated == false)
                {
                    Response.Redirect("Default.aspx");
                }
                records = connections.generateRestrictedContent();

                create_table();
            }
            else
            {
                Response.Redirect("Admin_Authentication.aspx");
            }
           

        }

        private void create_table()
        {
            foreach (RestrictedRecord record in records)
            {
                TableRow row = new TableRow();
                row.CssClass = "content_row";
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                cell1.CssClass = "content_cell";
                cell2.CssClass = "content_cell";

                cell1.Text = record.recordName;

                if(record.recordURL.ToLower().Contains("mp3"))
                {
                    HtmlAudio audio = new HtmlAudio();
                    audio.Attributes.Add("type", "audio/mp3");
                    audio.Attributes.Add("class", "sermon_audio_player");
                    audio.Attributes.Add("controls", "controls");
                    audio.Src = record.recordURL;
                    audio.Attributes.Add("preload", "preload");

                    cell2.Controls.Add(audio);

                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    Audio_Content.Controls.Add(row);
                }
            }
        }    
    }
}