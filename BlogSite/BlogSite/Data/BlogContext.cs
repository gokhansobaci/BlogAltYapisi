using BlogSite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogSite.Data
{
    public class BlogContext:DbContext
    {
        public BlogContext():base("blog")
        {
            
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }


        private static BlogContext instance;
        public static BlogContext Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new BlogContext(); 
                }
                return instance;
            }
        }



    }

    
}