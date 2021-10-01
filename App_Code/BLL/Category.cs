using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Pilot.DataAccessLayer;

namespace Pilot.BusinessLogicLayer
{

    /// <summary>
    /// Category 的摘要描述
    /// </summary>
    public class Category
    {
        private int _categoryID;
        private int _mainId;
        private string _name;
        private bool _isDisplay;
        private int _sortId;

        public Category(int categoryID, int mainID, string name, bool isDisplay, int SortID)
        {
            this.CategoryID = categoryID;
            this.MainID = mainID;
            this.Name = name;
            this.IsDisplay = isDisplay;
            this.SortID = SortID;

        }

        public Category()
        {

        }

        public int CategoryID
        {
            get
            {
                return _categoryID;
            }
            set
            {
                _categoryID = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int MainID
        {
            get
            {
                return _mainId;
            }
            set
            {
                _mainId = value;
            }
        }
        public bool IsDisplay
        {
            get
            {
                return _isDisplay;
            }
            set
            {
                _isDisplay = value;
            }
        }
        public int SortID
        {
            get
            {
                return _sortId;
            }
            set
            {
                _sortId = value;
            }
        }

        /*** METHODS  ***/
        public bool Remove()
        {

            return Remove(this.CategoryID);
        }

        public bool Save()
        {

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            if (CategoryID > 0)
            {

                return DALLayer.UpdateCategory(this.CategoryID, this.MainID, this.Name, this.IsDisplay, this.SortID);
            }
            else
            {
                CategoryID = DALLayer.InsertCategory(this.MainID, this.Name, this.IsDisplay, this.SortID);
                return (CategoryID > 0);
            }

        }

        /*** METHOD STATIC ***/
        public static bool Remove(int CategoryID)
        {
            if (CategoryID > 0)
            {
                DataAccess DALLayer = DataAccessHelper.GetDataAccess();
                return DALLayer.RemoveCategory(CategoryID);
            }
            else
                return false;
        }

        public static Category GetCategoryById(int CategoryID)
        {
            if (CategoryID <= 0)
                return (null);

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetCategoryById(CategoryID));
        }
        public static Category GetFirstDisplayCategory()
        {

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetFirstDisplayCategory());
        }
        public static List<Category> GetCategory()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetCategory());
        }
        public static List<Category> GetCategory(string sortParameter)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();

            List<Category> categoryList = DALLayer.GetCategory();

            if (!String.IsNullOrEmpty(sortParameter))
                categoryList.Sort(new CategoryComparer(sortParameter));

            return (categoryList);
        }
        public static List<Category> GetDisplayCategory()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetDisplayCategory());
        }
         


    }


    
}