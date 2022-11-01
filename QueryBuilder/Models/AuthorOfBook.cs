using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder_Lab.Models
{
    internal class AuthorOfBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public int CompareTo(AuthorOfBook? other)
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
            return AuthorId.ToString();
            
        }
    }
}
