using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Pilot.DataAccessLayer;

namespace Pilot.BusinessLogicLayer
{
    /// <summary>
    /// Product 的摘要描述
    /// </summary>
    public class Product
    {
        private int _productID;
        private int _categoryID;
        private string _name;
        private string _spec;
        private string _description;
        private ImageDisplayType _imageType;
        private string _price;
        private bool _isDisplay;
        private int _sortID;
      

        //Vertical 直式
        //Horizontal 橫式
        public enum ImageDisplayType { SingleImage=1, MultiImage=2 }

        public Product(int ProductID,
            int CategoryID,
            string Name,
            string Spec,
             string Description,
            ImageDisplayType ImageType,
            string Price,
            bool IsDisplay,
            int SortID)
        {
            this.ProductID = ProductID;
            this.CategoryID = CategoryID;
            this.Description = Description;
            this.Name = Name;
 
            this.Spec = Spec;
            this.ImageType = ImageType;
            this.Price = Price;
            this.IsDisplay = IsDisplay;
            this.SortID = SortID;
        }
        public Product()
        {

        }


        public int ProductID
        {
            get
            {
                return _productID;
            }
            set
            {
                _productID = value;
            }
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
        public string Spec
        {
            get
            {
                return _spec;
            }
            set
            {
                _spec = value;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public ImageDisplayType ImageType
        {
            get
            {
                return _imageType;
            }
            set
            {
                _imageType = value;
            }
        }
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
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
                return _sortID;
            }
            set
            {
                _sortID = value;
            }
        }


        /*** METHODS  ***/
        public bool Remove()
        {

            return Remove(this.ProductID);
        }

        public bool Save()
        {

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            if (ProductID > 0)
            {

                return DALLayer.UpdateProduct(this.ProductID, this.CategoryID, this.Name, this.Spec,this.Description  ,this.ImageType, this.Price, this.IsDisplay, this.SortID);
            }
            else
            {
                ProductID = DALLayer.InsertProduct(this.CategoryID, this.Name,  this.Spec, this.Description,this.ImageType, this.Price, this.IsDisplay, this.SortID);
                return (ProductID > 0);
            }

        }

        /*** METHOD STATIC ***/
        public static bool Remove(int ID)
        {
            if (ID > 0)
            {
                DataAccess DALLayer = DataAccessHelper.GetDataAccess();
                return DALLayer.RemoveProduct(ID);
            }
            else
                return false;
        }

        public static Product GetProductById(int ID)
        {
            if (ID <= 0)
                return (null);

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetProductById(ID));
        }
        public static Product GetLastDisplayProduct()
        {

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetLastDisplayProduct());
        }
        public static List<Product> GetProduct()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetProduct());
        }
        public static List<Product> GetProduct(string sortParameter)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();

            List<Product> productList = DALLayer.GetProduct();

            if (!String.IsNullOrEmpty(sortParameter))
                productList.Sort(new ProductComparer(sortParameter));

            return (productList);
        }



        public static List<Product> GetProductByCategory(int CategoryID)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetProductByCategoryID(CategoryID));
        }
        public static List<Product> GetProductByCategory(int CategoryID,string sortParameter)
        {

            List<Product> productList = GetProductByCategory(CategoryID);

            if (!String.IsNullOrEmpty(sortParameter))
                productList.Sort(new ProductComparer(sortParameter));

            return (productList);
        }
        public static List<Product> GetDisplayProduct()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetDisplayProduct());
        }
        public static List<Product> GetDisplayProduct(  string sortParameter)
        {

            List<Product> productList = GetDisplayProduct( );

            if (!String.IsNullOrEmpty(sortParameter))
                productList.Sort(new ProductComparer(sortParameter));

            return (productList);
        }
        public static List<Product> GetDisplayProductByCategory(int CategoryID)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetDisplayProductByCategoryID(CategoryID));
        }
        public static List<Product> GetDisplayProductByCategory( int CategoryID,string sortParameter)
        {
            
            List<Product> productList =  GetDisplayProductByCategory(CategoryID);

            if (!String.IsNullOrEmpty(sortParameter))
                productList.Sort(new ProductComparer(sortParameter));

            return (productList);
        }

        public static bool AddProductColor(int ProductID,int ColorID)
        {
            if (ColorID > 0 || ProductID>0)
            {
                DataAccess DALLayer = DataAccessHelper.GetDataAccess();
                return DALLayer.AddProductColor(ProductID, ColorID) ;
            }
            else
                return false;
        }

        public static bool RemoveProductColor(int ProductID, int ColorID)
        {
            if (ColorID > 0 || ProductID > 0)
            {
                DataAccess DALLayer = DataAccessHelper.GetDataAccess();
                return DALLayer.RemoveProductColor(ProductID, ColorID);
            }
            else
                return false;
        }

    }
}