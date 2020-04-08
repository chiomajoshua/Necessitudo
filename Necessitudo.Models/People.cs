using System;

namespace Necessitudo.Models
{
    public class People
    {
        public int Id { get; set; }
        public string LastName {get; set;}
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public DateTime DateofBirth { get; set; }
        public int PersonAge { get; set; }
        public string Gender { get; set; }
        public string About { get; set; }
        public string PhoneNumber { get; set; }
        public string Profession { get; set; }
        public string IEnjoy { get; set; }
        public string DealBreakers { get; set; }
        public string DealMakers { get; set; }
        public string ProfilePicture { get; set; }
        public int SocialMediaConnection { get; set; }
    }
}