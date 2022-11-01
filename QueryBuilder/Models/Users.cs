using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder_Lab.Models
{
    public class Users: IClassModel, IComparable<Users>
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string OtherUserDetails { get; set; }
        public string AmountOfFine { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public int CompareTo(Users? other)
        {
            return string.Compare(this.UserName, other.UserName);
        }

        public override string ToString()
        {
            return UserName;
        }

    }
}
