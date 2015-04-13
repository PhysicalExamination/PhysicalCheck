using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Maticsoft.Common;
namespace Maticsoft.BLL.BaseInfo
{
    
    public partial class BaseInfo
    {
        private readonly Maticsoft.DAL.BaseInfo.BaseInfo dal = new DAL.BaseInfo.BaseInfo();

          /// <summary>
        /// 获得表信息列表
        /// </summary>
        public DataSet GetList_Table(string tableName, string strWhere)
        {
            return dal.GetList_Table(tableName, strWhere);
        }

        /// <summary>
        /// 获得科室列表
        /// </summary>
        public DataSet GetList_department(string strWhere)
        {
            return dal.GetList_department(strWhere);
        }

        /// <summary>
        /// 获得体检项目列表
        /// </summary>
        public DataSet GetList_itemgroup(string strWhere)
        {
            return dal.GetList_itemgroup(strWhere);
        }

          /// <summary>
        /// 获得字典表列表
        /// </summary>
        /// select * from  commoncode where Category=3 
        public DataSet GetList_CommonCode(string strWhere)
        {
            return dal.GetList_CommonCode(strWhere);

        }

           /// <summary>
        /// 获得体检单位列表
        /// </summary>
        public DataSet GetList_physicaldepartment(string strWhere)
        {
            return dal.GetList_physicaldepartment(strWhere);
        }
    }
}
