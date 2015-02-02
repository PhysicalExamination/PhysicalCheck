using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Examination;
using DataEntity.Examination;

namespace BusinessLogic.Examination {

    public class LISBusiness : BaseBusinessLogic<LISDataAccess> {

        public LISBusiness() {
        }

        public List<LisEntity> GetLisDatas() {
            return DataAccess.GetLisDatas();
        }

        public List<LisEntity> GetLisDatas(String RegisterNo) {
            return DataAccess.GetLisDatas(RegisterNo);
        }

        public List<LisEntity> GetLisDatas(String RegisterNo, String GroupID) {
            return DataAccess.GetLisDatas(RegisterNo, GroupID);
        }


    }
}
