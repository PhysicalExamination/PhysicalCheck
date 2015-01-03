using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Maticsoft.Common;
namespace Maticsoft.BLL.Search
{
     public partial class Search
    {
         private readonly Maticsoft.DAL.Search.Search dal = new DAL.Search.Search();
           #region 组合查询
        /// <summary>
        /// 获得体检组合项目结论列表
        /// </summary>
         public DataSet GetList_GroupResult(string strWhere)
         {
             return dal.GetList_GroupResult(strWhere);

         }
            /// <summary>
        /// 获得体检项目结论列表
        /// </summary>
         public DataSet GetList_itemresult(string strWhere)
         {
             return dal.GetList_itemresult(strWhere);
         }

           #endregion
    }
}
