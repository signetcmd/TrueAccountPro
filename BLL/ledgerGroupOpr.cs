using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BEL;
using DAL;

namespace BEL
{
  public class ledgerGroupOpr
    {
         DbTask myDbTas = new DbTask();
        public void insertLedgerGroup(ledgerGroupInfo myLedgerGroupInfo)
        {
            object[,] groupArg = new object[3, 2]
            {
                {"@parentId",myLedgerGroupInfo.ParentGroupId },//Parent
                { "@groupName",myLedgerGroupInfo .GroupName},//Group Name
                { "@groupDescription", myLedgerGroupInfo .Description }//Description
            };

            //myDbTas.ExecuteNonQuery_SP("insert_ledger_group", groupArg);
        }
        public void updateLedgerGroup(ledgerGroupInfo myLedgerGroupInfo)
        {
            object[,] groupArg = new object[4, 2]
            {
                {"@groupId",myLedgerGroupInfo.GroupId },//Parent
                {"@parentId",myLedgerGroupInfo.ParentGroupId },//Parent
                { "@groupName",myLedgerGroupInfo .GroupName},//Group Name
                { "@groupDescription", myLedgerGroupInfo .Description }//Description
            };

            //myDbTas.ExecuteNonQuery_SP("update_ledger_group", groupArg);
        }
        public DataSet selectAllSubGroupDetails()
        {
            DataSet allGroups = myDbTas.ExecuteQuery_SP("select_all_ledger_sub_group_details");
            return allGroups;
        }
        public DataSet selectAllParentGroupDetails()
        {
            DataSet allGroups = myDbTas.ExecuteQuery_SP("select_all_ledger_main_group_details");
            return allGroups;
        }
        public DataSet selectAllParentAndSubGroupDetails()
        {
            DataSet allGroups = myDbTas.ExecuteQuery_SP("select_all_ledger_sub_and_main_group_details");
            return allGroups;
        }
        public void deleteLedgerGroup(ledgerGroupInfo myLedgerGroupInfo)
        {
            object[,] groupArg = new object[1, 2]
            {
                {"@quary_varc", myLedgerGroupInfo.Query}
            };

            //myDbTas.ExecuteNonQuery_SP("execute_simple_queries", groupArg);
        }
        public DataSet selectAGroupDetailsByName(ledgerGroupInfo myLedgerGroupInfo)
        {
            object[,] groupArg = new object[1, 2]
           {
                {"@group_name_vach",myLedgerGroupInfo.GroupName}
           };
            DataSet aGroup = myDbTas.ExecuteQuery_SP("select_a_ledger_group_details_by_name",groupArg);
            return aGroup;
        }
        public DataSet selectAllParentGroupDetailsByGroupType(ledgerGroupInfo myLedgerGroupInf)
        {

            object[,] groupArg = new object[1, 2]
           {
                {"@group_type_int",myLedgerGroupInf.GroupType}
           };
            DataSet allGroups = myDbTas.ExecuteQuery_SP("select_all_ledger_main_group_details_by_group_type", groupArg);
            return allGroups;
        }
        public DataSet selectASubGroupDetailsByParentId(ledgerGroupInfo myLedgerGroupInf)
        {

            object[,] groupArg = new object[1, 2]
           {
                {"@parent_id_int",myLedgerGroupInf.ParentGroupId}
           };
            DataSet allGroups = myDbTas.ExecuteQuery_SP("select_all_ledger_group_details_by_parent_id", groupArg);
            return allGroups;
        }
    }
}
