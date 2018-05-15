using System;
using System.Collections.Generic;
using System.Text;
using CFLibrary;
using SQLite;
namespace Prime.Database
{
    public class Radiographer : Employee
    {
        public Radiographer()
        {
        }
        //public bool Active { get; set; }
        public Rig Rig { get; set; }
        public List<Equipment> Equipments { get; set; }
        public override void OnSave()
        {
            SQLiteConnection conn = new SQLiteConnection(App.repo.fullPath);
            Type obj = GetType();
            conn.CreateTable<Radiographer>();
            //conn.Insert(this);
            var response = App.repo.GetRadiographer(this.EmployeeName);//conn.Get<Equipment>(this.Oid);

            if (response == null)
            {
                conn.Insert(this);
            }
            else
            {
                conn.Update(this);
            }

            conn.Close();
            base.OnSave();
        }
    }
}
