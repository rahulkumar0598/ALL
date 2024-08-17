using System;
using System.Collections.Generic;

namespace Company.Project.ProductDomain.DBContext
{
    public partial class LookUp
    {
        public int LookUpId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? IsDelete { get; set; }
        public int? LookUpCategoryId { get; set; }
    }
}
