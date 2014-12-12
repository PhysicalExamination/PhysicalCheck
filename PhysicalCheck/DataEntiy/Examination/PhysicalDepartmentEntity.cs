using System;
using System.ComponentModel;

namespace DataEntity.Examination {

    /// <summary>
    /// 实体类:PhysicalDepartmentEntity
    /// 文件名:PhysicalDepartmentEntity.cs
    /// 说  明:体检单位
    /// </summary>
    public class PhysicalDepartmentEntity:BaseEntity<PhysicalDepartmentEntity> {

        #region 构造方法

        public PhysicalDepartmentEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 单位编号
        /// </summary>		
        public virtual int? DeptID {
            get;
            set;
        }

        /// <summary>
        /// 单位名称
        /// </summary>		
        public virtual string DeptName {
            get;
            set;
        }

        /// <summary>
        /// 单位负责人
        /// </summary>		
        public virtual string Leader {
            get;
            set;
        }

        /// <summary>
        /// 联系电话
        /// </summary>		
        public virtual string LinkTel {
            get;
            set;
        }

        /// <summary>
        /// 传真
        /// </summary>		
        public virtual string Fax {
            get;
            set;
        }

        /// <summary>
        /// 邮政编码
        /// </summary>		
        public virtual string PostCode {
            get;
            set;
        }

        /// <summary>
        /// 通讯地址
        /// </summary>		
        public virtual string Address {
            get;
            set;
        }

        /// <summary>
        /// 开户行
        /// </summary>		
        public virtual string Bank {
            get;
            set;
        }

        /// <summary>
        /// 银行账号
        /// </summary>		
        public virtual string BankAccount {
            get;
            set;
        }

        /// <summary>
        /// 企业性质
        /// </summary>		
        public virtual string Nature {
            get;
            set;
        }

        /// <summary>
        /// 备注
        /// </summary>		
        public virtual string Comment {
            get;
            set;
        }

        /// <summary>
        /// 是否启用
        /// </summary>		
        public virtual bool? Enabled {
            get;
            set;
        }

        #endregion
    }
}