using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class mastersInfo
    {

        private string myQueryStr;
        private long myPost_id;
        private string myPost_name;
        private long myMasterId;
        private string myQueryUpdateStr;
        private string myQuery;

        /// <summary>
        /// Additional_Charges
        /// </summary>
        /// 
        private string myAdditionalCharge1;
        private string myAdditionalCharge2;
        private string myAdditionalCharge3;
        private string myAdditionalCharge4;
        private long mylegderAccout1;
        private long mylegderAccout2;
        private long mylegderAccout3;
        private long mylegderAccout4;

        //Godown Master
        private long myGodownId;
        private string myGodownCode;
        private string myGodownName;
        private string myAddress1;
        private string myAddress2;
        private string myManager;
        private string myMobile;
        private string myPhone;
        private string myDescription;
        private bool myActive;


        public string AdditionalCharge1
        {
            get { return myAdditionalCharge1; }
            set { myAdditionalCharge1 = value; }
        }
        public string AdditionalCharge2
        {
            get { return myAdditionalCharge2; }
            set { myAdditionalCharge2 = value; }
        }
        public string AdditionalCharge3
        {
            get { return myAdditionalCharge3; }
            set { myAdditionalCharge3 = value; }
        }
        public string AdditionalCharge4
        {
            get { return myAdditionalCharge4; }
            set { myAdditionalCharge4 = value; }
        }
        public long MasterId
        {
            get { return myMasterId; }
            set { myMasterId = value; }
        }

        public string queryUpdateStr
        {
            get { return myQueryUpdateStr; }
            set { myQueryUpdateStr = value; }
        }
        public long legderAccout1
        {
            get { return mylegderAccout1; }
            set { mylegderAccout1 = value; }
        }
        public long legderAccout2
        {
            get { return mylegderAccout2; }
            set { mylegderAccout2 = value; }
        }
        public long legderAccout3
        {
            get { return mylegderAccout3; }
            set { mylegderAccout3 = value; }
        }
        public long legderAccout4
        {
            get { return mylegderAccout4; }
            set { mylegderAccout4 = value; }
        }
        public long post_id
        {
            get { return myPost_id; }
            set { myPost_id = value; }
        }
        public string queryStr
        {
            get { return myQueryStr; }
            set { myQueryStr = value; }
        }
        public string Query
        {
            get { return myQuery; }
            set { myQuery = value; }
        }
        public string GodownCode
        {
            get { return myGodownCode; }
            set { myGodownCode = value; }
        }
       
        //Godown


        public long GodownId
        {
            get { return myGodownId; }
            set { myGodownId = value; }
        }
        public string GodownName
        {
            get { return myGodownName; }
            set { myGodownName = value; }
        }
        public string Address1
        {
            get { return myAddress1; }
            set { myAddress1 = value; }
        }
        public string Address2
        {
            get { return myAddress2; }
            set { myAddress2 = value; }
        }
        public string Manager
        {
            get { return myManager; }
            set { myManager = value; }
        }
        public string Mobile
        {
            get { return myMobile; }
            set { myMobile = value; }
        }
        public string Phone
        {
            get { return myPhone; }
            set { myPhone = value; }
        }
        public string Description
        {
            get { return myDescription; }
            set { myDescription = value; }
        }
        public bool Active
        {
            get { return myActive; }
            set { myActive = value; }
        }
    }
}
