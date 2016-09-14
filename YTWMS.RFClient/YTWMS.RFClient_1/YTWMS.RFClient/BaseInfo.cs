using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace YTWMS.RFClient
{
    public static class BaseInfo
    {
        ///卡车列表
        private static IDictionary<string, string> _truckList;
        public static IDictionary<string, string> truckList
        {
            get
            {
                if (_truckList == null)
                {
                    LoginInfo info = LoginInfo.GetInstance();
                    DataTable dt = ExceService.GetWareHouseTrcuks(info.LoginUser.WAREHOUSE_ID);
                    foreach (DataRow dr in dt.Rows)
                    {
                        _truckList.Add(dr["LICENCEPLATE"].ToString(), dr["ID"].ToString());
                    }
                    return _truckList;
                }
                else
                    return _truckList;
            }
            set { _truckList = value; }
        }

        ///供应商列表
        private static IDictionary<string, string> _supplierList;
        public static IDictionary<string, string> SupplierList
        {
            get
            {
                if (_supplierList == null)
                {
                    LoginInfo info = LoginInfo.GetInstance();
                    DataTable dt = ExceService.GetWareHouseSupplier(info.LoginUser.WAREHOUSE_ID);
                    foreach (DataRow dr in dt.Rows)
                    {
                        _supplierList.Add(dr["WAREHOUSE_CODE"].ToString(), dr["ID"].ToString());
                    }
                    return _supplierList;
                }
                else
                    return _supplierList;
            }
            set { _supplierList = value; }
        }

        ///大项目列表
        private static IDictionary<string, string> _projectList;
        public static IDictionary<string, string> ProjectList
        {
            get
            {
                if (_projectList == null)
                {
                    LoginInfo info = LoginInfo.GetInstance();
                    DataTable dt = ExceService.GetWareHouseSupplier(info.LoginUser.WAREHOUSE_ID);
                    foreach (DataRow dr in dt.Rows)
                    {
                        _projectList.Add(dr["WAREHOUSE_NAME"].ToString(), dr["ID"].ToString());
                    }
                    return _projectList;
                }
                else
                    return _projectList;
            }
            set { _projectList = value; }
        }
    }

    [Serializable]
    public class BoxInfo
    {
        public string PART_CODE
        {
            get;
            set;
        }

        public string BOX_CODE
        {
            get;
            set;
        }

        public string BATCH_NO
        {
            get;
            set;
        }

        public string FURNACE_NO
        {
            get;
            set;
        }

        public int QTY
        {
            get;
            set;
        }


        public int PROJECT_ID
        {
            get;
            set;
        }

        public int PROJECT_ITEM_ID
        {
            get;
            set; 
        }
    }

    [Serializable]
    public class MessageInfo
    {
        public string ResultState
        {
            get;
            set;
        }

        public string Info
        {
            get;
            set;
        }
    }


}
