using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository
{
    public class Developer
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int IdentificationNumber { get; set; }

        public bool PluralSight { get; set; }

        public Developer() { }

        public Developer(string firstName, string lastName, int identificationNumber, bool pluralSight)
        {
            FirstName = firstName;
            LastName = lastName;
            IdentificationNumber = identificationNumber;
            PluralSight = pluralSight;
        }

    }
}
