using MSUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPJ.Admin
{
    public partial class View_Log : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            logList.Items.Add(new ListItem("access.log"));
            logList.Items.Add(new ListItem("auth.log"));

        }

        public void getLogTable(object sender,EventArgs e)
        {
            LogTable.Rows.Clear();
            Logger l = new Logger(query.Text);
            ILogRecordset result=l.executeCommand();

            ILogRecord dataRow = null;
            TableHeaderRow header = new TableHeaderRow();
            TableHeaderCell headerCell;
            for (int i = 0; i < result.getColumnCount(); i++)
            {
                headerCell = new TableHeaderCell();
                headerCell.Text = result.getColumnName(i);
                headerCell.CssClass = "forumHeader";
                headerCell.Style.Add("border", "1px solid black");
                header.Cells.Add(headerCell);
                
            }
            LogTable.Rows.Add(header);

            while (!result.atEnd())
            {
                dataRow = result.getRecord();
                TableRow row = new TableRow();
                TableCell cell;
                for (int i = 0; i < result.getColumnCount(); i++)
                {
                    cell = new TableCell();
                    cell.Text = dataRow.getValue(i).ToString();
                    cell.Style.Add("border", "1px solid black");
                    row.Cells.Add(cell);
                }
                LogTable.Rows.Add(row);
                result.moveNext();
            }
        }
    }
}