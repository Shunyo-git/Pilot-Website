using System;
using System.Collections.Generic;


namespace Pilot.BusinessLogicLayer
{

    /// <summary>
    /// MessageComparer 的摘要描述
    /// </summary>
    public class MessageComparer : IComparer<Message>
    {
        private string _sortColumn;
        private bool _reverse;


        public MessageComparer(string sortEx)
        {
            if (!String.IsNullOrEmpty(sortEx))
            {
                _reverse = sortEx.ToLowerInvariant().EndsWith(" desc");
                if (_reverse)
                    _sortColumn = sortEx.Substring(0, sortEx.Length - 5);
                else
                    _sortColumn = sortEx;
            }
        }
        public bool Equals(Message x, Message y)
        {
            if (x.MsgID == y.MsgID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Compare(Message x, Message y)
        {
            int retVal = 0;
            switch (_sortColumn.Trim())
            {

                case "MsgID":
                    retVal = (x.MsgID - y.MsgID);
                    break;
                case "Name":
                    retVal = String.Compare(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "Email":
                    retVal = String.Compare(x.Email, y.Email, StringComparison.InvariantCultureIgnoreCase);
                    break;

                case "IsDone":
                    retVal = Convert.ToInt32(x.IsDone) - Convert.ToInt32(y.IsDone);
                    break;

                case "CreationDate":
                    retVal = DateTime.Compare(x.CreationDate, y.CreationDate);
                    break;
                case "UpdateDate":
                    retVal = DateTime.Compare(x.UpdateDate, y.UpdateDate);
                    break;
            }
            return (retVal * (_reverse ? -1 : 1));
        }


    }
}