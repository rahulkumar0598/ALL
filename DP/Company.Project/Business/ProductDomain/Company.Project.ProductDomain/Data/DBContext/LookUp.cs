using System;
using System.Collections.Generic;

namespace Company.Project.ProductDomain.Data.DBContext
{
    public partial class LookUp
    {
        public int LookupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IsDelete { get; set; }
        public int LookupCategoryId { get; set; }

        public virtual LookUpCategory LookupCategory { get; set; }
    }
}
