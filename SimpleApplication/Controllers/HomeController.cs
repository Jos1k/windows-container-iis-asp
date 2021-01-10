using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using SimpleApplication.EF;

namespace SimpleApplication.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            IEnumerable<Blog> blogs = Enumerable.Empty<Blog>();
            
            var db = new BloggingContext();
            blogs = db.Blogs.OrderBy(x => x.Name);

            var result = await new HttpClient().GetAsync("https://jsonplaceholder.typicode.com/todos/1");

            ViewBag.Rest = await result.Content.ReadAsStringAsync();
            
            return View(blogs);
        }

        public ActionResult About()
        {
            AddBlog();
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        private void AddBlog()
        {
            using (var db = new BloggingContext())
            {
                var name = $"Blog - {DateTime.Now.ToLongTimeString()}";

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }
    }
}