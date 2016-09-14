using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using LDV.WMS.LED.localhost;

namespace LDV.WMS.LED
{
    public class ReportService
    {
        private string serverUrl;

        public ReportService(string serverUrl)
        {
            this.serverUrl = serverUrl;
        }

        private LdvRfWebService service()
        {
            LdvRfWebService handler = new LdvRfWebService();
            if (!string.IsNullOrEmpty(serverUrl))
                handler.Url = serverUrl;

            return handler;
        }
        public DataTable getRvcDoc()
        {   
            return service().GetRcvDoc();
        }
        public DataTable GetPickDoc()
        {
            return service().GetPickDoc();
        }

       
    }
}