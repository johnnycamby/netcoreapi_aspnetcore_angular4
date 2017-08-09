using System;
using System.Collections.Generic;
using CoreWebAngularApp.Helpers;
using CoreWebAngularApp.Models;

namespace CoreWebAngularApp.Services.Contracts
{
    public interface IXplicitRepository
    {
        Company GetCompany(Guid companyId);
        PagedList<Company> GetCompanies(XplicitResourceParameters xplicitResourceParameters);
        IEnumerable<Company> GetCompanies(IEnumerable<Guid> companyIds);
        void AddCompany(Company company);
        void DeleteCompany(Company company);
        void UpdateCompany(Company company);
        bool CompanyExists(Guid companyId);

        IEnumerable<Car> GetCarsForCompany(Guid companyId);
        Car GetCarForCompany(Guid companyId, Guid carId);
        void AddCarForCompany(Guid companyId, Car car);
        void UpdateCarForCompany(Car car);
        void DeleteCar(Car car);
        bool Save();

    }
}