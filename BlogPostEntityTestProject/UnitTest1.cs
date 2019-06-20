using System;
using System.Collections.Generic;
using System.Linq;
using BackEndDataProviderLibrary;
using BlogPostEntityTestProject.BaseClasses;
using DatabaseFirstSample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogPostEntityTestProject
{
    /// <summary>
    /// Old but a good starter (some instructions have steps with wrong items)
    /// https://docs.microsoft.com/en-us/ef/ef6/modeling/designer/workflows/database-first
    /// </summary>
    [TestClass(), TestCategory("EF6 Database first")]
    public class UnitTest1 : TestBase
    {
        /// <summary>
        /// Test adding parent and child records for a blog via Entity Framework
        /// </summary>
        [TestMethod]
        public void AddNewBlogWithPostEntityFrameworkTest()
        {
            using (var context = new BloggingContext())
            {
                var blog = context.Blogs.Add(new Blog()
                {
                    Name = "All about EF",
                    Posts = new List<Post>()
                });

                blog.Posts = new List<Post>()
                {
                    new Post() {Title = "Parts 1", Content = "Let's get started"},
                    new Post() {Title = "Parts 2", Content = "History of EF"}
                };

                context.SaveChanges();
            }
        }
        /// <summary>
        /// Test adding parent and child records for a blog via classes and
        /// managed data provider
        /// </summary>
        [TestMethod]
        public void AddNewBlogWithPostSqlClientTest()
        {
            var blogs = new MyBlogs();
            blogs.Blogs.Add(
                new MyBlog() {
                Name = "All about Data providers",
                Posts = new List<MyPost>() {
                    new MyPost() {Title = "Parts 1", Content = "Let's get started"},
                    new MyPost() {Title = "Parts 2", Content = "History of data providers"}
                }
            } );

            var ops = new BlogOperations();
            Assert.IsTrue(ops.AddNewBlogUsingClasses(blogs.Blogs.FirstOrDefault()));

        }

        [TestMethod]
        public void AddNewBlogWithPostDataSetTest() 
        {
            var ds = PopulateDataSet(CreateBlogDataSet());
            var ops = new BlogOperations();
            Assert.IsTrue(ops.AddNewBlogUsingDataSet(ds));
        } 
    }
}
