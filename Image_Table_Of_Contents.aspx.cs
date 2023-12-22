using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Buldoc_Reader_Take_4
{
    public partial class Image_Table_Of_Contents : System.Web.UI.Page
    {
        DatabaseConnections connections = new DatabaseConnections();
        private List<ImageRecord> records;

        protected void Page_Load(object sender, EventArgs e)
        {
            records = connections.generateImages();
            create_table();
        }

        private void create_table()
        {

            foreach(ImageRecord record in records)
            {
                TableRow row = new TableRow();
                TableRow row2 = new TableRow();
                row.CssClass = "content_row";
                row2.CssClass = "content_row";
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                cell1.CssClass = "title_cell";
                cell1.Style["width"] = "100%";
                cell2.CssClass = "content_cell";
                cell2.Style["width"] = "100%";

                cell1.Text = record.pictureName;

                HtmlImage image = new HtmlImage();
                //image.ID = "Image_Player_" + i.ToString();
                image.Style["height"] = "30em";
                image.Src = record.pictureURL;

                cell2.Controls.Add(image);

                row.Cells.Add(cell1);
                row2.Cells.Add(cell2);
                Image_Table_of_Contents.Controls.Add(row);
                Image_Table_of_Contents.Controls.Add(row2);

            }

        }
    }
}