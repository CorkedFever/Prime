using System;
using System.Collections.Generic;
using System.Text;
using CFLibrary;
using SQLite;
namespace Prime.Database
{
    public class Employee : SimpleObject
    {
        public Employee()
        {

        }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set;}
        public bool IsEmployed { get; set; }
        public bool IsJumpedShip { get; set; }
        public bool IsLaidOff { get; set; }

        public override void OnSave()
        {
            SQLiteConnection conn = new SQLiteConnection(App.repo.fullPath);
            Type obj = GetType();
            conn.CreateTable<Employee>();
            //conn.Insert(this);
            var response = App.repo.GetEmployee(this.EmployeeName);//conn.Get<Equipment>(this.Oid);

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
