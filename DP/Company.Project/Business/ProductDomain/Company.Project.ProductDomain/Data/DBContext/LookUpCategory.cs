using System;
using System.Collections.Generic;

namespace Company.Project.ProductDomain.Data.DBContext
{
    public partial class LookUpCategory
    {
        public LookUpCategory()
        {
            LookUp = new HashSet<LookUp>();
        }

        public int LookupCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IsDelete { get; set; }

        public virtual ICollection<LookUp> LookUp { get; set; }
    }
}
