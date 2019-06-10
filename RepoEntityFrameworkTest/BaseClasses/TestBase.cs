using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NorthWindAzure2;
using NorthWindAzure2.Repositories;

namespace RepoEntityFrameworkTest.BaseClasses
{
    public class TestBase 
    {
        protected TestContext TestContextInstance;
        public TestContext TestContext
        {
            get => TestContextInstance;
            set
            {
                TestContextInstance = value;
                TestResults.Add(TestContext);
            }
        }

        public static IList<TestContext> TestResults;
        public Customer GetCompanyByCustomerIdentifier(int pIdentifier)
        {
            using (var context = new NorthWindEntities())
            {
                var repository = new CustomerRepository(context);
                return repository.GetById(pIdentifier);

            }
        }
    }
}
