using GlomilAssesment.Models.ORM.Context;
using GlomilAssesment.Models.ORM.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlomilAssesment.Controllers
{
    public class AddMathController : Controller
    {
        //private readonly GlomilContext _context;
        //public AddMathController(GlomilContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        //{
        //    _context = context;
        //}
        public IActionResult Index()
        {
            //int sayi1, sayi2;
            //char opt;
            //double sonuc;


            //Console.WriteLine("\n\tMenu");
            //Console.WriteLine("\nTOPLAMA İÇİN + TUŞUNA BASIN");
            //Console.WriteLine("ÇIKARMA İÇİN - TUŞUNA BASIN");
            //Console.WriteLine("ÇARPMA İÇİN * TUŞUNA BASIN");
            //Console.WriteLine("BÖLME İÇİN + TUŞUNA BASIN");

            //Console.Write("\n\n Birinci Sayıyı Girin :");
            //sayi1 = Convert.ToInt32(Console.ReadLine());

            //Console.Write(" İkinci Sayıyı Girin :");
            //sayi2 = Convert.ToInt32(Console.ReadLine());

            //Console.Write("\nİŞLEM YAPMAK İÇİN BİR OPERATÖR SEÇİN:\t");
            //opt = Convert.ToChar(Console.ReadLine());

            //if (opt == '+')
            //{
            //    sonuc = sayi1 + sayi2;
            //    Console.WriteLine("\n{0} + {1} = {2}", sayi1, sayi2, sonuc);
            //}
            //else if (opt == '-')
            //{
            //    sonuc = sayi1 - sayi2;
            //    Console.WriteLine("\n{0} - {1} = {2}", sayi1, sayi2, sonuc);
            //}
            //else if (opt == '*')
            //{
            //    sonuc = sayi1 * sayi2;
            //    Console.WriteLine("\n{0} x {1} = {2}", sayi1, sayi2, sonuc);
            //}
            //else if (opt == '/')
            //{
            //    sonuc = (double)sayi1 / sayi2;
            //    Console.WriteLine("\n{0} / {1} = {2}", sayi1, sayi2, sonuc);
            //}
            //else
            //{
            //    Console.WriteLine("ÜZGÜNÜN YANLIŞ BİR OPERATÖR GİRDİNİZ!");
            //}


            //Console.ReadKey();
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User model)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.UserName = model.UserName;
                user.Password = model.Password;

                //_context.Users.Add(user);
                //_context.SaveChanges();
                return RedirectToAction("Index", "AdminDriver");
            }

            return View();
        }
    }
}
