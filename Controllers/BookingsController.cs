using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiraffeBooking.Models;
using GiraffeBooking.Models.ViewModels;
using GiraffeBooking.Data;


namespace GiraffeBooking.Controllers
{
    public class BookingsController : Controller
    {
        public BookingsController()
        {

        }

        // GET: Bookings
        public IActionResult Index()
        {
            var bookings = GiraffeBookingContext.Bookings;

            return View(bookings);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            var createBookingViewModel = new CreateBookingViewModel() { Giraffes = GiraffeBookingContext.Giraffes };
            return View(createBookingViewModel);
        }


        // POST: Bookings/Create
        [HttpPost]
        // från vyn till metoden i controllern
        public IActionResult Create(Booking booking)
        {
            var giraffe = GiraffeBookingContext.Giraffes.FirstOrDefault(r => r.Id == booking.GiraffeId);

            if (giraffe == null)
            {
                return RedirectToAction(nameof(Create));
            }
            
            if (ModelState.IsValid)
            {
                booking.Id = Guid.NewGuid();
                booking.GiraffeName = giraffe.Name;
                GiraffeBookingContext.Bookings.Add(booking);
                return RedirectToAction("Index");
            }

            return View(giraffe);
        }

        // GET: Bookings/Edit/5
        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = GiraffeBookingContext.Bookings.FirstOrDefault(b => b.Id == id)
                ;

            if (booking == null) 
            {
                return NotFound();
            }

            var editBookingViewModel = new EditBookingViewModel() { Booking = booking, Giraffes = GiraffeBookingContext.Giraffes };
            return View(editBookingViewModel);
        }

        // POST: Bookings/Edit/5 
        [HttpPost]
        public IActionResult Edit(Booking booking)
        {
            booking.GiraffeName = GiraffeBookingContext.Giraffes.FirstOrDefault(r => r.Id == booking.GiraffeId).Name;

            var bookingIndex= GiraffeBookingContext.Bookings.FindIndex(m => m.Id == booking.Id);



            if (bookingIndex == -1)
            {
                return NotFound();
            }

            GiraffeBookingContext.Bookings[bookingIndex] = booking;

            return RedirectToAction(nameof(Index));
        }

        // GET: Booking/Delete/5
        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giraffe = GiraffeBookingContext.Bookings.FirstOrDefault(r => r.Id == id);

            if (giraffe == null)
            {
                return NotFound();
            }

            return View(giraffe);

        }

        // POST: Bookings/Delete/5
        [HttpPost]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var giraffe = GiraffeBookingContext.Bookings.FirstOrDefault(r => r.Id == id);

            if (giraffe == null)
            {
                return NotFound();
            }

            GiraffeBookingContext.Bookings.Remove(giraffe);

            return RedirectToAction("Index");
        }

    }
}
