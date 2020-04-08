using System;
using System.Collections.Generic;
using System.Text;

namespace Necessitudo.Models
{
    public class Age
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Profession
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class PickerService
    {
        public static List<Age> GetAges()
        {
            var ages = new List<Age>()
            {
                new Age() {Key=1, Value="20-25"},
                new Age() {Key=2, Value="25-30"},
                new Age() {Key=3, Value="30-35"},
                new Age() {Key=4, Value="35-40"},
                new Age() {Key=5, Value="40-45"},
                new Age() {Key=6, Value="45-50"},
                new Age() {Key=7, Value="50-55"},
                new Age() {Key=7, Value="55-60"}
            };
            return ages;
        }

        public static List<Profession> GetProfessions()
        {
            var professions = new List<Profession>()
            {
                new Profession() {Key=1,Value="Medical Doctor"},
                new Profession() {Key=2,Value="Engineer"},
                new Profession() {Key=3,Value="Architect"},
                new Profession() {Key=4,Value="Banker"},
                new Profession() {Key=5,Value="IT Specialist"},
                new Profession() {Key=6,Value="Accountant"},
                new Profession() {Key=7,Value="Auditor"},
                new Profession() {Key=8,Value="Lawyer"},
                new Profession() {Key=9,Value="Investment Banker"}
            };
            return professions;
        }

    }
}