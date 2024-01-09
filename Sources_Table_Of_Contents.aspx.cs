using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Buldoc_Reader_Take_4
{
    public partial class Sources_Table_Of_Contents : System.Web.UI.Page
    {
        DatabaseConnections connections = new DatabaseConnections();
        private List<SourceRecord> records;

        protected void Page_Load(object sender, EventArgs e)
        {
            records = connections.generateSources();
            create_table();
            //create_source_table();
        }

        private void create_table()
        {
            foreach(SourceRecord record in records)
            {
                TableRow row = new TableRow();
                row.CssClass = "content_row";
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                cell1.CssClass = "content_cell";
                cell2.CssClass = "content_cell";

                if(record.sourceNumber == 0)
                {
                    cell1.Text = "PADRE PIO REPORT";
                }
                else
                {
                    cell1.Text = "Source " + record.sourceNumber.ToString();
                }

                

                HyperLink link = new HyperLink();
                link.Text = "Source Download";
                link.NavigateUrl = record.sourceURL;
                link.Attributes["download"] = record.sourceURL;
                link.Attributes["target"] = "_blank";

                cell2.Controls.Add(link);

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                Sources_Table_of_Contents.Controls.Add(row);
            }
        }
    }
}