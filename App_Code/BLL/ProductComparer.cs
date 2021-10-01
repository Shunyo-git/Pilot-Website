using System;
using System.Collections.Generic;


namespace Pilot.BusinessLogicLayer
{

    /// <summary>
    /// EventComparer 的摘要描述
    /// </summary>
    public class ProductComparer : IComparer<Product>
    {
        private string _sortColumn;
        private bool _reverse;


        public ProductComparer(string sortEx)
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
        public bool Equals(Product x, Product y)
        {
            if (x.ProductID == y.ProductID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Compare(Product x, Product y)
        {
            int retVal = 0;
            switch (_sortColumn.Trim())
            {

                case "ProductID":
                    retVal = (x.ProductID - y.ProductID);
                    break;
                case "SortID":
                    retVal = (x.SortID - y.SortID);
                    break;
                case "CategoryID":
                    retVal = (x.CategoryID - y.CategoryID);
                    break;
                case "Name":
                    retVal = String.Compare(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "Description":
                    retVal = String.Compare(x.Description, y.Description, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "Price":
                    retVal = String.Compare(x.Price, y.Price, StringComparison.InvariantCultureIgnoreCase);
                    break;
            
                case "IsDisplay":
                    retVal =  Convert.ToInt32(x.IsDisplay) -  Convert.ToInt32(y.IsDisplay);
                    break;

                //case "ReleaseDate":
                //    System.TimeSpan TS = new System.TimeSpan(x.DisplayDate.Ticks - y.DisplayDate.Ticks);
                //    retVal = Convert.ToInt32(TS.TotalDays);
                //    break;
            }
            return (retVal * (_reverse ? -1 : 1));
        }

        
    }
}