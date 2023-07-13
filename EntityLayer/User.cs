using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public string Surname { get; set; }
        public string Company { get; set; }
        public bool IsActive { get; set; }//user listesinden birini silmek cok dogru bir işlem değil
                                          //bunun yerine aktif durum 0 yapılması daha dogru bir işlem 

     
    }
}
