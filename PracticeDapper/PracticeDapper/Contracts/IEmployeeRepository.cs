using PracticeDapper.Models;
using System.Collections.Generic;

namespace PracticeDapper.Contracts
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        Employee GetById(int id);
        List<Employee> GetAll();
    }
}
