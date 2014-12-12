using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.SysConfig;

namespace DataAccess.SysConfig {
    /// <summary>
    /// 数据访问类:CommonCodeDataAccess
    /// 文  件  名:CommonCodeDataAccess.cs
    /// 说      明:公共代码数据访问对象
    /// </summary>
    public class CommonCodeDataAccess : BaseDataAccess<CommonCodeEntity> {

        #region 构造器

        public CommonCodeDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取公共代码数据
        /// </summary>
        public List<CommonCodeEntity> GetCommonCodes(String Category) {
            var q = from p in Session.Query<CommonCodeEntity>()
                    where p.Category == Category
                    select p;
            List<CommonCodeEntity> Result = q.ToList<CommonCodeEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取公共代码数据
        /// </summary>
        /// <param name="Code"></param> 
        /// <returns>公共代码实体</returns>
        public CommonCodeEntity GetCommonCode(string Code) {
            CommonCodeEntity Result = Session.Get<CommonCodeEntity>(Code);
            CloseSession();
            return Result;

        }

        /// <summary>
        /// 保存公共代码数据
        /// </summary>
        /// <param name="CommonCode">公共代码实体</param>
        public void SaveCommonCode(CommonCodeEntity CommonCode) {           
            Session.SaveOrUpdate(CommonCode);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除公共代码数据
        /// </summary>
        /// <param name="CommonCode">公共代码实体</param>
        public void DeleteCommonCode(CommonCodeEntity CommonCode) {
            Session.Delete(CommonCode);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
