using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskEnergo.Entities;

namespace TestTaskEnergo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private MyContext context;

        private readonly IConfiguration Configuration;

        public ValuesController(MyContext myContext, IConfiguration configuration)
        {
            context = myContext;
            Configuration = configuration;
         //   FillDB();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            using (var db = new MyContext(Configuration))
            {
                var users = db.Users
                            .Include(u => u.Company)  // добавляем данные по компаниям
                            .ToList();
                foreach (var user in users)
                    Console.WriteLine($"{user.Name} - {user.Company?.Name}");
            }
     
            return await context.Users.ToListAsync();
        }


        private void FillDB()
        {
            using (var db = new MyContext(Configuration))
            {
                // создание и добавление моделей
                Company microsoft = new Company { Name = "Microsoft" };
                Company google = new Company { Name = "Google" };
                db.Companies.AddRange(microsoft, google);

                User tom = new User { Name = "Tom", Company = microsoft };
                User bob = new User { Name = "Bob", Company = microsoft };
                User alice = new User { Name = "Alice", Company = google };
                db.Users.AddRange(tom, bob, alice);
                db.SaveChanges();

            }
        }
    }
}
