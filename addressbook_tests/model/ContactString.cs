using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    public class ContactString : IEquatable<ContactString>, IComparable<ContactString>
    {
        private string firstname;
        private string lastname;
        public ContactString(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }
        public bool Equals(ContactString other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname;

        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return Firstname;
        }

        public int CompareTo(ContactString other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Firstname.CompareTo(other.Firstname) + Lastname.CompareTo(other.Lastname);
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
    }
}