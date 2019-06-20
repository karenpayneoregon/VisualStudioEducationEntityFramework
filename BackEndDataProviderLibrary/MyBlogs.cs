using System.Collections.Generic;

namespace BackEndDataProviderLibrary
{
    public class MyBlogs
    {
        public List<MyBlog> Blogs { get; set; }
        public MyBlogs()
        {
            Blogs = new List<MyBlog>();
        }
    }
}