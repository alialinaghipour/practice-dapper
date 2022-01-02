using PracticeDapper.Contracts;
using PracticeDapper.Models;
using System.Collections.Generic;
using System.Linq;

namespace PracticeDapper.Repository
{
    public class CompanyRepositoryEF : ICompanyRepository
    {
        private readonly DapperDbContaxt contaxt;

        public CompanyRepositoryEF(DapperDbContaxt contaxt)
        {
            this.contaxt = contaxt;
        }
        public void Add(Company company)
        {
            contaxt.Add(company);
            contaxt.SaveChanges(); 
        }

        public void Delete(Company company)
        {
            contaxt.Remove(company);
            contaxt.SaveChanges();
        }

        public void Delete(int id)
        {
            var company=GetById(id);
            Delete(company);
            contaxt.SaveChanges();
        }

        public List<Company> GetAll()
        {
            return contaxt.Companies.ToList();
        }

        public Company GetById(int id)
        {
            return contaxt.Companies.Find(id);
        }

        public void Update(Company company)
        {
            throw new System.NotImplementedException();
        }
    }
}
