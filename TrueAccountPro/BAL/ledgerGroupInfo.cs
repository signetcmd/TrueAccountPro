using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueAccountPro
{
    class ledgerGroupInfo
    {
        private long myGroupId;
        private string myGroupName;
        private long myParentGroupID;
        private string myDescription;
        private bool myIsParent;
        public int myGroupType;
       

        public long GroupId
        {
            get { return myGroupId; }
            set { myGroupId = value; }
        }
        public string  GroupName
        {
            get { return myGroupName; }
            set { myGroupName = value; }
        }
        public long ParentGroupId
        {
            get { return myParentGroupID ; }
            set { myParentGroupID = value; }
        }
        public string  Description
        {
            get { return myDescription; }
            set { myDescription = value; }
        }
        public bool IsParent
        {
            get { return myIsParent ; }
            set { myIsParent  = value; }
        }
        public int GroupType
        {
            get { return myGroupType; }
            set { myGroupType = value; }
        }
    }
}
