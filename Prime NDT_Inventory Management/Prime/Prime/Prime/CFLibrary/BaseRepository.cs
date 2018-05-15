using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using SQLite;
namespace CFLibrary
{
    public class BaseRepository
    {
        public string dbName { get; set; }
        public string folderPath { get; set; }
        public string fullPath { get; set; }
        public BaseRepository()
        {

        }
        public BaseRepository(string DBName, string FolderPath)
        {
            dbName = DBName;
            folderPath = FolderPath;
            fullPath = Path.Combine(folderPath, dbName);
            
        }
        public BaseRepository(string FullPath)
        {
            fullPath = FullPath;
        }

        //public void Save<T>(T DataObject)
        //{
        //    using (SQLiteConnection conn = new SQLiteConnection(fullPath))
        //    {
        //        conn.CreateTable<T>();
        //        conn.Update(DataObject, typeof(T));
        //    }
        //}
        //public List<T> GetObjects<T>()
        //{
        //    using (SQLiteConnection conn = new SQLiteConnection(fullPath))
        //    {
        //        conn.CreateTable<T>();
        //        List<T> objList = new List<T>();
        //        objList = conn.Table<T>();
        //        return objList;
        //    }
        //}

    }
}
