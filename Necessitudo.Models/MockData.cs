using System;
using System.Collections.Generic;

namespace Necessitudo.Models
{
    public class MockData
    {
        static readonly IList<People> _people;
        public static void CreatePeopleCollection()
        {
            _people.Add(new People
            {
                Id = 1,
                DateofBirth = Convert.ToDateTime("25/04/1988"),
                DealBreakers = "Pride, UnHealthy, Not Focused, Not Ambitious",
                DealMakers = "High Self-Esteem, Healthy, Firm, Bold",
                FirstName = "Joshua",
                Gender = "Male",
                IEnjoy = "Writing Codes, Swimming, Solving Problems, Charity Work, Singing",
                LastName = "Chioma",
                PhoneNumber = "+2349082464049",
                Profession = "Software Developer",
                ProfilePicture = "profilePicture.png",
                FullName = "Joshua Chioma",
                PersonAge = 27,
                About = "I was born in a ghetto part of Lagos. Now I live on the hills. Blah, Blah, Blah, Blah, Blah",
                SocialMediaConnection = 5
            });

            _people.Add(new People
            {
                Id = 2,
                DateofBirth = Convert.ToDateTime("2/01/1991"),
                DealBreakers = "Pride, UnHealthy, Not Focused, Not Ambitious",
                DealMakers = "High Self-Esteem, Healthy, Firm, Bold",
                FirstName = "Jessica",
                Gender = "Female",
                IEnjoy = "settling accounts, Swimming, Solving Problems, Charity Work, Dancing",
                LastName = "Johnson",
                PhoneNumber = "+2349082464049",
                Profession = "Banker",
                ProfilePicture = "blackWomanTwo.png",
                FullName = "Jessica Johnson",
                PersonAge = 27,
                About = "I was born in a ghetto part of Lagos. Now I live on the hills. Blah, Blah, Blah, Blah, Blah",
                SocialMediaConnection = 4
            });

            _people.Add(new People
            {
                Id = 3,
                DateofBirth = Convert.ToDateTime("25/04/1988"),
                DealBreakers = "Pride, UnHealthy, Not Focused, Not Ambitious",
                DealMakers = "High Self-Esteem, Healthy, Firm, Bold",
                FirstName = "Joshua",
                Gender = "Male",
                IEnjoy = "Writing Codes, Swimming, Solving Problems, Charity Work, Singing",
                LastName = "Chioma",
                PhoneNumber = "+2349082464049",
                Profession = "Software Developer",
                ProfilePicture = "blackManOne.png",
                FullName = "Joshua Chioma",
                PersonAge = 27,
                About = "I was born in a ghetto part of Lagos. Now I live on the hills. Blah, Blah, Blah, Blah, Blah",
                SocialMediaConnection = 3
            });

            _people.Add(new People
            {
                Id = 4,
                DateofBirth = Convert.ToDateTime("25/04/1988"),
                DealBreakers = "Pride, UnHealthy, Not Focused, Not Ambitious",
                DealMakers = "High Self-Esteem, Healthy, Firm, Bold",
                FirstName = "Folashade",
                Gender = "Female",
                IEnjoy = "Writing Codes, Swimming, Solving Problems, Charity Work, Singing",
                LastName = "Peters",
                PhoneNumber = "+2349082464049",
                Profession = "Software Developer",
                ProfilePicture = "blackWomanTwo.png",
                FullName = "Folashade Peters",
                PersonAge = 27,
                About = "I was born in a ghetto part of Lagos. Now I live on the hills. Blah, Blah, Blah, Blah, Blah",
                SocialMediaConnection = 5
            });

            _people.Add(new People
            {
                Id = 5,
                DateofBirth = Convert.ToDateTime("25/04/1988"),
                DealBreakers = "Pride, UnHealthy, Not Focused, Not Ambitious",
                DealMakers = "High Self-Esteem, Healthy, Firm, Bold",
                FirstName = "Joshua",
                Gender = "Male",
                IEnjoy = "Writing Codes, Swimming, Solving Problems, Charity Work, Singing",
                LastName = "Chioma",
                PhoneNumber = "+2349082464049",
                Profession = "Software Developer",
                ProfilePicture = "blackManTwo.png",
                FullName = "Joshua Chioma",
                PersonAge = 27,
                About = "I was born in a ghetto part of Lagos. Now I live on the hills. Blah, Blah, Blah, Blah, Blah",
                SocialMediaConnection = 1
            });

            _people.Add(new People
            {
                Id = 6,
                DateofBirth = Convert.ToDateTime("25/04/1988"),
                DealBreakers = "Pride, UnHealthy, Not Focused, Not Ambitious",
                DealMakers = "High Self-Esteem, Healthy, Firm, Bold",
                FirstName = "Sophie",
                Gender = "Female",
                IEnjoy = "Writing Codes, Swimming, Solving Problems, Charity Work, Singing",
                LastName = "Ofor",
                PhoneNumber = "+2349082464049",
                Profession = "Software Developer",
                ProfilePicture = "blackWomanTwo.png",
                FullName = "Sophie Ofor",
                PersonAge = 27,
                About = "I was born in a ghetto part of Lagos. Now I live on the hills. Blah, Blah, Blah, Blah, Blah",
                SocialMediaConnection = 2
            });
        }
    }
}