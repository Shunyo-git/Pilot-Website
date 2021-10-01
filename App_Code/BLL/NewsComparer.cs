using System;
using System.Collections.Generic;
using Pilot.DataAccessLayer;

namespace Pilot.BusinessLogicLayer
{

 
    /// <summary>
    /// NewsComparer 的摘要描述
    /// </summary>
    public class NewsComparer : IComparer<News>
    {
        private string _sortColumn;
        private bool _reverse;


        public NewsComparer(string sortEx)
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
        public bool Equals(News x, News y)
        {
            if (x.ID == y.ID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Compare(News x, News y)
        {
            int retVal = 0;
            switch (_sortColumn.Trim())
            {
                case "ID":
                    retVal = (x.ID - y.ID);
                    break;
                case "Caption":
                    retVal = String.Compare(x.Caption, y.Caption, StringComparison.InvariantCultureIgnoreCase);
                    break;              
                case "IsApproved":
                    retVal = Convert.ToInt32(x.IsApproved) - Convert.ToInt32(y.IsApproved);
                    break;
                case "IsMainPageDisplay":
                    retVal = Convert.ToInt32(x.IsMainPageDisplay) - Convert.ToInt32(y.IsMainPageDisplay);
                    break;
                case "CreationDate":
                    retVal = DateTime.Compare(x.CreationDate, y.CreationDate);
                    break;
            }
            return (retVal * (_reverse ? -1 : 1));
        }


    }
}