using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.Examination;

namespace DataAccess.Examination {

    /// <summary>
    /// 数据访问类:ItemResultDataAccess
    /// 文  件  名:ItemResultDataAccess.cs
    /// 说      明:体检项目结论数据访问对象
    /// </summary>
    public class ItemResultDataAccess : BaseDataAccess<ItemResultEntity> {

        #region 构造器

        public ItemResultDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取所有体检项目结论数据
        /// </summary>
        public List<ItemResultEntity> GetItemResults(string RegisterNo, int GroupID) {
            var q = from p in Session.Query<ItemResultEntity>()
                    where p.ID.RegisterNo == RegisterNo && p.ID.GroupID==GroupID
                    select p;
            List<ItemResultEntity> Result = q.ToList<ItemResultEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取体检项目结论数据
        /// </summary>
        /// <param name="RegisterNo"></param> 
        /// <param name="GroupID"></param> 
        /// <param name="ItemID"></param> 
        /// <returns>体检项目结论实体</returns>
        public ItemResultEntity GetItemResult(string RegisterNo, int GroupID, int ItemID) {
            ItemResultPK ID = new ItemResultPK { RegisterNo = RegisterNo, GroupID = GroupID, ItemID = ItemID };
            ItemResultEntity Result = Session.Get<ItemResultEntity>(ID);
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 保存体检项目结论数据
        /// </summary>
        /// <param name="ItemResult">体检项目结论实体</param>
        public void SaveItemResult(ItemResultEntity ItemResult) {
            Session.SaveOrUpdate(ItemResult);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除体检项目结论数据
        /// </summary>
        /// <param name="ItemResult">体检项目结论实体</param>
        public void DeleteItemResult(ItemResultEntity ItemResult) {
            Session.Delete(ItemResult);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
