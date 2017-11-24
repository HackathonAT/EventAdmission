using System;

namespace FaceAPI_BusinessLayer
{
    public class PersonEntity
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Status { set; get; }
        public string Role { set; get; }
        public DateTime Birthday { set; get; }

        public PersonEntity()
        {
        }

        public PersonEntity(string firstName, string lastName, string status, string role, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Status = status;
            Role = role;
            Birthday = birthday;
        }
    }
}
