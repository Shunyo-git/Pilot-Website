using System;
using System.Collections.Generic;


namespace Pilot.BusinessLogicLayer
{

    /// <summary>
    /// CFComparer 的摘要描述
    /// </summary>
    public class PilotStarComparer : IComparer<PilotStar>
    {
        private string _sortColumn;
        private bool _reverse;


        public PilotStarComparer(string sortEx)
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
        public bool Equals(PilotStar x, PilotStar y)
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

        public int Compare(PilotStar x, PilotStar y)
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
                case "Url":
                    retVal = String.Compare(x.Url, y.Url, StringComparison.InvariantCultureIgnoreCase);
                    break;
                 
            }
            return (retVal * (_reverse ? -1 : 1));
        }

        
    }
}