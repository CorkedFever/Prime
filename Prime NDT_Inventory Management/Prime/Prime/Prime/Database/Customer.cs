using System;
using System.Collections.Generic;
using System.Text;
using CFLibrary;
using SQLite;
namespace Prime.Database
{
    public class Customer : SimpleObject
    {
        public Customer()
        {

        }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        /// <summary>
        /// Need To be Stored PDF in the Database
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// Need To be Stored PDF in the Database
        /// </summary>
        public string RequiredCertifications { get; set; }

        /// <summary>
        /// Need To be Stored PDF in the Database
        /// </summary>
        public string RequiredSafetyTraining { get; set; }

        public override void OnSave()
        {
            SQLiteConnection conn = new SQLiteConnection(App.repo.fullPath);
            Type obj = GetType();
            conn.CreateTable<Customer>();
            //conn.Insert(this);
            var response = App.repo.GetCustomer(this.CustomerName);//conn.Get<Equipment>(this.Oid);

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
