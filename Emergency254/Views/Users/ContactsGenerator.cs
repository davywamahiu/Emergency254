using System;
using System.Collections.Generic;
using System.Text;
using Emergency254.Shared.Models;

namespace Emergency254.Shared.Utils
{
    public static class ContactsGenerator
    {

        public static List<Contact> GenerateContacts()
        {
            return new List<Contact>()
            {
                //new Contact() { Id = "00004363-F79A-44E7-BC32-6128E2EC8401", FirstName = "Joseph", LastName = "Kamau", Company = "Design lead", JobTitle = "Vice President", Email = "kamaa@genge.com", Phone = "0711-494-334", Street = "2030 Hague st", City = "Murang'a", PostalCode = "94144", State = "CA"},
                //new Contact() { Id = "c227bfd2-c6f6-49b5-93ec-afef9eb18d08", FirstName = "Khali", LastName = "Wamae", Company = "Developer", JobTitle = "Director", Email = "davy@tone.com", Phone = "0735-856-567", Street = "Kanu st ", City = "Nakuru", PostalCode = "9418", State = "CA"},
            };
        }
    }
}
