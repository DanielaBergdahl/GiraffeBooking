using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiraffeBooking.Models;
using GiraffeBooking.Data;

namespace GiraffeBooking.Controllers
{
    public class GiraffesController : Controller
    {
        public GiraffesController()
        {
            
        }

        // GET: Giraffes
        public IActionResult Index()
        {
            var giraffes = GiraffeBookingContext.Giraffes;

            return View(giraffes);
        }

        // GET: Giraffes/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Giraffes/Create
        [HttpPost]
        // från vyn till metoden i controllern.
        public IActionResult Create(Giraffe giraffe)
        {
            if (ModelState.IsValid)
            {
                giraffe.Id = Guid.NewGuid();
                GiraffeBookingContext.Giraffes.Add(giraffe);
                return RedirectToAction("Index");
            }

            return View(giraffe);
        }

        // GET: Giraffes/Edit/5
        public IActionResult Edit(Guid id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var giraffe = GiraffeBookingContext.Giraffes.FirstOrDefault(r => r.Id == id);

            if(giraffe == null)
            {
                return NotFound();
            }

            return View(giraffe);

        }

        // POST: Giraffes/Edit/5
        [HttpPost]
        public IActionResult Edit(Giraffe giraffe) 
        {
            if (ModelState.IsValid)
            {
                var giraffeIndex = GiraffeBookingContext.Giraffes.FindIndex(m => m.Id == giraffe.Id);

                if (giraffeIndex == -1)
                {
                    return NotFound();
                }

                GiraffeBookingContext.Giraffes[giraffeIndex] = giraffe;

                return RedirectToAction(nameof(Index));
            }

            return View(giraffe);

        }

        // GET: Giraffes/Delete/5
        public IActionResult Delete(Guid id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var giraffe = GiraffeBookingContext.Giraffes.FirstOrDefault(r => r.Id == id);

            if (giraffe == null)
            {
                return NotFound();
            }

            return View(giraffe);
        }


        // POST: Giraffes/Delete/5
        [HttpPost]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var giraffe = GiraffeBookingContext.Giraffes.FirstOrDefault(r => r.Id == id);

            if (giraffe == null)
            {
                return NotFound();
            }

            GiraffeBookingContext.Giraffes.Remove(giraffe);

            return RedirectToAction("Index");

        }


    }


}
