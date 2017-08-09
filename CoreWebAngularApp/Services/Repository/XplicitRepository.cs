using System;
using System.Collections.Generic;
using System.Linq;
using CoreWebAngularApp.Data;
using CoreWebAngularApp.Dto;
using CoreWebAngularApp.Extensions;
using CoreWebAngularApp.Helpers;
using CoreWebAngularApp.Models;
using CoreWebAngularApp.Services.Contracts;

namespace CoreWebAngularApp.Services.Repository
{
    public class XplicitRepository : IXplicitRepository
    {
        private readonly XplicitDbContext _context;
        private IPropertyMappingService _propertyMappingService;

        public XplicitRepository(XplicitDbContext context, IPropertyMappingService propertyMappingService)
        {
            _context = context;
            _propertyMappingService = propertyMappingService;
        }
        
        public void AddCompany(Company company)
        {
            company.Id = Guid.NewGuid();
            _context.Companies.Add(company);

            // let repository fill the id (instead of using identity columns)
            if (company.Cars.Any())
            {
                company.Cars.ForEach(c => c.Id = Guid.NewGuid());
            }
        }

        public void AddCarForCompany(Guid companyId, Car car)
        {
            var company = GetCompany(companyId);

            if (company != null)
            {
                // if there isn't an id filled out (ie: we're not upserting),
                // we should generate one
                if (car.Id == null)
                {
                    car.Id = Guid.NewGuid();
                }
                company.Cars.Add(car);
            }
        }

        public bool CompanyExists(Guid companyId)
        {
            return _context.Companies.Any(c => c.Id == companyId);
        }

        public Company GetCompany(Guid companyId)
        {
            return _context.Companies.FirstOrDefault(c => c.Id == companyId);
        }

        public IEnumerable<Company> GetCompanies(IEnumerable<Guid> companyIds)
        {
            return _context.Companies.Where(c => companyIds.Contains(c.Id))
                .OrderBy(c => c.CompanyName)
                .ThenBy(c => c.FoundedAt)
                .ToList();
        }

        public PagedList<Company> GetCompanies(XplicitResourceParameters xplicitResourceParameters)
        {

            var collectionBeforePaging = _context.Companies.ApplySort(xplicitResourceParameters.OrderBy,
                _propertyMappingService.GetPropertyMapping<CompanyDto, Company>());

            // Filtering by 'name'
            if (!string.IsNullOrEmpty(xplicitResourceParameters.CompanyName))
            {
                var companyNameForWhereClause = xplicitResourceParameters.CompanyName.Trim().ToLowerInvariant();
                collectionBeforePaging =
                    collectionBeforePaging.Where(c => c.CompanyName.ToLowerInvariant() == companyNameForWhereClause);
            }

            // Searching a collection
            if (!string.IsNullOrEmpty(xplicitResourceParameters.SearchQuery))
            {
                var searchQueryForWhereClause = xplicitResourceParameters.SearchQuery.Trim();
                collectionBeforePaging =
                    collectionBeforePaging.Where(s => s.CompanyName.ToLowerInvariant()
                        .Contains(searchQueryForWhereClause));
            }

            return PagedList<Company>.Create(collectionBeforePaging, xplicitResourceParameters.PageNumber,
                xplicitResourceParameters.PageSize);
        }

        public IEnumerable<Car> GetCarsForCompany(Guid companyId)
        {
            return _context.Cars.Where(c => c.CompanyId == companyId)
                .OrderBy(c => c.CarName).ToList();
        }

        public Car GetCarForCompany(Guid companyId, Guid carId)
        {
            return _context.Cars.FirstOrDefault(c => c.CompanyId == companyId && c.Id == carId);
        }

        public void UpdateCompany(Company company)
        {
            // no code in this implementation
        }

        public void UpdateCarForCompany(Car car)
        {
            // no code in this implementation
        }

        public void DeleteCompany(Company company)
        {
            _context.Companies.Remove(company);
        }

        public void DeleteCar(Car car)
        {
            _context.Cars.Remove(car);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}