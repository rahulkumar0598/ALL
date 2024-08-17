using System;
using System.Collections.Generic;

namespace Company.Project.ProductDomain.DBContext
{
    public partial class LookUpCategoryId
    {
        public int LookUpCategoryId1 { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? IsDelete { get; set; }
    }
}
