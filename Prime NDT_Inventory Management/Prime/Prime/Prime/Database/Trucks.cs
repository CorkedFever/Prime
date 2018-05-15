using System;
using System.Collections.Generic;
using System.Text;
using CFLibrary;
using SQLite;
namespace Prime.Database
{
    public class Truck : SimpleObject
    {
        public Truck()
        {

        }
        public bool IsBroken { get; set; }
        public string Condition { get; set; }
        public string TruckNumber { get; set; }
        public double Cost { get; set; }
        public override void OnSave()
        {
            SQLiteConnection conn = new SQLiteConnection(App.repo.fullPath);
            Type obj = GetType();
            conn.CreateTable<Truck>();
            //conn.Insert(this);
            var response = App.repo.GetTruck(this.TruckNumber);//conn.Get<Equipment>(this.Oid);

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
