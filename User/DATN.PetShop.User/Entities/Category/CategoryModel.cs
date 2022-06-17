using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Category
{
    public class CategoryModel : BaseModel
    {
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public string categoryHandle { get; set; }
        public int categoryParent { get; set; }
        public int oderNo { get; set; }
        public bool visible { get; set; }
    }
}
