using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder_Lab.Models
{
    public class BookCategory : IClassModel, IComparable<BookCategory>
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CategoriesId { get; set; }

        public int CompareTo(BookCategory? other)
        {
            if(this.Id < other.Id)
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
            return CategoriesId.ToString();

        }
    }
}
