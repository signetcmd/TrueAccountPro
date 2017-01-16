using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class purchaseInfo
    {
        private string myQuery;
        private long myRowId;
        private long myEntryNo;
        private DateTime myEntryDate;
        private string myEntryTime;
        private DateTime myUpdateDate;
        private string myUpdateTime;
        private string myInvoiceNo;
        private DateTime myInvoiceDate;
        private long myAccountId;
        private string mySupplierName;
        private string myAddress;
        private String myMobile;
        private string myDescription;
        private string myTinNo;
        private String myCstNo;
        private string myCFormNo;
        private DateTime myCFromDate;
        private int myNtrOfPurch;
        private DateTime myDeliveryDate;
        private int myFromType;
        private decimal myRoundOff;
        private decimal myGrandTotal;
        private decimal myNetTotal;
        private decimal myAmountPaid;
        private decimal myBalance;
        private decimal myOldBalance;
        private decimal myClosingBalance;
        private decimal myAdjustment;
        private DateTime? myDueDate;
        private long myBarCodeId;
        private long myItemId;
        private string myAddiDescrip;
        private long myUnit;
        private decimal myQty;
        private long myFreeQtyUnit;
        private decimal myFreeQty;
        private decimal myQty2;
        private decimal myTotalQty;
        private decimal myStickerQty;
        private decimal myReturnQty;
        private long myGodownId;
        private long myUserId;

        private decimal myUnitRate;
        private long myUnitId;
        private decimal myDiscPerc;
        private decimal myDisc2;
        private decimal myExiceDutyPerc;
        private decimal myGstPerc;
        private decimal myVatPerc;
        private decimal myCessPerc;
        private decimal myNetValue;
        private decimal myGrndTotal;
        private bool myRoundOffCheck;

        public bool ourRoundOffCheck
        {
            get { return myRoundOffCheck; }
            set { myRoundOffCheck = value; }
        }
        public string ourQuery
        {
            get { return myQuery; }
            set { myQuery = value; }
        }

        public long ourRowId
        {
            get { return myRowId; }
            set { myRowId = value; }
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
        public string ourEntryTime
        {
            get { return myEntryTime; }
            set { myEntryTime = value; }

        }
        public DateTime ourUpdateDate
        {
            get { return myUpdateDate; }
            set { myUpdateDate = value; }

        }
        public string ourUpdateTime
        {
            get { return myUpdateTime; }
            set { myUpdateTime = value; }

        }
        public string ourInvoiceNo
        {
            get { return myInvoiceNo; }
            set { myInvoiceNo = value; }

        }
        public DateTime ourInvoiceDate
        {
            get { return myInvoiceDate; }
            set { myInvoiceDate = value; }

        }
        public long ourAccountId
        {
            get { return myAccountId; }
            set { myAccountId = value; }

        }
        public string ourSupplierName
        {
            get { return mySupplierName; }
            set { mySupplierName = value; }

        }
        public string ourAddress
        {
            get { return myAddress; }
            set { myAddress = value; }

        }
        public String ourMobile
        {
            get { return myMobile; }
            set { myMobile = value; }

        }

        public string ourDescription
        {
            get { return myDescription; }
            set { myDescription = value; }

        }
        public string ourTinNo
        {
            get { return myTinNo; }
            set { myTinNo = value; }

        }
        public String ourCstNo
        {
            get { return myCstNo; }
            set { myCstNo = value; }

        }
        public string ourCFormNo
        {
            get { return myCFormNo; }
            set { myCFormNo = value; }

        }
        public DateTime ourCFromDate
        {
            get { return myCFromDate; }
            set { myCFromDate = value; }

        }
        public int ourNtrOfPurch
        {
            get { return myNtrOfPurch; }
            set { myNtrOfPurch = value; }

        }
        public DateTime ourDeliveryDate
        {
            get { return myDeliveryDate; }
            set { myDeliveryDate = value; }

        }
        public int ourFromType
        {
            get { return myFromType; }
            set { myFromType = value; }

        }
        public decimal ourRoundOff
        {
            get { return myRoundOff; }
            set { myRoundOff = value; }

        }
        public decimal ourGrandTotal
        {
            get { return myGrandTotal; }
            set { myGrandTotal = value; }

        }
        public decimal ourNetTotal
        {
            get { return myNetTotal; }
            set { myNetTotal = value; }

        }
        public decimal ourAmountPaid
        {
            get { return myAmountPaid; }
            set { myAmountPaid = value; }

        }
        public decimal ourBalance
        {
            get { return myBalance; }
            set { myBalance = value; }

        }
        public decimal ourOldBalance
        {
            get { return myOldBalance; }
            set { myOldBalance = value; }

        }
        public decimal ourClosingBalance
        {
            get { return myClosingBalance; }
            set { myClosingBalance = value; }

        }
        public decimal ourAdjustment
        {
            get { return myAdjustment; }
            set { myAdjustment = value; }

        }
        public DateTime? ourDueDate

        {
            get { return myDueDate; }
            set { myDueDate = value; }

        }

        public long ourBarCodeId
        {
            get { return myBarCodeId; }
            set { myBarCodeId = value; }

        }
        public long ourItemId
        {
            get { return myItemId; }
            set { myItemId = value; }

        }

        public string ourAddiDescrip
        {
            get { return myAddiDescrip; }
            set { myAddiDescrip = value; }

        }
        public long ourUnit
        {
            get { return myUnit; }
            set { myUnit = value; }

        }
        public decimal ourQty
        {
            get { return myQty; }
            set { myQty = value; }

        }
        public long ourFreeQtyUnit
        {
            get { return myFreeQtyUnit; }
            set { myFreeQtyUnit = value; }

        }
        public decimal ourFreeQty
        {
            get { return myFreeQty; }
            set { myFreeQty = value; }

        }
        public decimal ourQty2
        {
            get { return myQty2; }
            set { myQty2 = value; }

        }
        public decimal ourTotalQty
        {
            get { return myTotalQty; }
            set { myTotalQty = value; }

        }
        public decimal ourStickerQty
        {
            get { return myStickerQty; }
            set { myStickerQty = value; }

        }

        public decimal ourReturnQty
        {
            get { return myReturnQty; }
            set { myReturnQty = value; }

        }


        public long ourGodownId
        {
            get { return myGodownId; }
            set { myGodownId = value; }

        }

        public long ourUserId
        {
            get { return myUserId; }
            set { myUserId = value; }

        }

        public long ourUnitId
        {
            get { return myUnitId; }
            set { myUnitId = value; }

        }
        public decimal ourUnitRate
        {
            get { return myUnitRate; }
            set { myUnitRate = value; }

        }

        public decimal ourDiscPerc
        {
            get { return myDiscPerc; }
            set { myDiscPerc = value; }

        }
        public decimal ourDisc2
        {
            get { return myDisc2; }
            set { myDisc2 = value; }

        }


        public decimal ourExiceDutyPerc
        {
            get { return myExiceDutyPerc; }
            set { myExiceDutyPerc = value; }

        }

        public decimal ourGstPerc
        {
            get { return myGstPerc; }
            set { myGstPerc = value; }

        }


        public decimal ourVatPerc
        {
            get { return myVatPerc; }
            set { myVatPerc = value; }
        }
        public decimal ourCessPerc
        {
            get { return myCessPerc; }
            set { myCessPerc = value; }
        }
        public decimal ourNetValue
        {
            get { return myNetValue; }
            set { myNetValue = value; }
        }
        public decimal ourGrndTotal
        {
            get { return myGrndTotal; }
            set { myGrndTotal = value; }
        }
    }
}
