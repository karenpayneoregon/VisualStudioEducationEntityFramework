using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoEntityFrameworkTest.BaseClasses;

namespace RepoEntityFrameworkTest
{
    [TestClass(), TestCategory("SQL-Server EF6 - Generic")]
    public class UnitTest1 : TestBase
    {
        /// <summary>
        /// Demonstration to show how to get the current executing test method
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            Console.WriteLine(TestContext.TestName);
        }

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            TestResults = new List<TestContext>();
        }
        [TestMethod]
        public void GetCustomerUsingRepositoryPatternTest() 
        {
            var id = 4;
            var customer = GetCompanyByCustomerIdentifier(id);
            Assert.IsTrue(customer.CompanyName == "Around the Horn");
        }
    }
}
