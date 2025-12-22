using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firstname;
        private string middlename;
        private string lastname;
        private string nickname;
        private string title;
        private string company;
        private string address;
        private string home;
        private string mobile;
        private string work;
        private string email;
        private string email2;
        private string email3;
        private string homepage;
        private string bday;
        private string bmonth;
        private string byear;
        private string aday;
        private string amonth;
        private string ayear;


        public ContactData(string firstname, string middlename, string lastname, string nickname, string title, string company, string address, string home, string mobile, string work, string email, string email2, string email3, string homepage, string bday, string bmonth, string byear, string aday, string amonth, string ayear)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
            this.nickname = nickname;
            this.title = title;
            this.company = company;
            this.address = address;
            this.home = home;
            this.mobile = mobile;
            this.work = work;
            this.email = email;
            this.email2 = email2;
            this.email3 = email3;
            this.homepage = homepage;
            this.bday = bday;
            this.bmonth = bmonth;
            this.byear = byear;
            this.ayear = aday;
            this.amonth = amonth;
            this.ayear = ayear;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }

        }
        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string Home
        {
            get
            {
                return home;
            }
            set
            {
                home = value;
            }
        }
        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }
        }
        public string Work
        {
            get
            {
                return work;
            }
            set
            {
                work = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }
        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }
        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }
        public string Bday
        {
            get
            {
                return bday;
            }
            set
            {
                bday = value;
            }
        }
        public string Bmonth
        {
            get
            {
                return bmonth;
            }
            set
            {
                bmonth = value;
            }
        }
        public string Byear
        {
            get
            {
                return byear;
            }
            set
            {
                byear = value;
            }
        }
        public string Aday
        {
            get
            {
                return aday;
            }
            set
            {
                aday = value;
            }
        }
        public string Amonth
        {
            get
            {
                return amonth;
            }
            set
            {
                amonth = value;
            }
        }
        public string Ayear
        {
            get
            {
                return ayear;
            }
            set
            {
                ayear = value;
            }
        }
    }
}
