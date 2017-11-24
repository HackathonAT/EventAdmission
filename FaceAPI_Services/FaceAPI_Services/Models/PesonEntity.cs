using System;

namespace FaceAPI_BusinessLayer
{
    public class PersonEntity
    {
        private string FirstName { set; get; }
        private string LastName { set; get; }
        private string Status { set; get; }
        private string Role { set; get; }
        private DateTime Birthday { set; get; }

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
