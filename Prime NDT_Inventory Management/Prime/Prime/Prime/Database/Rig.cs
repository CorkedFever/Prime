using System;
using System.Collections.Generic;
using System.Text;
using CFLibrary;
using SQLite;
namespace Prime.Database
{
    public class Rig : SimpleObject
    {
        public Rig()
        {
        }
        public string RigNumber { get; set; }
        public bool IsBroken { get; set; }
        public override void OnSave()
        {
            SQLiteConnection conn = new SQLiteConnection(App.repo.fullPath);
            Type obj = GetType();
            conn.CreateTable<Rig>();
            //conn.Insert(this);
            var response = App.repo.GetRig(this.RigNumber);//conn.Get<Equipment>(this.Oid);

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
