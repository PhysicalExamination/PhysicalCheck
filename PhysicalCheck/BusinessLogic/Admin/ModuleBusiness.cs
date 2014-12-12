using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataEntity.Admin;
using DataAccess.Admin;


namespace BusinessLogic.Admin {

	/// <summary>
	/// 业务逻辑类:ModuleBusiness
	/// 文  件  名:ModuleBusiness.cs
	/// 说      明:系统模块业务逻辑对象
	/// </summary>
	public class ModuleBusiness : BaseBusinessLogic<ModuleDataAccess> {

		#region 构造器

		public ModuleBusiness() {

		}

		#endregion

		#region 公共方法

		/// <summary>
		///获取系统模块所有数据
		/// </summary>
		public List<ModuleEntity> GetModules() {
			return DataAccess.GetModules();
		}

		/// <summary>
		///获取系统模块所有数据
		///<param name="parentModuleNo">父模块编号</param>
		/// </summary>
		public List<ModuleEntity> GetModules(String parentModuleNo) {
			return DataAccess.GetModules(parentModuleNo);
		}

		/// <summary>
		/// 分页查询应用系统的所有模块
		/// </summary>
		/// <param name="pageIndex">当前第几页</param>
		/// <param name="pageSize">每页显示几条</param>        
		/// <param name="RecordCount">总记录数</param>
		/// <returns></returns>
		public List<ModuleEntity> GetModules(int pageIndex, int pageSize, out int RecordCount) {
			return DataAccess.GetModules(pageIndex, pageSize, out RecordCount);
		}
		/// <summary>
		/// 获取系统模块数据
		/// </summary>
		/// <param name="ModuleNo">模块编号</param> 
		/// <returns>系统模块实体</returns>
		public ModuleEntity GetModule(string ModuleNo) {
			return DataAccess.GetModule(ModuleNo);
		}

		/// <summary>
		/// 保存系统模块数据
		/// </summary>
		/// <param name="Module">系统模块实体</param>        
		/// <returns>成功保存的行数</returns>
		public int SaveModule(ModuleEntity Module) {
			return DataAccess.SaveModule(Module);
		}

		/// <summary>
		/// 删除系统模块数据
		/// </summary>
		/// <param name="Module">系统模块实体</param>        
		/// <returns>删除的数据行数</returns>
		public int DeleteModule(ModuleEntity Module) {
			return DataAccess.DeleteModule(Module);

		#endregion
		}
	}

}
