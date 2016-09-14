using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;



namespace Utility
{
    /// <summary>
    /// 
    /// </summary>
    public class CsvExportOperator
    {
        /// <summary>
        /// 
        /// </summary>
        public CsvExportOperator()
        {
        }

        #region 按照显示的DataGrid中数据导出到csv文件中
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="dg"></param>
        /// <returns></returns>
        public static DataTable GetCsvDT(System.Data.DataTable dataSource, DataGrid dg)
        {
            System.Collections.Queue columnCollection = new Queue();
            for (int colIndex = 0; colIndex < dg.Columns.Count; colIndex++)
            {
                if (dg.Columns[colIndex] is System.Web.UI.WebControls.BoundColumn)
                {
                    BoundColumn column = (BoundColumn)dg.Columns[colIndex];
                    if (column.DataField != "" && column.Visible)
                        columnCollection.Enqueue(new string[] { column.DataField, column.HeaderText });
                }
                if (dg.Columns[colIndex] is System.Web.UI.WebControls.HyperLinkColumn)
                {
                    HyperLinkColumn column = (HyperLinkColumn)dg.Columns[colIndex];
                    if (column.DataNavigateUrlField != "" && column.Visible)
                        columnCollection.Enqueue(new string[] { column.DataNavigateUrlField, column.HeaderText });
                }
            }
            System.Data.DataTable csvDT = new DataTable();
            IEnumerator enumerator = columnCollection.GetEnumerator();
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                csvDT.Columns.Add(((string[])enumerator.Current)[0].ToString());
            }
            foreach (DataRow dataRow in dataSource.Rows)
            {
                DataRow newRow = csvDT.NewRow();
                foreach (DataColumn dataColumn in csvDT.Columns)
                {
                    newRow[dataColumn] = dataRow[dataColumn.ColumnName];
                }
                csvDT.Rows.Add(newRow);
            }
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                string[] array = (string[])enumerator.Current;
                csvDT.Columns[array[0]].ColumnName = array[1];
            }
            return csvDT;
        }
        #endregion
    }
}
