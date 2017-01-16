using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class cashLedgerInfo
    {


        private String myEntryIdentity;
        private long myEntryNo;
        public string myVoucherNo;
        private DateTime myEntryDate;
        private string myEntryTime;
        private long myAccountId;
        private decimal myDebit;
        private decimal myCredit;
        private int myGroupId;

 
        public String ourEntryIdentity
        {
            get { return myEntryIdentity; }
            set { myEntryIdentity = value; }

        }
        public long ourEntryNo
        {
            get { return myEntryNo; }
            set { myEntryNo = value; }

        }
        public DateTime ourEntryDate
        {
            get { return myEntryDate; }
            set { myEntryDate = value; }

        }
        public string ourVoucherNo {
            get { return myVoucherNo; }
            set { myVoucherNo = value; }
        }
        public string ourEntryTime
        {
            get { return myEntryTime; }
            set { myEntryTime = value; }

        }
        public long ourAccountId
        {
            get { return myAccountId; }
            set { myAccountId = value; }

        }
        public decimal ourDebit
        {
            get { return myDebit; }
            set { myDebit = value; }

        }
        public decimal ourCredit
        {
            get { return myCredit; }
            set { myCredit = value; }

        }
        public int ourGroupId
        {
            get { return myGroupId; }
            set { myGroupId = value; }

        }
    }
}
