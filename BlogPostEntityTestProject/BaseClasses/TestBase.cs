using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEndDataProviderLibrary.ExtensionMethods;

namespace BlogPostEntityTestProject.BaseClasses
{
    public class TestBase
    {
        /// <summary>
        /// Mimic reading empty tables from a database
        /// </summary>
        /// <returns></returns>
        public DataSet CreateBlogDataSet()
        {
            var ds = new DataSet();
            var blogTable = new DataTable() {TableName = "Blogs"};
            blogTable.Columns.Add(new DataColumn() {ColumnName = "BlogId", DataType = typeof(int)});
            blogTable.Columns.Add(new DataColumn() {ColumnName = "Name", DataType = typeof(string)});
            blogTable.Columns.Add(new DataColumn() {ColumnName = "Url", DataType = typeof(string)});


            var postTable = new DataTable() { TableName = "Posts" };

            postTable.Columns.Add(new DataColumn() {ColumnName = "PostId", DataType = typeof(int)});
            postTable.Columns.Add(new DataColumn() {ColumnName = "Title", DataType = typeof(string)});
            postTable.Columns.Add(new DataColumn() {ColumnName = "Content", DataType = typeof(string)});
            postTable.Columns.Add(new DataColumn() {ColumnName = "BlogId", DataType = typeof(int)});

            ds.Tables.Add(blogTable);
            ds.Tables.Add(postTable);
            ds.SetRelation("Blogs", "Posts", "BlogId", "BlogId");

            return ds;
        }
        /// <summary>
        /// Mimic user adding a blog and two post
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public DataSet PopulateDataSet(DataSet ds)
        {
            ds.Tables["Blogs"].Rows.Add(null, "All about DataSet", "");
            ds.Tables["Posts"].Rows.Add(null, "Part  1", "Let's get started");
            ds.Tables["Posts"].Rows.Add(null, "Part  2", "using DataSets");

            return ds;
        }

    }
}
