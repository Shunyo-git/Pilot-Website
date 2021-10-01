using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Pilot.BusinessLogicLayer;

namespace Pilot.DataAccessLayer
{
    /// <summary>
    /// DataAccess 的摘要描述
    /// </summary>
    public abstract class DataAccess
    {
        /*** PROPERTIES ***/
        protected string ConnectionString
        {
            get

            {

                //string dataAccessStringType = ConfigurationManager.AppSettings["DataAccessLayerType"];
                string connectionString =   ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                
                if (connectionString == null)
                    throw (new NullReferenceException("ConnectionString configuration is missing from you web.config. It should contain  <connectionStrings> <add key=\"ConnectionString\" value=\"Data Source=.\\SQLExpress;Integrated Security=True;User Instance=True;AttachDBFilename=|DataDirectory|(DatabaseName)\" </connectionStrings>"));
 
                if (String.IsNullOrEmpty(connectionString))
                    throw (new NullReferenceException("ConnectionString configuration is missing from you web.config. It should contain  <connectionStrings> <add key=\"ConnectionString\" value=\"Server=(local);Integrated Security=True;Database=(DatabaseName)\" </connectionStrings>"));
                else
                    return (connectionString);
            }
        }

 
        /*** Product ***/
        public abstract Product GetProductById(int ProductID);
        public abstract Product GetLastDisplayProduct();
        public abstract List<Product> GetProduct();
        public abstract List<Product> GetProductByCategoryID(int CategoryID);
        public abstract List<Product> GetDisplayProduct();
        public abstract List<Product> GetDisplayProductByCategoryID(int CategoryID);
        public abstract int InsertProduct(
            int CategoryID,
            string Name,
            string Spec,
            string Description, 
            Product.ImageDisplayType ImageType,
            string Price,
            bool IsDisplay,
            int SortID);
        public abstract bool UpdateProduct(int ProductID,
            int CategoryID,
            string Name,
            string Spec,
            string Description, 
            Product.ImageDisplayType ImageType,
            string Price,
            bool IsDisplay,
            int SortID);
        public abstract bool RemoveProduct(int ProductID);
        public abstract bool AddProductColor(int ProductID, int ColorID);
        public abstract bool RemoveProductColor(int ProductID, int ColorID);

        /*** Category ***/
        public abstract Category GetCategoryById(int CategoryID);
        public abstract Category GetFirstDisplayCategory();
        public abstract List<Category> GetCategory();
        public abstract List<Category> GetDisplayCategory();

        public abstract int InsertCategory(int MainID, string Name, bool IsDisplay, int SortID);
        public abstract bool UpdateCategory(int CategoryID, int MainID, string Name, bool IsDisplay, int SortID);
        public abstract bool RemoveCategory(int CategoryID);

        /*** Message ***/
        public abstract Message GetMessageById(int MsgID);
        public abstract List<Message> GetMessage();
        public abstract List<Message> GetMessage(bool IsDone);
        public abstract List<Message> GetMessage(string Keyword);
        public abstract int InsertMessage(string Name, string Title, string Email, string Contact, string Company, string Content,string IP);
        public abstract bool UpdateMessage(int MsgID, string Note, bool IsDone);
        public abstract bool RemoveMessage(int MsgID);

        /*** Color ***/
        public abstract Color GetColorById(int ColorID);
        public abstract Color GetColorByCode(string ColorCode);
        public abstract List<Color> GetColor();
        public abstract List<Color> GetColorByProduct(int ProductID);
        public abstract Color GetColorByProduct(int ProductID, int ColorID);

        public abstract int InsertColor(string Name, string ColorCode );
        public abstract bool UpdateColor(int ColorID, string Name, string ColorCode );
        public abstract bool RemoveColor(int ColorID);

        /*** News ***/
        public abstract News GetNews(int ID);
        public abstract List<News> GetNews();
        public abstract List<News> GetNews(ApproveType approveType);
        public abstract bool UpdateNews(int ID, string Caption, string Foreword, string Content, bool IsDisplayImage, bool IsApproved, bool IsMainPageDisplay);
        public abstract int AddNews(string Caption, string Foreword, string Content, bool IsDisplayImage, bool IsApproved, bool IsMainPageDisplay);
        public abstract bool RemoveNews(int ID);

        /*** CF ***/
        public abstract PilotCF GetCFById(int  ID);
        public abstract List<PilotCF> GetCF();
        public abstract List<PilotCF> GetDisplayCF();

        public abstract int InsertCF( string Name, bool IsDisplay, int SortID);
        public abstract bool UpdateCF(int  ID,   string Name, bool IsDisplay, int SortID);
        public abstract bool RemoveCF(int ID);

        /*** Store ***/
        public abstract Store GetStoreById(int ID);
        public abstract List<Store> GetStore();
        public abstract List<Store> GetDisplayStore();
        public abstract List<Store> GetDisplayStoreByArea(int AreaID);
        public abstract int InsertStore(int AreaID, string StoreName, string Tel, string Address, string URL, bool IsDisplay, int SortID, string Note);
        public abstract bool UpdateStore(int ID, int AreaID, string StoreName, string Tel, string Address, string URL, bool IsDisplay, int SortID, string Note);
        public abstract bool RemoveStore(int ID);

        /*** PilotStar ***/
        public abstract PilotStar GetPilotStarById(int ID);
        public abstract List<PilotStar> GetPilotStar();
        public abstract int InsertPilotStar(string Caption, string Url);
        public abstract bool UpdatePilotStar(int ID, string Caption, string Url);
        public abstract bool RemovePilotStar(int ID);

        /*** Wallpaper ***/
        public abstract Wallpaper GetWallpaperById(int ID);
        public abstract List<Wallpaper> GetWallpaper();
        public abstract List<Wallpaper> GetDisplayWallpaper();

        public abstract int InsertWallpaper(string Name, bool IsDisplay, int SortID);
        public abstract bool UpdateWallpaper(int ID, string Name, bool IsDisplay, int SortID);
        public abstract bool RemoveWallpaper(int ID);
    }
}