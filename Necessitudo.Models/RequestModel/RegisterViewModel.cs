using System;

namespace Necessitudo.Models.RequestModel
{
    public class RegisterViewModel
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string DateofBirth { get; set; }
        public string Profession { get; set; }
        public string Hobbies { get; set; }
        public string AgeRange { get; set; }
        public string DealMakers { get; set; }
        public string DealBreakers { get; set; }
        public string AboutMe { get; set; }
        public string ImageURL { get; set; }
    }
}
