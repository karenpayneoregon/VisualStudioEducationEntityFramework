namespace DatabaseFirstSample
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BloggingContext : DbContext
    {
        public BloggingContext() : base("name=BloggingModel")
        {
            //Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberType> MemberTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
