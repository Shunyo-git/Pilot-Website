using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Pilot.DataAccessLayer;

namespace Pilot.BusinessLogicLayer
{

    /// <summary>
    /// 最新消息
    /// </summary>
    public class News
    {
        private int _ID;
        private string _caption;
        private string _foreword;
        private string _content;
        private bool _isApproved;
        private bool _isMainPageDisplay;
        private bool _isDisplayImage ;
        private DateTime _creationDate;
        public News()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        public News(int id, string caption,string foreword, string content,bool isDisplayImage,  bool isApproved, bool isMainPageDisplay, DateTime creationDate)
        {
            this.ID = id;
            this.Caption = caption;
            this.Foreword = foreword;
            this.Content = content;
            this.IsDisplayImage = isDisplayImage;
            this.IsApproved = isApproved;
            this.IsMainPageDisplay = isMainPageDisplay;
            this.CreationDate = creationDate;
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
        public string Foreword
        {
            get
            {
                return _foreword;
            }
            set
            {
                _foreword = value;
            }
        }
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }
     
        public bool IsApproved
        {
            get
            {
                return _isApproved;
            }
            set
            {
                _isApproved = value;
            }
        }
        public bool IsMainPageDisplay
        {
            get
            {
                return _isMainPageDisplay;
            }
            set
            {
                _isMainPageDisplay = value;
            }
        }
        public bool IsDisplayImage
        {
            get
            {
                return _isDisplayImage;
            }
            set
            {
                _isDisplayImage = value;
            }
        }
        
        public DateTime CreationDate
        {
            get
            {
                return _creationDate;
            }
            set
            {
                _creationDate = value;
            }
        }
        /*** METHODS  ***/
        public  bool Remove()
        {

            return News.Remove(this.ID);
        }

        public bool Save()
        {

            DataAccess DALLayer = DataAccessHelper.GetDataAccess(); if (ID > 0)
            {

                return DALLayer.UpdateNews(ID, Caption,Foreword, Content,IsDisplayImage, IsApproved, IsMainPageDisplay);
            }
            else
            {
                ID = DALLayer.AddNews(Caption, Foreword,Content,IsDisplayImage, IsApproved, IsMainPageDisplay);
                return (ID > 0);
            }

        }
    

        /*** METHOD STATIC ***/
        public static bool Remove(int ID)
        {
            if (ID > 0)
            {
                DataAccess DALLayer = DataAccessHelper.GetDataAccess();
                return DALLayer.RemoveNews(ID);
            }
            else
                return false;
        }

        public static News GetNews(int ID)
        {
            if (ID <= 0)
                return (null);

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetNews(ID));
        }

        public static News GetNews(int ID, bool IsApprove)
        {
            if (ID <= 0)
                return (null);

            News item = GetNews(ID);
            
            if(item!=null){
                if(item.IsApproved != IsApprove ){
                    item = null;
                }
            
            }
            return item;
        }

        public static List<News> GetNews()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetNews());
        }

        public static List<News> GetNews(string sortParameter)
        {
            List<News> dataList = GetNews();

            if (!String.IsNullOrEmpty(sortParameter))
                dataList.Sort(new NewsComparer(sortParameter));

            return (dataList);
        }

        public static List<News> GetNews(ApproveType IsApprove)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetNews(IsApprove));
        }

        public static List<News> GetNews(ApproveType IsApprove, string sortParameter)
        {
            List<News> dataList = GetNews(IsApprove);

            if (!String.IsNullOrEmpty(sortParameter))
                dataList.Sort(new NewsComparer(sortParameter));

            return (dataList);
        }

        public static List<News> GetNews(bool IsMainPageDisplay, ApproveType IsApprove, string sortParameter)
        {


            List<News> dataList = new List<News>();
            foreach (News n in GetNews(IsApprove))
            {
                if (n.IsMainPageDisplay == IsMainPageDisplay)
                {
                    dataList.Add(n);
                }
            }

            if (!String.IsNullOrEmpty(sortParameter))
                dataList.Sort(new NewsComparer(sortParameter));

           
            return (dataList);
        }
       
    }
}