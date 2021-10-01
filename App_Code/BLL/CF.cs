using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Pilot.DataAccessLayer;

namespace Pilot.BusinessLogicLayer
{

    /// <summary>
    /// PilotCF 的摘要描述
    /// </summary>
    public class PilotCF
    {
        private int _ID;
      
        private string _caption;
        private bool _isDisplay;
        private int _sortId;

        public PilotCF(int id, string caption, bool isDisplay, int sortID)
        {
            this.ID = id;

            this.Caption = caption;
            this.IsDisplay = isDisplay;
            this.SortID = sortID;

        }

        public PilotCF()
        {

        }

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
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

            return Remove(this.ID);
        }

        public bool Save()
        {

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            if (ID > 0)
            {

                return DALLayer.UpdateCF(this.ID,  this.Caption, this.IsDisplay, this.SortID);
            }
            else
            {
                ID = DALLayer.InsertCF(  this.Caption, this.IsDisplay, this.SortID);
                return (ID > 0);
            }

        }

        /*** METHOD STATIC ***/
        public static bool Remove(int  ID)
        {
            if (ID > 0)
            {
                DataAccess DALLayer = DataAccessHelper.GetDataAccess();
                return DALLayer.RemoveCF(ID);
            }
            else
                return false;
        }

        public static PilotCF GetCFById(int ID)
        {
            if (ID <= 0)
                return (null);

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetCFById(ID));
        }
       
        public static List<PilotCF> GetCF()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetCF());
        }
        public static List<PilotCF> GetCF(string sortParameter)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();

            List<PilotCF> CFList = DALLayer.GetCF();

            if (!String.IsNullOrEmpty(sortParameter))
                CFList.Sort(new PilotCFComparer(sortParameter));

            return (CFList);
        }
        public static List<PilotCF> GetDisplayCF()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetDisplayCF());
        }
         


    }


    
}