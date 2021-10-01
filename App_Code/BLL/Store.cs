using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Pilot.DataAccessLayer;

namespace Pilot.BusinessLogicLayer
{

    /// <summary>
    /// Store 的摘要描述
    /// </summary>
    public class Store
    {

        private int _id;
        private int _areaID;
        private string _areaName;
        private string _name;
        private string _tel;
        private string _address;
        private string _url;
        private bool _isDisplay;
        private int _sortID;
        private string _note;
        

        public Store(int ID, int AreaID, string StoreName, string Tel, string Address, string URL, bool IsDisplay, int SortID,string Note)
        {
            this.ID = ID;
            this.AreaID = AreaID;
            this.StoreName = StoreName;
            this.Tel = Tel;
            this.Address = Address;
            this.URL = URL;
            this.IsDisplay = IsDisplay;
            this.SortID = SortID;
            this.Note = Note;
        }

        public Store()
        {
           
        }
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public int AreaID
        {
            get
            {
                return _areaID;
            }
            set
            {
                _areaID = value;
            }
        }
        public int SortID
        {
            get
            {
                return _sortID;
            }
            set
            {
                _sortID = value;
            }
        }
        

        public string StoreName
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

        public string Tel
        {
            get
            {
                return _tel;
            }
            set
            {
                _tel = value;
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        public string AreaName
        {
            get
            {
                return _areaName;
            }
            set
            {
                _areaName = value;
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
        public string URL
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }

        public string Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
            }
        }

       
        /*** METHODS  ***/
        public bool Remove()
        {

            return Remove(this.ID);
        }

        public bool Save()
        {

             DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            if (ID > 0)
            {

                return DALLayer.UpdateStore(this.ID, this.AreaID, this.StoreName, this.Tel, this.Address, this.URL, this.IsDisplay, this.SortID,this.Note);
            }
            else
            {
                ID = DALLayer.InsertStore(this.AreaID, this.StoreName, this.Tel, this.Address, this.URL, this.IsDisplay, this.SortID,this.Note);
                return (ID > 0);
            }

        }

        /*** METHOD STATIC ***/
        public static bool Remove(int ID)
        {
            if (ID > 0)
            {
                 DataAccess DALLayer = DataAccessHelper.GetDataAccess();
                return DALLayer.RemoveStore(ID);
            }
            else
                return false;
        }

        public static Store GetStoreById(int ID)
        {
            if (ID <= 0)
                return (null);

             DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetStoreById(ID));
        }
        
        public static List<Store> GetStore()
        {
             DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetStore());
        }

        public static List<Store> GetStore(string sortParameter)
        {
             DataAccess DALLayer = DataAccessHelper.GetDataAccess();

            List<Store> storeList = DALLayer.GetStore();

            if (!String.IsNullOrEmpty(sortParameter))
                storeList.Sort(new StoreComparer(sortParameter));

            return (storeList);
        }
    
        public static List<Store> GetDisplayStore()
        {
             DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetDisplayStore());
        }
        public static List<Store> GetDisplayStoreByArea(int AreaID)
        {
             DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetDisplayStoreByArea(AreaID));
        }
        
    }
}