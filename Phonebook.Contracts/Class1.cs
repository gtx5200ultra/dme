using System;

namespace Phonebook.Contracts
{
    public class PhonebookUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public PhonebookPicture Pictures { get; set; }
    }

    public class PhonebookPicture
    {
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Thumbnail { get; set; }
    }
}
