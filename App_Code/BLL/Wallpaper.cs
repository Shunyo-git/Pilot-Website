using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Pilot.DataAccessLayer;

namespace Pilot.BusinessLogicLayer
{

    /// <summary>
    /// Wallpaper 的摘要描述
    /// </summary>
    public class Wallpaper
    {
        private int _ID;

        private string _caption;
        private bool _isDisplay;
        private int _sortId;

        public Wallpaper(int id, string caption, bool isDisplay, int sortID)
        {
            this.ID = id;

            this.Caption = caption;
            this.IsDisplay = isDisplay;
            this.SortID = sortID;

        }

        public Wallpaper()
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

                return DALLayer.UpdateWallpaper(this.ID, this.Caption, this.IsDisplay, this.SortID);
            }
            else
            {
                ID = DALLayer.InsertWallpaper(this.Caption, this.IsDisplay, this.SortID);
                return (ID > 0);
            }

        }

        /*** METHOD STATIC ***/
        public static bool Remove(int ID)
        {
            if (ID > 0)
            {
                DataAccess DALLayer = DataAccessHelper.GetDataAccess();
                return DALLayer.RemoveWallpaper(ID);
            }
            else
                return false;
        }

        public static Wallpaper GetWallpaperById(int ID)
        {
            if (ID <= 0)
                return (null);

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetWallpaperById(ID));
        }

        public static List<Wallpaper> GetWallpaper()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetWallpaper());
        }
        public static List<Wallpaper> GetWallpaper(string sortParameter)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();

            List<Wallpaper> WallpaperList = DALLayer.GetWallpaper();

            if (!String.IsNullOrEmpty(sortParameter))
                WallpaperList.Sort(new WallpaperComparer(sortParameter));

            return (WallpaperList);
        }
        public static List<Wallpaper> GetDisplayWallpaper()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetDisplayWallpaper());
        }



    }



}