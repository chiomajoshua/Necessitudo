using System;

namespace Necessitudo.APIModels
{
    public class APIPeopleViewModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Profession { get; set; }
        public string Hobbies { get; set; }
        public string DealMakers { get; set; }
        public string DealBreakers { get; set; }
        public string AboutMe { get; set; }
        public int StarCount { get; set; }
        public string ImageURL { get; set; }
    }
}