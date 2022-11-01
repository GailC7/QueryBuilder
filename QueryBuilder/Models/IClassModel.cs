using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder_Lab.Models
{
    public class IClassModel //: IComparable<IClassModel>
    {
        public int Id { get; set; }

        /*public int CompareTo(IClassModel? other)
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
            return Id.ToString();

        }*/
    }
}
