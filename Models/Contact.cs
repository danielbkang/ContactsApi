using System;

namespace ContactsApi.Models
{
    public class Contact
    {
        public int Id { get; set; }
 
        public string FirstName { get; set; }
 
        public string LastName { get; set; }
 
        public string Address { get; set; }
 
        public string PhoneNumber { get; set; }
 
        public DateTime Birth { get; set; }
 
        public string Email { get; set; }
    }
}
