using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        [XmlIgnore]
        private string allPhones;
        [XmlIgnore]
        private string allEmails;
        [XmlIgnore]
        private string allInfo;

        public ContactData(string firstname, string lastname, string middlename)
        {
            Firstname = firstname;
            Lastname = lastname;
        //    FullName = fullname;
            Middlename = middlename;

        }
        public ContactData(string firstname)
        {
            Firstname = firstname;
        }
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public ContactData()
        {
        }

        public ContactData(string firstname, string middlename, string lastname, string nickname, string title, string company, string address, string home, string mobile, string work, string email, string email2, string email3, string homepage, string bday, string bmonth, string byear, string aday, string amonth, string ayear)
        {
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
            Nickname = nickname;
            Title = title;
            Company = company;
            Address = address;
            HomePhone = home;
            MobilePhone = mobile;
            WorkPhone = work;
            Email = email;
            Email2 = email2;
            Email3 = email3;
            Homepage = homepage;
            Bday = bday;
            Bmonth = bmonth;
            Byear = byear;
            Ayear = aday;
            Amonth = amonth;
            Ayear = ayear;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            if (Lastname == other.Lastname)
                { 
                if (Firstname == other.Firstname)
                {
                    return true;
                }
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;

        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return Firstname + Lastname + Middlename;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int lastnameComparison = Lastname.CompareTo(other.Lastname);
            if (lastnameComparison != 0)
            {
                return lastnameComparison;
            }
            return Firstname.CompareTo(other.Firstname);
        }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string FullName { get; set; }

        [XmlIgnore]
        public string AllInfo
        {
            get
            {
                if (!string.IsNullOrEmpty(allInfo))
                {
                    return allInfo;
                }
                else
                {
                    var parts = new List<string>();

                    if (!string.IsNullOrEmpty(Firstname)) parts.Add(Firstname + " ");
                    if (!string.IsNullOrEmpty(Middlename)) parts.Add(Middlename + " ");
                    if (!string.IsNullOrEmpty(Lastname)) parts.Add(Lastname + "\r\n");

                    if (!string.IsNullOrEmpty(Nickname)) parts.Add(CleanUp(Nickname));
                    if (!string.IsNullOrEmpty(Title)) parts.Add(CleanUp(Title));
                    if (!string.IsNullOrEmpty(Company)) parts.Add(CleanUp(Company));
                    if (!string.IsNullOrEmpty(Address)) parts.Add(CleanUp(Address) + "\r\n");

                    if (!string.IsNullOrEmpty(HomePhone))
                        parts.Add("H: " + CleanUp(HomePhone));
                    if (!string.IsNullOrEmpty(MobilePhone))
                        parts.Add("M: " + CleanUp(MobilePhone));
                    if (!string.IsNullOrEmpty(WorkPhone))
                        parts.Add("W: " + CleanUp(WorkPhone) + "\r\n");

                    if (!string.IsNullOrEmpty(Email)) parts.Add(CleanUp(Email));
                    if (!string.IsNullOrEmpty(Email2)) parts.Add(CleanUp(Email2));
                    if (!string.IsNullOrEmpty(Email3)) parts.Add(CleanUp(Email3));

                    if (!string.IsNullOrEmpty(Homepage)) parts.Add(CleanUp(Homepage));

                    if (!string.IsNullOrEmpty(Bday)) parts.Add(CleanUp(Bday));
                    if (!string.IsNullOrEmpty(Bmonth)) parts.Add(CleanUp(Bmonth));
                    if (!string.IsNullOrEmpty(Byear)) parts.Add(CleanUp(Byear));

                    if (!string.IsNullOrEmpty(Aday)) parts.Add(CleanUp(Aday));
                    if (!string.IsNullOrEmpty(Amonth)) parts.Add(CleanUp(Amonth));
                    if (!string.IsNullOrEmpty(Ayear)) parts.Add(CleanUp(Ayear));

                    return string.Join("", parts);
                }
            }
            set
            {
                allInfo = value;
            }
        }
        [XmlIgnore]
        public string AllPhones 
        { 
            get {
                if (allPhones !=null)
                {
                    return allPhones;
                }
                else
                {
                    return CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone).Trim();
                }
            } 
            set 
            {
                allPhones = value;
            } 
        }
        [XmlIgnore]
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3);
                }
            }
            set
            {
                allEmails = value;
            }
        }


        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
           return Regex.Replace(phone, "[()-]","") + "\r\n";

        }

        public string CleanUpPhone(string info)
        {
            return Regex.Replace(info, "[- ()]", "");

        }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Aday { get; set; }
        public string Amonth { get; set; }
        public string Ayear { get; set; }
        public string Id { get; set; }
      
    }
}
