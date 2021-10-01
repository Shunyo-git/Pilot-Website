using System;
using System.Data;
using System.Configuration;

using System.Text;
using System.Collections.Generic;
using System.Data.OleDb;
using Pilot.BusinessLogicLayer;


namespace Pilot.DataAccessLayer
{
    /// <summary>
    /// EventProvider 的摘要描述
    /// </summary>
    public class AccessDataProvider : DataAccess
    {

    


        /*** DELEGATE ***/

        private delegate void TGenerateListFromReader<T>(OleDbDataReader returnData, ref List<T> tempList);


        /*****************************  BASE CLASS IMPLEMENTATION *****************************/

        #region Category METHODS
        //Static constants 
        private const string SQL_SELECT_CATEGORY = "SELECT  CategoryID,MainID,Name,IsDisplay,SortID FROM Category WHERE (CategoryID = @CategoryID)";
        private const string SQL_SELECT_FIRST_DISPLAY_CATEGORY = "SELECT TOP 1 CategoryID,MainID,Name,IsDisplay,SortID FROM Category WHERE (IsDelete = False) AND (IsDisplay = True) ORDER BY SortID ";
        private const string SQL_SELECT_ALL_CATEGORY = "SELECT CategoryID,MainID,Name,IsDisplay,SortID FROM Category  WHERE (IsDelete = 0) ORDER BY  SortID";
        private const string SQL_SELECT_ALL_DISPLAY_CATEGORY = "SELECT CategoryID,MainID,Name,IsDisplay,SortID FROM  Category WHERE (IsDelete = False) AND (IsDisplay = True) ORDER BY SortID";


        private const string SQL_INSERT_CATEGORY = " INSERT INTO Category (MainID,Name,IsDisplay,SortID) VALUES(@MainID ,@Name,@IsDisplay, @SortID )";
        private const string SQL_UPDATE_CATEGORY = " UPDATE Category SET MainID=@MainID ,Name=@Name,IsDisplay=@IsDisplay, SortID=@SortID  WHERE CategoryID=@CategoryID";
        private const string SQL_REMOVE_CATEGORY = " UPDATE Category SET IsDelete=True  WHERE CategoryID=@CategoryID";

