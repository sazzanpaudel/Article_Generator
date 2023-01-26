using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Article.Data;
using MVC_Article.Models;
using MVC_Article.Models.Domain;

namespace MVC_Article.Controllers
{
    public class DatasController : Controller
    {
        private readonly DemoDbContext demoDbcontext;

        public DatasController(DemoDbContext demoDbcontext)
        {
            this.demoDbcontext = demoDbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
           var tdatas =  await demoDbcontext.Datas.ToListAsync();
            return View(tdatas);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddDataViewModel addDataRequest)
        {
            var tdata = new T_data()
            {
                Id = Guid.NewGuid(),
                Heading = addDataRequest.Heading,
                Name = addDataRequest.Name,
                Date = addDataRequest.Date,
                address = addDataRequest.address,
                body = addDataRequest.body,
                conclusion = addDataRequest.conclusion
            };
            await demoDbcontext.Datas.AddAsync(tdata);
            await demoDbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
