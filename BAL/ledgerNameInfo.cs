using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ledgerNameInfo
    {
        //ledger name variables
        private long myLedgerId;
        private long myGroupId;
        private String myLedgerCode;
        private String myLedgerName;
        private String myAlternateName;
        private decimal myOpBal;
        private bool myOpBalType;
        private string myDescription;
        private bool myIsLedgerActive;

        // ledger address variables
        private string myAddress1;
        private string myAddress2;
        private string myAddress3;
        private string myPinCode;
        private string myPhoneNo;
        private String myMobileNo;
        private string myFax;
        private long myPost;
        private long myPlace;
        private long myArea;
        private long myDistrict;
        private long myState;
        private string myEmail;
        private string myWeb;

        //ledger registration
        private String myTinNo;
        private DateTime myTinDate;
        private string myCstNo;
        private DateTime myCstDate;
        private string myPanNo;
        private DateTime myPanDate;
        private string myPanRefNo;
        private string myTaxDeductionNo;
        private DateTime myTaxDeductionDate;
        private string myServiceTaxNo;
        private DateTime myServiceTaxDate;
        private string myLuxuryTaxNo;
        private DateTime myLuxuryTaxDate;
        private string myImportExportCode;
        private DateTime myImportExportDate;

        //ledger other details

        private long myDueDays;
        private long myRoute;
        private long mySalesRate;
        private long myCategory;
        private string myNatureOfPur;
        private string myNatureOfSale;
        private decimal myMinBalance;
        private decimal myCreditLimit;
        private long myRep;
        private long myType;
        private decimal myDisAmount;
        private bool myIsPrintOB;

        private string myTermsAndCondition;
        private string myBankName;
        private string myBankAccountName;
        private string myAccountNo;
        private string myBranchName;
        private string myIfscCode;
        private string mySwiftCode;
        private string myBSR;
        private string myAccountType;
        private string myMisc1;
        private string myyMisc2;

        private DateTime? myToDate;
        private string myToTime;

        private byte[] myLedgerImage;
      
        public long LedgerIdInt
        {
            get { return myLedgerId; }
            set { myLedgerId = value; }
        }
        public long GroupIdInt
        {
            get { return myGroupId; }
            set { myGroupId = value; }
        }

        public String LedgerCodeStr
        {
            get { return myLedgerCode; }
            set { myLedgerCode = value; }
        }

        public String LedgerNameStr
        {
            get { return myLedgerName; }
            set { myLedgerName = value; }
        }
        public String AlternateNameStr
        {
            get { return myAlternateName; }
            set { myAlternateName = value; }
        }
        public decimal OpeningBalDec
        {
            get { return myOpBal; }
            set { myOpBal = value; }
        }
        public bool OpBalTypeBol
        {
            get { return myOpBalType; }
            set { myOpBalType = value; }
        }
        public string DescriptionStr
        {
            get { return myDescription; }
            set { myDescription = value; }
        }
        public bool IsLedgerActive
        {
            get { return myIsLedgerActive; }
            set { myIsLedgerActive = value; }
        }

        //ledger address
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

        public string Address3
        {
            get { return myAddress3; }
            set { myAddress3 = value; }

        }
        public string PinCode
        {
            get { return myPinCode; }
            set { myPinCode = value; }

        }
        public string PhoneNo
        {
            get { return myPhoneNo; }
            set { myPhoneNo = value; }

        }
        public string MobileNo
        {
            get { return myMobileNo; }
            set { myMobileNo = value; }

        }
        public string Fax
        {
            get { return myFax; }
            set { myFax = value; }

        }

        public long Post
        {
            get { return myPost; }
            set { myPost = value; }

        }
        public long Place
        {
            get { return myPlace; }
            set { myPlace = value; }

        }
        public long Area
        {
            get { return myArea; }
            set { myArea = value; }

        }
        public long District
        {
            get { return myDistrict; }
            set { myDistrict = value; }

        }
        public long State
        {
            get { return myState; }
            set { myState = value; }

        }
        public string Email
        {
            get { return myEmail; }
            set { myEmail = value; }

        }
        public string Web
        {
            get { return myWeb; }
            set { myWeb = value; }

        }
        public String TinNo
        {
            get { return myTinNo; }
            set { myTinNo = value; }
        }


        public DateTime TinDate
        {
            get { return myTinDate; }
            set { myTinDate = value; }

        }
        public string CstNo
        {
            get { return myCstNo; }
            set { myCstNo = value; }

        }
        public DateTime CstDate
        {
            get { return myCstDate; }
            set { myCstDate = value; }

        }
        public string PanNo
        {
            get { return myPanNo; }
            set { myPanNo = value; }

        }
        public DateTime PanDate
        {
            get { return myPanDate; }
            set { myPanDate = value; }

        }
        public string PanRefNo
        {
            get { return myPanRefNo; }
            set { myPanRefNo = value; }

        }
        public string TaxDeductionNo
        {
            get { return myTaxDeductionNo; }
            set { myTaxDeductionNo = value; }

        }
        public DateTime TaxDeductionDate
        {
            get { return myTaxDeductionDate; }
            set { myTaxDeductionDate = value; }

        }
        public string ServiceTaxNo
        {
            get { return myServiceTaxNo; }
            set { myServiceTaxNo = value; }

        }
        public DateTime ServiceTaxDate
        {
            get { return myServiceTaxDate; }
            set { myServiceTaxDate = value; }

        }
        public string LuxuryTaxNo
        {
            get { return myLuxuryTaxNo; }
            set { myLuxuryTaxNo = value; }

        }
        public DateTime LuxuryTaxDate
        {
            get { return myLuxuryTaxDate; }
            set { myLuxuryTaxDate = value; }

        }
        public string ImportExportCode
        {
            get { return myImportExportCode; }
            set { myImportExportCode = value; }

        }
        public DateTime ImportExportDate
        {
            get { return myImportExportDate; }
            set { myImportExportDate = value; }

        }

        public long DueDays
        {
            get { return myDueDays; }
            set { myDueDays = value; }

        }
        public long Route
        {
            get { return myRoute; }
            set { myRoute = value; }

        }
        public long SalesRate
        {
            get { return mySalesRate; }
            set { mySalesRate = value; }

        }
        public long Category
        {
            get { return myCategory; }
            set { myCategory = value; }

        }
        public string NatureOfPur
        {
            get { return myNatureOfPur; }
            set { myNatureOfPur = value; }

        }
        public string NatureOfSale
        {
            get { return myNatureOfSale; }
            set { myNatureOfSale = value; }

        }
        public decimal MinBalance
        {
            get { return myMinBalance; }
            set { myMinBalance = value; }

        }
        public decimal CreditLimit
        {
            get { return myCreditLimit; }
            set { myCreditLimit = value; }

        }
        public long Rep
        {
            get { return myRep; }
            set { myRep = value; }

        }
        public long Type
        {
            get { return myType; }
            set { myType = value; }

        }
        public decimal DisAmount
        {
            get { return myDisAmount; }
            set { myDisAmount = value; }

        }
        public bool IsPrintOB
        {
            get { return myIsPrintOB; }
            set { myIsPrintOB = value; }

        }
        public string TermsAndCondition
        {
            get { return myTermsAndCondition; }
            set { myTermsAndCondition = value; }

        }
        public string BankName
        {
            get { return myBankName; }
            set { myBankName = value; }

        }
        public string BankAccountName
        {
            get { return myBankAccountName; }
            set { myBankAccountName = value; }

        }
        public string AccountNo
        {
            get { return myAccountNo; }
            set { myAccountNo = value; }

        }
        public string BranchName
        {
            get { return myBranchName; }
            set { myBranchName = value; }

        }
        public string IfscCode
        {
            get { return myIfscCode; }
            set { myIfscCode = value; }

        }
        public string SwiftCode
        {
            get { return mySwiftCode; }
            set { mySwiftCode = value; }

        }
        public string BSR
        {
            get { return myBSR; }
            set { myBSR = value; }

        }
        public string AccountType
        {
            get { return myAccountType; }
            set { myAccountType = value; }

        }
        public string Misc1
        {
            get { return myMisc1; }
            set { myMisc1 = value; }

        }
        public string Misc2
        {
            get { return myyMisc2; }
            set { myyMisc2 = value; }

        }
        public byte[] LedgerImage

        {
            get { return myLedgerImage; }
            set { myLedgerImage = value; }
        }

        public DateTime? ToDate
        {
            get { return myToDate; }
            set { myToDate = value; }

        }
        public string ToTime
        {
            get { return myToTime; }
            set { myToTime = value; }

        }
    }

}
