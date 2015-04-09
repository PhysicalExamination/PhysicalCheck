using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Maticsoft.Common;
namespace Maticsoft.BLL.UnitReport
{
     public partial class UnitReport
    {
         private readonly Maticsoft.DAL.UintReport.UintReport dal = new DAL.UintReport.UintReport();
           #region 单位体检报告
        /// <summary>
        /// 体检疾病统计
        /// </summary>
         public DataSet GetUnitDiseasesumMain(string strWhere)
         {
             return dal.GetUnitDiseasesumMain(strWhere);

         }
            /// <summary>
         /// 体检疾病统计
        /// </summary>
         public DataSet GetUnitDiseasesumSub(string strWhere)
         {
             return dal.GetUnitDiseasesumSub(strWhere);
         }
      
           #endregion

        

    }
}
