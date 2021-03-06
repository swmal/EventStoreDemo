﻿using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.Events
{
    public class CarServiceNeedIdentified : Event
    {
        public string Registration { get; set; }

        public override string Stream => Streams.CarRental;
    }
}
