using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Reports
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int UserCount { get; set; }
        public int UserPhoneCount { get; set; }
        public DateTime ReportDate { get; set; }
        public bool ReportStatus { get;set; }//false hazırlanıyor, true tamamlandı

          
    }
}
