using System;

namespace Phonebook.Contracts
{
    public class Class1
    {
    }

    public class Login
    {
        public string Uuid { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }
        public string Md5 { get; set; }
        public string Sha1 { get; set; }
        public string Sha256 { get; set; }
    }

    public class User
    {
        public string Gender { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; }
        public Login Login { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTimeOffset Registered { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public PersonalId Id { get; set; }
        public Picture Picture { get; set; }
        public string Nat { get; set; }
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }

    public class Picture
    {
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Thumbnail { get; set; }
    }

    public class Location
    {
        public Street Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Postcode { get; set; }
        public Timezone Timezone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class PersonalId
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Timezone
    {
        public string Offset { get; set; }
        public string Description { get; set; }
    }

    public class Street
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }
}
