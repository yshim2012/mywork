using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLToolkit.Data.DataProvider.Oracle
{
    /// <summary>
    /// SQL语句的类
    /// </summary>
    public static class SqlText
    {
        /// <summary>
        /// 查询WMS收货的Sql语句
        /// </summary>
        public const string SELECT_WMS_RCV_DOC = @"  select   to_char(rd.bill_date,'yyyy-mm-dd') bill_date,
                rd.doc_code,i.item_code,extend_column_2,rdd.expected_qty,whse_id   from v_wms_rcv_doc rd 
                 left join v_wms_rcv_doc_detail rdd on(rd.id=rdd.rcv_doc_id) 
                 left join v_wms_item i on(rdd.item_id=i.id) 
                 where rdd.extend_column_2 in('OP','PQ')  and whse_id=1";
        
    }
}
