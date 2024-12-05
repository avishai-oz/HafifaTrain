using System;
using System.IO;
using System.Reflection;

namespace Train
{
    public static class Validators
    {
        
        public static void FileExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file '{filePath}' does not exist.");
            }
        }

        public static bool UserNameExists(string userName, IDBManager db)
        {
            return db.GetByAtt<User>("name", userName) != null;
        }

        public static bool UserIdExists(int userId, IDBManager db)
        {
            return db.GetByAtt<User>("id", userId) != null;
        }

        public static bool DoesPropertyExist<T>(string propertyName)
        {
            return typeof(T).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase) != null;
        }

        
    }
}
