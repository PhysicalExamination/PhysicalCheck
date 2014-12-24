using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///BaseReport 的摘要说明
/// </summary>
public abstract class BaseReport {

    public void Print(HttpContext context,String RegisterNo) {
        Initialize(context);
        BuildHeader();
        BuildContent();
        BuildFooter();
        Release(context);
    }

    protected abstract void Initialize(HttpContext context);
    protected abstract void BuildHeader();
    protected abstract void BuildContent();
    protected abstract void BuildFooter();
    protected abstract void Release(HttpContext context);

}