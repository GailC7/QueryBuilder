using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder_Lab.Models
{
    public class BooksOutOnLoan : IClassModel, IComparable<BooksOutOnLoan>
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }

        public int CompareTo(BooksOutOnLoan? other)
        {
            if (this.Id < other.Id)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        public override string ToString()
        {
            return UserId.ToString();

        }
    }
}
