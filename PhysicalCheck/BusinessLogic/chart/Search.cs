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
          /// <summary>
        /// 获得组合查询列表
        /// </summary>
         public DataSet GetList_Composed(string strWhere)
         {
             return dal.GetList_Composed(strWhere);
         }
          /// <summary>
        /// 获取组合查询记录总数
        /// </summary>
         public int GetRecordCount_Composed(string strWhere)
         {
             return dal.GetRecordCount_Composed(strWhere);
         }

          /// <summary>
        /// 分页获取组合查询数据列表
        /// </summary>
         public DataSet GetListByPage_Composed(string strWhere, string orderby, int startIndex, int endIndex)
         {
             return dal.GetListByPage_Composed(strWhere, orderby, startIndex, endIndex);
         }

           #endregion

          #region 工作量
        /// <summary>
        /// 获得体检套餐工作量、
        /// </summary>
         public DataSet GetList_workload_package(string strWhere)
         {
             return dal.GetList_workload_package(strWhere);
         }

         /// <summary>
         /// 获得体检组合项目结论列表
         /// </summary>
         public DataSet GetList_workload_itemgroup(string strWhere)
         {
             return dal.GetList_workload_itemgroup(strWhere);
         }


         /// <summary>
         /// 获得体检单项结论列表
         /// </summary>
         public DataSet GetList_workload_checkItem(string strWhere)
         {
             return dal.GetList_workload_checkItem(strWhere);
         }


          #endregion

    }
}
