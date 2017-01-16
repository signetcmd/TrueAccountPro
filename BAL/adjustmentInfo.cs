using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class adjustmentInfo
    {


        private long myEntryNo;
        private string myEntryId;
        private long myAccountId;
        private string myParticular;
        private int myAddOrMinus;
        private decimal myPercentage;
        private decimal myAmount;

        public long ourEntryNo
     
        {
            get { return myEntryNo; }
            set { myEntryNo = value; }
        }
        public string ourEntryId
           
        {
            get { return myEntryId; }
            set { myEntryId = value; }
        }
        public long ourAccountId
             
        {
            get { return myAccountId; }
            set { myAccountId = value; }
        }
        public string ourParticular
             
        {
            get { return myParticular; }
            set { myParticular = value; }
        }
        public int ourAddOrMinus
            
        {
            get { return myAddOrMinus; }
            set { myAddOrMinus = value; }
        }
        public decimal ourPercentage
             
        {
            get { return myPercentage; }
            set { myPercentage = value; }
        }
        public decimal ourAmount
             
        {
            get { return myAmount; }
            set { myAmount = value; }
        }



    }
}
