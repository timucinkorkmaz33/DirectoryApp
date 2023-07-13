using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ContactInformation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Information { get; set; }
    }
}
