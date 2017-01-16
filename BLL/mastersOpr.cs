using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using BEL;

namespace BLL
{
   public class mastersOpr
    {
        DbTask mydbtas = new DbTask();
        public bool insertMastersDetails(mastersInfo mstrs)
        {
            object[,] arg = new object[1, 2]
            {
             
                { "@quary_varc",mstrs.Query},
                };
           return   mydbtas.ExecuteNonQuery_SP("execute_simple_queries", arg, false);


        }
        public void updateMasterDetails(mastersInfo msInfo)
        {
            object[,] masterArg = new object[1, 2]
            {
                {"@quary_varcupdate",msInfo.queryUpdateStr},//Post update
               
            };
            //mydbtas.ExecuteNonQuery_SP("update_simple_queries", masterArg);

        }
        public DataSet selectAllMasterDetails(mastersInfo mstrs)
        {
            object[,] postInserts = new object[1, 2]
            {

                { "@quary_varc",mstrs.Query},
                };
            DataSet allDetails= mydbtas.ExecuteQuery_SP("execute_simple_queries", postInserts);
            return allDetails;


        }
        public void deleteMasterDetails(mastersInfo msDInfo)
        {
            object[,] masterArg = new object[1, 2]
            {
                {"@quary_varc",msDInfo.Query }
            };
            //mydbtas.ExecuteNonQuery_SP("execute_simple_queries", masterArg);

        }
        public DataSet selectAllMasterSeletedDetails(mastersInfo msInfoDetails)
        {
            object[,] masterArgSeleted = new object[1, 2]
            {
                {"@quaey_varc",msInfoDetails.queryStr},
            };
            DataSet selectedData = mydbtas.ExecuteQuery_SP("execute_simple_queries", masterArgSeleted);
            return selectedData;
        }
         public void insertadditionalcharges(mastersInfo msInfo)
        {
            object[,] productInserts = new object[1, 2]
            {
                ////
                
                { "@quary_varc","insert into [dbo].[tblAdditionalCharges](Additional_Charge1, Additional_Charge2,Additional_Charge3,Additional_Charge4,legderAccout1,legderAccout2,legderAccout3,legderAccout4) values ('"+msInfo.AdditionalCharge1+"','" + msInfo.AdditionalCharge2+ "','" +msInfo.AdditionalCharge3 + "','" +msInfo.AdditionalCharge4 + "','" +msInfo.legderAccout1+ "','" + msInfo.legderAccout2+ "','" + msInfo.legderAccout3+"','" + msInfo.legderAccout4+"')"},
    
                };
            //mydbtas.ExecuteNonQuery_SP("execute_simple_queries", productInserts);


        }
        public void insertGodownMasterDetails(mastersInfo msInfo)
        {
            object[,] productInserts = new object[1, 2]
            {
                ////
                
                { "@quary_varc","insert into [dbo].[tblGodown](godown_code,godown_name, addrerss_1, address_2, manager, mobile, phone, description, active) values('" + msInfo.GodownCode +  "','" + msInfo.GodownName +  "','" + msInfo.Address1 +  "','" + msInfo.Address2 +  "','" + msInfo.Manager +  "','" + msInfo.Mobile +  "','" + msInfo.Phone +  "','" + msInfo.Description +  "','" + msInfo.Active +  "')"}


                };
            //mydbtas.ExecuteNonQuery_SP("execute_simple_queries", productInserts);


        }
        public void updateGodownMasterDetails(mastersInfo msInfo)
        {
            object[,] productInserts = new object[1, 2]
            {
                ////
                
                { "@quary_varc","update tblGodown set godown_code='" + msInfo.GodownCode +  "',godown_name='" + msInfo.GodownName +  "',addrerss_1='" + msInfo.Address1 +  "',address_2='" + msInfo.Address2 +  "',manager='" + msInfo.Manager +  "',mobile='" + msInfo.Mobile +  "', phone='" + msInfo.Phone +  "',description='" + msInfo.Description +  "',active='" + msInfo.Active +  "' where godown_id='" + msInfo.GodownId +  "'"}


                };
            //mydbtas.ExecuteNonQuery_SP("execute_simple_queries", productInserts);


        }

    }
}
