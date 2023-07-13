using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class User
    {
        [Key]
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public bool IsActive { get; set; }//user listesinden birini silmek cok dogru bir işlem değil
                                          //bunun yerine aktif durum 0 yapılması daha dogru bir işlem 


    }
}
