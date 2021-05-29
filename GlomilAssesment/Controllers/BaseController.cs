using GlomilAssesment.Models.ORM.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GlomilAssesment.Controllers
{
    
    [Authorize]

public class BaseController : Controller
        {
        private readonly GlomilContext _context;
        private readonly IMemoryCache _memoryCache;

        public BaseController(GlomilContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }


        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}

