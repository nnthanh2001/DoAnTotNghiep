using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Request
{
    public class RequestModel<T>
    {
        public int HttpStatusCode { get; set; }
        public string message { get; set; }
        public T model { get; set; }

    }
}
