using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Maticsoft.Common;
namespace Maticsoft.BLL.chart
{
    public partial class chart
    {
        private readonly Maticsoft.DAL.chart.chart dal = new Maticsoft.DAL.chart.chart();
        #region " 体检单位费用统计"

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList_DepartmentCharge(string strWhere)
        {
            return dal.GetList_DepartmentCharge(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount_DepartmentCharge(string strWhere)
        {
            return dal.GetRecordCount_DepartmentCharge(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage_DepartmentCharge(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage_DepartmentCharge(strWhere, orderby, startIndex, endIndex);
        }

        public DataSet GetSum_DepartmentCharge(string strWhere)
        {
            return dal.GetSum_DepartmentCharge(strWhere);
        }
        #endregion


        #region " 体检人数同比分析"


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList_PersonNumber(string strWhere)
        {

            return dal.GetList_PersonNumber(strWhere);
        }
        #endregion

        #region "检查项目人数分布"


          /// <summary>
       /// 获得体检项目人数分布列表
       /// </summary>
        public DataSet GetList_itemgroupNumber(string strWhere)
        {
            return dal.GetList_itemgroupNumber(strWhere);
        }
        #endregion

        #region "按照科室年人数分布"


       
        /// <summary>
        /// 按照科室获得体检项目人数分布比例
        /// </summary>
        public DataSet GetList_itemDepartmentNumberPercent(string strWhere)
        {
            return dal.GetList_itemDepartmentNumberPercent(strWhere);
        }
        #endregion

           #region " 工种按年体检人数同比分析-chart2"


       /// <summary>
       /// 获得数据列表
       /// </summary>
        public DataSet GetList_TradeYear(string strWhere)
        {
            return dal.GetList_TradeYear(strWhere);
        }

           #endregion


          #region " 工种按年体检人数同比分析-chart3"

       /// <summary>
       /// 获得体检组合项目人数分布列表
       /// </summary>
        public DataSet GetList_TradePercent(string strWhere)
        {
            return dal.GetList_TradePercent(strWhere);
        }
          #endregion
    }
}
