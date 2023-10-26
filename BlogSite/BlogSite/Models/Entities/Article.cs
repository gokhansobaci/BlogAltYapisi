using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogSite.Models.Entities
{
    public class Article:BaseEntity
    {
       
        
        public string Baslik { get; set; }
        public bool Yayindami { get; set; } = false;
        public string Icerik { get; set; }
        public DateTime YayınTarihi { get; set; }
        public string OneCikanResim { get; set; }
        public string Yazar { get; set; }

        //foreign key
       
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}