using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Pilot.DataAccessLayer;

namespace Pilot.BusinessLogicLayer
{

    /// <summary>
    /// Color 的摘要描述
    /// </summary>
    public class Color
    {
        private int _colorID;

        private string _name;
        private string _colorCode;

        public Color(int colorID, string name, string colorCode)
        {
            this.ColorID = colorID;
            this.Name = name;
            this.ColorCode = colorCode;


        }

        public Color()
        {

        }

        public int ColorID
        {
            get
            {
                return _colorID;
            }
            set
            {
                _colorID = value;
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
        public string ColorCode
        {
            get
            {
                return _colorCode;
            }
            set
            {
                _colorCode = value;
            }
        }

        /*** METHODS  ***/
        public bool Remove()
        {

            return Remove(this.ColorID);
        }

        public bool Save()
        {

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            if (ColorID > 0)
            {

                return DALLayer.UpdateColor(this.ColorID, this.Name, this.ColorCode);
            }
            else
            {
                ColorID = DALLayer.InsertColor(this.Name, this.ColorCode);
                return (ColorID > 0);
            }

        }

        /*** METHOD STATIC ***/
        public static bool Remove(int ColorID)
        {
            if (ColorID > 0)
            {
                DataAccess DALLayer = DataAccessHelper.GetDataAccess();
                return DALLayer.RemoveColor(ColorID);
            }
            else
                return false;
        }

        public static Color GetColor(int CategoryID)
        {
            if (CategoryID <= 0)
                return (null);

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetColorById(CategoryID));
        }
        public static Color GetColorByCode(string ColorCode)
        {


            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetColorByCode(ColorCode));
        }
        public static List<Color> GetColor()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetColor());
        }
        public static List<Color> GetColor(string sortParameter)
        {

            List<Color> itemList = GetColor();

            if (!String.IsNullOrEmpty(sortParameter))
                itemList.Sort(new ColorComparer(sortParameter));

            return (itemList);
        }

        public static List<Color> GetColorByProduct(int ProductID)
        {

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetColorByProduct(ProductID));
        }

        public static Color GetColorByProduct(int ProductID,int ColorID)
        {

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetColorByProduct(ProductID, ColorID));
        }

    }



}