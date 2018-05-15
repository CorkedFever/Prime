using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using SQLite;
namespace CFLibrary
{
    public class SimpleObject
    {
        public bool Active { get; set; }
        [PrimaryKey]
        public string Oid { get; set; }
        
        

        [Ignore]
        public BaseRepository repository { get; set; }
        public SimpleObject()
        {

            AfterConstruction();
        }
        
        
        public virtual void AfterConstruction()
        {
            if (string.IsNullOrEmpty(Oid))
            {
                Guid guid = Guid.NewGuid();
                Oid = guid.ToString();
            }
            Active = true;

        }

        public void Save()
        {
            OnSave();
        }
        public virtual void OnSave()
        {

            //SQLiteConnection conn = new SQLiteConnection(fullPath);
            //Type obj_type = Assembly.GetCallingAssembly().GetType();// this.GetType();
            //conn.CreateTable(obj_type.GetType());
            //conn.Update(this, GetType());
            //conn.Close();

        }
        public void Delete()
        {
            OnDelete();
        }
        public virtual void OnDelete()
        {
            SQLiteConnection conn = new SQLiteConnection(repository.fullPath);
            conn.Delete(this);
            conn.Close();
        }


    }
}
