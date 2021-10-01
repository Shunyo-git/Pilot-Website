using System;
using System.Data;
using System.Configuration;


namespace Pilot.BusinessLogicLayer
{
    public enum GenderType
    {
        unknown = 0,
        male = 1,
        female = 2,
    }


    /// <summary>
    /// MemberInfo 的摘要描述
    /// </summary>
    /// <summary>
    /// Business entity used to model addresses
    /// </summary>
    [Serializable]
    public class MemberInfo
    {
       

        // Internal member variables


        private string _ChineseName;
        private string _Email;
        private GenderType _Gender;
        private int _YearofBirth;
        private int _MonthofBirth;
        private int _DayofBirth;
        private string _AgeLevel;
        private string _Eduction;
        private string _Telephone;
        private string _MobilePhone;
        private string _Address;
        private string _ActivityWish;
        private string _OtherWish;
        private string _RegisterIP;
        private string _OrigenalUserName;
        private string _OrigenalPassword;

        /// <summary>
        /// Default constructor
        /// </summary>
        public MemberInfo() { }

        /// <summary>
        /// Constructor with specified initial values
        /// </summary>

        public MemberInfo(string ChineseName, string Email, GenderType Gender, int YearofBirth, int MonthofBirth, int DayofBirth, string AgeLevel, string Eduction, string Telephone, string MobilePhone, string Address, string ActivityWish, string OtherWish, string RegisterIP)
            : this(ChineseName, Email, Gender, YearofBirth, MonthofBirth, DayofBirth, AgeLevel, Eduction, Telephone, MobilePhone, Address, ActivityWish, OtherWish, RegisterIP, string.Empty, string.Empty)
        { }

        public MemberInfo(string ChineseName, string Email, GenderType Gender, int YearofBirth, int MonthofBirth, int DayofBirth, string AgeLevel, string Eduction, string Telephone, string MobilePhone, string Address, string ActivityWish, string OtherWish, string RegisterIP, string OrigenalUserName, string OrigenalPassword)
        {

            this.OrigenalUserName = OrigenalUserName;
            this.OrigenalPassword = OrigenalPassword;
            this.ChineseName = ChineseName;
            this.Email = Email;
            this.Gender = Gender;
            this.YearofBirth = YearofBirth;
            this.MonthofBirth = MonthofBirth;
            this.DayofBirth = DayofBirth;
            this.AgeLevel = AgeLevel;
            this.Eduction = Eduction;
            this.Telephone = Telephone;
            this.MobilePhone = MobilePhone;
            this.Address = Address;
            this.ActivityWish = ActivityWish;
            this.OtherWish = OtherWish;
            this.RegisterIP = RegisterIP;
        }

        // Properties


        public string ChineseName
        {
            get { return _ChineseName; }
            set { _ChineseName = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public GenderType Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        public int YearofBirth
        {
            get { return _YearofBirth; }
            set { _YearofBirth = value; }
        }
        public int MonthofBirth
        {
            get { return _MonthofBirth; }
            set { _MonthofBirth = value; }
        }
        public int DayofBirth
        {
            get { return _DayofBirth; }
            set { _DayofBirth = value; }
        }
        public string AgeLevel
        {
            get { return _AgeLevel; }
            set { _AgeLevel = value; }
        }
        public string Eduction
        {
            get { return _Eduction; }
            set { _Eduction = value; }
        }

        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }
        public string MobilePhone
        {
            get { return _MobilePhone; }
            set { _MobilePhone = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string ActivityWish
        {
            get { return _ActivityWish; }
            set { _ActivityWish = value; }
        }
        public string OtherWish
        {
            get { return _OtherWish; }
            set { _OtherWish = value; }
        }
        public string RegisterIP
        {
            get { return _RegisterIP; }
            set { _RegisterIP = value; }
        }

        public string OrigenalUserName
        {
            get { return _OrigenalUserName; }
            set { _OrigenalUserName = value; }
        }
        public string OrigenalPassword
        {
            get { return _OrigenalPassword; }
            set { _OrigenalPassword = value; }
        }




    }
}
