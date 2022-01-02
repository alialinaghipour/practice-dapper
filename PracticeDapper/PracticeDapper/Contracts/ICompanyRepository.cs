using PracticeDapper.Models;
using System.Collections.Generic;

namespace PracticeDapper.Contracts
{
    public interface ICompanyRepository
    {
        void Add(Company company);
        void Update(Company company);
        void Delete(Company company);
        Company GetById(int id);
        List<Company> GetAll();
    }
}
