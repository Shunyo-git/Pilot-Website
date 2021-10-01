using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Pilot.DataAccessLayer;

namespace Pilot.BusinessLogicLayer
{

    /// <summary>
    /// PilotStar 的摘要描述
    /// </summary>
    public class PilotStar
    {
        private int _ID;
        private string _caption;
        private string _url;

        public PilotStar(int id, string caption, string url)
        {
            this.ID = id;

            this.Caption = caption;

            this.Url = url;

        }

        public PilotStar()
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


        public string Url
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

                return DALLayer.UpdatePilotStar(this.ID, this.Caption,  this.Url);
            }
            else
            {
                ID = DALLayer.InsertPilotStar(this.Caption,  this.Url);
                return (ID > 0);
            }

        }

        /*** METHOD STATIC ***/
        public static bool Remove(int ID)
        {
            if (ID > 0)
            {
                DataAccess DALLayer = DataAccessHelper.GetDataAccess();
                return DALLayer.RemovePilotStar(ID);
            }
            else
                return false;
        }

        public static PilotStar GetPilotStarById(int ID)
        {
            if (ID <= 0)
                return (null);

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetPilotStarById(ID));
        }

        public static List<PilotStar> GetPilotStar()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetPilotStar());
        }
        public static List<PilotStar> GetPilotStar(string sortParameter)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();

            List<PilotStar> PilotStarList = DALLayer.GetPilotStar();

            if (!String.IsNullOrEmpty(sortParameter))
                PilotStarList.Sort(new PilotStarComparer(sortParameter));

            return (PilotStarList);
        }
        


    }



}