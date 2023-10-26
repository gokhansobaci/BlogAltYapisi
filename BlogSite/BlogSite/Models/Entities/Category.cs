using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogSite.Models.Entities
{
    public class Category:BaseEntity
    {
        
        public string KategoriAdi { get; set; }
        //foreign table
        public virtual ICollection<Article> Articles { get; set; }

    }
}