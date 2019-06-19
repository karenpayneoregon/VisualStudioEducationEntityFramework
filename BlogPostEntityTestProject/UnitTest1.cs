using System;
using System.Collections.Generic;
using DatabaseFirstSample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlogPostEntityTestProject
{
    /// <summary>
    /// Old but a good starter (some instructions have steps with wrong items)
    /// https://docs.microsoft.com/en-us/ef/ef6/modeling/designer/workflows/database-first
    /// </summary>
    [TestClass(), TestCategory("EF6 Database first")]
    public class UnitTest1
    {
        [TestMethod]
        public void AddNewBlogWithPostTest()
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
    }
}
