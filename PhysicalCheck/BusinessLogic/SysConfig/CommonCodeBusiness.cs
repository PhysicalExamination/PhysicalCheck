using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity.SysConfig;
using DataAccess.SysConfig;

namespace BusinessLogic.SysConfig {
    /// <summary>
    /// 业务逻辑类:CommonCodeBusiness
    /// 文  件  名:CommonCodeBusiness.cs
    /// 说      明:公共代码业务逻辑对象
    /// </summary>
    public class CommonCodeBusiness : BaseBusinessLogic<CommonCodeDataAccess> {

        #region 构造器

        public CommonCodeBusiness() {

        }

        #endregion

        #region 公共方法

        public List<CommonCodeEntity> GetFactNatures() {
            return DataAccess.GetCommonCodes("004");
        }

        public List<CommonCodeEntity> GetCommonCodes(String Category) {
            return DataAccess.GetCommonCodes(Category);
        }

        public CommonCodeEntity GetCommonCode(string Code) {
            return DataAccess.GetCommonCode(Code);
        }

        public void SaveCommonCode(CommonCodeEntity CommonCode) {
            DataAccess.SaveCommonCode(CommonCode);
        }

        public void DeleteCommonCode(CommonCodeEntity CommonCode) {
            DataAccess.DeleteCommonCode(CommonCode);
        }

        #endregion
    }
}
