<%@ WebHandler Language="C#" Class="Services" %>

using System;
using System.Web;
using System.Collections.Generic;
using Newtonsoft.Json;
using BusinessLogic.Survey;
using DataEntity.Survey;

public class Services : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "application/json";
        context.Response.Write("Hello World");
    }

    private void GetQuestionOptions(HttpContext context) {
        HttpResponse Response = context.Response;
        HttpRequest Request = context.Request;
        int QuestionID = Convert.ToInt32(Request.Params["QuestionID"]);
        using (QuestionOptionBusiness Business = new QuestionOptionBusiness()) {
           String JSON = JsonConvert.SerializeObject( Business.GetQuestionOptions(QuestionID));
           Response.Write(JSON);           
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}