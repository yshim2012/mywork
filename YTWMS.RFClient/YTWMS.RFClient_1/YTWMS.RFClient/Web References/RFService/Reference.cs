﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.5420
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.CompactFramework.Design.Data 2.0.50727.5420 版自动生成。
// 
namespace YTWMS.RFClient.RFService {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    using System.Data;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="RFServiceSoap", Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BaseEntityOfQueue))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BaseEntityOfWareHouse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BaseEntityOfLtUser))]
    public partial class RFService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public RFService() {
            this.Url = "http://192.168.0.54/YTRFServices/RFService.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CheckService", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool CheckService() {
            object[] results = this.Invoke("CheckService", new object[0]);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCheckService(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CheckService", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndCheckService(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetVersion", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetVersion() {
            object[] results = this.Invoke("GetVersion", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetVersion(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetVersion", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetVersion(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllFiles", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetAllFiles() {
            object[] results = this.Invoke("GetAllFiles", new object[0]);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetAllFiles(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetAllFiles", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGetAllFiles(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/DownLoadFile", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] DownLoadFile(string FileName) {
            object[] results = this.Invoke("DownLoadFile", new object[] {
                        FileName});
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginDownLoadFile(string FileName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("DownLoadFile", new object[] {
                        FileName}, callback, asyncState);
        }
        
        /// <remarks/>
        public byte[] EndDownLoadFile(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Login", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public LtUser Login(string Acount, string Password) {
            object[] results = this.Invoke("Login", new object[] {
                        Acount,
                        Password});
            return ((LtUser)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginLogin(string Acount, string Password, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Login", new object[] {
                        Acount,
                        Password}, callback, asyncState);
        }
        
        /// <remarks/>
        public LtUser EndLogin(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((LtUser)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetSortParts", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetSortParts(string sortNo, int warehouseId) {
            object[] results = this.Invoke("GetSortParts", new object[] {
                        sortNo,
                        warehouseId});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetSortParts(string sortNo, int warehouseId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetSortParts", new object[] {
                        sortNo,
                        warehouseId}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataTable EndGetSortParts(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetWareHouseTrcuks", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetWareHouseTrcuks(int warehouseId) {
            object[] results = this.Invoke("GetWareHouseTrcuks", new object[] {
                        warehouseId});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetWareHouseTrcuks(int warehouseId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetWareHouseTrcuks", new object[] {
                        warehouseId}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataTable EndGetWareHouseTrcuks(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendConfirm", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SendConfirm(string sortNo, int userId, int warehouseId, string strDock, string strDriver, string strTruck) {
            object[] results = this.Invoke("SendConfirm", new object[] {
                        sortNo,
                        userId,
                        warehouseId,
                        strDock,
                        strDriver,
                        strTruck});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSendConfirm(string sortNo, int userId, int warehouseId, string strDock, string strDriver, string strTruck, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SendConfirm", new object[] {
                        sortNo,
                        userId,
                        warehouseId,
                        strDock,
                        strDriver,
                        strTruck}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndSendConfirm(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getSendInfo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public SendInfo getSendInfo(SendInfo info) {
            object[] results = this.Invoke("getSendInfo", new object[] {
                        info});
            return ((SendInfo)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetSendInfo(SendInfo info, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getSendInfo", new object[] {
                        info}, callback, asyncState);
        }
        
        /// <remarks/>
        public SendInfo EndgetSendInfo(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((SendInfo)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getQueueInfo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable getQueueInfo(string no, int warehouseId) {
            object[] results = this.Invoke("getQueueInfo", new object[] {
                        no,
                        warehouseId});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetQueueInfo(string no, int warehouseId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getQueueInfo", new object[] {
                        no,
                        warehouseId}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataTable EndgetQueueInfo(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetWareHouseSupplier", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetWareHouseSupplier(int warehouseId) {
            object[] results = this.Invoke("GetWareHouseSupplier", new object[] {
                        warehouseId});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetWareHouseSupplier(int warehouseId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetWareHouseSupplier", new object[] {
                        warehouseId}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataTable EndGetWareHouseSupplier(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetWareHouseProject", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetWareHouseProject(int warehouseId) {
            object[] results = this.Invoke("GetWareHouseProject", new object[] {
                        warehouseId});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetWareHouseProject(int warehouseId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetWareHouseProject", new object[] {
                        warehouseId}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataTable EndGetWareHouseProject(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CheckBoxInfo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CheckBoxInfo(int warehouseId, string strJson) {
            object[] results = this.Invoke("CheckBoxInfo", new object[] {
                        warehouseId,
                        strJson});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCheckBoxInfo(int warehouseId, string strJson, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CheckBoxInfo", new object[] {
                        warehouseId,
                        strJson}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndCheckBoxInfo(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/PackageReceive", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string PackageReceive(string documentNo, int userId, string strJson, int warehouseId) {
            object[] results = this.Invoke("PackageReceive", new object[] {
                        documentNo,
                        userId,
                        strJson,
                        warehouseId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginPackageReceive(string documentNo, int userId, string strJson, int warehouseId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("PackageReceive", new object[] {
                        documentNo,
                        userId,
                        strJson,
                        warehouseId}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndPackageReceive(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/BackSupplier", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string BackSupplier(int supplierId, int userId, int warehouseId, string truckNo, string driver, string tel, string jsonBox) {
            object[] results = this.Invoke("BackSupplier", new object[] {
                        supplierId,
                        userId,
                        warehouseId,
                        truckNo,
                        driver,
                        tel,
                        jsonBox});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginBackSupplier(int supplierId, int userId, int warehouseId, string truckNo, string driver, string tel, string jsonBox, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("BackSupplier", new object[] {
                        supplierId,
                        userId,
                        warehouseId,
                        truckNo,
                        driver,
                        tel,
                        jsonBox}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndBackSupplier(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/PullPackageSend", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string PullPackageSend(string planNO, int userId, int warehouseId, string truckNo, string driver, string tel, string jsonBox) {
            object[] results = this.Invoke("PullPackageSend", new object[] {
                        planNO,
                        userId,
                        warehouseId,
                        truckNo,
                        driver,
                        tel,
                        jsonBox});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginPullPackageSend(string planNO, int userId, int warehouseId, string truckNo, string driver, string tel, string jsonBox, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("PullPackageSend", new object[] {
                        planNO,
                        userId,
                        warehouseId,
                        truckNo,
                        driver,
                        tel,
                        jsonBox}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndPullPackageSend(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getPlanInfo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable getPlanInfo(string no, int warehouseId) {
            object[] results = this.Invoke("getPlanInfo", new object[] {
                        no,
                        warehouseId});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetPlanInfo(string no, int warehouseId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getPlanInfo", new object[] {
                        no,
                        warehouseId}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataTable EndgetPlanInfo(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CheckBoxStock", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CheckBoxStock(string boxNO, string partCode, int warehouseId) {
            object[] results = this.Invoke("CheckBoxStock", new object[] {
                        boxNO,
                        partCode,
                        warehouseId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCheckBoxStock(string boxNO, string partCode, int warehouseId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CheckBoxStock", new object[] {
                        boxNO,
                        partCode,
                        warehouseId}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndCheckBoxStock(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class LtUser : BaseEntityOfLtUser {
        
        /// <remarks/>
        public int ID;
        
        /// <remarks/>
        public string USER_NAME;
        
        /// <remarks/>
        public string USER_ACCOUNT;
        
        /// <remarks/>
        public string USER_PWD;
        
        /// <remarks/>
        public string USER_EMAIL;
        
        /// <remarks/>
        public string USER_TEL;
        
        /// <remarks/>
        public string USER_MOBILE;
        
        /// <remarks/>
        public string USER_ADDR;
        
        /// <remarks/>
        public string IS_DELETE;
        
        /// <remarks/>
        public string IS_LOCK;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> CREATE_TIME;
        
        /// <remarks/>
        public int CREATE_USER;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> LAST_UPDATE;
        
        /// <remarks/>
        public int LAST_UPDATOR;
        
        /// <remarks/>
        public int WAREHOUSE_ID;
        
        /// <remarks/>
        public string WAREHOUSE_CODE;
        
        /// <remarks/>
        public string WAREHOUSE_NAME;
        
        /// <remarks/>
        public WareHouse House;
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class WareHouse : BaseEntityOfWareHouse {
        
        /// <remarks/>
        public int ID;
        
        /// <remarks/>
        public string WAREHOUSE_CODE;
        
        /// <remarks/>
        public string WAREHOUSE_NAME;
        
        /// <remarks/>
        public string CONTACT;
        
        /// <remarks/>
        public string PHONE;
        
        /// <remarks/>
        public string ADDRESS;
        
        /// <remarks/>
        public string E_MAIL;
        
        /// <remarks/>
        public string TYPE;
        
        /// <remarks/>
        public string IS_DISABLE;
        
        /// <remarks/>
        public string REMARK;
        
        /// <remarks/>
        public System.DateTime CREATE_TIME;
        
        /// <remarks/>
        public int CREATE_USER_ID;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> LAST_UPDATE;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> UPDATE_USER_ID;
        
        /// <remarks/>
        public int WAREHOUSE_ID;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(WareHouse))]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class BaseEntityOfWareHouse {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Queue))]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class BaseEntityOfQueue {
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Queue : BaseEntityOfQueue {
        
        /// <remarks/>
        public int ID;
        
        /// <remarks/>
        public int ORDER_BUSINESS_ID;
        
        /// <remarks/>
        public int PART_ID;
        
        /// <remarks/>
        public int SUPPLIER_ID;
        
        /// <remarks/>
        public int PROJECT_ID;
        
        /// <remarks/>
        public int PROJECT_ITEM_ID;
        
        /// <remarks/>
        public decimal PLAN_QUEUE_QTY;
        
        /// <remarks/>
        public string QUEUE_NO;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> QUEUE_TIME;
        
        /// <remarks/>
        public int WAREHOUSE_ID;
        
        /// <remarks/>
        public string IS_DISABLE;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> CREATE_TIME;
        
        /// <remarks/>
        public int CREATE_USER_ID;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> LAST_UPDATE;
        
        /// <remarks/>
        public int UPDATE_USER_ID;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> ORDER_DELIVER_TIME;
        
        /// <remarks/>
        public string WAREHOUSE_NAME;
        
        /// <remarks/>
        public string PART_CODE;
        
        /// <remarks/>
        public string PART_NAME;
        
        /// <remarks/>
        public string ORDER_STATE;
        
        /// <remarks/>
        public string ORDER_NO;
        
        /// <remarks/>
        public string PROJECT_NAME;
        
        /// <remarks/>
        public string PROJECT_ITEM_NAME;
        
        /// <remarks/>
        public int ORDER_SOURCE_ID;
        
        /// <remarks/>
        public int BATCH_PART_ID;
        
        /// <remarks/>
        public int WAREHOUSE_LOCATION_ID;
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class SendInfo {
        
        /// <remarks/>
        public int WarehouseId;
        
        /// <remarks/>
        public string Dock;
        
        /// <remarks/>
        public string Driver;
        
        /// <remarks/>
        public int UserId;
        
        /// <remarks/>
        public Queue[] QueueList;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LtUser))]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class BaseEntityOfLtUser {
    }
}
