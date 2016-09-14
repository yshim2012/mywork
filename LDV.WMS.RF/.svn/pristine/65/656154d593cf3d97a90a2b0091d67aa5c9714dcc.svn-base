using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LDV.WMS.RF.DataMapper;
using LDV.WMS.RF.Utility;
using System.Data;

namespace LDV.WMS.RF.Business
{
    public class RvcDoc
    {

        /// <summary>
        /// 获取WMS系统的收货信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRvcDoc()
        {
            SqlParamSet sqlParam = new SqlParamSet();
            string SELECT_WMS_RCV_DOC = @"    select   to_char(rd.bill_date,'yyyy-mm-dd') bill_date,
                rd.doc_code,i.item_code,rdd.extend_column_2 as type            
                ,rdd.expected_qty qty,rd.whse_id   from v_wms_rcv_doc rd 
                 left join v_wms_rcv_doc_detail rdd on(rd.id=rdd.rcv_doc_id) 
                 left join v_wms_item i on(rdd.item_id=i.id) 
                 where rdd.extend_column_2 in('OP','PQ')  and rd.whse_id=1 ";
            try
            {
                return VPhrSecUsr.ExecuteWithQueryDataTable(SELECT_WMS_RCV_DOC);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取WMS系统的发货信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPickDoc()
        {
            SqlParamSet sqlParam = new SqlParamSet();
            string SELECT_WMS_RCV_DOC = @"  select pickCode,sum(pp)+sum(ed)+sum(pt) pp,sum(pt) pt,sum(ed) ed from
                        (select pickCode, case when p.status='PA' then 1 else 0 end pp,
                        case when p.status='BL' then 1 else 0 end pt,
                          case when p.status='PI' then 1 else 0 end ed
                             from (
                        select  b.extend_column_3 pickCode  
                         from  v_wms_pick_ticket b  
                         left join V_WMS_PICK_TICKET_DETAIL c on (b.id=c.pick_ticket_id) 
                          left join v_wms_pick_ticket_act a on (b.id=a.pick_ticket_id)  
                          where b.whse_id = 1
                         and b.status not in ('CA','PI','XX','V' )
                          group by    b.extend_column_3  )a
                          left join v_wms_pick_ticket p on(a.pickCode=p.extend_column_3)
                          where  p.status not in ('CA','XX','V' ))a
                          group by pickCode
                          order by pickCode   ";
            try
            {
                return VPhrSecUsr.ExecuteWithQueryDataTable(SELECT_WMS_RCV_DOC);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
