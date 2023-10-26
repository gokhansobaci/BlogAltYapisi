using BlogSite.DTO;
using BlogSite.Models.Entities;
using BlogSite.Repositories.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace BlogSite.Services
{
    public class ArticleService
    {
        private ArticleRepo repo;
        public ArticleService()
        {
           repo = new ArticleRepo();
        }

        public IEnumerable<ArticleListItem> GetArticles(int page=1,int page_size = 20)
        {
            IEnumerable<Article> articles = repo
                .Read(x => x.Yayindami && x.Active && !x.Deleted)
                .OrderByDescending(x => x.YayınTarihi)
                .Skip((page - 1) * page_size)
                .Take(page_size);


            return from a in articles
                   select new ArticleListItem
                   {
                       Baslik = a.Baslik,
                       YayinTarihi = a.YayınTarihi,
                       Yazar = a.Yazar,
                       KategoriAdi = a.Category.KategoriAdi,
                       OneCıkanResim = a.OneCikanResim
                   };
        }

        public ArticleDetail GetArticle(string url) {
        
            int id =Convert.ToInt32(url.Split('-').LastOrDefault()) ;
            Article c = repo.Read(id); 
            if (c != null && c.Yayindami && c.Active && !c.Deleted)
            {
                return new ArticleDetail
                {
                    Baslik = c.Baslik,
                    Icerik = c.Icerik,
                    YayinTarihi = c.YayınTarihi,
                    Yazar = c.Yazar,
                    KategoriAdi = c.Category.KategoriAdi,
                    OneCıkanResim = c.OneCikanResim
                };
            }

            return null;
        }

    }
}