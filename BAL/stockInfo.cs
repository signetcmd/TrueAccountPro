using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class stockInfo
    {

        private long myRowId;
        private DateTime myEntryDate;
        private string myEntryTime;
        private string myEntryId;
        private long myEntryNo;
        private long myItemId;
        private long myBarCode;
        private long myGodownId;
        private decimal myInwardQty;
        private decimal myInwardQty2;
        private decimal myOutwardQty;
        private decimal myOutwardQty2;
        private decimal myInwardNetValue;
        private decimal myOutwardNetValue;
        private String myAddDescrip;
        private string myMode;

        public long ourRowId
        {
            get { return myRowId; }
            set { myRowId = value; }
        }

        public DateTime ourEntryDate
        {
            get { return myEntryDate; }
            set { myEntryDate = value; }
        }
        public string ourEntryTime
        {
            get { return myEntryTime; }
            set { myEntryTime = value; }
        }
        public string ourEntryId
        {
            get { return myEntryId; }
            set { myEntryId = value; }
        }
        public long ourEntryNo
        {
            get { return myEntryNo; }
            set { myEntryNo = value; }
        }
        public long ourItemId
        {
            get { return myItemId; }
            set { myItemId = value; }
        }
        public long ourBarCode
        {
            get { return myBarCode; }
            set { myBarCode = value; }
        }
        
        public long ourGodownId
        {
            get { return myGodownId; }
            set { myGodownId = value; }
        }
        public decimal ourInwardQty
        {
            get { return myInwardQty; }
            set { myInwardQty = value; }
        }
        public decimal ourInwardQty2
        {
            get { return myInwardQty2; }
            set { myInwardQty2 = value; }
        }
        public decimal ourOutwardQty
        {
            get { return myOutwardQty; }
            set { myOutwardQty = value; }
        }
        public decimal ourOutwardQty2
        {
            get { return myOutwardQty2; }
            set { myOutwardQty2 = value; }
        }
        public decimal ourInwardNetValue
        {
            get { return myInwardNetValue; }
            set { myInwardNetValue = value; }
        }
        public decimal ourOutwardNetValue
        {
            get { return myOutwardNetValue; }
            set { myOutwardNetValue = value; }
        }
        public string ourAddDescrip
        {
            get { return myAddDescrip; }
            set { myAddDescrip = value; }
        }
        public string ourMode
        {
            get { return myMode; }
            set { myMode = value; }
        }


    }
}
