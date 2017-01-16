using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class opStockInfo
    {




        private long myRowId;
        private long myEntryNo;
        private DateTime myEntryDate;
        private string myEntryTime;

        private DateTime myUpdateDate;
        private string myUpdateTime;
         private string myDescription;


        private string myBarCode;
        private long myItemId;
        private long myCompanyId;
        private long myCategoryId;
        private long myModelId;
        private long myBrandId;
        private long myColourId;
        private long mySizeId;
        private long mySupplierId;
        private string myAddiDescrip;
        private string myBatch;
        private DateTime? myExpDate;
        private decimal myQty;
        private decimal myFreeQty;
        private decimal myQty2;
        private decimal myTotalQty;
        private decimal myStickerQty;
        private decimal myUnitRate;
        private decimal myTotalAmount;
        private decimal myDiscPerc;
        private decimal myDiscount;
        private decimal myDiscount2;
        private decimal myGrossValue;
        private decimal myExiceDutyPerc;
        private decimal myExiceDuty;
        private decimal myGstPerc;
        private decimal myGstAmount;
        private decimal myNetValue;
        private decimal myVatPerc;
        private decimal myVatAmount;
        private decimal myCessPerc;
        private decimal myCessAmount;
        private decimal myGrandTotal;
        private decimal myAddCost;
        private decimal myCost;
        private decimal myReatilRatePro;
        private decimal myRetailRate;
        private decimal myMrpPro;
        private decimal myMrp;
        private decimal mySpecialRatePro;
        private decimal mySpecialRate;
        private decimal myWhoeSalePro;
        private decimal myWholeSale;
        private decimal myBranchRatePro;
        private decimal myBranchRate;
        private string myItemBarCode;
        private long myGodownId;

        public long RowId
        {
            get { return myRowId; }
            set { myRowId = value; }

        }

        public long EntryNo
        {
            get { return myEntryNo; }
            set { myEntryNo = value; }

        }
        public DateTime EntryDate
        {
            get { return myEntryDate; }
            set { myEntryDate = value; }

        }
        public string EntryTime
        {
            get { return myEntryTime; }
            set { myEntryTime = value; }

        }
        public DateTime UpdateDate
        {
            get { return myUpdateDate; }
            set { myUpdateDate = value; }

        }
        public string UpdateTime
        {
            get { return myUpdateTime; }
            set { myUpdateTime = value; }

        }
        public  string Description
        {
            get { return myDescription; }
            set { myDescription = value; }

        }

        public string BarCode
        {
            get { return myBarCode; }
            set { myBarCode = value; }

        }
        public long ItemId
        {
            get { return myItemId; }
            set { myItemId = value; }

        }
        public long CompanyId
        {
            get { return myCompanyId; }
            set { myCompanyId = value; }

        }
        public long CategoryId
        {
            get { return myCategoryId; }
            set { myCategoryId = value; }

        }
        public long ModelId
        {
            get { return myModelId; }
            set { myModelId = value; }

        }
        public long BrandId
        {
            get { return myBrandId; }
            set { myBrandId = value; }

        }
        public long ColourId
        {
            get { return myColourId; }
            set { myColourId = value; }

        }
        public long SizeId
        {
            get { return mySizeId; }
            set { mySizeId = value; }

        }
        public long SupplierId
        {
            get { return mySupplierId; }
            set { mySupplierId = value; }

        }
        public string AddiDescrip
        {
            get { return myAddiDescrip; }
            set { myAddiDescrip = value; }

        }
        public string Batch
        {
            get { return myBatch; }
            set { myBatch = value; }

        }
        public DateTime? ExpDate
        {
            get { return myExpDate; }
            set { myExpDate = value; }

        }
        public decimal Qty
        {
            get { return myQty; }
            set { myQty = value; }

        }

        public decimal FreeQty
        {
            get { return myFreeQty; }
            set { myFreeQty = value; }

        }
        public decimal Qty2
        {
            get { return myQty2; }
            set { myQty2 = value; }

        }
        public decimal TotalQty
        {
            get { return myTotalQty; }
            set { myTotalQty = value; }

        }
        public decimal StickerQty
        {
            get { return myStickerQty; }
            set { myStickerQty = value; }

        }
        public decimal UnitRate
        {
            get { return myUnitRate; }
            set { myUnitRate = value; }

        }
        public decimal TotalAmount
        {
            get { return myTotalAmount; }
            set { myTotalAmount = value; }

        }
        public decimal DiscPerc
        {
            get { return myDiscPerc; }
            set { myDiscPerc = value; }

        }
        public decimal Discount
        {
            get { return myDiscount; }
            set { myDiscount = value; }

        }
        public decimal Discount2
        {
            get { return myDiscount2; }
            set { myDiscount2 = value; }

        }
        public decimal GrossValue
        {
            get { return myGrossValue; }
            set { myGrossValue = value; }

        }
        public decimal ExiceDutyPerc
        {
            get { return myExiceDutyPerc; }
            set { myExiceDutyPerc = value; }

        }
        public decimal ExiceDuty
        {
            get { return myExiceDuty; }
            set { myExiceDuty = value; }

        }
        public decimal GstPerc
        {
            get { return myGstPerc; }
            set { myGstPerc = value; }

        }
        public decimal GstAmount
        {
            get { return myGstAmount; }
            set { myGstAmount = value; }

        }
        public decimal NetValue
        {
            get { return myNetValue; }
            set { myNetValue = value; }

        }
        public decimal VatPerc
        {
            get { return myVatPerc; }
            set { myVatPerc = value; }

        }
        public decimal VatAmount
        {
            get { return myVatAmount; }
            set { myVatAmount = value; }

        }
        public decimal CessPerc
        {
            get { return myCessPerc; }
            set { myCessPerc = value; }

        }
        public decimal CessAmount
        {
            get { return myCessAmount; }
            set { myCessAmount = value; }

        }
        public decimal GrandTotal
        {
            get { return myGrandTotal; }
            set { myGrandTotal = value; }

        }
        public decimal AddCost
        {
            get { return myAddCost; }
            set { myAddCost = value; }

        }
        public decimal Cost
        {
            get { return myCost; }
            set { myCost = value; }

        }
        public decimal ReatilRatePro
        {
            get { return myReatilRatePro; }
            set { myReatilRatePro = value; }

        }
        public decimal RetailRate
        {
            get { return myRetailRate; }
            set { myRetailRate = value; }

        }
        public decimal MrpPro
        {
            get { return myMrpPro; }
            set { myMrpPro = value; }

        }
        public decimal Mrp
        {
            get { return myMrp; }
            set { myMrp = value; }

        }
        public decimal SpecialRatePro
        {
            get { return mySpecialRatePro; }
            set { mySpecialRatePro = value; }

        }
        public decimal SpecialRate
        {
            get { return mySpecialRate; }
            set { mySpecialRate = value; }

        }
        public decimal WhoeSalePro
        {
            get { return myWhoeSalePro; }
            set { myWhoeSalePro = value; }

        }
        public decimal WholeSale
        {
            get { return myWholeSale; }
            set { myWholeSale = value; }

        }
        public decimal BranchRatePro
        {
            get { return myBranchRatePro; }
            set { myBranchRatePro = value; }

        }
        public decimal BranchRate
        {
            get { return myBranchRate; }
            set { myBranchRate = value; }

        }
        public string ItemBarCode
        {
            get { return myItemBarCode; }
            set { myItemBarCode = value; }

        }
        public long GodownId
        {
            get { return myGodownId; }
            set { myGodownId = value; }

        }

    }
}
