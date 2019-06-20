using System.Collections.Generic;

namespace BackEndDataProviderLibrary
{
    public class MyBlog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<MyPost> Posts { get; set; }
    }
}