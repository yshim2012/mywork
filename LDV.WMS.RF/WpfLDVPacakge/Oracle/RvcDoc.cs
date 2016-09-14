using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLToolkit.Data.DataProvider.Oracle
{
    public class RvcDoc
    {
        /// <summary>
        /// 获取WMS系统的库位信息
        /// </summary>
        /// <returns></returns>
        public List<WMSRvcDoc> GetWMSData(List<string> dbConfigs)
        {
            var totalLocationList = new List<WMSRvcDoc>();

            foreach (var dbConfig in dbConfigs)
            {
                using (var db = new DbManager(dbConfig))
                {
                    var command = db.SetCommand(SqlText.SELECT_WMS_RCV_DOC);
                    var locationList = command.ExecuteList<WMSRvcDoc>();
                    totalLocationList.AddRange(locationList);
                }
            }

            if (totalLocationList.Count == 0)
            {
                return totalLocationList;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取WMS系统的库位信息
        /// </summary>
        /// <returns></returns>
        public List<WMSRvcDoc> GetWMSData()
        {
            var totalLocationList = new List<WMSRvcDoc>();

          
                using (var db = new DbManager())
                {
                    var command = db.SetCommand(SqlText.SELECT_WMS_RCV_DOC);
                    var locationList = command.ExecuteList<WMSRvcDoc>();
                    totalLocationList.AddRange(locationList);
                }
           
                return totalLocationList;
           
        }
    }
}
