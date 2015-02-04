using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LISDataService {

    public class LISBusiness:IDisposable {

        private LISDataAccess m_DataAccess;

        public LISBusiness() {
        }

        public List<LisEntity> GetLisDatas() {
            return m_DataAccess.GetLisDatas();
        }

        public List<LisEntity> GetLisDatas(String RegisterNo) {
            return m_DataAccess.GetLisDatas(RegisterNo);
        }

        public List<LisEntity> GetLisDatas(String RegisterNo, String GroupID) {
            return m_DataAccess.GetLisDatas(RegisterNo, GroupID);
        }



        public void Dispose() {
            m_DataAccess.Dispose();
            m_DataAccess = null;
        }
    }
}
