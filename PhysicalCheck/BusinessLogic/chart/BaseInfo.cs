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


    }
}
