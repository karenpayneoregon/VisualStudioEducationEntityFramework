namespace BackEndDataProviderLibrary
{
    public class MyPost
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }

        public virtual MyBlog Blog { get; set; }
    }
}