using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Train
{
    public class DBManager : IDBManager
    {
        public string FileName { get; set; }

        public DBManager(string fileName)
        {
            FileName = fileName;
        }

        public void Save<T>(T obj)
        {
            var jsonData = DBHelper.ReadJsonFile(FileName);
            var objects = string.IsNullOrEmpty(jsonData) ? new List<T>() : DBHelper.DeserializeJson<T>(jsonData);

            objects.Add(obj);

            var updatedJson = DBHelper.SerializeJson(objects);
            File.WriteAllText(FileName, updatedJson);
        }

        public List<T> Get<T>()
        {
            // Read JSON data from the file
            string jsonData = DBHelper.ReadJsonFile(FileName);

            // Deserialize JSON into a list of objects
            var objects = DBHelper.DeserializeJson<T>(jsonData);

            // Ensure all deserialized objects implement the specified interface (if T is an interface)
            if (typeof(T).IsInterface)
            {
                if (!objects.All(obj => obj != null && typeof(T).IsAssignableFrom(obj.GetType())))
                {
                    throw new InvalidOperationException($"Not all deserialized objects implement the interface {typeof(T).Name}.");
                }
            }

            return objects;
        }

        public T GetByAtt<T>(string propertyName, object propertyValue)
        {
            var jsonData = DBHelper.ReadJsonFile(FileName);
            var objects = DBHelper.DeserializeJson<T>(jsonData);
            
            return objects.FirstOrDefault(obj =>
            {
                var property = DBHelper.GetProperty<T>(propertyName);
                return Equals(property.GetValue(obj), propertyValue);
            });
        }

        public void UpdateAtt<T>(T obj,string attToComper , string propertyName, object propertyValue)
        {
            var jsonData = DBHelper.ReadJsonFile(FileName);
            var objects = DBHelper.DeserializeJson<T>(jsonData);

            //var targetObject = objects.FirstOrDefault(o =>
            //    DBHelper.AreObjectsEqualExcluding(obj, o, propertyName));
            var targetObject = objects.FirstOrDefault(o => DBHelper.AreObjectsEqualByProperty(obj,o, attToComper));

            if (targetObject == null)
            {
                throw new InvalidOperationException("The object to update was not found.");
            }

            
            var propertyToUpdate = DBHelper.GetProperty<T>(propertyName);
            propertyToUpdate.SetValue(targetObject, propertyValue);

            var updatedJson = DBHelper.SerializeJson(objects);
            File.WriteAllText(FileName, updatedJson);
        }

        public void Delete<T>(T obj)
        {
            var jsonData = DBHelper.ReadJsonFile(FileName);
            var objects = DBHelper.DeserializeJson<T>(jsonData);

            objects = objects.Where(o => !DBHelper.AreAllPropertiesEqual(obj, o)).ToList();

            var updatedJson = DBHelper.SerializeJson(objects);
            File.WriteAllText(FileName, updatedJson);
        }
    }
}
