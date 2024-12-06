using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    public interface IDBManager
    {
        public string FileName { get; set; }
        // a T method save<T>(T obj) to the database
        public void Save<T>(T obj);
        // a method get() return the database
        List<T> Get<T>();
        // a T method getbyatt<a>(a Atribiute) to get an object by attribute form the database
        public T GetByAtt<T>(string propertyName, object propertyValue);
        public void UpdateAtt<T>(T obj, string attToComper, string propertyName, object propertyValue);
        public void Delete<T>(T obj);

        public void Clear();
    }
}
