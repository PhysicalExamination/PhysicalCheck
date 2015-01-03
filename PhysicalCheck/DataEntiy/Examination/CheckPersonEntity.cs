using System;
using System.ComponentModel;

namespace DataEntity.Examination {

    /// <summary>
    /// 实体类:CheckPersonEntity
    /// 文件名:CheckPersonEntity.cs
    /// 说  明:体检人员信息
    /// </summary>
    public class CheckPersonEntity:BaseEntity<CheckPersonEntity> {

        #region 构造方法

        public CheckPersonEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 体检人编号
        /// </summary>		
        public virtual int? PersonID {
            get;
            set;
        }

        /// <summary>
        /// 姓名
        /// </summary>		
        public virtual string Name {
            get;
            set;
        }

        /// <summary>
        /// 性别
        /// </summary>		
        public virtual string Sex {
            get;
            set;
        }

        /// <summary>
        /// 身份证号
        /// </summary>		
        public virtual string IDNumber {
            get;
            set;
        }

        /// <summary>
        /// 出生日期
        /// </summary>		
        public virtual DateTime? Birthday {
            get;
            set;
        }

        /// <summary>
        /// 年龄
        /// </summary>		
        public virtual int? Age {
            get;
            set;
        }

        /// <summary>
        /// 工作单位
        /// </summary>		
        public virtual int? DeptID {
            get;
            set;
        }

        /// <summary>
        /// 婚姻
        /// </summary>		
        public virtual string Marriage {
            get;
            set;
        }

        /// <summary>
        /// 职业
        /// </summary>		
        public virtual string Job {
            get;
            set;
        }

        /// <summary>
        /// 学历
        /// </summary>		
        public virtual string Education {
            get;
            set;
        }

        /// <summary>
        /// 民族
        /// </summary>		
        public virtual string Nation {
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
        /// 联系地址
        /// </summary>		
        public virtual string Address {
            get;
            set;
        }

        /// <summary>
        /// 手机
        /// </summary>		
        public virtual string Mobile {
            get;
            set;
        }

        /// <summary>
        /// 电子邮件
        /// </summary>		
        public virtual string EMail {
            get;
            set;
        }

        /// <summary>
        /// 个人照片
        /// </summary>
        public virtual String Photo {
            get;
            set;
        }


        /// <summary>
        /// 工种
        /// </summary>
        public virtual String TradeCode {
            get;
            set;
        }

        /// <summary>
        /// 行业
        /// </summary>
        public virtual int? IndustryID {
            get;
            set;
        }

        /// <summary>
        /// 所属地区
        /// </summary>
        public virtual String RegionCode {
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