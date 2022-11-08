using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IObejects
{
    public interface IDataRepositroy
    {
        List<Employee> Get();
        Employee Get(string id);
        Employee Create(Employee employee);
        void Update(string id,Employee employee);
        void Delete(string id);
    }
}
