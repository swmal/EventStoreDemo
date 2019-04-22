using EventStoreDemo.Domain;
using EventStoreDemo.Domain.Booking;
using EventStoreDemo.Domain.Car;
using EventStoreDemo.Domain.CarRental;
using EventStoreDemo.Domain.Events;
using NJsonSchema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EventStoreDemo.SchemaGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            MySchemaGenerator<Car>.GenerateSchemas();
            MySchemaGenerator<CarRental>.GenerateSchemas();
            MySchemaGenerator<Booking>.GenerateSchemas();
        }

        
    }
}
