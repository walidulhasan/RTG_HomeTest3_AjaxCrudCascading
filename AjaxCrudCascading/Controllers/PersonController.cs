using AjaxCrudCascading.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxCrudCascading.Controllers
{
    public class PersonController : Controller
    {
        #region Class Constractor
        // GET: PersonController
        private readonly PersonDbContext _context;
        public PersonController(PersonDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Data View with Cascading Dropdown
        public ActionResult Index()
        {
            ViewBag.Countries = new SelectList(_context.countries, "CountryId", "CountryName");
            var addressBookDbContext = _context.persons.Include(p => p.Countrys).Include(p => p.Citys);
            return View(addressBookDbContext.ToList());
        }
        //For City name Cascading Dropdown 
        public JsonResult getCity(int id)
        {
            var division = _context.citys.Where(x => x.CountryId == id).ToList();
            return Json(new SelectList(division, "CityId", "DivisionName"));
        }
        public IActionResult GetAllPerson()
        {
            
            var person = _context.persons.ToList();
            //var person = _context.persons.Include("Country")
            //.Select(b => new Country()
            //{
            //    CountryId = b.CountryId,
            //    CountryName = _context.countries
            //                .Where(c => c.CountryId == b.CountryId)
            //                .Select(c => c.CountryName)
            //                .SingleOrDefault()
            //}).ToList();


            return Json(person, new Newtonsoft.Json.JsonSerializerSettings());
        }
        #endregion

        //GET person By Id
        public ActionResult Get(int id)
        {
            var product = _context.persons.ToList().Find(x => x.Id == id);
            return Json(product, new Newtonsoft.Json.JsonSerializerSettings());
        }

        #region Person Create
        [HttpPost]
        public IActionResult Create(Person person)
        {
            
            if (ModelState.IsValid)
            {
                _context.persons.Add(person);
                _context.SaveChanges();
            }
           
            return  Json("ok");

        }
        #endregion
        //Update a product

        [HttpPost]
        public ActionResult Update(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            return Json(person, new Newtonsoft.Json.JsonSerializerSettings());
        }
        #region Person Delete
        //GET: People/Delete/5
        //public IActionResult Delete(int? id)
        //{
        //    var del = (from Client in _context.persons where Client.Id == id select Client).FirstOrDefault();
        //    _context.persons.Remove(del);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var person = _context.persons.ToList().Find(x => x.Id == id);
            if (person != null)
            {
                _context.persons.Remove(person);
                _context.SaveChanges();
            }
            return Json(person, new Newtonsoft.Json.JsonSerializerSettings());
        }

        #endregion




        //private bool PersonExists(int id)
        //{
        //    return _context.persons.Any(e => e.Id == id);
        //}

    }
}
