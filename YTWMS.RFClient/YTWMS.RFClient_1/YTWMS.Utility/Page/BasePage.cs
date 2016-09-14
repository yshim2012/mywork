using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Collections;
using CustomControls;
using DataMapper;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
namespace Utility
{
    /// <summary>
    /// 各个框架页面的基类，封装了一些调用Js的方法
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {
        /// <summary>
        /// 初始化，判断Session是否存在，不存在则跳转到登录页面
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            ClientScript.RegisterStartupScript(this.GetType(),
                Guid.NewGuid().ToString(), "<script>history.forward();</script>");
            //ClientScript.RegisterStartupScript(this.GetType(),
            //Guid.NewGuid().ToString(), "<script>window.onload=function(){ if(top == window){top.window.location.replace('" + GetWebApplicationPath() + "/Default.aspx');}}</script>");
            if (Session["LogonUser"] == null)
            {
                ViewState["SessionError"] = "true";
                Response.Write("<script>top.window.location.replace('" + GetWebApplicationPath() + "/Default.aspx');</script>");
                return;
            }
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        }

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (ViewState["SessionError"] != null && ViewState["SessionError"].Equals("true"))
            {
                return;
            }
            base.OnLoad(e);
            if (!Page.IsPostBack)
            {
                if (Page.Request["modulecode"] != null &&
                    Page.Request["modulecode"] != string.Empty)
                {
                    ViewState["modulecode"] = Page.Request["modulecode"];
                }
                SetTextBoxMaxLength();
            }
        }

        private void SetTextBoxMaxLength()
        {
            string pageName = GetPageName();
            IList<TextBoxProperty> textboxList = TextBoxVerifyConfig.Instance.GetTextBoxList(pageName);
            MyTextBox mytextbox;
            string textboxid;
            int maxlength;
            foreach (TextBoxProperty textboxproperty in textboxList)
            {
                textboxid = textboxproperty.TextBoxId;
                maxlength = textboxproperty.MaxLength;
                mytextbox = Page.FindControl(textboxid) as MyTextBox;
                if (mytextbox != null)
                    mytextbox.MaxLength = maxlength;
            }
        }

        /// <summary>
        /// 校验页面中文本框控件的值是否正确
        /// 不正确则显示错误信息提示用户
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckTextBoxValue()
        {
            string pageName = GetPageName();
            IList<TextBoxProperty> textboxList = TextBoxVerifyConfig.Instance.GetTextBoxList(pageName);
            MyTextBox mytextbox;
            string textboxid, lengthmessageid, typepattern,
                typemessageid, requiredmessageid;
            bool required;
            foreach (TextBoxProperty textboxproperty in textboxList)
            {
                textboxid = textboxproperty.TextBoxId;
                required = textboxproperty.Required;
                requiredmessageid = textboxproperty.RequiredMessageId;
                mytextbox = Page.FindControl(textboxid) as MyTextBox;

                if (mytextbox == null)
                    continue;

                //如果不是必填，并且TextBox值为空，忽略
                if (!required && mytextbox.Text.Trim() == string.Empty)
                    continue;

                //如果是必填，并且TextBox值为空，显示错误信息
                if (required && mytextbox.Text.Trim() == string.Empty)
                {
                    ShowMessageByKey(requiredmessageid);
                    mytextbox.Focus();
                    return false;
                }

                lengthmessageid = textboxproperty.LengthMessageId;
                //值长度超出MexLength，显示错误信息
                if (!mytextbox.IsTextLengthValid())
                {
                    ShowMessageByKey(lengthmessageid);
                    mytextbox.Focus();
                    return false;
                }

                typepattern = textboxproperty.TypePattern;
                //类型校验的表达式存在，并且类型校验不通过，显示错误信息
                if (typepattern != string.Empty && !RegExpLib.IsMatch(typepattern, mytextbox.Text))
                {
                    typemessageid = textboxproperty.TypeMessageId;
                    ShowMessageByKey(typemessageid);
                    mytextbox.Focus();
                    return false;
                }
            }
            return true;
        }

        private string GetPageName()
        {
            string path = Page.Request.Path;
            string[] pathArray = path.Split('/');
            string pageName = pathArray[pathArray.Length - 1];
            return pageName.Substring(0, pageName.Length - 5);
        }

        /// <summary>
        /// 根据传入的Key从MessagePool中取出对应的value，
        /// 并且用js的alert显示message提示信息
        /// </summary>
        /// <param name="key"></param>
        public void ShowMessageByKey(string key)
        {
            if (key == null || key == string.Empty)
                return;
            string message = MessagePool.Instance.GetMessage(key);
            ClientScript.RegisterStartupScript(this.GetType(),
                Guid.NewGuid().ToString(),
                "<script>alert('" + message + "');</script>");
        }

        /// <summary>
        /// 根据传入的Key从MessagePool中取出对应的value，
        /// 并且用js的alert显示message提示信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="messageParams"></param>
        public void ShowMessageByKey(string key, string[] messageParams)
        {
            if (key == null || key == string.Empty)
                return;
            string message = MessagePool.Instance.GetMessage(key, messageParams);
            ClientScript.RegisterStartupScript(this.GetType(),
                Guid.NewGuid().ToString(),
                "<script>alert('" + message + "');</script>");
        }

        /// <summary>
        /// 用Js的alert显示一个提示信息
        /// </summary>
        /// <param name="message"></param>
        protected void ShowMessage(string message)
        {
            if (message == null || message == string.Empty)
                return;

            ClientScript.RegisterStartupScript(this.GetType(),
                Guid.NewGuid().ToString(),
                "<script>alert('" + message + "');</script>");
        }

        /// <summary>
        /// 根据传入值，选中符合条件的下拉框值
        /// </summary>
        /// <param name="dropdownlist"></param>
        /// <param name="itemvalue"></param>
        protected void DownDownListSelected(DropDownList dropdownlist, string itemvalue)
        {
            for (int i = 0; i < dropdownlist.Items.Count; i++)
            {
                if (dropdownlist.Items[i].Value == itemvalue)
                {
                    dropdownlist.SelectedIndex = i;
                    break;
                }
            }
        }
        /// <summary>
        /// 跳转页面
        /// </summary>
        /// <param name="url"></param>
        protected virtual void Redirect(string url)
        {
            if (url == null || url == string.Empty)
                return;

            //Response.Redirect(url);
            ClientScript.RegisterStartupScript(this.GetType(),
                Guid.NewGuid().ToString(),
                "<script>window.location.href='" + url + "';</script>");
        }

        /// <summary>
        /// 跳转到登录页面
        /// </summary>
        protected virtual void RedirectToLoginForm()
        {
            Response.Write("<script>top.window.location.replace('" + GetWebApplicationPath() + "/Default.aspx');</script>");
        }

        /// <summary>
        /// 跳转到错误页面
        /// </summary>
        protected virtual void RedirectToErrorForm()
        {
            Response.Write("<script>top.window.location.replace('" + GetWebApplicationPath() + "/Views/ErrorPage.aspx');</script>");
        }

        /// <summary>
        /// 获得应用程序虚拟目录路径
        /// </summary>
        /// <returns></returns>
        protected string GetWebApplicationPath()
        {
            if (Request.ApplicationPath != "/")
            {
                return Request.ApplicationPath;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        public virtual void Print()
        {
            string scriptValue = " this.print();" + "window.close();";
            //string scriptValue = "window.print();";
            //string scriptValue = " this.print();" + "window.close();";

            ClientScript.RegisterStartupScript(this.GetType(),
               Guid.NewGuid().ToString(),
               "<script>" + scriptValue + "</script>");
        }

        /// <summary>
        /// 打印
        /// </summary>
        public virtual void PrintPlans()
        {
            string scriptValue = " document.all.WebBrowser.ExecWB(6,6);" + "window.close();";
            //string scriptValue = "window.print();";
            //string scriptValue = " this.print();" + "window.close();";

            ClientScript.RegisterStartupScript(this.GetType(),
               Guid.NewGuid().ToString(),
               "<script>" + scriptValue + "</script>");
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="dotName"></param>
        public virtual void Print(string dotName)
        {
            string scriptValue =
                @"try
                  {
                    var WordApp=new ActiveXObject(""Word.Application"");
                    WordApp.Application.Visible=false;
                    WordApp.Application.DisplayAlerts=0;
                    var Doc=WordApp.Documents.Open(""" + dotName + @""");
                    Doc.PrintOut();
                    WordApp.Quit();
                    WordApp=null;
                 }
                 catch(e)
                 {
                    alert(e.message);
                 }
                 finally 
                 {
                    if(WordApp!=undefined)
                    {
                        WordApp.Quit();
                        WordApp=null;
                    }
                 }";

            ClientScript.RegisterStartupScript(this.GetType(),
               Guid.NewGuid().ToString(),
               "<script>" + scriptValue + "</script>");
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="dotName"></param>
        /// <param name="print"></param>
        public virtual void Print(string dotName, string print)
        {
            string scriptValue =
                "try{"
                + "var WordApp=new ActiveXObject(\"Word.Application\");"
                + "WordApp.Application.Visible=false;"
                + "WordApp.Application.DisplayAlerts=0;"
                + "var Doc=WordApp.Documents.Open(\"" + dotName + "\");"
                + "	Doc.PrintOut();"
                + "	WordApp.Quit();"
                + "	WordApp=null;"
                + "} catch(e){alert(e.message);} finally {if(WordApp!=undefined){WordApp.Quit();WordApp=null;}}";

            ClientScript.RegisterStartupScript(this.GetType(),
               Guid.NewGuid().ToString(),
               "<script>" + scriptValue + "</script>");
        }

        #region 对象赋值给控件

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="value"></param>
        protected virtual void SetControlVale(TextBox textbox, Nullable<Int32> value)
        {
            if (value.HasValue)
                textbox.Text = value.Value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="value"></param>
        protected virtual void SetControlVale(CustomControls.ModalTextBox textbox, Nullable<Int32> value)
        {
            if (value.HasValue)
                textbox.Value = value.Value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="value"></param>
        protected virtual void SetControlVale(CustomControls.ModalTextBox textbox, Nullable<Double> value)
        {
            if (value.HasValue)
                textbox.Value = value.Value.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="value"></param>
        protected virtual void SetControlVale(CustomControls.ModalTextBox textbox, string value)
        {
            if (value != null)
                textbox.Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="value"></param>
        protected virtual void SetControlVale(TextBox textbox, Nullable<Decimal> value)
        {
            if (value.HasValue)
                textbox.Text = value.Value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="value"></param>
        protected virtual void SetControlVale(TextBox textbox, Nullable<DateTime> value)
        {
            if (value.HasValue)
                textbox.Text = value.Value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="value"></param>
        /// <param name="dateFormate"></param>
        protected virtual void SetControlVale(TextBox textbox, Nullable<DateTime> value, string dateFormate)
        {
            if (value.HasValue)
                textbox.Text = value.Value.ToString(dateFormate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="value"></param>
        protected virtual void SetControlVale(TextBox textbox, string value)
        {
            if (value != null)
                textbox.Text = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="value"></param>
        protected virtual void SetControlAttribute(TextBox textbox, string value)
        {
            if (value != null)
                textbox.Attributes["value"] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        protected virtual void SetControlVale(CustomControls.ModalTextBox textbox, string value1, Nullable<Int32> value2)
        {
            if (value1 != null && value2.HasValue)
            {
                textbox.Text = value1;
                textbox.Value = value2.Value.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        protected virtual void SetControlVale(CustomControls.ModalTextBox textbox, string value1, string value2)
        {
            if (value1 != null && value2 != null)
            {
                textbox.Text = value1;
                textbox.Value = value2;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dropdownlist"></param>
        /// <param name="value"></param>
        protected virtual void SetControlVale(DropDownList dropdownlist, string value)
        {
            if (value != null)
            {
                DownDownListSelected(dropdownlist, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dropdownlist"></param>
        /// <param name="value"></param>
        protected virtual void SetControlVale(DropDownList dropdownlist, Nullable<Int32> value)
        {
            if (value.HasValue)
            {
                DownDownListSelected(dropdownlist, value.ToString());
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buttonId"></param>
        protected virtual void ButtonClick(string buttonId)
        {
            string scriptValue = "<script>document.getElementById('" + buttonId + "').click();</script>";
            ClientScript.RegisterStartupScript(this.GetType(),
                Guid.NewGuid().ToString(), scriptValue);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public virtual void Open(string url)
        {
            ClientScript.RegisterStartupScript(this.GetType(),
               Guid.NewGuid().ToString(),
               "<script>var win = window.open('" + url + "','dialog','width=800,height=500,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=no,status=no',false);win.focus();</script>");
        }

        /// <summary>
        /// 
        /// </summary>
        protected void PlaySuccessSound()
        {
            Response.Write("<bgsound src='../../Resource/Sound/success.wav' loop = '1'>");
        }

        /// <summary>
        /// 
        /// </summary>
        protected void PlayFailureSound()
        {
            Response.Write("<bgsound src='../../Resource/Sound/failure.wav' loop = '1'>");
        }

        /// <summary>
        /// 弹出模式窗口
        /// </summary>
        /// <param name="url"></param>
        protected void showModalDialog(string url)
        {
            ClientScript.RegisterStartupScript(this.GetType(),
                Guid.NewGuid().ToString(),
                "<script> window.showModalDialog('" + url + "',self,'dialogWidth=800px,dialogHeight=600px');</script>");
        }


        /// <summary>
        /// 邦定当前商品名称
        /// </summary>
        /// <param name="ddlProductCode"></param>
        protected virtual void BindProduct(DropDownList ddlProductCode)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            paramHashtable.Add("IS_LEAST_UNIT", EnumParser.GetEnumFiledValue(Utility.IsLeastUnit.是).ToString());
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectProduct", paramHashtable);

            string procuctName = "";
            foreach(DataRow row in table.Rows)
            {
                procuctName = row["PRODUCT_NAME"].ToString() + "  " +
                    EnumParser.GetEnumFiledName(typeof(ProductUnit), row["UNIT"].ToString()) + "(" + row["QUANTITY"].ToString() + ")"; 
                ddlProductCode.Items.Add(new ListItem(procuctName, row["PRODUCT_CODE"].ToString()));
            }
        }

        /// <summary>
        /// 邦定当前商品名称
        /// </summary>
        /// <param name="ddlProductCode"></param>
        /// <param name="strText"></param>
        /// <param name="strValue"></param>
        protected virtual void BindProduct(DropDownList ddlProductCode, string strText, string strValue)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            paramHashtable.Add("IS_LEAST_UNIT", EnumParser.GetEnumFiledValue(Utility.IsLeastUnit.是).ToString());
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectProduct", paramHashtable);

            string procuctName = "";
            foreach (DataRow row in table.Rows)
            {
                procuctName = row["PRODUCT_NAME"].ToString() + "  " +
                    EnumParser.GetEnumFiledName(typeof(ProductUnit), row["UNIT"].ToString()) + "(" + row["QUANTITY"].ToString() + ")";
                ddlProductCode.Items.Add(new ListItem(procuctName, row["PRODUCT_CODE"].ToString()));
            }

            ddlProductCode.Items.Insert(0, new ListItem(strText, strValue));
        }

        /// <summary>
        /// 邦定当前商品名称
        /// </summary>
        /// <param name="ddlProductCode"></param>
        protected virtual void BindProductCode(DropDownList ddlProductCode)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectForPageing", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProductCode.Items.Add(new ListItem(row["PRODUCT_NAME"].ToString(), row["PRODUCT_CODE"].ToString()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddlProductCode"></param>
        /// <param name="strText"></param>
        /// <param name="strValue"></param>
        protected virtual void BindProductCode(DropDownList ddlProductCode, string strText, string strValue)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectForPageing", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProductCode.Items.Add(new ListItem(row["PRODUCT_NAME"].ToString(), row["PRODUCT_CODE"].ToString()));
            }
            ddlProductCode.Items.Insert(0, new ListItem(strText, strValue));
        }


        /// <summary>
        /// 邦定当前商品名称
        /// </summary>
        /// <param name="ddlProductCode"></param>
        protected virtual void BindInstrumentProductCode(DropDownList ddlProductCode)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            paramHashtable.Add("TYPE", EnumParser.GetEnumFiledValue(Utility.ProductType.仪器).ToString());
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectForPageing", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProductCode.Items.Add(new ListItem(row["PRODUCT_NAME"].ToString(), row["PRODUCT_CODE"].ToString()));
            }
        }

        /// <summary>
        /// 邦定当前商品名称
        /// </summary>
        /// <param name="ddlProductCode"></param>
        /// <param name="strText"></param>
        /// <param name="strValue"></param>
        protected virtual void BindInstrumentProductCode(DropDownList ddlProductCode, string strText, string strValue)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            paramHashtable.Add("TYPE", EnumParser.GetEnumFiledValue(Utility.ProductType.仪器).ToString());
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectForPageing", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProductCode.Items.Add(new ListItem(row["PRODUCT_NAME"].ToString(), row["PRODUCT_CODE"].ToString()));
            }

            ddlProductCode.Items.Insert(0, new ListItem(strText, strValue));
        }

        /// <summary>
        /// 邦定当前商品名称
        /// </summary>
        /// <param name="ddlProductCode"></param>
        protected virtual void BindInstrumentPaperProductCode(DropDownList ddlProductCode)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            paramHashtable.Add("TYPE", new string[] { EnumParser.GetEnumFiledValue(Utility.ProductType.仪器).ToString() ,
                             EnumParser.GetEnumFiledValue(Utility.ProductType.试纸).ToString()});
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectInstrumentPaper", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProductCode.Items.Add(new ListItem(row["PRODUCT_NAME"].ToString(), row["PRODUCT_CODE"].ToString()));
            }
        }

        /// <summary>
        /// 邦定当前商品名称
        /// </summary>
        /// <param name="ddlProductCode"></param>
        /// <param name="strText"></param>
        /// <param name="strValue"></param>
        protected virtual void BindInstrumentPaperProductCode(DropDownList ddlProductCode, string strText, string strValue)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            paramHashtable.Add("TYPE", new string[] { EnumParser.GetEnumFiledValue(Utility.ProductType.仪器).ToString() ,
                             EnumParser.GetEnumFiledValue(Utility.ProductType.试纸).ToString()});
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectInstrumentPaper", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProductCode.Items.Add(new ListItem(row["PRODUCT_NAME"].ToString(), row["PRODUCT_CODE"].ToString()));
            }

            ddlProductCode.Items.Insert(0, new ListItem(strText, strValue));
        }

        /// <summary>
        /// 邦定当前商品名称
        /// </summary>
        /// <param name="ddlProductCode"></param>
        protected virtual void BindProductCode(DropDownList ddlProductCode, string[] type, string strText, string strValue)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            paramHashtable.Add("TYPE", type);
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectInstrumentPaper", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProductCode.Items.Add(new ListItem(row["PRODUCT_NAME"].ToString(), row["PRODUCT_CODE"].ToString()));
            }
            ddlProductCode.Items.Insert(0, new ListItem(strText, strValue));
        }

        /// <summary>
        /// 邦定当前商品名称
        /// </summary>
        /// <param name="ddlProductCode"></param>
        protected virtual void BindProductCode(DropDownList ddlProductCode, string[] type)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            paramHashtable.Add("TYPE", type);
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectInstrumentPaper", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProductCode.Items.Add(new ListItem(row["PRODUCT_NAME"].ToString(), row["PRODUCT_CODE"].ToString()));
            }
        }

        /// <summary>
        /// 邦定更换类型更换原因对应关系
        /// </summary>
        /// <param name="ddlChangeCase"></param>
        protected virtual void BindTypeOfCause(DropDownList ddlChangeCase,string changeType)
        {
            if (changeType != "")
            {
                IDictionary paramHashtable = new Hashtable();
                paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
                paramHashtable.Add("CHANGE_TYPE", changeType);
                DataTable table = JjmcBaseinfoTypeOfCause.QueryDataTable("SelectForPageing", paramHashtable);

                foreach (DataRow row in table.Rows)
                {

                    ddlChangeCase.Items.Add(new ListItem(row["RECEIVING_CAUSE_NAME"].ToString(), row["RECEIVING_DEFINE_CODE"].ToString()));
                }
            }

            ddlChangeCase.Items.Insert(0, new ListItem("----------", ""));
        }

       /// <summary>
        /// 邦定更换类型更换原因对应关系
       /// </summary>
       /// <param name="ddlChangeCase"></param>
       /// <param name="changeType"></param>
       /// <param name="strText"></param>
       /// <param name="strValue"></param>
        protected virtual void BindTypeOfCause(DropDownList ddlChangeCase, string changeType, string strText, string strValue)
        {
            if (changeType != "")
            {
                IDictionary paramHashtable = new Hashtable();
                paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
                paramHashtable.Add("CHANGE_TYPE", changeType);
                DataTable table = JjmcBaseinfoTypeOfCause.QueryDataTable("SelectForPageing", paramHashtable);

                foreach (DataRow row in table.Rows)
                {

                    ddlChangeCase.Items.Add(new ListItem(row["RECEIVING_CAUSE_NAME"].ToString(), row["RECEIVING_DEFINE_CODE"].ToString()));
                }
            }

            ddlChangeCase.Items.Insert(0, new ListItem(strText, strValue));
        }



        /// <summary>
        /// 邦定收货原因
        /// </summary>
        /// <param name="ddlChangeCase"></param>
        protected virtual void BindReceivingCase(DropDownList ddlChangeCase)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            DataTable table = JjmcBaseinfoReceivingCause.QueryDataTable("SelectForPageing", paramHashtable);

            foreach (DataRow row in table.Rows)
            {

                ddlChangeCase.Items.Add(new ListItem(row["RECEIVING_CAUSE_NAME"].ToString(), row["RECEIVING_DEFINE_CODE"].ToString()));
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddlChangeCase"></param>
        /// <param name="strText"></param>
        /// <param name="strValue"></param>
        protected virtual void BindReceivingCase(DropDownList ddlChangeCase, string strText, string strValue)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            DataTable table = JjmcBaseinfoReceivingCause.QueryDataTable("SelectForPageing", paramHashtable);

            foreach (DataRow row in table.Rows)
            {

                ddlChangeCase.Items.Add(new ListItem(row["RECEIVING_CAUSE_NAME"].ToString(), row["RECEIVING_DEFINE_CODE"].ToString()));
            }
            ddlChangeCase.Items.Insert(0, new ListItem(strText, strValue));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddlChangeCase"></param>
        /// <param name="strText"></param>
        /// <param name="strValue"></param>
        protected virtual void BindReceivingCaseId(DropDownList ddlChangeCase, string strText, string strValue)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            DataTable table = JjmcBaseinfoReceivingCause.QueryDataTable("SelectForPageing", paramHashtable);

            foreach (DataRow row in table.Rows)
            {

                ddlChangeCase.Items.Add(new ListItem(row["RECEIVING_CAUSE_NAME"].ToString(), row["ID"].ToString()));
            }
            ddlChangeCase.Items.Insert(0, new ListItem(strText, strValue));
        }


        /// <summary>
        /// 邦定换货原因
        /// </summary>
        /// <param name="ddlChangeCase"></param>
        protected virtual void BindChangeCase(DropDownList ddlChangeCase)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            DataTable table = JjmcBaseinfoChangeCause.QueryDataTable("SelectForPageing", paramHashtable);

            foreach (DataRow row in table.Rows)
            {

                ddlChangeCase.Items.Add(new ListItem(row["CHANGE_CAUSE_NAME"].ToString(), row["CHANGE_DEFINE_CODE"].ToString()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddlChangeCase"></param>
        /// <param name="strText"></param>
        /// <param name="strValue"></param>
        protected virtual void BindChangeCase(DropDownList ddlChangeCase, string strText, string strValue)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            DataTable table = JjmcBaseinfoChangeCause.QueryDataTable("SelectForPageing", paramHashtable);

            foreach (DataRow row in table.Rows)
            {

                ddlChangeCase.Items.Add(new ListItem(row["CHANGE_CAUSE_NAME"].ToString(), row["CHANGE_DEFINE_CODE"].ToString()));
            }
            ddlChangeCase.Items.Insert(0, new ListItem(strText, strValue));
        }

        /// <summary>
        /// 邦定省名称
        /// </summary>
        /// <param name="ddlProvinceName"></param>
        protected virtual void BindProvinceName(DropDownList ddlProvinceName)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            DataTable table = JjmcBaseinfoCity.QueryDataTable("SelectProvinceName", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProvinceName.Items.Add(new ListItem(row["PROVINCE_NAME"].ToString(), row["PROVINCE_NAME"].ToString()));
            }
        }

        /// <summary>
        /// 邦定省名称
        /// </summary>
        /// <param name="ddlProvinceName"></param>
        protected virtual void BindProvinceName(DropDownList ddlProvinceName, string strText, string strValue)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            DataTable table = JjmcBaseinfoCity.QueryDataTable("SelectProvinceName", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProvinceName.Items.Add(new ListItem(row["PROVINCE_NAME"].ToString(), row["PROVINCE_NAME"].ToString()));
            }
            ddlProvinceName.Items.Insert(0, new ListItem(strText, strValue));
        }

        /// <summary>
        /// 邦定市名称
        /// </summary>
        /// <param name="ddlCityName"></param>
        /// <param name="provinceName"></param>
        protected virtual void BindCityName(DropDownList ddlCityName, string provinceName)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            paramHashtable.Add("PROVINCE_NAME", provinceName);
            DataTable table = JjmcBaseinfoCity.QueryDataTable("SelectCityNameByProvince", paramHashtable);
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {

                    ddlCityName.Items.Add(new ListItem(row["CITY_NAME"].ToString(), row["CITY_NAME"].ToString()));
                }
            }
        }

        /// <summary>
        /// 邦定市名称
        /// </summary>
        /// <param name="ddlCityName"></param>
        /// <param name="provinceName"></param>
        protected virtual void BindCityName(DropDownList ddlCityName, string provinceName, string strText, string strValue)
        {
            if (provinceName != "")
            {
                IDictionary paramHashtable = new Hashtable();
                paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
                paramHashtable.Add("PROVINCE_NAME", provinceName);
                DataTable table = JjmcBaseinfoCity.QueryDataTable("SelectCityNameByProvince", paramHashtable);
                if (table != null)
                {
                    foreach (DataRow row in table.Rows)
                    {

                        ddlCityName.Items.Add(new ListItem(row["CITY_NAME"].ToString(), row["CITY_NAME"].ToString()));
                    }
                }
            }
            ddlCityName.Items.Insert(0, new ListItem(strText, strValue));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        protected virtual void DeleteDropDownList(DropDownList ddl)
        {
            for (int i = ddl.Items.Count - 1; i >=0 ; i--)
            {
                ddl.Items.RemoveAt(i);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="name"></param>
        protected virtual bool CheckDropDownList(DropDownList ddl, string name)
        {
            foreach (ListItem item in ddl.Items)
            {
                if (name == item.Text)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual string DropDownListName(DropDownList ddl, string value)
        {
            foreach (ListItem item in ddl.Items)
            {
                if (value == item.Value)
                {
                    return item.Text;
                }
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="name"></param>
        protected virtual void DropDownListChecked(DropDownList ddl, string name)
        {
            foreach (ListItem item in ddl.Items)
            {
                if (name == item.Text)
                    item.Selected = true;
                else
                    item.Selected = false;
            }
        }



        #region 绑定当前用户属仓库
        /// <summary>
        /// 绑定当前用户属仓库
        /// </summary>
        /// <param name="dropDownList"></param>
        protected virtual void BindWarehouse(DropDownList dropDownList)
        {
            if (Session["LogonUser"] == null)
                RedirectToLoginForm();
            LtUser logonUser = (LtUser)Session["LogonUser"];
            IDictionary queryParams = new Hashtable();
            queryParams.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(IsEnabled.启用));
            queryParams.Add("USER_ID", logonUser.ID);
            IList<JjmcDimWarehouse> warehouseList = JjmcDimWarehouse.QueryList("SelectWarehouseList", queryParams);
            if (warehouseList.Count == 0)
                RedirectToLoginForm();
            dropDownList.DataSource = warehouseList;
            dropDownList.DataTextField = "WAREHOUSE_NAME";
            dropDownList.DataValueField = "WAREHOUSE_CODE";
            dropDownList.DataBind();
            dropDownList.Items.Insert(0,"全部");
            dropDownList.Items[0].Value = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual string[] GetUserWarehouseList()
        {
            if (Session["LogonUser"] == null)
                RedirectToLoginForm();
            LtUser logonUser = (LtUser)Session["LogonUser"];
            IDictionary queryParams = new Hashtable();
            queryParams.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(IsEnabled.启用));
            queryParams.Add("USER_ID", logonUser.ID);
            IList<JjmcDimWarehouse> warehouseList = JjmcDimWarehouse.QueryList("SelectWarehouseList", queryParams);
            string[] str = new string[warehouseList.Count];
            for (int i = 0; i < warehouseList.Count; i++)
            {
                str[i] = warehouseList[i].WAREHOUSE_CODE;
            }
            return str;
        }

        /// <summary>
        /// 绑定当前用户属仓库
        /// </summary>
        /// <param name="dropDownList"></param>
        protected virtual void BindAllWarehouse(DropDownList dropDownList)
        {

            IDictionary queryParams = new Hashtable();
            queryParams.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(IsEnabled.启用));
            IList<JjmcDimWarehouse> warehouseList = JjmcDimWarehouse.QueryList("SelectByParam", queryParams);

            dropDownList.DataSource = warehouseList;
            dropDownList.DataTextField = "WAREHOUSE_NAME";
            dropDownList.DataValueField = "WAREHOUSE_CODE";
            dropDownList.DataBind();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        protected virtual string MoneyFormat(string money)
        {
            if (money == "0" || money=="&nbsp;")
                return "0";
            else
                return (decimal.Parse(money)).ToString("#,#", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        protected virtual string MoneyFormatToString(string money)
        {
            if (money == "0" || money == "&nbsp;")
                return "0";
            else
            {
                string[] moenys = money.Split(',');
                string str = "";
                foreach (string s in moenys)
                {
                    str += s;
                }

                return str;
            }
                
        }

        /// <summary>
        /// 系统管理员
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckUserIsAdmin()
        {
            LtUser logonUser = (LtUser)Session["LogonUser"];
            if (EnumParser.GetEnumFiledValue(Utility.RoleType.系统管理员).ToString() == logonUser.ROLE_TYPE)
                return true;
            else
                return false;
        }
        



        #region 
        /// <summary>
        /// 下载Excel
        /// </summary>
        /// <param name="table"></param>
        /// <param name="exportName"></param>
        /// <param name="titleName"></param>
        /// <param name="columnName"></param>
        protected void DownloadExcel(DataTable table, string exportName, string[] titleName, string[] columnName)
        {

            //if (table.Rows.Count > 20000)
            //{
            //    throw new Exception(MessagePool.Instance.GetMessage("ReportDataLong"));
            //}

            //Response.Clear();

            //Response.Buffer = false;

            //Response.Charset = "GB2312";

            //Response.AppendHeader("Content-Disposition", "attachment;filename=Export.xls");

            //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312"); Response.ContentType = "application/ms-excel"; this.EnableViewState = false;

            //Stream stream = Response.OutputStream;

            

            //Response.End();


            string filename = GetDownloadExcelFileName("xlsx");
            Stream stream = new FileStream(filename, FileMode.Create);
            ExcelExportOprator.Export(table, stream, exportName, titleName, columnName);
            stream.Close();

            FileDownLoadDel(filename);

        }
        #endregion

        #region
        /// <summary>
        /// 下载Excel含有时分秒
        /// </summary>
        /// <param name="table"></param>
        /// <param name="exportName"></param>
        /// <param name="titleName"></param>
        /// <param name="columnName"></param>
        protected void DownloadExcel(DataTable table, string exportName, string[] titleName, string[] columnName, bool operDate)
        {
            string filename = GetDownloadExcelFileName("xlsx");
            Stream stream = new FileStream(filename, FileMode.Create);
            ExcelExportOprator.Export(table, stream, exportName, titleName, columnName, operDate);
            stream.Close();
            FileDownLoadDel(filename);

        }
        #endregion

        #region 下载Excel

        /// <summary>
        /// 文件下载并删除
        /// </summary>
        /// <param name="result"></param>
        protected void FileDownLoadDel(string fullFilename)
        {
            System.IO.Stream iStream = null;
            // Buffer to read 10K bytes in chunk:
            byte[] buffer = new Byte[10000];

            // Length of the file:
            int length;

            // Total bytes to read:
            long dataToRead;

            // Identify the file to download including its path.
            string filepath = fullFilename;

            // Identify the file name.
            string filename = System.IO.Path.GetFileName(filepath);

            try
            {
                // Open the file.
                iStream = new System.IO.FileStream(filepath, System.IO.FileMode.Open,
                            System.IO.FileAccess.Read, System.IO.FileShare.Read);


                // Total bytes to read:
                dataToRead = iStream.Length;

                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);

                // Read the bytes.
                while (dataToRead > 0)
                {
                    // Verify that the client is connected.
                    if (Response.IsClientConnected)
                    {
                        // Read the data in buffer.
                        length = iStream.Read(buffer, 0, 10000);

                        // Write the data to the current output stream.
                        Response.OutputStream.Write(buffer, 0, length);

                        // Flush the data to the HTML output.
                        Response.Flush();

                        buffer = new Byte[10000];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        //prevent infinite loop if user disconnects
                        dataToRead = -1;
                        Response.Clear();
                    }
                }
                Response.End(); //没有这句会将该页面刷新后的内容追加写入文件中。
            }
            catch (Exception ex)
            {
                // Trap the error, if any.
                //Response.Write("Error : " + ex.Message);
                //base.WriteLog("资料", "下载资料:" + ex.Message + "!", LogType.Error, this.GetType().ToString());

            }
            finally
            {
                if (iStream != null)
                {
                    //Close the file.
                    iStream.Close();
                }
                File.Delete(fullFilename);
            }
        }


        protected string GetDownloadExcelFileName(string file)
        {
            string filename = this.Server.MapPath("");
            return filename.Substring(0, filename.IndexOf("Views")) + "Resource\\WordModel\\Export" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + "." + file;
        }

        /// <summary>
        /// 下载Excel
        /// </summary>
        /// <param name="table"></param>
        /// <param name="type"></param>
        /// <param name="exportName"></param>
        protected void DownloadExcel(DataTable table, string type,string exportName)
        {

            //if (table.Rows.Count > 20000)
            //{
            //    throw new Exception(MessagePool.Instance.GetMessage("ReportDataLong"));
            //}
            //Response.Clear();

            //Response.Buffer = false;

            //Response.Charset = "GB2312";

            //Response.AppendHeader("Content-Disposition", "attachment;filename=Export.xlsx");


            //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            //Response.ContentType = "application/ms-excel"; 
            //this.EnableViewState = false;

            //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312"); Response.ContentType = "application/ms-excel"; this.EnableViewState = false;


            //Stream stream = Response.OutputStream;

            //ExcelExportOprator.DownloadExcel(table,stream,type,exportName);

            //Response.End();


            string filename = GetDownloadExcelFileName("xlsx");
            Stream stream = new FileStream(filename, FileMode.Create);
            ExcelExportOprator.DownloadExcel(table, stream, type, exportName);
            stream.Close();

            FileDownLoadDel(filename);

        }

        protected void DownloadExcelDispatchDetail(DataTable table, DataTable tableSN, string type, string exportName,string exportName02)
        {
            string filename = GetDownloadExcelFileName("xlsx");
            Stream stream = new FileStream(filename, FileMode.Create);
            ExcelExportOprator.DownloadExcel02(table, tableSN, stream, type, exportName, exportName02);
            stream.Close();

            FileDownLoadDel(filename);

        }

        protected void DownloadExcel(DataTable table1, DataTable table2, DataTable table3,string exportName1, string exportName2, string exportName3)
        {
            //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            //Response.ContentType = "application/ms-excel";
            //this.EnableViewState = false;

            string filename = GetDownloadExcelFileName("xlsx");
            Stream stream = new FileStream(filename, FileMode.Create);
            ExcelExportOprator.ExportSheet(table1,table2,table3, stream,exportName1,exportName2,exportName3);
            stream.Close();

            FileDownLoadDel(filename);
        }
        #endregion
        #region 下载VBAExcel
        /// <summary>
        /// 下载VBAExcel
        /// </summary>
        /// <param name="table"></param>
        /// <param name="excelName"></param>
        /// <param name="exportName"></param>
        /// <param name="titleName"></param>
        /// <param name="columnName"></param>
        protected void DownloadVBAExcel(DataTable table, string excelName,string exportName, string[] titleName, string[] columnName)
        {

            string modelFilename = this.Server.MapPath("");
            modelFilename = modelFilename.Substring(0, modelFilename.Length - 17);
            modelFilename = modelFilename + "\\resource\\wordmodel\\" + excelName + ".xlsx";

            string filename = GetDownloadExcelFileName("xlsx");
            Stream stream = new FileStream(filename, FileMode.Create);
            ExcelExportOprator.ExportVBA(table, stream, modelFilename, exportName, titleName, columnName);
            stream.Close();

            FileDownLoadDel(filename);


        }

        /// <summary>
        /// 下载VBAExcel
        /// </summary>
        /// <param name="table"></param>
        /// <param name="excelName"></param>
        /// <param name="exportName"></param>
        /// <param name="titleName"></param>
        /// <param name="columnName"></param>
        protected void DownloadVBAExcel(DataTable table, string excelName, string exportName, string[] columnName)
        {

            //if (table.Rows.Count > 20000)
            //{
            //    throw new Exception(MessagePool.Instance.GetMessage("ReportDataLong"));
            //}

            //Response.Clear();

            //Response.Buffer = false;

            //Response.Charset = "GB2312";

            //Response.AppendHeader("Content-Disposition", "attachment;filename=Export.xls");

            //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312"); Response.ContentType = "application/ms-excel"; this.EnableViewState = false;

            //Stream stream = Response.OutputStream;

            //string filename = this.Server.MapPath("");
            //filename = filename.Substring(0, filename.Length - 17);
            //filename = filename + "\\resource\\wordmodel\\" + excelName + ".xls";

            //ExcelExportOprator.ExportVBA(table, stream, filename, exportName, columnName);

            //Response.End();


            string modelFilename = this.Server.MapPath("");
            modelFilename = modelFilename.Substring(0, modelFilename.Length - 17);
            modelFilename = modelFilename + "\\resource\\wordmodel\\" + excelName + ".xlsx";

            string filename = GetDownloadExcelFileName("xlsx");
            Stream stream = new FileStream(filename, FileMode.Create);
            ExcelExportOprator.ExportVBA(table, stream, modelFilename, exportName, columnName);
            stream.Close();

            FileDownLoadDel(filename);

        }


        /// <summary>
        /// 下载VBAExcel
        /// </summary>
        /// <param name="table"></param>
        /// <param name="excelName"></param>
        /// <param name="exportName"></param>
        protected void DownloadVBAExcel(DataTable table, string excelName, string exportName)
        {

            string modelFilename = this.Server.MapPath("");
            modelFilename = modelFilename.Substring(0, modelFilename.Length - 17);
            modelFilename = modelFilename + "\\resource\\wordmodel\\" + excelName + ".xlsx";

            string filename = GetDownloadExcelFileName("xlsx");
            Stream stream = new FileStream(filename, FileMode.Create);
            ExcelExportOprator.ExportVBA(table, stream, modelFilename, exportName, excelName);
            stream.Close();

            FileDownLoadDel(filename);
        }

        #endregion 

        /// <summary>
        /// 下载VBAExcel（客户卡片登记明细离线报表下载用）
        /// </summary>
        /// <param name="table"></param>
        /// <param name="excelName"></param>
        /// <param name="exportName"></param>
        /// <param name="titleName"></param>
        /// <param name="columnName"></param>
        public void DownloadVBAExcelCard(DataTable table, string excelName, string exportName, string[] columnName, string fielNa, string ExcelModel, string SavePath)
        {


            string modelFilename = ExcelModel + excelName + ".xlsx"; ;


            string filename = fielNa;
            Stream stream = new FileStream(filename, FileMode.Create);
            ExcelExportOprator.ExportVBAExcel(table, stream, modelFilename, exportName, columnName, SavePath, filename);
            stream.Close();
        }

        #region 系统管理员
        /// <summary>
        /// 系统管理员
        /// </summary>
        /// <returns></returns>
        protected bool IsAdmin()
        {
            LtUser logonUser = (LtUser)Session["LogonUser"];
            if (EnumParser.GetEnumFiledValue(RoleType.系统管理员).ToString() == logonUser.ROLE_TYPE)
                return true;
            else
                return false;
        }
        #endregion


        #region 校验密码
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        protected bool IsValidPassword(string password)
        {
            Hashtable hashtable = new Hashtable();
            string numbers = @"[0-9]";
            string lowers = @"[a-z]";
            string uppers = @"[A-Z]";
            string chars = @"[@,#,`,~,!,$,%,^,&,*,(,),_,\\,|,\-,\,,+,=,\[,\],\{,\},.,?,/,:,;]";
            string pattern = @"^[a-zA-Z0-9,@,#,`,~,!,$,%,^,&,*,(,),_,\\,|,\-,\,,+,=,\[,\],\{,\},.,?,/,:,;]*$";
            if (password.Length < 6)
            {
                ShowMessage("密码长度至少6位");
                return false;
            }
            //判断是否粘贴非法字符,汉字
            if (!Regex.IsMatch(password, pattern))
            {
                ShowMessage("密码有非法字符,汉字");
                return false;
            }
            //密码长度为6,7位
            if (password.Length == 6 || password.Length == 7)
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (Regex.IsMatch(password[i].ToString(), numbers))
                    {
                        if (!hashtable.Contains("numbers"))
                            hashtable.Add("numbers", password[i]);
                        continue;
                    }
                    if (Regex.IsMatch(password[i].ToString(), lowers))
                    {
                        if (!hashtable.Contains("lowers"))
                            hashtable.Add("lowers", password[i]);
                        continue;
                    }
                    if (Regex.IsMatch(password[i].ToString(), uppers))
                    {
                        if (!hashtable.Contains("uppers"))
                            hashtable.Add("uppers", password[i]);
                        continue;
                    }
                    if (Regex.IsMatch(password[i].ToString(), chars))
                    {
                        if (!hashtable.Contains("chars"))
                            hashtable.Add("chars", password[i]);
                        continue;
                    }
                }
                //string exp = @"([a-z]+[A-Z]+[0-9]+)" +
                //@"|([a-z]+[A-Z]+[@,#,`,~,!,$,%,^,&,*,(,),_,\\,|,\-,\,,+,=,\[,\],\{,\},.,?,/,:,;]+)" +
                //@"|([a-z]+[0-9]+[@,#,`,~,!,$,%,^,&,*,(,),_,\\,|,\-,\,,+,=,\[,\],\{,\},.,?,/,:,;]+)" +
                //@"|([A-Z]+[0-9]+[@,#,`,~,!,$,%,^,&,*,(,),_,\\,|,\-,\,,+,=,\[,\],\{,\},.,?,/,:,;]+)" +
                //@"|([a-z]+[A-Z]+[0-9]+[@,#,`,~,!,$,%,^,&,*,(,),_,\\,|,\-,\,,+,=,\[,\],\{,\},.,?,/,:,;]+)";
                //if (!Regex.IsMatch(password, exp))
                //{
                //    ShowMessage("密码必须至少包含大写,小写,数字,字符中的任意三种");
                //    return false;
                //}
                if (hashtable.Keys.Count < 3)
                {
                    ShowMessage("密码必须至少包含大写,小写,数字,字符中的任意三种");
                    return false;
                }
            }
            if (password.Length >= 8)
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (Regex.IsMatch(password[i].ToString(), numbers))
                    {
                        if (!hashtable.Contains("numbers"))
                            hashtable.Add("numbers", password[i]);
                        continue;
                    }
                    if (Regex.IsMatch(password[i].ToString(), lowers))
                    {
                        if (!hashtable.Contains("lowers"))
                            hashtable.Add("lowers", password[i]);
                        continue;
                    }
                    if (Regex.IsMatch(password[i].ToString(), uppers))
                    {
                        if (!hashtable.Contains("uppers"))
                            hashtable.Add("uppers", password[i]);
                        continue;
                    }
                    if (Regex.IsMatch(password[i].ToString(), chars))
                    {
                        if (!hashtable.Contains("chars"))
                            hashtable.Add("chars", password[i]);
                        continue;
                    }
                }
                //string exp = @"([a-z]+[A-Z]+)" +
                //@"|([a-z]+[0-9]+)" +
                //@"|([A-Z]+[0-9]+)" +
                //@"|([a-z]+[@,#,`,~,!,$,%,^,&,*,(,),_,\\,|,\-,\,,+,=,\[,\],\{,\},.,?,/,:,;]+)" +
                //@"|([A-Z]+[@,#,`,~,!,$,%,^,&,*,(,),_,\\,|,\-,\,,+,=,\[,\],\{,\},.,?,/,:,;]+)" +
                //@"|([0-9]+[@,#,`,~,!,$,%,^,&,*,(,),_,\\,|,\-,\,,+,=,\[,\],\{,\},.,?,/,:,;]+)" +
                //@"|([a-z]+[A-Z]+[0-9]+)" +
                //@"|([a-z]+[A-Z]+[@,#,`,~,!,$,%,^,&,*,(,),_,\\,|,\-,\,,+,=,\[,\],\{,\},.,?,/,:,;]+)" +
                //@"|([a-z]+[0-9]+[@,#,`,~,!,$,%,^,&,*,(,),_,\\,|,\-,\,,+,=,\[,\],\{,\},.,?,/,:,;]+)" +
                //@"|([A-Z]+[0-9]+[@,#,`,~,!,$,%,^,&,*,(,),_,\\,|,\-,\,,+,=,\[,\],\{,\},.,?,/,:,;]+)" +
                //@"|([a-z]+[A-Z]+[0-9]+[@,#,`,~,!,$,%,^,&,*,(,),_,\\,|,\-,\,,+,=,\[,\],\{,\},.,?,/,:,;]+)";
                //if (!Regex.IsMatch(password, exp))
                //{
                //    ShowMessage("密码必须至少含大写,小写,数字,字符中的任意两种");
                //    return false;
                //}
                if (hashtable.Keys.Count < 2)
                {
                    ShowMessage("密码必须至少包含大写,小写,数字,字符中的任意两种");
                    return false;
                }
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected string[] SplitValue(string value)
        {
            return value.Substring(0, value.Length - 1).Split(',');
        }


        /// <summary>
        /// 重复提交
        /// </summary>
        protected void CheckSubmit(Button btnSubmit)
        {
            //sb保存的是JavaScript脚本代码,点击提交按钮时执行该脚本

            StringBuilder sb = new StringBuilder();

            //保证验证函数的执行 

            sb.Append("if (typeof(Page_ClientValidate) == 'function') { if (Page_ClientValidate() == false) { return false; }};");

            //点击提交按钮后设置Button的disable属性防止用户再次点击,注意这里的this是JavaScript代码

            sb.Append("this.disabled  = true;");

            //用__doPostBack来提交，保证按钮的服务器端click事件执行 

            sb.Append(this.ClientScript.GetPostBackEventReference(btnSubmit, ""));

            sb.Append(";");

            //SetUIStyle()是JavaScript函数,点击提交按钮后执行,如可以显示动画效果提示后台处理进度

            //注意SetUIStyle()定义在aspx页面中

            //sb.Append("SetUIStyle();");

            //给提交按钮增加OnClick属性

            btnSubmit.Attributes.Add("onclick", sb.ToString());

        }

        protected DateTime CastDate(string str)
        {
             DateTime dt = DateTime.ParseExact(str, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
             return dt;
        }

        protected bool IsValidYYYYMMDDDate(string str,string error)
        {
            if (str == "")
                return false;
            if (str.Length != 8)
                throw new Exception(error + "错误");
            try
            {
                CastDate(str);
            }
            catch(Exception ex)
            {
                throw new Exception(error + "错误");
            }
                
            return true;
        }


        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="result"></param>
        protected void FileDownLoad(string fullFilename)
        {
            System.IO.Stream iStream = null;
            // Buffer to read 10K bytes in chunk:
            byte[] buffer = new Byte[10000];

            // Length of the file:
            int length;

            // Total bytes to read:
            long dataToRead;

            // Identify the file to download including its path.
            string filepath = fullFilename;

            // Identify the file name.
            string filename = System.IO.Path.GetFileName(filepath);

            try
            {
                // Open the file.
                iStream = new System.IO.FileStream(filepath, System.IO.FileMode.Open,
                            System.IO.FileAccess.Read, System.IO.FileShare.Read);


                // Total bytes to read:
                dataToRead = iStream.Length;
                //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);

                // Read the bytes.
                while (dataToRead > 0)
                {
                    // Verify that the client is connected.
                    if (Response.IsClientConnected)
                    {
                        // Read the data in buffer.
                        length = iStream.Read(buffer, 0, 10000);

                        // Write the data to the current output stream.
                        Response.OutputStream.Write(buffer, 0, length);

                        // Flush the data to the HTML output.
                        Response.Flush();

                        buffer = new Byte[10000];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        //prevent infinite loop if user disconnects
                        dataToRead = -1;
                        Response.Clear();
                    }
                }
                Response.End(); //没有这句会将该页面刷新后的内容追加写入文件中。
            }
            catch (Exception ex)
            {
                // Trap the error, if any.
                //Response.Write("Error : " + ex.Message);
                //base.WriteLog("资料", "下载资料:" + ex.Message + "!", LogType.Error, this.GetType().ToString());

            }
            finally
            {
                if (iStream != null)
                {
                    //Close the file.
                    iStream.Close();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual string GetUserWarehouseListStr()
        {
            if (Session["LogonUser"] == null)
                RedirectToLoginForm();
            LtUser logonUser = (LtUser)Session["LogonUser"];
            IDictionary queryParams = new Hashtable();
            queryParams.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(IsEnabled.启用));
            queryParams.Add("USER_ID", logonUser.ID);
            IList<JjmcDimWarehouse> warehouseList = JjmcDimWarehouse.QueryList("SelectWarehouseList", queryParams);
            string str = null;
            for (int i = 0; i < warehouseList.Count; i++)
            {
                str += warehouseList[i].WAREHOUSE_CODE + "|";
            }
            if (str.Length != 0)
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }
        /// <summary>
        /// 对数组进行字符串“|”分割
        /// </summary>
        /// <returns></returns>
        protected virtual string GetStr1(string[] str1)
        {
            string str = null;
            for (int i = 0; i < str1.Length; i++)
            {
                str += str1[i] + "|";
            }
            if (str.Length != 0)
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }


        /// <summary>
        /// 邦定赠品说明
        /// </summary>
        /// <param name="ddlProvinceName"></param>
        protected virtual void BindGiftsDesPromotional(DropDownList ddlSecondRemark)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            DataTable table = JjmcGiftsDesPromotional.QueryDataTable("SelectByParam", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlSecondRemark.Items.Add(new ListItem(row["GIFTS_DES_NAME"].ToString(), row["GIFTS_DES_CODE"].ToString()));
            }
        }

        /// <summary>
        /// 邦定促销力度
        /// </summary>
        /// <param name="ddlProvinceName"></param>
        protected virtual void BindBaseinfoPromotional(DropDownList ddlPromotionType)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.启用).ToString());
            DataTable table = JjmcBaseinfoPromotional.QueryDataTable("SelectByParam", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlPromotionType.Items.Add(new ListItem(row["PROMOTIONAL_NAME"].ToString(), row["PROMOTIONAL_CODE"].ToString()));
            }
            ddlPromotionType.Items.Insert(0,new ListItem("全部", ""));
        }
    }
}
