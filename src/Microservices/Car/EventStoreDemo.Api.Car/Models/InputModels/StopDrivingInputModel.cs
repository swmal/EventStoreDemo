using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventStoreDemo.Api.Car.Models.InputModels
{
    public class StopDrivingInputModel
    {
        public string Driver { get; set; }

        public int DistanceDriven { get; set; }
    }
}
