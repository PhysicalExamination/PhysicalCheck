using System;
using System.ComponentModel;

namespace DataEntity.SysConfig {

    /// <summary>
    /// 实体类:HospitalEntity
    /// 文件名:HospitalEntity.cs
    /// 说  明:医院信息
    /// </summary>
    public class HospitalEntity:BaseEntity<HospitalEntity> {

        #region 构造方法

        public HospitalEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 医院编号
        /// </summary>		
        public virtual int? HospitalID {
            get;
            set;
        }

        /// <summary>
        /// 医院名称
        /// </summary>		
        public virtual string HospitalName {
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
        /// 网站
        /// </summary>		
        public virtual string Website {
            get;
            set;
        }

        /// <summary>
        /// 地址
        /// </summary>		
        public virtual string Address {
            get;
            set;
        }

        /// <summary>
        /// 微博
        /// </summary>		
        public virtual string Blog {
            get;
            set;
        }

        /// <summary>
        /// 微信
        /// </summary>		
        public virtual string WeChat {
            get;
            set;
        }

        /// <summary>
        /// 徽标
        /// </summary>		
        public virtual string Logo {
            get;
            set;
        }

        #endregion
    }
}