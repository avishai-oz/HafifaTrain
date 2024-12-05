using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace Train
{
    public static class DBHelper
    {
        public static string ReadJsonFile(string filePath)
        {
            Validators.FileExists(filePath);
            string jsonData = File.ReadAllText(filePath);
            //if (string.IsNullOrWhiteSpace(jsonData))
            //{
            //    throw new InvalidOperationException("The file is empty or invalid.");
            //}
            return jsonData;
        }

        public static List<T> DeserializeJson<T>(string jsonData)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            var objects = JsonConvert.DeserializeObject<List<T>>(jsonData, settings);
            //if (objects == null)
            //{
            //    throw new InvalidOperationException("Failed to deserialize JSON data.");
            //}
            return objects;
        }

        public static string SerializeJson<T>(List<T> objects)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            return JsonConvert.SerializeObject(objects, Formatting.Indented, settings);
        }

        public static PropertyInfo GetProperty<T>(string propertyName)
        {
            var property = typeof(T).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (property == null)
            {
                throw new InvalidOperationException($"Property '{propertyName}' does not exist on type '{typeof(T).Name}'.");
            }
            return property;
        }
        public static bool AreAllPropertiesEqual<T>(T obj1, T obj2)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var value1 = property.GetValue(obj1);
                var value2 = property.GetValue(obj2);
                if (!Equals(value1, value2))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool AreObjectsEqualExcluding<T>(T obj1, T obj2, string excludeProperty)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                if (property.Name.Equals(excludeProperty, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var value1 = property.GetValue(obj1);
                var value2 = property.GetValue(obj2);

                if (!Equals(value1, value2))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AreObjectsEqualByProperty<T>(T obj1, T obj2, string propertyName)
        {
            // קבלת מידע על התכונה באמצעות Reflection
            var property = typeof(T).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            if (property == null)
            {
                throw new ArgumentException($"Property '{propertyName}' does not exist on type '{typeof(T).Name}'.");
            }

            // השגת הערכים של התכונה עבור שני האובייקטים
            var value1 = property.GetValue(obj1);
            var value2 = property.GetValue(obj2);

            // בדיקה אם הערכים שווים
            return Equals(value1, value2);
        }
    }
}
