using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Train
{
    public class DBManager : IDBManager
    {
        public string FileName { get; set; }

        public DBManager(string fileName)   
        {
            FileName = fileName;
        }

        public T Save<T>(T obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            System.IO.File.WriteAllText(FileName, json);
            return obj;
        }

        public T Get<T>(T obj)
        {
            string json = System.IO.File.ReadAllText(FileName);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public T GetByAtt<T, a>(T obj, a Attribute)
        {
            string json = System.IO.File.ReadAllText(FileName);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public T Update<T>(T obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            System.IO.File.WriteAllText(FileName, json);
            return obj;
        }

        public T Delete<T>(T obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            System.IO.File.WriteAllText(FileName, json);
            return obj;
        }
    }
}
