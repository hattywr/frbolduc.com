using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;

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
                cell3.ColumnSpan= 2;


                HtmlImage image = new HtmlImage();
                //image.ID = "Image_Player_" + i.ToString();
                //image.Style["height"] = "30em";
                image.Attributes["style"] = "max-width:100%; height:auto; width:auto";
                image.Src = record.pictureURL;

                cell3.Controls.Add(image);

                row2.Cells.Add(cell3);

                Image_Table_of_Contents.Controls.Add(title);

                Image_Table_of_Contents.Controls.Add(row);
                Image_Table_of_Contents.Controls.Add(row2);

            }

        }
    }
}