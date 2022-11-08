using DAL.Model;
using IObejects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DataManager
{
    public class EmpManager : IDataRepositroy
    {
        private readonly IMongoCollection<Employee> _employees;
        public EmpManager(IEmpStoreDatabaseSettings settings,IMongoClient mongoClient)
        {
            var database=mongoClient.GetDatabase(settings.DatabaseName);
            _employees=database.GetCollection<Employee>(settings.CollectionName);
        }
        public Employee Create(Employee employee)
        {
           _employees.InsertOne(employee);
            return employee;
        }
        public void Delete(string id)
        {
           _employees.DeleteOne(Employee=>Employee.Id==id);
        }
        public List<Employee> Get()
        {
            return _employees.Find(Employee => true).ToList();
        }
        public Employee Get(string id)
        {
           return _employees.Find(Employee=>Employee.Id==id).FirstOrDefault();
        }

        public void Update(string id, Employee employee)
        {
            _employees.ReplaceOne(Employee=>Employee.Id==id, employee);
        }
    }
}
