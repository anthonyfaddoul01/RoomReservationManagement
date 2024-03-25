using Microsoft.EntityFrameworkCore;
using RoomManagement2.Core;
using RoomManagement2.Core.Models;
using RoomManagement2.Core.Repositories;
using RoomManagement2.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomManagement2.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Company> CreateCompany(Company newCompany)
        {
            await _unitOfWork.Companies.AddAsync(newCompany);
            await _unitOfWork.CommitAsync();
            return newCompany;
        }

        public async Task DeleteCompany(Company company)
        {
            _unitOfWork.Companies.Remove(company);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _unitOfWork.Companies.GetAllAsync();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await _unitOfWork.Companies.GetByIdAsync(id);
        }

        public async Task UpdateCompany(Company companyToBeUpdated, Company company)
        {
            companyToBeUpdated.Name = company.Name;
            companyToBeUpdated.Email = company.Email;
            companyToBeUpdated.Status = company.Status;
            companyToBeUpdated.Description = company.Description;

            await _unitOfWork.CommitAsync();
        }
    }
}
