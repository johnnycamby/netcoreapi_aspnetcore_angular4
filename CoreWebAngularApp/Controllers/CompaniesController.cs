using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoreWebAngularApp.Dto;
using CoreWebAngularApp.Dto.Hateoas;
using CoreWebAngularApp.Extensions;
using CoreWebAngularApp.Helpers;
using CoreWebAngularApp.Models;
using CoreWebAngularApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreWebAngularApp.Controllers
{
    [Route("api/companies")]
    public class CompaniesController : Controller
    {
        private readonly IXplicitRepository _xplicitRepository;
        private readonly IPropertyMappingService _propertyMappingService;
        private readonly ITypeHelperService _typeHelperService;
        private readonly IUrlHelper _urlHelper;

        public CompaniesController(IXplicitRepository xplicitRepository, IPropertyMappingService propertyMappingService, ITypeHelperService typeHelperService, IUrlHelper urlHelper)
        {
            _xplicitRepository = xplicitRepository;
            _propertyMappingService = propertyMappingService;
            _typeHelperService = typeHelperService;
            _urlHelper = urlHelper;
        }

        [HttpGet(Name = "GetCompanies")]
        [HttpHead] // to retrieve info in response-headers without transporting the response-body
        public IActionResult GetCompanies(XplicitResourceParameters xplicitResourceParameters, [FromHeader(Name = "Accept")] string mediaType)
        {
            // throw new Exception("testing exception handling....");

            if (!_propertyMappingService.ValidMappingExistsFor<CompanyDto, Company>(xplicitResourceParameters.OrderBy))
            {
                return BadRequest();
            }

            if (!_typeHelperService.TypeHasProperty<CompanyDto>(xplicitResourceParameters.Fields))
            {
                return BadRequest();
            }

            var companiesFromRepo = _xplicitRepository.GetCompanies(xplicitResourceParameters);
            var companies = Mapper.Map<IEnumerable<CompanyDto>>(companiesFromRepo);

            // // HATEOAS & Content negotiation
            if (mediaType == "application/vnd.johnny.hateoas+json")
            {
                var paginationMetadata = new
                {
                    totalCount = companiesFromRepo.TotalCount,
                    pageSize = companiesFromRepo.PageSize,
                    currentPage = companiesFromRepo.CurrentPage,
                    totalPages = companiesFromRepo.TotalPages
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

                var links = CreateLinksForCompanies(xplicitResourceParameters, companiesFromRepo.HasNext,
                    companiesFromRepo.HasPrevious);
                var shapeCompanies = companies.ShapeData(xplicitResourceParameters.Fields);
                var shapedCompaniesWithLinks = shapeCompanies.Select(c =>
                {
                    var companyAsDictionary = c as IDictionary<string, object>;
                    var companyLinks =
                        CreateLinksForCompany((Guid)companyAsDictionary["Id"], xplicitResourceParameters.Fields);
                    companyAsDictionary.Add("links", companyLinks);

                    return companyAsDictionary;
                });

                var linkedCollectionResource = new
                {
                    value = shapedCompaniesWithLinks,
                    links = links
                };

                return Ok(linkedCollectionResource);

            }
            else
            {
                var previousPageLink = companiesFromRepo.HasPrevious
                    ? CreateCompaniesResourceUri(xplicitResourceParameters, ResourceUriType.PreviousPage)
                    : null;
                var nextPageLink = companiesFromRepo.HasNext
                    ? CreateCompaniesResourceUri(xplicitResourceParameters, ResourceUriType.NextPage)
                    : null;

                var paginationMetadata = new
                {
                    totalCount = companiesFromRepo.TotalCount,
                    pageSize = companiesFromRepo.PageSize,
                    currentPage = companiesFromRepo.CurrentPage,
                    totalPages = companiesFromRepo.TotalPages,
                    previousPageLink,
                    nextPageLink
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

                return Ok(companies.ShapeData(xplicitResourceParameters.Fields));

            }
        }

        [HttpGet("{id}", Name = "GetCompany")]
        public IActionResult GetCompany(Guid id, [FromQuery] string fields)
        {
            if (!_typeHelperService.TypeHasProperty<CompanyDto>(fields))
            {
                return BadRequest();
            }

            var companyFromRepo = _xplicitRepository.GetCompany(id);

            if (companyFromRepo == null)
            {
                return NotFound();
            }

            var company = Mapper.Map<CompanyDto>(companyFromRepo);

            var links = CreateLinksForCompany(id, fields);
            var linkedResourceToReturn = company.ShapeData(fields) as IDictionary<string, object>;
            linkedResourceToReturn.Add("links", links);

            return Ok(linkedResourceToReturn);
        }
        
        private string CreateCompaniesResourceUri(XplicitResourceParameters xplicitResourceParameters, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return _urlHelper.Link("GetCompanies", new
                    {
                        fields = xplicitResourceParameters.Fields,
                        orderBy = xplicitResourceParameters.OrderBy,
                        searchQuery = xplicitResourceParameters.SearchQuery,
                        companyName = xplicitResourceParameters.CompanyName,
                        pageNumber = xplicitResourceParameters.PageNumber - 1,
                        pageSize = xplicitResourceParameters.PageSize
                    });

                case ResourceUriType.NextPage:
                    return _urlHelper.Link("GetCompanies", new
                    {
                        fields = xplicitResourceParameters.Fields,
                        orderBy = xplicitResourceParameters.OrderBy,
                        searchQuery = xplicitResourceParameters.SearchQuery,
                        companyName = xplicitResourceParameters.CompanyName,
                        pageNumber = xplicitResourceParameters.PageNumber + 1,
                        pageSize = xplicitResourceParameters.PageSize
                    });

                case ResourceUriType.Current:
                default:
                    return _urlHelper.Link("GetCompanies", new
                    {
                        fields = xplicitResourceParameters.Fields,
                        orderBy = xplicitResourceParameters.OrderBy,
                        searchQuery = xplicitResourceParameters.SearchQuery,
                        companyName = xplicitResourceParameters.CompanyName,
                        pageNumber = xplicitResourceParameters.PageNumber,
                        pageSize = xplicitResourceParameters.PageSize
                    });
            }
        }

        #region HATEOAS --- Dynamic approach ---


        private IEnumerable<LinkDto> CreateLinksForCompany(Guid id, string fields)
        {
            var links = new List<LinkDto>
            {
                string.IsNullOrWhiteSpace(fields) ? new LinkDto(_urlHelper.Link("GetCompany", new {id}), "self", "GET")
                    : new LinkDto(_urlHelper.Link("GetCompany", new {id, fields}), "self", "GET")
            };

            return links;
        }

        private IEnumerable<LinkDto> CreateLinksForCompanies(XplicitResourceParameters xplicitResourceParameters, bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>
            {
                new LinkDto(CreateCompaniesResourceUri(xplicitResourceParameters, ResourceUriType.Current), "self", "GET")
            };

            if (hasNext)
            {
                links.Add(new LinkDto(CreateCompaniesResourceUri(xplicitResourceParameters, ResourceUriType.NextPage), "nextPage", "GET"));
            }

            if (hasPrevious)
            {
                links.Add(new LinkDto(CreateCompaniesResourceUri(xplicitResourceParameters, ResourceUriType.PreviousPage), "previousPage", "GET"));
            }

            return links;
        }
        
        #endregion

    }
}