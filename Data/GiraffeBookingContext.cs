using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiraffeBooking.Models;

namespace GiraffeBooking.Data
{
    public static class GiraffeBookingContext
    {
        public static List<Giraffe> Giraffes { get; set; }
        public static List<Booking> Bookings { get; set; }

        static GiraffeBookingContext()
        {
            Giraffes = new List<Giraffe>();
            Bookings = new List<Booking>();

            Seed();

        }

        private static void Seed()
        {
            var giraffe1 = new Giraffe() { Id = Guid.NewGuid(), Name = "Dotty", DegreeOfTameness = 1, Size = 3, Price = 1000 };
            var giraffe2 = new Giraffe() { Id = Guid.NewGuid(), Name = "Filaff", DegreeOfTameness = 0, Size = 1, Price = 750 };
            var giraffe3 = new Giraffe() { Id = Guid.NewGuid(), Name = "Kolinara", DegreeOfTameness = 5, Size = 2, Price = 2000 };


            Giraffes.Add(giraffe1);
            Giraffes.Add(giraffe2);
            Giraffes.Add(giraffe3);

            var booking1 = new Booking
            {
                Id = Guid.NewGuid(),
                GiraffeName = giraffe1.Name,
                GiraffeId = giraffe1.Id,
                BookedDate = new DateTime(2020, 12, 03),
                UserName = "Roberta",
                Email = "robertabert@robert.com"
            };

            var booking2 = new Booking
            {
                Id = Guid.NewGuid(),
                GiraffeName = giraffe2.Name,
                GiraffeId = giraffe2.Id,
                BookedDate = new DateTime(2021, 01, 12),
                UserName = "Mio",
                Email = "mio@mia.com"
            };

            Bookings.Add(booking1);
            Bookings.Add(booking2);

        }
    }
}