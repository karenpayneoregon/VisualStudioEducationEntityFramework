using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseConnectionLibrary.ConnectionClasses;

namespace BackEndDataProviderLibrary
{
    public class BlogOperations : SqlServerConnection
    {
        /// <summary>
        /// Connection for restoring the database
        /// </summary>
        public string MasterConnection => 
            "Data Source=.\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

        /// <summary>
        /// Setup default connection for all data operations
        /// </summary>
        public BlogOperations()
        {
            DatabaseServer = ".\\SQLEXPRESS";
            DefaultCatalog = "DatabaseFirst.Blogging";

        }
        /// <summary>
        /// Used to programmatically restore the blog database
        /// </summary>
        /// <returns></returns>
        public bool RestoreBlogDatabase()
        {
            var restoreStatement = "ALTER DATABASE [DatabaseFirst.Blogging] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " +
                                   "RESTORE DATABASE [DatabaseFirst.Blogging] FROM  DISK = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL14.SQLEXPRESS\\MSSQL\\Backup\\DatabaseFirst.Blogging.bak' WITH  FILE = 1,  NOUNLOAD,  STATS = 5; " +
                                   "ALTER DATABASE [DatabaseFirst.Blogging] SET MULTI_USER;";

            using (var cn = new SqlConnection {ConnectionString = MasterConnection})
            {
                using (var cmd = new SqlCommand() { Connection = cn, CommandText = restoreStatement })
                {

                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
        /// <summary>
        /// Add a new blog and add any post for the blog
        /// </summary>
        /// <param name="pMyBlog"></param>
        /// <returns></returns>
        public bool AddNewBlogUsingClasses(MyBlog pMyBlog)
        {
            mHasException = false;

            var blogInsertStatement = "INSERT INTO dbo.Blogs ([Name]) " + 
                                      "VALUES (@Name);" + 
                                      "SELECT CAST(scope_identity() AS int);";

            var postInsertStatement = "INSERT INTO dbo.Posts (Title,Content,BlogId) " +
                                      "VALUES (@Title,@Content,@BlogId);SELECT CAST(scope_identity() AS int);";

            try
            {
                using (var cn = new SqlConnection { ConnectionString = ConnectionString })
                {
                    // excluding a transaction
                    using (var cmd = new SqlCommand { Connection = cn })
                    {
                        cmd.CommandText = blogInsertStatement;
                        cmd.Parameters.AddWithValue("@Name", pMyBlog.Name);

                        cn.Open();

                        pMyBlog.BlogId = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.CommandText = postInsertStatement;
                        cmd.Parameters.Clear();

                        cmd.Parameters.Add("@Title", SqlDbType.NText);
                        cmd.Parameters.Add("@Content", SqlDbType.NText);
                        cmd.Parameters.Add("@BlogId", SqlDbType.Int);

                        foreach (var post in pMyBlog.Posts)
                        {
                            cmd.Parameters["@Title"].Value = post.Title;
                            cmd.Parameters["@Content"].Value = post.Content;
                            cmd.Parameters["@BlogId"].Value = post.BlogId = pMyBlog.BlogId;
                            post.PostId = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }

            return mHasException == false; // && RestoreBlogDatabase();
        }

        public bool AddNewBlogUsingDataSet(DataSet pDataSet)
        {
            mHasException = false;

            var blogInsertStatement = "INSERT INTO dbo.Blogs ([Name]) " +
                                      "VALUES (@Name);" +
                                      "SELECT CAST(scope_identity() AS int);";

            var postInsertStatement = "INSERT INTO dbo.Posts (Title,Content,BlogId) " +
                                      "VALUES (@Title,@Content,@BlogId);SELECT CAST(scope_identity() AS int);";

            try
            {
                using (var cn = new SqlConnection { ConnectionString = ConnectionString })
                {
                    // excluding a transaction
                    using (var cmd = new SqlCommand { Connection = cn })
                    {
                        cmd.CommandText = blogInsertStatement;
                        cmd.Parameters.AddWithValue("@Name", pDataSet.Tables["Blogs"].Rows[0].Field<string>("Name"));

                        cn.Open();

                        pDataSet.Tables["Blogs"].Rows[0].SetField("BlogId", Convert.ToInt32(cmd.ExecuteScalar()));
                        cmd.CommandText = postInsertStatement;
                        cmd.Parameters.Clear();

                        cmd.Parameters.Add("@Title", SqlDbType.NText);
                        cmd.Parameters.Add("@Content", SqlDbType.NText);
                        cmd.Parameters.Add("@BlogId", SqlDbType.Int);

                        foreach (DataRow post in pDataSet.Tables["Posts"].Rows)
                        {
                            cmd.Parameters["@Title"].Value = post.Field<string>("Title");
                            cmd.Parameters["@Content"].Value = post.Field<string>("Content");
                            cmd.Parameters["@BlogId"].Value = pDataSet.Tables["Blogs"].Rows[0].Field<int>("BlogId");
                            post.SetField("PostId", Convert.ToInt32(cmd.ExecuteScalar()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }

            return mHasException == false; // && RestoreBlogDatabase();
        }
    }
}
