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
        public T Save<T>(T obj);
        // a T method get<T>(T obj) to get an object from the database
        public T Get<T>(T obj);
        // a T method getbyatt<T,a>(T obj, a Atribiute) to get an object by attribute form the database
        public T GetByAtt<T, a>(T obj, a Attribute);
        // a T method update<T>(T obj) to update an object in the database
        public T Update<T>(T obj);
        // a T method delete<T>(T obj) to delete an object from the database
        public T Delete<T>(T obj);
    }
}
