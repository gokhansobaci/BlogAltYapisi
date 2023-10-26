using BlogSite.DTO;
using BlogSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ArticleService service = new ArticleService();
            IEnumerable<ArticleListItem> articles = service.GetArticles();
            Console.WriteLine($"Bu Sayfadaki Makale Sayısı: {articles.Count()}");
            if (articles.Any())
            {
                Console.WriteLine("Bu Sayfada Bulunan Makaleler:");
                foreach (var a in articles)
                {
                    Console.WriteLine(a.Baslik);
                    Console.WriteLine(a.YayinTarihi);
                    Console.WriteLine();
                }
            }
        }
    }
}
