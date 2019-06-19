using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonPhoneProject;


namespace PersonPhoneTest
{
    [TestClass(), TestCategory("EF6 Parent child CRUD")]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new PersonEntities())
            {
                var person = context.People.Add(
                    new Person(){FirstName = "Mary", LastName = "Moore"});

                person.Phones = new List<Phone>()
                {
                    new Phone() { PhoneType = "Cell 1", PhoneNumber = "888-888-8888"},
                    new Phone() { PhoneType = "Cell 2", PhoneNumber = "666-666-6666"},
                    new Phone() { PhoneType = "Cell 3", PhoneNumber = "444-444-444"}
                };

                context.SaveChanges(); 

            }
        }
    }
}
