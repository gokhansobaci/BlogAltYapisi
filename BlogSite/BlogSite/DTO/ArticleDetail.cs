﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSite.DTO
{
    public class ArticleDetail
    {
        public DateTime YayinTarihi { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string Yazar { get; set; }
        public string OneCıkanResim { get; set; }

        public string KategoriAdi{ get; set; }       
    }
}