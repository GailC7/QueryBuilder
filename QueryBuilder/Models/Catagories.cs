using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder_Lab.Models
{
    public class Catagories : IClassModel, IComparable<Catagories>
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public int CompareTo(Catagories? other)
        {
            return string.Compare(this.Name, other.Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
