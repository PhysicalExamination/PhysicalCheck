<%@ WebHandler Language="C#" Class="GenerateBarcode" %>

using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using BusinessLogic.Examination;
using DataEntity.Examination;
using DataEntity.SysConfig;

public class GenerateBarcode : IHttpHandler {
    
    private RegistrationBusiness m_Registration;

    public void ProcessRequest(HttpContext context) {
        m_Registration = new RegistrationBusiness();
        context.Response.ContentType = "application/json";
        String Action = context.Request.Params["Action"];
        if (Action == "BuildRegisterTree") BuildRegisterTree(context);
        if (Action == "GetCheckedGroup") GetCheckedGroup(context);
    }

    #region 体检结果录入

    /// <summary>
    /// 生成体检人员与检查项树
    /// </summary>
    /// <param name="context"></param>
    private void BuildRegisterTree(HttpContext context) {
        HttpResponse Response = context.Response;
        HttpRequest Request = context.Request;
        String DeptName = Request.Params["DeptName"];
        String RegisterNo = Request.Params["RegisterNo"];
        DateTime? CheckDate = null;
        if (!String.IsNullOrWhiteSpace(Request.Params["CheckDate"])) {
            CheckDate = Convert.ToDateTime(Request.Params["CheckDate"]);
        }
        List<RegisterTreeData> Nodes = m_Registration.GetRegistrationTree(CheckDate, DeptName, RegisterNo);
        Response.Write(JsonConvert.SerializeObject(Nodes));
    }

    private void GetCheckedGroup(HttpContext context) {
        HttpResponse Response = context.Response;
        HttpRequest Request = context.Request;       
        String RegisterNo = Request.Params["RegisterNo"];
        List<ItemGroupViewEntity> Groups = m_Registration.GetCheckedGroups(RegisterNo);
        Response.Write(JsonConvert.SerializeObject(Groups));
    }

    #endregion
    public bool IsReusable {
        get {
            return false;
        }
    }

}