using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity.SysConfig;
using DataAccess.SysConfig;

namespace BusinessLogic.SysConfig {
   
    /// <summary>
    /// 业务逻辑类:CommonResultBusiness
    /// 文  件  名:CommonResultBusiness.cs
    /// 说      明:常见体检结果业务逻辑对象
    /// </summary>
    public class CommonResultBusiness : BaseBusinessLogic<CommonResultDataAccess> {

        #region 构造器

        public CommonResultBusiness() {

        }

        #endregion

        #region 公共方法

        public List<CommonResultEntity> GetCommonResults(int pageIndex, int pageSize, int DeptID, out int RecordCount) {
            return DataAccess.GetCommonResults(pageIndex,pageSize,DeptID,out RecordCount);
        }

        public CommonResultEntity GetCommonResult(int ItemID, int ResultID) {
            return DataAccess.GetCommonResult(ItemID, ResultID);
        }

        public void SaveCommonResult(CommonResultEntity CommonResult) {
            DataAccess.SaveCommonResult(CommonResult);
        }

        public void DeleteCommonResult(CommonResultEntity CommonResult) {
            DataAccess.DeleteCommonResult(CommonResult);
        }

        #endregion
    }
}
