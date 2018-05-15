using System;
using System.Collections.Generic;
using System.Text;
using CFLibrary;
using SQLite;

namespace Prime.Database
{
    public class Equipment : SimpleObject
    {
        public Equipment()
        {
            StartDate = DateTime.Now;
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string SerialNumber{ get; set; }

        public string Description { get; set; }

        public string RIGNumber { get; set; }

        /// <summary>
        /// Guys in the field
        /// </summary>
        public string Radiographers { get; set; }

        /// <summary>
        /// Different Equipment Types
        /// 1. Darkroom
        /// 2. Consumables
        ///     ->Film
        ///     ->Rig Consumables
        /// 3. Personal
        ///     ->Dosimeters
        ///     ->Raid Alarms
        /// 
        /// </summary>
        public string EquipmentType { get; set; }

        public int Quanity { get; set; }

        public double Cost { get; set; }

        public bool Reorder { get; set; }

        public string Location { get; set; }
        //company branch
        public string Shop { get; set; }

        public string Company { get; set; }

        public double TotalCost
        {
            get
            {
                return Cost * Quanity;
            }
        }

        public bool IsBroken { get; set; }

        public override void OnSave()
        {

            SQLiteConnection conn = new SQLiteConnection(App.repo.fullPath);
            Type obj = GetType();
            conn.CreateTable<Equipment>();
            //conn.Insert(this);
            var response = App.repo.GetEquipment(this.SerialNumber);//conn.Get<Equipment>(this.Oid);

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

        public void Update()
        {
            SQLiteConnection conn = new SQLiteConnection(App.repo.fullPath);
            Type obj = GetType();
            conn.CreateTable<Equipment>();
            conn.Update(this);
            conn.Close();
            base.OnSave();
        }

        public override void OnDelete()
        {
            SQLiteConnection conn = new SQLiteConnection(App.repo.fullPath);
            conn.Delete(this);
            conn.Close();
            base.OnDelete();
        }

    }
}
