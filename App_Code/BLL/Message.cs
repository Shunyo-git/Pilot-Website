using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Pilot.DataAccessLayer;

namespace Pilot.BusinessLogicLayer
{

    /// <summary>
    /// Message 的摘要描述
    /// </summary>
    /// 
    public class Message
    {
        private int _msgID;
        private string _name;
        private string _title;
        private string _email;
        private string _contact;
        private string _company;
        private string _content;
        private string _note;
        private bool _isDone;
        private DateTime _creationDate;
        private DateTime _updateDate;
        private string _ip;
       
        public Message()
        {

        }

        public Message(int MsgID, string Name, string Title, string Email, string Contact, string Company, string Content, string Note, bool IsDone, DateTime CreationDate, DateTime UpdateDate,string IP)
        {
            this.MsgID = MsgID;
            this.Name = Name;
            this.Title = Title;
            this.Email = Email;
            this.Contact = Contact;
            this.Company = Company;
            this.Content = Content;
            this.Note = Note;
            this.IsDone = IsDone;
            this.CreationDate = CreationDate;
            this.UpdateDate = UpdateDate;
            this.IP = IP;
        }

        public int MsgID
        {
            get
            {
                return _msgID;
            }
            set
            {
                _msgID = value;
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
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
            }
        }
        public string Company
        {
            get
            {
                return _company;
            }
            set
            {
                _company = value;
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
        public bool IsDone
        {
            get
            {
                return _isDone;
            }
            set
            {
                _isDone = value;
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
        public DateTime UpdateDate
        {
            get
            {
                return _updateDate;
            }
            set
            {
                _updateDate = value;
            }
        }
        public string IP
        {
            get
            {
                return _ip;
            }
            set
            {
                _ip = value;
            }
        }
        /*** METHODS  ***/
        public bool Remove()
        {

            return Remove(this.MsgID);
        }

        public bool Save()
        {

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            if (MsgID > 0)
            {

                return DALLayer.UpdateMessage(this.MsgID, this.Note, this.IsDone);
            }
            else
            {
                MsgID = DALLayer.InsertMessage(this.Name, this.Title, this.Email, this.Contact, this.Company, this.Content, this.IP);
                return (MsgID > 0);
            }

        }

        /*** METHOD STATIC ***/
        public static bool Remove(int MsgID)
        {
            if (MsgID > 0)
            {
                DataAccess DALLayer = DataAccessHelper.GetDataAccess();
                return DALLayer.RemoveMessage(MsgID);
            }
            else
                return false;
        }

        public static Message GetMessage(int MsgID)
        {
            if (MsgID <= 0)
                return (null);

            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetMessageById(MsgID));
        }

        public static List<Message> GetMessage()
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetMessage());
        }

        public static List<Message> GetMessage(string sortParameter)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();

            List<Message> dataList = DALLayer.GetMessage();

            if (!String.IsNullOrEmpty(sortParameter))
                dataList.Sort(new MessageComparer(sortParameter));

            return (dataList);
        }
 
        public static List<Message> GetMessage(bool IsDone)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetMessage(IsDone));
        }

        public static List<Message> FindMessage(string Keyword)
        {
            DataAccess DALLayer = DataAccessHelper.GetDataAccess();
            return (DALLayer.GetMessage(Keyword));
        }
        public static List<Message> FindMessage(string Keyword, string sortParameter)
        {
       
            List<Message> dataList = FindMessage(Keyword);
            if (!String.IsNullOrEmpty(sortParameter))
                dataList.Sort(new MessageComparer(sortParameter));
            return dataList;
        }
    }
}