<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="Chart4.aspx.cs" Inherits="Charts_Chart4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    年度<select>
        <option>2010年</option>
        <option>2011年</option>
        <option>2012年</option>
        <option>2013年</option>
        <option>2014年</option>
        <option>2015年</option>
    </select><input type="button" class="buttonCss" value="检索" />
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <th>
                体检单位
            </th>
            <th>
                体检套餐
            </th>
            <th>
              体检人数
            </th>
            <th>
                体检费用合计（元）
            </th>
        </tr>
        <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
            <td class="VLine" align="center">
                AA矿业有限公司
            </td>
            <td class="VLine" align="center">
              从业体检
            </td>
            <td class="VLine" align="center">
              20
            </td>
            <td class="VLine" align="center">
              2,800.00
            </td>
        </tr>
        <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
            <td class="VLine" align="center">
                XXX通讯科技有限公司
            </td>
            <td class="VLine" align="center">
              从业体检
            </td>
            <td class="VLine" align="center">
              23
            </td>
            <td class="VLine" align="center">
              3,000.00
            </td>
        </tr>
        <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
            <td class="VLine" align="center">
                XXX信息科技有限公司
            </td>
            <td class="VLine" align="center">
              从业体检
            </td>
            <td class="VLine" align="center">
              20
            </td>
            <td class="VLine" align="center">
              2,800.00
            </td>
        </tr>
        <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
            <td class="VLine" align="center">
                XXX健身器材有限公司
            </td>
            <td class="VLine" align="center">
              从业体检
            </td>
            <td class="VLine" align="center">
              25
            </td>
            <td class="VLine" align="center">
              3,600.00
            </td>
        </tr>

        <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
            <td class="VLine" align="center">
                XXX企业管理咨询有限公司
            </td>
            <td class="VLine" align="center">
              从业体检
            </td>
            <td class="VLine" align="center">
              25
            </td>
            <td class="VLine" align="center">
              2,600.00
            </td>
        </tr>
        <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
            <td class="VLine" align="center">
                XXX企业管理咨询有限公司
            </td>
            <td class="VLine" align="center">
              从业体检
            </td>
            <td class="VLine" align="center">
              23
            </td>
            <td class="VLine" align="center">
              3,000.00
            </td>
        </tr>
        <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
            <td class="VLine" align="center">
                XXX信息科技有限公司
            </td>
            <td class="VLine" align="center">
              从业体检
            </td>
            <td class="VLine" align="center">
              20
            </td>
            <td class="VLine" align="center">
              2,800.00
            </td>
        </tr>
        <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
            <td class="VLine" align="center">
                XXX运输有限公司
            </td>
            <td class="VLine" align="center">
              从业体检
            </td>
            <td class="VLine" align="center">
              25
            </td>
            <td class="VLine" align="center">
              3,600.00
            </td>
        </tr>
        <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
            <td class="VLine" align="center">
                XXX信息科技有限公司
            </td>
            <td class="VLine" align="center">
              从业体检
            </td>
            <td class="VLine" align="center">
              20
            </td>
            <td class="VLine" align="center">
              2,800.00
            </td>
        </tr>
        <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
            <td class="VLine" align="center">
                XXX数码科技有限公司
            </td>
            <td class="VLine" align="center">
              从业体检
            </td>
            <td class="VLine" align="center">
              25
            </td>
            <td class="VLine" align="center">
              3,600.00
            </td>
        </tr>
        <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
            <td class="VLine" align="center">
                XXX生物科技有限公司
            </td>
            <td class="VLine" align="center">
              从业体检
            </td>
            <td class="VLine" align="center">
              20
            </td>
            <td class="VLine" align="center">
              2,800.00
            </td>
        </tr>
        <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
            <td class="VLine" align="center">
                XXX感应加热设备有限公司
            </td>
            <td class="VLine" align="center">
              从业体检
            </td>
            <td class="VLine" align="center">
              25
            </td>
            <td class="VLine" align="center">
              3,600.00
            </td>
        </tr>
        <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
            <td class="VLine" align="center" colspan="2">
                合计
            </td>
            
            <td class="VLine" align="center">
              291
            </td>
            <td class="VLine" align="center">
              37,000.00
            </td>
        </tr>
    </table>
</asp:Content>
