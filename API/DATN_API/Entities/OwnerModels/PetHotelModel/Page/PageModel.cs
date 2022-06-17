using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Owners.PetHotel.Page
{
    public class PageModel
    {
        public int pageID { get; set; }
        public int  pagePrevious { get; set; }
        public int pageNext { get; set; }
        public int number { get; set; }
    }
}
