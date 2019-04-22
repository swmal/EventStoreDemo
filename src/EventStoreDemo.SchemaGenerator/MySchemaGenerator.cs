using EventStoreDemo.Domain;
using EventStoreDemo.Domain.Events;
using NJsonSchema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EventStoreDemo.SchemaGenerator
{
    public static class MySchemaGenerator<T>
        where T : AggregateRoot, new()
    {
        public static void GenerateSchemas()
        {
            var eventTypes = GetAggregateEventTypes();
            foreach (var eventType in eventTypes)
            {
                GenerateSchema(eventType, typeof(T).Name, "events");
            }
            var commandTypes = GetAggregateCommandTypes();
            foreach (var commandType in commandTypes)
            {
                GenerateSchema(commandType, typeof(T).Name, "commands");
            }
        }

        private static IEnumerable<Type> GetAggregateEventTypes()
        {
            var carAssembly = Assembly.GetAssembly(typeof(T));
            Type[] types = carAssembly.GetTypes();

            var eventTypes = from t in types
                             where (typeof(Event).IsAssignableFrom(t))
                             select t;

            return eventTypes;
        }

        private static IEnumerable<Type> GetAggregateCommandTypes()
        {
            var assembly = Assembly.GetAssembly(typeof(T));
            Type[] types = assembly.GetTypes();

            var eventTypes = from t in types
                             where (typeof(Command<T>).IsAssignableFrom(t))
                             select t;

            return eventTypes;
        }

        private static string GetOutputDir(string outputFolder, string subfolder)
        {
            var baseDir = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..");
            var outputDir = Path.Combine(baseDir, "output", outputFolder, subfolder);
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);
            return outputDir;
        }

        private static async void GenerateSchema(Type type, string outputFolder, string subfolder)
        {
            var fileName = type.Name + ".json";
            var schema = await JsonSchema4.FromTypeAsync(type);
            var json = schema.ToJson();

            var outputDir = GetOutputDir(outputFolder, subfolder);
            var filePath = Path.Combine(outputDir, fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);

            File.WriteAllText(filePath, json);
        }
    }
}
