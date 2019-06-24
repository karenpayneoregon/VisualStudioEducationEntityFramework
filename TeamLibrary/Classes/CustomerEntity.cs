using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamLibrary.Classes
{
    public class CustomerEntity
    {
        public int CustomerIdentifier { get; set; }
        public string Company { get; set; }
        public int? ContactIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactTypeIdentifier { get; set; }
        public string ContactTitle { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int? CountryIdentifier { get; set; }
        public string CountyName { get; set; }
        public override string ToString()
        {
            return $"{CustomerIdentifier} -- {Company}";
        }
    }
}
