using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BEL
{
    public class ledgerNameOpr
    {
        DbTask myDbTask = new DbTask();
        public long insertLedgerNameDetails(ledgerNameInfo myLedgerNameInfo)
        {
            object[,] ledgerArg = new object[8, 2]
            {
                 {"@group_id_int",myLedgerNameInfo.GroupIdInt},
                 {"@ledger_code_varc",myLedgerNameInfo.LedgerCodeStr},
                 {"@ledger_name_varc",myLedgerNameInfo.LedgerNameStr},
                 {"@alternate_name_varc",myLedgerNameInfo.AlternateNameStr},
                 {"@op_balance_mny" ,myLedgerNameInfo.OpeningBalDec},
                 {"@balance_type_bit",myLedgerNameInfo.OpBalTypeBol },
                 {"@description_varc",myLedgerNameInfo.DescriptionStr},
                {"@is_active_bit",myLedgerNameInfo.IsLedgerActive }

            };

            DataSet ledgerDetails = myDbTask.ExecuteQuery_SP("insert_ledger_names", ledgerArg, true);
            return Convert.ToInt64(ledgerDetails.Tables[0].Rows[0][0].ToString());

        }
        public bool insertLedgerAddressDetails(ledgerNameInfo myLedgerNameInfo)
        {
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","insert into tblLedgerAddress(ledger_id, address_1, address_2, address_3, pincode, phone_no, mobile_no, fax, post, place, area, district, state, email, website)" +
                  "values('" + Convert.ToInt32(myLedgerNameInfo.LedgerIdInt) + "','" + myLedgerNameInfo.Address1 + "','" + myLedgerNameInfo.Address2 + "','"
                  + myLedgerNameInfo.Address3 + "','" + myLedgerNameInfo.PinCode + "','" + myLedgerNameInfo.PhoneNo + "','" + myLedgerNameInfo.MobileNo + "','" + myLedgerNameInfo.Fax + "','"
                  + myLedgerNameInfo.Post + "','" + myLedgerNameInfo.Place + "','" + myLedgerNameInfo.Area + "','" + myLedgerNameInfo.District + "','" + myLedgerNameInfo.State + "','"
                  + myLedgerNameInfo.Email + "','" + myLedgerNameInfo.Web + "')"}


            };

          return   myDbTask.ExecuteNonQuery_SP("execute_simple_queries", ledgerArg,false );


        }
        public bool insertLedgerRegistrationDetails(ledgerNameInfo myLedgerNameInfo)
        {
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","insert into tblLedgerRegistration (ledger_id, tin_no, tin_date, cst_no, cst_date, pan_no, pan_date, pan_ref_no, tax_deduction_no, tax_deduction_date, service_tax_reg_no, service_tax_reg_date, luxury_tax_reg_no, luxury_tax_reg_date, import_export_code, import_export_date)" +
                  "values('"+ myLedgerNameInfo.LedgerIdInt +"','"+ myLedgerNameInfo.TinNo +"','"+ myLedgerNameInfo.TinDate +"','"+myLedgerNameInfo.CstNo +"','"+  myLedgerNameInfo.CstDate+"','"+myLedgerNameInfo.PanNo  +"','"+ myLedgerNameInfo.PanDate +"','"+ myLedgerNameInfo.PanRefNo +"','"+ myLedgerNameInfo.TaxDeductionNo +
                  "','"+ myLedgerNameInfo.TaxDeductionDate +"','"+ myLedgerNameInfo.ServiceTaxNo +"','"+  myLedgerNameInfo.ServiceTaxDate+"','"+ myLedgerNameInfo.LuxuryTaxNo +"','"+myLedgerNameInfo.LuxuryTaxDate  +"','"+ myLedgerNameInfo.ImportExportCode +"','"+ myLedgerNameInfo.ImportExportDate +"')" }

            };

            return myDbTask.ExecuteNonQuery_SP("execute_simple_queries", ledgerArg, false);


        }
        public bool insertLedgerOtherDetails(ledgerNameInfo myLedgerNameInfo)
        {
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","insert into tblLedgerOtherDetails (ledger_id, due_days, route, sales_rate, category, nature_of_purchase, nature_of_sale, minimum_balance, credit_limit, represantative, type_of_customer, sales_discount, is_print_ob)" +
                  "values('"+ myLedgerNameInfo.LedgerIdInt +"','"+ myLedgerNameInfo.DueDays +"','"+ myLedgerNameInfo.Route +"','"+myLedgerNameInfo.SalesRate +"','"+  myLedgerNameInfo.Category+"','"+myLedgerNameInfo.NatureOfPur  +"','"+ myLedgerNameInfo.NatureOfSale +"','"+ myLedgerNameInfo.MinBalance +"','"+ myLedgerNameInfo.CreditLimit +
                  "','"+ myLedgerNameInfo.Rep +"','"+ myLedgerNameInfo.Type +"','"+  myLedgerNameInfo.DisAmount+"','"+ myLedgerNameInfo.IsPrintOB +"')" }

            };

           return myDbTask.ExecuteNonQuery_SP("execute_simple_queries", ledgerArg,false);


        }
        public bool insertTermsAndCondition(ledgerNameInfo myLedgerNameInfo)
        {
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","insert into tblLedgerTandC (ledger_id,terms_and_conditions)" +
                  "values('"+ myLedgerNameInfo.LedgerIdInt +"','"+ myLedgerNameInfo.TermsAndCondition +"')" }

            };

           return myDbTask.ExecuteNonQuery_SP("execute_simple_queries", ledgerArg,false);


        }
        public bool insertLedgerBankDetials(ledgerNameInfo myLedgerNameInfo)
        {
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","insert into tblLedgerBank (ledger_id, bank_name, account_name, account_no, branch_name, ifsc, swift, bsr, account_type, misc1, misc2)" +
                  "values('"+ myLedgerNameInfo.LedgerIdInt +"','"+ myLedgerNameInfo.BankName +"','"+ myLedgerNameInfo.BankAccountName +"','"+ myLedgerNameInfo.AccountNo  +
                  "','"+ myLedgerNameInfo.BranchName +"','"+ myLedgerNameInfo.IfscCode +"','"+ myLedgerNameInfo.SwiftCode +"','"+ myLedgerNameInfo.BSR +
                  "','"+ myLedgerNameInfo.AccountType +"','"+ myLedgerNameInfo.Misc1 +"','"+ myLedgerNameInfo.Misc2 +"')" }

            };

           return myDbTask.ExecuteNonQuery_SP("execute_simple_queries", ledgerArg,false);


        }
        public bool insertLedgerImage(ledgerNameInfo myLedgerNameInfo)
        {
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","insert into tblLedgerImage (ledger_id, ledger_image)" +
                  "values('"+ myLedgerNameInfo.LedgerIdInt +"','"+ myLedgerNameInfo.LedgerImage +"')" }

            };

          return  myDbTask.ExecuteNonQuery_SP("execute_simple_queries", ledgerArg,false);


        }
        public DataSet selectAllLedgerNameByGroupId(ledgerNameInfo myLedgerNameInfo)
        {

            object[,] ledgerArg = new object[1, 2]
            {
                 {"@group_id_int",myLedgerNameInfo.GroupIdInt},

            };

            DataSet ledgerDetails = myDbTask.ExecuteQuery_SP("select_all_ledger_name_details_by_group_id", ledgerArg);
            return ledgerDetails;

        }
        public DataSet selectLedgerNameAndIdByGroupId(ledgerNameInfo myLedgerNameInfo)
        {

            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","select ledger_id,ledger_code,ledger_name,alternate_name from tblLedgerNames where group_id="+myLedgerNameInfo.GroupIdInt},

            };

            DataSet ledgerDetails = myDbTask.ExecuteQuery_SP("execute_simple_queries", ledgerArg);
            return ledgerDetails;

        }
        public DataSet selectCashAccAndLedgerByGroupId(ledgerNameInfo myLedgerNameInfo)
        {

            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","select ledger_id,ledger_code,ledger_name,alternate_name from tblLedgerNames where tblLedgerNames.ledger_id=42 or group_id="+myLedgerNameInfo.GroupIdInt},

            };

            DataSet ledgerDetails = myDbTask.ExecuteQuery_SP("execute_simple_queries", ledgerArg);
            return ledgerDetails;

        }
        public DataSet selectBasicDetailsOfALedgerById(ledgerNameInfo myLedgerNameInfo)
        {

            object[,] ledgerArg;

            if (myLedgerNameInfo.ToDate != null)
            {
                ledgerArg = new object[3, 2]
                {
                {"@ledger_id",myLedgerNameInfo.LedgerIdInt },
                {"@to_date ",myLedgerNameInfo.ToDate },
                {"@to_time" ,myLedgerNameInfo.ToDate }
                };
            }
            else
            {
                ledgerArg = new object[3, 2]
               {
                {"@ledger_id",myLedgerNameInfo.LedgerIdInt },
                {"@to_date ",DBNull.Value},
                {"@to_time" ,DBNull.Value }
               };
            }
            DataSet ledgerDetails = myDbTask.ExecuteQuery_SP("select_al_ledger_name_and_cash_balance_by_ledger_id", ledgerArg);
            return ledgerDetails;

        }
        public DataSet selectAllLedgerNameDetails()
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","select ledger_id,fixed,ledger_code,ledger_name,alternate_name,op_balance,balance_type,description,is_active from tblLedgerNames"}
              

            };

            DataSet ledgerDetails = myDbTask.ExecuteQuery_SP("execute_simple_queries", ledgerArg);
            return ledgerDetails;

        }
        public DataSet selectAllSundryCreditorsDetails()
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","select ledger_id,fixed,ledger_code,ledger_name,alternate_name,op_balance,balance_type,description,is_active from tblLedgerNames where group_id=39"}


            };

            DataSet ledgerDetails = myDbTask.ExecuteQuery_SP("execute_simple_queries", ledgerArg);
            return ledgerDetails;

        }
        public DataSet selectALedgerNameDetailsById(ledgerNameInfo myLedgerNameInf)
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","SELECT [ledger_id],[group_id],[fixed],[ledger_code],[ledger_name],[alternate_name],[op_balance],[balance_type],[description],[is_active] FROM tblLedgerNames where ledger_id='"+myLedgerNameInf.LedgerIdInt +"'" }


            };

            DataSet ledgerDetails = myDbTask.ExecuteQuery_SP("execute_simple_queries", ledgerArg);
            return ledgerDetails;

        }
        public DataSet selectALedgerAddressDetailsById(ledgerNameInfo myLedgerNameInf)
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","SELECT * FROM tblLedgerAddress where ledger_id='"+myLedgerNameInf.LedgerIdInt +"'" }


            };

            DataSet ledgerDetails = myDbTask.ExecuteQuery_SP("execute_simple_queries", ledgerArg);
            return ledgerDetails;

        }
        public DataSet selectALedgerRegDetailsById(ledgerNameInfo myLedgerNameInf)
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","SELECT * FROM tblLedgerRegistration where ledger_id='"+myLedgerNameInf.LedgerIdInt +"'" }


            };

            DataSet ledgerDetails = myDbTask.ExecuteQuery_SP("execute_simple_queries", ledgerArg);
            return ledgerDetails;

        }
        public DataSet selectALedgerOtherDetailsById(ledgerNameInfo myLedgerNameInf)
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","SELECT * FROM tblLedgerOtherDetails where ledger_id='"+myLedgerNameInf.LedgerIdInt +"'" }


            };

            DataSet ledgerDetails = myDbTask.ExecuteQuery_SP("execute_simple_queries", ledgerArg);
            return ledgerDetails;

        }
        public DataSet selectALedgerTermsAndCondById(ledgerNameInfo myLedgerNameInf)
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","SELECT * FROM tblLedgerTandC where ledger_id='"+myLedgerNameInf.LedgerIdInt +"'" }


            };

            DataSet ledgerDetails = myDbTask.ExecuteQuery_SP("execute_simple_queries", ledgerArg);
            return ledgerDetails;

        }
        public DataSet selectALedgerBankDetailsById(ledgerNameInfo myLedgerNameInf)
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","SELECT * FROM tblLedgerBank where ledger_id='"+myLedgerNameInf.LedgerIdInt +"'" }


            };

            DataSet ledgerDetails = myDbTask.ExecuteQuery_SP("execute_simple_queries", ledgerArg);
            return ledgerDetails;

        }
        public DataSet selectALedgerImageDetailsById(ledgerNameInfo myLedgerNameInf)
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","SELECT * FROM tblLedgerImage where ledger_id='"+myLedgerNameInf.LedgerIdInt +"'" }


            };

            DataSet ledgerDetails = myDbTask.ExecuteQuery_SP("execute_simple_queries", ledgerArg);
            return ledgerDetails;

        }
        public void  deleteALedgerNameDetailsById(ledgerNameInfo myLedgerNameInf)
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","delete FROM tblLedgerNames where ledger_id='"+myLedgerNameInf.LedgerIdInt +"'" }


            };

            myDbTask.ExecuteQuery_SP("execute_simple_queries", ledgerArg);
          

        }
        public bool deleteALedgerAddressDetailsById(ledgerNameInfo myLedgerNameInf)
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","delete FROM tblLedgerAddress where ledger_id='"+myLedgerNameInf.LedgerIdInt +"'" }


            };

           return myDbTask.ExecuteNonQuery_SP("execute_simple_queries", ledgerArg,false);
         

        }
        public bool deleteALedgerRegDetailsById(ledgerNameInfo myLedgerNameInf)
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","delete FROM tblLedgerRegistration where ledger_id='"+myLedgerNameInf.LedgerIdInt +"'" }


            };

          return  myDbTask.ExecuteNonQuery_SP("execute_simple_queries", ledgerArg,false);
          

        }
        public bool deleteALedgerOtherDetailsById(ledgerNameInfo myLedgerNameInf)
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","delete FROM tblLedgerOtherDetails where ledger_id='"+myLedgerNameInf.LedgerIdInt +"'" }


            };

           return  myDbTask.ExecuteNonQuery_SP("execute_simple_queries", ledgerArg,false);
       

        }
        public bool deleteALedgerTermsAndCondById(ledgerNameInfo myLedgerNameInf)
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","delete FROM tblLedgerTandC where ledger_id='"+myLedgerNameInf.LedgerIdInt +"'" }


            };

          return  myDbTask.ExecuteNonQuery_SP("execute_simple_queries", ledgerArg,false);
          

        }
        public bool  deleteALedgerBankDetailsById(ledgerNameInfo myLedgerNameInf)
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","delete FROM tblLedgerBank where ledger_id='"+myLedgerNameInf.LedgerIdInt +"'" }


            };

        return  myDbTask.ExecuteNonQuery_SP("execute_simple_queries", ledgerArg,false);
         

        }
        public bool deleteALedgerImageDetailsById(ledgerNameInfo myLedgerNameInf)
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","delete FROM tblLedgerImage where ledger_id='"+myLedgerNameInf.LedgerIdInt +"'" }


            };

            return myDbTask.ExecuteNonQuery_SP("execute_simple_queries", ledgerArg,false);
            

        }
        public DataSet selectALedgerNameDetailsByName(ledgerNameInfo myLedgerNameInf)
        {
            //primary details means code,ledgername,ledger alternarnate name
            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","SELECT [ledger_id],[group_id],[fixed],[ledger_code],[ledger_name],[alternate_name],[op_balance],[balance_type],[description],[is_active] FROM tblLedgerNames where ledger_name='"+myLedgerNameInf.LedgerNameStr+"'" }


            };

            DataSet ledgerDetails = myDbTask.ExecuteQuery_SP("execute_simple_queries", ledgerArg);
            return ledgerDetails;

        }
        public bool updateLedgerNameDetails(ledgerNameInfo myLedgerNameInf)
        {

            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","Update tblLedgerNames set group_id='" + myLedgerNameInf.GroupIdInt  +"',ledger_code='" + myLedgerNameInf.LedgerCodeStr  +"',ledger_name='" + myLedgerNameInf.LedgerNameStr +"',alternate_name='" + myLedgerNameInf.AlternateNameStr  +"',op_balance='" + myLedgerNameInf.OpeningBalDec  +"',balance_type='" + myLedgerNameInf.OpBalTypeBol +"',description='" + myLedgerNameInf.DescriptionStr +"',is_active= '" + myLedgerNameInf.IsLedgerActive +"' where ledger_id= '" + myLedgerNameInf.LedgerIdInt +"'" }


            };

         return myDbTask.ExecuteNonQuery_SP("execute_simple_queries", ledgerArg,false);


        }
        public void deleteLedgerNameDetails(ledgerNameInfo myLedgerNameInf)
        {

            object[,] ledgerArg = new object[1, 2]
            {
                 {"@quary_varc","delete from tblLedgerNames where ledger_id= '" + myLedgerNameInf.LedgerIdInt +"'" }


            };

            //myDbTask.ExecuteNonQuery_SP("execute_simple_queries", ledgerArg);


        }
    }
}
