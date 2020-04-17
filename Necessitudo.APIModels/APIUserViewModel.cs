using System;

namespace Necessitudo.APIModels
{
    public class APIUserViewModel
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Profession { get; set; }
        public string Hobbies { get; set; }
        public string AgeRange { get; set; }
        public string DealMakers { get; set; }
        public string DealBreakers { get; set; }
        public string AboutMe { get; set; }
        public DateTime DateJoined { get; set; }
        public int AccountStatus { get; set; }
        public int StarCount { get; set; }
        public string ImageURL { get; set; }
    }
}