using System;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

namespace Utility
{
    /// <summary>
    /// 各个弹出框页面的基类，封装了一些调用Js的方法
    /// </summary>
    public class BasePopPage : BasePage
    {
        /// <summary>
        /// 预生成，加载javascript引用
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "poppage"))
            {
                string script = "<script language=\"javascript\" type=\"text/javascript\" src=\"../../Resource/Js/poppage.js\"></script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "poppage", script);
            }
        }
        /// <summary>
        /// 初始化，判断Session是否存在，不存在则跳转到错误页面
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>history.forward();</script>");
            ClientScript.RegisterStartupScript(this.GetType(),
                Guid.NewGuid().ToString(), "<script>window.onload=function(){ if(window.dialogArguments == null){top.window.location.replace('" + GetWebApplicationPath() + "/Default.aspx');}}</script>");
            if (Session["LogonUser"] == null)
            {
                ViewState["SessionError"] = "true";
                StringBuilder strbuilder = new StringBuilder();
                strbuilder.Append("<script>\r\n");
                strbuilder.Append("if(window.dialogArguments != null)\r\n");
                strbuilder.Append("{\r\n");
                strbuilder.Append("  var parent = window.dialogArguments;\r\n");
                strbuilder.Append("  window.close();\r\n");
                strbuilder.Append("  parent.location.replace('" + GetWebApplicationPath() + "/Default.aspx');\r\n");
                strbuilder.Append("}\r\n");
                strbuilder.Append("else\r\n");
                strbuilder.Append("{\r\n");
                strbuilder.Append("  window.location.replace('" + GetWebApplicationPath() + "/Default.aspx');\r\n");
                strbuilder.Append("}\r\n");
                strbuilder.Append("</script>\r\n");
                Response.Write(strbuilder.ToString());
            }
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (ViewState["SessionError"] != null && ViewState["SessionError"].Equals("true"))
            {
                return;
            }
            base.OnLoad(e);
        }

        /// <summary>
        /// 模态对话框页面关闭，回传值给父窗口的控件
        /// </summary>
        /// <param name="txtclientID"></param>
        /// <param name="txt"></param>
        /// <param name="valclientID"></param>
        /// <param name="val"></param>
        protected void ModalDialogClose(string txtclientID, string txt, string valclientID, string val)
        {
            ModalDialogClose(txtclientID, txt, valclientID, val, string.Empty);
        }

        /// <summary>
        /// 模态对话框页面关闭，回传值给父窗口的控件
        /// </summary>
        /// <param name="txtclientID"></param>
        /// <param name="txt"></param>
        /// <param name="valclientID"></param>
        /// <param name="val"></param>
        /// <param name="buttonId"></param>
        protected void ModalDialogClose(string txtclientID, string txt, string valclientID, string val, string buttonId)
        {
            StringBuilder strbuilder = new StringBuilder();
            strbuilder.Append("<script>");
            strbuilder.Append("modaldialogclose('" + txtclientID + "','" + valclientID + "','" + txt + "','" + val + "','" + buttonId + "');");
            strbuilder.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(),
                Guid.NewGuid().ToString(), strbuilder.ToString());
        }

        /// <summary>
        /// 弹出页面连动，回传值给父窗口的控件
        /// </summary>
        /// <param name="fathercontrolid"></param>
        /// <param name="val"></param>
        protected void SetFatherControlValue(string fathercontrolid, string val)
        {
            StringBuilder strbuilder = new StringBuilder();
            strbuilder.Append("<script>");
            strbuilder.Append("setfathercontrolvalue('" + fathercontrolid + "','" + val + "');");
            strbuilder.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(),
                Guid.NewGuid().ToString(), strbuilder.ToString());
        }

        /// <summary>
        /// 弹出页面连动，父窗口控件值传给子窗口控件
        /// </summary>
        /// <param name="fathercontrolid"></param>
        /// <param name="childcontrolid"></param>
        protected void GetFatherControlValue(string fathercontrolid, string childcontrolid)
        {
            StringBuilder strbuilder = new StringBuilder();
            strbuilder.Append("<script>");
            strbuilder.Append("getfathercontrolval('" + fathercontrolid + "','" + childcontrolid + "');");
            strbuilder.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), strbuilder.ToString());
        }

        /// <summary>
        /// 弹出页面连动，通过比较清空父窗口控件
        /// </summary>
        /// <param name="comparecontrolid">父窗口比较控件Id</param>
        /// <param name="comparevalue">比较值</param>
        /// <param name="clearcontrolids">父窗口清空控件Ids</param>
        protected void ClearFatherControlValue(string comparecontrolid, 
            string comparevalue, string clearcontrolids)
        {
            StringBuilder strbuilder = new StringBuilder();
            strbuilder.Append("<script>");
            strbuilder.Append("clearfathercontrolval('" + comparecontrolid + "','" + comparevalue + "','" + clearcontrolids + "');");
            strbuilder.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), strbuilder.ToString());
        }

        /// <summary>
        /// 关闭本窗口
        /// </summary>
        protected void CloseSelf()
        {
            ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script>window.close();</script>");
        }

        /// <summary>
        /// 跳转页面
        /// </summary>
        /// <param name="url"></param>
        protected override void Redirect(string url)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override bool CheckTextBoxValue()
        {
            return true;
        }

        /// <summary>
        /// 跳转到登录页面
        /// </summary>
        protected override void RedirectToLoginForm()
        {
            StringBuilder strbuilder = new StringBuilder();
            strbuilder.Append("<script>\r\n");
            strbuilder.Append("if(window.dialogArguments != null)\r\n");
            strbuilder.Append("{\r\n");
            strbuilder.Append(" var obj = window.dialogArguments;\r\n");
            strbuilder.Append(" obj.parent.location.replace('" + GetWebApplicationPath() + "/Default.aspx');\r\n");
            strbuilder.Append(" window.close();\r\n");
            strbuilder.Append("}\r\n");
            strbuilder.Append("</script>\r\n");
            ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), strbuilder.ToString());
        }

        /// <summary>
        /// 跳转到错误页面
        /// </summary>
        protected override void RedirectToErrorForm()
        {
            StringBuilder strbuilder = new StringBuilder();
            strbuilder.Append("<script>\r\n");
            strbuilder.Append("if(window.dialogArguments != null)\r\n");
            strbuilder.Append("{\r\n");
            strbuilder.Append(" var obj = window.dialogArguments;\r\n");
            strbuilder.Append(" obj.parent.location.replace('" + GetWebApplicationPath() + "/Views/ErrorPage.aspx');\r\n");
            strbuilder.Append(" window.close();\r\n");
            strbuilder.Append("}\r\n");
            strbuilder.Append("</script>\r\n");
            ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), strbuilder.ToString());
        }
    }
}
