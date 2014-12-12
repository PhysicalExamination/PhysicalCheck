using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.SysConfig;

namespace DataAccess.SysConfig {
    
    /// <summary>
    /// 系统参数设置
    /// </summary>
    public class SysParameterDataAccess:BaseDataAccess<SysParameterEntity> {

        #region 构造器

        public SysParameterDataAccess() {
		}

		#endregion

        #region 公共方法

        /// <summary>
        /// 返回系统参数详细细腻些
        /// </summary>
        /// <param name="ParameterName">参数名称</param>
        /// <returns></returns>
        public SysParameterEntity GetSysParameter(String ParameterName) {
            SysParameterEntity Result = Session.Get<SysParameterEntity>(ParameterName);
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 返回所有系统参数信息
        /// </summary>
        /// <returns></returns>
        public List<SysParameterEntity> GetSysParameters() {
            var q = from p in Session.Query<SysParameterEntity>()
                    where p.Enabled == true
                    select p;
            List<SysParameterEntity> Result = q.ToList<SysParameterEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 保存系统参数信息
        /// </summary>
        /// <param name="SysParameter">系统参数实体</param>
        /// <returns></returns>
        public void SaveSysParameter(SysParameterEntity SysParameter) {
            Session.SaveOrUpdate(SysParameter);
            Session.Flush();
            CloseSession();           
        }

        /// <summary>
        /// 删除系统参数
        /// </summary>
        /// <param name="SysParameter">系统参数实体</param>
        /// <returns></returns>
        public void DeleteSysParameter(SysParameterEntity SysParameter) {
            Session.Delete(SysParameter);
            Session.Flush();
            CloseSession();           
        }

        #endregion
    }
}
