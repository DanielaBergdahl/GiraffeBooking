﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiraffeBooking.Models.ViewModels
{
    public class EditBookingViewModel
    {
        public List<Giraffe> Giraffes { get; set; }
        public Booking Booking { get; set; }
    }
}
