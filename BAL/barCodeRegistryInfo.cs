using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
   public class barCodeRegistryInfo
    {
        private long myBarCodeId;
        private string myBarCode;
        private long myItemId;
        private long myCompanyId;
        private long myCategoryId;
        private long myModelId;
        private long myBrandId;
        private long myColourId;
        private long mySizeId;
        private long myUnitId;
        private DateTime? myExpDate;
        private string myBatch;
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
        private string myEntryId;
        private long myEntryNo;
        private long myCount;
        private string mySearchText;
        public string ourSearchText
        {
            get { return mySearchText; }
            set { mySearchText = value; }
        }
        public long ourUnitId
        {
            get { return myUnitId; }
            set { myUnitId = value; }
        }
        public long ourBarCodeId
        {
            get { return myBarCodeId; }
            set { myBarCodeId = value; }
        }
        public string ourBarCode
        {
            get { return myBarCode; }
            set { myBarCode = value; }

        }
        public long ourItemId
        {
            get { return myItemId; }
            set { myItemId = value; }

        }
        public long ourCompanyId
        {
            get { return myCompanyId; }
            set { myCompanyId = value; }

        }
        public long ourCategoryId
        {
            get { return myCategoryId; }
            set { myCategoryId = value; }

        }
        public long ourModelId
        {
            get { return myModelId; }
            set { myModelId = value; }

        }
        public long ourBrandId
        {
            get { return myBrandId; }
            set { myBrandId = value; }

        }
        public long ourColourId
        {
            get { return myColourId; }
            set { myColourId = value; }

        }
        public long ourSizeId
        {
            get { return mySizeId; }
            set { mySizeId = value; }

        }
    
      public string ourBatch
        {
            get { return myBatch; }
            set { myBatch = value; }
        }
        public DateTime? ourExpDate
        {
            get { return myExpDate; }
            set { myExpDate = value; }
        }
        public decimal ourAddCost
        {
            get { return myAddCost; }
            set { myAddCost = value; }
        }
        public decimal ourCost
        {
            get { return myCost; }
            set { myCost = value; }
        }
        public decimal ourReatilRatePro
        {
            get { return myReatilRatePro; }
            set { myReatilRatePro = value; }
        }
        public decimal ourRetailRate
        {
            get { return myRetailRate; }
            set { myRetailRate = value; }
        }
        public decimal ourMrpPro
        {
            get { return myMrpPro; }
            set { myMrpPro = value; }
        }
        public decimal ourMrp
        {
            get { return myMrp; }
            set { myMrp = value; }
        }
        public decimal ourSpecialRatePro
        {
            get { return mySpecialRatePro; }
            set { mySpecialRatePro = value; }
        }
        public decimal ourSpecialRate
        {
            get { return mySpecialRate; }
            set { mySpecialRate = value; }
        }
        public decimal ourWhoeSalePro
        {
            get { return myWhoeSalePro; }
            set { myWhoeSalePro = value; }
        }
        public decimal ourWholeSale
        {
            get { return myWholeSale; }
            set { myWholeSale = value; }
        }
        public decimal ourBranchRatePro
        {
            get { return myBranchRatePro; }
            set { myBranchRatePro = value; }
        }
        public decimal ourBranchRate
        {
            get { return myBranchRate; }
            set { myBranchRate = value; }
        }
        public string ourItemBarCode
        {
            get { return myItemBarCode; }
            set { myItemBarCode = value; }
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
        public long ourCount
        {
            get { return myCount; }
            set { myCount = value; }
        }
    }
}
