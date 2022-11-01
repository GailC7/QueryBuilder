using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder_Lab.Models
{
    public class Books : IClassModel, IComparable<Books> 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Isbn { get; set; }

        public int CompareTo(Books? other)
        {
            return string.Compare(this.Title, other.Title);
        }

        public override string ToString()
        {
            return Title;
        }


    }
}
