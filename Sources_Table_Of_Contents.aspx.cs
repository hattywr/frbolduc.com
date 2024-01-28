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

                if(record.sourceNumber == 0)
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

                Sources_Table_of_Contents.Controls.Add(title);
                Sources_Table_of_Contents.Controls.Add(row);
                Sources_Table_of_Contents.Controls.Add(sourceRow);
            }
        }
    }
}