using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoreWebAngularApp.Dto;
using CoreWebAngularApp.Dto.Hateoas;
using CoreWebAngularApp.Services.Contracts;
using CoreWebAngularApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreWebAngularApp.Controllers
{
    [Route("api/companies/{companyId}/cars")]
    public class CarsController : Controller
    {
        private readonly IXplicitRepository _xplicitRepository;
        private ILogger<CarsController> _logger;
        private readonly IUrlHelper _urlHelper;

        public CarsController(IXplicitRepository xplicitRepository, ILogger<CarsController> logger, IUrlHelper urlHelper)
        {
            _xplicitRepository = xplicitRepository;
            _logger = logger;
            _urlHelper = urlHelper;
        }

        [HttpGet(Name = "GetCarsForCompany")]
        public IActionResult GetCarsForCompany(Guid companyId)
        {
            if (!_xplicitRepository.CompanyExists(companyId))
            {
                return NotFound();
            }

            var carsForCompanyFromRepo = _xplicitRepository.GetCarsForCompany(companyId);
            var carsForCompany = Mapper.Map<IEnumerable<CarDto>>(carsForCompanyFromRepo);

            carsForCompany = carsForCompany.Select(car =>
            {
                car = CreateLinksForCar(car);
                return car;
            });

            var wrapper = new LinkedCollectionResourceWrapperDto<CarDto>(carsForCompany);

            return Ok(CreateLinksForCars(wrapper));
        }

        [HttpGet("{id}", Name = "GetCarForCompany")]
        public IActionResult GetCarForCompany(Guid companyId, Guid id)
        {
            if (!_xplicitRepository.CompanyExists(companyId))
            {
                return NotFound();
            }

            var carForCompanyFromRepo = _xplicitRepository.GetCarForCompany(companyId, id);

            if (carForCompanyFromRepo == null)
            {
                return NotFound();
            }

            var carForCompany = Mapper.Map<CarDto>(carForCompanyFromRepo);

            return Ok(CreateLinksForCar(carForCompany));
        }

        #region ------- HATEOAS --------
        // Base & Wrapper class approach

        private LinkedCollectionResourceWrapperDto<CarDto> CreateLinksForCars(LinkedCollectionResourceWrapperDto<CarDto> wrapper)
        {
            wrapper.Links.Add(new LinkDto(_urlHelper.Link("GetCarsForCompany", new {}), "self", "GET"));

            return wrapper;
        }

        private CarDto CreateLinksForCar(CarDto car)
        {
            car.Links.Add(new LinkDto(_urlHelper.Link("GetCarForCompany", new {id = car.Id}), "self", "GET"));

            return car;
        }

        #endregion


    }
}