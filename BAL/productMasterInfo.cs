using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
    {

   public  class productMasterInfo
     {
        private string myqueryStrSc;
        private long myProductId;
        private string myProductName;
        private string myProduct_code;
        private string myAlternatename;
        private string myAdditionaldescription;
        private string myBarCode;
        private string myQuery;


        private long myproductGroupName;
        private long myProductCompanyName;
        private long myproductCategoryName;
        private long myModelName;
        private long myBrandName;
        

        private decimal myRateofTaxSale;
        private decimal myRateofTaxPurchase;
        private decimal myRateofCess;
        private int myCommodityCode;
        private decimal myExiceDuty;
        private int myGST;

        private string myStockType;
        private decimal myMinStock;
        private decimal myMaxStock;
        private int myReorderLevel;

        private decimal myDimension;
        private decimal myVolume;
        private decimal myWeight;
        private long myUnit;

        private string myUnitNo;
        private decimal myFactor;
        private decimal myDiscQty;
        private decimal myPurchaseRate;
        private decimal myPurchaseDisc;
        private decimal myMrp;
        private decimal myMrpDisc;
        private decimal myRetail;
        private decimal myRetailDisc;
        private decimal mySpecialRate;
        private decimal mySpecialDisc;
        private decimal myWholeSale;
        private decimal myWholeSaleDisc;
        private decimal myBranchRate;
        private decimal myBranchDisc;


        private decimal myPurchaseDiscount;
        private decimal mySalesDiscount;
        private decimal mySpecialDiscount;
        private decimal myAgentCommission;


        public decimal PurchaseDiscount
        {
            get { return myPurchaseDiscount; }
            set { myPurchaseDiscount = value; }
        }
        public decimal SalesDiscount
        {
            get { return mySalesDiscount; }
            set { mySalesDiscount = value; }
        }
        public decimal SpecialDiscount
        {
            get { return mySpecialDiscount; }
            set { mySpecialDiscount = value; }
        }
        public decimal AgentCommission
        {
            get { return myAgentCommission; }
            set { myAgentCommission = value; }
        }
        public string UnitNo
        {
            get { return myUnitNo; }
            set { myUnitNo = value; }
        }
        public decimal Factor
        {

            get { return myFactor; }
            set { myFactor = value; }
        }
        public decimal DiscQty
        {
            get { return myDiscQty; }
            set { myDiscQty = value; }
        }
        public decimal PurchaseRate
        {
            get { return myPurchaseRate; }
            set { myPurchaseRate = value; }
        }
        public decimal PurchaseDisc
        {
            get { return myPurchaseDisc; }
            set { myPurchaseDisc = value; }
        }
        public decimal Mrp
        {
            get { return myMrp; }
            set { myMrp = value; }
        }
        public decimal MrpDisc
        {
            get { return myMrpDisc; }
            set { myMrpDisc = value; }
        }
        public decimal Retail
        {
            get { return myRetail; }
            set { myRetail = value; }
        }
        public decimal RetailDisc
        {
            get { return myRetailDisc; }
            set { myRetailDisc = value; }
        }
        public decimal SpecialRate
        {
            get { return mySpecialRate; }
            set { mySpecialRate = value; }
        }
        public decimal SpecialDisc
        {
            get { return mySpecialDisc; }
            
            set { mySpecialDisc = value; }
        }
        public decimal WholeSale   
        {
            get { return myWholeSale; }
            set { myWholeSale = value; }
        }
        public decimal WholeSaleDisc    
        {
            get { return myWholeSaleDisc; }
            set { myWholeSaleDisc = value; }
        }
        public decimal BranchRate
        {
            get { return myBranchRate; }
            set { myBranchRate = value; }
        }
        public decimal BranchDisc
        {
            get { return myBranchDisc; }
            set { myBranchDisc = value; }
        }


        public long Unit
        {
            get { return myUnit; }
            set { myUnit = value; }
        }
        public decimal Dimension
        {
            get { return myDimension; }
            set { myDimension = value; }
        }
        public decimal Volume
        {
            get { return myVolume; }
            set { myVolume = value; }
        }
        public decimal Weight
        {
            get { return myWeight; }
            set { myWeight = value; }
        }
        public string StockType
        {
            get { return myStockType; }
            set { myStockType = value; }
        }
        public decimal MinStock
        {
            get { return myMinStock; }
            set { myMinStock = value; }
        }
        public decimal MaxStock
        {
            get { return myMaxStock; }
            set { myMaxStock = value; }
        }
        public int ReOrderLevel
        {
            get { return myReorderLevel; }
            set { myReorderLevel = value; }
        }

        public decimal RateofTaxSale
        {
            get { return myRateofTaxSale; }
            set { myRateofTaxSale = value; }
        }
        public decimal RateofTaxPurchase
        {
            get { return myRateofTaxPurchase; }
            set { myRateofTaxPurchase = value; }
        }
        public decimal RateofCess
        {
            get { return myRateofCess; }
            set { myRateofCess = value; }

        }
        public int CommodityCode
        {
            get { return myCommodityCode; }
            set { myCommodityCode = value; }
        }
        public decimal ExiceDuty
        {
            get { return myExiceDuty; }
            set { myExiceDuty = value; }
        }
        public int GST
        {
            get { return myGST; }
            set { myGST = value; }
        }

        public long ProductGroupid
        {
            get { return myproductGroupName; }
            set { myproductGroupName = value; }
        }
        public long ProductCompanyId
        {
            get { return myProductCompanyName; }
            set { myProductCompanyName = value; }
        }
        public long ProductCategoryId
        {
            get { return myproductCategoryName; }
            set { myproductCategoryName = value; }
        }
        public long ModelId
        {
            get { return myModelName; }
            set { myModelName = value; }
        }
        public long BrandId
        {
            get { return myBrandName; }
            set { myBrandName = value; }
        }
        public string queryStrProduct
        {
            get { return myqueryStrSc; }
            set { myqueryStrSc = value; }
        }
        public long ProductId
        {
            get { return myProductId; }
            set { myProductId = value; }

        }
        public string ProductName
        {
            get { return myProductName; }
            set { myProductName = value; }
        }
        public string ProductCode
        {
            get { return myProduct_code; }
            set { myProduct_code = value; }
        }
        public string Alternate_name
        {
            get { return myAlternatename; }
            set { myAlternatename  = value; }
        }
        public string Additionaldescription
        {
            get { return myAdditionaldescription; }
            set { myAdditionaldescription = value; }
        }
        public string BarCode
        {
            get { return myBarCode; }
            set { myBarCode = value; }
        }
        public string Query
        {
            get { return myQuery; }
            set { myQuery = value; }
        }



    }
}
