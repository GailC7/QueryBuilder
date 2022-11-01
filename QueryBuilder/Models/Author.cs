using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder_Lab.Models
{
    public class Author : IClassModel, IComparable<Author>
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }   
        public string Surname { get; set; }  

        public  Author(){ }

        public Author(int id, string firstName, string surName)
        {
            Id = id;
            FirstName = firstName;
            Surname = surName;
        }   

        public int CompareTo(Author? other)
        {
            return string.Compare(this.Surname, other.Surname);
        }

        public override string ToString()
        {
            return $"{Surname}, {FirstName[0]}";
        }


    }
}