        public override Category GetCategoryById(int CategoryID)
        {
            if (CategoryID <= 0)
            {
                throw (new ArgumentOutOfRangeException("CategoryID"));
            }
            OleDbCommand OleDbCmd = new OleDbCommand();
            AddParamToOleDbCmd(OleDbCmd, "CategoryID", OleDbType.Integer, 0, CategoryID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_CATEGORY);
            List<Category> CategoryList = new List<Category>();
            TExecuteReaderCmd<Category>(OleDbCmd, TGenerateCategoryListFromReader<Category>, ref CategoryList);
            if (CategoryList.Count > 0)
                return CategoryList[0];
            else
                return null;
        }
        public override Category GetFirstDisplayCategory()
        {

            OleDbCommand OleDbCmd = new OleDbCommand();

            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_FIRST_DISPLAY_CATEGORY);
            List<Category> CategoryList = new List<Category>();
            TExecuteReaderCmd<Category>(OleDbCmd, TGenerateCategoryListFromReader<Category>, ref CategoryList);
            if (CategoryList.Count > 0)
                return CategoryList[0];
            else
                return null;
        }
        public override List<Category> GetCategory()
        {
            OleDbCommand OleDbCmd = new OleDbCommand();
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_CATEGORY);
            List<Category> CategoryList = new List<Category>();
            TExecuteReaderCmd<Category>(OleDbCmd, TGenerateCategoryListFromReader<Category>, ref CategoryList);
            return CategoryList;
        }
        public override List<Category> GetDisplayCategory()
        {
            OleDbCommand OleDbCmd = new OleDbCommand();
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_CATEGORY);
            List<Category> CategoryList = new List<Category>();
            TExecuteReaderCmd<Category>(OleDbCmd, TGenerateCategoryListFromReader<Category>, ref CategoryList);
            return CategoryList;
        }


        public override int InsertCategory(int MainID, string Name, bool IsDisplay, int SortID)
        {

            OleDbCommand OleDbCmd = new OleDbCommand();

            AddParamToOleDbCmd(OleDbCmd, "MainID", OleDbType.Integer, 0, MainID);
            AddParamToOleDbCmd(OleDbCmd, "Name", OleDbType.VarWChar, 100, Name);
            AddParamToOleDbCmd(OleDbCmd, "IsDisplay", OleDbType.Boolean, 1, IsDisplay);
            AddParamToOleDbCmd(OleDbCmd, "SortID", OleDbType.Integer, 0, SortID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_INSERT_CATEGORY);
            //ExecuteScalarCmd(OleDbCmd);

            return (ExecuteScalarCmdGetIdentity(OleDbCmd));

        }
        public override bool UpdateCategory(int CategoryID, int MainID, string Name, bool IsDisplay, int SortID)
        {


            OleDbCommand OleDbCmd = new OleDbCommand();


            AddParamToOleDbCmd(OleDbCmd, "MainID", OleDbType.Integer, 0, MainID);
            AddParamToOleDbCmd(OleDbCmd, "Name", OleDbType.VarWChar, 100, Name);
            AddParamToOleDbCmd(OleDbCmd, "IsDisplay", OleDbType.Boolean, 1, IsDisplay);
            AddParamToOleDbCmd(OleDbCmd, "SortID", OleDbType.Integer, 0, SortID);
            AddParamToOleDbCmd(OleDbCmd, "CategoryID", OleDbType.Integer, 0, CategoryID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_UPDATE_CATEGORY);
            ExecuteNonQueryCmd(OleDbCmd);


            return true;

        }
        public override bool RemoveCategory(int CategoryID)
        {

            if (CategoryID <= 0)
                throw (new ArgumentOutOfRangeException("CategoryID"));

            OleDbCommand OleDbCmd = new OleDbCommand();

            //AddParamToOleDbCmd(OleDbCmd, "@ReturnValue", OleDbType.Integer, 0, ParameterDirection.ReturnValue, null);
            AddParamToOleDbCmd(OleDbCmd, "CategoryID", OleDbType.Integer, 0, CategoryID);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_REMOVE_CATEGORY);
            ExecuteNonQueryCmd(OleDbCmd);

            //int returnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;

            //return (returnValue == 0 ? true : false);
            return true;
        }

        #endregion

        #region Product METHODS

        //int ProductID, int CategoryID, string SKU, string Name, string Spec, string Orientation, string Price, bool IsDisplay, int SortID

        //Static constants
        private const string SQL_SELECT_PRODUCT = "SELECT ProductID, CategoryID, Name, Spec, Description, ImageType,Price,IsDisplay,SortID FROM Product     WHERE (ProductID = @ProductID)";
        private const string SQL_SELECT_LAST_DISPLAY_PRODUCT = "SELECT TOP 1 ProductID, CategoryID,  Name,  Spec, Description, ImageType,Price,IsDisplay,SortID FROM Product     WHERE (IsDelete = False) AND (IsDisplay = True) ORDER BY CategoryID,SortID";
        private const string SQL_SELECT_ALL_PRODUCT = "SELECT ProductID, CategoryID, Name,  Spec, Description, ImageType,Price,IsDisplay,SortID FROM Product     WHERE (IsDelete = 0) ORDER BY CategoryID,SortID";
        private const string SQL_SELECT_ALL_PRODUCT_BY_GROUPID = "SELECT ProductID, CategoryID, Name, Spec, Description, ImageType,Price,IsDisplay,SortID FROM Product     WHERE (IsDelete = 0)   AND (CategoryID = @CategoryID) ORDER BY CategoryID,SortID";
        private const string SQL_SELECT_ALL_DISPLAY_PRODUCT_BY_CATEGORYID = "SELECT ProductID, CategoryID, Name, Spec, Description, ImageType,Price,IsDisplay,SortID FROM Product     WHERE (IsDelete = 0) AND (IsDisplay = True)  AND (CategoryID = @CategoryID) ORDER BY CategoryID,SortID";
        private const string SQL_SELECT_ALL_DISPLAY_PRODUCT = "SELECT ProductID, CategoryID, Name, Spec, Description, ImageType,Price,IsDisplay,SortID FROM Product     WHERE (IsDelete = False) AND (IsDisplay = True) ORDER BY CategoryID,SortID";
        private const string SQL_INSERT_PRODUCT = "INSERT INTO Product (CategoryID,  Name,  Spec, Description , ImageType, Price,IsDisplay,SortID) VALUES(@CategoryID,    @Name,   @Spec,@Description ,@ImageType,@Price,@IsDisplay,@SortID) ";
        private const string SQL_UPDATE_PRODUCT = "UPDATE Product SET CategoryID=@CategoryID,  Name=@Name,  Spec=@Spec,Description=@Description, ImageType=@ImageType,Price=@Price,IsDisplay=@IsDisplay,SortID=@SortID  WHERE ProductID=@ProductID ";
        private const string SQL_REMOVE_PRODUCT = "UPDATE Product SET IsDelete=True WHERE ProductID=@ProductID ";
        private const string SQL_INSERT_PRODUCT_COLOR = "INSERT INTO Product_Color (ProductID, ColorID) VALUES(@ProductID, @ColorID) ";
        private const string SQL_REMOVE_PRODUCT_COLOR = "DELETE  FROM Product_Color WHERE ProductID = @ProductID AND ColorID = @ColorID";

        public override Product GetProductById(int ProductID)
        {
            if (ProductID <= 0)
            {
                throw (new ArgumentOutOfRangeException("ProductID"));
            }
            OleDbCommand OleDbCmd = new OleDbCommand();
            AddParamToOleDbCmd(OleDbCmd, "ProductID", OleDbType.Integer, 0, ProductID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_PRODUCT);
            List<Product> productList = new List<Product>();
            TExecuteReaderCmd<Product>(OleDbCmd, TGenerateProductListFromReader<Product>, ref productList);
            if (productList.Count > 0)
                return productList[0];
            else
                return null;
        }
        public override Product GetLastDisplayProduct()
        {

            OleDbCommand OleDbCmd = new OleDbCommand();

            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_LAST_DISPLAY_PRODUCT);
            List<Product> productList = new List<Product>();
            TExecuteReaderCmd<Product>(OleDbCmd, TGenerateProductListFromReader<Product>, ref productList);
            if (productList.Count > 0)
                return productList[0];
            else
                return null;
        }
        public override List<Product> GetProduct()
        {
            OleDbCommand OleDbCmd = new OleDbCommand();
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_PRODUCT);
            List<Product> productList = new List<Product>();
            TExecuteReaderCmd<Product>(OleDbCmd, TGenerateProductListFromReader<Product>, ref productList);
            return productList;
        }
        public override List<Product> GetProductByCategoryID(int CategoryID)
        {

            if (CategoryID <= 0)
            {
                throw (new ArgumentOutOfRangeException("CategoryID"));
            }
            OleDbCommand OleDbCmd = new OleDbCommand();
            AddParamToOleDbCmd(OleDbCmd, "CategoryID", OleDbType.Integer, 0, CategoryID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_PRODUCT_BY_GROUPID);
            List<Product> productList = new List<Product>();
            TExecuteReaderCmd<Product>(OleDbCmd, TGenerateProductListFromReader<Product>, ref productList);
            return productList;
        }
        public override List<Product> GetDisplayProduct()
        {
            OleDbCommand OleDbCmd = new OleDbCommand();
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_PRODUCT);
            List<Product> productList = new List<Product>();
            TExecuteReaderCmd<Product>(OleDbCmd, TGenerateProductListFromReader<Product>, ref productList);
            return productList;
        }
        public override List<Product> GetDisplayProductByCategoryID(int CategoryID)
        {

            if (CategoryID <= 0)
            {
                throw (new ArgumentOutOfRangeException("CategoryID"));
            }
            OleDbCommand OleDbCmd = new OleDbCommand();
            AddParamToOleDbCmd(OleDbCmd, "CategoryID", OleDbType.Integer, 0, CategoryID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_PRODUCT_BY_CATEGORYID);
            List<Product> productList = new List<Product>();
            TExecuteReaderCmd<Product>(OleDbCmd, TGenerateProductListFromReader<Product>, ref productList);
            return productList;
        }

        public override int InsertProduct(int CategoryID, string Name, string Spec, string Description, Product.ImageDisplayType ImageType, string Price, bool IsDisplay, int SortID)
        {
          

            OleDbCommand OleDbCmd = new OleDbCommand();


            AddParamToOleDbCmd(OleDbCmd, "CategoryID", OleDbType.Integer, 0, CategoryID);
            
            AddParamToOleDbCmd(OleDbCmd, "Name", OleDbType.VarWChar, 255, Name);

            AddParamToOleDbCmd(OleDbCmd, "Spec", OleDbType.VarWChar, 1500, Spec);
            AddParamToOleDbCmd(OleDbCmd, "Description", OleDbType.VarWChar, 1500, Description);
            AddParamToOleDbCmd(OleDbCmd, "ImageType", OleDbType.Integer, 0, (int)ImageType);
            AddParamToOleDbCmd(OleDbCmd, "Price", OleDbType.VarWChar, 255, Price);
            AddParamToOleDbCmd(OleDbCmd, "IsDisplay", OleDbType.Boolean, 0, IsDisplay);
            AddParamToOleDbCmd(OleDbCmd, "SortID", OleDbType.Integer, 0, SortID);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_INSERT_PRODUCT);
            return (ExecuteScalarCmdGetIdentity(OleDbCmd));



        }
        public override bool UpdateProduct(int ProductID, int CategoryID, string Name, string Spec, string Description, Product.ImageDisplayType ImageType, string Price, bool IsDisplay, int SortID)
        {

       

            OleDbCommand OleDbCmd = new OleDbCommand();

            AddParamToOleDbCmd(OleDbCmd, "CategoryID", OleDbType.Integer, 0, CategoryID);
     
            AddParamToOleDbCmd(OleDbCmd, "Name", OleDbType.VarWChar, 255, Name);
            AddParamToOleDbCmd(OleDbCmd, "Spec", OleDbType.VarWChar, 1500, Spec);
            AddParamToOleDbCmd(OleDbCmd, "Description", OleDbType.VarWChar, 1500, Description);
            AddParamToOleDbCmd(OleDbCmd, "ImageType", OleDbType.Integer, 0, (int)ImageType);
            AddParamToOleDbCmd(OleDbCmd, "Price", OleDbType.VarWChar, 255, Price);
            AddParamToOleDbCmd(OleDbCmd, "IsDisplay", OleDbType.Boolean, 1, IsDisplay);
            AddParamToOleDbCmd(OleDbCmd, "SortID", OleDbType.Integer, 0, SortID);
            AddParamToOleDbCmd(OleDbCmd, "ProductID", OleDbType.Integer, 0, ProductID);


            SetCommandType(OleDbCmd, CommandType.Text, SQL_UPDATE_PRODUCT);
            ExecuteNonQueryCmd(OleDbCmd);


            return true;
        }
        public override bool RemoveProduct(int ProductID)
        {

            if (ProductID <= 0)
                throw (new ArgumentOutOfRangeException("ProductID"));

            OleDbCommand OleDbCmd = new OleDbCommand();

            // AddParamToOleDbCmd(OleDbCmd, "@ReturnValue", OleDbType.Integer, 0, ParameterDirection.ReturnValue, null);
            AddParamToOleDbCmd(OleDbCmd, "ProductID", OleDbType.Integer, 0, ProductID);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_REMOVE_PRODUCT);
            ExecuteNonQueryCmd(OleDbCmd);

            //int returnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;

            //return (returnValue == 0 ? true : false);
            return true;
        }
        public override bool AddProductColor(int ProductID,int ColorID)
        {

            if (ProductID <= 0)
                throw (new ArgumentOutOfRangeException("ProductID"));

            if (ColorID <= 0)
                throw (new ArgumentOutOfRangeException("ColorID"));

            OleDbCommand OleDbCmd = new OleDbCommand();

             AddParamToOleDbCmd(OleDbCmd, "ProductID", OleDbType.Integer, 0, ProductID);
            AddParamToOleDbCmd(OleDbCmd, "ColorID", OleDbType.Integer, 0, ColorID);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_INSERT_PRODUCT_COLOR);
         
            return (ExecuteScalarCmdGetIdentity(OleDbCmd) >0);
        }
        public override bool RemoveProductColor(int ProductID, int ColorID)
        {

            if (ProductID <= 0)
                throw (new ArgumentOutOfRangeException("ProductID"));
            if (ColorID <= 0)
                throw (new ArgumentOutOfRangeException("ColorID"));

            OleDbCommand OleDbCmd = new OleDbCommand();

            // AddParamToOleDbCmd(OleDbCmd, "@ReturnValue", OleDbType.Integer, 0, ParameterDirection.ReturnValue, null);
            AddParamToOleDbCmd(OleDbCmd, "ProductID", OleDbType.Integer, 0, ProductID);
            AddParamToOleDbCmd(OleDbCmd, "ColorID", OleDbType.Integer, 0, ColorID);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_REMOVE_PRODUCT_COLOR);
            ExecuteNonQueryCmd(OleDbCmd);

            //int returnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;

            //return (returnValue == 0 ? true : false);
            return true;
        }
        #endregion

        #region Message METHODS
        //Static constants 
        private const string SQL_SELECT_MESSAGE = "SELECT  MsgID, Name, Title, Email, Contact, Company, Content, [Note], IsDone, CreationDate, UpdateDate ,IP FROM Message WHERE (MsgID = @MsgID)";
        private const string SQL_SELECT_ALL_MESSAGE = "SELECT MsgID, Name, Title, Email, Contact, Company, Content, [Note], IsDone, CreationDate, UpdateDate,IP  FROM Message  WHERE (IsDelete = 0) ORDER BY MsgID DESC";
        private const string SQL_SELECT_ALL_MESSAGE_DONE = "SELECT MsgID, Name, Title, Email, Contact, Company, Content, [Note], IsDone, CreationDate, UpdateDate,IP  FROM  Message WHERE (IsDelete = False) AND (IsDone = @IsDone) ORDER BY MsgID DESC";
        private const string SQL_SELECT_ALL_MESSAGE_KEYWORD = "SELECT MsgID, Name, Title, Email, Contact, Company, Content, [Note], IsDone, CreationDate, UpdateDate,IP  FROM Message  WHERE (IsDelete = 0) AND ( Name LIKE '%{0}%' OR  Title LIKE '%{0}%' OR  Email LIKE '%{0}%' OR  Contact LIKE '%{0}%' OR  Company LIKE '%{0}%' OR  Content LIKE '%{0}%' OR  Note LIKE '%{0}%' )  ORDER BY MsgID DESC";

        private const string SQL_INSERT_MESSAGE = " INSERT INTO Message (Name,Title,Email,Contact,Company,Content,IP) VALUES(@Name,@Title,@Email,@Contact,@Company,@Content,@IP)";
        private const string SQL_UPDATE_MESSAGE = " UPDATE Message SET IsDone=@IsDone,[Note]=@Note, UpdateDate=Now() WHERE ( MsgID=@MsgID )";
        private const string SQL_REMOVE_MESSAGE = " UPDATE Message SET IsDelete=True WHERE ( MsgID=@MsgID) ";

        public override Message GetMessageById(int MsgID)
        {
            if (MsgID <= 0)
            {
                throw (new ArgumentOutOfRangeException("MsgID"));
            }
            OleDbCommand OleDbCmd = new OleDbCommand();
            AddParamToOleDbCmd(OleDbCmd, "MsgID", OleDbType.Integer, 0, MsgID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_MESSAGE);
            List<Message> MessageList = new List<Message>();
            TExecuteReaderCmd<Message>(OleDbCmd, TGenerateMessageListFromReader<Message>, ref MessageList);
            if (MessageList.Count > 0)
                return MessageList[0];
            else
                return null;
        }

        public override List<Message> GetMessage()
        {
            OleDbCommand OleDbCmd = new OleDbCommand();
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_MESSAGE);
            List<Message> MessageList = new List<Message>();
            TExecuteReaderCmd<Message>(OleDbCmd, TGenerateMessageListFromReader<Message>, ref MessageList);
            return MessageList;
        }
        public override List<Message> GetMessage(bool IsDone)
        {
            OleDbCommand OleDbCmd = new OleDbCommand();
            AddParamToOleDbCmd(OleDbCmd, "IsDone", OleDbType.Boolean, 1, IsDone);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_MESSAGE_DONE);
            List<Message> MessageList = new List<Message>();
            TExecuteReaderCmd<Message>(OleDbCmd, TGenerateMessageListFromReader<Message>, ref MessageList);
            return MessageList;
        }
        public override List<Message> GetMessage(string Keyword)
        {
            OleDbCommand OleDbCmd = new OleDbCommand();
 
            SetCommandType(OleDbCmd, CommandType.Text, string.Format(SQL_SELECT_ALL_MESSAGE_KEYWORD, Keyword));
            List<Message> MessageList = new List<Message>();
            TExecuteReaderCmd<Message>(OleDbCmd, TGenerateMessageListFromReader<Message>, ref MessageList);
            return MessageList;
        }
        public override int InsertMessage(string Name, string Title, string Email, string Contact, string Company, string Content, string IP)
        {

            OleDbCommand OleDbCmd = new OleDbCommand();

            AddParamToOleDbCmd(OleDbCmd, "Name", OleDbType.VarWChar, 100, Name);
            AddParamToOleDbCmd(OleDbCmd, "Title", OleDbType.VarWChar, 100, Title);
            AddParamToOleDbCmd(OleDbCmd, "Email", OleDbType.VarWChar, 100, Email);
            AddParamToOleDbCmd(OleDbCmd, "Contact", OleDbType.VarWChar, 100, Contact);
            AddParamToOleDbCmd(OleDbCmd, "Company", OleDbType.VarWChar, 100, Company);
            AddParamToOleDbCmd(OleDbCmd, "Content", OleDbType.LongVarWChar, 1500, Content);
            AddParamToOleDbCmd(OleDbCmd, "IP", OleDbType.VarWChar, 50, IP);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_INSERT_MESSAGE);

            return (ExecuteScalarCmdGetIdentity(OleDbCmd));

        }
        public override bool UpdateMessage(int MsgID, string Note, bool IsDone)
        {


            OleDbCommand OleDbCmd = new OleDbCommand();

            AddParamToOleDbCmd(OleDbCmd, "IsDone", OleDbType.Boolean, 1, IsDone);
            AddParamToOleDbCmd(OleDbCmd, "Note", OleDbType.LongVarWChar, 500, Note);
            
            AddParamToOleDbCmd(OleDbCmd, "MsgID", OleDbType.Integer, 0, MsgID);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_UPDATE_MESSAGE);
            ExecuteNonQueryCmd(OleDbCmd);


            return true;

        }
        public override bool RemoveMessage(int MsgID)
        {

            if (MsgID <= 0)
                throw (new ArgumentOutOfRangeException("MsgID"));

            OleDbCommand OleDbCmd = new OleDbCommand();

            AddParamToOleDbCmd(OleDbCmd, "MsgID", OleDbType.Integer, 0, MsgID);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_REMOVE_MESSAGE);
            ExecuteNonQueryCmd(OleDbCmd);

            return true;
        }


        #endregion

        #region Color METHODS
        //Static constants 
        private const string SQL_SELECT_COLOR = "SELECT  ColorID,Name,Code FROM Color WHERE (ColorID = @ColorID)";
        private const string SQL_SELECT_COLOR_BY_CODE = "SELECT ColorID,Name,Code FROM Color WHERE   (Code = @Code) ";
        private const string SQL_SELECT_ALL_COLOR = "SELECT ColorID,Name,Code FROM Color  WHERE (IsDelete = 0) ORDER BY  Code";
        private const string SQL_SELECT_COLOR_BY_PRODUCT = "SELECT ColorID,Name,Code FROM Color  WHERE ColorID IN ( SELECT ColorID FROM Product_Color WHERE ProductID = @ProductID) ";
        private const string SQL_SELECT_COLOR_BY_PRODUCT_COLOR = "SELECT ColorID,Name,Code FROM Color  WHERE ColorID IN ( SELECT ColorID FROM Product_Color WHERE ProductID = @ProductID) AND ColorID= @ColorID ";
        

        private const string SQL_INSERT_Color = " INSERT INTO Color (@Name,Code) VALUES(@Name,Code )";
        private const string SQL_UPDATE_Color = " UPDATE Color SET  Name=@Name,Code=@Code   WHERE ColorID=@ColorID";
        private const string SQL_REMOVE_Color = " UPDATE Color SET IsDelete=True  WHERE ColorID=@ColorID";

        public override Color GetColorById(int ColorID)
        {
            if (ColorID <= 0)
            {
                throw (new ArgumentOutOfRangeException("ColorID"));
            }
            OleDbCommand OleDbCmd = new OleDbCommand();
            AddParamToOleDbCmd(OleDbCmd, "ColorID", OleDbType.Integer, 0, ColorID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_COLOR);
            List<Color> ColorList = new List<Color>();
            TExecuteReaderCmd<Color>(OleDbCmd, TGenerateColorListFromReader<Color>, ref ColorList);
            if (ColorList.Count > 0)
                return ColorList[0];
            else
                return null;
        }
        public override Color GetColorByCode(string ColorCode)
        {
           
            OleDbCommand OleDbCmd = new OleDbCommand();
            AddParamToOleDbCmd(OleDbCmd, "Code", OleDbType.VarWChar, 100, ColorCode);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_COLOR_BY_CODE);
            List<Color> ColorList = new List<Color>();
            TExecuteReaderCmd<Color>(OleDbCmd, TGenerateColorListFromReader<Color>, ref ColorList);
            if (ColorList.Count > 0)
                return ColorList[0];
            else
                return null;
        }
        public override List<Color> GetColor()
        {
            OleDbCommand OleDbCmd = new OleDbCommand();
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_COLOR);
            List<Color> ColorList = new List<Color>();
            TExecuteReaderCmd<Color>(OleDbCmd, TGenerateColorListFromReader<Color>, ref ColorList);
            return ColorList;
        }
        public override List<Color> GetColorByProduct(int ProductID)
        {
            OleDbCommand OleDbCmd = new OleDbCommand();
            AddParamToOleDbCmd(OleDbCmd, "ProductID", OleDbType.Integer, 0, ProductID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_COLOR_BY_PRODUCT);
            List<Color> ColorList = new List<Color>();
            TExecuteReaderCmd<Color>(OleDbCmd, TGenerateColorListFromReader<Color>, ref ColorList);
            return ColorList;
        }
        public override int InsertColor( string Name, string Code)
        {

            OleDbCommand OleDbCmd = new OleDbCommand();

            AddParamToOleDbCmd(OleDbCmd, "Name", OleDbType.VarWChar, 100, Name);
            AddParamToOleDbCmd(OleDbCmd, "Code", OleDbType.VarWChar, 100, Code);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_INSERT_Color);
            //ExecuteScalarCmd(OleDbCmd);

            return (ExecuteScalarCmdGetIdentity(OleDbCmd));

        }
        public override bool UpdateColor(int ColorID,  string Name,   string Code)
        {


            OleDbCommand OleDbCmd = new OleDbCommand();


             AddParamToOleDbCmd(OleDbCmd, "Name", OleDbType.VarWChar, 100, Name);
            AddParamToOleDbCmd(OleDbCmd, "Code", OleDbType.VarWChar, 100, Code);
            AddParamToOleDbCmd(OleDbCmd, "ColorID", OleDbType.Integer, 0, ColorID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_UPDATE_Color);
            ExecuteNonQueryCmd(OleDbCmd);


            return true;

        }
        public override bool RemoveColor(int ColorID)
        {

            if (ColorID <= 0)
                throw (new ArgumentOutOfRangeException("ColorID"));

            OleDbCommand OleDbCmd = new OleDbCommand();

            //AddParamToOleDbCmd(OleDbCmd, "@ReturnValue", OleDbType.Integer, 0, ParameterDirection.ReturnValue, null);
            AddParamToOleDbCmd(OleDbCmd, "ColorID", OleDbType.Integer, 0, ColorID);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_REMOVE_Color);
            ExecuteNonQueryCmd(OleDbCmd);

            //int returnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;

            //return (returnValue == 0 ? true : false);
            return true;
        }
        public override Color GetColorByProduct(int ProductID,int ColorID)
        {
            if (ProductID <= 0)
            {
                throw (new ArgumentOutOfRangeException("ProductID"));
            } 
            if (ColorID <= 0)
            {
                throw (new ArgumentOutOfRangeException("ColorID"));
            }
            OleDbCommand OleDbCmd = new OleDbCommand();
            AddParamToOleDbCmd(OleDbCmd, "ProductID", OleDbType.Integer, 0, ProductID);
            AddParamToOleDbCmd(OleDbCmd, "ColorID", OleDbType.Integer, 0, ColorID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_COLOR_BY_PRODUCT_COLOR);
            List<Color> ColorList = new List<Color>();
            TExecuteReaderCmd<Color>(OleDbCmd, TGenerateColorListFromReader<Color>, ref ColorList);
            if (ColorList.Count > 0)
                return ColorList[0];
            else
                return null;
        }
        #endregion

        #region News
        private const string SQL_News_GetNewsByID = "SELECT  ID,Caption,Foreword,Content,IsDisplayImage,IsApproved,IsMainPageDisplay,CreationDate FROM News WHERE (IsDelete = False) AND (ID = @ID)";
        private const string SQL_News_ListNews = "SELECT  ID,Caption,Foreword,Content,IsDisplayImage,IsApproved,IsMainPageDisplay,CreationDate FROM News WHERE (IsDelete = False)";
        private const string SQL_News_ListNewsByApproveType = "SELECT  ID,Caption,Foreword,Content,IsDisplayImage,IsApproved,IsMainPageDisplay,CreationDate FROM News WHERE (IsApproved=@IsApproved) AND (IsDelete = False)";

        private const string SQL_News_UpdateNews = "INSERT INTO News (Caption,Foreword,Content,IsDisplayImage,IsApproved,IsMainPageDisplay) VALUES(@Caption,@Foreword,@Content,@IsDisplayImage,@IsApproved,@IsMainPageDisplay) ";
        private const string SQL_News_AddNews = "UPDATE News SET Caption=@Caption,Foreword=@Foreword,Content=@Content,IsDisplayImage=@IsDisplayImage,IsApproved=@IsApproved,IsMainPageDisplay=@IsMainPageDisplay WHERE ID=@ID";
        private const string SQL_News_RemoveNews = "UPDATE News SET IsDelete=True WHERE ID=@ID ";

        public override News GetNews(int ID)
        {
            if (ID <= 0)
                throw (new ArgumentOutOfRangeException("ID"));

            OleDbCommand OleDbCmd = new OleDbCommand();

            AddParamToOleDbCmd(OleDbCmd, "@ID", OleDbType.Integer, 0, ID);


            SetCommandType(OleDbCmd, CommandType.Text, SQL_News_GetNewsByID);

            List<News> dataList = new List<News>();

            TExecuteReaderCmd<News>(OleDbCmd, News_TGenerateListFromReader<News>, ref dataList);

            if (dataList.Count > 0)
                return dataList[0];

            else
                return null;
        }
        public override List<News> GetNews()
        {

            OleDbCommand OleDbCmd = new OleDbCommand();


            SetCommandType(OleDbCmd, CommandType.Text, SQL_News_ListNews);

            List<News> dataList = new List<News>();

            TExecuteReaderCmd<News>(OleDbCmd, News_TGenerateListFromReader<News>, ref dataList);
            return dataList;

        }
        public override List<News> GetNews(ApproveType approveType)
        {

            bool IsApproved = (approveType == ApproveType.Approved) ? true : false;
            OleDbCommand OleDbCmd = new OleDbCommand();

            AddParamToOleDbCmd(OleDbCmd, "@IsApproved", OleDbType.Boolean, 0, IsApproved);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_News_ListNewsByApproveType);

            List<News> dataList = new List<News>();

            TExecuteReaderCmd<News>(OleDbCmd, News_TGenerateListFromReader<News>, ref dataList);
            return dataList;

        }
        public override bool UpdateNews(int ID, string Caption, string Foreword, string Content, bool IsDisplayImage, bool IsApproved, bool IsMainPageDisplay)
        {

            OleDbCommand OleDbCmd = new OleDbCommand();


            
            AddParamToOleDbCmd(OleDbCmd, "@Caption", OleDbType.VarWChar, 255, Caption);
            AddParamToOleDbCmd(OleDbCmd, "@Foreword", OleDbType.VarWChar, 1500, Foreword);
            AddParamToOleDbCmd(OleDbCmd, "@Content", OleDbType.VarWChar, 1500, Content);
            AddParamToOleDbCmd(OleDbCmd, "@IsDisplayImage", OleDbType.Boolean, 1, IsDisplayImage);
            AddParamToOleDbCmd(OleDbCmd, "@IsApproved", OleDbType.Boolean, 1, IsApproved);
            AddParamToOleDbCmd(OleDbCmd, "@IsMainPageDisplay", OleDbType.Boolean, 1, IsMainPageDisplay);

            AddParamToOleDbCmd(OleDbCmd, "@ID", OleDbType.Integer, 0, ID);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_News_UpdateNews);
            ExecuteNonQueryCmd(OleDbCmd);



            return (true);

        }
        public override int AddNews(string Caption, string Foreword, string Content, bool IsDisplayImage, bool IsApproved, bool IsMainPageDisplay)
        {

            OleDbCommand OleDbCmd = new OleDbCommand();

            
            AddParamToOleDbCmd(OleDbCmd, "@Caption", OleDbType.VarWChar, 255, Caption);
            AddParamToOleDbCmd(OleDbCmd, "@Foreword", OleDbType.VarWChar, 1500, Foreword);
            AddParamToOleDbCmd(OleDbCmd, "@Content", OleDbType.VarWChar, 1500, Content);
            AddParamToOleDbCmd(OleDbCmd, "@IsDisplayImage", OleDbType.Boolean, 1, IsDisplayImage);
            AddParamToOleDbCmd(OleDbCmd, "@IsApproved", OleDbType.Boolean, 1, IsApproved);
            AddParamToOleDbCmd(OleDbCmd, "@IsMainPageDisplay", OleDbType.Boolean, 1, IsMainPageDisplay);


            SetCommandType(OleDbCmd, CommandType.Text, SQL_News_AddNews);
            return (ExecuteScalarCmdGetIdentity(OleDbCmd));

        


        }
        public override bool RemoveNews(int ID)
        {

            if (ID <= 0)
                throw (new ArgumentOutOfRangeException("ID"));

            OleDbCommand OleDbCmd = new OleDbCommand();

            AddParamToOleDbCmd(OleDbCmd, "@ID", OleDbType.Integer, 0, ID);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_News_RemoveNews);
            ExecuteNonQueryCmd(OleDbCmd);

            return (true);

        }


        #endregion

        #region CF METHODS
        //Static constants 
        private const string SQL_SELECT_CF = "SELECT  ID,Caption,IsDisplay,SortID FROM CF WHERE (ID = @ID)";
        private const string SQL_SELECT_ALL_CF = "SELECT ID,Caption,IsDisplay,SortID FROM CF  WHERE (IsDelete = 0) ORDER BY  SortID";
        private const string SQL_SELECT_ALL_DISPLAY_CF = "SELECT ID,Caption,IsDisplay,SortID FROM  CF WHERE (IsDelete = False) AND (IsDisplay = True) ORDER BY SortID";


        private const string SQL_INSERT_CF = " INSERT INTO CF (Caption,IsDisplay,SortID) VALUES(@MainID ,@Caption,@IsDisplay, @SortID )";
        private const string SQL_UPDATE_CF = " UPDATE CF SET MainID=@MainID ,Caption=@Caption,IsDisplay=@IsDisplay, SortID=@SortID  WHERE ID=@ID";
        private const string SQL_REMOVE_CF = " UPDATE CF SET IsDelete=True  WHERE ID=@ID";

        public override PilotCF GetCFById(int ID)
        {
            if (ID <= 0)
            {
                throw (new ArgumentOutOfRangeException("ID"));
            }
            OleDbCommand OleDbCmd = new OleDbCommand();
            AddParamToOleDbCmd(OleDbCmd, "ID", OleDbType.Integer, 0, ID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_CF);
            List<PilotCF> CFList = new List<PilotCF>();
            TExecuteReaderCmd<PilotCF>(OleDbCmd, TGenerateCFListFromReader<PilotCF>, ref CFList);
            if (CFList.Count > 0)
                return CFList[0];
            else
                return null;
        }

        public override List<PilotCF> GetCF()
        {
            OleDbCommand OleDbCmd = new OleDbCommand();
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_CF);
            List<PilotCF> CFList = new List<PilotCF>();
            TExecuteReaderCmd<PilotCF>(OleDbCmd, TGenerateCFListFromReader<PilotCF>, ref CFList);
            return CFList;
        }
        public override List<PilotCF> GetDisplayCF()
        {
            OleDbCommand OleDbCmd = new OleDbCommand();
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_CF);
            List<PilotCF> CFList = new List<PilotCF>();
            TExecuteReaderCmd<PilotCF>(OleDbCmd, TGenerateCFListFromReader<PilotCF>, ref CFList);
            return CFList;
        }


        public override int InsertCF(string Caption, bool IsDisplay, int SortID)
        {

            OleDbCommand OleDbCmd = new OleDbCommand();

            AddParamToOleDbCmd(OleDbCmd, "Caption", OleDbType.VarWChar, 100, Caption);
            AddParamToOleDbCmd(OleDbCmd, "IsDisplay", OleDbType.Boolean, 1, IsDisplay);
            AddParamToOleDbCmd(OleDbCmd, "SortID", OleDbType.Integer, 0, SortID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_INSERT_CF);
            //ExecuteScalarCmd(OleDbCmd);

            return (ExecuteScalarCmdGetIdentity(OleDbCmd));

        }
        public override bool UpdateCF(int ID, string Caption, bool IsDisplay, int SortID)
        {


            OleDbCommand OleDbCmd = new OleDbCommand();


            AddParamToOleDbCmd(OleDbCmd, "Caption", OleDbType.VarWChar, 100, Caption);
            AddParamToOleDbCmd(OleDbCmd, "IsDisplay", OleDbType.Boolean, 1, IsDisplay);
            AddParamToOleDbCmd(OleDbCmd, "SortID", OleDbType.Integer, 0, SortID);
            AddParamToOleDbCmd(OleDbCmd, "ID", OleDbType.Integer, 0, ID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_UPDATE_CF);
            ExecuteNonQueryCmd(OleDbCmd);


            return true;

        }
        public override bool RemoveCF(int ID)
        {

            if (ID <= 0)
                throw (new ArgumentOutOfRangeException("ID"));

            OleDbCommand OleDbCmd = new OleDbCommand();

            //AddParamToOleDbCmd(OleDbCmd, "@ReturnValue", OleDbType.Integer, 0, ParameterDirection.ReturnValue, null);
            AddParamToOleDbCmd(OleDbCmd, "ID", OleDbType.Integer, 0, ID);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_REMOVE_CF);
            ExecuteNonQueryCmd(OleDbCmd);

            //int returnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;

            //return (returnValue == 0 ? true : false);
            return true;
        }

        #endregion

        #region Store METHODS
        //Static constants
        private const string SQL_SELECT_STORE = "SELECT S.ID, S.AreaID, S.StoreName, S.Tel,S.Address,S.URL,S.IsDisplay,A.Name AS AreaName ,S.SortID,S.Note FROM Store S INNER JOIN StoreArea A  ON S.AreaID = A.ID  WHERE (S.ID = @ID)";
        private const string SQL_SELECT_ALL_STORE = "SELECT S.ID, S.AreaID, S.StoreName, S.Tel,S.Address,S.URL,S.IsDisplay,A.Name AS AreaName ,S.SortID,S.Note FROM Store S INNER JOIN  StoreArea A  ON S.AreaID = A.ID WHERE (IsDelete = False) ORDER BY A.ID,S.SortID";
        private const string SQL_SELECT_ALL_DISPLAY_STORE = "SELECT S.ID, S.AreaID, S.StoreName, S.Tel,S.Address,S.URL,S.IsDisplay,A.Name AS AreaName ,S.SortID,S.Note FROM  Store S INNER JOIN  StoreArea A  ON S.AreaID = A.ID WHERE (IsDelete = False) AND (IsDisplay = TRUE) ORDER BY A.ID,S.SortID";
        private const string SQL_SELECT_ALL_DISPLAY_STORE_BY_AREAID = "SELECT S.ID, S.AreaID, S.StoreName, S.Tel,S.Address,S.URL,S.IsDisplay,A.Name AS AreaName  ,S.SortID,S.Note FROM  Store S INNER JOIN  StoreArea A  ON S.AreaID = A.ID WHERE (IsDelete = False) AND (IsDisplay = TRUE) AND (AreaID = @AreaID) ORDER BY  A.ID,S.SortID";
        private const string SQL_INSERT_STORE = "INSERT INTO Store ( AreaID, StoreName, Tel,Address,URL,IsDisplay,SortID,Note) VALUES(  @AreaID, @StoreName, @Tel,@Address,@URL,@IsDisplay,@SortID,@Note); ";
        private const string SQL_UPDATE_STORE = "UPDATE Store SET  AreaID=@AreaID, StoreName=@StoreName, Tel=@Tel,Address=@Address,URL=@URL,IsDisplay=@IsDisplay,SortID=@SortID ,Note=@Note WHERE ID=@ID;";
        private const string SQL_REMOVE_STORE = "UPDATE Store SET IsDelete=1,DeletedDate=GetDate() WHERE ID=@ID; SELECT @ReturnValue=@@ERROR;SELECT @ReturnValue;";

        public override Store GetStoreById(int ID)
        {
            if (ID <= 0)
            {
                throw (new ArgumentOutOfRangeException("ID"));
            }
            OleDbCommand OleDbCmd = new OleDbCommand();
            AddParamToOleDbCmd(OleDbCmd, "@ID", OleDbType.Integer, 0, ID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_STORE);
            List<Store> storeList = new List<Store>();
            TExecuteReaderCmd<Store>(OleDbCmd, Store_TGenerateListFromReader<Store>, ref storeList);
            if (storeList.Count > 0)
                return storeList[0];
            else
                return null;
        }
        public override List<Store> GetStore()
        {
            OleDbCommand OleDbCmd = new OleDbCommand();
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_STORE);
            List<Store> storeList = new List<Store>();
            TExecuteReaderCmd<Store>(OleDbCmd, Store_TGenerateListFromReader<Store>, ref storeList);
            return storeList;
        }
        public override List<Store> GetDisplayStore()
        {
            OleDbCommand OleDbCmd = new OleDbCommand();
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_STORE);
            List<Store> storeList = new List<Store>();
            TExecuteReaderCmd<Store>(OleDbCmd, Store_TGenerateListFromReader<Store>, ref storeList);
            return storeList;
        }
        public override List<Store> GetDisplayStoreByArea(int AreaID)
        {

            if (AreaID <= 0)
            {
                throw (new ArgumentOutOfRangeException("AreaID"));
            }
            OleDbCommand OleDbCmd = new OleDbCommand();
            AddParamToOleDbCmd(OleDbCmd, "@AreaID", OleDbType.Integer, 0, AreaID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_STORE_BY_AREAID);
            List<Store> storeList = new List<Store>();
            TExecuteReaderCmd<Store>(OleDbCmd, Store_TGenerateListFromReader<Store>, ref storeList);
            return storeList;
        }

        public override int InsertStore(int AreaID, string StoreName, string Tel, string Address, string URL, bool IsDisplay, int SortID, string Note)
        {

            OleDbCommand OleDbCmd = new OleDbCommand();

            AddParamToOleDbCmd(OleDbCmd, "@ReturnValue", OleDbType.Integer, 0, null);
            AddParamToOleDbCmd(OleDbCmd, "@ID", OleDbType.Integer, 0, null);

            AddParamToOleDbCmd(OleDbCmd, "@AreaID", OleDbType.Integer, 0, AreaID);
            AddParamToOleDbCmd(OleDbCmd, "@StoreName", OleDbType.VarWChar, 50, StoreName);
            AddParamToOleDbCmd(OleDbCmd, "@IsDisplay", OleDbType.Boolean, 1, IsDisplay);
            AddParamToOleDbCmd(OleDbCmd, "@Tel", OleDbType.VarWChar, 50, Tel);
            AddParamToOleDbCmd(OleDbCmd, "@Address", OleDbType.VarWChar, 300, Address);
            AddParamToOleDbCmd(OleDbCmd, "@URL", OleDbType.VarWChar, 200, URL);
            AddParamToOleDbCmd(OleDbCmd, "@SortID", OleDbType.Integer, 0, SortID);
            AddParamToOleDbCmd(OleDbCmd, "@Note", OleDbType.VarWChar, 1500, Note);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_INSERT_STORE);
            return (ExecuteScalarCmdGetIdentity(OleDbCmd));


        }
        public override bool UpdateStore(int ID, int AreaID, string StoreName, string Tel, string Address, string URL, bool IsDisplay, int SortID, string Note)
        {

            OleDbCommand OleDbCmd = new OleDbCommand();

           
            AddParamToOleDbCmd(OleDbCmd, "@ID", OleDbType.Integer, 0, ID);
            AddParamToOleDbCmd(OleDbCmd, "@AreaID", OleDbType.Integer, 0, AreaID);
            AddParamToOleDbCmd(OleDbCmd, "@StoreName", OleDbType.VarWChar, 50, StoreName);
            AddParamToOleDbCmd(OleDbCmd, "@IsDisplay", OleDbType.Boolean, 1, IsDisplay);
            AddParamToOleDbCmd(OleDbCmd, "@Tel", OleDbType.VarWChar, 50, Tel);
            AddParamToOleDbCmd(OleDbCmd, "@Address", OleDbType.VarWChar, 300, Address);
            AddParamToOleDbCmd(OleDbCmd, "@URL", OleDbType.VarWChar, 200, URL);
            AddParamToOleDbCmd(OleDbCmd, "@SortID", OleDbType.Integer, 0, SortID);
            AddParamToOleDbCmd(OleDbCmd, "@Note", OleDbType.VarWChar, 1500, Note);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_UPDATE_STORE);
            ExecuteNonQueryCmd(OleDbCmd);


            return true;

        }
        public override bool RemoveStore(int ID)
        {

            if (ID <= 0)
                throw (new ArgumentOutOfRangeException("ID"));

            OleDbCommand OleDbCmd = new OleDbCommand();

             AddParamToOleDbCmd(OleDbCmd, "@ID", OleDbType.Integer, 0, ID);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_REMOVE_STORE);
            ExecuteNonQueryCmd(OleDbCmd);
 
            return true;

        }

        #endregion

        #region PilotStar METHODS
        //Static constants 
        private const string SQL_SELECT_PilotStar = "SELECT  ID,Caption, Url FROM PilotStar WHERE (ID = @ID)";
        private const string SQL_SELECT_ALL_PilotStar = "SELECT ID,Caption, Url FROM PilotStar  WHERE ORDER BY ID";
        private const string SQL_SELECT_ALL_DISPLAY_PilotStar = "SELECT ID,Caption, Url FROM  PilotStar WHERE   ORDER BY ID";


        private const string SQL_INSERT_PilotStar = " INSERT INTO PilotStar (Caption, Url) VALUES( @Caption,  @Url )";
        private const string SQL_UPDATE_PilotStar = " UPDATE PilotStar SET  Caption=@Caption,  Url=@Url  WHERE ID=@ID";
        private const string SQL_REMOVE_PilotStar = " DELETE FROM  PilotStar   WHERE ID=@ID";

        public override PilotStar GetPilotStarById(int ID)
        {
            if (ID <= 0)
            {
                throw (new ArgumentOutOfRangeException("ID"));
            }
            OleDbCommand OleDbCmd = new OleDbCommand();
            AddParamToOleDbCmd(OleDbCmd, "ID", OleDbType.Integer, 0, ID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_PilotStar);
            List<PilotStar> PilotStarList = new List<PilotStar>();
            TExecuteReaderCmd<PilotStar>(OleDbCmd, TGeneratePilotStarListFromReader<PilotStar>, ref PilotStarList);
            if (PilotStarList.Count > 0)
                return PilotStarList[0];
            else
                return null;
        }

        public override List<PilotStar> GetPilotStar()
        {
            OleDbCommand OleDbCmd = new OleDbCommand();
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_PilotStar);
            List<PilotStar> PilotStarList = new List<PilotStar>();
            TExecuteReaderCmd<PilotStar>(OleDbCmd, TGeneratePilotStarListFromReader<PilotStar>, ref PilotStarList);
            return PilotStarList;
        }



        public override int InsertPilotStar(string Caption, string Url)
        {

            OleDbCommand OleDbCmd = new OleDbCommand();

            AddParamToOleDbCmd(OleDbCmd, "Caption", OleDbType.VarWChar, 100, Caption);
            AddParamToOleDbCmd(OleDbCmd, "Url", OleDbType.VarWChar, 255, Url);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_INSERT_PilotStar);
            //ExecuteScalarCmd(OleDbCmd);

            return (ExecuteScalarCmdGetIdentity(OleDbCmd));

        }
        public override bool UpdatePilotStar(int ID, string Caption, string Url)
        {


            OleDbCommand OleDbCmd = new OleDbCommand();


            AddParamToOleDbCmd(OleDbCmd, "Caption", OleDbType.VarWChar, 100, Caption);
            AddParamToOleDbCmd(OleDbCmd, "Url", OleDbType.VarWChar, 255, Url);
            AddParamToOleDbCmd(OleDbCmd, "ID", OleDbType.Integer, 0, ID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_UPDATE_PilotStar);
            ExecuteNonQueryCmd(OleDbCmd);


            return true;

        }
        public override bool RemovePilotStar(int ID)
        {

            if (ID <= 0)
                throw (new ArgumentOutOfRangeException("ID"));

            OleDbCommand OleDbCmd = new OleDbCommand();

            //AddParamToOleDbCmd(OleDbCmd, "@ReturnValue", OleDbType.Integer, 0, ParameterDirection.ReturnValue, null);
            AddParamToOleDbCmd(OleDbCmd, "ID", OleDbType.Integer, 0, ID);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_REMOVE_PilotStar);
            ExecuteNonQueryCmd(OleDbCmd);

            //int returnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;

            //return (returnValue == 0 ? true : false);
            return true;
        }

        #endregion

        #region Wallpaper METHODS
        //Static constants 
        private const string SQL_SELECT_Wallpaper = "SELECT  ID,Caption,IsDisplay,SortID FROM Wallpaper WHERE (ID = @ID)";
        private const string SQL_SELECT_ALL_Wallpaper = "SELECT ID,Caption,IsDisplay,SortID FROM Wallpaper  WHERE (IsDelete = 0) ORDER BY  SortID";
        private const string SQL_SELECT_ALL_DISPLAY_Wallpaper = "SELECT ID,Caption,IsDisplay,SortID FROM  Wallpaper WHERE (IsDelete = False) AND (IsDisplay = True) ORDER BY SortID";


        private const string SQL_INSERT_Wallpaper = " INSERT INTO Wallpaper (Caption,IsDisplay,SortID) VALUES(@MainID ,@Caption,@IsDisplay, @SortID )";
        private const string SQL_UPDATE_Wallpaper = " UPDATE Wallpaper SET MainID=@MainID ,Caption=@Caption,IsDisplay=@IsDisplay, SortID=@SortID  WHERE ID=@ID";
        private const string SQL_REMOVE_Wallpaper = " UPDATE Wallpaper SET IsDelete=True  WHERE ID=@ID";

        public override Wallpaper GetWallpaperById(int ID)
        {
            if (ID <= 0)
            {
                throw (new ArgumentOutOfRangeException("ID"));
            }
            OleDbCommand OleDbCmd = new OleDbCommand();
            AddParamToOleDbCmd(OleDbCmd, "ID", OleDbType.Integer, 0, ID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_Wallpaper);
            List<Wallpaper> WallpaperList = new List<Wallpaper>();
            TExecuteReaderCmd<Wallpaper>(OleDbCmd, TGenerateWallpaperListFromReader<Wallpaper>, ref WallpaperList);
            if (WallpaperList.Count > 0)
                return WallpaperList[0];
            else
                return null;
        }

        public override List<Wallpaper> GetWallpaper()
        {
            OleDbCommand OleDbCmd = new OleDbCommand();
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_Wallpaper);
            List<Wallpaper> WallpaperList = new List<Wallpaper>();
            TExecuteReaderCmd<Wallpaper>(OleDbCmd, TGenerateWallpaperListFromReader<Wallpaper>, ref WallpaperList);
            return WallpaperList;
        }
        public override List<Wallpaper> GetDisplayWallpaper()
        {
            OleDbCommand OleDbCmd = new OleDbCommand();
            SetCommandType(OleDbCmd, CommandType.Text, SQL_SELECT_ALL_DISPLAY_Wallpaper);
            List<Wallpaper> WallpaperList = new List<Wallpaper>();
            TExecuteReaderCmd<Wallpaper>(OleDbCmd, TGenerateWallpaperListFromReader<Wallpaper>, ref WallpaperList);
            return WallpaperList;
        }


        public override int InsertWallpaper(string Caption, bool IsDisplay, int SortID)
        {

            OleDbCommand OleDbCmd = new OleDbCommand();

            AddParamToOleDbCmd(OleDbCmd, "Caption", OleDbType.VarWChar, 100, Caption);
            AddParamToOleDbCmd(OleDbCmd, "IsDisplay", OleDbType.Boolean, 1, IsDisplay);
            AddParamToOleDbCmd(OleDbCmd, "SortID", OleDbType.Integer, 0, SortID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_INSERT_Wallpaper);
            //ExecuteScalarCmd(OleDbCmd);

            return (ExecuteScalarCmdGetIdentity(OleDbCmd));

        }
        public override bool UpdateWallpaper(int ID, string Caption, bool IsDisplay, int SortID)
        {


            OleDbCommand OleDbCmd = new OleDbCommand();


            AddParamToOleDbCmd(OleDbCmd, "Caption", OleDbType.VarWChar, 100, Caption);
            AddParamToOleDbCmd(OleDbCmd, "IsDisplay", OleDbType.Boolean, 1, IsDisplay);
            AddParamToOleDbCmd(OleDbCmd, "SortID", OleDbType.Integer, 0, SortID);
            AddParamToOleDbCmd(OleDbCmd, "ID", OleDbType.Integer, 0, ID);
            SetCommandType(OleDbCmd, CommandType.Text, SQL_UPDATE_Wallpaper);
            ExecuteNonQueryCmd(OleDbCmd);


            return true;

        }
        public override bool RemoveWallpaper(int ID)
        {

            if (ID <= 0)
                throw (new ArgumentOutOfRangeException("ID"));

            OleDbCommand OleDbCmd = new OleDbCommand();

            //AddParamToOleDbCmd(OleDbCmd, "@ReturnValue", OleDbType.Integer, 0, ParameterDirection.ReturnValue, null);
            AddParamToOleDbCmd(OleDbCmd, "ID", OleDbType.Integer, 0, ID);

            SetCommandType(OleDbCmd, CommandType.Text, SQL_REMOVE_Wallpaper);
            ExecuteNonQueryCmd(OleDbCmd);

            //int returnValue = (int)OleDbCmd.Parameters["@ReturnValue"].Value;

            //return (returnValue == 0 ? true : false);
            return true;
        }

        #endregion
        /*****************************  GENARATE List HELPER METHODS *****************************/
        #region GENARATE List HELPER METHODS



        //Category
        private void TGenerateCategoryListFromReader<T>(OleDbDataReader returnData, ref List<Category> itemList)
        {
            while (returnData.Read())
            {
                //int CategoryID, string Name, bool IsDisplay, string Spec, string Description, int SortID
                int CategoryID = 0;
                if (returnData["CategoryID"] != DBNull.Value) { CategoryID = Convert.ToInt32(returnData["CategoryID"]); }

                int MainID = 0;
                if (returnData["MainID"] != DBNull.Value) { MainID = Convert.ToInt32(returnData["MainID"]); }

                string Name = string.Empty;
                if (returnData["Name"] != DBNull.Value) { Name = Convert.ToString(returnData["Name"]); }

                bool IsDisplay = false;
                if (returnData["IsDisplay"] != DBNull.Value) { IsDisplay = Convert.ToBoolean(returnData["IsDisplay"]); }

                
                int SortID = 0;
                if (returnData["SortID"] != DBNull.Value) { SortID = Convert.ToInt32(returnData["SortID"]); }
 
                Category ct = new Category(CategoryID,MainID, Name, IsDisplay,   SortID );
                itemList.Add(ct);
            }
        }

        //Product
        private void TGenerateProductListFromReader<T>(OleDbDataReader returnData, ref List<Product> itemList)
        {
            while (returnData.Read())
            {


                //    int ProductID,
                //int CategoryID,
                //string SKU,
                //string Name,
                //string Spec,
                //OrientationType Orientation,
                //string Price,
                //bool IsDisplay,
                //int SortID
                int ProductID = 0;
                if (returnData["ProductID"] != DBNull.Value) { ProductID = Convert.ToInt32(returnData["ProductID"]); }

                int CategoryID = 0;
                if (returnData["CategoryID"] != DBNull.Value) { CategoryID = Convert.ToInt32(returnData["CategoryID"]); }

                
                string Name = string.Empty;
                if (returnData["Name"] != DBNull.Value) { Name = Convert.ToString(returnData["Name"]); }



                string Spec = string.Empty;
                if (returnData["Spec"] != DBNull.Value) { Spec = Convert.ToString(returnData["Spec"]); }


                string Description = string.Empty;
                if (returnData["Description"] != DBNull.Value) { Description = Convert.ToString(returnData["Description"]); }

                int intImageType = 1;
                if (returnData["ImageType"] != DBNull.Value) { intImageType = Convert.ToInt32(returnData["ImageType"]); }

                Product.ImageDisplayType ImageType = Product.ImageDisplayType.SingleImage;
                switch (intImageType)
                {
                    case 1:
                        ImageType = Product.ImageDisplayType.MultiImage;
                        break;
                    default:
                        ImageType = Product.ImageDisplayType.SingleImage;
                        break;
                }

                string Price = string.Empty;
                if (returnData["Price"] != DBNull.Value) { Price = Convert.ToString(returnData["Price"]); }

                bool IsDisplay = false;
                if (returnData["IsDisplay"] != DBNull.Value) { IsDisplay = Convert.ToBoolean(returnData["IsDisplay"]); }

                int SortID = 0;
                if (returnData["SortID"] != DBNull.Value) { SortID = Convert.ToInt32(returnData["SortID"]); }

                Product pt = new Product(ProductID, CategoryID,Name,  Spec, Description,ImageType, Price, IsDisplay, SortID);
                itemList.Add(pt);
            }
        }

        //Message
        private void TGenerateMessageListFromReader<T>(OleDbDataReader returnData, ref List<Message> itemList)
        {
            while (returnData.Read())
            {
                //int MsgID, string Name, string Title, string Email, string Contact, string Company, string Content, string Note, bool IsDone, DateTime CreationDate, DateTime UpdateDate
                int MsgID = 0;
                if (returnData["MsgID"] != DBNull.Value) { MsgID = Convert.ToInt32(returnData["MsgID"]); }

                string Name = string.Empty;
                if (returnData["Name"] != DBNull.Value) { Name = Convert.ToString(returnData["Name"]); }

                string Title = string.Empty;
                if (returnData["Title"] != DBNull.Value) { Title = Convert.ToString(returnData["Title"]); }

                string Email = string.Empty;
                if (returnData["Email"] != DBNull.Value) { Email = Convert.ToString(returnData["Email"]); }

                string Contact = string.Empty;
                if (returnData["Contact"] != DBNull.Value) { Contact = Convert.ToString(returnData["Contact"]); }

                string Company = string.Empty;
                if (returnData["Company"] != DBNull.Value) { Company = Convert.ToString(returnData["Company"]); }

                string Content = string.Empty;
                if (returnData["Content"] != DBNull.Value) { Content = Convert.ToString(returnData["Content"]); }

                string Note = string.Empty;
                if (returnData["Note"] != DBNull.Value) { Note = Convert.ToString(returnData["Note"]); }

                bool IsDone = false;
                if (returnData["IsDone"] != DBNull.Value) { IsDone = Convert.ToBoolean(returnData["IsDone"]); }

                DateTime CreationDate = DateTime.MinValue;
                if (returnData["CreationDate"] != DBNull.Value) { CreationDate = Convert.ToDateTime(returnData["CreationDate"]); }

                DateTime UpdateDate = DateTime.MinValue;
                if (returnData["UpdateDate"] != DBNull.Value) { UpdateDate = Convert.ToDateTime(returnData["UpdateDate"]); }

                string IP = string.Empty;
                if (returnData["IP"] != DBNull.Value) { IP = Convert.ToString(returnData["IP"]); }


                Message ct = new Message(MsgID, Name, Title, Email, Contact, Company, Content, Note, IsDone, CreationDate, UpdateDate,IP);


                itemList.Add(ct);
            }
  }
             //Color
        private void TGenerateColorListFromReader<T>(OleDbDataReader returnData, ref List<Color> itemList)
        {
            while (returnData.Read())
            {
                //int CategoryID, string Name, bool IsDisplay, string Spec, string Description, int SortID
                int ColorID = 0;
                if (returnData["ColorID"] != DBNull.Value) { ColorID = Convert.ToInt32(returnData["ColorID"]); }

              
                string Name = string.Empty;
                if (returnData["Name"] != DBNull.Value) { Name = Convert.ToString(returnData["Name"]); }

                 string Code = string.Empty;
                if (returnData["Code"] != DBNull.Value) { Code = Convert.ToString(returnData["Code"]); }

                Color ct = new Color(ColorID,  Name,Code );
                itemList.Add(ct);
            }
        }
      
        //News
        private void News_TGenerateListFromReader<T>(OleDbDataReader returnData, ref List<News> dataList)
        {
            while (returnData.Read())
            {
                // 
                int ID = 0;
                if (returnData["ID"] != DBNull.Value) { ID = Convert.ToInt32(returnData["ID"]); }


                string Caption = string.Empty;
                if (returnData["Caption"] != DBNull.Value) { Caption = Convert.ToString(returnData["Caption"]); }

                string Foreword = string.Empty;
                if (returnData["Foreword"] != DBNull.Value) { Foreword = Convert.ToString(returnData["Foreword"]); }

                string Content = string.Empty;
                if (returnData["Content"] != DBNull.Value) { Content = Convert.ToString(returnData["Content"]); }

                bool IsDisplayImage = false;
                if (returnData["IsDisplayImage"] != DBNull.Value) { IsDisplayImage = Convert.ToBoolean(returnData["IsDisplayImage"]); }

                bool IsApproved = false;
                if (returnData["IsApproved"] != DBNull.Value) { IsApproved = Convert.ToBoolean(returnData["IsApproved"]); }

                bool IsMainPageDisplay = false;
                if (returnData["IsMainPageDisplay"] != DBNull.Value) { IsMainPageDisplay = Convert.ToBoolean(returnData["IsMainPageDisplay"]); }

                
                DateTime CreationDate = DateTime.MaxValue;
                if (returnData["CreationDate"] != DBNull.Value) { CreationDate = Convert.ToDateTime(returnData["CreationDate"]); }

                News currentItem = new News(ID, Caption, Foreword, Content,IsDisplayImage, IsApproved, IsMainPageDisplay, CreationDate);

                dataList.Add(currentItem);
            }
        }


        //CF
        private void TGenerateCFListFromReader<T>(OleDbDataReader returnData, ref List<PilotCF> itemList)
        {
            while (returnData.Read())
            {
                int ID = 0;
                 if (returnData["ID"] != DBNull.Value) { ID = Convert.ToInt32(returnData["ID"]); }

                
                string Caption = string.Empty;
                if (returnData["Caption"] != DBNull.Value) { Caption = Convert.ToString(returnData["Caption"]); }

                bool IsDisplay = false;
                if (returnData["IsDisplay"] != DBNull.Value) { IsDisplay = Convert.ToBoolean(returnData["IsDisplay"]); }


                int SortID = 0;
                if (returnData["SortID"] != DBNull.Value) { SortID = Convert.ToInt32(returnData["SortID"]); }

                PilotCF ct = new PilotCF(ID,   Caption, IsDisplay, SortID);
                itemList.Add(ct);
            }
        }
        
        //Store
        private void Store_TGenerateListFromReader<T>(OleDbDataReader returnData, ref List<Store> dataList)
        {
            while (returnData.Read())
            {
                //int AreaID, string StoreName, string Tel, string Address, bool IsDisplay
                int ID = 0;
                if (returnData["ID"] != DBNull.Value) { ID = Convert.ToInt32(returnData["ID"]); }

                int AreaID = 0;
                if (returnData["AreaID"] != DBNull.Value) { AreaID = Convert.ToInt32(returnData["AreaID"]); }

                string StoreName = string.Empty;
                if (returnData["StoreName"] != DBNull.Value) { StoreName = Convert.ToString(returnData["StoreName"]); }

                string Tel = string.Empty;
                if (returnData["Tel"] != DBNull.Value) { Tel = Convert.ToString(returnData["Tel"]); }

                string Address = string.Empty;
                if (returnData["Address"] != DBNull.Value) { Address = Convert.ToString(returnData["Address"]); }

                string URL = string.Empty;
                if (returnData["URL"] != DBNull.Value) { URL = Convert.ToString(returnData["URL"]); }

                bool IsDisplay = false;
                if (returnData["IsDisplay"] != DBNull.Value) { IsDisplay = Convert.ToBoolean(returnData["IsDisplay"]); }

                string AreaName = string.Empty;
                if (returnData["AreaName"] != DBNull.Value) { AreaName = Convert.ToString(returnData["AreaName"]); }

                int SortID = 0;
                if (returnData["SortID"] != DBNull.Value) { SortID = Convert.ToInt32(returnData["SortID"]); }

                string Note = string.Empty;
                if (returnData["Note"] != DBNull.Value) { Note = Convert.ToString(returnData["Note"]); }


                Store currentItem = new Store(ID, AreaID, StoreName, Tel, Address, URL, IsDisplay, SortID, Note);
                currentItem.AreaName = AreaName;
                
                dataList.Add(currentItem);
            }
        }


        //PilotStar
        private void TGeneratePilotStarListFromReader<T>(OleDbDataReader returnData, ref List<PilotStar> itemList)
        {
            while (returnData.Read())
            {
                int ID = 0;
                if (returnData["ID"] != DBNull.Value) { ID = Convert.ToInt32(returnData["ID"]); }


                string Caption = string.Empty;
                if (returnData["Caption"] != DBNull.Value) { Caption = Convert.ToString(returnData["Caption"]); }


                string Url = string.Empty;
                if (returnData["Url"] != DBNull.Value) { Url = Convert.ToString(returnData["Url"]); }

                PilotStar ct = new PilotStar(ID, Caption, Url);
                itemList.Add(ct);
            }
        }

        //Wallpaper
        private void TGenerateWallpaperListFromReader<T>(OleDbDataReader returnData, ref List<Wallpaper> itemList)
        {
            while (returnData.Read())
            {
                int ID = 0;
                if (returnData["ID"] != DBNull.Value) { ID = Convert.ToInt32(returnData["ID"]); }


                string Caption = string.Empty;
                if (returnData["Caption"] != DBNull.Value) { Caption = Convert.ToString(returnData["Caption"]); }

                bool IsDisplay = false;
                if (returnData["IsDisplay"] != DBNull.Value) { IsDisplay = Convert.ToBoolean(returnData["IsDisplay"]); }


                int SortID = 0;
                if (returnData["SortID"] != DBNull.Value) { SortID = Convert.ToInt32(returnData["SortID"]); }

                Wallpaper ct = new Wallpaper(ID, Caption, IsDisplay, SortID);
                itemList.Add(ct);
            }
        }
       
        #endregion

        /*****************************  SQL HELPER METHODS *****************************/
        #region SQL HELPER METHODS
        private int ExecuteScalarCmdGetIdentity(OleDbCommand OleDbCmd)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCmd.Connection = cn;
                cn.Open();
                OleDbCmd.ExecuteScalar();

                int newID = 0;
                OleDbCommand cmdGetIdentity = new OleDbCommand();
                cmdGetIdentity.CommandType = CommandType.Text;
                cmdGetIdentity.CommandText = "SELECT @@IDENTITY";
                cmdGetIdentity.Connection = cn;

                newID = (int)cmdGetIdentity.ExecuteScalar();
                return newID;
            }
        }
        private void AddParamToOleDbCmd(OleDbCommand OleDbCmd,
                                      string paramId,
                                       OleDbType sqlType,
                                      int paramSize,
                                      object paramvalue)
        {

            if (OleDbCmd == null)
                throw (new ArgumentNullException("OleDbCmd"));
            if (paramId == string.Empty)
                throw (new ArgumentOutOfRangeException("paramId"));

            OleDbParameter newOleDbParam = new OleDbParameter(paramId, sqlType);

            if (paramSize > 0)
            {
                newOleDbParam.Size = paramSize;
            }

            if (paramvalue != null)
            {
                newOleDbParam.Value = paramvalue;
            }

            OleDbCmd.Parameters.Add(newOleDbParam);
        }


        private void ExecuteScalarCmd(OleDbCommand OleDbCmd)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (OleDbCmd == null)
                throw (new ArgumentNullException("OleDbCmd"));


            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCmd.Connection = cn;
                cn.Open();
                OleDbCmd.ExecuteScalar();
            }
        }
        private void ExecuteNonQueryCmd(OleDbCommand OleDbCmd)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (OleDbCmd == null)
                throw (new ArgumentNullException("OleDbCmd"));


            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCmd.Connection = cn;
                cn.Open();
                OleDbCmd.ExecuteNonQuery();
            }
        }

        private void SetCommandType(OleDbCommand OleDbCmd, CommandType cmdType, string cmdText)
        {
            OleDbCmd.CommandType = cmdType;
            OleDbCmd.CommandText = cmdText;
        }


        private void TExecuteReaderCmd<T>(OleDbCommand OleDbCmd, TGenerateListFromReader<T> gcfr, ref List<T> List)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (OleDbCmd == null)
                throw (new ArgumentNullException("OleDbCmd"));


            using (OleDbConnection cn = new OleDbConnection(this.ConnectionString))
            {
                OleDbCmd.Connection = cn;
                cn.Open();
                OleDbDataReader reader = OleDbCmd.ExecuteReader();
                gcfr(reader, ref List);
                reader.Close();

            }
        }
        #endregion


    }
}