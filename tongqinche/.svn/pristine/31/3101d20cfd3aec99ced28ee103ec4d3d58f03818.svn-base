using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataMapper;
using Common;

namespace tongqinche.Controllers
{
    public class CarrierApiController : ApiController
    {
        public string GetCarrierList() {
            Carrier Car = new Carrier();
            var CarList = Car.QueryList("SelectAll");
            var jsonStr = JsonSerializationHandler.Serialize<IList<Carrier>>(CarList);
            return jsonStr;
        }

        [HttpPost]
        public string PostCarrier(dynamic Car) 
        {
            Carrier parmCar = new Carrier();
            if (Car != null) 
            {
                if (Car["CarrierName"] != null)
                {
                    parmCar.CarrierName = Car["CarrierName"].ToString().Trim();
                }
                if (Car["Contact"] != null)
                {
                    parmCar.Contact = Car["Contact"].ToString().Trim();
                }
                if (Car["Mobile"] != null)
                {
                    parmCar.Mobile = Car["Mobile"].ToString().Trim();
                }
                if (Car["Tel"] != null)
                {
                    parmCar.Tel = Car["Tel"].ToString().Trim();
                }
                if (Car["Address"] != null)
                {
                    parmCar.Address = Car["Address"].ToString().Trim();
                }
                if (Car["Status"] != null)
                {
                    parmCar.Status = Car["Status"].ToString().Trim();
                }
            }
            var CarList = parmCar.QueryList("SelectByParam");
            var jsonStr = JsonSerializationHandler.Serialize<IList<Carrier>>(CarList);
            return jsonStr;
        }

        [HttpPost]
        public int CreateCarrier(dynamic Carrier)
        {
            //try
            //{
            //    Carrier newCar = new Carrier();
            //    newCar.CarrierName = Carrier["CarrierName"];
            //    newCar.Contact = Carrier["Contact"];
            //    newCar.Mobile = Carrier["Mobile"];
            //    newCar.Tel = Carrier["Tel"];
            //    newCar.Address = Carrier["Address"];
            //    newCar.Save();
            //    return 2;

            //}
            //catch (Exception)
            //{
            //    return 1;
            //    throw;
            //}
            if (Carrier != null)
            {
                Carrier newCar = new Carrier();
                newCar.CarrierName = Carrier["CarrierName"].ToString();
                newCar.Contact = Carrier["Contact"].ToString();
                newCar.Mobile = Carrier["Mobile"].ToString();
                newCar.Tel = Carrier["Tel"].ToString();
                newCar.Address = Carrier["Address"].ToString();
                newCar.Status = 0;
                //newCar.CreateTime = Carrier["CreateTime"];
                newCar.CreateUserId = 1;
                //newCar.UpdateTime = Carrier["UpdateTime"];
                newCar.UpdateUserId = 1;
                newCar.Save("InsertCarrier");
                return 1;
            }
            return 2;
        }
        [HttpPost]
        public int EditCarrier(dynamic Carrier)
        {
            if (Carrier != null)
            {
                Carrier NewCar = new Carrier();
                NewCar.ID = int.Parse(Carrier["ID"].ToString());
                NewCar.CarrierName = Carrier["CarrierName"].ToString();
                NewCar.Contact = Carrier["Contact"].ToString();
                NewCar.Mobile = Carrier["Mobile"].ToString();
                NewCar.Tel = Carrier["Tel"].ToString();
                NewCar.Address = Carrier["Address"].ToString();
                NewCar.CreateUserId = 1;
                NewCar.UpdateUserId = 1;
                NewCar.Update("UpdateCarrier");
                //Loc newLoc = new Loc();
                //newLoc.Id = int.Parse(loc["LocId"].ToString());
                //newLoc.LocCode = loc["LocCode"].ToString();
                //newLoc.LocName = loc["LocName"].ToString();
                //newLoc.ProvinceCode = loc["Province_Code"].ToString();
                //newLoc.CityCode = loc["City_Code"].ToString();
                //newLoc.DistrictCode = loc["District_Code"].ToString();
                //newLoc.LocType = loc["LocType"].ToString();
                //newLoc.UpdateUserid = 1;
                //newLoc.Update("UpdateLoc");
                return 1;
            }
            return 2;
        }

    }
}
