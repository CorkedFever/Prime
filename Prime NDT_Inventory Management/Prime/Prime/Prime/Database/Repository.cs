using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CFLibrary;
using SQLite;

namespace Prime.Database
{
    public class Repository : BaseRepository
    {

        public Repository()
        {
        }
        public Repository(string DBName, string FolderPath)
        {
            dbName = DBName;
            folderPath = FolderPath;
            fullPath = Path.Combine(folderPath, dbName);

        }
        public Repository(string FullPath)
        {
            fullPath = FullPath;
        }

        public List<Equipment> GetFilmConsumables()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(fullPath))
                {
                    List<Equipment> equipments = new List<Equipment>();
                    conn.CreateTable<Equipment>();
                    equipments = conn.Table<Equipment>().ToList<Equipment>();
                    //List<Equipment> results = equipments.FindAll(s => s.EquipmentType == "");//Where(s => s.EquipmentType == "").ToList<Equipment>();
                    return equipments.FindAll(s => s.EquipmentType == "Consumables - Film");
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Equipment> GetRigConsumables()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(fullPath))
                {
                    List<Equipment> equipments = new List<Equipment>();
                    conn.CreateTable<Equipment>();
                    equipments = conn.Table<Equipment>().ToList<Equipment>();
                    //List<Equipment> results = equipments.FindAll(s => s.EquipmentType == "");//Where(s => s.EquipmentType == "").ToList<Equipment>();
                    return equipments.FindAll(s => s.EquipmentType == "Consumables - Rig");
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public Customer GetCustomer(string CustomerName)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(fullPath))
                {
                    Customer customer = new Customer();
                    conn.CreateTable<Customer>();
                    customer = conn.FindWithQuery<Customer>("SELECT * FROM Customer WHERE CustomerName = ? AND Active = ?", CustomerName, true);
                    return customer;

                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Customer> GetCustomers()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(fullPath))
                {
                    List<Customer> customers = new List<Customer>();
                    conn.CreateTable<Customer>();
                    customers = conn.Table<Customer>().ToList<Customer>();
                    return customers;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Employee GetEmployee(string EmployeeName)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(fullPath))
                {
                    Employee employee = new Employee();
                    conn.CreateTable<Employee>();
                    employee = conn.FindWithQuery<Employee>("SELECT * FROM Employee WHERE EmployeeName = ?", EmployeeName);
                    return employee;

                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Employee> GetEmployees()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(fullPath))
                {
                    List<Employee> employees = new List<Employee>();
                    conn.CreateTable<Employee>();
                    employees = conn.Table<Employee>().ToList<Employee>();
                    return employees;
                }
            }
            catch (Exception ex)
            {
                return null;
                
            }

        }

        public Equipment GetEquipment(string SKU)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(fullPath))
                {
                    Equipment equipment = new Equipment();
                    conn.CreateTable<Equipment>();
                    equipment = conn.FindWithQuery<Equipment>("SELECT * FROM Equipment WHERE SerialNumber = ?", SKU);
                    return equipment;

                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Equipment> GetEquipments()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(fullPath))
                {
                    List<Equipment> equipments = new List<Equipment>();
                    conn.CreateTable<Equipment>();
                    equipments = conn.Table<Equipment>().ToList<Equipment>();
                    return equipments;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<Equipment> GetEquipment()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(fullPath))
                {
                    List<Equipment> equipments = new List<Equipment>();
                    equipments = conn.Table<Equipment>().ToList<Equipment>();
                    return equipments;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Radiographer GetRadiographer(string EmployeeName)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(fullPath))
                {
                    Radiographer radiographer = new Radiographer();
                    conn.CreateTable<Radiographer>();
                    radiographer = conn.FindWithQuery<Radiographer>("SELECT * FROM Radiographer WHERE SKU = ?", EmployeeName);
                    return radiographer;

                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Radiographer> GetRadiographers()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(fullPath))
                {
                    List<Radiographer> radiographers = new List<Radiographer>();
                    conn.CreateTable<Radiographer>();
                    radiographers = conn.Table<Radiographer>().ToList<Radiographer>();
                    return radiographers;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Rig GetRig(string RigNumber)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(fullPath))
                {
                    Rig rig = new Rig();
                    conn.CreateTable<Rig>();
                    rig = conn.FindWithQuery<Rig>("SELECT * FROM Rig WHERE RigNumber = ?", RigNumber);
                    return rig;

                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<Rig> GetRigs()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(fullPath))
                {
                    List<Rig> rigs = new List<Rig>();
                    conn.CreateTable<Rig>();
                    rigs = conn.Table<Rig>().ToList<Rig>();
                    return rigs;
                }
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public Truck GetTruck(string TruckNumber)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(fullPath))
                {
                    Truck truck = new Truck();
                    conn.CreateTable<Truck>();
                    truck = conn.FindWithQuery<Truck>("SELECT * FROM Truck WHERE TruckNumber = ?", TruckNumber);
                    return truck;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Truck> GetTrucks()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(fullPath))
                {
                    List<Truck> trucks = new List<Truck>();
                    conn.CreateTable<Truck>();
                    trucks = conn.Table<Truck>().ToList<Truck>();
                    return trucks;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
