using System;
using System.Collections.Generic;


namespace Pilot.BusinessLogicLayer
{

    /// <summary>
    /// ColorComparer 的摘要描述
    /// </summary>
    public class ColorComparer : IComparer<Color>
    {
        private string _sortColumn;
        private bool _reverse;


        public ColorComparer(string sortEx)
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
        public bool Equals(Color x, Color y)
        {
            if (x.ColorID == y.ColorID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Compare(Color x, Color y)
        {
            int retVal = 0;
            switch (_sortColumn.Trim())
            {

                case "ColorID":
                    retVal = (x.ColorID - y.ColorID);
                    break;
                
                case "Name":
                    retVal = String.Compare(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "ColorCode":
                    retVal = String.Compare(x.ColorCode, y.ColorCode, StringComparison.InvariantCultureIgnoreCase);
                    break;
               
            }
            return (retVal * (_reverse ? -1 : 1));
        }

        
    }
}