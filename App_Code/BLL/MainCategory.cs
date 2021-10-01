using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Pilot.DataAccessLayer;

namespace Pilot.BusinessLogicLayer
{

    /// <summary>
    /// MainCategory 的摘要描述
    /// </summary>
    


    public class MainCategory
    {
        private int _mainId;
        private string _name;


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

        public MainCategory()
        {

        }

        public MainCategory(int mainID, string name)
        {
            this.MainID = mainID;
            this.Name = name;

        }

        public static MainCategory GetMainCategory(int MainID)
        {
            MainCategory item;

            switch (MainID)
            {
                case 1:
                    item = new MainCategory(1, "一般用途");
                    break;
                case 2:
                    item = new MainCategory(2, "專業用途");
                    break;
                case 3:
                    item = new MainCategory(3, "修正系列");
                    break;
                case 4:
                    item = new MainCategory(4, "環保系列");
                    break;
                default:
                    item = null;
                    break;
            }
            return item;
        }

    }
}