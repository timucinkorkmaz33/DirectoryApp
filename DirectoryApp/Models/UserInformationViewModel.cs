using System;

namespace DirectoryApp.Models
{
    public class UserInformationViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Information { get; set; }

    }
}
