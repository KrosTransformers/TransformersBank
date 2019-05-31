using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformers.Bank.Entities
{
    public class Address: BaseEntity<long>
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }
}
