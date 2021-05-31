using GlomilAssesment.Models.ORM.Context;
using GlomilAssesment.Models.ORM.Entities;
using GlomilAssesment.Models.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlomilAssesment.Controllers
{
    public class AddMathController : Controller
    {
        private readonly GlomilContext _context;
        public AddMathController(GlomilContext context, IMemoryCache memoryCache) /*: base(context, memoryCache)*/
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MathEntity model)
        {
            if (ModelState.IsValid)
            {
                MathEntity mathEntity = new MathEntity();
                mathEntity.input1 = model.input1;
                mathEntity.input2 = model.input2;
                mathEntity.ID = model.ID;
                mathEntity.sonuc1 = mathEntity.input1 + mathEntity.input2;
                mathEntity.sonuc2 = mathEntity.input1 - mathEntity.input2;
                mathEntity.sonuc3 = mathEntity.input1 * mathEntity.input2;
                mathEntity.sonuc4 = mathEntity.input1 / mathEntity.input2;

                _context.mathEntity.Add(mathEntity);
                _context.SaveChanges();
                
                return RedirectToAction("detail", new RouteValueDictionary(
    new { controller = "AddMath", action = "detail", ID = mathEntity.ID }));
            }


            return View();

        }
        public IActionResult Detail(int id)
        {
            MathEntity mathEntity = _context.mathEntity.FirstOrDefault(x => x.ID == id);

            MathVM model = new MathVM();

            model.ID = mathEntity.ID;
            model.sonuc1 = mathEntity.sonuc1;
            model.sonuc2 = mathEntity.sonuc2;
            model.sonuc3 = mathEntity.sonuc3;
            model.sonuc4 = mathEntity.sonuc4;

            return View(model);
        }

        public IActionResult AllDetail()
        {
            List<MathDetailsVM> alldetails = _context.mathEntity.Include(a => a.User).Select(q => new MathDetailsVM()
            {
                ID = q.ID,
                input1 = q.input1,
                input2 = q.input2,
                sonuc1 = q.sonuc1,
                sonuc2 = q.sonuc2,
                sonuc3 = q.sonuc3,
                sonuc4 = q.sonuc4,
                UserName = q.User.UserName

            }).ToList();

            return View(alldetails);

        }

       
    }
}

       
