using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
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
        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        public string Middlename { get; set; }
        
        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        
        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }
        
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
                    var resultParts = new List<string>();

                    var fioParts = new List<string>();
                    if (!string.IsNullOrEmpty(Firstname)) fioParts.Add(Firstname);
                    if (!string.IsNullOrEmpty(Middlename)) fioParts.Add(Middlename);
                    if (!string.IsNullOrEmpty(Lastname)) fioParts.Add(Lastname);
                    if (fioParts.Count > 0)
                        resultParts.Add(string.Join(" ", fioParts));
                        resultParts.Add("");

                    var part1 = new List<string>();
                    if (!string.IsNullOrEmpty(Nickname)) part1.Add(CleanUp(Nickname));
                    if (!string.IsNullOrEmpty(Title)) part1.Add(CleanUp(Title));
                    if (!string.IsNullOrEmpty(Company)) part1.Add(CleanUp(Company));
                    if (!string.IsNullOrEmpty(Address)) part1.Add(CleanUp(Address));
                    if (part1.Count > 0)
                        resultParts.Add(string.Join("\r\n", part1));

                    var phones = new List<string>();
                    if (!string.IsNullOrEmpty(HomePhone))
                        phones.Add("H: " + CleanUpPhone(HomePhone));
                    if (!string.IsNullOrEmpty(MobilePhone))
                        phones.Add("M: " + CleanUpPhone(MobilePhone));
                    if (!string.IsNullOrEmpty(WorkPhone))
                        phones.Add("W: " + CleanUpPhone(WorkPhone));
                    if (phones.Count > 0)
                        resultParts.Add(string.Join("\r\n", phones));
                        resultParts.Add("");

                    var emails = new List<string>();
                    if (!string.IsNullOrEmpty(Email)) emails.Add(CleanUp(Email));
                    if (!string.IsNullOrEmpty(Email2)) emails.Add(CleanUp(Email2));
                    if (!string.IsNullOrEmpty(Email3)) emails.Add(CleanUp(Email3));
                    if (emails.Count > 0)
                        resultParts.Add(string.Join("\r\n", emails));
                        resultParts.Add("");

                    var part2 = new List<string>();
                    if (!string.IsNullOrEmpty(Homepage)) part2.Add(CleanUp(Homepage));
                    if (!string.IsNullOrEmpty(Bday) || !string.IsNullOrEmpty(Bmonth) || !string.IsNullOrEmpty(Byear))
                    {
                        var birthDate = string.Join(".", new[] { Bday, Bmonth, Byear }.Where(s => !string.IsNullOrEmpty(s)));
                        part2.Add(birthDate);
                    }

                    if (!string.IsNullOrEmpty(Aday) || !string.IsNullOrEmpty(Amonth) || !string.IsNullOrEmpty(Ayear))
                    {
                        var anniversaryDate = string.Join(".", new[] { Aday, Amonth, Ayear }.Where(s => !string.IsNullOrEmpty(s)));
                        part2.Add(anniversaryDate);
                    }

                    if (part2.Count > 0)
                        resultParts.Add(string.Join("\r\n", part2));

                    return string.Join("\r\n", resultParts);
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
           return Regex.Replace(phone, "[()-]","");

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

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}
