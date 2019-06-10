using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamLibrary.Classes
{
    public class SelectStatements
    {
        public string SelectCustomerByCustomerIdentifier => @"                    
        SELECT Cust.CustomerIdentifier,
               Cust.CompanyName, 
               Cust.ContactId,
               Contacts.FirstName,
               Contacts.LastName,
               CT.ContactTitle,
               Cust.CountryIdentifier,
               Countries.Name AS CountryName
        FROM Customers AS Cust
             INNER JOIN ContactType AS CT ON Cust.ContactTypeIdentifier = CT.ContactTypeIdentifier
             INNER JOIN Contacts ON Cust.ContactId = Contacts.ContactId
             INNER JOIN Countries ON Cust.CountryIdentifier = Countries.CountryIdentifier
        WHERE Cust.CustomerIdentifier = @CustomerIdentifier;";
    }
}
