using GlomilAssesment.Models.ORM.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlomilAssesment.Controllers
{
    public class MenuController : BaseController
    {
        private readonly GlomilContext _context;
        public MenuController(GlomilContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
