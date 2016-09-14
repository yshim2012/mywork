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
    /// �������ҳ��Ļ��࣬��װ��һЩ����Js�ķ���
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {
        /// <summary>
        /// ��ʼ�����ж�Session�Ƿ���ڣ�����������ת����¼ҳ��
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
        /// ҳ�����
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
        /// У��ҳ�����ı���ؼ���ֵ�Ƿ���ȷ
        /// ����ȷ����ʾ������Ϣ��ʾ�û�
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

                //������Ǳ������TextBoxֵΪ�գ�����
                if (!required && mytextbox.Text.Trim() == string.Empty)
                    continue;

                //����Ǳ������TextBoxֵΪ�գ���ʾ������Ϣ
                if (required && mytextbox.Text.Trim() == string.Empty)
                {
                    ShowMessageByKey(requiredmessageid);
                    mytextbox.Focus();
                    return false;
                }

                lengthmessageid = textboxproperty.LengthMessageId;
                //ֵ���ȳ���MexLength����ʾ������Ϣ
                if (!mytextbox.IsTextLengthValid())
                {
                    ShowMessageByKey(lengthmessageid);
                    mytextbox.Focus();
                    return false;
                }

                typepattern = textboxproperty.TypePattern;
                //����У��ı��ʽ���ڣ���������У�鲻ͨ������ʾ������Ϣ
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
        /// ���ݴ����Key��MessagePool��ȡ����Ӧ��value��
        /// ������js��alert��ʾmessage��ʾ��Ϣ
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
        /// ���ݴ����Key��MessagePool��ȡ����Ӧ��value��
        /// ������js��alert��ʾmessage��ʾ��Ϣ
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
        /// ��Js��alert��ʾһ����ʾ��Ϣ
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
        /// ���ݴ���ֵ��ѡ�з���������������ֵ
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
        /// ��תҳ��
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
        /// ��ת����¼ҳ��
        /// </summary>
        protected virtual void RedirectToLoginForm()
        {
            Response.Write("<script>top.window.location.replace('" + GetWebApplicationPath() + "/Default.aspx');</script>");
        }

        /// <summary>
        /// ��ת������ҳ��
        /// </summary>
        protected virtual void RedirectToErrorForm()
        {
            Response.Write("<script>top.window.location.replace('" + GetWebApplicationPath() + "/Views/ErrorPage.aspx');</script>");
        }

        /// <summary>
        /// ���Ӧ�ó�������Ŀ¼·��
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
        /// ��ӡ
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
        /// ��ӡ
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
        /// ��ӡ
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
        /// ��ӡ
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

        #region ����ֵ���ؼ�

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
        /// ����ģʽ����
        /// </summary>
        /// <param name="url"></param>
        protected void showModalDialog(string url)
        {
            ClientScript.RegisterStartupScript(this.GetType(),
                Guid.NewGuid().ToString(),
                "<script> window.showModalDialog('" + url + "',self,'dialogWidth=800px,dialogHeight=600px');</script>");
        }


        /// <summary>
        /// ���ǰ��Ʒ����
        /// </summary>
        /// <param name="ddlProductCode"></param>
        protected virtual void BindProduct(DropDownList ddlProductCode)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
            paramHashtable.Add("IS_LEAST_UNIT", EnumParser.GetEnumFiledValue(Utility.IsLeastUnit.��).ToString());
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
        /// ���ǰ��Ʒ����
        /// </summary>
        /// <param name="ddlProductCode"></param>
        /// <param name="strText"></param>
        /// <param name="strValue"></param>
        protected virtual void BindProduct(DropDownList ddlProductCode, string strText, string strValue)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
            paramHashtable.Add("IS_LEAST_UNIT", EnumParser.GetEnumFiledValue(Utility.IsLeastUnit.��).ToString());
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
        /// ���ǰ��Ʒ����
        /// </summary>
        /// <param name="ddlProductCode"></param>
        protected virtual void BindProductCode(DropDownList ddlProductCode)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
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
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectForPageing", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProductCode.Items.Add(new ListItem(row["PRODUCT_NAME"].ToString(), row["PRODUCT_CODE"].ToString()));
            }
            ddlProductCode.Items.Insert(0, new ListItem(strText, strValue));
        }


        /// <summary>
        /// ���ǰ��Ʒ����
        /// </summary>
        /// <param name="ddlProductCode"></param>
        protected virtual void BindInstrumentProductCode(DropDownList ddlProductCode)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
            paramHashtable.Add("TYPE", EnumParser.GetEnumFiledValue(Utility.ProductType.����).ToString());
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectForPageing", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProductCode.Items.Add(new ListItem(row["PRODUCT_NAME"].ToString(), row["PRODUCT_CODE"].ToString()));
            }
        }

        /// <summary>
        /// ���ǰ��Ʒ����
        /// </summary>
        /// <param name="ddlProductCode"></param>
        /// <param name="strText"></param>
        /// <param name="strValue"></param>
        protected virtual void BindInstrumentProductCode(DropDownList ddlProductCode, string strText, string strValue)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
            paramHashtable.Add("TYPE", EnumParser.GetEnumFiledValue(Utility.ProductType.����).ToString());
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectForPageing", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProductCode.Items.Add(new ListItem(row["PRODUCT_NAME"].ToString(), row["PRODUCT_CODE"].ToString()));
            }

            ddlProductCode.Items.Insert(0, new ListItem(strText, strValue));
        }

        /// <summary>
        /// ���ǰ��Ʒ����
        /// </summary>
        /// <param name="ddlProductCode"></param>
        protected virtual void BindInstrumentPaperProductCode(DropDownList ddlProductCode)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
            paramHashtable.Add("TYPE", new string[] { EnumParser.GetEnumFiledValue(Utility.ProductType.����).ToString() ,
                             EnumParser.GetEnumFiledValue(Utility.ProductType.��ֽ).ToString()});
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectInstrumentPaper", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProductCode.Items.Add(new ListItem(row["PRODUCT_NAME"].ToString(), row["PRODUCT_CODE"].ToString()));
            }
        }

        /// <summary>
        /// ���ǰ��Ʒ����
        /// </summary>
        /// <param name="ddlProductCode"></param>
        /// <param name="strText"></param>
        /// <param name="strValue"></param>
        protected virtual void BindInstrumentPaperProductCode(DropDownList ddlProductCode, string strText, string strValue)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
            paramHashtable.Add("TYPE", new string[] { EnumParser.GetEnumFiledValue(Utility.ProductType.����).ToString() ,
                             EnumParser.GetEnumFiledValue(Utility.ProductType.��ֽ).ToString()});
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectInstrumentPaper", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProductCode.Items.Add(new ListItem(row["PRODUCT_NAME"].ToString(), row["PRODUCT_CODE"].ToString()));
            }

            ddlProductCode.Items.Insert(0, new ListItem(strText, strValue));
        }

        /// <summary>
        /// ���ǰ��Ʒ����
        /// </summary>
        /// <param name="ddlProductCode"></param>
        protected virtual void BindProductCode(DropDownList ddlProductCode, string[] type, string strText, string strValue)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
            paramHashtable.Add("TYPE", type);
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectInstrumentPaper", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProductCode.Items.Add(new ListItem(row["PRODUCT_NAME"].ToString(), row["PRODUCT_CODE"].ToString()));
            }
            ddlProductCode.Items.Insert(0, new ListItem(strText, strValue));
        }

        /// <summary>
        /// ���ǰ��Ʒ����
        /// </summary>
        /// <param name="ddlProductCode"></param>
        protected virtual void BindProductCode(DropDownList ddlProductCode, string[] type)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
            paramHashtable.Add("TYPE", type);
            DataTable table = JjmcBaseinfoProduct.QueryDataTable("SelectInstrumentPaper", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProductCode.Items.Add(new ListItem(row["PRODUCT_NAME"].ToString(), row["PRODUCT_CODE"].ToString()));
            }
        }

        /// <summary>
        /// ��������͸���ԭ���Ӧ��ϵ
        /// </summary>
        /// <param name="ddlChangeCase"></param>
        protected virtual void BindTypeOfCause(DropDownList ddlChangeCase,string changeType)
        {
            if (changeType != "")
            {
                IDictionary paramHashtable = new Hashtable();
                paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
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
        /// ��������͸���ԭ���Ӧ��ϵ
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
                paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
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
        /// ��ջ�ԭ��
        /// </summary>
        /// <param name="ddlChangeCase"></param>
        protected virtual void BindReceivingCase(DropDownList ddlChangeCase)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
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
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
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
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
            DataTable table = JjmcBaseinfoReceivingCause.QueryDataTable("SelectForPageing", paramHashtable);

            foreach (DataRow row in table.Rows)
            {

                ddlChangeCase.Items.Add(new ListItem(row["RECEIVING_CAUSE_NAME"].ToString(), row["ID"].ToString()));
            }
            ddlChangeCase.Items.Insert(0, new ListItem(strText, strValue));
        }


        /// <summary>
        /// �����ԭ��
        /// </summary>
        /// <param name="ddlChangeCase"></param>
        protected virtual void BindChangeCase(DropDownList ddlChangeCase)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
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
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
            DataTable table = JjmcBaseinfoChangeCause.QueryDataTable("SelectForPageing", paramHashtable);

            foreach (DataRow row in table.Rows)
            {

                ddlChangeCase.Items.Add(new ListItem(row["CHANGE_CAUSE_NAME"].ToString(), row["CHANGE_DEFINE_CODE"].ToString()));
            }
            ddlChangeCase.Items.Insert(0, new ListItem(strText, strValue));
        }

        /// <summary>
        /// �ʡ����
        /// </summary>
        /// <param name="ddlProvinceName"></param>
        protected virtual void BindProvinceName(DropDownList ddlProvinceName)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
            DataTable table = JjmcBaseinfoCity.QueryDataTable("SelectProvinceName", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProvinceName.Items.Add(new ListItem(row["PROVINCE_NAME"].ToString(), row["PROVINCE_NAME"].ToString()));
            }
        }

        /// <summary>
        /// �ʡ����
        /// </summary>
        /// <param name="ddlProvinceName"></param>
        protected virtual void BindProvinceName(DropDownList ddlProvinceName, string strText, string strValue)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
            DataTable table = JjmcBaseinfoCity.QueryDataTable("SelectProvinceName", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlProvinceName.Items.Add(new ListItem(row["PROVINCE_NAME"].ToString(), row["PROVINCE_NAME"].ToString()));
            }
            ddlProvinceName.Items.Insert(0, new ListItem(strText, strValue));
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="ddlCityName"></param>
        /// <param name="provinceName"></param>
        protected virtual void BindCityName(DropDownList ddlCityName, string provinceName)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
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
        /// �������
        /// </summary>
        /// <param name="ddlCityName"></param>
        /// <param name="provinceName"></param>
        protected virtual void BindCityName(DropDownList ddlCityName, string provinceName, string strText, string strValue)
        {
            if (provinceName != "")
            {
                IDictionary paramHashtable = new Hashtable();
                paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
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



        #region �󶨵�ǰ�û����ֿ�
        /// <summary>
        /// �󶨵�ǰ�û����ֿ�
        /// </summary>
        /// <param name="dropDownList"></param>
        protected virtual void BindWarehouse(DropDownList dropDownList)
        {
            if (Session["LogonUser"] == null)
                RedirectToLoginForm();
            LtUser logonUser = (LtUser)Session["LogonUser"];
            IDictionary queryParams = new Hashtable();
            queryParams.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(IsEnabled.����));
            queryParams.Add("USER_ID", logonUser.ID);
            IList<JjmcDimWarehouse> warehouseList = JjmcDimWarehouse.QueryList("SelectWarehouseList", queryParams);
            if (warehouseList.Count == 0)
                RedirectToLoginForm();
            dropDownList.DataSource = warehouseList;
            dropDownList.DataTextField = "WAREHOUSE_NAME";
            dropDownList.DataValueField = "WAREHOUSE_CODE";
            dropDownList.DataBind();
            dropDownList.Items.Insert(0,"ȫ��");
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
            queryParams.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(IsEnabled.����));
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
        /// �󶨵�ǰ�û����ֿ�
        /// </summary>
        /// <param name="dropDownList"></param>
        protected virtual void BindAllWarehouse(DropDownList dropDownList)
        {

            IDictionary queryParams = new Hashtable();
            queryParams.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(IsEnabled.����));
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
        /// ϵͳ����Ա
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckUserIsAdmin()
        {
            LtUser logonUser = (LtUser)Session["LogonUser"];
            if (EnumParser.GetEnumFiledValue(Utility.RoleType.ϵͳ����Ա).ToString() == logonUser.ROLE_TYPE)
                return true;
            else
                return false;
        }
        



        #region 
        /// <summary>
        /// ����Excel
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
        /// ����Excel����ʱ����
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

        #region ����Excel

        /// <summary>
        /// �ļ����ز�ɾ��
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
                Response.End(); //û�����Ὣ��ҳ��ˢ�º������׷��д���ļ��С�
            }
            catch (Exception ex)
            {
                // Trap the error, if any.
                //Response.Write("Error : " + ex.Message);
                //base.WriteLog("����", "��������:" + ex.Message + "!", LogType.Error, this.GetType().ToString());

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
        /// ����Excel
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
        #region ����VBAExcel
        /// <summary>
        /// ����VBAExcel
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
        /// ����VBAExcel
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
        /// ����VBAExcel
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
        /// ����VBAExcel���ͻ���Ƭ�Ǽ���ϸ���߱��������ã�
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

        #region ϵͳ����Ա
        /// <summary>
        /// ϵͳ����Ա
        /// </summary>
        /// <returns></returns>
        protected bool IsAdmin()
        {
            LtUser logonUser = (LtUser)Session["LogonUser"];
            if (EnumParser.GetEnumFiledValue(RoleType.ϵͳ����Ա).ToString() == logonUser.ROLE_TYPE)
                return true;
            else
                return false;
        }
        #endregion


        #region У������
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
                ShowMessage("���볤������6λ");
                return false;
            }
            //�ж��Ƿ�ճ���Ƿ��ַ�,����
            if (!Regex.IsMatch(password, pattern))
            {
                ShowMessage("�����зǷ��ַ�,����");
                return false;
            }
            //���볤��Ϊ6,7λ
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
                //    ShowMessage("����������ٰ�����д,Сд,����,�ַ��е���������");
                //    return false;
                //}
                if (hashtable.Keys.Count < 3)
                {
                    ShowMessage("����������ٰ�����д,Сд,����,�ַ��е���������");
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
                //    ShowMessage("����������ٺ���д,Сд,����,�ַ��е���������");
                //    return false;
                //}
                if (hashtable.Keys.Count < 2)
                {
                    ShowMessage("����������ٰ�����д,Сд,����,�ַ��е���������");
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
        /// �ظ��ύ
        /// </summary>
        protected void CheckSubmit(Button btnSubmit)
        {
            //sb�������JavaScript�ű�����,����ύ��ťʱִ�иýű�

            StringBuilder sb = new StringBuilder();

            //��֤��֤������ִ�� 

            sb.Append("if (typeof(Page_ClientValidate) == 'function') { if (Page_ClientValidate() == false) { return false; }};");

            //����ύ��ť������Button��disable���Է�ֹ�û��ٴε��,ע�������this��JavaScript����

            sb.Append("this.disabled  = true;");

            //��__doPostBack���ύ����֤��ť�ķ�������click�¼�ִ�� 

            sb.Append(this.ClientScript.GetPostBackEventReference(btnSubmit, ""));

            sb.Append(";");

            //SetUIStyle()��JavaScript����,����ύ��ť��ִ��,�������ʾ����Ч����ʾ��̨�������

            //ע��SetUIStyle()������aspxҳ����

            //sb.Append("SetUIStyle();");

            //���ύ��ť����OnClick����

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
                throw new Exception(error + "����");
            try
            {
                CastDate(str);
            }
            catch(Exception ex)
            {
                throw new Exception(error + "����");
            }
                
            return true;
        }


        /// <summary>
        /// �ļ�����
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
                Response.End(); //û�����Ὣ��ҳ��ˢ�º������׷��д���ļ��С�
            }
            catch (Exception ex)
            {
                // Trap the error, if any.
                //Response.Write("Error : " + ex.Message);
                //base.WriteLog("����", "��������:" + ex.Message + "!", LogType.Error, this.GetType().ToString());

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
            queryParams.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(IsEnabled.����));
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
        /// ����������ַ�����|���ָ�
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
        /// ���Ʒ˵��
        /// </summary>
        /// <param name="ddlProvinceName"></param>
        protected virtual void BindGiftsDesPromotional(DropDownList ddlSecondRemark)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
            DataTable table = JjmcGiftsDesPromotional.QueryDataTable("SelectByParam", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlSecondRemark.Items.Add(new ListItem(row["GIFTS_DES_NAME"].ToString(), row["GIFTS_DES_CODE"].ToString()));
            }
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="ddlProvinceName"></param>
        protected virtual void BindBaseinfoPromotional(DropDownList ddlPromotionType)
        {
            IDictionary paramHashtable = new Hashtable();
            paramHashtable.Add("IS_ENABLED", EnumParser.GetEnumFiledValue(Utility.IsEnabled.����).ToString());
            DataTable table = JjmcBaseinfoPromotional.QueryDataTable("SelectByParam", paramHashtable);

            foreach (DataRow row in table.Rows)
            {
                ddlPromotionType.Items.Add(new ListItem(row["PROMOTIONAL_NAME"].ToString(), row["PROMOTIONAL_CODE"].ToString()));
            }
            ddlPromotionType.Items.Insert(0,new ListItem("ȫ��", ""));
        }
    }
}
