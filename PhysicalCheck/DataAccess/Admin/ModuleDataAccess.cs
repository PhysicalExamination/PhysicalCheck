using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity.Admin;
using NHibernate.Linq;
using NHibernate;

namespace DataAccess.Admin {


	public class ModuleDataAccess : BaseDataAccess<ModuleEntity> {

		#region 构造器

		public ModuleDataAccess() {

		}

		#endregion

		#region 公共方法

		/// <summary>
		///获取系统模块所有数据
		/// </summary>
		public List<ModuleEntity> GetModules() {
			List<ModuleEntity> Result = (from m in Session.Query<ModuleEntity>()
										 where m.ParentModuleNo == "Root"
										 select m).ToList<ModuleEntity>();
			CloseSession();
			return Result;
		}

		/// <summary>
		///获取系统模块所有数据
		///<param name="parentModuleNo">父模块编号</param>
		/// </summary>
		public List<ModuleEntity> GetModules(String parentModuleNo) {
			List<ModuleEntity> Result = (from m in Session.Query<ModuleEntity>()
										 where m.ParentModuleNo == parentModuleNo
										 orderby m.OrderNo
										 select m).ToList<ModuleEntity>();
			CloseSession();
			return Result;
		}

		/// <summary>
		/// 分页查询应用系统的所有模块
		/// </summary>
		/// <param name="pageIndex">当前第几页</param>
		/// <param name="pageSize">每页显示几条</param>        
		/// <param name="RecordCount">总记录数</param>
		/// <returns></returns>
		public List<ModuleEntity> GetModules(int pageIndex, int pageSize, out int RecordCount) {			
			String hql = "select count(*) from SysUserEntity";
			IQuery query = Session.CreateQuery(hql);
			object obj = query.UniqueResult();
			int.TryParse(obj.ToString(), out RecordCount);

			List<ModuleEntity> Result = Session.CreateQuery(" from ModuleEntity")
											   .SetFirstResult((pageIndex - 1) * pageSize)
											   .SetMaxResults(pageSize)
											   .List<ModuleEntity>().ToList<ModuleEntity>();
			CloseSession();
			return Result;
		}

		/// <summary>
        /// 获取系统模块数据
        /// </summary>
        /// <param name="ModuleNo">模块编号</param> 
        /// <returns>系统模块实体</returns>
		public ModuleEntity GetModule(string ModuleNo) {
			ModuleEntity Result = Session.Get<ModuleEntity>(ModuleNo);
			CloseSession();
			return Result;
		}

		/// <summary>
        /// 保存系统模块数据
        /// </summary>
        /// <param name="Module">系统模块实体</param>        
        /// <returns>成功保存的行数</returns>
		public int SaveModule(ModuleEntity Module) {
			if (String.IsNullOrEmpty(Module.ModuleNo)) Module.ModuleNo = GetLineID("Module")+"";
			Session.SaveOrUpdate(Module);
			Session.Flush();
			CloseSession();
			return 1;
		}

		/// <summary>
        /// 删除系统模块数据
        /// </summary>
        /// <param name="Module">系统模块实体</param>        
        /// <returns>删除的数据行数</returns>
		public int DeleteModule(ModuleEntity Module) {
			Session.Delete(Module);
			Session.Flush();
			CloseSession();
			return 1;
		}

		#endregion
	}
}
