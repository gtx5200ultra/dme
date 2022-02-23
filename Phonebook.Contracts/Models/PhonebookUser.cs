using System;

namespace Phonebook.Contracts.Models
{
    public class PhonebookUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public PhonebookPicture Pictures { get; set; }
    }
}